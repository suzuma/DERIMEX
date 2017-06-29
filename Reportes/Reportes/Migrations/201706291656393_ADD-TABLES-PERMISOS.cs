namespace Reportes.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ADDTABLESPERMISOS : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.admPermisos",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        nombre = c.String(nullable: false, unicode: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.admPermisosNegadosRol",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        permiso_id = c.Int(),
                        rol_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.admPermisos", t => t.permiso_id)
                .ForeignKey("dbo.admRoles", t => t.rol_id)
                .Index(t => t.permiso_id)
                .Index(t => t.rol_id);
            
            CreateTable(
                "dbo.admRoles",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        nombre = c.String(nullable: false, unicode: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.admUsuarios",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        usuario = c.String(nullable: false, unicode: false),
                        password = c.String(nullable: false, unicode: false),
                        nombre = c.String(nullable: false, unicode: false),
                        estado = c.Boolean(nullable: false),
                        rol_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.admRoles", t => t.rol_id)
                .Index(t => t.rol_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.admUsuarios", "rol_id", "dbo.admRoles");
            DropForeignKey("dbo.admPermisosNegadosRol", "rol_id", "dbo.admRoles");
            DropForeignKey("dbo.admPermisosNegadosRol", "permiso_id", "dbo.admPermisos");
            DropIndex("dbo.admUsuarios", new[] { "rol_id" });
            DropIndex("dbo.admPermisosNegadosRol", new[] { "rol_id" });
            DropIndex("dbo.admPermisosNegadosRol", new[] { "permiso_id" });
            DropTable("dbo.admUsuarios");
            DropTable("dbo.admRoles");
            DropTable("dbo.admPermisosNegadosRol");
            DropTable("dbo.admPermisos");
        }
    }
}
