using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Reportes.Modelo;
using System.IO;
using System.Diagnostics;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace Reportes
{
    public partial class btnExcel : Form
    {
        public static System.Drawing.Color cGris = System.Drawing.Color.FromArgb(251, 252, 252);
        public static System.Drawing.Color cVerde = System.Drawing.Color.FromArgb(229,255,204);
        public static System.Drawing.Color cAmarillo = System.Drawing.Color.FromArgb(255,255,204);
        public static System.Drawing.Color cRojo = System.Drawing.Color.FromArgb(255,229,204);

        int nRenglon = 0;
        admAlmacenes almacen;

        public btnExcel()
        {
            InitializeComponent();            
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
                   
        }

        private void cmbAlmacenes_SelectedIndexChanged(object sender, EventArgs e)
        {
            AcDeBotones();
            InicializarCiadricula();
            if (cmbAlmacenes.SelectedIndex > 0)
            {
                  almacen = conAlmacen.buscarAlmacen(Convert.ToInt32(cmbAlmacenes.SelectedValue));
                //MOSTRAR DATOS ALMACEN
                grdDatos.Rows.Insert(nRenglon,"");
                grdDatos.Rows[nRenglon].Cells[0].Value = almacen.CNOMBREALMACEN.ToUpper();
                grdDatos.Rows[nRenglon].Cells[0].ToolTipText = almacen.CCODIGOALMACEN.ToUpper();
                nRenglon++;
                procesarProductos();
            }
            AcDeBotones();
        }

        private void procesarProductos()
        {
            #region "CODIGO COMENTADO"
            /*foreach (var item in almacen.ExistenciaCosto) {                
                var producto= conAlmacen.buscarProducto(item.CIDPRODUCTO);
                
                if (producto != null)
                {
                    grdDatos.Rows.Insert(nRenglon, "");
//                    grdDatos.Rows[nRenglon].Cells[1].Value = item.CIDPRODUCTO;
                    grdDatos.Rows[nRenglon].Cells[1].Value = producto.CCODIGOPRODUCTO.ToUpper() + " -- "+ item.CIDPRODUCTO.ToString();
                    grdDatos.Rows[nRenglon].Cells[2].Value = producto.CNOMBREPRODUCTO.ToUpper();
                    grdDatos.Rows[nRenglon].Cells[3].Value = item.CalcularExistencia();

                    double[] tem = almacen.tPrimerRango(producto.CIDPRODUCTO);
                    grdDatos.Rows[nRenglon].Cells[4].Value = tem[1];
                    grdDatos.Rows[nRenglon].Cells[5].Value = tem[2];
                    grdDatos.Rows[nRenglon].Cells[6].Value = tem[3];
                    grdDatos.Rows[nRenglon].Cells[7].Value = tem[4];
                    grdDatos.Rows[nRenglon].Cells[8].Value = tem[0];

                    nRenglon++;
                    //TODO: PROCESAR LOS TIEMPOS DE CADUCIDAD Y METERLOS EN EL RANGO
                }          
            }*/
            #endregion  
            
            foreach (admProductos item in almacen.listarProductos()) {
                double merma = 0;
                grdDatos.Rows.Insert(nRenglon, "");
                //grdDatos.Rows[nRenglon].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                grdDatos.Rows[nRenglon].Cells[1].Value = item.CCODIGOPRODUCTO.ToUpper();
                grdDatos.Rows[nRenglon].Cells[2].Value = item.CNOMBREPRODUCTO.ToUpper();
                            
                grdDatos.Rows[nRenglon].Cells[4].Value =  item.CalcularTotalRango17(almacen.CIDALMACEN).ToString("N");
                grdDatos.Rows[nRenglon].Cells[5].Value = item.CalcularTotalRango816(almacen.CIDALMACEN).ToString("N");
                grdDatos.Rows[nRenglon].Cells[6].Value =  item.CalcularTotalRango1730(almacen.CIDALMACEN).ToString("N");
                grdDatos.Rows[nRenglon].Cells[7].Value =  item.CalcularTotalRango3100(almacen.CIDALMACEN).ToString("N");
                merma = item.CalcularTotalCaducos(almacen.CIDALMACEN);
                grdDatos.Rows[nRenglon].Cells[8].Value = merma.ToString("N");

                double tStock = Convert.ToDouble(grdDatos.Rows[nRenglon].Cells[4].Value) +
                    Convert.ToDouble(grdDatos.Rows[nRenglon].Cells[5].Value) +
                    Convert.ToDouble(grdDatos.Rows[nRenglon].Cells[6].Value) +
                    Convert.ToDouble(grdDatos.Rows[nRenglon].Cells[7].Value) +
                    Convert.ToDouble(grdDatos.Rows[nRenglon].Cells[8].Value);
                grdDatos.Rows[nRenglon].Cells[3].Value = tStock.ToString("N"); //almacen.stockProducto(item.CIDPRODUCTO)  + " [ " + tStock + " ]";

                double costo = item.CalcularCostoPromedio(almacen.CIDALMACEN);
                grdDatos.Rows[nRenglon].Cells[9].Value = "$ " + costo.ToString("N");                               
                grdDatos.Rows[nRenglon].Cells[10].Value = "$ " +(costo*merma).ToString("N");


                #region "FORMATO"
                double temp = Convert.ToDouble(grdDatos.Rows[nRenglon].Cells[8].Value);
                //CADUCOS
                    if (temp > 0)
                    {
                        grdDatos.Rows[nRenglon].Cells[8].Style.ForeColor = System.Drawing.Color.Red;
                        grdDatos.Rows[nRenglon].Cells[8].Style.BackColor = cRojo;
                        grdDatos.Rows[nRenglon].Cells[10].Style.BackColor = cRojo;
                    }
                    else {
                        grdDatos.Rows[nRenglon].Cells[8].Style.ForeColor = System.Drawing.Color.Black;
                    }

                //PRIMER RANGO
                temp = Convert.ToDouble(grdDatos.Rows[nRenglon].Cells[4].Value);
                if (temp > 0) {
                    grdDatos.Rows[nRenglon].Cells[4].Style.BackColor = cRojo;
                }
                //SEGUNDO RANGO
                temp = Convert.ToDouble(grdDatos.Rows[nRenglon].Cells[5].Value);
                if (temp > 0)
                {
                    grdDatos.Rows[nRenglon].Cells[5].Style.BackColor = cAmarillo;
                }
                temp = Convert.ToDouble(grdDatos.Rows[nRenglon].Cells[6].Value);
                if (temp > 0)
                {
                    grdDatos.Rows[nRenglon].Cells[6].Style.BackColor = cAmarillo;
                }
                //ULTIMO RANGO
                temp = Convert.ToDouble(grdDatos.Rows[nRenglon].Cells[7].Value);
                if (temp > 0)
                {
                    grdDatos.Rows[nRenglon].Cells[7].Style.BackColor = cVerde;
                }

                //CENTRADO
                grdDatos.Rows[nRenglon].Cells[4].Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                grdDatos.Rows[nRenglon].Cells[5].Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                grdDatos.Rows[nRenglon].Cells[6].Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                grdDatos.Rows[nRenglon].Cells[7].Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                grdDatos.Rows[nRenglon].Cells[8].Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

                #endregion

                nRenglon++;
            }            
        }

        /*
         * grdPizarra.Rows.Insert(iRenglon, "");
            grdPizarra.Rows[iRenglon].Cells[1].Value = producto.CodigoProducto;
            grdPizarra.Rows[iRenglon].Cells[2].Value = producto.NombreProducto;
            grdPizarra.Rows[iRenglon].Cells[3].Value = producto.Stock.ToString();
         * 
         * 
         * 
            grdPizarra.Rows.Insert(iRenglon, "");
            grdPizarra.Rows[iRenglon].Cells[0].Value = almacen.NombreAlmacen.ToUpper();
            grdPizarra.Rows[iRenglon].Cells[0].ToolTipText = almacen.CodigoAlmacen;
             */


        private void frmPanel_Load(object sender, EventArgs e)
        {
            AcDeBotones();
            InicializarCiadricula();
            var lista = conAlmacen.listarAlmacenes();
            this.cmbAlmacenes.DisplayMember = "CNOMBREALMACEN";
            this.cmbAlmacenes.ValueMember = "CIDALMACEN";
            this.cmbAlmacenes.DataSource = lista;
            AcDeBotones();


        }

        private void frmSync_Click(object sender, EventArgs e)
        {
            Form1 frmSyn = new Form1();
            frmSyn.ShowDialog();
        }




        //FUNCION PARA COPIAR AL PORTA PAPELESEL GRID
        private void UI_GV_CopyData(DataGridView dgvOne)
        {
            if (dgvOne != null)
            {
                StringBuilder Output = new StringBuilder();

                //CellSkippers comes into play with copying cell data in each row.
                List<int> CellSkippers = new List<int>();

                //The first "line" will be the Headers.
                for (int i = 0; i < dgvOne.Columns.Count; i++)
                {
                    if (dgvOne.Columns[i].Visible)
                    {
                        Output.Append(dgvOne.Columns[i].HeaderText + "\t");
                    }
                    else
                    {
                        CellSkippers.Add(i);
                    }
                }

                Output.Append("\n");

                //Generate Cell Value Data
                foreach (DataGridViewRow Row in dgvOne.Rows)
                {
                    //Don't generate a new line at all if Row is not visible
                    if (Row.Visible)
                    {
                        if (CellSkippers.Count != 0)
                        {
                            for (int i = 0; i < Row.Cells.Count; i++)
                            {
                                //Handling the last cell of the line.
                                if (i == (Row.Cells.Count - 1))
                                {
                                    if (CellSkippers.Contains(i))
                                    {
                                        Output.Append("\n");
                                    }
                                    else
                                    {
                                        Output.Append(Row.Cells[i].Value + "\n");
                                    }
                                }
                                else
                                {
                                    //If CellSkippers contains the index value, it means a
                                    //column was hidden and the data should not be saved
                                    //to memory, so skip it!
                                    if (!(CellSkippers.Contains(i)))
                                    {
                                        Output.Append(Row.Cells[i].Value + "\t");
                                    }
                                }
                            }

                        }
                        else
                        {
                            for (int i = 0; i < Row.Cells.Count; i++)
                            {
                                if (i == (Row.Cells.Count - 1))
                                {
                                    Output.Append(Row.Cells[i].Value + "\n");
                                }
                                else
                                {

                                    Output.Append(Row.Cells[i].Value + "\t");
                                }
                            }
                        }
                    }
                }

                System.Windows.Forms.Clipboard.SetText(Output.ToString());
            }
        }

        private void btnCopiar_Click(object sender, EventArgs e)
        {
            if (this.grdDatos.Rows.Count > 1) { 
                this.UI_GV_CopyData(this.grdDatos);
             }
            else {
                MessageBox.Show("Debe seleccionar un Almacen","No hay almacen",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        #region "FUNCIONES CUADRICULA"
        private void AddColumna(int iColumna, int aColumna)
        {
            grdDatos.Columns[iColumna].ReadOnly = true;
            grdDatos.Columns[iColumna].Width = aColumna;
            grdDatos.Columns[iColumna].DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(251, 252, 252);
            grdDatos.Columns[iColumna].Frozen = true;
        }
        private void InicializarCiadricula()
        {
            grdDatos.Rows.Clear();
            grdDatos.Columns.Clear();
            string[] columnas = new string[] { "ALMACEN-100", "CODIGO PRODUCTO-120", "DESCRIPCION-250", "EXISTENCIA TOTAL-100", "RANGO  1 A 7-60", "RANGO  8 A 16-60", "RANGO 17 A 30-60", "RANGO 31 MAS-60", "EXISTENCIA CON CADUCIDAD-85", "COSTO PROMEDIO-80", "PERDIDA-80" };
            int iColumnas = 0;
            DataGridViewTextBoxColumn TextCol;
            foreach (string item in columnas)
            {
                string[] tdatos = item.Split('-');
                TextCol = new DataGridViewTextBoxColumn();
                TextCol.Name = tdatos[0];
                grdDatos.Columns.Insert(iColumnas, TextCol);
                AddColumna(iColumnas, Convert.ToInt32(tdatos[1]));
                iColumnas++;
            }
            nRenglon = 0;
        }

        #endregion

        private void bacAlmacen_DoWork(object sender, DoWorkEventArgs e)
        {
            

        }

        private void bacAlmacen_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            cmbAlmacenes.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (grdDatos.Rows.Count > 1)
            {
                try { 
                    this.UI_GV_CopyData(this.grdDatos);
                    Microsoft.Office.Interop.Excel.Application xlexcel;
                    Microsoft.Office.Interop.Excel.Workbook xlWorkBook;
                    Microsoft.Office.Interop.Excel.Worksheet xlWorkSheet;
                    object valores = System.Reflection.Missing.Value;
                    xlexcel=new Microsoft.Office.Interop.Excel.Application();
                    xlexcel.Visible = true;
                    xlWorkBook = xlexcel.Workbooks.Add(valores);
                    xlWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
                    Microsoft.Office.Interop.Excel.Range cr = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[1, 1];
                    cr.Select();
                    xlWorkSheet.PasteSpecial(cr, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, true);
                    }
                    catch (Exception ex) {

                    }
            }
            else
            {
                MessageBox.Show("Debe seleccionar un Almacen", "No hay almacen", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private StringBuilder DataGridtoHTML(DataGridView dg)
        {
            StringBuilder strB = new StringBuilder();
            //create html & table
            strB.AppendLine("<html><body><center><" +
                          "table border='1' cellpadding='0' cellspacing='0'>");
            strB.AppendLine("<tr>");
            //cteate table header
            for (int i = 0; i < dg.Columns.Count; i++)
            {
                strB.AppendLine("<td align='center' valign='middle'>" +
                               dg.Columns[i].HeaderText + "</td>");
            }
            //create table body
            strB.AppendLine("<tr>");
            for (int i = 0; i < dg.Rows.Count; i++)
            {
                strB.AppendLine("<tr>");
                foreach (DataGridViewCell dgvc in dg.Rows[i].Cells)
                {
                    if (dgvc.Value != null)
                    {
                        strB.AppendLine("<td align='center' valign='middle'>" +
                                    dgvc.Value.ToString() + "</td>");
                    }
                }
                strB.AppendLine("</tr>");

            }
            //table footer & end of html file
            strB.AppendLine("</table></center></body></html>");
            return strB;
        }

        private void btnHtml_Click(object sender, EventArgs e)
        {
            if (grdDatos.Rows.Count > 1)
            {
                StringBuilder tem = DataGridtoHTML(this.grdDatos);
                using (SaveFileDialog dlg = new SaveFileDialog())
                {
                    dlg.Filter = "Data Files (*.html)|*.html";
                    dlg.DefaultExt = "html";
                    dlg.AddExtension = true;
                    if (dlg.ShowDialog() == DialogResult.OK)
                    {
                        string fileName = dlg.FileName;

                        System.IO.TextWriter w = new System.IO.StreamWriter(fileName);
                        w.Write(tem);
                        w.Flush();
                        w.Close();
                    }
                }
            }
            else {
                MessageBox.Show("Debe seleccionar un Almacen","No hay almacen",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }


        public void AcDeBotones() {
            foreach (object obj in this.Controls) {
                if (obj is Button) {
                    Button btn = (Button)obj;
                    btn.Enabled = !btn.Enabled;
                }
            }
        }

        private void btnPdf_Click(object sender, EventArgs e)
        {
            if (this.grdDatos.Rows.Count > 1) {
                SaveFileDialog save = new SaveFileDialog();
                save.Filter = "PDF Files (*.pdf)|*.pdf";
                save.DefaultExt = "pdf";
                save.AddExtension = true;
                save.FileName = "REPORTE-" + System.DateTime.Now.ToString("MMddyy");
                if (save.ShowDialog() == DialogResult.OK) {
                    string filename = save.FileName;
                    Document doc = new Document(PageSize.A3, 9, 9, 9, 9);
                    String Encabezado = "ALMACEN: " + this.cmbAlmacenes.Text + "   FECHA: " + System.DateTime.Now.ToString() +"\n\n";
                    Chunk encab = new Chunk(Encabezado, FontFactory.GetFont("COURIER", 18));
                    try
                    {
                        FileStream file = new FileStream(filename, FileMode.OpenOrCreate);
                        PdfWriter writer = PdfWriter.GetInstance(doc, file);
                        writer.ViewerPreferences = PdfWriter.PageModeUseThumbs;
                        writer.ViewerPreferences = PdfWriter.PageLayoutOneColumn;
                        doc.Open();
                       
                        doc.Add(new Paragraph(encab));
                        GenerarDocumentos(doc);

                        Process.Start(filename);
                        doc.Close();
                    }

                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            } else {
                MessageBox.Show("Debe seleccionar un Almacen", "No hay almacen", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




        public void GenerarDocumentos(Document document)
        {
            //se crea un objeto PdfTable con el numero de columnas del dataGridView 
            PdfPTable datatable = new PdfPTable(grdDatos.ColumnCount);

            //asignamos algunas propiedades para el diseño del pdf  
            datatable.DefaultCell.Padding = 1;
            float[] headerwidths = GetTamañoColumnas(grdDatos);

            datatable.SetWidths(headerwidths);
            datatable.WidthPercentage = 100;
            datatable.DefaultCell.BorderWidth = 1;

            //DEFINIMOS EL COLOR DE LAS CELDAS EN EL PDF 
            datatable.DefaultCell.BackgroundColor = iTextSharp.text.BaseColor.WHITE;

            //DEFINIMOS EL COLOR DE LOS BORDES 
            datatable.DefaultCell.BorderColor = iTextSharp.text.BaseColor.LIGHT_GRAY;

            //LA FUENTE DE NUESTRO TEXTO 
            iTextSharp.text.Font fuente = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.COURIER,8);

            Phrase objP = new Phrase("A", fuente);

            datatable.DefaultCell.HorizontalAlignment = Element.ALIGN_LEFT;
           

            //SE GENERA EL ENCABEZADO DE LA TABLA EN EL PDF  
            for (int i = 0; i < grdDatos.ColumnCount; i++)
            {
                objP = new Phrase(grdDatos.Columns[i].HeaderText, fuente);
                datatable.HorizontalAlignment = Element.ALIGN_CENTER;

                PdfPCell cel = new PdfPCell();
                cel.AddElement(objP);
                cel.Padding = 3;
                cel.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                datatable.AddCell(cel);
            }
            datatable.HeaderRows = 2;

            datatable.DefaultCell.BorderWidth = 1;

            //SE GENERA EL CUERPO DEL PDF 
            for (int i = 0; i < grdDatos.RowCount; i++)
            {
                for (int j = 0; j < grdDatos.ColumnCount; j++)
                {
                    if (grdDatos[j, i].Value != null)
                    {
                        
                        objP = new Phrase(grdDatos[j, i].Value.ToString() , fuente);
                        objP.Font.Color = iTextSharp.text.BaseColor.BLACK;
                        if (j == 8)
                        {
                            double val = Convert.ToDouble(grdDatos[j,i].Value);
                            if (val > 0) {
                                objP.Font.Color = iTextSharp.text.BaseColor.RED;
                            }

                        }
                        
                        PdfPCell cel = new PdfPCell();                        
                        cel.Padding = 3;                        
                        cel.AddElement(objP);
                        datatable.AddCell(cel);
                        
                    }
                }
                datatable.CompleteRow();
            }
            document.Add(datatable);
        }

        //Función que obtiene los tamaños de las columnas del datagridview 
        public float[] GetTamañoColumnas(DataGridView dg)
        {
            //Tomamos el numero de columnas 
            float[] values = new float[dg.ColumnCount];
            for (int i = 0; i < dg.ColumnCount; i++)
            {
                //Tomamos el ancho de cada columna 
                values[i] = (float)dg.Columns[i].Width;
            }
            return values;
        }
    }
}
