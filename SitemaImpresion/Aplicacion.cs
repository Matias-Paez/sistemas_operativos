using System;
using System.Threading;

namespace SistemaImpresion
{
    public class Aplicacion
    {
        private readonly ColaImpresion cola;
        private readonly Estadisticas estadisticas;

        public int Id { get; }

        public Aplicacion(
            int id,
            ColaImpresion cola,
            Estadisticas estadisticas)
        {
            Id = id;
            this.cola = cola;
            this.estadisticas = estadisticas;
        }

        public void Ejecutar()
        {
            for (int i = 1; i <= 100; i++)
            {
                Trabajo trabajo = new Trabajo(i, Id);

                cola.AgregarTrabajo(trabajo);

                if (i == 100)
                {
                    estadisticas.RegistrarUltimoEnvio(Id);
                }

                if (i < 100)
                {
                    int demora = Random.Shared.Next(500, 4501);
                    Thread.Sleep(demora);
                }
            }

            Logger.Escribir(
                $"Aplicación {Id} terminó de generar sus 100 trabajos.");
        }
    }
}