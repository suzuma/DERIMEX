
using System.Data.Entity;
namespace Reportes.Modelo
{
    class DataModel : DbContext
    {
        public DataModel() : base("DataModel") { }

        /*public DbSet<Permiso> Permisos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Rol> Roles { get; set; }
        public DbSet<PermisoNegadoRol> PermisosNegadosRol { get; set; } */


        public virtual DbSet<admAlmacenes> admAlmacenes { get; set; }
        public virtual DbSet<admProductos> admProductos { get; set; }    
        public virtual DbSet<admCapasProducto> admCapasProducto { get; set; }

        /*
        public virtual DbSet<admExistenciaCosto> admExistenciaCosto { get; set; }
        public virtual DbSet<admMovimientoSerie> admMovimientoSerie { get; set; }
        public virtual DbSet<admNumerosSerie> admNumerosSerie { get; set; }
        public virtual DbSet<admMovimientosCapas> admMovimientosCapas { get; set; }
        public virtual DbSet<admMovtosInvFisicoSerieCa> admMovtosInvFisicoSerieCa { get; set; }  
        */

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<admAlmacenes>()
               .Property(e => e.CCODIGOALMACEN)
               .IsUnicode(false);

            modelBuilder.Entity<admAlmacenes>()
                .Property(e => e.CNOMBREALMACEN)
                .IsUnicode(false);

            /*modelBuilder.Entity<admAlmacenes>()
                .Property(e => e.CSEGCONTALMACEN)
                .IsUnicode(false);*/

            modelBuilder.Entity<admAlmacenes>()
                .Property(e => e.CTEXTOEXTRA1)
                .IsUnicode(false);

            modelBuilder.Entity<admAlmacenes>()
                .Property(e => e.CTEXTOEXTRA2)
                .IsUnicode(false);

            modelBuilder.Entity<admAlmacenes>()
                .Property(e => e.CTEXTOEXTRA3)
                .IsUnicode(false);

            modelBuilder.Entity<admAlmacenes>()
                .Property(e => e.CTIMESTAMP)
                .IsUnicode(false);

            modelBuilder.Entity<admAlmacenes>()
                .Property(e => e.CSCALMAC2)
                .IsUnicode(false);

            modelBuilder.Entity<admAlmacenes>()
                .Property(e => e.CSCALMAC3)
                .IsUnicode(false);

            modelBuilder.Entity<admCapasProducto>()
                .Property(e => e.CNUMEROLOTE)
                .IsUnicode(false);

            modelBuilder.Entity<admCapasProducto>()
                .Property(e => e.CPEDIMENTO)
                .IsUnicode(false);

            modelBuilder.Entity<admCapasProducto>()
                .Property(e => e.CADUANA)
                .IsUnicode(false);

            modelBuilder.Entity<admCapasProducto>()
                .Property(e => e.CTIMESTAMP)
                .IsUnicode(false);


            modelBuilder.Entity<admProductos>()
                .Property(e => e.CCODIGOPRODUCTO)
                .IsUnicode(false);

            modelBuilder.Entity<admProductos>()
                .Property(e => e.CNOMBREPRODUCTO)
                .IsUnicode(false);

            modelBuilder.Entity<admProductos>()
                .Property(e => e.CDESCRIPCIONPRODUCTO)
                .IsUnicode(false);

            modelBuilder.Entity<admProductos>()
                .Property(e => e.CSEGCONTPRODUCTO1)
                .IsUnicode(false);

            modelBuilder.Entity<admProductos>()
                .Property(e => e.CSEGCONTPRODUCTO2)
                .IsUnicode(false);

            modelBuilder.Entity<admProductos>()
                .Property(e => e.CSEGCONTPRODUCTO3)
                .IsUnicode(false);

            modelBuilder.Entity<admProductos>()
                .Property(e => e.CTEXTOEXTRA1)
                .IsUnicode(false);

            modelBuilder.Entity<admProductos>()
                .Property(e => e.CTEXTOEXTRA2)
                .IsUnicode(false);

            modelBuilder.Entity<admProductos>()
                .Property(e => e.CTEXTOEXTRA3)
                .IsUnicode(false);

            modelBuilder.Entity<admProductos>()
                .Property(e => e.CTIMESTAMP)
                .IsUnicode(false);

            modelBuilder.Entity<admProductos>()
                .Property(e => e.CCODALTERN)
                .IsUnicode(false);

            modelBuilder.Entity<admProductos>()
                .Property(e => e.CNOMALTERN)
                .IsUnicode(false);

            modelBuilder.Entity<admProductos>()
                .Property(e => e.CDESCCORTA)
                .IsUnicode(false);

            modelBuilder.Entity<admProductos>()
                .Property(e => e.CSEGCONTPRODUCTO4)
                .IsUnicode(false);

            modelBuilder.Entity<admProductos>()
                .Property(e => e.CSEGCONTPRODUCTO5)
                .IsUnicode(false);

            modelBuilder.Entity<admProductos>()
                .Property(e => e.CSEGCONTPRODUCTO6)
                .IsUnicode(false);

            modelBuilder.Entity<admProductos>()
                .Property(e => e.CSEGCONTPRODUCTO7)
                .IsUnicode(false);

            modelBuilder.Entity<admProductos>()
                .Property(e => e.CCTAPRED)
                .IsUnicode(false);         
        }
    }
}
