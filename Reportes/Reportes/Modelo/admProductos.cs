using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Linq;

namespace Reportes.Modelo
{
    [Table("admProductos")]
    public class admProductos
    {
        #region "PROPIEDADES
        //MGW10005
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CIDPRODUCTO { get; set; }

        //[Required]
        [StringLength(30)]
        public string CCODIGOPRODUCTO { get; set; }

        //[Required]
        [StringLength(60)]
        public string CNOMBREPRODUCTO { get; set; }

        public int CTIPOPRODUCTO { get; set; }

        public DateTime CFECHAALTAPRODUCTO { get; set; }

        public int CCONTROLEXISTENCIA { get; set; }

        public int CIDFOTOPRODUCTO { get; set; }

        [Column(TypeName = "text")]
        public string CDESCRIPCIONPRODUCTO { get; set; }

        public int CMETODOCOSTEO { get; set; }

        public double CPESOPRODUCTO { get; set; }

        public double CCOMVENTAEXCEPPRODUCTO { get; set; }

        public double CCOMCOBROEXCEPPRODUCTO { get; set; }

        public double CCOSTOESTANDAR { get; set; }

        public double CMARGENUTILIDAD { get; set; }

        public int CSTATUSPRODUCTO { get; set; }

        public int CIDUNIDADBASE { get; set; }

        public int CIDUNIDADNOCONVERTIBLE { get; set; }

        public DateTime CFECHABAJA { get; set; }

        public double CIMPUESTO1 { get; set; }

        public double CIMPUESTO2 { get; set; }

        public double CIMPUESTO3 { get; set; }

        public double CRETENCION1 { get; set; }

        public double CRETENCION2 { get; set; }

        public int CIDPADRECARACTERISTICA1 { get; set; }

        public int CIDPADRECARACTERISTICA2 { get; set; }

        public int CIDPADRECARACTERISTICA3 { get; set; }

        public int CIDVALORCLASIFICACION1 { get; set; }

        public int CIDVALORCLASIFICACION2 { get; set; }

        public int CIDVALORCLASIFICACION3 { get; set; }

        public int CIDVALORCLASIFICACION4 { get; set; }

        public int CIDVALORCLASIFICACION5 { get; set; }

        public int CIDVALORCLASIFICACION6 { get; set; }

        //[Required]
        [StringLength(50)]
        public string CSEGCONTPRODUCTO1 { get; set; }

        //[Required]
        [StringLength(50)]
        public string CSEGCONTPRODUCTO2 { get; set; }

        //[Required]
        [StringLength(50)]
        public string CSEGCONTPRODUCTO3 { get; set; }

        //[Required]
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

        public double CPRECIO1 { get; set; }

        public double CPRECIO2 { get; set; }

        public double CPRECIO3 { get; set; }

        public double CPRECIO4 { get; set; }

        public double CPRECIO5 { get; set; }

        public double CPRECIO6 { get; set; }

        public double CPRECIO7 { get; set; }

        public double CPRECIO8 { get; set; }

        public double CPRECIO9 { get; set; }

        public double CPRECIO10 { get; set; }

        public int CBANUNIDADES { get; set; }

        public int CBANCARACTERISTICAS { get; set; }

        public int CBANMETODOCOSTEO { get; set; }

        public int CBANMAXMIN { get; set; }

        public int CBANPRECIO { get; set; }

        public int CBANIMPUESTO { get; set; }

        public int CBANCODIGOBARRA { get; set; }

        public int CBANCOMPONENTE { get; set; }

        //[Required]
        [StringLength(23)]
        public string CTIMESTAMP { get; set; }

        public int CERRORCOSTO { get; set; }

        public DateTime CFECHAERRORCOSTO { get; set; }

        public double CPRECIOCALCULADO { get; set; }

        public int CESTADOPRECIO { get; set; }

        public int CBANUBICACION { get; set; }

        public int CESEXENTO { get; set; }

        public int CEXISTENCIANEGATIVA { get; set; }

        public double CCOSTOEXT1 { get; set; }

        public double CCOSTOEXT2 { get; set; }

