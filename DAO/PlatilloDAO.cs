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
    class PlatilloDAO : ConnectionDataBase
    {
        public DataTable Consultar(string tabla)
        {
            string sql = "";
            DataTable datos = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter();
            if (tabla == "Categoria")
            {
                sql = "SELECT idCategoria, Nombre_Categoria FROM Categoria";
            }
            else
            {
                sql = "SELECT * FROM V_Platillo";
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
             ClsPlatillo p = new ClsPlatillo();
            p = (ClsPlatillo)objDatos;
            string sql = "INSERT INTO Platillo VALUES ('"+p.NombrePlatillo+"',"+ p.Precio + ", '"+p.Descripcion+"'," + p.IdCategoria + ")";
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
            ClsPlatillo p = new ClsPlatillo();
            p = (ClsPlatillo)objDatos;
            string sql = "UPDATE Platillo SET Nombre_Platillo = '"+p.NombrePlatillo+"',Precio ="+p.Precio+",Descripcion = '"+p.Descripcion+"',idCategoria = "+p.IdCategoria+" WHERE idPlatillo = " + p.IdPlatillo;
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
            string sql = "DELETE FROM Platillo WHERE idPlatillo=" + CodigoUsuario;
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
            if (Campo == "CODIGO")
            {
                sql = "SELECT * FROM V_Platillo WHERE idPlatillo=" + ValorCampo;
            }
            else
            {
                sql = "SELECT * FROM V_Platillo WHERE " + Campo + " Like '%" + ValorCampo + "%'";
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
                MessageBox.Show("OCURRIO AL BUSCAR EL PLATILLO: " + error.Message, "INFORMACION", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                con.Close();
            }

            return data;
        }
        
    }
}
