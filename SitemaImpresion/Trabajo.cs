using System;

namespace SistemaImpresion
{
    public class Trabajo
    {
        public int Id { get; }
        public int AplicacionId { get; }
        public DateTime HoraEntrada { get; set; }
        public DateTime? HoraInicioImpresion { get; set; }

        public Trabajo(int id, int aplicacionId)
        {
            Id = id;
            AplicacionId = aplicacionId;
        }

        public string Identificador => $"A{AplicacionId}-T{Id:000}";
    }
}