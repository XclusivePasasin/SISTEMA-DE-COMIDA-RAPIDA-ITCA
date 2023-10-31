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
    class UsuarioDAO : ConnectionDataBase
    {

        public DataTable Consultar()
        {
            string sql = "";
            DataTable datos = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter();
            sql = "SELECT * FROM V_Usuario";
            SqlConnection con = GetSqlConnection();//Extraer Conexion
            try
            {
                con.Open();//Abrimos La Conexion
                string connectionString = getConnectiontring(); //Extraer Cadena De Conexion
                adapter = new SqlDataAdapter(sql,connectionString);//Ejecurtar Consulta
                adapter.Fill(datos);
            }
            catch (SqlException error){
                MessageBox.Show("OCURRIO EL SIGUIENTE ERROR: " + error.Message, "INFORMACION", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally{
                con.Close();
            }

            return datos;
        }
        //CREAMOS METODOS PARA EL CRUD
        private bool Ejecutar(string sql )
        {
            SqlConnection con = GetSqlConnection();//Extraer Conexion
            SqlCommand cmd = new SqlCommand();
            try{
                cmd.CommandText = sql;
                cmd.Connection = con;
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                return true;
            }catch (SqlException err){
                MessageBox.Show("OCURRIO UN ERROR: " + err.Message, "INFORMACION!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }finally
            {
                cmd.Connection.Close();
            }
        }

        public bool Insertar(object objDatos)
        {
            ClsUsuario u = new ClsUsuario();
            u = (ClsUsuario)objDatos;
            string sql = "INSERT INTO Usuario VALUES ('"+u.Contraseña+"','"+u.Nombre+"','"+u.Telefono+"','"+u.Rol+"')";
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
            ClsUsuario u = new ClsUsuario();
            u = (ClsUsuario)objDatos;
            string sql = "UPDATE Usuario SET Nombre_Empleado = '" + u.Nombre + "',Contraseña = '" + u.Contraseña+"',Telefono = '"+u.Telefono+"',Rol = '"+u.Rol+"' WHERE idUsuario =" + u.IdUsuario;
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
            string sql = "DELETE FROM Usuario WHERE idUsuario=" + CodigoUsuario;
            if (Ejecutar(sql))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public  DataTable Buscar(string Campo, string ValorCampo)
        {
            DataTable data = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter();
            string sql = "";
            if (Campo == "Codigo")
            {
                sql = "SELECT * FROM V_Usuario WHERE CODIGO=" + ValorCampo;
            }
            else
            {
                sql = "SELECT * FROM V_Usuario WHERE " + Campo +" Like '%"+ ValorCampo +"%'";
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
                MessageBox.Show("OCURRIO AL BUSCAR EL USUARIO : " + error.Message, "INFORMACION", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                con.Close();
            }

            return data;
        }
        public bool InicioSesion(string Usuario, string Contraseña)
        {
            SqlConnection con = GetSqlConnection();
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                //Definir Parametros Para El SQL
                cmd.Parameters.AddWithValue("@Usuario", Usuario);
                cmd.Parameters.AddWithValue("@Contraseña", Contraseña);
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM Usuario WHERE  Nombre_Empleado = @Usuario AND Contraseña = @Contraseña";
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows) 
                {
                    while (reader.Read())
                    {
                        //Set De Datos De La Clase CacheUsuario
                        CacheUsuario.idUsuario = reader.GetInt32(0);
                        CacheUsuario.nombre = reader.GetString(2);
                        CacheUsuario.rol = reader.GetString(4);
                    }
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException err)
            {
                MessageBox.Show("ERROR AL EXTRAER LA SESION" + err.Message);
                return false;
            }
            finally
            {
                con.Close();
            }
        }



    }
}
