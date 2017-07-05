namespace Reportes.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class INICIAL : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.admAlmacenes",
                c => new
                    {
                        CIDALMACEN = c.Int(nullable: false),
                        CCODIGOALMACEN = c.String(nullable: false, maxLength: 30, unicode: false),
                        CNOMBREALMACEN = c.String(nullable: false, maxLength: 60, unicode: false),
                        CFECHAALTAALMACEN = c.DateTime(nullable: false, precision: 0),
                        CIDVALORCLASIFICACION1 = c.Int(nullable: false),
                        CIDVALORCLASIFICACION2 = c.Int(nullable: false),
                        CIDVALORCLASIFICACION3 = c.Int(nullable: false),
                        CIDVALORCLASIFICACION4 = c.Int(nullable: false),
                        CIDVALORCLASIFICACION5 = c.Int(nullable: false),
                        CIDVALORCLASIFICACION6 = c.Int(nullable: false),
                        CSEGCONTALMACEN = c.String(maxLength: 50, unicode: false, storeType: "nvarchar"),
                        CTEXTOEXTRA1 = c.String(maxLength: 50, unicode: false),
                        CTEXTOEXTRA2 = c.String(maxLength: 50, unicode: false),
                        CTEXTOEXTRA3 = c.String(maxLength: 50, unicode: false),
                        CFECHAEXTRA = c.DateTime(nullable: false, precision: 0),
                        CIMPORTEEXTRA1 = c.Double(nullable: false),
                        CIMPORTEEXTRA2 = c.Double(nullable: false),
                        CIMPORTEEXTRA3 = c.Double(nullable: false),
                        CIMPORTEEXTRA4 = c.Double(nullable: false),
                        CBANDOMICILIO = c.Int(nullable: false),
                        CTIMESTAMP = c.String(maxLength: 23, unicode: false),
                        CSCALMAC2 = c.String(maxLength: 50, unicode: false),
                        CSCALMAC3 = c.String(maxLength: 50, unicode: false),
                        CSISTORIG = c.Int(nullable: false),
                        CSTATUS = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.CIDALMACEN);
            
            CreateTable(
                "dbo.admCapasProducto",
                c => new
                    {
                        CIDCAPA = c.Int(nullable: false),
                        CIDALMACEN = c.Int(nullable: false),
                        CIDPRODUCTO = c.Int(nullable: false),
                        CFECHA = c.DateTime(nullable: false, precision: 0),
                        CTIPOCAPA = c.Int(nullable: false),
                        CNUMEROLOTE = c.String(maxLength: 30, unicode: false),
                        CFECHACADUCIDAD = c.DateTime(nullable: false, precision: 0),
                        CFECHAFABRICACION = c.DateTime(nullable: false, precision: 0),
                        CPEDIMENTO = c.String(maxLength: 30, unicode: false),
                        CADUANA = c.String(maxLength: 60, unicode: false),
                        CFECHAPEDIMENTO = c.DateTime(nullable: false, precision: 0),
                        CTIPOCAMBIO = c.Double(nullable: false),
                        CEXISTENCIA = c.Double(nullable: false),
                        CCOSTO = c.Double(nullable: false),
                        CIDCAPAORIGEN = c.Int(nullable: false),
                        CTIMESTAMP = c.String(maxLength: 23, unicode: false),
                        CNUMADUANA = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CIDCAPA)
                .ForeignKey("dbo.admAlmacenes", t => t.CIDALMACEN, cascadeDelete: true)
                .ForeignKey("dbo.admProductos", t => t.CIDPRODUCTO, cascadeDelete: true)
                .Index(t => t.CIDALMACEN)
                .Index(t => t.CIDPRODUCTO);
            
            CreateTable(
                "dbo.admProductos",
                c => new
                    {
                        CIDPRODUCTO = c.Int(nullable: false),
                        CCODIGOPRODUCTO = c.String(maxLength: 30, unicode: false),
                        CNOMBREPRODUCTO = c.String(maxLength: 60, unicode: false),
                        CTIPOPRODUCTO = c.Int(nullable: false),
                        CFECHAALTAPRODUCTO = c.DateTime(nullable: false, precision: 0),
                        CCONTROLEXISTENCIA = c.Int(nullable: false),
                        CIDFOTOPRODUCTO = c.Int(nullable: false),
                        CDESCRIPCIONPRODUCTO = c.String(unicode: false, storeType: "text"),
                        CMETODOCOSTEO = c.Int(nullable: false),
                        CPESOPRODUCTO = c.Double(nullable: false),
                        CCOMVENTAEXCEPPRODUCTO = c.Double(nullable: false),
                        CCOMCOBROEXCEPPRODUCTO = c.Double(nullable: false),
                        CCOSTOESTANDAR = c.Double(nullable: false),
                        CMARGENUTILIDAD = c.Double(nullable: false),
                        CSTATUSPRODUCTO = c.Int(nullable: false),
                        CIDUNIDADBASE = c.Int(nullable: false),
                        CIDUNIDADNOCONVERTIBLE = c.Int(nullable: false),
                        CFECHABAJA = c.DateTime(nullable: false, precision: 0),
                        CIMPUESTO1 = c.Double(nullable: false),
                        CIMPUESTO2 = c.Double(nullable: false),
                        CIMPUESTO3 = c.Double(nullable: false),
                        CRETENCION1 = c.Double(nullable: false),
                        CRETENCION2 = c.Double(nullable: false),
                        CIDPADRECARACTERISTICA1 = c.Int(nullable: false),
                        CIDPADRECARACTERISTICA2 = c.Int(nullable: false),
                        CIDPADRECARACTERISTICA3 = c.Int(nullable: false),
                        CIDVALORCLASIFICACION1 = c.Int(nullable: false),
                        CIDVALORCLASIFICACION2 = c.Int(nullable: false),
                        CIDVALORCLASIFICACION3 = c.Int(nullable: false),
                        CIDVALORCLASIFICACION4 = c.Int(nullable: false),
                        CIDVALORCLASIFICACION5 = c.Int(nullable: false),
                        CIDVALORCLASIFICACION6 = c.Int(nullable: false),
                        CSEGCONTPRODUCTO1 = c.String(maxLength: 50, unicode: false),
                        CSEGCONTPRODUCTO2 = c.String(maxLength: 50, unicode: false),
                        CSEGCONTPRODUCTO3 = c.String(maxLength: 50, unicode: false),
                        CTEXTOEXTRA1 = c.String(maxLength: 50, unicode: false),
                        CTEXTOEXTRA2 = c.String(maxLength: 50, unicode: false),
                        CTEXTOEXTRA3 = c.String(maxLength: 50, unicode: false),
                        CFECHAEXTRA = c.DateTime(nullable: false, precision: 0),
                        CIMPORTEEXTRA1 = c.Double(nullable: false),
                        CIMPORTEEXTRA2 = c.Double(nullable: false),
                        CIMPORTEEXTRA3 = c.Double(nullable: false),
                        CIMPORTEEXTRA4 = c.Double(nullable: false),
                        CPRECIO1 = c.Double(nullable: false),
                        CPRECIO2 = c.Double(nullable: false),
                        CPRECIO3 = c.Double(nullable: false),
                        CPRECIO4 = c.Double(nullable: false),
                        CPRECIO5 = c.Double(nullable: false),
                        CPRECIO6 = c.Double(nullable: false),
                        CPRECIO7 = c.Double(nullable: false),
                        CPRECIO8 = c.Double(nullable: false),
                        CPRECIO9 = c.Double(nullable: false),
                        CPRECIO10 = c.Double(nullable: false),
                        CBANUNIDADES = c.Int(nullable: false),
                        CBANCARACTERISTICAS = c.Int(nullable: false),
                        CBANMETODOCOSTEO = c.Int(nullable: false),
                        CBANMAXMIN = c.Int(nullable: false),
                        CBANPRECIO = c.Int(nullable: false),
                        CBANIMPUESTO = c.Int(nullable: false),
                        CBANCODIGOBARRA = c.Int(nullable: false),
                        CBANCOMPONENTE = c.Int(nullable: false),
                        CTIMESTAMP = c.String(maxLength: 23, unicode: false),
                        CERRORCOSTO = c.Int(nullable: false),
                        CFECHAERRORCOSTO = c.DateTime(nullable: false, precision: 0),
                        CPRECIOCALCULADO = c.Double(nullable: false),
                        CESTADOPRECIO = c.Int(nullable: false),
                        CBANUBICACION = c.Int(nullable: false),
                        CESEXENTO = c.Int(nullable: false),
                        CEXISTENCIANEGATIVA = c.Int(nullable: false),
                        CCOSTOEXT1 = c.Double(nullable: false),
                        CCOSTOEXT2 = c.Double(nullable: false),
                        CCOSTOEXT3 = c.Double(nullable: false),
                        CCOSTOEXT4 = c.Double(nullable: false),
                        CCOSTOEXT5 = c.Double(nullable: false),
                        CFECCOSEX1 = c.DateTime(nullable: false, precision: 0),
                        CFECCOSEX2 = c.DateTime(nullable: false, precision: 0),
                        CFECCOSEX3 = c.DateTime(nullable: false, precision: 0),
                        CFECCOSEX4 = c.DateTime(nullable: false, precision: 0),
                        CFECCOSEX5 = c.DateTime(nullable: false, precision: 0),
                        CMONCOSEX1 = c.Int(nullable: false),
                        CMONCOSEX2 = c.Int(nullable: false),
                        CMONCOSEX3 = c.Int(nullable: false),
                        CMONCOSEX4 = c.Int(nullable: false),
                        CMONCOSEX5 = c.Int(nullable: false),
                        CBANCOSEX = c.Int(nullable: false),
                        CESCUOTAI2 = c.Int(nullable: false),
                        CESCUOTAI3 = c.Int(nullable: false),
                        CIDUNIDADCOMPRA = c.Int(nullable: false),
                        CIDUNIDADVENTA = c.Int(nullable: false),
                        CSUBTIPO = c.Int(nullable: false),
                        CCODALTERN = c.String(maxLength: 30, unicode: false),
                        CNOMALTERN = c.String(maxLength: 60, unicode: false),
                        CDESCCORTA = c.String(maxLength: 30, unicode: false),
                        CIDMONEDA = c.Int(nullable: false),
                        CUSABASCU = c.Int(nullable: false),
                        CTIPOPAQUE = c.Int(nullable: false),
                        CPRECSELEC = c.Int(nullable: false),
                        CDESGLOSAI2 = c.Int(nullable: false),
                        CSEGCONTPRODUCTO4 = c.String(maxLength: 20, unicode: false),
                        CSEGCONTPRODUCTO5 = c.String(maxLength: 20, unicode: false),
                        CSEGCONTPRODUCTO6 = c.String(maxLength: 20, unicode: false),
                        CSEGCONTPRODUCTO7 = c.String(maxLength: 20, unicode: false),
                        CCTAPRED = c.String(maxLength: 30, unicode: false),
                        CNODESCOMP = c.Int(nullable: false),
                        CIDUNIXML = c.Int(nullable: false),
                        CNOMODCOMP = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CIDPRODUCTO);
            
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
            DropForeignKey("dbo.admCapasProducto", "CIDPRODUCTO", "dbo.admProductos");
            DropForeignKey("dbo.admCapasProducto", "CIDALMACEN", "dbo.admAlmacenes");
            DropIndex("dbo.admUsuarios", new[] { "rol_id" });
            DropIndex("dbo.admPermisosNegadosRol", new[] { "rol_id" });
            DropIndex("dbo.admPermisosNegadosRol", new[] { "permiso_id" });
            DropIndex("dbo.admCapasProducto", new[] { "CIDPRODUCTO" });
            DropIndex("dbo.admCapasProducto", new[] { "CIDALMACEN" });
            DropTable("dbo.admUsuarios");
            DropTable("dbo.admRoles");
            DropTable("dbo.admPermisosNegadosRol");
            DropTable("dbo.admPermisos");
            DropTable("dbo.admProductos");
            DropTable("dbo.admCapasProducto");
            DropTable("dbo.admAlmacenes");
        }
    }
}
