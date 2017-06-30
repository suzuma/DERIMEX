namespace Reportes.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ADDFROMULARIODETALLE : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.admAlmacenes", "CSTATUS", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.admAlmacenes", "CSTATUS");
        }
    }
}
