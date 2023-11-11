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

namespace SIVARS_BURGUERS.Interfaz
{
    public partial class frmCobros : Form
    {
        ClsVerPedido p = new ClsVerPedido();
        public frmCobros()
        {
            InitializeComponent();
        }
        private void cargarOrdenes()
        {

            dtVerPedidos.DataSource = p.TodasOrdenes("Pedido");
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnCobrar_Click(object sender, EventArgs e)
        {
            if (dtVerPedidos.SelectedRows.Count > 0)
            {
                int indiceFilaSeleccionada = dtVerPedidos.SelectedRows[0].Index;

                if (dtVerPedidos.Columns.Contains("Total_Orden"))
                {
                    object valorCeldaEstado = dtVerPedidos["Estado_Orden", indiceFilaSeleccionada].Value; // Supongamos que la columna de estado se llama "Estado".

                    if (valorCeldaEstado != null && valorCeldaEstado.ToString() == "Entregada")
                    {
                        int orderId = (int)dtVerPedidos["Codigo", indiceFilaSeleccionada].Value;
                        decimal total = Convert.ToDecimal(dtVerPedidos["Total_Orden", indiceFilaSeleccionada].Value);

                        frmDetalleCobro formularioCobra = new frmDetalleCobro(orderId, total);
                        formularioCobra.ShowDialog(); // Puedes usar ShowDialog para abrir el formulario de cobro como un diálogo modal.
                    }
                    else
                    {
                        MessageBox.Show("No se puede cobrar una orden que no esté en estado 'Entregada'.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            else
            {
                MessageBox.Show("Por favor, seleccione una orden antes de cobrar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void frmCobros_Load(object sender, EventArgs e)
        {

        }
    }
}
