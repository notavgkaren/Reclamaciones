namespace Reclamaciones.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class inicio : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clientes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Cedula = c.String(),
                        Telefono = c.String(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Departamentos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Empleados",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Cedula = c.String(),
                        DepartamentoId = c.Int(nullable: false),
                        HorasTrabajo = c.String(),
                        Salario = c.String(),
                        Bono = c.String(),
                        FechaInico = c.DateTimeOffset(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Departamentos", t => t.DepartamentoId, cascadeDelete: true)
                .Index(t => t.DepartamentoId);
            
            CreateTable(
                "dbo.EstadoMetodoEnvios",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Metodoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MetodoEnvios",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TipoMetodoOpcionId = c.Int(nullable: false),
                        DepartamentoId = c.Int(nullable: false),
                        FechaInicio = c.DateTimeOffset(nullable: false, precision: 7),
                        HoraInicio = c.Int(nullable: false),
                        EstadoMetodoEnvioId = c.Int(nullable: false),
                        ClienteId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Clientes", t => t.ClienteId, cascadeDelete: true)
                .ForeignKey("dbo.Departamentos", t => t.DepartamentoId, cascadeDelete: true)
                .ForeignKey("dbo.EstadoMetodoEnvios", t => t.EstadoMetodoEnvioId, cascadeDelete: true)
                .ForeignKey("dbo.TipoMetodoOpcions", t => t.TipoMetodoOpcionId, cascadeDelete: true)
                .Index(t => t.TipoMetodoOpcionId)
                .Index(t => t.DepartamentoId)
                .Index(t => t.EstadoMetodoEnvioId)
                .Index(t => t.ClienteId);
            
            CreateTable(
                "dbo.TipoMetodoOpcions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        MetodoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Metodoes", t => t.MetodoId, cascadeDelete: true)
                .Index(t => t.MetodoId);
            
            CreateTable(
                "dbo.MetodoRespuestas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MetodoEnvioId = c.Int(nullable: false),
                        EmpleadoId = c.Int(nullable: false),
                        FechaInicio = c.DateTimeOffset(nullable: false, precision: 7),
                        Comentario = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Empleados", t => t.EmpleadoId, cascadeDelete: false)
                .ForeignKey("dbo.MetodoEnvios", t => t.MetodoEnvioId, cascadeDelete: false)
                .Index(t => t.MetodoEnvioId)
                .Index(t => t.EmpleadoId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MetodoRespuestas", "MetodoEnvioId", "dbo.MetodoEnvios");
            DropForeignKey("dbo.MetodoRespuestas", "EmpleadoId", "dbo.Empleados");
            DropForeignKey("dbo.MetodoEnvios", "TipoMetodoOpcionId", "dbo.TipoMetodoOpcions");
            DropForeignKey("dbo.TipoMetodoOpcions", "MetodoId", "dbo.Metodoes");
            DropForeignKey("dbo.MetodoEnvios", "EstadoMetodoEnvioId", "dbo.EstadoMetodoEnvios");
            DropForeignKey("dbo.MetodoEnvios", "DepartamentoId", "dbo.Departamentos");
            DropForeignKey("dbo.MetodoEnvios", "ClienteId", "dbo.Clientes");
            DropForeignKey("dbo.Empleados", "DepartamentoId", "dbo.Departamentos");
            DropIndex("dbo.MetodoRespuestas", new[] { "EmpleadoId" });
            DropIndex("dbo.MetodoRespuestas", new[] { "MetodoEnvioId" });
            DropIndex("dbo.TipoMetodoOpcions", new[] { "MetodoId" });
            DropIndex("dbo.MetodoEnvios", new[] { "ClienteId" });
            DropIndex("dbo.MetodoEnvios", new[] { "EstadoMetodoEnvioId" });
            DropIndex("dbo.MetodoEnvios", new[] { "DepartamentoId" });
            DropIndex("dbo.MetodoEnvios", new[] { "TipoMetodoOpcionId" });
            DropIndex("dbo.Empleados", new[] { "DepartamentoId" });
            DropTable("dbo.MetodoRespuestas");
            DropTable("dbo.TipoMetodoOpcions");
            DropTable("dbo.MetodoEnvios");
            DropTable("dbo.Metodoes");
            DropTable("dbo.EstadoMetodoEnvios");
            DropTable("dbo.Empleados");
            DropTable("dbo.Departamentos");
            DropTable("dbo.Clientes");
        }
    }
}
