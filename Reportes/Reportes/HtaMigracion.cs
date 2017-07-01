using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.OleDb;
using System.Data;
using Reportes.Modelo;
//DRIVER FOXPRO
//https://download.microsoft.com/download/b/f/b/bfbfa4b8-7f91-4649-8dab-9a6476360365/VFPOLEDBSetup.msi
namespace Reportes
{
    class HtaMigracion
    {
        public static DataTable tDatos;


        public static void llenarDatosAlmacenes() {
            OleDbCommand cm = new OleDbCommand("select * from MGW10003", getConeccion());
            OleDbDataAdapter da = new OleDbDataAdapter(cm);
            tDatos = new DataTable("Almacenes");
            da.Fill(tDatos);
            List<string> columnas = new List<string>();
            foreach (DataColumn item in tDatos.Columns)
            {
                columnas.Add(item.ColumnName);
            }
        }
        public static void CargarAlmacenes(System.ComponentModel.BackgroundWorker syn) {
            if (tDatos.Rows.Count == 0) {
                llenarDatosAlmacenes();
            }        
            using (var ctx = new DataModel())
            {
                ctx.Configuration.AutoDetectChangesEnabled = false;
                /*nAuto.clienteVendedor = cliente;
                ctx.Autos.Add(nAuto);
                ctx.ClientesVendedor.Attach(cliente);
                ctx.SaveChanges();*/
                bool primero = true;
                int tIndice = 0;
                foreach (DataRow item in tDatos.Rows)
                {                    
                    admAlmacenes nAlmacen = new admAlmacenes();
                    nAlmacen.CIDALMACEN = Convert.ToInt32( item["CIDALMACEN"].ToString());   //*
                    nAlmacen.CCODIGOALMACEN = item["CCODIGOA01"].ToString();   //*
                    nAlmacen.CNOMBREALMACEN = item["CNOMBREA01"].ToString();  //*
                    nAlmacen.CFECHAALTAALMACEN =Convert.ToDateTime(item["CFECHAAL01"].ToString());

                    nAlmacen.CIDVALORCLASIFICACION1 =Convert.ToInt32( item["CIDVALOR01"].ToString());
                    nAlmacen.CIDVALORCLASIFICACION2 = Convert.ToInt32(item["CIDVALOR02"].ToString());
                    nAlmacen.CIDVALORCLASIFICACION3 = Convert.ToInt32(item["CIDVALOR03"].ToString());
                    nAlmacen.CIDVALORCLASIFICACION4 = Convert.ToInt32(item["CIDVALOR04"].ToString());
                    nAlmacen.CIDVALORCLASIFICACION5 = Convert.ToInt32(item["CIDVALOR05"].ToString());
                    nAlmacen.CIDVALORCLASIFICACION6 = Convert.ToInt32(item["CIDVALOR06"].ToString());
                    
                    nAlmacen.CSEGCONTALMACEN = item["CSEGCONT01"].ToString();  //*

                    nAlmacen.CTEXTOEXTRA1 = item["CTEXTOEX01"].ToString();  //*
                    nAlmacen.CTEXTOEXTRA2 = item["CTEXTOEX02"].ToString();  //*
                    nAlmacen.CTEXTOEXTRA3 = item["CTEXTOEX03"].ToString();   //*
                    nAlmacen.CFECHAEXTRA = Convert.ToDateTime(item["CFECHAEX01"].ToString());
                    
                        nAlmacen.CIMPORTEEXTRA1 =Convert.ToDouble( item["CIMPORTE01"].ToString());                    
                        nAlmacen.CIMPORTEEXTRA2 = Convert.ToDouble(item["CIMPORTE02"].ToString());                   
                        nAlmacen.CIMPORTEEXTRA3 = Convert.ToDouble(item["CIMPORTE03"].ToString());                    
                        nAlmacen.CIMPORTEEXTRA4 = Convert.ToDouble(item["CIMPORTE04"].ToString());                    
                        nAlmacen.CBANDOMICILIO = Convert.ToInt32(item["CBANDOMI01"].ToString());

                    nAlmacen.CTIMESTAMP = item["CTIMESTAMP"].ToString();  //*
                    nAlmacen.CSCALMAC2 = item["CSCALMAC2"].ToString();  //*
                    nAlmacen.CSCALMAC3 = item["CSCALMAC3"].ToString();  //*
                    nAlmacen.CSISTORIG = Convert.ToInt32(item["CSISTORIG"].ToString());


                        try
                        {
                            if (existeAlmacen(nAlmacen.CIDALMACEN))
                            {
                                //ctx.Entry(nAlmacen).State = System.Data.Entity.EntityState.Modified;
                            }
                            else
                            {
                                ctx.admAlmacenes.Add(nAlmacen);
                            ctx.SaveChanges();
                        }
                            
                        tIndice++;
                        syn.ReportProgress(tIndice);

                    }
                    catch (System.Data.Entity.Validation.DbEntityValidationException dbEx) {
                            Exception raise = dbEx;
                            foreach (var validationErrors in dbEx.EntityValidationErrors)
                            {
                                foreach (var validationError in validationErrors.ValidationErrors)
                                {
                                    string message = string.Format("{0}:{1}",
                                        validationErrors.Entry.Entity.ToString(),
                                        validationError.ErrorMessage);
                                    // raise a new exception nesting  
                                    // the current instance as InnerException  
                                    raise = new InvalidOperationException(message, raise);
                                }
                            }
                            throw raise;
                        }                   
                }
            }
                                      
        }


