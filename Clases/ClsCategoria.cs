using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using SIVARS_BURGUERS.DAO;

namespace SIVARS_BURGUERS.Clases
{
    class ClsCategoria
    {
        private int idCategoria;
        private string nombreCategoria;

        public ClsCategoria()
        {
        }

        public ClsCategoria(int idCategoria, string nombreCategoria)
        {
            this.idCategoria = idCategoria;
            this.nombreCategoria = nombreCategoria;
        }

        CategoriaDAO c = new CategoriaDAO();

        public int IdCategoria { get => idCategoria; set => idCategoria = value; }
        public string NombreCategoria { get => nombreCategoria; set => nombreCategoria = value; }

        public DataTable getDatos()
        {
            return c.Consultar();
        }

        public bool insertarDatos(object datos)
        {
            return c.Insertar(datos);
        }

        public bool modificarDatos(object datos)
        {
            return c.Modificar(datos);
        }

        public bool eliminarDatos(string codigo)
        {
            return c.Eliminar(codigo);
        }

        public DataTable buscarRegistro(string campo, string valorCampo)
        {
            return c.Buscar(campo, valorCampo);
        }
       
    }
}
