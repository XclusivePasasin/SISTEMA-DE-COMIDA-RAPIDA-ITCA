using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Importar Para Conectar La Base De Datos
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using SIVARS_BURGUERS.Clases;

namespace SIVARS_BURGUERS.DAO
{
    class ClienteDAO : ConnectionDataBase
    {
        public DataTable Consultar()
        {
            string sql = "";
            DataTable datos = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter();
            sql = "SELECT * FROM V_Cliente";
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
        //CREAMOS METODOS PARA EL CRUD
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

        public bool Insertar(object objDatos)
        {
            ClsCliente cl = new ClsCliente();
            cl = (ClsCliente)objDatos;
            string sql = "INSERT INTO Cliente  VALUES('"+cl.Nombre+"', '"+cl.Apellido+"', '"+cl.Genero+"'); ";
            if (Ejecutar(sql))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Modificar(object objDatos)
        {
            ClsCliente cl = new ClsCliente();
            cl = (ClsCliente)objDatos;
            string sql = "UPDATE Cliente SET Nombre = '"+cl.Nombre+"', Apellido = '"+cl.Apellido+"', Genero = '"+cl.Genero+"' WHERE idCliente =" + cl.IdCliente ;
            if (Ejecutar(sql))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Eliminar(string CodigoUsuario)
        {
            string sql = "DELETE FROM Cliente WHERE idCliente=" + CodigoUsuario;
            if (Ejecutar(sql))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public DataTable Buscar(string Campo, string ValorCampo)
        {
            DataTable data = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter();
            string sql = "";
            if (Campo == "Codigo")
            {
                sql = "SELECT * FROM V_Cliente WHERE CODIGO=" + ValorCampo;
            }
            else
            {
                sql = "SELECT * FROM V_Cliente WHERE " + Campo + " Like '%" + ValorCampo + "%'";
            }
            SqlConnection con = GetSqlConnection();//Extraemos La Conexion
            try
            {
                con.Open();//Abrimos La Conexión
                string connectionString = getConnectiontring(); //Extraer Cadena De Conexion
                adapter = new SqlDataAdapter(sql, connectionString);//Ejecutar La Consulta
                adapter.Fill(data);
            }
            catch (SqlException error)
            {
                MessageBox.Show("OCURRIO AL BUSCAR LA CATEGORIA : " + error.Message, "INFORMACION", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                con.Close();
            }

            return data;
        }
    }
}
