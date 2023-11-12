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
            dtVerPedidos.DataSource = vp.getDatos("V_VerPedidoMesero");
        }


        private void frmVerPedidosPendientes_Load(object sender, EventArgs e)
        {
            cargar();
        }

        private void dtVerPedidos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dtVerPedidos.Rows.Count)
            {
                // Obtén el ID de la orden seleccionada desde el DataGridView
                int idPedido = Convert.ToInt32(dtVerPedidos.Rows[e.RowIndex].Cells["CODIGO"].Value);

                // Consulta SQL para obtener los detalles de la orden
                string sql = "SELECT * FROM V_DetallesPlatillosPedidosFuncionUltima1 WHERE CODIGO_PEDIDO = @idPedido";

                // Ejecuta la consulta y carga los detalles en otro DataGridView o control apropiado
                // Recuerda utilizar parámetros para evitar SQL Injection.
                // Aquí se asume que tienes una conexión de base de datos configurada (por ejemplo, SqlConnection).
                string connectionString = "Data Source=DESKTOP-0JUU1TS\\SQLEXPRESS; DataBase=SIVAR_BURGUERS; Integrated Security=True";
                using (SqlConnection connection = new SqlConnection(connectionString))
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@idPedido", idPedido);
                    connection.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable detallesTable = new DataTable();
                    adapter.Fill(detallesTable);
                    dtDetallesPedido.DataSource = detallesTable; // Carga los detalles en un DataGridView separado.
                }
            }
        }
    }
}
