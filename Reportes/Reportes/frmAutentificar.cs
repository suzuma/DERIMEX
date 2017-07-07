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
    public partial class frmAutentificar : Form
    {
        private static frmAutentificar instancia = null;
        frmPanel vPadre;

        public static frmAutentificar getIntancia(frmPanel padre) {
            if (instancia == null) {
                instancia = new frmAutentificar(padre);
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
            using(new CursorWait()) { 
                ErrorProvider ep = new ErrorProvider();
                if (txtPassword.Text.Length <= 0) {

                    ep.SetError(label2, "Debe ingresar una clave de acceso");
                } else {
                    ep.SetError(label2, "");
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

        private void txtEmail_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                ErrorProvider ep = new ErrorProvider();
                if (txtEmail.Text.Length <= 0)
                {
                    ep.SetError(label1, "Debe ingresar una direccion de correo");
                }
                else {
                    ep.SetError(label1, "");
                    txtPassword.Focus();
                }
            }
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                btnIngresar.Focus();
            }
        }
    }
}
