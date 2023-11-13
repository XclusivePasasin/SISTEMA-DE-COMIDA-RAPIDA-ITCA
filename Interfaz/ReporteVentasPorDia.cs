using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SIVARS_BURGUERS.Interfaz
{
    public partial class frmVentasPorDia : Form
    {
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
    }
}
