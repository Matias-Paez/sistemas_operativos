using System;
using System.Diagnostics;
using System.Threading;

namespace SistemaImpresion
{
    public class Impresora
    {
        private readonly ColaImpresion cola;
        private readonly Estadisticas estadisticas;

        private int trabajosImpresos = 0;

        public Impresora(
            ColaImpresion cola,
            Estadisticas estadisticas)
        {
            this.cola = cola;
            this.estadisticas = estadisticas;
        }

        public void Ejecutar()
        {
            while (true)
            {
                Trabajo? trabajo = cola.ObtenerTrabajo();

                if (trabajo == null)
                {
                    break;
                }

                estadisticas.RegistrarInicioImpresion(trabajo);

                trabajosImpresos++;

                Logger.Escribir(
                    $"Impresora imprimiendo trabajo {trabajo.Id} " +
                    $"de la aplicación {trabajo.AplicacionId} " +
                    $"({trabajosImpresos}-ésimo trabajo de impresión).");

                int demora = Random.Shared.Next(500, 1001);

                Stopwatch cronometro = Stopwatch.StartNew();
                Thread.Sleep(demora);
                cronometro.Stop();

                estadisticas.RegistrarTiempoImpresion(
                    cronometro.Elapsed.TotalSeconds);
            }

            Logger.Escribir(
                $"Impresora finalizó. Total impresos: {trabajosImpresos}.");
        }
    }
}