using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SIVARS_BURGUERS.Clases;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SIVARS_BURGUERS.DAO
{
    class DetallePedidoDAO : ConnectionDataBase
    {
        public DataTable Consultar(string tabla)
        {
            string sql = "";
            DataTable datos = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter();
            if (tabla == "Usuario")
            {
                sql = "SELECT idUsuario,Nombre_Empleado FROM Usuario";
            }
            else if (tabla == "Mesa")
            {
                sql = "SELECT idMesa,Numero_Mesa FROM Mesa WHERE Estado = 1";
            }
            else if (tabla == "Cliente")
            {
                sql = "SELECT idCliente,CONCAT(Nombre,' ',Apellido) AS Nombre FROM Cliente";
            }
            else if (tabla == "Estado_Pedido")
            {
                sql = "SELECT idEstado_Pedido,Tipo_Estado FROM Estado_Pedido WHERE Tipo_Estado = 'Pendiente'";
            }
            else if (tabla == "Pago")
            {
                sql = "SELECT idPago,Tipo_Pago FROM Pago";
            }
            else if (tabla == "Categoria")
            {
                sql = "SELECT idCategoria,Nombre_Categoria FROM Categoria";
            }
            else if (tabla == "Detalle_Pedido")
            {
                sql = "SELECT * FROM V_DetallePedido";
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
            ClsDetallePedido dp = new ClsDetallePedido();
            dp = (ClsDetallePedido)objDatos;
            string sql = "";
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
            ClsDetallePedido dp = new ClsDetallePedido();
            dp = (ClsDetallePedido)objDatos;
            string sql = "";
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
            string sql = "DELETE FROM Categoria WHERE =" + CodigoUsuario;
            if (Ejecutar(sql))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

       
    }
}
