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
        public frmPedido()
        {
            InitializeComponent();
            dtPedido.SelectionChanged += new EventHandler(dtPedido_SelectionChanged);
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
            DateTime fecha = DateTime.Now;
            string dataFecha = fecha.ToString("yyyy-MM-dd");
            txtFecha.Text = dataFecha;
            txtHora.Text = DateTime.Now.ToString("h:mm:ss tt");
            ListarUsuario();
            ListarMesa();
            ListarCliente();
            ListarEstado();
            ListarPago();
            ListarCategoria();
        }

        private double Subtotal(double precio, int cantidad)
        {
            return precio * cantidad;
        }

        public bool ValidarProducto(string Platillo, DataGridView dtPedido)
        {
            bool existencia = false;
            string valor;
            if (dtPedido.RowCount > 0)
            {
                foreach (DataGridViewRow fila in dtPedido.Rows)
                {
                    if (fila.Cells.Cast<DataGridViewCell>().Any(c => c.Value != null && !string.IsNullOrWhiteSpace(c.Value.ToString())))
                    {
                        valor = fila.Cells["Platillo"].Value.ToString();
                        if (valor == Platillo)
                        {
                            existencia = true;
                            break;
                        }

                    }

                }
            }
            return existencia;
        }

        double TotalPedido = 0.0;

        private void LimpiarCampos()
        {
            txtCodigoPedido.Text = "";
            cbMesa.Text = "";
            cbEstado.Text = "";
            cbPago.Text = "";
            cbEstado.Text = "";
            cbCliente.Text = "";
            cbUsuario.Text = "";
            txtTotal.Text = "";
            ListarCategoria();
            //Colocamos Todos Los Campos Para Limpiar
        }

        private void frmPedido_Load(object sender, EventArgs e)
        {
            
            cargar();
        }

        int filaIndex;
        double precioEdit;
        double SubTotalEdit;
      

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
                var msj = "NO EXISTEN PLATILLOS EN ESTA CATEGORIA";
                MessageBox.Show(msj, "CAMBIE OTRA CATEGORIA", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (cbMenu.Text != "" && txtCantidad.Value > 0)
            {
                //PREPARAMOS LOS CAMPOS QUE SE ENVIARAN AL DATAGRIDVIEW
                string platillo = cbMenu.Text;
                int idPlatillo = Convert.ToInt32(cbMenu.SelectedValue);
                var data = platillo.Split('$');
                int Cantidad = Convert.ToInt32(txtCantidad.Value);
                double subtotal = Subtotal(double.Parse(data[1]), Convert.ToInt32(txtCantidad.Value));
                string[] Arreglo = { idPlatillo.ToString(), data[0], Cantidad.ToString(), data[1], subtotal.ToString() };
                string Nombre_Platillo = data[0];
                bool verificacion = ValidarProducto(Nombre_Platillo, dtPedido);
                if (verificacion)
                {
                    MessageBox.Show("EL PRODUCTO YA EXISTE EN EL DETALLE DEL PEDIDO", "SELECCIONE UN PLATILLO DIFERENTE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    dtPedido.Rows.Add(Arreglo); // MANDAMOS EL ARREGLO SI LA CONDICION DA COMO RESPUESTA FALSE
                    TotalPedido += subtotal;
                    txtTotal.Text = TotalPedido.ToString("0.00");
                }
            }
            
        }

        private void dtPedido_SelectionChanged(object sender, EventArgs e)
        {

        }


        int rowIndex;
        //double precioEdit;
        double subtotalEdit;
        private void dtPedido_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnEditar.Visible = true;
            btnEliminar.Visible = true;
            if (e.RowIndex >= 0)
            {
                rowIndex = e.RowIndex;
                DataGridViewRow selectedRow = dtPedido.Rows[e.RowIndex];
                //CARGAMOS DATOS PARA EDICION
                cbCategoria.Text = "";
                cbMenu.Text = "";
                txtCantidad.Text = selectedRow.Cells["cantidad"].Value.ToString();


            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dtPedido.SelectedCells.Count > 0)
            {
                DataGridViewCell selectedCell = dtPedido.SelectedCells[0];

                if (selectedCell != null)
                {
                    DataGridViewRow selectedRow = dtPedido.Rows[selectedCell.RowIndex];
                    selectedRow.Cells["codigo"].Value = cbMenu.SelectedValue;
                    selectedRow.Cells["Platillo"].Value = cbMenu.Text;
                    selectedRow.Cells["cantidad"].Value = txtCantidad.Text;
                    //LIMPIAMOS LOS CONTROLES LUEGO DE ACTUALIZARLOS
                    cbMenu.SelectedItem = null;
                    LimpiarCampos();
                    btnEliminar.Visible = false;
                    btnEditar.Visible = false;


                }
            }
        }

        private void dtPedido_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dtPedido.Columns["cantidad"].Index || e.ColumnIndex == dtPedido.Columns["precio"].Index)
            {
                // Asegúrate de que estás en la columna de "Cantidad" o "Precio"
                int cantidad = Convert.ToInt32(dtPedido.Rows[e.RowIndex].Cells["cantidad"].Value);
                decimal precio = Convert.ToDecimal(dtPedido.Rows[e.RowIndex].Cells["precio"].Value);

                // Calcula el nuevo subtotal
                decimal subtotal = cantidad * precio;

                // Actualiza el valor en la columna "Subtotal"
                dtPedido.Rows[e.RowIndex].Cells["subt"].Value = subtotal;
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dtPedido.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dtPedido.SelectedRows[0];
                string mensaje = "¿SEGURO QUE QUIERE ELIMINAR ESTE PLATILLO?";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                MessageBoxIcon icon = MessageBoxIcon.Question;
                DialogResult result = MessageBox.Show(mensaje, "ELIMINANDO", buttons, icon);
                if (result == DialogResult.Yes)
                {
                    dtPedido.Rows.Remove(selectedRow);
                    TotalPedido = TotalPedido - subtotalEdit;
                    txtTotal.Text = TotalPedido.ToString("0.00");
                }
                btnEliminar.Visible = false;
                btnEditar.Visible = false;


            }
        }
    }
}
