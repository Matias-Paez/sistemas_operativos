using System;

namespace SistemaImpresion
{
    public static class Logger
    {
        private static readonly object locker = new object();

        public static void Escribir(string mensaje)
        {
            lock (locker)
            {
                Console.WriteLine(
                    $"[{DateTime.Now:HH:mm:ss.fff}] {mensaje}");
            }
        }
    }
}