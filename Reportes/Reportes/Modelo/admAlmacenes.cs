using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

using System.Collections.Generic;
using System.Linq;

namespace Reportes.Modelo
{
    [Table("admAlmacenes")]
   public class admAlmacenes
    {
        #region "PROPIEDADES"
        //MGW10003

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CIDALMACEN { get; set; }

        [Required]
        [StringLength(30)]
        public string CCODIGOALMACEN { get; set; }

        [Required]
        [StringLength(60)]
        public string CNOMBREALMACEN { get; set; }

        public DateTime CFECHAALTAALMACEN { get; set; }

        public int CIDVALORCLASIFICACION1 { get; set; }

        public int CIDVALORCLASIFICACION2 { get; set; }

        public int CIDVALORCLASIFICACION3 { get; set; }

        public int CIDVALORCLASIFICACION4 { get; set; }

        public int CIDVALORCLASIFICACION5 { get; set; }

        public int CIDVALORCLASIFICACION6 { get; set; }

        //[Required]
        [StringLength(50)]
        public string CSEGCONTALMACEN { get; set; }

        ///[Required]
        [StringLength(50)]
        public string CTEXTOEXTRA1 { get; set; }

        //[Required]
        [StringLength(50)]
        public string CTEXTOEXTRA2 { get; set; }

        //[Required]
        [StringLength(50)]
        public string CTEXTOEXTRA3 { get; set; }

        public DateTime CFECHAEXTRA { get; set; }

        public double CIMPORTEEXTRA1 { get; set; }

        public double CIMPORTEEXTRA2 { get; set; }

        public double CIMPORTEEXTRA3 { get; set; }

        public double CIMPORTEEXTRA4 { get; set; }

        public int CBANDOMICILIO { get; set; }

        //[Required]
        [StringLength(23)]
        public string CTIMESTAMP { get; set; }

        //[Required]
        [StringLength(50)]
        public string CSCALMAC2 { get; set; }

        //[Required]
        [StringLength(50)]
        public string CSCALMAC3 { get; set; }

        public int CSISTORIG { get; set; }

        public bool CSTATUS { get; set; }
        #endregion

        public admAlmacenes() {
            this.CSTATUS = true;
        }


        public ICollection<admCapasProducto> admCapasProducto { get; set; }
        /// <summary>
        /// FUNCION RESPONSABLE DE OBTENER LA LISTA DE PRODUCTOS EN EL ALMACEN
        /// </summary>
        /// <returns>LISTA DE OBJETOS DE PRODUCTOS</returns>
        public List<admProductos> listarProductos() {
            List<admProductos> productos = new List<admProductos>();
            var listItem = this.admCapasProducto.GroupBy(c => c.CIDPRODUCTO);
            foreach (var item in listItem) {
                admProductos tItem = item.First().admProductos;
                productos.Add(tItem);
            }
            return productos;
        }

        public double stockProducto(int idProducto) {
            double stock = 0;
            var producto= this.admCapasProducto.Where(c => c.CIDPRODUCTO == idProducto).First();
            stock = producto.CEXISTENCIA;
            return stock;
        }
            

    }
}
