namespace Reclamaciones.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cambios : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.MetodoRespuestas", "MetodoEnvioId", "dbo.MetodoEnvios");
            AddForeignKey("dbo.MetodoRespuestas", "MetodoEnvioId", "dbo.MetodoEnvios", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MetodoRespuestas", "MetodoEnvioId", "dbo.MetodoEnvios");
            AddForeignKey("dbo.MetodoRespuestas", "MetodoEnvioId", "dbo.MetodoEnvios", "Id", cascadeDelete: true);
        }
    }
}
