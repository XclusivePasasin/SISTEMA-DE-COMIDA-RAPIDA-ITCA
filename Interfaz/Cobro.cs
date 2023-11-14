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
using SIVARS_BURGUERS.Reportes;
using SIVARS_BURGUERS.Interfaz;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

namespace SIVARS_BURGUERS.Interfaz
{
    public partial class frmCobros : Form
    {
        ClsVerPedido p = new ClsVerPedido();
         
        public frmCobros()
        {
            InitializeComponent();
        }

        private void cargarPedidos()
        {

            dtVerPedidos.DataSource = p.TodasOrdenes("V_VerPedidosCobro");
        }

       

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnCobrar_Click(object sender, EventArgs e)
        {
            if (dtVerPedidos.SelectedRows.Count > 0)
            {
                int indiceFilaSeleccionada = dtVerPedidos.SelectedRows[0].Index;

                if (dtVerPedidos.Columns.Contains("TOTAL"))
                {
                    object valorCeldaEstado = dtVerPedidos["ESTADO", indiceFilaSeleccionada].Value;

                    if (valorCeldaEstado != null)
                    {
                        if (valorCeldaEstado.ToString() == "Entregado")
                        {
                            int Codigo = (int)dtVerPedidos["CODIGO", indiceFilaSeleccionada].Value;
                            decimal total = Convert.ToDecimal(dtVerPedidos["TOTAL", indiceFilaSeleccionada].Value);

                            frmDetalleCobro formularioCobra = new frmDetalleCobro(Codigo, total);
                            formularioCobra.ShowDialog();
                            cargarPedidos();
                        }
                        else if (valorCeldaEstado.ToString() == "Pagado")
                        {
                            MessageBox.Show("EL PEDIDO YA FUE COBRADO ANTERIORMENTE.", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else
                        {
                            MessageBox.Show("NO ES POSIBLE COBRAR ESTE PEDIDO DEBIDO QUE AUN NO TIENE EL ESTADO DE 'ENTREGADA'.", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("SELECCIONE UN PEDIDO A COBRAR", "ANUNCIO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void frmCobros_Load(object sender, EventArgs e) 
        {
            cargarPedidos();
        }

        private void dtVerPedidos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            cargarPedidos();
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {

            if (txtBuscar.Text != "" && cbOpcion.Text != "")
            {
                string campo;
                if (cbOpcion.Text == "Codigo")
                {
                    campo = "CODIGO";
                }
                else if (cbOpcion.Text == "Nombre")
                {
                    campo = "CLIENTE";
                }
                else if (cbOpcion.Text == "Estado")
                {
                    campo = "ESTADO";
                }
                else
                {
                    campo = "FECHA";
                }
                dtVerPedidos.DataSource = p.buscarRegistro(campo, txtBuscar.Text);
            }
            else
            {
                string msj = "COMPLETAR LOS DATOS PARA FILTRAR";
                MessageBox.Show(msj, "INFORMACION!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnFactura_Click(object sender, EventArgs e)
        {
            if (dtVerPedidos.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dtVerPedidos.SelectedRows[0];
                int idPedido = Convert.ToInt32(selectedRow.Cells["CODIGO"].Value);
                string estadoPedido = selectedRow.Cells["ESTADO"].Value.ToString();
                if (estadoPedido == "Pagado")
                {
                    ReportDocument reportDocument = new ReportDocument();
                    reportDocument.Load("C:\\Users\\Antonio Pasasin\\Documents\\GitHub\\SISTEMA-DE-COMIDA-RAPIDA-ITCA\\Reportes\\rptFactura.rpt"); // Reemplaza con la ruta de tu informe

                    reportDocument.SetParameterValue("@idPedido", idPedido);

                    frmFactura frmCobros = new frmFactura(idPedido);
                    frmCobros.Show();
                }
                else
                {
                    MessageBox.Show("NO ES POSIBLE GENERAR LA FACTURA, DEBIDO QUE EL PEDIDO AUN NO HA SIDO COBRADO.","ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("SELECCIONE UN PEDIDO PARA REALIZAR ESTA OPERACION","INFORMACION",MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
