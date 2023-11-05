using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SIVARS_BURGUERS.DAO;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SIVARS_BURGUERS.DAO
{
    class VerPedidosDAO : ConnectionDataBase
    {

        public DataTable Consultar(string tabla)
        {
            string sql = "";
            DataTable datos = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter();
            if (tabla == "Pedido")
            {
                sql = "SELECT * FROM V_VerPedido";
            }
            else
            {
                sql = "SELECT idPlatillo,CONCAT(Nombre_Platillo,' $',Precio) AS PLATILLO FROM Platillo WHERE idCategoria =" + tabla;
            }
            SqlConnection con = GetSqlConnection();//Extraer Conexion
            try
            {
                con.Open();//Abrimos La Conexion
                string connectionString = getConnectiontring(); //Extraer Cadena De Conexion
                adapter = new SqlDataAdapter(sql, connectionString);//Ejecurtar Consulta
                adapter.Fill(datos);
            }
            catch (SqlException error)
            {
                MessageBox.Show("OCURRIO EL SIGUIENTE ERROR: " + error.Message, "INFORMACION", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                con.Close();
            }

            return datos;
        }

        public DataTable Buscar(string Campo, string ValorCampo, DateTime Fecha, int IdEstadoPedido)
        {
            DataTable data = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter();
            string sql = "";

            SqlConnection con = GetSqlConnection(); // Extraemos La Conexion
            try
            {
                con.Open(); // Abrimos La Conexión
                string connectionString = getConnectiontring(); // Extraer Cadena De Conexion

                if (Campo == "idPedido")
                {
                    sql = "SELECT * FROM Pedido WHERE idPedido = @ValorCampo";
                    adapter = new SqlDataAdapter(sql, connectionString);
                    adapter.SelectCommand.Parameters.AddWithValue("@ValorCampo", ValorCampo);
                }
                else if (Campo == "Fecha")
                {
                    sql = "SELECT * FROM Pedido WHERE Fecha = @Fecha";
                    adapter = new SqlDataAdapter(sql, connectionString);
                    adapter.SelectCommand.Parameters.AddWithValue("@Fecha", Fecha);
                }
                else if (Campo == "Estado")
                {
                    sql = "SELECT * FROM Pedido WHERE idEstado_Pedido = @IdEstadoPedido";
                    adapter = new SqlDataAdapter(sql, connectionString);
                    adapter.SelectCommand.Parameters.AddWithValue("@IdEstadoPedido", IdEstadoPedido);
                }
                else
                {
                    // Búsqueda por otro campo (por ejemplo, idUsuario, idCliente, idMesa, idPago)
                    sql = "SELECT * FROM Pedido WHERE " + Campo + " = @ValorCampo";
                    adapter = new SqlDataAdapter(sql, connectionString);
                    adapter.SelectCommand.Parameters.AddWithValue("@ValorCampo", ValorCampo);
                }

                adapter.Fill(data);
            }
            catch (SqlException error)
            {
                MessageBox.Show("OCURRIO UN ERROR AL BUSCAR EL PEDIDO: " + error.Message, "INFORMACION", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                con.Close();
            }

            return data;
        }
    }
}
