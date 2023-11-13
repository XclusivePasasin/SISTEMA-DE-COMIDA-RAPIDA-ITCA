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
    public partial class frmReporteVentasSemanales : Form
    {
        //Variables Globales
        ParameterFields datos = new ParameterFields();
        //Parametro Que Se Enviara
        ParameterField parametroFechaInicio = new ParameterField();
        ParameterField parametroFechaFinal = new ParameterField();
        //Variable Que Estara En El Parametro
        ParameterDiscreteValue fechainicio = new ParameterDiscreteValue();
        ParameterDiscreteValue fechafinal = new ParameterDiscreteValue();
        public frmReporteVentasSemanales()
        {
            InitializeComponent();
        }

        private void Reporte_Load(object sender, EventArgs e)
        {
            DateTime fecha = DateTime.Now;
            string dataFecha = fecha.ToString("yyyy-MM-dd");
            txtFechaInicio.Text = dataFecha;
            txtFechaFinal.Text = dataFecha;
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            // Configurar el nombre y el valor para FechaInicio
            parametroFechaInicio.ParameterValueType = ParameterValueKind.StringParameter;
            parametroFechaInicio.Name = "@FechaInicio";
            ParameterDiscreteValue fechainicio = new ParameterDiscreteValue();
            fechainicio.Value = this.txtFechaInicio.Text;
            parametroFechaInicio.CurrentValues.Add(fechainicio);
            // Configurar el nombre y el valor para FechaFin
            parametroFechaFinal.ParameterValueType = ParameterValueKind.StringParameter;
            parametroFechaFinal.Name = "@FechaFin";
            ParameterDiscreteValue fechafinal = new ParameterDiscreteValue();
            fechafinal.Value = this.txtFechaFinal.Text;
            parametroFechaFinal.CurrentValues.Add(fechafinal);

            // Crear una lista para almacenar los parámetros
            List<ParameterField> parametros = new List<ParameterField>();
            parametros.Add(parametroFechaInicio);
            parametros.Add(parametroFechaFinal);
            // Crear un objeto ParameterFields y agregar los parámetros
            ParameterFields parameterFields = new ParameterFields();
            parameterFields.AddRange(parametros);

            //Enviamos El Array Al Reporte
            this.viewVentasSemanales.ParameterFieldInfo = parameterFields;
            //Objeto Que Representa El Reporte
            rptVentasPorSemanas rpt = new rptVentasPorSemanas();
            //Asignamos Reporte Para Enviarlo Al CrystalReportViewer
            this.viewVentasSemanales.ReportSource = rpt;
        }
    }
}