        public static void llenarDatosProductos() {
            //OleDbCommand cm = new OleDbCommand("select * from MGW10005 where CSTATUSP01=1", getConeccion());
            OleDbCommand cm = new OleDbCommand("select * from MGW10005", getConeccion());
            OleDbDataAdapter da = new OleDbDataAdapter(cm);
            tDatos = new DataTable("Almacenes");
            da.Fill(tDatos);
            List<string> columnas = new List<string>();
            /*string tem = "";
            foreach (DataColumn item in tDatos.Columns)
            {
                columnas.Add(item.ColumnName);
                tem = tem + " " + item.ColumnName;
            }*/
        }
        public static void CargarProductos(System.ComponentModel.BackgroundWorker syn) {
            if (tDatos.Rows.Count == 0) {
                llenarDatosProductos();
            }                                                                                                                                              
            using (var ctx = new DataModel())
            {
                ctx.Configuration.AutoDetectChangesEnabled = false;
                admProductos nProductos;
                int iTotal = 0;
                foreach (DataRow item in tDatos.Rows) {
                    nProductos = new admProductos();
                    //cidprodu01 ccodigop01 cnombrep01 ctipopro01 cfechaal01 ccontrol01 cidfotop01 cdescrip01 cmetodoc01 cpesopro01
                    nProductos.CIDPRODUCTO =Convert.ToInt32( item["cidprodu01"].ToString());
                    nProductos.CCODIGOPRODUCTO = item["ccodigop01"].ToString();
                    nProductos.CNOMBREPRODUCTO = item["cnombrep01"].ToString();
                    nProductos.CTIPOPRODUCTO = Convert.ToInt32(item["ctipopro01"].ToString());
                    nProductos.CFECHAALTAPRODUCTO =Convert.ToDateTime( item["cfechaal01"].ToString());
                    nProductos.CCONTROLEXISTENCIA =Convert.ToInt32( item["ccontrol01"].ToString());
                    nProductos.CIDFOTOPRODUCTO = Convert.ToInt32(item["cidfotop01"].ToString());
                    nProductos.CDESCRIPCIONPRODUCTO = item["cdescrip01"].ToString();
                    nProductos.CMETODOCOSTEO =Convert.ToInt32( item["cmetodoc01"].ToString());
                    nProductos.CPESOPRODUCTO =Convert.ToDouble( item["cpesopro01"].ToString());

                    //ccomvent01 ccomcobr01 ccostoes01 cmargenu01 cstatusp01 cidunida01 cidunida02 cfechabaja cimpuesto1 cimpuesto2 
                    nProductos.CCOMVENTAEXCEPPRODUCTO =Convert.ToDouble( item["ccomvent01"].ToString());
                    nProductos.CCOMCOBROEXCEPPRODUCTO = Convert.ToDouble(item["ccomcobr01"].ToString());
                    nProductos.CCOSTOESTANDAR = Convert.ToDouble(item["ccostoes01"].ToString());
                    nProductos.CMARGENUTILIDAD = Convert.ToDouble(item["cmargenu01"].ToString());
                    nProductos.CSTATUSPRODUCTO =Convert.ToInt32( item["cstatusp01"].ToString());
                    nProductos.CIDUNIDADBASE =Convert.ToInt32( item["cidunida01"].ToString());
                    nProductos.CIDUNIDADNOCONVERTIBLE =Convert.ToInt32( item["cidunida02"].ToString());
                    nProductos.CFECHABAJA =Convert.ToDateTime( item["cfechabaja"].ToString());
                    nProductos.CIMPUESTO1 =Convert.ToDouble( item["cimpuesto1"].ToString());
                    nProductos.CIMPUESTO2 =Convert.ToDouble( item["cimpuesto2"].ToString());

                    //cimpuesto3 cretenci01 cretenci02 cidpadre01 cidpadre02 cidpadre03 cidvalor01 cidvalor02 cidvalor03 cidvalor04 
                    nProductos.CIMPUESTO3 = Convert.ToDouble(item["cimpuesto3"].ToString());
                    nProductos.CRETENCION1 = Convert.ToDouble(item["cretenci01"].ToString());
                    nProductos.CRETENCION2 = Convert.ToDouble(item["cretenci02"].ToString());
                    nProductos.CIDPADRECARACTERISTICA1 = Convert.ToInt32(item["cidpadre01"].ToString());
                    nProductos.CIDPADRECARACTERISTICA2 = Convert.ToInt32(item["cidpadre02"].ToString());
                    nProductos.CIDPADRECARACTERISTICA3 = Convert.ToInt32(item["cidpadre03"].ToString());
                    nProductos.CIDVALORCLASIFICACION1 = Convert.ToInt32(item["cidvalor01"].ToString());
                    nProductos.CIDVALORCLASIFICACION2 = Convert.ToInt32(item["cidvalor02"].ToString());
                    nProductos.CIDVALORCLASIFICACION3 = Convert.ToInt32(item["cidvalor03"].ToString());
                    nProductos.CIDVALORCLASIFICACION4 =Convert.ToInt32( item["cidvalor04"].ToString());

                    //cidvalor05 cidvalor06 csegcont01 csegcont02 csegcont03 ctextoex01 ctextoex02 ctextoex03 cfechaex01 cimporte01 
                    nProductos.CIDVALORCLASIFICACION5 =Convert.ToInt32( item["cidvalor05"].ToString());
                    nProductos.CIDVALORCLASIFICACION6 =Convert.ToInt32( item["cidvalor06"].ToString());
                    nProductos.CSEGCONTPRODUCTO1 = item["csegcont01"].ToString();
                    nProductos.CSEGCONTPRODUCTO2 = item["csegcont02"].ToString();
                    nProductos.CSEGCONTPRODUCTO3 = item["csegcont03"].ToString();
                    nProductos.CTEXTOEXTRA1 = item["ctextoex01"].ToString();
                    nProductos.CTEXTOEXTRA2 = item["ctextoex02"].ToString();
                    nProductos.CTEXTOEXTRA3 = item["ctextoex03"].ToString();
                    nProductos.CFECHAEXTRA =Convert.ToDateTime( item["cfechaex01"].ToString());
                    nProductos.CIMPORTEEXTRA1 = Convert.ToDouble(item["cimporte01"].ToString());

                    //cimporte02 cimporte03 cimporte04 cprecio1 cprecio2 cprecio3 cprecio4 cprecio5 cprecio6 cprecio7 cprecio8 cprecio9 
                    nProductos.CIMPORTEEXTRA2 = Convert.ToDouble(item["cimporte02"].ToString());
                    nProductos.CIMPORTEEXTRA3 = Convert.ToDouble(item["cimporte03"].ToString());
                    nProductos.CIMPORTEEXTRA4 = Convert.ToDouble(item["cimporte04"].ToString());
                    nProductos.CPRECIO1 = Convert.ToDouble(item["cprecio1"].ToString());
                    nProductos.CPRECIO2 = Convert.ToDouble(item["cprecio2"].ToString());
                    nProductos.CPRECIO3 = Convert.ToDouble(item["cprecio3"].ToString());
                    nProductos.CPRECIO4 = Convert.ToDouble(item["cprecio4"].ToString());
                    nProductos.CPRECIO5 = Convert.ToDouble(item["cprecio5"].ToString());
                    nProductos.CPRECIO6 = Convert.ToDouble(item["cprecio6"].ToString());
                    nProductos.CPRECIO7 = Convert.ToDouble(item["cprecio7"].ToString());
                    nProductos.CPRECIO8 = Convert.ToDouble(item["cprecio8"].ToString());
                    nProductos.CPRECIO9 =Convert.ToDouble( item["cprecio9"].ToString());


                    //cprecio10 cbanunid01 cbancara01 cbanmeto01 cbanmaxmin cbanprecio cbanimpu01 cbancodi01 cbancomp01 ctimestamp 
                    //nProductos.CPRECI =Convert.ToDouble( item["cprecio10"].ToString());
                    nProductos.CBANUNIDADES = Convert.ToInt32(item["cbanunid01"].ToString());
                    nProductos.CBANCARACTERISTICAS = Convert.ToInt32(item["cbancara01"].ToString());
                    nProductos.CBANMETODOCOSTEO = Convert.ToInt32(item["cbanmeto01"].ToString());
                    nProductos.CBANMAXMIN = Convert.ToInt32(item["cbanmaxmin"].ToString());
                    nProductos.CBANPRECIO = Convert.ToInt32(item["cbanprecio"].ToString());
                    nProductos.CBANIMPUESTO = Convert.ToInt32(item["cbanimpu01"].ToString());
                    nProductos.CBANCODIGOBARRA =Convert.ToInt32( item["cbancodi01"].ToString());
                    nProductos.CBANCOMPONENTE =Convert.ToInt32( item["cbancomp01"].ToString());
                    //nProductos.CCOMCOBROEXCEPPRODUCTO =Convert.ToDouble( item["ctimestamp"].ToString());

                    //cerrorco01 cfechaer01 cprecioc01 cestadop01 cbanubic01 cesexento cexisten01 ccostoext1 ccostoext2 ccostoext3 
                    nProductos.CERRORCOSTO =Convert.ToInt32( item["cerrorco01"].ToString());
                    nProductos.CFECHAERRORCOSTO =Convert.ToDateTime(item["cfechaer01"].ToString());
                    nProductos.CPRECIOCALCULADO = Convert.ToDouble(item["cprecioc01"].ToString());
                    nProductos.CESTADOPRECIO = Convert.ToInt32(item["cestadop01"].ToString());
                    nProductos.CBANUBICACION = Convert.ToInt32(item["cbanubic01"].ToString());
                    nProductos.CESEXENTO = Convert.ToInt32(item["cesexento"].ToString());
                    nProductos.CEXISTENCIANEGATIVA = Convert.ToInt32(item["cexisten01"].ToString());
                    //nProductos.CFECCOSEX1 = Convert.ToDateTime(item["ccostoext1"].ToString());
                    nProductos.CCOSTOEXT2 = Convert.ToInt32(item["ccostoext2"].ToString());
                    nProductos.CCOSTOEXT3 =Convert.ToInt32( item["ccostoext3"].ToString());

                    //ccostoext4 ccostoext5 cfeccosex1 cfeccosex2 cfeccosex3 cfeccosex4 cfeccosex5 cmoncosex1 cmoncosex2 cmoncosex3 
                    nProductos.CCOSTOEXT4 =Convert.ToInt32( item["ccostoext4"].ToString());
                    nProductos.CCOSTOEXT5 = Convert.ToInt32(item["ccostoext5"].ToString());
                    nProductos.CFECCOSEX1 = Convert.ToDateTime(item["cfeccosex1"].ToString());
                    nProductos.CFECCOSEX2 = Convert.ToDateTime(item["cfeccosex2"].ToString());
                    nProductos.CFECCOSEX3 = Convert.ToDateTime(item["cfeccosex3"].ToString());
                    nProductos.CFECCOSEX4 = Convert.ToDateTime(item["cfeccosex4"].ToString());
                    nProductos.CFECCOSEX5 = Convert.ToDateTime(item["cfeccosex5"].ToString());
                    nProductos.CMONCOSEX1 = Convert.ToInt32(item["cmoncosex1"].ToString());
                    nProductos.CMONCOSEX2 = Convert.ToInt32(item["cmoncosex2"].ToString());
                    nProductos.CMONCOSEX3 = Convert.ToInt32(item["cmoncosex3"].ToString());

                    //cmoncosex4 cmoncosex5 cbancosex cescuotai2 cescuotai3 cidunicom ciduniven csubtipo ccodaltern cnomaltern cdesccorta 
                    nProductos.CMONCOSEX4 = Convert.ToInt32(item["cmoncosex4"].ToString());
                    nProductos.CMONCOSEX5 = Convert.ToInt32(item["cmoncosex5"].ToString());
                    nProductos.CBANCOSEX = Convert.ToInt32(item["cbancosex"].ToString());
                    nProductos.CESCUOTAI2 = Convert.ToInt32(item["cescuotai2"].ToString());
                    nProductos.CESCUOTAI3 = Convert.ToInt32(item["cescuotai3"].ToString());
                    nProductos.CIDUNIDADCOMPRA = Convert.ToInt32(item["cidunicom"].ToString());
                    nProductos.CIDUNIDADVENTA = Convert.ToInt32(item["ciduniven"].ToString());
                    nProductos.CSUBTIPO =Convert.ToInt32( item["csubtipo"].ToString());
                    nProductos.CCODALTERN = item["ccodaltern"].ToString();
                    nProductos.CNOMALTERN = item["cnomaltern"].ToString();
                    nProductos.CDESCCORTA = item["cdesccorta"].ToString();

                    //cidmoneda cusabascu ctipopaque cprecselec cdesglosai csegcont04 csegcont05 csegcont06 csegcont07 cctapred cnodescomp 
                    nProductos.CPESOPRODUCTO = Convert.ToDouble(item["cidmoneda"].ToString());
                    nProductos.CPESOPRODUCTO = Convert.ToDouble(item["cusabascu"].ToString());
                    nProductos.CPESOPRODUCTO = Convert.ToDouble(item["ctipopaque"].ToString());
                    nProductos.CPRECSELEC = Convert.ToInt32(item["cprecselec"].ToString());
                    nProductos.CDESGLOSAI2 = Convert.ToInt32(item["cdesglosai"].ToString());
                    nProductos.CSEGCONTPRODUCTO4 = item["csegcont04"].ToString();
                    nProductos.CSEGCONTPRODUCTO5 = item["csegcont05"].ToString();
                    nProductos.CSEGCONTPRODUCTO6 =item["csegcont06"].ToString();
                    nProductos.CSEGCONTPRODUCTO7 = item["csegcont07"].ToString();
                    nProductos.CCTAPRED = item["cctapred"].ToString();
                    nProductos.CNODESCOMP =Convert.ToInt32( item["cnodescomp"].ToString());

                    //cnomodcomp cidunixml
                    nProductos.CNOMODCOMP =Convert.ToInt32( item["cnomodcomp"].ToString());
                    nProductos.CIDUNIXML =Convert.ToInt32( item["cidunixml"].ToString());


                    try
                    {
                        if (existeProducto(nProductos.CIDPRODUCTO))
                        {
                            //ctx.Entry(nProductos).State = System.Data.Entity.EntityState.Modified;
                        }
                        else
                        {
                            ctx.admProductos.Add(nProductos);
                            ctx.SaveChanges();
                        }
                        
                        iTotal++;
                        syn.ReportProgress(iTotal);
                    }
                    catch (System.Data.Entity.Validation.DbEntityValidationException dbEx)
                    {
                        Exception raise = dbEx;
                        foreach (var validationErrors in dbEx.EntityValidationErrors)
                        {
                            foreach (var validationError in validationErrors.ValidationErrors)
                            {
                                string message = string.Format("{0}:{1}",
                                    validationErrors.Entry.Entity.ToString(),
                                    validationError.ErrorMessage);
                                // raise a new exception nesting  
                                // the current instance as InnerException  
                                raise = new InvalidOperationException(message, raise);
                            }
                        }
                        throw raise;
                    }



                }
            }
        }

