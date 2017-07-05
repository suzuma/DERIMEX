namespace Reportes
{
    partial class frmPanel
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPanel));
            this.grdDatos = new System.Windows.Forms.DataGridView();
            this.cmbAlmacenes = new System.Windows.Forms.ComboBox();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.bacAlmacen = new System.ComponentModel.BackgroundWorker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button6 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.btnUsuarios = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.frmSync = new System.Windows.Forms.Button();
            this.btnHtml = new System.Windows.Forms.Button();
            this.btnCopiar = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.grdDatos)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grdDatos
            // 
            this.grdDatos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdDatos.Location = new System.Drawing.Point(12, 94);
            this.grdDatos.Name = "grdDatos";
            this.grdDatos.Size = new System.Drawing.Size(1221, 344);
            this.grdDatos.TabIndex = 0;
            this.grdDatos.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdDatos_CellContentDoubleClick);
            // 
            // cmbAlmacenes
            // 
            this.cmbAlmacenes.Enabled = false;
            this.cmbAlmacenes.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbAlmacenes.FormattingEnabled = true;
            this.cmbAlmacenes.Location = new System.Drawing.Point(6, 54);
            this.cmbAlmacenes.Name = "cmbAlmacenes";
            this.cmbAlmacenes.Size = new System.Drawing.Size(305, 28);
            this.cmbAlmacenes.TabIndex = 2;
            this.cmbAlmacenes.SelectedIndexChanged += new System.EventHandler(this.cmbAlmacenes_SelectedIndexChanged);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "1498696720_sync.png");
            this.imageList1.Images.SetKeyName(1, "1498696804_BT_copy.png");
            this.imageList1.Images.SetKeyName(2, "1498696784_excel.png");
            this.imageList1.Images.SetKeyName(3, "1498696835_38.png");
            this.imageList1.Images.SetKeyName(4, "1498698707_pdf.png");
            this.imageList1.Images.SetKeyName(5, "1498774299_mail-send-receive.png");
            this.imageList1.Images.SetKeyName(6, "1498776018_mypc_config.png");
            this.imageList1.Images.SetKeyName(7, "1498776186_admin.png");
            this.imageList1.Images.SetKeyName(8, "1498786897_simpline_43.png");
            this.imageList1.Images.SetKeyName(9, "1498864449_20_-_Home.png");
            // 
            // bacAlmacen
            // 
            this.bacAlmacen.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bacAlmacen_DoWork);
            this.bacAlmacen.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bacAlmacen_ProgressChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.button6);
            this.groupBox1.Controls.Add(this.button5);
            this.groupBox1.Controls.Add(this.button4);
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.btnUsuarios);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.frmSync);
            this.groupBox1.Controls.Add(this.cmbAlmacenes);
            this.groupBox1.Controls.Add(this.btnHtml);
            this.groupBox1.Controls.Add(this.btnCopiar);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Location = new System.Drawing.Point(13, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1220, 85);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            // 
            // button6
            // 
            this.button6.Enabled = false;
            this.button6.ImageIndex = 9;
            this.button6.ImageList = this.imageList1;
            this.button6.Location = new System.Drawing.Point(379, 12);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(71, 67);
            this.button6.TabIndex = 13;
            this.button6.Tag = "9";
            this.button6.Text = "Almacenes";
            this.button6.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button5
            // 
            this.button5.Enabled = false;
            this.button5.ImageIndex = 8;
            this.button5.ImageList = this.imageList1;
            this.button5.Location = new System.Drawing.Point(323, 12);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(50, 67);
            this.button5.TabIndex = 12;
            this.button5.Tag = "0";
            this.button5.Text = "Salir";
            this.button5.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button4
            // 
            this.button4.Enabled = false;
            this.button4.ImageIndex = 7;
            this.button4.ImageList = this.imageList1;
            this.button4.Location = new System.Drawing.Point(450, 12);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(71, 67);
            this.button4.TabIndex = 11;
            this.button4.Tag = "8";
            this.button4.Text = "Usuarios";
            this.button4.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.Enabled = false;
            this.button3.ImageIndex = 6;
            this.button3.ImageList = this.imageList1;
            this.button3.Location = new System.Drawing.Point(521, 13);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(71, 67);
            this.button3.TabIndex = 10;
            this.button3.Tag = "7";
            this.button3.Text = "Sistema";
            this.button3.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Enabled = false;
            this.button2.ImageIndex = 5;
            this.button2.ImageList = this.imageList1;
            this.button2.Location = new System.Drawing.Point(592, 12);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(71, 67);
            this.button2.TabIndex = 9;
            this.button2.Tag = "6";
            this.button2.Text = "Correo";
            this.button2.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnUsuarios
            // 
            this.btnUsuarios.Enabled = false;
            this.btnUsuarios.ImageIndex = 4;
            this.btnUsuarios.ImageList = this.imageList1;
            this.btnUsuarios.Location = new System.Drawing.Point(663, 12);
            this.btnUsuarios.Name = "btnUsuarios";
            this.btnUsuarios.Size = new System.Drawing.Size(71, 67);
            this.btnUsuarios.TabIndex = 8;
            this.btnUsuarios.Tag = "5";
            this.btnUsuarios.Text = "pdf";
            this.btnUsuarios.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnUsuarios.UseVisualStyleBackColor = true;
            this.btnUsuarios.Click += new System.EventHandler(this.btnPdf_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(10, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 20);
            this.label1.TabIndex = 7;
            this.label1.Text = "ALMACEN:";
            // 
            // frmSync
            // 
            this.frmSync.Enabled = false;
            this.frmSync.ImageIndex = 0;
            this.frmSync.ImageList = this.imageList1;
            this.frmSync.Location = new System.Drawing.Point(947, 12);
            this.frmSync.Name = "frmSync";
            this.frmSync.Size = new System.Drawing.Size(71, 67);
            this.frmSync.TabIndex = 3;
            this.frmSync.Tag = "1";
            this.frmSync.Text = "Sincronizar";
            this.frmSync.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.frmSync.UseVisualStyleBackColor = true;
            this.frmSync.Click += new System.EventHandler(this.frmSync_Click);
            // 
            // btnHtml
            // 
            this.btnHtml.Enabled = false;
            this.btnHtml.ImageIndex = 3;
            this.btnHtml.ImageList = this.imageList1;
            this.btnHtml.Location = new System.Drawing.Point(734, 12);
            this.btnHtml.Name = "btnHtml";
            this.btnHtml.Size = new System.Drawing.Size(71, 67);
            this.btnHtml.TabIndex = 6;
            this.btnHtml.Tag = "4";
            this.btnHtml.Text = "html";
            this.btnHtml.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnHtml.UseVisualStyleBackColor = true;
            this.btnHtml.Click += new System.EventHandler(this.btnHtml_Click);
            // 
            // btnCopiar
            // 
            this.btnCopiar.Enabled = false;
            this.btnCopiar.ImageIndex = 1;
            this.btnCopiar.ImageList = this.imageList1;
            this.btnCopiar.Location = new System.Drawing.Point(876, 12);
            this.btnCopiar.Name = "btnCopiar";
            this.btnCopiar.Size = new System.Drawing.Size(71, 67);
            this.btnCopiar.TabIndex = 4;
            this.btnCopiar.Tag = "2";
            this.btnCopiar.Text = "Copiar";
            this.btnCopiar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCopiar.UseVisualStyleBackColor = true;
            this.btnCopiar.Click += new System.EventHandler(this.btnCopiar_Click);
            // 
            // button1
            // 
            this.button1.Enabled = false;
            this.button1.ImageIndex = 2;
            this.button1.ImageList = this.imageList1;
            this.button1.Location = new System.Drawing.Point(805, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(71, 67);
            this.button1.TabIndex = 5;
            this.button1.Tag = "3";
            this.button1.Text = "Excel";
            this.button1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // frmPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1245, 442);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.grdDatos);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmPanel";
            this.Text = "Panel de Control";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmPanel_Load);
            this.Enter += new System.EventHandler(this.frmPanel_Enter);
            ((System.ComponentModel.ISupportInitialize)(this.grdDatos)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView grdDatos;
        private System.Windows.Forms.ComboBox cmbAlmacenes;
        private System.Windows.Forms.Button frmSync;
        private System.Windows.Forms.Button btnCopiar;
        private System.ComponentModel.BackgroundWorker bacAlmacen;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnHtml;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnUsuarios;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
    }
}