using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using SIVARS_BURGUERS.DAO;

namespace SIVARS_BURGUERS.Clases
{
    class ClsUsuario
    {
        private int idUsuario;
        private string nombre;
        private string contraseña;
        private string telefono;
        private string  rol;

        public ClsUsuario()
        {
        }

        public ClsUsuario(int idUsuario, string nombre, string contraseña, string telefono, string rol)
        {
            this.idUsuario = idUsuario;
            this.nombre = nombre;
            this.contraseña = contraseña;
            this.telefono = telefono;
            this.rol = rol;
        }

        UsuarioDAO u = new UsuarioDAO();

        public int IdUsuario { get => idUsuario; set => idUsuario = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Contraseña { get => contraseña; set => contraseña = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public string Rol { get => rol; set => rol = value; }

        public DataTable getDatos()
        {
            return u.Consultar();
        }

        public bool insertarDatos(object datos)
        {
            return u.Insertar(datos);
        }

        public bool modificarDatos(object datos)
        {
            return u.Modificar(datos);
        }

        public bool eliminarDatos(string codigo)
        {
            return u.Eliminar(codigo);
        }

        public DataTable buscarRegistro(string campo, string valorCampo)
        {
            return u.Buscar(campo, valorCampo);
        }
        public bool getLogin()
        {
            return u.InicioSesion(this.nombre, this.contraseña);
        }
    }
}
