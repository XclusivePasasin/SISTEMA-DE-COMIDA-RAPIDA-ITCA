using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SIVARS_BURGUERS.Clases;

namespace SIVARS_BURGUERS.Interfaz
{
    public partial class frmUsuarios : Form
    {
        ClsUsuario obj = new ClsUsuario();
        public frmUsuarios()
        {
            InitializeComponent();
        }
        private void cargar()
        {
            dtUsuarios.DataSource = obj.getDatos();
        }
        private void LimpiarCampos()
        {
            txtCodigoUsuario.Text = "";
            txtNombreUsuario.Text = "";
            txtContraseñaUsuario.Text = "";
            txtTelefonoUsuario.Text = "";
            cbRolUsuario.Text = "";
            //Colocamos Todos Los Campos Para Limpiar
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtNombreUsuario.Text) ||
                    string.IsNullOrWhiteSpace(txtContraseñaUsuario.Text) ||
                    string.IsNullOrWhiteSpace(cbRolUsuario.Text) ||
                    string.IsNullOrWhiteSpace(txtTelefonoUsuario.Text))
                {
                    MessageBox.Show("POR FAVOR, COMPLETAR TODOS LOS CAMPOS.", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return; 
                }

                obj.Nombre = txtNombreUsuario.Text;
                obj.Contraseña = txtContraseñaUsuario.Text;
                obj.Rol = cbRolUsuario.Text;
                obj.Telefono = txtTelefonoUsuario.Text;
                obj.insertarDatos(obj);
                LimpiarCampos();
                cargar();
            }
            catch (Exception err)
            {
                MessageBox.Show("ERROR AL INSERTAR DATOS DEL USUARIO: " + err.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        

        private void frmUsuarios_Load(object sender, EventArgs e)
        {
            cargar();
            dtUsuarios.Columns[2].Visible = false;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtNombreUsuario.Text) ||
                    string.IsNullOrWhiteSpace(txtContraseñaUsuario.Text) ||
                    string.IsNullOrWhiteSpace(cbRolUsuario.Text) ||
                    string.IsNullOrWhiteSpace(txtTelefonoUsuario.Text))
                {
                    MessageBox.Show("POR FAVOR, COMPLETAR TODOS LOS CAMPOS.", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                obj.Nombre = txtNombreUsuario.Text;
                obj.Contraseña = txtContraseñaUsuario.Text;
                obj.Rol = cbRolUsuario.Text;
                obj.Telefono = txtTelefonoUsuario.Text;
                obj.modificarDatos(obj);
                LimpiarCampos();
                cargar();
            }
            catch (Exception err)
            {
                MessageBox.Show("ERROR AL MODIFICAR  DATOS DEL USUARIO: " + err.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (txtCodigoUsuario.Text != "")
            {
                try
                {
                    //Mandamos La Informacion Por Medio Del obj y Los Insertamos,Luego Limpiamos Campos y Cargamos Los Nuevos Datos
                    obj.IdUsuario = int.Parse(txtCodigoUsuario.Text);
                    obj.Nombre = txtNombreUsuario.Text;
                    obj.Contraseña = txtContraseñaUsuario.Text;
                    obj.Rol = cbRolUsuario.Text;
                    obj.Telefono = txtTelefonoUsuario.Text;
                    obj.modificarDatos(obj);
                    LimpiarCampos();
                    cargar();
                }
                catch (Exception err)
                {
                    MessageBox.Show("ERROR AL MODIFICAR DATOS DEL USUARIO: " + err.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            if (txtBuscar.Text != "" && cbOpcion.Text != "")
            {
                string campo;
                if (cbOpcion.Text == "Codigo")
                {
                    campo = "CODIGO";
                }
                else if (cbOpcion.Text == "Nombre")
                {
                    campo = "NOMBRE";
                }
                else
                {
                    campo = "ROL";
                }
                dtUsuarios.DataSource = obj.buscarRegistro(campo, txtBuscar.Text);
            }
            else
            {
                string msj = "COMPLETAR LOS DATOS PARA FILTRAR";
                MessageBox.Show(msj, "INFORMACION!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            cargar();
        }

        private void dtUsuarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            this.txtCodigoUsuario.Text = dtUsuarios.SelectedRows[0].Cells[0].Value.ToString();
            this.txtNombreUsuario.Text = dtUsuarios.SelectedRows[0].Cells[1].Value.ToString();
            this.txtContraseñaUsuario.Text = dtUsuarios.SelectedRows[0].Cells[2].Value.ToString();
            this.txtTelefonoUsuario.Text = dtUsuarios.SelectedRows[0].Cells[3].Value.ToString();
            this.cbRolUsuario.Text = dtUsuarios.SelectedRows[0].Cells[4].Value.ToString();
        }
    }   
}
