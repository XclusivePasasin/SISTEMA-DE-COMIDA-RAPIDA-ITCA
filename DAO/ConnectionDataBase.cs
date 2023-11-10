using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Importar Para Conectar La Base De Datos
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace SIVARS_BURGUERS.DAO
{
    public abstract class  ConnectionDataBase
    {
        private readonly string connectionString;

        public ConnectionDataBase()
        {
            connectionString = "Data Source=DESKTOP-UHOQIP5\\SQLEXPRESS ; DataBase=SIVAR_BURGUERS; Integrated Security=True";
        }

        protected SqlConnection GetSqlConnection()
        {
            return new SqlConnection(connectionString);
        }

        public string getConnectiontring()
        {
            return connectionString;
        }

    }
}
