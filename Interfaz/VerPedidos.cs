using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using SIVARS_BURGUERS.Clases;

namespace SIVARS_BURGUERS.Interfaz
{
    public partial class frmVerPedidos : Form
    {
        ClsVerPedido vp = new ClsVerPedido();
        public frmVerPedidos()
        {
            InitializeComponent();
        }

        private void cargar()
        {
            dtVerPedidos.DataSource = vp.getDatos();
        }
        private void ListarEstados()
        {
            cbEstado.DisplayMember = "Tipo_Estado";
            cbEstado.ValueMember = "idEstado_Pedido";
            cbEstado.DataSource = vp.getDatos("Estado_Pedido");
        }
        private void ListarEstadosNuevos()
        {
            cbEstadoNuevo.DisplayMember = "Tipo_Estado";
            cbEstadoNuevo.ValueMember = "idEstado_Pedido";
            cbEstadoNuevo.DataSource = vp.getDatos("Estado_Pedido");
        }



        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            if (txtFecha.Text != "" && cbEstado.Text != "")
            {
                string fecha = txtFecha.Text;
                string estado = cbEstado.Text;
              
                
                dtVerPedidos.DataSource = vp.buscarRegistro(fecha, estado);
            }
            else
            {
                string msj = "COMPLETAR LOS DATOS PARA FILTRAR";
                MessageBox.Show(msj, "INFORMACION!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void frmVerOrdenes_Load(object sender, EventArgs e)
        {
            DateTime fecha = DateTime.Now;
            string dataFecha = fecha.ToString("yyyy-MM-dd");
            txtFecha.Text = dataFecha;
            ListarEstados();
            cargar();
        }
        private void LimpiarCampos()
        {
            txtCodigoPedido.Text = "";
            cbEstadoNuevo.Text = "";
        }
        private void dtVerPedidos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnEditar.Visible = true;
            ListarEstadosNuevos();
            this.txtCodigoPedido.Text = dtVerPedidos.SelectedRows[0].Cells[0].Value.ToString();
            this.cbEstadoNuevo.Text = dtVerPedidos.SelectedRows[0].Cells[4].Value.ToString();
            
        }
        private int ObtenerEstadoPedido(int idPedido)
        {

            int estadoActual = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection("Data Source=DESKTOP-0JUU1TS\\SQLEXPRESS; DataBase=SIVAR_BURGUERS; Integrated Security=True"))
                {
                    connection.Open();

                    string sqlQuery = "SELECT idEstado_Pedido FROM Pedido WHERE idPedido = @IdPedido";

                    using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                    {
                        command.Parameters.AddWithValue("@IdPedido", idPedido);
                        object result = command.ExecuteScalar();

                        if (result != null && result != DBNull.Value)
                        {
                            estadoActual = Convert.ToInt32(result);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR AL OBTENER EL ESTADO DEL PEDIDO: " + ex.Message);
            }

            return estadoActual;
        }
        private void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                int estadoActual = ObtenerEstadoPedido(Convert.ToInt32(txtCodigoPedido.Text));

                if (estadoActual == 5)
                {
                    MessageBox.Show("NO SE PUEDE EDITAR EL ESTADO DE ESTE PEDIDO, DEBIDO QUE YA FUE COBRADO.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpiarCampos();
                    cargar();
                    // LIMPIAMOS EL DATAGRID DEL DETALLE PEDIDO
                    btnEditar.Visible = false;

                    return;
                }
                else
                {
                    vp.IdPedido = Convert.ToInt32(txtCodigoPedido.Text);
                    vp.IdEstadoPedido = Convert.ToInt32(cbEstadoNuevo.SelectedValue);
                    vp.modificarDatos(vp);
                    LimpiarCampos();
                    cargar();
                    // LIMPIAMOS EL DATAGRID DEL DETALLE PEDIDO
                    btnEditar.Visible = false;
                }
            }
            catch (Exception err)
            {
                MessageBox.Show("ERROR AL ACTUALIZAR PEDIDO: " + err.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            cargar();
        }
    }
}
