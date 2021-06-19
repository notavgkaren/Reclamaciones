namespace Reclamaciones.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cambio : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Departamentos", "Nombre", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Departamentos", "Nombre", c => c.Int(nullable: false));
        }
    }
}
