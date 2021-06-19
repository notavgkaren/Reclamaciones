using System;
using System.Collections.Generic;
using System.Text;

namespace Reclamaciones.Models
{
    public class TipoMetodoOpcion
    {
        public int Id { get; set; }

        public string Nombre { get; set; }

        public int MetodoId { get; set; }
        public Metodo Metodo { get; set; }
    }
}
