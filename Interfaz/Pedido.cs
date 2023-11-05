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
        ClsPedido p = new ClsPedido();
        ClsDetallePedido dp = new ClsDetallePedido();
        public frmPedido()
        {
            InitializeComponent();
        }


        private void ListarUsuario()
        {
            cbUsuario.DisplayMember = "Nombre_Empleado";
            cbUsuario.ValueMember = "idUsuario";
            cbUsuario.DataSource = p.getDatos("Usuario");
        }
        private void ListarMesa()
        {
            cbMesa.DisplayMember = "Numero_Mesa";
            cbMesa.ValueMember = "idMesa";
            cbMesa.DataSource = p.getDatos("Mesa");
        }
        private void ListarCliente()
        {
            cbCliente.DisplayMember = "Nombre";
            cbCliente.ValueMember = "idCliente";
            cbCliente.DataSource = p.getDatos("Cliente");
        }
        private void ListarEstado()
        {
            cbEstado.DisplayMember = "Tipo_Estado";
            cbEstado.ValueMember = "idEstado_Pedido";
            cbEstado.DataSource = p.getDatos("Estado_Pedido");
        }
        private void ListarPago()
        {
            cbPago.DisplayMember = "Tipo_Pago";
            cbPago.ValueMember = "idPago";
            cbPago.DataSource = p.getDatos("Pago");
        }
        private void ListarCategoria()
        {
            cbCategoria.DisplayMember = "Nombre_Categoria";
            cbCategoria.ValueMember = "idCategoria";
            cbCategoria.DataSource = p.getDatos("Categoria");
        }

        private void cargar()
        {
            dtDetallePedido.DataSource = p.getDatos("Detalle_Pedido");
        }

        private double Subtotal(double precio, int cantidad)
        {
            return precio * cantidad;
        }

        public bool ValidarProducto(string NombrePlato)
        {
            bool existencia = false;
            string valor;
            if (dtDetallePedido.RowCount > 0)
            {
                foreach (DataGridViewRow fila in dtDetallePedido.Rows)
                {
                    if (fila.Cells.Cast<DataGridViewCell>().Any(c => c.Value != null && !string.IsNullOrWhiteSpace(c.Value.ToString())))
                    {
                        valor = fila.Cells["Platillo"].Value.ToString();
                        if (valor == NombrePlato)
                        {
                            existencia = true;
                            break;
                        }

                    }

                }
            }
            return existencia;
        }

        double TotalPedido = 0;

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
            ListarCategoria();
            cargar();
        }

        int filaIndex;
        double precioEdit;
        double SubTotalEdit;
        private void dtDetallePedido_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            btnEditar.Visible = true;
            btnEliminar.Visible = true;
            if (e.RowIndex >= 0)
            {
                filaIndex = e.RowIndex;
                this.txtCantidad.Value = Convert.ToDecimal(dtDetallePedido.SelectedRows[0].Cells[2].Value);
                precioEdit = double.Parse(dtDetallePedido.SelectedRows[0].Cells[3].Value.ToString());
                SubTotalEdit = double.Parse(dtDetallePedido.SelectedRows[0].Cells[4].Value.ToString());
            }
        }

        private void cbCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            string codigo = cbCategoria.SelectedValue.ToString();
            ListarMenu(codigo);
        }
        private void ListarMenu(string Categoria)
        {
            var datos = p.getDatos(Categoria);
            if (datos.Rows.Count > 0)
            {
                cbMenu.DisplayMember = "PLATILLO";
                cbMenu.ValueMember = "idPlatillo";
                cbMenu.DataSource = datos;
            }
            else
            {
                cbMenu.DataSource = datos;
                var msj = "No Existen Platillos";
                MessageBox.Show(msj, "Cambie Otra Categoria", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string platillo = cbMenu.Text;
            int idPlatillo = Convert.ToInt32(cbMenu.SelectedValue);
            var data = platillo.Split('$');
            double subtotal = Subtotal(double.Parse(data[1]), Convert.ToInt32(txtCantidad.Value));
            string[] Arreglo = { idPlatillo.ToString(), data[0], txtCantidad.Value.ToString(), data[1], subtotal.ToString() };
            bool verificacion = ValidarProducto(data[0]);
            if(verificacion == false)
            {
                dtDetallePedido.Rows.Add(Arreglo);
                TotalPedido += subtotal;
                txtTotal.Text = TotalPedido.ToString();
                this.txtCantidad.Value = 1;
            }
        }
    }
}