        public static void llenarDatosCapasProducto() {
            OleDbCommand cm = new OleDbCommand("select * from MGW10025 where cexisten01>0 order by CFECHA desc", getConeccion());
            OleDbDataAdapter da = new OleDbDataAdapter(cm);
             tDatos = new DataTable("Almacenes");
            da.Fill(tDatos);
            List<string> columnas = new List<string>();
        }
        public static void CargarCapasProducto(System.ComponentModel.BackgroundWorker syn)
        {
            if (tDatos.Rows.Count == 0) {
                llenarDatosCapasProducto();
            }
            using (var ctx = new DataModel())
            {
                ctx.Configuration.AutoDetectChangesEnabled = false;
                //ctx.Database.ExecuteSqlCommand("TRUNCATE TABLE admMovimientosCapas");
                //ctx.Database.ExecuteSqlCommand("TRUNCATE TABLE admcapasproducto");
                admCapasProducto nCapa;
                int indice = 0;
                foreach (DataRow item in tDatos.Rows)
                {
                    nCapa = new admCapasProducto();
                    nCapa.CIDCAPA = Convert.ToInt32(item["cidcapa"].ToString());
                    nCapa.CIDALMACEN = Convert.ToInt32(item["cidalmacen"].ToString());
                    nCapa.CIDPRODUCTO = Convert.ToInt32(item["cidprodu01"].ToString());
                    nCapa.CFECHA = Convert.ToDateTime(item["cfecha"].ToString());
                    nCapa.CTIPOCAPA = Convert.ToInt32(item["ctipocapa"].ToString());
                    nCapa.CNUMEROLOTE = (item["cnumerol01"].ToString());
                    nCapa.CFECHACADUCIDAD = Convert.ToDateTime(item["cfechaca01"].ToString());
                    nCapa.CFECHAFABRICACION = Convert.ToDateTime(item["cfechafa01"].ToString());
                    nCapa.CPEDIMENTO = (item["cpedimento"].ToString());
                    nCapa.CADUANA = (item["caduana"].ToString());
                    nCapa.CFECHAPEDIMENTO = Convert.ToDateTime(item["cfechape01"].ToString());
                    nCapa.CTIPOCAMBIO = Convert.ToDouble(item["ctipocam01"].ToString());
                    nCapa.CEXISTENCIA = Convert.ToDouble(item["cexisten01"].ToString());
                    nCapa.CCOSTO = Convert.ToDouble(item["ccosto"].ToString());
                    nCapa.CIDCAPAORIGEN = Convert.ToInt32(item["cidcapao01"].ToString());
                    nCapa.CTIMESTAMP = (item["ctimestamp"].ToString());
                    nCapa.CNUMADUANA = Convert.ToInt32(item["cnumaduana"].ToString());
                    try
                    {
                        if (existeCapa(nCapa.CIDCAPA))
                        {
                            //ctx.Entry(nCapa).State = System.Data.Entity.EntityState.Modified;
                        }
                        else
                        {
                            ctx.admCapasProducto.Add(nCapa);
                            ctx.SaveChanges();
                        }
                        
                        indice++;
                        syn.ReportProgress(indice);
                    }
                    catch (System.Data.Entity.Validation.DbEntityValidationException dbEx)
                    {
                        Exception raise = dbEx;
                        foreach (var validationErrors in dbEx.EntityValidationErrors)
                        {
                            foreach (var validationError in validationErrors.ValidationErrors)
                            {
                                string message = string.Format("{0}:{1}",
                                    validationErrors.Entry.Entity.ToString(),
                                    validationError.ErrorMessage);
                                // raise a new exception nesting  
                                // the current instance as InnerException  
                                raise = new InvalidOperationException(message, raise);
                            }
                        }
                        throw raise;
                    }

                }
            }
        }

