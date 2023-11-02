using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using SIVARS_BURGUERS.DAO;

namespace SIVARS_BURGUERS.Clases
{
    class ClsMesa
    {
        private int idMesa;
        private string numeroMesa;
        private int estado;

        public ClsMesa()
        {
        }

        public ClsMesa(int idMesa, string numeroMesa, int estado)
        {
            this.idMesa = idMesa;
            this.numeroMesa = numeroMesa;
            this.estado = estado;
        }

        public int IdMesa { get => idMesa; set => idMesa = value; }
        public string NumeroMesa { get => numeroMesa; set => numeroMesa = value; }
        public int Estado { get => estado; set => estado = value; }

        MesaDAO m = new MesaDAO();
        public DataTable getDatos()
        {
            return m.Consultar();
        }

        public bool insertarDatos(object datos)
        {
            return m.Insertar(datos);
        }

        public bool modificarDatos(object datos)
        {
            return m.Modificar(datos);
        }

        public bool eliminarDatos(string codigo)
        {
            return m.Eliminar(codigo);
        }

        public DataTable buscarRegistro(string campo, string valorCampo)
        {
            return m.Buscar(campo, valorCampo);
        }
    }
}
