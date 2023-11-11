using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SIVARS_BURGUERS.DAO;
using System.Data;

namespace SIVARS_BURGUERS.Clases
{
    class ClsDetallePedido
    {
        private int  idDetallePedido;
        private int idPlatillo;
        private int idPedido;
        private int cantidad;
        private decimal precio;
        private decimal subTotal;

        public ClsDetallePedido()
        {
        }

        public ClsDetallePedido(int idDetallePedido, int idPlatillo, int idPedido, int cantidad, decimal precio, decimal subTotal)
        {
            this.idDetallePedido = idDetallePedido;
            this.idPlatillo = idPlatillo;
            this.idPedido = idPedido;
            this.cantidad = cantidad;
            this.precio = precio;
            this.subTotal = subTotal;
        }

        public int IdDetallePedido { get => idDetallePedido; set => idDetallePedido = value; }
        public int IdPlatillo { get => idPlatillo; set => idPlatillo = value; }
        public int IdPedido { get => idPedido; set => idPedido = value; }
        public int Cantidad { get => cantidad; set => cantidad = value; }
        public decimal Precio { get => precio; set => precio = value; }
        public decimal SubTotal { get => subTotal; set => subTotal = value; }

        DetallePedidoDAO dp = new DetallePedidoDAO();
        public DataTable getDatos(string tabla = null)
        {
            return dp.Consultar(tabla);
        }

        public bool insertarDetalle(List<ClsDetallePedido> listaDatos)
        {

            foreach (object row in listaDatos)
            {
                dp.insertar(row);
            }
            return true;

        }

        public bool modificarDatos(object datos)
        {
            return dp.Modificar(datos);
        }

        public bool eliminarDatos(string codigo)
        {
            return dp.Eliminar(codigo);
        }

       
    }
}
