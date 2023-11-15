using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SIVARS_BURGUERS.DAO;
using System.Data.SqlClient;
using SIVARS_BURGUERS.Clases;

namespace SIVARS_BURGUERS.Interfaz
{
    public partial class frmVerPedidosPendientes : Form  
    {
        ClsVerPedido vp = new ClsVerPedido();
        public frmVerPedidosPendientes()
        {
            InitializeComponent();
        }

        private void cargar()
        {
            ListarEstados();
            dtVerPedidos.DataSource = vp.getDatos("V_VerPedidoMesero");
        }
        private void ListarEstados()
        {
            cbEstadoNuevo.DisplayMember = "Tipo_Estado";
            cbEstadoNuevo.ValueMember = "idEstado_Pedido";
            cbEstadoNuevo.DataSource = vp.getDatos("Estado_Pedido");
        }
        private void LimpiarCampos()
        {
            txtCodigoPedido.Text = "";
            cbEstadoNuevo.Text = "";
        }


        private void frmVerPedidosPendientes_Load(object sender, EventArgs e)
        {
            cargar();
        }

        private void dtVerPedidos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0 && e.RowIndex < dtVerPedidos.Rows.Count)
                {

                    btnEditar.Visible = true;
                    this.txtCodigoPedido.Text = dtVerPedidos.SelectedRows[0].Cells[0].Value.ToString();
                    this.cbEstadoNuevo.Text = dtVerPedidos.SelectedRows[0].Cells[4].Value.ToString();
                    int idPedido = Convert.ToInt32(dtVerPedidos.Rows[e.RowIndex].Cells["CODIGO"].Value);

                    string sql = "SELECT * FROM V_DetallesPlatillosPedidos WHERE CODIGO = @idPedido";

                    string connectionString = "Data Source=DESKTOP-0JUU1TS\\SQLEXPRESS; DataBase=SIVAR_BURGUERS; Integrated Security=True";
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@idPedido", idPedido);
                        connection.Open();
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        DataTable detallesTable = new DataTable();
                        adapter.Fill(detallesTable);
                        dtDetallesPedido.DataSource = detallesTable; 
                    }
                }
                else
                {
                    MessageBox.Show("NO EXISTEN PEDIDOS ", "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("NO EXISTE UN PEDIDO EN LA TABLA: ", "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                vp.IdPedido = Convert.ToInt32(txtCodigoPedido.Text);
                vp.IdEstadoPedido = Convert.ToInt32(cbEstadoNuevo.SelectedValue);
                vp.modificarDatos(vp);
                LimpiarCampos();
                cargar();
                btnEditar.Visible = false;
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
                else
                {
                    campo = "ESTADO";
                }
                dtVerPedidos.DataSource = vp.buscarRegistro(campo, txtBuscar.Text);
            }
            else
            {
                string msj = "COMPLETAR LOS DATOS PARA FILTRAR";
                MessageBox.Show(msj, "INFORMACION!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
