using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SIVARS_BURGUERS.DAO;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using SIVARS_BURGUERS.Clases;

namespace SIVARS_BURGUERS.DAO
{
    class VerPedidosDAO : ConnectionDataBase
    {

        public DataTable Consultar(string tabla)
        {
            string sql = "";
            DataTable datos = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter();
            if (tabla == "Estado_Pedido")
            {
                sql = "SELECT idEstado_Pedido, Tipo_Estado FROM Estado_Pedido";
            }
            else
            {
                sql = "SELECT * FROM V_VerPedido";
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
        private bool Ejecutar(string sql)
        {
            SqlConnection con = GetSqlConnection();//Extraer Conexion
            SqlCommand cmd = new SqlCommand();
            try
            {
                cmd.CommandText = sql;
                cmd.Connection = con;
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (SqlException err)
            {
                MessageBox.Show("OCURRIO UN ERROR: " + err.Message, "INFORMACION!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            finally
            {
                cmd.Connection.Close();
            }
        }
        //UPDATE Pedido SET idEstado_Pedido =   WHERE idPedido =  
        public bool Modificar(object objDatos)
        {
            ClsVerPedido vp = new ClsVerPedido();
            vp = (ClsVerPedido)objDatos;
            string sql = "UPDATE Pedido SET idEstado_Pedido = "+vp.IdEstadoPedido+"   WHERE idPedido = " + vp.IdPedido;
            if (Ejecutar(sql))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public DataTable Buscar(DateTime fecha, int idEstadoPedido)
        {
            DataTable data = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter();
            // Utiliza parámetros en la consulta SQL para evitar la inyección de SQL.
            string sql = "SELECT * FROM V_VerPedido WHERE FECHA = @Fecha AND CLAVE = @IdEstadoPedido";

            SqlConnection con = GetSqlConnection();
            try
            {
                con.Open();

                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@Fecha", fecha);
                cmd.Parameters.AddWithValue("@IdEstadoPedido", idEstadoPedido);

                adapter.SelectCommand = cmd;
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
