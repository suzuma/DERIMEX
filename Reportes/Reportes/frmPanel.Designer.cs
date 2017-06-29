namespace Reportes
{
    partial class btnExcel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(btnExcel));
            this.grdDatos = new System.Windows.Forms.DataGridView();
            this.cmbAlmacenes = new System.Windows.Forms.ComboBox();
            this.frmSync = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.btnCopiar = new System.Windows.Forms.Button();
            this.bacAlmacen = new System.ComponentModel.BackgroundWorker();
            this.button1 = new System.Windows.Forms.Button();
            this.btnHtml = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnPdf = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
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
            this.grdDatos.RowHeadersVisible = false;
            this.grdDatos.Size = new System.Drawing.Size(1147, 344);
            this.grdDatos.TabIndex = 0;
            // 
            // cmbAlmacenes
            // 
            this.cmbAlmacenes.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbAlmacenes.FormattingEnabled = true;
            this.cmbAlmacenes.Location = new System.Drawing.Point(6, 54);
            this.cmbAlmacenes.Name = "cmbAlmacenes";
            this.cmbAlmacenes.Size = new System.Drawing.Size(369, 28);
            this.cmbAlmacenes.TabIndex = 2;
            this.cmbAlmacenes.SelectedIndexChanged += new System.EventHandler(this.cmbAlmacenes_SelectedIndexChanged);
            // 
            // frmSync
            // 
            this.frmSync.ImageIndex = 0;
            this.frmSync.ImageList = this.imageList1;
            this.frmSync.Location = new System.Drawing.Point(1065, 14);
            this.frmSync.Name = "frmSync";
            this.frmSync.Size = new System.Drawing.Size(75, 65);
            this.frmSync.TabIndex = 3;
            this.frmSync.Text = "Sincronizar";
            this.frmSync.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.frmSync.UseVisualStyleBackColor = true;
            this.frmSync.Click += new System.EventHandler(this.frmSync_Click);
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
            // 
            // btnCopiar
            // 
            this.btnCopiar.ImageIndex = 1;
            this.btnCopiar.ImageList = this.imageList1;
            this.btnCopiar.Location = new System.Drawing.Point(984, 14);
            this.btnCopiar.Name = "btnCopiar";
            this.btnCopiar.Size = new System.Drawing.Size(75, 65);
            this.btnCopiar.TabIndex = 4;
            this.btnCopiar.Text = "Copiar";
            this.btnCopiar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCopiar.UseVisualStyleBackColor = true;
            this.btnCopiar.Click += new System.EventHandler(this.btnCopiar_Click);
            // 
            // bacAlmacen
            // 
            this.bacAlmacen.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bacAlmacen_DoWork);
            this.bacAlmacen.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bacAlmacen_ProgressChanged);
            // 
            // button1
            // 
            this.button1.ImageIndex = 2;
            this.button1.ImageList = this.imageList1;
            this.button1.Location = new System.Drawing.Point(903, 14);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 65);
            this.button1.TabIndex = 5;
            this.button1.Text = "Excel";
            this.button1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnHtml
            // 
            this.btnHtml.ImageIndex = 3;
            this.btnHtml.ImageList = this.imageList1;
            this.btnHtml.Location = new System.Drawing.Point(822, 14);
            this.btnHtml.Name = "btnHtml";
            this.btnHtml.Size = new System.Drawing.Size(75, 65);
            this.btnHtml.TabIndex = 6;
            this.btnHtml.Text = "html";
            this.btnHtml.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnHtml.UseVisualStyleBackColor = true;
            this.btnHtml.Click += new System.EventHandler(this.btnHtml_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.btnPdf);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.frmSync);
            this.groupBox1.Controls.Add(this.cmbAlmacenes);
            this.groupBox1.Controls.Add(this.btnHtml);
            this.groupBox1.Controls.Add(this.btnCopiar);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Location = new System.Drawing.Point(13, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1146, 85);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            // 
            // btnPdf
            // 
            this.btnPdf.ImageIndex = 4;
            this.btnPdf.ImageList = this.imageList1;
            this.btnPdf.Location = new System.Drawing.Point(741, 14);
            this.btnPdf.Name = "btnPdf";
            this.btnPdf.Size = new System.Drawing.Size(75, 65);
            this.btnPdf.TabIndex = 8;
            this.btnPdf.Text = "pdf";
            this.btnPdf.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnPdf.UseVisualStyleBackColor = true;
            this.btnPdf.Click += new System.EventHandler(this.btnPdf_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(7, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 20);
            this.label1.TabIndex = 7;
            this.label1.Text = "ALMACEN:";
            // 
            // btnExcel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1171, 442);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.grdDatos);
            this.Name = "btnExcel";
            this.Text = "frmPanel";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmPanel_Load);
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
        private System.Windows.Forms.Button btnPdf;
    }
}