using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using SIVARS_BURGUERS.DAO;

namespace SIVARS_BURGUERS.Clases
{
    class ClsPlatillo
    {
        private int idPlatillo;
        private string nombrePlatillo;
        private decimal precio;
        private string descripcion;
        private int idCategoria;

        public ClsPlatillo()
        {
        }

        public ClsPlatillo(int idPlatillo, string nombrePlatillo, decimal precio, string descripcion, int idCategoria)
        {
            this.idPlatillo = idPlatillo;
            this.nombrePlatillo = nombrePlatillo;
            this.precio = precio;
            this.descripcion = descripcion;
            this.idCategoria = idCategoria;
        }
        

        public int IdPlatillo { get => idPlatillo; set => idPlatillo = value; }
        public string NombrePlatillo { get => nombrePlatillo; set => nombrePlatillo = value; }
        public decimal Precio { get => precio; set => precio = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public int IdCategoria { get => idCategoria; set => idCategoria = value; }

        PlatilloDAO p = new PlatilloDAO();
        public DataTable getDatos(string tabla = null)
        {
            return p.Consultar(tabla);
        }

        public bool insertarDatos(object datos)
        {
            return p.Insertar(datos);
        }

        public bool modificarDatos(object datos)
        {
            return p.Modificar(datos);
        }

        public bool eliminarDatos(string codigo)
        {
            return p.Eliminar(codigo);
        }

        public DataTable buscarRegistro(string campo, string valorCampo)
        {
            return p.Buscar(campo, valorCampo);
        }

    }
}
