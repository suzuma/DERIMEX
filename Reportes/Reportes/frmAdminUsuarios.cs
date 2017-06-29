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
    public partial class frmAdminUsuarios : Form
    {
        public void cargarDatos() {
            this.grdDatos.DataSource = conUsuarios.listar();
        }
        
        public frmAdminUsuarios()
        {
            InitializeComponent();
            grdDatos.AutoGenerateColumns = false;
        }

        private void frmAdminUsuarios_Load(object sender, EventArgs e)
        {
            cargarDatos();
        }

        private void grdDatos_DataSourceChanged(object sender, EventArgs e)
        {
            this.label1.Text = "Registros: " + this.grdDatos.Rows.Count.ToString();
        }

        private void txtFiltro_TextChanged(object sender, EventArgs e)
        {
            this.grdDatos.DataSource=conUsuarios.filtrarNombre(txtFiltro.Text);
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            frmNuevoUsuario nUsuario = new frmNuevoUsuario(this);
            nUsuario.ShowDialog();
        }
    }
}
