using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Reportes.Modelo
{
    class conAlmacen
    {
        public static List<admAlmacenes> listarAlmacenes() {
            List<admAlmacenes> catAlmacen = new List<admAlmacenes>();
            try { 
               using (var ctx = new DataModel()) {
                    Reportes.Tools.ELog.saveDebug("conAlmacenes", ctx.Permisos.Count().ToString());
                    catAlmacen = ctx.admAlmacenes.Where(c=>c.CSTATUS==false).OrderBy(c=>c.CNOMBREALMACEN)
                        .ToList();                    
                }
            }
            catch (Exception ex )
            {
                Reportes.Tools.ELog.saveDebug("conAlmacenes", ex.Message);
            }
            return catAlmacen;
        }

        public static admAlmacenes buscarAlmacen(int idAlmacen) {
            admAlmacenes almacen;
            using (var ctx = new DataModel()) {
                return ctx.admAlmacenes.Include("admCapasProducto").Include("admCapasProducto.admProductos")
                    .Where(c => c.CIDALMACEN == idAlmacen).FirstOrDefault();
            }
        }

        public static void guardarAlmacen(admAlmacenes nAlmacen) {
            using (var ctx = new DataModel()) {
                ctx.Configuration.AutoDetectChangesEnabled = false;
                ctx.Entry(nAlmacen).State = System.Data.Entity.EntityState.Modified;
                ctx.SaveChanges();
            }
        }


        public static admProductos buscarProducto(int idProducto) {
            admProductos producto;
            using (var ctx = new DataModel()) {
                producto = ctx.admProductos.Where(c => c.CIDPRODUCTO == idProducto).FirstOrDefault();
            }
                return producto;
        }
        
    }
}