        public double CCOSTOEXT3 { get; set; }

        public double CCOSTOEXT4 { get; set; }

        public double CCOSTOEXT5 { get; set; }

        public DateTime CFECCOSEX1 { get; set; }

        public DateTime CFECCOSEX2 { get; set; }

        public DateTime CFECCOSEX3 { get; set; }

        public DateTime CFECCOSEX4 { get; set; }

        public DateTime CFECCOSEX5 { get; set; }

        public int CMONCOSEX1 { get; set; }

        public int CMONCOSEX2 { get; set; }

        public int CMONCOSEX3 { get; set; }

        public int CMONCOSEX4 { get; set; }

        public int CMONCOSEX5 { get; set; }

        public int CBANCOSEX { get; set; }

        public int CESCUOTAI2 { get; set; }

        public int CESCUOTAI3 { get; set; }

        public int CIDUNIDADCOMPRA { get; set; }

        public int CIDUNIDADVENTA { get; set; }

        public int CSUBTIPO { get; set; }

        //[Required]
        [StringLength(30)]
        public string CCODALTERN { get; set; }

        //[Required]
        [StringLength(60)]
        public string CNOMALTERN { get; set; }

        //[Required]
        [StringLength(30)]
        public string CDESCCORTA { get; set; }

        public int CIDMONEDA { get; set; }

        public int CUSABASCU { get; set; }

        public int CTIPOPAQUE { get; set; }

        public int CPRECSELEC { get; set; }

        public int CDESGLOSAI2 { get; set; }

        //[Required]
        [StringLength(20)]
        public string CSEGCONTPRODUCTO4 { get; set; }

        //[Required]
        [StringLength(20)]
        public string CSEGCONTPRODUCTO5 { get; set; }

        //[Required]
        [StringLength(20)]
        public string CSEGCONTPRODUCTO6 { get; set; }

        //[Required]
        [StringLength(20)]
        public string CSEGCONTPRODUCTO7 { get; set; }

        //[Required]
        [StringLength(30)]
        public string CCTAPRED { get; set; }

        public int CNODESCOMP { get; set; }

        public int CIDUNIXML { get; set; }

        public int CNOMODCOMP { get; set; }

        public ICollection<admCapasProducto> admCapasProducto { get; set; }

        #endregion

        public double ObtenerInventario() {
            double total = 0;
            foreach (admCapasProducto item in this.admCapasProducto.ToList()) {
                total += item.CEXISTENCIA;
            }
            return total;
        }
        public double CalcularCostoPromedio(int idAlmacen) {
            double total = 0;
            int indice = 0;
            foreach (admCapasProducto item in this.admCapasProducto.Where(c => c.CIDALMACEN == idAlmacen).ToList())
            {
                total += item.CCOSTO;                
                indice++;
            }
            return total/indice;
        }
        public double CalcularTotalCaducos(int idAlmacen)
        {
            double total = 0;

            foreach (admCapasProducto item in this.admCapasProducto.Where(c => c.CIDALMACEN == idAlmacen).ToList())
            {
                if (item.CTIPOCAPA != 5) { 
                    double tdias = CalcularDiasDeDiferencia(DateTime.Now, item.CFECHACADUCIDAD);
                    if (tdias<=0)
                    {
                        total += item.CEXISTENCIA;
                    }
                }
            }
            return total;
        }

        public List<admCapasProducto> listarLotesCaducos(int idAlmacen) {
            List<admCapasProducto> lCaducos = new List<Modelo.admCapasProducto>();
            foreach (admCapasProducto item in this.admCapasProducto.Where(c => c.CIDALMACEN == idAlmacen).ToList()) {
                double tdias = CalcularDiasDeDiferencia(DateTime.Now, item.CFECHACADUCIDAD);
                if (tdias <= 0)
                {
                    lCaducos.Add(item);
                }
            }
            return lCaducos;
        }
        public List<admCapasProducto> listarLotesSinCaducar(int idAlmacen)
        {
            List<admCapasProducto> lsCaducos = new List<Modelo.admCapasProducto>();
            foreach (admCapasProducto item in this.admCapasProducto.Where(c => c.CIDALMACEN == idAlmacen).ToList())
            {
                double tdias = CalcularDiasDeDiferencia(DateTime.Now, item.CFECHACADUCIDAD);
                if (tdias > 0)
                {
                    lsCaducos.Add(item);
                }
            }
            return lsCaducos;
        }

