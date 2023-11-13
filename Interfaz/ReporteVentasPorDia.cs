using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrystalDecisions.Shared;
using SIVARS_BURGUERS.Reportes;

namespace SIVARS_BURGUERS.Interfaz
{ 
    
    public partial class frmVentasPorDia : Form
    {
        //Variables Globales
         ParameterFields datos = new ParameterFields();
        //Parametro Que Se Enviara
        ParameterField parametro = new ParameterField();
        //Variable Que Estara En El Parametro
        ParameterDiscreteValue Valor = new ParameterDiscreteValue();
        public frmVentasPorDia()
        {
            InitializeComponent();
        }

        private void ReporteVentasPorDia_Load(object sender, EventArgs e)
        {
            DateTime fecha = DateTime.Now;
            string dataFecha = fecha.ToString("yyyy-MM-dd");
            txtFecha.Text = dataFecha;
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            //Asignar El Valor Para Enviar
            this.parametro.ParameterValueType = ParameterValueKind.StringParameter;
            this.parametro.Name = "@FechaConsulta";
            this.Valor.Value = this.txtFecha.Text; // Capturamos Valor Del Control
            //Enviamos Valor Al Parametro
            this.parametro.CurrentValues.Add(Valor);
            //Enviamos Parametro Al Array
            this.datos.Add(parametro);
            //Enviamos El Array Al Reporte
            this.viewVentasPorDia.ParameterFieldInfo = datos;
            //Objeto Que Representa El Reporte
            rptVentasPorDia rpt = new rptVentasPorDia();
            //Asignamos Reporte Para Enviarlo Al CrystalReportViewer
            this.viewVentasPorDia.ReportSource = rpt;
        }
    }
}
