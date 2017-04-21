namespace Reportes
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnSincronizar = new System.Windows.Forms.Button();
            this.proProductos = new System.Windows.Forms.ProgressBar();
            this.proCapasProductos = new System.Windows.Forms.ProgressBar();
            this.lblProductos = new System.Windows.Forms.Label();
            this.lblCapasProductos = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.bakAsincronico = new System.ComponentModel.BackgroundWorker();
            this.btbProductos = new System.Windows.Forms.Button();
            this.btnCapasProductos = new System.Windows.Forms.Button();
            this.bacProductos = new System.ComponentModel.BackgroundWorker();
            this.bacCapasProductos = new System.ComponentModel.BackgroundWorker();
            this.button1 = new System.Windows.Forms.Button();
            this.lblAlmacenes = new System.Windows.Forms.Label();
            this.proAlmacenes = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // btnSincronizar
            // 
            this.btnSincronizar.Location = new System.Drawing.Point(303, 324);
            this.btnSincronizar.Name = "btnSincronizar";
            this.btnSincronizar.Size = new System.Drawing.Size(87, 23);
            this.btnSincronizar.TabIndex = 0;
            this.btnSincronizar.Text = "Sincronizar";
            this.btnSincronizar.UseVisualStyleBackColor = true;
            this.btnSincronizar.Visible = false;
            this.btnSincronizar.Click += new System.EventHandler(this.button1_Click);
            // 
            // proProductos
            // 
            this.proProductos.Location = new System.Drawing.Point(12, 91);
            this.proProductos.Name = "proProductos";
            this.proProductos.Size = new System.Drawing.Size(364, 23);
            this.proProductos.TabIndex = 1;
            // 
            // proCapasProductos
            // 
            this.proCapasProductos.Location = new System.Drawing.Point(12, 137);
            this.proCapasProductos.Name = "proCapasProductos";
            this.proCapasProductos.Size = new System.Drawing.Size(364, 23);
            this.proCapasProductos.TabIndex = 2;
            // 
            // lblProductos
            // 
            this.lblProductos.AutoSize = true;
            this.lblProductos.Location = new System.Drawing.Point(13, 72);
            this.lblProductos.Name = "lblProductos";
            this.lblProductos.Size = new System.Drawing.Size(64, 13);
            this.lblProductos.TabIndex = 4;
            this.lblProductos.Text = "Productos...";
            // 
            // lblCapasProductos
            // 
            this.lblCapasProductos.AutoSize = true;
            this.lblCapasProductos.Location = new System.Drawing.Point(13, 121);
            this.lblCapasProductos.Name = "lblCapasProductos";
            this.lblCapasProductos.Size = new System.Drawing.Size(88, 13);
            this.lblCapasProductos.TabIndex = 5;
            this.lblCapasProductos.Text = "Capas Productos";
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(210, 324);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(87, 23);
            this.btnCancelar.TabIndex = 7;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Visible = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // bakAsincronico
            // 
            this.bakAsincronico.WorkerReportsProgress = true;
            this.bakAsincronico.WorkerSupportsCancellation = true;
            this.bakAsincronico.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bakAsincronico_DoWork);
            this.bakAsincronico.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bakAsincronico_ProgressChanged);
            this.bakAsincronico.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bakAsincronico_RunWorkerCompleted);
            // 
            // btbProductos
            // 
            this.btbProductos.Location = new System.Drawing.Point(382, 91);
            this.btbProductos.Name = "btbProductos";
            this.btbProductos.Size = new System.Drawing.Size(87, 23);
            this.btbProductos.TabIndex = 8;
            this.btbProductos.Text = "Sincronizar";
            this.btbProductos.UseVisualStyleBackColor = true;
            this.btbProductos.Click += new System.EventHandler(this.btbProductos_Click);
            // 
            // btnCapasProductos
            // 
            this.btnCapasProductos.Location = new System.Drawing.Point(382, 137);
            this.btnCapasProductos.Name = "btnCapasProductos";
            this.btnCapasProductos.Size = new System.Drawing.Size(87, 23);
            this.btnCapasProductos.TabIndex = 9;
            this.btnCapasProductos.Text = "Sincronizar";
            this.btnCapasProductos.UseVisualStyleBackColor = true;
            this.btnCapasProductos.Click += new System.EventHandler(this.btnCapasProductos_Click);
            // 
            // bacProductos
            // 
            this.bacProductos.WorkerReportsProgress = true;
            this.bacProductos.WorkerSupportsCancellation = true;
            this.bacProductos.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bacProductos_DoWork);
            this.bacProductos.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bacProductos_ProgressChanged);
            // 
            // bacCapasProductos
            // 
            this.bacCapasProductos.WorkerReportsProgress = true;
            this.bacCapasProductos.WorkerSupportsCancellation = true;
            this.bacCapasProductos.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bacCapasProductos_DoWork);
            this.bacCapasProductos.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bacCapasProductos_ProgressChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(382, 46);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(87, 23);
            this.button1.TabIndex = 13;
            this.button1.Text = "Sincronizar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // lblAlmacenes
            // 
            this.lblAlmacenes.AutoSize = true;
            this.lblAlmacenes.Location = new System.Drawing.Point(13, 27);
            this.lblAlmacenes.Name = "lblAlmacenes";
            this.lblAlmacenes.Size = new System.Drawing.Size(68, 13);
            this.lblAlmacenes.TabIndex = 12;
            this.lblAlmacenes.Text = "Almacenes...";
            // 
            // proAlmacenes
            // 
            this.proAlmacenes.Location = new System.Drawing.Point(12, 46);
            this.proAlmacenes.Name = "proAlmacenes";
            this.proAlmacenes.Size = new System.Drawing.Size(364, 23);
            this.proAlmacenes.TabIndex = 11;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(480, 193);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lblAlmacenes);
            this.Controls.Add(this.proAlmacenes);
            this.Controls.Add(this.btnCapasProductos);
            this.Controls.Add(this.btbProductos);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.lblCapasProductos);
            this.Controls.Add(this.lblProductos);
            this.Controls.Add(this.proCapasProductos);
            this.Controls.Add(this.proProductos);
            this.Controls.Add(this.btnSincronizar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sincronizando...";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSincronizar;
        private System.Windows.Forms.ProgressBar proProductos;
        private System.Windows.Forms.ProgressBar proCapasProductos;
        private System.Windows.Forms.Label lblProductos;
        private System.Windows.Forms.Label lblCapasProductos;
        private System.Windows.Forms.Button btnCancelar;
        private System.ComponentModel.BackgroundWorker bakAsincronico;
        private System.Windows.Forms.Button btbProductos;
        private System.Windows.Forms.Button btnCapasProductos;
        private System.ComponentModel.BackgroundWorker bacProductos;
        private System.ComponentModel.BackgroundWorker bacCapasProductos;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lblAlmacenes;
        private System.Windows.Forms.ProgressBar proAlmacenes;
    }
}

