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
    public partial class frmCategoria : Form
    {

        ClsCategoria obj = new ClsCategoria();
        public frmCategoria()
        {
            InitializeComponent();
        }
        private void cargar()
        {
            dtCategoria.DataSource = obj.getDatos();
        }
        private void LimpiarCampos()
        {
            txtCodigoCategoria.Text = "";
            txtNombreCategoria.Text = "";
            //Colocamos Todos Los Campos Para Limpiar
        }
        private void dtCategorias_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            this.txtCodigoCategoria.Text = dtCategoria.SelectedRows[0].Cells[0].Value.ToString();
            this.txtNombreCategoria.Text = dtCategoria.SelectedRows[0].Cells[1].Value.ToString();
        }

        private void frmCategoria_Load(object sender, EventArgs e)
        {
            cargar();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtNombreCategoria.Text))
                {
                    MessageBox.Show("POR FAVOR, INGRESE UN NOMBRE PARA LA CATEGORIA", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return; 
                }
                obj.NombreCategoria = txtNombreCategoria.Text;
                obj.insertarDatos(obj);
                LimpiarCampos();
                cargar();
            }
            catch (Exception err)
            {
                MessageBox.Show("ERROR AL INSERTAR DATOS LA CATEGORIA: " + err.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtNombreCategoria.Text))
                {
                    MessageBox.Show("POR FAVOR, INGRESE UN NOMBRE PARA LA CATEGORIA", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                obj.NombreCategoria = txtNombreCategoria.Text;
                obj.modificarDatos(obj);
                LimpiarCampos();
                cargar();
            }
            catch (Exception err)
            {
                MessageBox.Show("ERROR AL MODIFICAR DATOS LA CATEGORIA: " + err.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (txtCodigoCategoria.Text != "")
            {
                string msj = "¿SEGURO QUE DESEA ELIMINAR ESTE REGISTRO?";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                MessageBoxIcon icon = MessageBoxIcon.Question;
                DialogResult resultado = MessageBox.Show(msj, "ELIMINANDO....", buttons, icon);
                if (resultado == DialogResult.Yes)
                {
                    obj.eliminarDatos(txtCodigoCategoria.Text);
                    cargar();
                    LimpiarCampos();
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
                    campo = "NOMBRE_CATEGORIA";
                }
                else
                {
                    campo = "";
                }
                dtCategoria.DataSource = obj.buscarRegistro(campo, txtBuscar.Text);
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
