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
    public partial class Form1 : Form
    {
        Boolean tAlmacen = false;
        Boolean tProductos = false;
        Boolean tMovimientos = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //HtaMigracion.CargarCapasProducto();

            this.btnCancelar.Enabled = false;
            this.btnSincronizar.Enabled = false;
            this.bakAsincronico.RunWorkerAsync();                
        }

        private void bakAsincronico_DoWork(object sender, DoWorkEventArgs e)
        {

            HtaMigracion.CargarAlmacenes(this.bakAsincronico);
            //HtaMigracion.CargarCapasProducto();
            //HtaMigracion.CargarAlmacenes();
            //HtaMigracion.CargarProductos();
            //HtaMigracion.CargarExistencia();
            //HtaMigracion.CargarMovimientoSerie();
            //HtaMigracion.CargarNumeroSerie();
            //HtaMigracion.CargarMovimientoCapas();

        }

        private void bakAsincronico_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.btnCancelar.Enabled = true;
            this.btnSincronizar.Enabled = true;
        }

        private void btbProductos_Click(object sender, EventArgs e)
        {
            HtaMigracion.llenarDatosProductos();
            this.proProductos.Minimum = 0;
            this.proProductos.Maximum = HtaMigracion.tDatos.Rows.Count;
            this.bacProductos.RunWorkerAsync();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            HtaMigracion.llenarDatosAlmacenes();
            this.proAlmacenes.Minimum = 0;
            this.proAlmacenes.Maximum = HtaMigracion.tDatos.Rows.Count;
            this.bakAsincronico.RunWorkerAsync();
        }

        private void bakAsincronico_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            proAlmacenes.Value = e.ProgressPercentage;
            double por = (e.ProgressPercentage * 100) / HtaMigracion.tDatos.Rows.Count;
            lblAlmacenes.Text = "Almacenes... [ " + por.ToString() + "% ]";
        }

        private void bacProductos_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            proProductos.Value = e.ProgressPercentage;
            double por=(e.ProgressPercentage*100)/ HtaMigracion.tDatos.Rows.Count;
            lblProductos.Text = "Productos... [ " + por.ToString() + "% ]";
        }

        private void bacProductos_DoWork(object sender, DoWorkEventArgs e)
        {
            HtaMigracion.CargarProductos(this.bacProductos);
        }

        private void btnCapasProductos_Click(object sender, EventArgs e)
        {
            HtaMigracion.llenarDatosCapasProducto();
            this.proCapasProductos.Minimum = 0;
            this.proCapasProductos.Maximum = HtaMigracion.tDatos.Rows.Count;
            bacCapasProductos.RunWorkerAsync();
        }

        private void bacCapasProductos_DoWork(object sender, DoWorkEventArgs e)
        {
          
            HtaMigracion.CargarCapasProducto(this.bacCapasProductos);
        }

        private void bacCapasProductos_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            proCapasProductos.Value = e.ProgressPercentage;
            double por = (e.ProgressPercentage * 100) / HtaMigracion.tDatos.Rows.Count;
            lblCapasProductos.Text = "Capas Productos... [ " + por.ToString() + "% ]";
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {

        }
    }
}
