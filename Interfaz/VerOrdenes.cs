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
    public partial class frmVerOrdenes : Form
    {
        public frmVerOrdenes()
        {
            InitializeComponent();
        }

        private void cargar()
        {
            dtVerPedidos.DataSource = obj.getDatos();
        }



        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtFecha.Text) && cbEstado.SelectedIndex >= 0)
            {
                DateTime fecha = DateTime.Now;
                string dataFecha = fecha.ToString("yyyy-mm-dd");
                txtFecha.Text = dataFecha;

            }
        }

        private void frmVerOrdenes_Load(object sender, EventArgs e)
        {
            DateTime fecha = DateTime.Now;
            string dataFecha = fecha.ToString("yyyy-mm-dd");

            cargar();
        }
    }
}
