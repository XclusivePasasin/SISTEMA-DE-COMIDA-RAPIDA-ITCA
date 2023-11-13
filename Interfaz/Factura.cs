using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SIVARS_BURGUERS.Reportes;
using CrystalDecisions.Shared;
using CrystalDecisions.CrystalReports.Engine;

namespace SIVARS_BURGUERS.Interfaz
{
    public partial class frmFactura : Form
    {
        public int IdPedido { get; set; }


        public frmFactura(int idPedido)
        {
            InitializeComponent();
            IdPedido = idPedido; // Asigna el valor del parámetro a la propiedad IdPedido

        }
        
        private void frmFactura_Load(object sender, EventArgs e)
        {
            // Crear una instancia del informe de Crystal Reports (reemplaza con la ruta de tu informe)
            rptFactura reportDocument = new rptFactura();

            // Configura el parámetro en el informe
            reportDocument.SetParameterValue("@idPedido", IdPedido); // Asegúrate de que el nombre del parámetro coincida

            // Configura el ReportSource en el CrystalReportViewer (asume que se llama viewFactura)
            viewFactura.ReportSource = reportDocument;
        }
    }
}
