
namespace SIVARS_BURGUERS.Interfaz
{
    partial class frmFactura
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
            this.viewFactura = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // viewFactura
            // 
            this.viewFactura.ActiveViewIndex = 0;
            this.viewFactura.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.viewFactura.Cursor = System.Windows.Forms.Cursors.Default;
            this.viewFactura.DisplayStatusBar = false;
            this.viewFactura.Dock = System.Windows.Forms.DockStyle.Fill;
            this.viewFactura.Location = new System.Drawing.Point(0, 0);
            this.viewFactura.Name = "viewFactura";
            this.viewFactura.ReportSource = "C:\\Users\\Antonio Pasasin\\Documents\\GitHub\\SISTEMA-DE-COMIDA-RAPIDA-ITCA\\Reportes\\" +
    "rptFactura.rpt";
            this.viewFactura.ShowCloseButton = false;
            this.viewFactura.ShowCopyButton = false;
            this.viewFactura.ShowGotoPageButton = false;
            this.viewFactura.ShowGroupTreeButton = false;
            this.viewFactura.ShowLogo = false;
            this.viewFactura.ShowPageNavigateButtons = false;
            this.viewFactura.ShowParameterPanelButton = false;
            this.viewFactura.ShowTextSearchButton = false;
            this.viewFactura.Size = new System.Drawing.Size(839, 650);
            this.viewFactura.TabIndex = 0;
            this.viewFactura.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // frmFactura
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(839, 650);
            this.Controls.Add(this.viewFactura);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "frmFactura";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FACTURA";
            this.Load += new System.EventHandler(this.frmFactura_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer viewFactura;
    }
}