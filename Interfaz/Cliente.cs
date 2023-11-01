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
            dtMesa.DataSource = obj.getDatos();
        }
        private void LimpiarCampos()
        {
            txtCodigoMesa.Text = "";
            txtNumeroMesa.Text = "";
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

            this.txtCodigoMesa.Text = dtMesa.SelectedRows[0].Cells[0].Value.ToString();
            this.txtNumeroMesa.Text = dtMesa.SelectedRows[0].Cells[1].Value.ToString();
            this.txtApellidoCliente.Text = dtMesa.SelectedRows[0].Cells[2].Value.ToString();
            this.cbGeneroCliente.Text = dtMesa.SelectedRows[0].Cells[3].Value.ToString();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                obj.Nombre = txtNumeroMesa.Text;
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
            if (txtCodigoMesa.Text != "")
            {
                string msj = "¿SEGURO QUE DESEA ELIMINAR ESTE REGISTRO?";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                MessageBoxIcon icon = MessageBoxIcon.Question;
                DialogResult resultado = MessageBox.Show(msj, "ELIMINANDO....", buttons, icon);
                if (resultado == DialogResult.Yes)
                {
                    obj.eliminarDatos(txtCodigoMesa.Text);
                    cargar();
                    LimpiarCampos();
                }
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                obj.IdCliente = Convert.ToInt32(txtCodigoMesa.Text);
                obj.Nombre = txtNumeroMesa.Text;
                obj.Apellido = txtApellidoCliente.Text;
                obj.Genero = cbGeneroCliente.Text;
                obj.modificarDatos(obj);
                LimpiarCampos();
                cargar();
            }
            catch (Exception err)
            {
                MessageBox.Show("ERROR AL INSERTAR DATOS DEL CLIENTE: " + err.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                dtMesa.DataSource = obj.buscarRegistro(campo, txtBuscar.Text);
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
