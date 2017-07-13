using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Reportes
{
    public partial class frmFiltrar : Form
    {
        private static frmFiltrar instancia = null;
        frmPanel pMain;
        public frmFiltrar( frmPanel Main)
        {
            InitializeComponent();
            pMain = Main;
        }

        public static frmFiltrar getIntancia(frmPanel tVentana)
        {
            if (instancia == null)
            {
                instancia = new frmFiltrar(tVentana);
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

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            using(new Tools.CursorWait()) { 
               lblTotal.Text=  pMain.BuscarProducto(txtCodigo.Text).ToString();
            }
        }

        private void txtCodigo_TextChanged(object sender, EventArgs e)
        {
            if (chkContinuo.Checked) {
                using (new Tools.CursorWait())
                {
                    lblTotal.Text = pMain.BuscarProducto(txtCodigo.Text.ToUpper()).ToString();
                }
            }
        }
    }
}
