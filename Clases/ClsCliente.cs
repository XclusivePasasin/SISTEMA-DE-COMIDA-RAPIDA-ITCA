using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SIVARS_BURGUERS.DAO;
using System.Data;

namespace SIVARS_BURGUERS.Clases
{
    class ClsCliente
    {
        private int idCliente;
        private string nombre;
        private string apellido;
        private string genero;

        public ClsCliente()
        {
        }

        public ClsCliente(int idCliente, string nombre, string apellido, string genero)
        {
            this.idCliente = idCliente;
            this.nombre = nombre;
            this.apellido = apellido;
            this.genero = genero;
        }

        public int IdCliente { get => idCliente; set => idCliente = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public string Genero { get => genero; set => genero = value; }


        ClienteDAO cl = new ClienteDAO();
        public DataTable getDatos()
        {
            return cl.Consultar();
        }

        public bool insertarDatos(object datos)
        {
            return cl.Insertar(datos);
        }

        public bool modificarDatos(object datos)
        {
            return cl.Modificar(datos);
        }

        public bool eliminarDatos(string codigo)
        {
            return cl.Eliminar(codigo);
        }

        public DataTable buscarRegistro(string campo, string valorCampo)
        {
            return cl.Buscar(campo, valorCampo);
        }
      

    }
}
