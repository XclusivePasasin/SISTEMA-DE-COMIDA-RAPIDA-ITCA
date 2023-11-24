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
using System.Data.SqlClient;

namespace SIVARS_BURGUERS.Interfaz
{
    public partial class frmPedido : Form
    {
        ClsPedido p = new ClsPedido();
        ClsDetallePedido dp = new ClsDetallePedido();
        public frmPedido()
        {
            InitializeComponent();
            dtPedido.SelectionChanged += new EventHandler(dtPedido_SelectionChanged);
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
            txtUsuario.Text = CacheUsuario.nombre;
            ListarMesa();
            ListarCliente();
            ListarEstado();
            ListarPago();
            ListarCategoria();
            //SECCION PARA CONOCER EL ULTIMO PEDIDO INGRESADO
            string connectionString = "Data Source=DESKTOP-0JUU1TS\\SQLEXPRESS; DataBase=SIVAR_BURGUERS; Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string sqlQuery = "SELECT MAX(idPedido) FROM Pedido";

                using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                {
                    object result = command.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        int ultimoPedido = Convert.ToInt32(result);
                        lblUltimoPedido.Text = "Último Pedido: " + ultimoPedido.ToString();
                    }
                    else
                    {
                        lblUltimoPedido.Text = "NO HAY PEDIDOS INGRESADOS";
                    }
                }
            }
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
            txtUsuario.Text = "";
            txtTotal.Text = "";
            ListarCategoria();
            //COLOCAMOS LOS CAMPOS A LIMPIAR
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
                    txtCantidad.Value = 1;
                }
            }

        }

        private void dtPedido_SelectionChanged(object sender, EventArgs e)
        {

        }


        int rowIndex;
        double subtotalEdit;
        private void dtPedido_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnAgregar.Visible = false;
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
                    string platillo = cbMenu.Text;
                    var data = platillo.Split('$');
                    string Nombre_Platillo = data[0];
                    int nuevaCantidad = Convert.ToInt32(txtCantidad.Value);
                    // Recalcular el subtotal con la nueva cantidad
                    double nuevoSubtotal = Subtotal(double.Parse(data[1]), nuevaCantidad);
                    DataGridViewRow selectedRow = dtPedido.Rows[selectedCell.RowIndex];
                    selectedRow.Cells["codigo"].Value = cbMenu.SelectedValue;
                    selectedRow.Cells["Platillo"].Value = Nombre_Platillo;
                    selectedRow.Cells["cantidad"].Value = txtCantidad.Text;
                    selectedRow.Cells["subt"].Value = nuevoSubtotal.ToString("0.00");
                    //LIMPIAMOS LOS CONTROLES LUEGO DE ACTUALIZARLOS    
                    cbMenu.SelectedItem = null;
                    LimpiarCampos();
                    btnEliminar.Visible = false;
                    btnEditar.Visible = false;
                    btnAgregar.Visible = true;
                    txtCantidad.Value = 1;
                    txtUsuario.Text = CacheUsuario.nombre;
                    // RECALCULA EL TOTAL
                    RecalcularTotal();

                }
            }
        }

        //METODO PARA RECALCULAR EL TOTAL
        private void RecalcularTotal()
        {
            double nuevoTotal = 0;

            foreach (DataGridViewRow row in dtPedido.Rows)
            {
                nuevoTotal += Convert.ToDouble(row.Cells["subt"].Value);
            }

            TotalPedido = nuevoTotal;
            txtTotal.Text = TotalPedido.ToString("0.00");
        }

        private void dtPedido_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dtPedido.Columns["cantidad"].Index || e.ColumnIndex == dtPedido.Columns["precio"].Index)
            {
                int cantidad = Convert.ToInt32(dtPedido.Rows[e.RowIndex].Cells["cantidad"].Value);
                decimal precio = Convert.ToDecimal(dtPedido.Rows[e.RowIndex].Cells["precio"].Value);

                decimal subtotal = cantidad * precio;

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
                    string platillo = cbMenu.Text;
                    var data = platillo.Split('$');
                    int nuevaCantidad = Convert.ToInt32(txtCantidad.Value);
                    double nuevoSubtotal = Subtotal(double.Parse(data[1]), nuevaCantidad);
                    selectedRow.Cells["subt"].Value = nuevoSubtotal.ToString("0.00");
                    dtPedido.Rows.Remove(selectedRow);
                    TotalPedido = TotalPedido - subtotalEdit;
                    txtTotal.Text = TotalPedido.ToString("0.00");
                    RecalcularTotal();
                }
                txtCantidad.Value = 1;
                btnEliminar.Visible = false;
                btnEditar.Visible = false;
                btnAgregar.Visible = true;


            }
        }

        private bool ComprobarSiPedidoExiste(int idPedido)
        {
            string connectionString = "Data Source=DESKTOP-0JUU1TS\\SQLEXPRESS; DataBase=SIVAR_BURGUERS; Integrated Security=True"; 
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT COUNT(*) FROM Pedido WHERE idPedido = @IdPedido";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@IdPedido", idPedido);
                    int count = (int)command.ExecuteScalar();
                    return count > 0;
                }
            }
        }

        private void btnRegistrarOrden_Click(object sender, EventArgs e)
        {
            int idPedido;
            if (int.TryParse(txtCodigoPedido.Text, out idPedido))
            {
                p.IdPedido = idPedido;
            }
            else
            {
                MessageBox.Show("EL CÓDIGO DEL PEDIDO ES INCORRECTO", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //VALIDACION PARA COMPROBAR QUE EL PEDIDO YA EXISTE O NO EXISTE
            bool esDuplicado = ComprobarSiPedidoExiste(idPedido);
            if (esDuplicado)
            {
                MessageBox.Show("EL PEDIDO YA EXISTE. INGRESE UN ID DE PEDIDO DIFERENTE.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DateTime fecha = DateTime.Now;
            string dataFecha = fecha.ToString("yyyy-MM-dd");
            p.IdCliente = Convert.ToInt32(cbCliente.SelectedValue);
            p.IdMesa = Convert.ToInt32(cbMesa.SelectedValue);
            p.IdUsuario = CacheUsuario.idUsuario;
            p.IdPago = Convert.ToInt32(cbPago.SelectedValue);
            p.Fecha = dataFecha;
            p.Hora = DateTime.Now.ToString("hh:mm:ss");
            p.IdEstadoPedido = Convert.ToInt32(cbEstado.SelectedValue);

            decimal total;
            if (decimal.TryParse(txtTotal.Text, out total) && total > 0)
            {
                p.Total = total;

                bool insertPedido = p.insertarDatos(p);

                if (insertPedido)
                {
                    if (dtPedido.RowCount > 0)
                    {
                        List<ClsDetallePedido> detalle_pedido = new List<ClsDetallePedido>();

                        foreach (DataGridViewRow row in dtPedido.Rows)
                        {
                            ClsDetallePedido dp = new ClsDetallePedido();
                            dp.IdPedido = Convert.ToInt32(txtCodigoPedido.Text);
                            dp.IdPlatillo = Convert.ToInt32(row.Cells["codigo"].Value);
                            dp.Cantidad = Convert.ToInt32(row.Cells["cantidad"].Value);
                            dp.Precio = Convert.ToDecimal(row.Cells["precio"].Value);
                            dp.SubTotal = Convert.ToDecimal(row.Cells["subt"].Value);

                            detalle_pedido.Add(dp);
                        }

                        bool insertDetalle = dp.insertarDetalle(detalle_pedido);

                        if (insertDetalle)
                        {
                            MessageBox.Show("EL PEDIDO SE HA CREADO CON ÉXITO.", "NOTIFICACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LimpiarCampos();
                            cargar();
                            dtPedido.Rows.Clear();
                        }
                        else
                        {
                            MessageBox.Show("ERROR AL INSERTAR LOS DATOS DEL PEDIDO.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("AGREGUE PLATILLOS PARA CREAR EL PEDIDO.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("ERROR AL CREAR EL PEDIDO.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("EL CAMPO 'TOTAL' DEBE SER UN VALOR VÁLIDO Y MAYOR QUE CERO.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
