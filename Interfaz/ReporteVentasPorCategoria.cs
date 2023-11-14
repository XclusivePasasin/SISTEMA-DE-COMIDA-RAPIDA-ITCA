using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SIVARS_BURGUERS.Clases;
using CrystalDecisions.Shared;
using SIVARS_BURGUERS.Reportes;

namespace SIVARS_BURGUERS.Interfaz
{
    public partial class frmReportePorCategoria : Form
    {
        ClsCategoria c = new ClsCategoria();
        //Variables Globales
        ParameterFields datos = new ParameterFields();
        //Parametro Que Se Enviara
        ParameterField parametro = new ParameterField();
        //Variable Que Estara En El Parametro
        ParameterDiscreteValue Valor = new ParameterDiscreteValue();
        public frmReportePorCategoria()
        {
            InitializeComponent();
        }
        private void ListarCategoria()
        {
            cbCategoria.DisplayMember = "Nombre_Categoria";
            cbCategoria.ValueMember = "idCategoria";
            cbCategoria.DataSource = c.getDatos("Categoria");
        }

        private void ReporteVentasPorCategoria_Load(object sender, EventArgs e)
        {
            ListarCategoria();
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            //Asignar El Valor Para Enviar
            this.parametro.ParameterValueType = ParameterValueKind.StringParameter;
            this.parametro.Name = "@NombreCategoria";
            this.Valor.Value = this.cbCategoria.Text; // Capturamos Valor Del Control
            //Enviamos Valor Al Parametro
            this.parametro.CurrentValues.Add(Valor);
            //Enviamos Parametro Al Array
            this.datos.Add(parametro);
            //Enviamos El Array Al Reporte
            this.viewReporteCategoria.ParameterFieldInfo = datos;
            //Objeto Que Representa El Reporte
            rptVentasPorCategoria rpt = new rptVentasPorCategoria();
            //Asignamos Reporte Para Enviarlo Al CrystalReportViewer
            this.viewReporteCategoria.ReportSource = rpt;
        }
    }
}
