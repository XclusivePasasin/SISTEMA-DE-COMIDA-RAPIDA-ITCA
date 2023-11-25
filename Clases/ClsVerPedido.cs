using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SIVARS_BURGUERS.DAO;
using System.Data;

namespace SIVARS_BURGUERS.Clases
{
    class ClsVerPedido
    {
        private int idPedido;
        private int idUsuario;
        private int idCliente;
        private int idMesa;
        private int idEstadoPedido;
        private decimal total;
        private string  fecha;
        private string hora;
        private int idPago;

        public ClsVerPedido()
        {
        }

        public ClsVerPedido(int idPedido, int idUsuario, int idCliente, int idMesa, int idEstadoPedido, decimal total, string fecha, string hora, int idPago)
        {
            this.idPedido = idPedido;
            this.idUsuario = idUsuario;
            this.idCliente = idCliente;
            this.idMesa = idMesa;
            this.idEstadoPedido = idEstadoPedido;
            this.total = total;
            this.fecha = fecha;
            this.hora = hora;
            this.idPago = idPago;
        }

        public int IdPedido { get => idPedido; set => idPedido = value; }
        public int IdUsuario { get => idUsuario; set => idUsuario = value; }
        public int IdCliente { get => idCliente; set => idCliente = value; }
        public int IdMesa { get => idMesa; set => idMesa = value; }
        public int IdEstadoPedido { get => idEstadoPedido; set => idEstadoPedido = value; }
        public decimal Total { get => total; set => total = value; }
        public string Fecha { get => fecha; set => fecha = value; }
        public string Hora { get => hora; set => hora = value; }
        public int IdPago { get => idPago; set => idPago = value; }

        VerPedidosDAO vp = new VerPedidosDAO();
        public DataTable getDatos(string tabla = null)
        {
            return vp.Consultar(tabla);
        }
        public DataTable buscarRegistro(string fecha, string estado)
        {
            return vp.Buscar(fecha, estado);
        }
        public DataTable TodasOrdenes(string tabla = null)
        {
            return vp.Consultar(tabla); 
        }
        public bool modificarDatos(object datos)
        {
            return vp.Modificar(datos);
        }
        public DataTable buscarDatos(string campo, string valorCampo)
        {
            return vp.BuscarMesero(campo, valorCampo);
        }
    }
}
