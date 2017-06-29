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
    public partial class frmAutentificar : Form
    {
        frmPanel vPadre;
        public frmAutentificar(frmPanel padre)
        {
            InitializeComponent();
            vPadre = padre;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            conUsuarios.uAutentificado = null;
            this.Close();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            if (conUsuarios.autentificar(txtEmail.Text, txtPassword.Text))
            {
                this.vPadre.CargarPermisos();
                this.Close();
            }
            else {
                MessageBox.Show("Datos incorrectos","Autentificando...",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
    }
}
