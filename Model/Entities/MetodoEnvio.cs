using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Entities
{
    public class MetodoEnvio
    {
        public int Id { get; set; }

        public int TipoMetodoOpcionId { get; set; }

        public TipoMetodoOpcion TipoMetodoOpcion { get; set; }

        public int DepartamentoId { get; set; }

        public Departamento Departamento { get; set; }

        public DateTimeOffset FechaInicio { get; set; }

        public int HoraInicio { get; set; }

        public int EstadoMetodoEnvioId { get; set; }

        public EstadoMetodoEnvio EstadoMetodoEnvio { get; set; }

        public int ClienteId { get; set; }

        public Cliente Cliente { get; set; }
    }
}
