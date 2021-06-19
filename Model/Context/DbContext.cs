using Model.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;


namespace Model.Context
{


    public class ReclamacionesDbContext : DbContext
    {
        public ReclamacionesDbContext()
             : base("ReclamacionesDbContext")
        {
          
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
           
        }

        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Departamento> Departamento { get; set; }
        public DbSet<Empleado> Empleado { get; set; }
        public DbSet<EstadoMetodoEnvio> EstadoMetodoEnvio { get; set; }
        public DbSet<Metodo> Metodo { get; set; }
        public DbSet<MetodoEnvio> MetodoEnvio { get; set; }
        public DbSet<MetodoRespuesta> MetodoRespuesta { get; set; }
        public DbSet<TipoMetodoOpcion> TipoMetodoOpcion { get; set; }
    }

   
}
