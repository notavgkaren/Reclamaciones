using System;
using System.Collections.Generic;
using System.Text;

namespace Reclamaciones.Models
{
    public class Empleado
    {
        public int Id { get; set; }

        public string Nombre { get; set; }

        public string Cedula { get; set; }

        public int DepartamentoId { get; set; }
        public Departamento Departamento { get; set; }

        public string HorasTrabajo { get; set; }

        public string Salario { get; set; }

        public string Bono { get; set; }

        public DateTimeOffset FechaInico { get; set; }

    }
}
