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
    public partial class frmCliente : Form
    {
        ClsCliente obj = new ClsCliente();
        public frmCliente()
        {
            InitializeComponent();
        }
        private void cargar()
        {
            dtCliente.DataSource = obj.getDatos();
        }
        private void LimpiarCampos()
        {
            txtCodigoCliente.Text = "";
            txtNombreCliente.Text = "";
            txtApellidoCliente.Text = "";
            cbGeneroCliente.Text = "";
            //Colocamos Todos Los Campos Para Limpiar
        }

        private void frmCliente_Load(object sender, EventArgs e)
        {
            cargar();
        }
       

        private void dtUsuarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            this.txtCodigoCliente.Text = dtCliente.SelectedRows[0].Cells[0].Value.ToString();
            this.txtNombreCliente.Text = dtCliente.SelectedRows[0].Cells[1].Value.ToString();
            this.txtApellidoCliente.Text = dtCliente.SelectedRows[0].Cells[2].Value.ToString();
            this.cbGeneroCliente.Text = dtCliente.SelectedRows[0].Cells[3].Value.ToString();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtNombreCliente.Text) ||
                    string.IsNullOrWhiteSpace(txtApellidoCliente.Text) ||
                    string.IsNullOrWhiteSpace(cbGeneroCliente.Text))
                {
                    MessageBox.Show("POR FAVOR, COMPLETE TODOS LOS CAMPOS.", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return; 
                }

                obj.Nombre = txtNombreCliente.Text;
                obj.Apellido = txtApellidoCliente.Text;
                obj.Genero = cbGeneroCliente.Text;
                obj.insertarDatos(obj);
                LimpiarCampos();
                cargar();
            }
            catch (Exception err)
            {
                MessageBox.Show("ERROR AL INSERTAR DATOS DEL CLIENTE: " + err.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (txtCodigoCliente.Text != "")
            {
                string msj = "¿SEGURO QUE DESEA ELIMINAR ESTE REGISTRO?";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                MessageBoxIcon icon = MessageBoxIcon.Question;
                DialogResult resultado = MessageBox.Show(msj, "ELIMINANDO....", buttons, icon);
                if (resultado == DialogResult.Yes)
                {
                    obj.eliminarDatos(txtCodigoCliente.Text);
                    cargar();
                    LimpiarCampos();
                }
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtNombreCliente.Text) ||
                    string.IsNullOrWhiteSpace(txtApellidoCliente.Text) ||
                    string.IsNullOrWhiteSpace(cbGeneroCliente.Text))
                {
                    MessageBox.Show("POR FAVOR, COMPLETE TODOS LOS CAMPOS.", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                obj.Nombre = txtNombreCliente.Text;
                obj.Apellido = txtApellidoCliente.Text;
                obj.Genero = cbGeneroCliente.Text;
                obj.modificarDatos(obj);
                LimpiarCampos();
                cargar();
            }
            catch (Exception err)
            {
                MessageBox.Show("ERROR AL MODIFICAR DATOS DEL CLIENTE: " + err.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                else
                {
                    campo = "NOMBRE";
                }
                dtCliente.DataSource = obj.buscarRegistro(campo, txtBuscar.Text);
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
    }
}
