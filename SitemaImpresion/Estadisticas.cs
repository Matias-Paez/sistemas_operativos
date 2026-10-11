using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace SistemaImpresion
{
    public class Estadisticas
    {
        private readonly object locker = new object();
        private readonly Stopwatch reloj = new Stopwatch();

        private readonly Dictionary<int, DateTime> ultimoEnvio = new();
        private readonly Dictionary<int, int> cantidadBloqueos = new();
        private readonly Dictionary<int, double> tiempoBloqueado = new();

        private double sumaEsperas;
        private double esperaMaxima;
        private int trabajosIniciados;
        private double tiempoImpresion;

        private double areaCola;
        private int longitudCola;
        private double ultimoCambioCola;

        public void Iniciar()
        {
            lock (locker)
            {
                ultimoEnvio.Clear();
                cantidadBloqueos.Clear();
                tiempoBloqueado.Clear();

                sumaEsperas = 0;
                esperaMaxima = 0;
                trabajosIniciados = 0;
                tiempoImpresion = 0;

                areaCola = 0;
                longitudCola = 0;
                ultimoCambioCola = 0;

                reloj.Restart();
            }
        }

        public void RegistrarCambioCola(int nuevaLongitud)
        {
            lock (locker)
            {
                double ahora = reloj.Elapsed.TotalSeconds;

                areaCola += longitudCola *
                            (ahora - ultimoCambioCola);

                longitudCola = nuevaLongitud;
                ultimoCambioCola = ahora;
            }
        }

        public void RegistrarInicioImpresion(Trabajo trabajo)
        {
            lock (locker)
            {
                DateTime ahora = DateTime.Now;
                trabajo.HoraInicioImpresion = ahora;

                double espera =
                    (ahora - trabajo.HoraEntrada).TotalSeconds;

                sumaEsperas += espera;
                esperaMaxima = Math.Max(esperaMaxima, espera);
                trabajosIniciados++;
            }
        }

        public void RegistrarTiempoImpresion(double segundos)
        {
            lock (locker)
            {
                tiempoImpresion += segundos;
            }
        }

        public void RegistrarUltimoEnvio(int aplicacionId)
        {
            lock (locker)
            {
                ultimoEnvio[aplicacionId] = DateTime.Now;
            }
        }

        public void RegistrarBloqueo(int aplicacionId, double segundos)
        {
            lock (locker)
            {
                if (!cantidadBloqueos.ContainsKey(aplicacionId))
                {
                    cantidadBloqueos[aplicacionId] = 0;
                    tiempoBloqueado[aplicacionId] = 0;
                }

                cantidadBloqueos[aplicacionId]++;
                tiempoBloqueado[aplicacionId] += segundos;
            }
        }

        public void MostrarResumen()
        {
            lock (locker)
            {
                double duracion = reloj.Elapsed.TotalSeconds;

                double promedioCola = duracion > 0
                    ? (areaCola + longitudCola *
                       (duracion - ultimoCambioCola)) / duracion
                    : 0;

                double esperaPromedio = trabajosIniciados > 0
                    ? sumaEsperas / trabajosIniciados
                    : 0;

                double utilizacion = duracion > 0
                    ? tiempoImpresion / duracion * 100
                    : 0;

                Console.WriteLine();
                Console.WriteLine("==============================================");
                Console.WriteLine("          ESTADÍSTICAS FINALES");
                Console.WriteLine("==============================================");

                Console.WriteLine(
                    $"Trabajos impresos: {trabajosIniciados}/300");

                Console.WriteLine(
                    $"Duración total: {duracion:F2} segundos");

                Console.WriteLine(
                    $"Longitud promedio de la cola: {promedioCola:F2}");

                Console.WriteLine(
                    $"Espera promedio: {esperaPromedio:F2} segundos");

                Console.WriteLine(
                    $"Espera máxima: {esperaMaxima:F2} segundos");

                Console.WriteLine(
                    $"Utilización de la impresora: {utilizacion:F2}%");

                Console.WriteLine();
                Console.WriteLine("Último envío por aplicación:");

                for (int id = 1; id <= 3; id++)
                {
                    string hora = ultimoEnvio.TryGetValue(
                        id, out DateTime valor)
                        ? valor.ToString("HH:mm:ss.fff")
                        : "No registrado";

                    Console.WriteLine(
                        $"Aplicación {id}: {hora}");
                }

                Console.WriteLine();
                Console.WriteLine("Bloqueos por cola llena:");

                for (int id = 1; id <= 3; id++)
                {
                    int cantidad = cantidadBloqueos
                        .GetValueOrDefault(id);

                    double tiempo = tiempoBloqueado
                        .GetValueOrDefault(id);

                    Console.WriteLine(
                        $"Aplicación {id}: {cantidad} bloqueos, " +
                        $"{tiempo:F2} segundos acumulados");
                }

                Console.WriteLine("==============================================");
            }
        }
    }
}