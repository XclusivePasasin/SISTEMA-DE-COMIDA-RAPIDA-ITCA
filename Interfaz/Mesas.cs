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
    public partial class frmMesas : Form
    {
         ClsMesa obj = new ClsMesa();
        public frmMesas()
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
            txtNombreMesa.Text = "";
            //Colocamos Todos Los Campos Para Limpiar
        }
        private void frmMesas_Load(object sender, EventArgs e)
        {
            cargar();
        }

        private void dtMesa_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            this.txtCodigoMesa.Text = dtMesa.SelectedRows[0].Cells[0].Value.ToString();
            this.txtNombreMesa.Text = dtMesa.SelectedRows[0].Cells[1].Value.ToString();
            this.nEstadoPedido.Text = dtMesa.SelectedRows[0].Cells[2].Value.ToString();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtNombreMesa.Text))
                {
                    MessageBox.Show("POR FAVOR, INGRESE NOMBRE PARA LA MESA.", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                    obj.NumeroMesa = txtNombreMesa.Text;
                    obj.Estado = (int)nEstadoPedido.Value;
                    obj.insertarDatos(obj);
                    LimpiarCampos();
                    cargar();
                
            }
            catch (Exception err)
            {
                MessageBox.Show("ERROR AL INSERTAR DATOS DE LA MESA: " + err.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                if (string.IsNullOrWhiteSpace(txtNombreMesa.Text))
                {
                    MessageBox.Show("POR FAVOR, INGRESE NOMBRE PARA LA MESA.", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                obj.IdMesa = int.Parse(txtCodigoMesa.Text);
                obj.NumeroMesa = txtNombreMesa.Text;
                obj.Estado = (int)nEstadoPedido.Value;
                obj.modificarDatos(obj);
                LimpiarCampos();
                cargar();

            }
            catch (Exception err)
            {
                MessageBox.Show("ERROR AL MODIFICAR DATOS DE LA MESA: " + err.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    campo = "NUMERO_MESA";
                }
                else
                {
                    campo = "";
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
