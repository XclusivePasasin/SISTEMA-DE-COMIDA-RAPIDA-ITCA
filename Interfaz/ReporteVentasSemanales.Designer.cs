
namespace SIVARS_BURGUERS.Interfaz
{
    partial class frmReporteVentasSemanales
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReporteVentasSemanales));
            this.viewVentasSemanales = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.label1 = new System.Windows.Forms.Label();
            this.txtFechaInicio = new System.Windows.Forms.TextBox();
            this.btnGenerar = new System.Windows.Forms.Button();
            this.txtFechaFinal = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // viewVentasSemanales
            // 
            this.viewVentasSemanales.ActiveViewIndex = 0;
            this.viewVentasSemanales.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.viewVentasSemanales.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.viewVentasSemanales.Cursor = System.Windows.Forms.Cursors.Default;
            this.viewVentasSemanales.DisplayStatusBar = false;
            this.viewVentasSemanales.Location = new System.Drawing.Point(2, 104);
            this.viewVentasSemanales.Name = "viewVentasSemanales";
            this.viewVentasSemanales.ReportSource = "C:\\Users\\Antonio Pasasin\\Documents\\GitHub\\SISTEMA-DE-COMIDA-RAPIDA-ITCA\\Reportes\\" +
    "rptVentasPorSemanas.rpt";
            this.viewVentasSemanales.ShowCloseButton = false;
            this.viewVentasSemanales.ShowCopyButton = false;
            this.viewVentasSemanales.ShowGotoPageButton = false;
            this.viewVentasSemanales.ShowGroupTreeButton = false;
            this.viewVentasSemanales.ShowLogo = false;
            this.viewVentasSemanales.ShowParameterPanelButton = false;
            this.viewVentasSemanales.ShowTextSearchButton = false;
            this.viewVentasSemanales.Size = new System.Drawing.Size(740, 495);
            this.viewVentasSemanales.TabIndex = 0;
            this.viewVentasSemanales.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(82, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Fecha Inicio:";
            // 
            // txtFechaInicio
            // 
            this.txtFechaInicio.Location = new System.Drawing.Point(156, 49);
            this.txtFechaInicio.Name = "txtFechaInicio";
            this.txtFechaInicio.Size = new System.Drawing.Size(108, 20);
            this.txtFechaInicio.TabIndex = 2;
            // 
            // btnGenerar
            // 
            this.btnGenerar.BackColor = System.Drawing.Color.Blue;
            this.btnGenerar.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerar.ForeColor = System.Drawing.Color.White;
            this.btnGenerar.Image = ((System.Drawing.Image)(resources.GetObject("btnGenerar.Image")));
            this.btnGenerar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGenerar.Location = new System.Drawing.Point(513, 31);
            this.btnGenerar.Name = "btnGenerar";
            this.btnGenerar.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.btnGenerar.Size = new System.Drawing.Size(158, 51);
            this.btnGenerar.TabIndex = 3;
            this.btnGenerar.Text = "Crear Reporte";
            this.btnGenerar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGenerar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnGenerar.UseVisualStyleBackColor = false;
            this.btnGenerar.Click += new System.EventHandler(this.btnGenerar_Click);
            // 
            // txtFechaFinal
            // 
            this.txtFechaFinal.Location = new System.Drawing.Point(360, 49);
            this.txtFechaFinal.Name = "txtFechaFinal";
            this.txtFechaFinal.Size = new System.Drawing.Size(105, 20);
            this.txtFechaFinal.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(289, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Fecha Final:";
            // 
            // frmReporteVentasSemanales
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(743, 611);
            this.Controls.Add(this.txtFechaFinal);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnGenerar);
            this.Controls.Add(this.txtFechaInicio);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.viewVentasSemanales);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmReporteVentasSemanales";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Reporte";
            this.Load += new System.EventHandler(this.Reporte_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer viewVentasSemanales;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtFechaInicio;
        private System.Windows.Forms.Button btnGenerar;
        private System.Windows.Forms.TextBox txtFechaFinal;
        private System.Windows.Forms.Label label2;
    }
}