        #region "CODIGO COMENTADO"
        /*

        public static void llenarDatosMovimientoCapas() {
            String query = "SELECT * FROM MGW10028 order by CFECHA desc ";// where cnumeros01=" + IdNumSerie.ToString();
            OleDbCommand cm = new OleDbCommand(query, getConeccion());
            OleDbDataAdapter da = new OleDbDataAdapter(cm);
            tDatos = new DataTable("Almacenes");
            da.Fill(tDatos);
            List<string> columnas = new List<string>();
            string tem = "";
            foreach (DataColumn item in tDatos.Columns)
            {
                columnas.Add(item.ColumnName);
                tem = tem + " " + item.ColumnName;
            }
            int c = 0;
        }
        public static void CargarMovimientoCapas(System.ComponentModel.BackgroundWorker syn)
        {
            if (tDatos.Rows.Count == 0) {
                llenarDatosMovimientoCapas();
            }
            using (var ctx = new DataModel())
            {
                ctx.Configuration.AutoDetectChangesEnabled = false;
                //ctx.Database.ExecuteSqlCommand("TRUNCATE TABLE admMovimientosCapas");
                admMovimientosCapas nCapa;
                int indice = 0;
                foreach (DataRow item in tDatos.Rows)
                {
                    nCapa = new admMovimientosCapas();
                    nCapa.CIDMOVIMIENTO = Convert.ToInt32(item["cidmovim01"].ToString());
                    nCapa.CIDCAPA = Convert.ToInt32(item["cidcapa"].ToString());
                    nCapa.CFECHA = Convert.ToDateTime(item["cfecha"].ToString());
                    nCapa.CUNIDADES = Convert.ToDouble(item["cunidades"].ToString());
                    nCapa.CTIPOCAPA = Convert.ToInt32(item["ctipocapa"].ToString());
                    nCapa.CIDUNIDAD = Convert.ToInt32(item["cidunidad"].ToString());

                    try
                    {
                        if (existeMovimientoCapa(nCapa.CIDMOVIMIENTO))
                        {
                            //ctx.Entry(nCapa).State = System.Data.Entity.EntityState.Modified;
                        }
                        else
                        {
                            ctx.admMovimientosCapas.Add(nCapa);
                            ctx.SaveChanges();
                        }
                        
                        indice++;
                        syn.ReportProgress(indice);
                    }
                    catch (System.Data.Entity.Validation.DbEntityValidationException dbEx)
                    {
                        Exception raise = dbEx;
                        foreach (var validationErrors in dbEx.EntityValidationErrors)
                        {
                            foreach (var validationError in validationErrors.ValidationErrors)
                            {
                                string message = string.Format("{0}:{1}",
                                    validationErrors.Entry.Entity.ToString(),
                                    validationError.ErrorMessage);
                                // raise a new exception nesting  
                                // the current instance as InnerException  
                                raise = new InvalidOperationException(message, raise);
                            }
                        }
                        throw raise;
                    }

                }

            }


        }

        public static void llenarDatosMovimientoInvFisicoCa()
        {
            String query = "SELECT * FROM MGW10040";
            OleDbCommand cm = new OleDbCommand(query, getConeccion());
            OleDbDataAdapter da = new OleDbDataAdapter(cm);
            tDatos = new DataTable("Almacenes");
            da.Fill(tDatos);
            List<string> columnas = new List<string>();
            string tem = "";
            foreach (DataColumn item in tDatos.Columns)
            {
                columnas.Add(item.ColumnName);
                tem = tem + " " + item.ColumnName;
            }
            int c = 0;
        }
        public static void CargarMovimientoInvFisicoCa(System.ComponentModel.BackgroundWorker syn)
        {
            if (tDatos.Rows.Count == 0)
            {
                llenarDatosMovimientoInvFisicoCa();
            }
            using (var ctx = new DataModel())
            {
                ctx.Configuration.AutoDetectChangesEnabled = false;
                ctx.Database.ExecuteSqlCommand("TRUNCATE TABLE admMovtosInvFisicoSerieCa");
                admMovtosInvFisicoSerieCa nCapa;
                int indice = 0;
                foreach (DataRow item in tDatos.Rows)
                {
                    nCapa = new admMovtosInvFisicoSerieCa();
                    nCapa.CIDSERIECAPA = Convert.ToInt32(item["cidserie01"].ToString());
                    nCapa.CIDMOVTOINVENTARIOFISICO = Convert.ToInt32(item["cidmovto01"].ToString());
                    nCapa.CIDPRODUCTO = Convert.ToInt32(item["cidprodu01"].ToString());
                    nCapa.CNUMEROSERIE = Convert.ToString(item["cnumeros01"].ToString());
                    nCapa.CNUMEROLOTE = Convert.ToString(item["cnumerol01"].ToString());
                    nCapa.CFECHACADUCIDAD = Convert.ToDateTime(item["cfechaca01"].ToString());
                    nCapa.CFECHAFABRICACION = Convert.ToDateTime(item["cfechafa01"].ToString());
                    nCapa.CFECHAPEDIMENTO = Convert.ToDateTime(item["cfechape01"].ToString());
                    nCapa.CTIPOCAMBIO = Convert.ToDouble(item["ctipocam01"].ToString());
                    nCapa.CIDALMACEN = Convert.ToInt32(item["cidalmacen"].ToString());
                    nCapa.CTIPO = Convert.ToInt32(item["ctipo"].ToString());
                    nCapa.CIDCAPA = Convert.ToInt32(item["cidcapa"].ToString());
                    nCapa.CCANTIDAD = Convert.ToDouble(item["ccantidad"].ToString());
                    nCapa.CADUANA = item["caduana"].ToString();
                    nCapa.CPEDIMENTO = item["cpedimento"].ToString();

                    //cidserie01 cidmovto01 cidprodu01 cnumeros01 cidalmacen 
                    //ctipo cnumerol01 cfechaca01 cfechafa01 cpedimento 
                    //caduana cfechape01 ctipocam01 ccantidad cidcapa

                    try
                    {
                        if (existeMovimientoInventarioFisicoSerieCa(nCapa.CIDMOVTOINVENTARIOFISICO))
                        {
                            //ctx.Entry(nCapa).State = System.Data.Entity.EntityState.Modified;
                        }
                        else
                        {
                            ctx.admMovtosInvFisicoSerieCa.Add(nCapa);
                            ctx.SaveChanges();
                        }

                        indice++;
                        syn.ReportProgress(indice);
                    }
                    catch (System.Data.Entity.Validation.DbEntityValidationException dbEx)
                    {
                        Exception raise = dbEx;
                        foreach (var validationErrors in dbEx.EntityValidationErrors)
                        {
                            foreach (var validationError in validationErrors.ValidationErrors)
                            {
                                string message = string.Format("{0}:{1}",
                                    validationErrors.Entry.Entity.ToString(),
                                    validationError.ErrorMessage);
                                // raise a new exception nesting  
                                // the current instance as InnerException  
                                raise = new InvalidOperationException(message, raise);
                            }
                        }
                        throw raise;
                    }

                }

            }


        }
       
        public static void CargarExistencia() {
            //OleDbCommand cm = new OleDbCommand("select * from MGW10030", getConeccion());
            //SELECT * FROM existenciacosto WHERE CIDEJERCICIO=(
            //select MAX(CIDEJERCICIO) as EJERCICIO from existenciacosto ORDER BY CIDEXISTENCIA DESC);
            String query = "SELECT * FROM MGW10030 WHERE CIDEJERC01=(select MAX(CIDEJERC01) as EJERCICIO from MGW10030 ORDER BY CIDEXIST01 DESC); ";
            OleDbCommand cm = new OleDbCommand(query, getConeccion());
            OleDbDataAdapter da = new OleDbDataAdapter(cm);
            DataTable tDatos = new DataTable("Almacenes");
            da.Fill(tDatos);
            List<string> columnas = new List<string>();
            string tem = "";
            foreach (DataColumn item in tDatos.Columns)
            {
                columnas.Add(item.ColumnName);
                tem = tem + " " + item.ColumnName;
            }
            using (var ctx = new DataModel()) {
                admExistenciaCosto nExistencia;
                foreach (DataRow item in tDatos.Rows) {
                    nExistencia = new admExistenciaCosto();
                    nExistencia.CIDEXISTENCIA = Convert.ToInt32(item["cidexist01"].ToString());
                    nExistencia.CIDALMACEN = Convert.ToInt32(item["cidalmacen"].ToString());
                    nExistencia.CIDPRODUCTO = Convert.ToInt32(item["cidprodu01"].ToString());
                    nExistencia.CIDEJERCICIO = Convert.ToInt32(item["cidejerc01"].ToString());
                    nExistencia.CTIPOEXISTENCIA = Convert.ToInt32(item["ctipoexi01"].ToString());
                    nExistencia.CENTRADASINICIALES = Convert.ToDouble(item["centrada01"].ToString());
                    nExistencia.CSALIDASINICIALES = Convert.ToDouble(item["csalidas01"].ToString());
                    nExistencia.CCOSTOINICIALENTRADAS = Convert.ToDouble(item["ccostoin01"].ToString());
                    nExistencia.CCOSTOINICIALSALIDAS = Convert.ToDouble(item["ccostoin02"].ToString());
                    nExistencia.CENTRADASPERIODO1 = Convert.ToDouble(item["centrada02"].ToString());
                    nExistencia.CENTRADASPERIODO2 = Convert.ToDouble(item["centrada03"].ToString());
                    nExistencia.CENTRADASPERIODO3 = Convert.ToDouble(item["centrada04"].ToString());
                    nExistencia.CENTRADASPERIODO4 = Convert.ToDouble(item["centrada05"].ToString());
                    nExistencia.CENTRADASPERIODO5 = Convert.ToDouble(item["centrada06"].ToString());
                    nExistencia.CENTRADASPERIODO6 = Convert.ToDouble(item["centrada07"].ToString());
                    nExistencia.CENTRADASPERIODO7 = Convert.ToDouble(item["centrada08"].ToString());
                    nExistencia.CENTRADASPERIODO8 = Convert.ToDouble(item["centrada09"].ToString());
                    nExistencia.CENTRADASPERIODO9 = Convert.ToDouble(item["centrada10"].ToString());
                    nExistencia.CENTRADASPERIODO10 = Convert.ToDouble(item["centrada11"].ToString());
                    nExistencia.CENTRADASPERIODO11 = Convert.ToDouble(item["centrada12"].ToString());
                    nExistencia.CENTRADASPERIODO12 = Convert.ToDouble(item["centrada13"].ToString());
                    nExistencia.CSALIDASPERIODO1 =Convert.ToDouble(item["csalidas02"].ToString());
                    nExistencia.CSALIDASPERIODO2=Convert.ToDouble(item["csalidas03"].ToString());
                    nExistencia.CSALIDASPERIODO3 = Convert.ToDouble(item["csalidas04"].ToString());
                    nExistencia.CSALIDASPERIODO4 =Convert.ToDouble(item["csalidas05"].ToString());
                    nExistencia.CSALIDASPERIODO5 = Convert.ToDouble(item["csalidas06"].ToString());
                    nExistencia.CSALIDASPERIODO5 =Convert.ToDouble( item["csalidas07"].ToString()); 
                    nExistencia.CSALIDASPERIODO6=Convert.ToDouble( item["csalidas08"].ToString());
                    nExistencia.CSALIDASPERIODO7 = Convert.ToDouble(item["csalidas09"].ToString());
                    nExistencia.CSALIDASPERIODO8 = Convert.ToDouble(item["csalidas10"].ToString());
                    nExistencia.CSALIDASPERIODO9 = Convert.ToDouble(item["csalidas11"].ToString());
                    nExistencia.CSALIDASPERIODO10 = Convert.ToDouble(item["csalidas12"].ToString());
                    nExistencia.CSALIDASPERIODO11 = Convert.ToDouble(item["csalidas13"].ToString());
                    nExistencia.CCOSTOENTRADASPERIODO1 =Convert.ToDouble( item["ccostoen01"].ToString());
                    nExistencia.CCOSTOENTRADASPERIODO2 = Convert.ToDouble( item["ccostoen02"].ToString());
                    nExistencia.CCOSTOENTRADASPERIODO3 = Convert.ToDouble( item["ccostoen03"].ToString());
                    nExistencia.CCOSTOENTRADASPERIODO4 = Convert.ToDouble( item["ccostoen04"].ToString());
                    nExistencia.CCOSTOENTRADASPERIODO5 = Convert.ToDouble(item["ccostoen05"].ToString());
                    nExistencia.CCOSTOENTRADASPERIODO6 = Convert.ToDouble( item["ccostoen06"].ToString());
                    nExistencia.CCOSTOENTRADASPERIODO7 = Convert.ToDouble( item["ccostoen07"].ToString());
                    nExistencia.CCOSTOENTRADASPERIODO8 = Convert.ToDouble( item["ccostoen08"].ToString());
                    nExistencia.CCOSTOENTRADASPERIODO9 = Convert.ToDouble( item["ccostoen09"].ToString());
                    nExistencia.CCOSTOENTRADASPERIODO10 = Convert.ToDouble( item["ccostoen10"].ToString());
                    nExistencia.CCOSTOENTRADASPERIODO11 = Convert.ToDouble( item["ccostoen11"].ToString());
                    nExistencia.CCOSTOENTRADASPERIODO12 = Convert.ToDouble( item["ccostoen12"].ToString());
                    nExistencia.CCOSTOSALIDASPERIODO1 =Convert.ToDouble( item["ccostosa01"].ToString());
                    nExistencia.CCOSTOSALIDASPERIODO2 = Convert.ToDouble( item["ccostosa02"].ToString() );
                    nExistencia.CCOSTOSALIDASPERIODO3 = Convert.ToDouble( item["ccostosa03"].ToString() );
                    nExistencia.CCOSTOSALIDASPERIODO4 = Convert.ToDouble( item["ccostosa04"].ToString() );
                    nExistencia.CCOSTOSALIDASPERIODO5 = Convert.ToDouble( item["ccostosa05"].ToString() );
                    nExistencia.CCOSTOSALIDASPERIODO6 = Convert.ToDouble( item["ccostosa06"].ToString() );
                    nExistencia.CCOSTOSALIDASPERIODO7 = Convert.ToDouble( item["ccostosa07"].ToString() );
                    nExistencia.CCOSTOSALIDASPERIODO8 = Convert.ToDouble( item["ccostosa08"].ToString() );
                    nExistencia.CCOSTOSALIDASPERIODO9 = Convert.ToDouble( item["ccostosa09"].ToString() );
                    nExistencia.CCOSTOSALIDASPERIODO10 = Convert.ToDouble( item["ccostosa10"].ToString() );
                    nExistencia.CCOSTOSALIDASPERIODO11 = Convert.ToDouble( item["ccostosa11"].ToString() );
                    nExistencia.CCOSTOSALIDASPERIODO12 = Convert.ToDouble( item["ccostosa12"].ToString() );
                    nExistencia.CBANCONGELADO =Convert.ToInt32( item["cbancong01"].ToString() );
                    //= item["ctimestamp"].ToString());

                    try
                    {
                        if (existeExistencia(nExistencia.CIDEXISTENCIA))
                        {
                            ctx.Entry(nExistencia).State = System.Data.Entity.EntityState.Modified;
                        }
                        else
                        {
                            ctx.admExistenciaCosto.Add(nExistencia);
                        }
                        ctx.SaveChanges();
                    }
                    catch (System.Data.Entity.Validation.DbEntityValidationException dbEx)
                    {
                        Exception raise = dbEx;
                        foreach (var validationErrors in dbEx.EntityValidationErrors)
                        {
                            foreach (var validationError in validationErrors.ValidationErrors)
                            {
                                string message = string.Format("{0}:{1}",
                                    validationErrors.Entry.Entity.ToString(),
                                    validationError.ErrorMessage);
                                // raise a new exception nesting  
                                // the current instance as InnerException  
                                raise = new InvalidOperationException(message, raise);
                            }
                        }
                        throw raise;
                    }
                }
            }
        }

        public static void CargarMovimientoSerie() {
            String query = "SELECT * FROM MGW10036";
            OleDbCommand cm = new OleDbCommand(query, getConeccion());
            OleDbDataAdapter da = new OleDbDataAdapter(cm);
            DataTable tDatos = new DataTable("Almacenes");
            da.Fill(tDatos);
            List<string> columnas = new List<string>();
            string tem = "";         
            using (var ctx = new DataModel())
            {
                foreach (DataRow item in tDatos.Rows)
                {
                    admMovimientoSerie movimiento = new admMovimientoSerie();
                    //cidmovim01 cidserie cfecha
                    movimiento.CIDMOVIMIENTO = Convert.ToInt32(item["cidmovim01"].ToString());
                    movimiento.CIDSERIE = Convert.ToInt32(item["cidserie"].ToString());
                    movimiento.CFECHA = Convert.ToDateTime(item["cfecha"].ToString());

                    try
                    {
                        if (existeMovimientoSerie(movimiento.CIDSERIE,movimiento.CIDMOVIMIENTO))
                        {
                            ctx.Entry(movimiento).State = System.Data.Entity.EntityState.Modified;
                        }
                        else
                        {
                            ctx.admMovimientoSerie.Add(movimiento);
                        }
                        ctx.SaveChanges();
                       
                    }
                    catch (System.Data.Entity.Validation.DbEntityValidationException dbEx)
                    {
                        Exception raise = dbEx;
                        foreach (var validationErrors in dbEx.EntityValidationErrors)
                        {
                            foreach (var validationError in validationErrors.ValidationErrors)
                            {
                                string message = string.Format("{0}:{1}",
                                    validationErrors.Entry.Entity.ToString(),
                                    validationError.ErrorMessage);
                                // raise a new exception nesting  
                                // the current instance as InnerException  
                                raise = new InvalidOperationException(message, raise);
                            }
                        }
                        throw raise;
                    }
                }
            }
        }

        public static void CargarNumeroSerie() {
            String query = "SELECT * FROM MGW10032";// where cnumeros01=" + IdNumSerie.ToString();
            OleDbCommand cm = new OleDbCommand(query, getConeccion());
            OleDbDataAdapter da = new OleDbDataAdapter(cm);
            DataTable tDatos = new DataTable("Almacenes");
            da.Fill(tDatos);
            List<string> columnas = new List<string>();

            using (var ctx = new DataModel()) {
                admNumerosSerie nSerie;
                foreach (DataRow item in tDatos.Rows) {
                    nSerie = new admNumerosSerie();
                    nSerie.CIDSERIE = Convert.ToInt32(item["cidserie"].ToString()); 
                    nSerie.CIDPRODUCTO= Convert.ToInt32(item["cidprodu01"].ToString()); 
                    nSerie.CNUMEROSERIE= item["cnumeros01"].ToString(); 
                    nSerie.CIDALMACEN= Convert.ToInt32(item["cidalmacen"].ToString()); 
                    nSerie.CESTADO= Convert.ToInt32(item["cestado"].ToString()); 
                    nSerie.CESTADOANTERIOR= Convert.ToInt32(item["cestadoa01"].ToString()); 
                    nSerie.CNUMEROLOTE=item["cnumerol01"].ToString(); 
                        nSerie.CFECHACADUCIDAD=Convert.ToDateTime(item["cfechaca01"].ToString()); 
                    nSerie.CFECHAFABRICACION= Convert.ToDateTime(item["cfechafa01"].ToString()); 
                    nSerie.CPEDIMENTO= item["cpedimento"].ToString(); 
                    nSerie.CADUANA=item["caduana"].ToString(); 
                    nSerie.CFECHAPEDIMENTO= Convert.ToDateTime(item["cfechape01"].ToString()); 
                    nSerie.CTIPOCAMBIO= Convert.ToDouble(item["ctipocam01"].ToString()); 
                    nSerie.CCOSTO= Convert.ToDouble(item["ccosto"].ToString()); 
                    nSerie.CTIMESTAMP= Convert.ToString(item["ctimestamp"].ToString());
                    nSerie.CNUMADUANA= Convert.ToInt32(item["cnumaduana"].ToString());

                    try
                    {
                        if (existeNumeroSerie(nSerie.CIDSERIE))
                        {
                            ctx.Entry(nSerie).State = System.Data.Entity.EntityState.Modified;
                        }
                        else
                        {
                            ctx.admNumerosSerie.Add(nSerie);
                        }
                        ctx.SaveChanges();
                    }
                    catch (System.Data.Entity.Validation.DbEntityValidationException dbEx)
                    {
                        Exception raise = dbEx;
                        foreach (var validationErrors in dbEx.EntityValidationErrors)
                        {
                            foreach (var validationError in validationErrors.ValidationErrors)
                            {
                                string message = string.Format("{0}:{1}",
                                    validationErrors.Entry.Entity.ToString(),
                                    validationError.ErrorMessage);
                                // raise a new exception nesting  
                                // the current instance as InnerException  
                                raise = new InvalidOperationException(message, raise);
                            }
                        }
                        throw raise;
                    }

                }
            }

            
        }

        */

