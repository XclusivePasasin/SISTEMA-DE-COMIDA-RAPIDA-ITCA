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
using SIVARS_BURGUERS.Interfaz;
using SIVARS_BURGUERS.DAO;

namespace SIVARS_BURGUERS.Interfaz
{
    public partial class frmDetalleCobro : Form
    {
        private int idPedido;
        private decimal total;

        public frmDetalleCobro(int idPedido, decimal total)
        {
            InitializeComponent();
            this.idPedido = idPedido;
            this.total = total;
        }
        ClsPedido cp = new ClsPedido();

        private bool Transaccion(int Codigo)
        {
            try
            {
                ClsPedido actualizar_cobro = new ClsPedido();

                if (actualizar_cobro.ActualizarEstado(Codigo))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR AL COBRAR ESTE PEDIDO: " + ex.Message);
                return false;
            }
        }

        private void frmDetalleCobro_Load(object sender, EventArgs e)
        {
            nTotal.DecimalPlaces = 2;
            nRecibido.DecimalPlaces = 2;
            nDevuelto.DecimalPlaces = 2;
            nTotal.Value = (decimal)total;
        }

        private void btnCobrar_Click(object sender, EventArgs e)
        {
            decimal dineroRecibido = nRecibido.Value;
            decimal totalOrden = (decimal)nTotal.Value;
            if (dineroRecibido < totalOrden)
            {
                MessageBox.Show("EL DINERO RECIBIDO ES INSUFICIENTE PARA COBRAR EL PEDIDO.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (Transaccion(idPedido))
                {
                    MessageBox.Show($"EL PEDIDO: {idPedido} HA SIDO COBRADO CON EXITO", "NOTIFICACION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("ERROR AL COBRAR ESTE PEDIDO.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
            }
            
        }

        private void nRecibido_ValueChanged(object sender, EventArgs e)
        {
            decimal dineroRecibido = nRecibido.Value;
            decimal totalOrden = (decimal)nTotal.Value;
            decimal cambio = dineroRecibido - totalOrden;
            // ACTUALIZA EL CAMBIO
            nDevuelto.Value = cambio;
        }
    }
}
