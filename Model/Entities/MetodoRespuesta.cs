using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Entities
{
    public class MetodoRespuesta
    {
        public int Id { get; set; }

        public int MetodoEnvioId { get; set; }

        public MetodoEnvio MetodoEnvio { get; set; }

        public int EmpleadoId { get; set; }

        public Empleado Empleado { get; set; }

        public DateTimeOffset FechaInicio { get; set; }

        public string Comentario { get; set; }
    }
}
