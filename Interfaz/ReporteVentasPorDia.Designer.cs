
namespace SIVARS_BURGUERS.Interfaz
{
    partial class frmVentasPorDia
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmVentasPorDia));
            this.viewVentasPorDia = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.label1 = new System.Windows.Forms.Label();
            this.txtFecha = new System.Windows.Forms.TextBox();
            this.btnGenerar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // viewVentasPorDia
            // 
            this.viewVentasPorDia.ActiveViewIndex = 0;
            this.viewVentasPorDia.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.viewVentasPorDia.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.viewVentasPorDia.Cursor = System.Windows.Forms.Cursors.Default;
            this.viewVentasPorDia.DisplayStatusBar = false;
            this.viewVentasPorDia.Location = new System.Drawing.Point(-4, 120);
            this.viewVentasPorDia.Name = "viewVentasPorDia";
            this.viewVentasPorDia.ReportSource = "C:\\Users\\Antonio Pasasin\\Documents\\GitHub\\SISTEMA-DE-COMIDA-RAPIDA-ITCA\\Reportes\\" +
    "rptVentasPorDia.rpt";
            this.viewVentasPorDia.ShowCloseButton = false;
            this.viewVentasPorDia.ShowCopyButton = false;
            this.viewVentasPorDia.ShowGotoPageButton = false;
            this.viewVentasPorDia.ShowGroupTreeButton = false;
            this.viewVentasPorDia.ShowLogo = false;
            this.viewVentasPorDia.ShowParameterPanelButton = false;
            this.viewVentasPorDia.ShowRefreshButton = false;
            this.viewVentasPorDia.ShowTextSearchButton = false;
            this.viewVentasPorDia.Size = new System.Drawing.Size(745, 487);
            this.viewVentasPorDia.TabIndex = 0;
            this.viewVentasPorDia.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(192, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 19);
            this.label1.TabIndex = 1;
            this.label1.Text = "Fecha:";
            // 
            // txtFecha
            // 
            this.txtFecha.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtFecha.Location = new System.Drawing.Point(246, 47);
            this.txtFecha.Name = "txtFecha";
            this.txtFecha.Size = new System.Drawing.Size(100, 20);
            this.txtFecha.TabIndex = 2;
            this.txtFecha.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnGenerar
            // 
            this.btnGenerar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnGenerar.BackColor = System.Drawing.Color.Blue;
            this.btnGenerar.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerar.ForeColor = System.Drawing.Color.White;
            this.btnGenerar.Image = ((System.Drawing.Image)(resources.GetObject("btnGenerar.Image")));
            this.btnGenerar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGenerar.Location = new System.Drawing.Point(382, 32);
            this.btnGenerar.Name = "btnGenerar";
            this.btnGenerar.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.btnGenerar.Size = new System.Drawing.Size(168, 49);
            this.btnGenerar.TabIndex = 3;
            this.btnGenerar.Text = "Crear Reporte";
            this.btnGenerar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGenerar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnGenerar.UseVisualStyleBackColor = false;
            this.btnGenerar.Click += new System.EventHandler(this.btnGenerar_Click);
            // 
            // frmVentasPorDia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(743, 611);
            this.Controls.Add(this.btnGenerar);
            this.Controls.Add(this.txtFecha);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.viewVentasPorDia);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmVentasPorDia";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Reporte";
            this.Load += new System.EventHandler(this.ReporteVentasPorDia_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer viewVentasPorDia;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtFecha;
        private System.Windows.Forms.Button btnGenerar;
    }
}