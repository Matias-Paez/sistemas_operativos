using System;
using System.Threading;

namespace SistemaImpresion
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("SISTEMA DE IMPRESIÓN CONCURRENTE");
            Console.WriteLine("--------------------------------");
            Console.WriteLine("Aplicaciones: 3");
            Console.WriteLine("Trabajos por aplicación: 100");
            Console.WriteLine("Capacidad de la cola: 10");
            Console.WriteLine();

            Estadisticas estadisticas = new Estadisticas();

            ColaImpresion cola =new ColaImpresion(10, estadisticas);

            Aplicacion app1 = new Aplicacion(1, cola, estadisticas);

            Aplicacion app2 = new Aplicacion(2, cola, estadisticas);

            Aplicacion app3 = new Aplicacion(3, cola, estadisticas);

            Impresora impresora = new Impresora(cola, estadisticas);

            Thread hiloImpresora =new Thread(impresora.Ejecutar);

            Thread hiloApp1 = new Thread(app1.Ejecutar);

            Thread hiloApp2 = new Thread(app2.Ejecutar);

            Thread hiloApp3 = new Thread(app3.Ejecutar);

            // Iniciar las mediciones antes de iniciar los hilos.
            estadisticas.Iniciar();

            // Iniciar la impresora y las aplicaciones.
            hiloImpresora.Start();

            hiloApp1.Start();
            hiloApp2.Start();
            hiloApp3.Start();

            // Esperar a que las tres aplicaciones terminen.
            hiloApp1.Join();
            hiloApp2.Join();
            hiloApp3.Join();

            // Informar que no se generarán más trabajos.
            cola.FinalizarProduccion();

            // Esperar a que la impresora vacíe la cola.
            hiloImpresora.Join();

            // Mostrar las estadísticas finales.
            estadisticas.MostrarResumen();

            Console.WriteLine();
            Console.WriteLine("Simulación finalizada.");
            Console.WriteLine("Presioná una tecla para salir.");

            Console.ReadKey();
        }
    }
}