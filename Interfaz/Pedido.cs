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
    public partial class frmPedido : Form
    {
        ClsPedido obj = new ClsPedido();
        public frmPedido()
        {
            InitializeComponent();
        }

        private void cargar()
        {
            dtDetallePedido.DataSource = obj.getDatos();
        }
        private void ListarUsuario()
        {
            cbUsuario.DisplayMember = "Nombre_Empleado";
            cbUsuario.ValueMember = "idUsuario";
            cbUsuario.DataSource = obj.getDatos("Usuario");
        }
        private void ListarMesa()
        {
            cbMesa.DisplayMember = "Numero_Mesa";
            cbMesa.ValueMember = "idMesa";
            cbMesa.DataSource = obj.getDatos("Mesa");
        }
        private void ListarCliente()
        {
            cbCliente.DisplayMember = "Nombre";
            cbCliente.ValueMember = "idCliente";
            cbCliente.DataSource = obj.getDatos("Cliente");
        }
        private void ListarEstado()
        {
            cbEstado.DisplayMember = "Tipo_Estado";
            cbEstado.ValueMember = "idEstado_Pedido";
            cbEstado.DataSource = obj.getDatos("Estado_Pedido");
        }
        private void ListarPago()
        {
            cbPago.DisplayMember = "Tipo_Pago";
            cbPago.ValueMember = "idPago";
            cbPago.DataSource = obj.getDatos("Pago");
        }
        private void LimpiarCampos()
        {
            /*txtCodigoPlatillo.Text = "";
            txtNombrePlatillo.Text = "";
            txtDescripcionPlatillo.Text = "";
            nPrecio.Text = "";
            cbCategoriaPlatillo.Text = "";
            ListarCategoria();
            //Colocamos Todos Los Campos Para Limpiar*/
        }

        private void frmPedido_Load(object sender, EventArgs e)
        {
            DateTime fecha = DateTime.Now;
            string dataFecha = fecha.ToString("yyyy-mm-dd");
            txtFecha.Text = dataFecha;
            txtHora.Text = DateTime.Now.ToString("h:mm:ss tt");
            ListarUsuario();
            ListarMesa();
            ListarCliente();
            ListarEstado();
            ListarPago();
            cargar();
        }

        private void dtDetallePedido_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnEditar.Visible = true;
            btnEliminar.Visible = true;
        }
    }
}
