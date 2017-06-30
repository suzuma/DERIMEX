namespace Reportes
{
    partial class frmLotesCaducados
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLotesCaducados));
            this.grdDatos = new System.Windows.Forms.DataGridView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnCopiar = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.grdDatos)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grdDatos
            // 
            this.grdDatos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdDatos.Location = new System.Drawing.Point(12, 110);
            this.grdDatos.Name = "grdDatos";
            this.grdDatos.RowHeadersVisible = false;
            this.grdDatos.Size = new System.Drawing.Size(795, 374);
            this.grdDatos.TabIndex = 0;
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
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnCopiar);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Location = new System.Drawing.Point(14, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(792, 91);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // btnCopiar
            // 
            this.btnCopiar.ImageIndex = 1;
            this.btnCopiar.ImageList = this.imageList1;
            this.btnCopiar.Location = new System.Drawing.Point(702, 18);
            this.btnCopiar.Name = "btnCopiar";
            this.btnCopiar.Size = new System.Drawing.Size(75, 65);
            this.btnCopiar.TabIndex = 6;
            this.btnCopiar.Tag = "2";
            this.btnCopiar.Text = "Copiar";
            this.btnCopiar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCopiar.UseVisualStyleBackColor = true;
            this.btnCopiar.Click += new System.EventHandler(this.btnCopiar_Click);
            // 
            // button1
            // 
            this.button1.ImageIndex = 2;
            this.button1.ImageList = this.imageList1;
            this.button1.Location = new System.Drawing.Point(621, 18);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 65);
            this.button1.TabIndex = 7;
            this.button1.Tag = "3";
            this.button1.Text = "Excel";
            this.button1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // frmLotesCaducados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(819, 496);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.grdDatos);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmLotesCaducados";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Detalle de Producto...";
            this.Load += new System.EventHandler(this.frmLotesCaducados_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdDatos)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView grdDatos;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnCopiar;
        private System.Windows.Forms.Button button1;
    }
}