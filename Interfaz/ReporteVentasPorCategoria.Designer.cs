
namespace SIVARS_BURGUERS.Interfaz
{
    partial class frmReportePorCategoria
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReportePorCategoria));
            this.viewReporteCategoria = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.btnGenerar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cbCategoria = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // viewReporteCategoria
            // 
            this.viewReporteCategoria.ActiveViewIndex = -1;
            this.viewReporteCategoria.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.viewReporteCategoria.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.viewReporteCategoria.Cursor = System.Windows.Forms.Cursors.Default;
            this.viewReporteCategoria.DisplayStatusBar = false;
            this.viewReporteCategoria.Location = new System.Drawing.Point(1, 114);
            this.viewReporteCategoria.Name = "viewReporteCategoria";
            this.viewReporteCategoria.ShowCloseButton = false;
            this.viewReporteCategoria.ShowCopyButton = false;
            this.viewReporteCategoria.ShowGotoPageButton = false;
            this.viewReporteCategoria.ShowGroupTreeButton = false;
            this.viewReporteCategoria.ShowLogo = false;
            this.viewReporteCategoria.ShowParameterPanelButton = false;
            this.viewReporteCategoria.ShowRefreshButton = false;
            this.viewReporteCategoria.ShowTextSearchButton = false;
            this.viewReporteCategoria.Size = new System.Drawing.Size(741, 497);
            this.viewReporteCategoria.TabIndex = 0;
            this.viewReporteCategoria.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // btnGenerar
            // 
            this.btnGenerar.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnGenerar.BackColor = System.Drawing.Color.Blue;
            this.btnGenerar.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerar.ForeColor = System.Drawing.Color.White;
            this.btnGenerar.Image = ((System.Drawing.Image)(resources.GetObject("btnGenerar.Image")));
            this.btnGenerar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGenerar.Location = new System.Drawing.Point(389, 27);
            this.btnGenerar.Name = "btnGenerar";
            this.btnGenerar.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.btnGenerar.Size = new System.Drawing.Size(168, 49);
            this.btnGenerar.TabIndex = 6;
            this.btnGenerar.Text = "Crear Reporte";
            this.btnGenerar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGenerar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnGenerar.UseVisualStyleBackColor = false;
            this.btnGenerar.Click += new System.EventHandler(this.btnGenerar_Click);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(157, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 19);
            this.label1.TabIndex = 4;
            this.label1.Text = "Categoria:";
            // 
            // cbCategoria
            // 
            this.cbCategoria.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cbCategoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCategoria.FormattingEnabled = true;
            this.cbCategoria.Location = new System.Drawing.Point(234, 42);
            this.cbCategoria.Name = "cbCategoria";
            this.cbCategoria.Size = new System.Drawing.Size(121, 21);
            this.cbCategoria.TabIndex = 7;
            // 
            // frmReportePorCategoria
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(743, 611);
            this.Controls.Add(this.cbCategoria);
            this.Controls.Add(this.btnGenerar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.viewReporteCategoria);
            this.Name = "frmReportePorCategoria";
            this.Text = "Reporte";
            this.Load += new System.EventHandler(this.ReporteVentasPorCategoria_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer viewReporteCategoria;
        private System.Windows.Forms.Button btnGenerar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbCategoria;
    }
}