using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;

namespace SistemaImpresion
{
    public class ColaImpresion
    {
        private readonly Queue<Trabajo> trabajos = new Queue<Trabajo>();
        private readonly object locker = new object();
        private readonly int capacidad;
        private readonly Estadisticas estadisticas;

        private bool produccionTerminada = false;

        public ColaImpresion(int capacidad, Estadisticas estadisticas)
        {
            this.capacidad = capacidad;
            this.estadisticas = estadisticas;
        }

        public void AgregarTrabajo(Trabajo trabajo)
        {
            lock (locker)
            {
                Stopwatch? cronometroBloqueo = null;

                while (trabajos.Count >= capacidad)
                {
                    if (cronometroBloqueo == null)
                    {
                        cronometroBloqueo = Stopwatch.StartNew();

                        Logger.Escribir(
                            $"Aplicación {trabajo.AplicacionId} bloqueada: cola llena.");
                    }

                    Monitor.Wait(locker);
                }

                if (cronometroBloqueo != null)
                {
                    cronometroBloqueo.Stop();

                    estadisticas.RegistrarBloqueo(
                        trabajo.AplicacionId,
                        cronometroBloqueo.Elapsed.TotalSeconds);

                    Logger.Escribir(
                        $"Aplicación {trabajo.AplicacionId} desbloqueada.");
                }

                trabajo.HoraEntrada = DateTime.Now;

                trabajos.Enqueue(trabajo);

                estadisticas.RegistrarCambioCola(trabajos.Count);

                Logger.Escribir(
                    $"Aplicación {trabajo.AplicacionId} envió su trabajo " +
                    $"{trabajo.Id}, quedando en la posición " +
                    $"{trabajos.Count} de la cola.");

                Monitor.PulseAll(locker);
            }
        }

        public Trabajo? ObtenerTrabajo()
        {
            lock (locker)
            {
                while (trabajos.Count == 0 && !produccionTerminada)
                {
                    Monitor.Wait(locker);
                }

                if (trabajos.Count == 0 && produccionTerminada)
                {
                    return null;
                }

                Trabajo trabajo = trabajos.Dequeue();

                estadisticas.RegistrarCambioCola(trabajos.Count);

                Monitor.PulseAll(locker);

                return trabajo;
            }
        }

        public void FinalizarProduccion()
        {
            lock (locker)
            {
                produccionTerminada = true;
                Monitor.PulseAll(locker);
            }
        }
    }
}