        /// <summary>
        /// FUNCION RESPONSABLE DE OBTENER EL TOTAL DE PRODUCTOS A CADUCAR EN
        /// 1 A 7 DIAS
        /// </summary>
        /// <returns></returns>
        public double CalcularTotalRango17(int idAlmacen) {
            double total = 0;
            
            foreach (admCapasProducto item in this.admCapasProducto.Where(c=>c.CIDALMACEN==idAlmacen).ToList())
            {
                if (item.CTIPOCAPA != 5)
                {
                    double tdias = CalcularDiasDeDiferencia(DateTime.Now, item.CFECHACADUCIDAD);
                    if (tdias >= 1 && tdias <= 15)
                    {
                        total += item.CEXISTENCIA;
                    }
                }
            }
            return total;
        }
        /// <summary>
        /// FUNCION RESPONSABLE DE OBTENER EL TOTAL DE PRODUCTOS A CADUCAR EN 
        /// 8 A 16 DIAS
        /// </summary>
        /// <returns></returns>
        public double CalcularTotalRango816(int idAlmacen)
        {
            double total = 0;
            foreach (admCapasProducto item in this.admCapasProducto.Where(c => c.CIDALMACEN == idAlmacen).ToList())
            {
                if (item.CTIPOCAPA != 5) { 
                    double tdias = CalcularDiasDeDiferencia(DateTime.Now, item.CFECHACADUCIDAD);
                    if (tdias >= 16 && tdias <= 30)
                    {
                        total += item.CEXISTENCIA;
                    }
                }
            }
            return total;
        }
        /// <summary>
        /// FUNCION RESPONSABLE DE OBTENER EL TOTAL DE PRODUCTOS A CADUCAR EN 
        /// 17 A 30 DIAS
        /// </summary>
        /// <returns></returns>
        public double CalcularTotalRango1730(int idAlmacen)
        {
            double total = 0;
            foreach (admCapasProducto item in this.admCapasProducto.Where(c => c.CIDALMACEN == idAlmacen).ToList())
            {
                if (item.CTIPOCAPA != 5) { 
                    double tdias = CalcularDiasDeDiferencia(DateTime.Now, item.CFECHACADUCIDAD);
                    if (tdias >= 31 && tdias <= 60)
                    {
                        total += item.CEXISTENCIA;
                    }
                }
            }
            return total;
        }
        /// <summary>
        /// FUNCION RESPONSABLE DE OBTENER EL TOTAL DE PRODUCTOS CADUCOS EN EL 
        /// RANGO DE 30 MAS DIAS 
        /// </summary>
        /// <returns></returns>
        public double CalcularTotalRango3100(int idAlmacen)
        {
            double total = 0;
            foreach (admCapasProducto item in this.admCapasProducto.Where(c => c.CIDALMACEN == idAlmacen).ToList())
            {
                if (item.CTIPOCAPA != 5) { 
                    double tdias = CalcularDiasDeDiferencia(DateTime.Now, item.CFECHACADUCIDAD);
                    if (tdias >= 61)
                    {
                        total += item.CEXISTENCIA;
                    }
                }
            }
            return total;
        }

        public Boolean tieneCaducidad(int idAlmacen) {
            Boolean tiene = true;
            foreach (admCapasProducto item in this.admCapasProducto.Where(c => c.CIDALMACEN == idAlmacen).ToList())
            {
                if (item.CTIPOCAPA == 5) {
                    tiene = false;
                }
                break;
            }
                return tiene;
        }


        private double CalcularDiasDeDiferencia(DateTime FechaActual, DateTime FechaCaducar)
        {
            TimeSpan diferencia;
            diferencia =  FechaCaducar- FechaActual;

            return diferencia.Days;
        }

    }
}
