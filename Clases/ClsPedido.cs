﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SIVARS_BURGUERS.DAO;
using System.Data;

namespace SIVARS_BURGUERS.Clases
{
    class ClsPedido
    {
        private int idPedido;
        private int idUsuario;
        private int idCliente;
        private int idMesa;
        private int idEstadoPedido;
        private decimal total;
        private DateTime fecha;
        private string hora;
        private int idPago;

        

        public ClsPedido()
        {
        }

        public ClsPedido(int idPedido, int idUsuario, int idCliente, int idMesa, int idEstadoPedido, decimal total, DateTime fecha, string hora, int idPago)
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
        public DateTime Fecha { get => fecha; set => fecha = value; }
        public string Hora { get => hora; set => hora = value; }
        public int IdPago { get => idPago; set => idPago = value; }


        PedidoDAO p = new PedidoDAO();

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

        public DataTable buscarRegistro(string campo, string valorCampo, DateTime Fecha, int idEtadoPedido)
        {
            return p.Buscar(campo, valorCampo,Fecha,idEtadoPedido);
        }
    }
}
