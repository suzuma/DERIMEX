﻿using System;

using System.Windows.Forms;
using System.Text.RegularExpressions;
using Reportes.Modelo;
namespace Reportes
{
    public partial class frmNuevoUsuario : Form
    {
        bool invalid = false;
        frmAdminUsuarios vPadre;
        public frmNuevoUsuario(frmAdminUsuarios padre)
        {
            InitializeComponent();
            this.vPadre = padre;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Quiere salir de la ventana?","Usuarios...",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes) {
                this.Close();
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (conUsuarios.existeMail(txtEmail.Text)) {
                MessageBox.Show("Esta dirección no puede ser utilizada", "Nuevo usaurio", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtEmail.Focus();
            } else { 

            if (txtPassword.Text.Equals(txtPassword2.Text))
            {
                this.errorProvider1.SetError(txtPassword, "");
                if (this.IsValidEmail(txtEmail.Text))
                {
                    this.errorProvider1.SetError(txtEmail, "");
                    Usuario nUsuario = new Usuario();
                    nUsuario.nombre = txtNombre.Text.ToUpper();
                    nUsuario.usuario = txtEmail.Text.ToUpper();
                    nUsuario.password = Tools.Seguridad.GetMD5(txtPassword.Text);
                    nUsuario.rol = conUsuarios.buscarRol(3);
                    conUsuarios.guardar(nUsuario);
                    vPadre.cargarDatos();
                    this.Close();                    
                }
                else {
                    this.errorProvider1.SetError(txtEmail, "Email no tiene el formato correcto");
                }
            }
            else
            {
                this.errorProvider1.SetError(txtPassword, "Clave de acceso no son iguales..");
            }
            }
        }


         public bool IsValidEmail(string strIn)
            {
            bool valido = false;
                System.Text.RegularExpressions.Regex rEmail = new System.Text.RegularExpressions.Regex(@"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$");

                if (strIn.Length > 0 && strIn.Trim().Length != 0)
                {
                    if (!rEmail.IsMatch(strIn.Trim()))
                    {
                    valido= true;
                    }

            }
            return valido;
            }
    
    }
}