        #endregion



        #region "FUNCIONES EXTRAS"
        #region "COMENTADO"
        /*
 

    private static Boolean existeMovimientoInventarioFisicoSerieCa(int Id) {
        admMovtosInvFisicoSerieCa tAlmacen = new admMovtosInvFisicoSerieCa();
        try
        {
            using (var ctx = new DataModel())
            {
                tAlmacen = ctx.admMovtosInvFisicoSerieCa
                    .Where(r => r.CIDMOVTOINVENTARIOFISICO == Id)
                    .FirstOrDefault();
            }
        }
        catch (Exception ex)
        {
            throw;
        }
        if (tAlmacen != null)
            return true;
        else
            return false;
    }

    private static Boolean existeMovimientoCapa(int Id)
    {
        admMovimientosCapas tAlmacen = new admMovimientosCapas();
        try
        {
            using (var ctx = new DataModel())
            {
                tAlmacen = ctx.admMovimientosCapas
                    .Where(r => r.CIDMOVIMIENTO == Id)
                    .FirstOrDefault();
            }
        }
        catch (Exception ex)
        {
            throw;
        }
        if (tAlmacen != null)
            return true;
        else
            return false;
    }

    private static Boolean existeNumeroSerie(int Id)
    {
        admNumerosSerie tAlmacen = new admNumerosSerie();
        try
        {
            using (var ctx = new DataModel())
            {
                tAlmacen = ctx.admNumerosSerie
                    .Where(r => r.CIDSERIE == Id)
                    .FirstOrDefault();
            }
        }
        catch (Exception ex)
        {
            throw;
        }
        if (tAlmacen != null)
            return true;
        else
            return false;
    }


    private static Boolean existeMovimientoSerie(int IdSerie, int IdMovimiento) {
        admMovimientoSerie tAlmacen = new admMovimientoSerie();
        try
        {
            using (var ctx = new DataModel())
            {
                tAlmacen = ctx.admMovimientoSerie
                    .Where(r => r.CIDSERIE == IdSerie)
                    .Where(r=>r.CIDMOVIMIENTO==IdMovimiento)
                    .FirstOrDefault();
            }
        }
        catch (Exception ex)
        {
            throw;
        }
        if (tAlmacen != null)
            return true;
        else
            return false;
    }



    private static Boolean existeExistencia(int Id)
    {
        admExistenciaCosto tAlmacen = new admExistenciaCosto();
        try
        {
            using (var ctx = new DataModel())
            {
                tAlmacen = ctx.admExistenciaCosto
                    .Where(r => r.CIDEXISTENCIA == Id)
                    .FirstOrDefault();
            }
        }
        catch (Exception ex)
        {
            throw;
        }
        if (tAlmacen != null)
            return true;
        else
            return false;
    }
    */
        #endregion

