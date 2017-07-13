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

using Reportes.Tools;
namespace Reportes
{
    public partial class frmLotesCaducados : Form
    {
        private static frmLotesCaducados instancia = null;
        admAlmacenes almacen;
        int tIdProducto;
        admProductos tProducto;
        int nRenglon = 0;

        public static frmLotesCaducados getIntancia(admAlmacenes talmacen, int idProducto) {
            if (instancia == null) {
                instancia = new frmLotesCaducados(talmacen, idProducto);
            }
            return instancia;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
            instancia = null;
        }

        public frmLotesCaducados(admAlmacenes tAlmacen, int idProducto)
        {
            InitializeComponent();
            almacen = tAlmacen;
            this.tIdProducto = idProducto;            
        }

        private void frmLotesCaducados_Load(object sender, EventArgs e)
        {
            if (grdDatos.Rows.Count > 1)
            {
               // cargarDatos(talmacen, idProducto);
            }

        }

        public void cargarDatos(admAlmacenes talmacen, int idProducto)
        {
            InicializarCiadricula();
            grdDatos.Rows.Clear();
            grdDatos.Rows.Add(nRenglon, "");

            grdDatos.Rows[nRenglon].Cells[0].Value = almacen.CNOMBREALMACEN;
            nRenglon++;
            List<admCapasProducto> lProductosCaducos;
            tProducto = almacen.listarProductos().Where(c => c.CIDPRODUCTO == idProducto).FirstOrDefault();
            if (tProducto != null)
            {
                lProductosCaducos = tProducto.listarLotesCaducos(almacen.CIDALMACEN)
                    .Where(c => c.CIDPRODUCTO == idProducto).ToList();
                DesplegarLista(lProductosCaducos);
            }
            lProductosCaducos = tProducto.listarLotesSinCaducar(almacen.CIDALMACEN)
                .Where(c => c.CIDPRODUCTO == idProducto).ToList();
            DesplegarLista(lProductosCaducos, false);
        }

        private void AddColumna(int iColumna, int aColumna)
        {
            grdDatos.Columns[iColumna].ReadOnly = true;
            grdDatos.Columns[iColumna].Width = aColumna;
            grdDatos.Columns[iColumna].DefaultCellStyle.BackColor = frmPanel.cBlanco;
            grdDatos.Columns[iColumna].Frozen = true;
        }
        private void InicializarCiadricula()
        {
            grdDatos.Rows.Clear();
            grdDatos.Columns.Clear();
            string[] columnas = new string[] { "CODIGO-100","NOMBRE-250","EXISTENCIA-80","NUM. LOTE-150","FECHA DE CADUCIDAD-150" };
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

        private void DesplegarLista(List<admCapasProducto> lProductos,Boolean esCaduco=true) {
            try {
            foreach (admCapasProducto item in lProductos) {
                
                grdDatos.Rows.Insert(nRenglon, "");
                grdDatos.Rows[nRenglon].Cells[0].Value =item.admProductos.CCODIGOPRODUCTO.ToString();
                grdDatos.Rows[nRenglon].Cells[1].Value = item.admProductos.CNOMBREPRODUCTO.ToString();
                grdDatos.Rows[nRenglon].Cells[2].Value = item.CEXISTENCIA.ToString();
                grdDatos.Rows[nRenglon].Cells[3].Value = item.CNUMEROLOTE.ToString();
                grdDatos.Rows[nRenglon].Cells[4].Value = item.CFECHACADUCIDAD.ToString();

                if (esCaduco)
                {
                    grdDatos.Rows[nRenglon].DefaultCellStyle.BackColor = frmPanel.cRojo;
                }
                else {
                    grdDatos.Rows[nRenglon].DefaultCellStyle.BackColor = frmPanel.cBlanco;
                }                
                nRenglon++;
            }
            }
            catch (Exception ex)
            {
                int x = 0;
            }
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
            try {
                using (new CursorWait())
                {
                    UI_GV_CopyData(grdDatos);
                }
            }
            catch (Exception ex)
            {
                ELog.save("ERROR AL COPIAR EN CADUCOS", ex);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (grdDatos.Rows.Count > 1)
            {
                try
                {
                    using(new CursorWait()) { 
                        this.UI_GV_CopyData(this.grdDatos);
                        Microsoft.Office.Interop.Excel.Application xlexcel;
                        Microsoft.Office.Interop.Excel.Workbook xlWorkBook;
                        Microsoft.Office.Interop.Excel.Worksheet xlWorkSheet;
                        object valores = System.Reflection.Missing.Value;
                        xlexcel = new Microsoft.Office.Interop.Excel.Application();
                        xlexcel.Visible = true;
                        xlWorkBook = xlexcel.Workbooks.Add(valores);
                        xlWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
                        Microsoft.Office.Interop.Excel.Range cr = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[1, 1];
                        cr.Select();
                        xlWorkSheet.PasteSpecial(cr, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, true);
                    }
                }
                catch (Exception ex)
                {
                    ELog.save("ERRO AL ENVIAR A EXCEL CADUCOS", ex);
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar un Almacen", "No hay almacen", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
