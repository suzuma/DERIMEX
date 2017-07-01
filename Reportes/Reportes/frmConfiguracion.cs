using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
namespace Reportes
{
    public partial class frmConfiguracion : Form
    {
        public frmConfiguracion()
        {
            InitializeComponent();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            DialogResult dial = this.folderBrowserDialog1.ShowDialog();
            if (dial == DialogResult.OK) {
                txtPathAdminpaq.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void frmConfiguracion_Load(object sender, EventArgs e)
        {
            string conectionString = ConfigurationManager.ConnectionStrings["DataModel"].ConnectionString;
            string[] parametros = conectionString.Split(';');
            string[] Valores = parametros[0].Split('=');
            txtHost.Text = Valores[1];

            Valores = parametros[1].Split('=');
            txtUsuario.Text = Valores[1];

            Valores = parametros[2].Split('=');
            txtPassword.Text = Valores[1];

            Valores = parametros[4].Split('=');
            txtBaseDatos.Text = Valores[1];

            //datos ODBC
            txtPathAdminpaq.Text = ConfigurationManager.AppSettings["pathAdminpaq"];

            //hotmail
            string datos = ConfigurationManager.AppSettings["Hotmail"];
            txtUsuarioHotmail.Text = datos.Split(';')[0];
            txtPasswordHotmail.Text = datos.Split(';')[1];
            datos = ConfigurationManager.AppSettings["EmailAdmin"];
            txtEmailAdmin.Text = datos;

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Cualquier cambio en la configuración puede dañar el funcionamiento de la aplicación, ¿desea Guardar los cambios?","Guardando los cambios",MessageBoxButtons.YesNo,MessageBoxIcon.Warning) == DialogResult.Yes) { 

            string cString = "server="+txtHost.Text+";user id="+txtUsuario.Text+";password="+txtPassword.Text+";persistsecurityinfo=true;database="+txtBaseDatos.Text;
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.ConnectionStrings.ConnectionStrings["DataModel"].ConnectionString = cString;

            config.AppSettings.Settings["pathAdminpaq"].Value = txtPathAdminpaq.Text;
            config.AppSettings.Settings["Hotmail"].Value = txtUsuarioHotmail.Text + ";" + txtPasswordHotmail.Text;
            config.AppSettings.Settings["EmailAdmin"].Value = txtPathAdminpaq.Text;

                config.Save(ConfigurationSaveMode.Modified);
                this.Close();
            }
        }
    }
}
