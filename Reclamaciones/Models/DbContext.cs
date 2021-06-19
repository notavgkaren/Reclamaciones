using Reclamaciones.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;


namespace Reclamaciones.Models
{


    public class ReclamacionesDbContext : DbContext
    {
        public ReclamacionesDbContext()
             : base("ReclamacionesDbContext")
        {
          
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MetodoRespuesta>()
                .HasRequired(m => m.MetodoEnvio)
                .WithMany()
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Departamento>().ToTable("Departamentos");
            modelBuilder.Entity<Empleado>().ToTable("Empleados");


        }

        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Departamento> Departamentos { get; set; }
        public DbSet<Empleado> Empleado { get; set; }
        public DbSet<EstadoMetodoEnvio> EstadoMetodoEnvio { get; set; }
        public DbSet<Metodo> Metodo { get; set; }
        public DbSet<MetodoEnvio> MetodoEnvio { get; set; }
        public DbSet<MetodoRespuesta> MetodoRespuesta { get; set; }
        public DbSet<TipoMetodoOpcion> TipoMetodoOpcion { get; set; }
    }

   
}
