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
namespace Reportes
{
    public partial class frmManageAlmacenes : Form
    {

        public static frmManageAlmacenes instancia = null;

        int nRenglon = 0;
        List<admAlmacenes> almacenes;

        public static  frmManageAlmacenes getIntancia() {
            if (instancia == null) {
                instancia = new frmManageAlmacenes();
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

        public frmManageAlmacenes()
        {
            InitializeComponent();
        }

        private void frmManageAlmacenes_Load(object sender, EventArgs e)
        {
            InicializarCiadricula();
            almacenes = conAlmacen.listarAlmacenes();
            DesplegarAlmacenes();

        }


        void DesplegarAlmacenes() {
            foreach (admAlmacenes item in almacenes) {
                grdDatos.Rows.Add(nRenglon, "");
                grdDatos.Rows[nRenglon].Cells[0].Value = item.CCODIGOALMACEN;
                grdDatos.Rows[nRenglon].Cells[0].ToolTipText = item.CIDALMACEN.ToString();
                grdDatos.Rows[nRenglon].Cells[1].Value = item.CNOMBREALMACEN;
                grdDatos.Rows[nRenglon].Cells[2].Value = item.CSTATUS;
                                

                nRenglon++;
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
            string[] columnas = new string[] { "CODIGO-80","NOMBRE-200"};
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
            DataGridViewCheckBoxColumn chk = new DataGridViewCheckBoxColumn();
            grdDatos.Columns.Add(chk);
            chk.HeaderText = "INACTIVO";
            chk.Name = "status";
            nRenglon = 0;
        }

        #endregion

        private void button5_Click(object sender, EventArgs e)
        {
            int x = 0;
            if (MessageBox.Show("¿Quiere guardar los cambios?", "Guardar cambios...", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {
                //foreach (DataGridViewRow item in grdDatos.Rows) {
                for(int indice = 0; indice < grdDatos.Rows.Count; indice++) { 
                    if (grdDatos.Rows[indice].Cells[0].Value != null)
                    {
                        int id = Convert.ToInt32(grdDatos.Rows[indice].Cells[0].ToolTipText);
                        admAlmacenes tAlma = conAlmacen.buscarAlmacen(id);
                        tAlma.CSTATUS = Convert.ToBoolean(grdDatos.Rows[indice].Cells[2].Value);
                        conAlmacen.guardarAlmacen(tAlma);                      
                    }                    
                }
            }
        }
    }
}