        private static OleDbConnection getConeccion()
        {
            OleDbConnection cn = new OleDbConnection();
            cn.ConnectionString = "Provider=vfpoledb;Data Source=C:\\Compacw\\Empresas\\SuZuMa\\Respaldo;Collating Sequence=general";
            return cn;
        }
        private static Boolean existeAlmacen(int Id)
        {
            admAlmacenes tAlmacen = new admAlmacenes();
            try
            {
                using (var ctx = new DataModel())
                {
                    tAlmacen = ctx.admAlmacenes
                        .Where(r => r.CIDALMACEN == Id)
                        .FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            if (tAlmacen != null)
                return true;
            else
                return false;
        }
        private static Boolean existeProducto(int Id)
        {
            admProductos tAlmacen = new admProductos();
            try
            {
                using (var ctx = new DataModel())
                {
                    tAlmacen = ctx.admProductos
                        .Where(r => r.CIDPRODUCTO == Id)
                        .FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            if (tAlmacen != null)
                return true;
            else
                return false;
        }

        private static Boolean existeCapa(int Id) {
            admCapasProducto tAlmacen = new admCapasProducto();
            try
            {
                using (var ctx = new DataModel())
                {
                    tAlmacen = ctx.admCapasProducto
                        .Where(r => r.CIDCAPA == Id)
                        .FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            if (tAlmacen != null)
                return true;
            else
                return false;
        }
        #endregion

    }
}
