using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Reclamaciones.Models
{

    public class Departamento
    {
        public int Id { get; set; }

        public string Nombre { get; set; }
    }
}
