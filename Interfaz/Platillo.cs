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
using System.Data.SqlClient;

namespace SIVARS_BURGUERS.Interfaz
{
    public partial class frmPlatillo : Form
    {
        ClsPlatillo obj = new ClsPlatillo();
        public frmPlatillo()
        {
            InitializeComponent();
        }
        private void cargar()
        {
            dtPlatillo.DataSource = obj.getDatos();
        }
        private void ListarCategoria()
        {
            cbCategoriaPlatillo.DisplayMember = "Nombre_Categoria";
            cbCategoriaPlatillo.ValueMember = "idCategoria";
            cbCategoriaPlatillo.DataSource = obj.getDatos("Categoria");
        }
        private void LimpiarCampos()
        {
            txtCodigoPlatillo.Text = "";
            txtNombrePlatillo.Text = "";
            txtDescripcionPlatillo.Text = "";
            nPrecio.Text = "";
            cbCategoriaPlatillo.Text = "";
            ListarCategoria();
            //Colocamos Todos Los Campos Para Limpiar
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                //Mandamos La Informacion Por Medio Del obj y Los Insertamos,Luego Limpiamos Campos y Cargamos Los Nuevos Datos
                obj.NombrePlatillo = txtNombrePlatillo.Text;
                obj.Precio = Convert.ToInt32(nPrecio.Text);
                obj.Descripcion = txtDescripcionPlatillo.Text;
                obj.IdCategoria = Convert.ToInt32(cbCategoriaPlatillo.SelectedValue);
                obj.insertarDatos(obj);
                LimpiarCampos();
                cargar();
            }
            catch (Exception err)
            {
                MessageBox.Show("ERROR AL INSERTAR DATOS DEL PLATILLO: " + err.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (txtCodigoPlatillo.Text != "")
            {
                string msj = "¿SEGURO QUE DESEA ELIMINAR ESTE REGISTRO?";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                MessageBoxIcon icon = MessageBoxIcon.Question;
                DialogResult resultado = MessageBox.Show(msj, "ELIMINANDO....", buttons, icon);
                if (resultado == DialogResult.Yes)
                {
                    obj.eliminarDatos(txtCodigoPlatillo.Text);
                    cargar();
                    LimpiarCampos();
                }
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                //Mandamos La Informacion Por Medio Del obj y Los Insertamos,Luego Limpiamos Campos y Cargamos Los Nuevos Datos
                obj.IdPlatillo = Convert.ToInt32(txtCodigoPlatillo.Text);
                obj.NombrePlatillo = txtNombrePlatillo.Text;
                obj.Precio = Convert.ToInt32(nPrecio.Text);
                obj.Descripcion = txtDescripcionPlatillo.Text;
                obj.IdCategoria = Convert.ToInt32(cbCategoriaPlatillo.SelectedValue);
                obj.modificarDatos(obj);
                LimpiarCampos();
                cargar();
            }
            catch (Exception err)
            {
                MessageBox.Show("ERROR AL INSERTAR DATOS DEL PLATILLO: " + err.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            if (txtBuscar.Text != "" && cbOpcion.Text != "")
            {
                string campo;
                if (cbOpcion.Text == "Codigo")
                {
                    campo = "idPlatillo";
                }
                else if (cbOpcion.Text == "Nombre")
                {
                    campo = "Nombre_Platillo";
                }
                else
                {
                    campo = "Categoria";
                }
                dtPlatillo.DataSource = obj.buscarRegistro(campo, txtBuscar.Text);
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

        private void dtPlatillo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            this.txtCodigoPlatillo.Text = dtPlatillo.SelectedRows[0].Cells[0].Value.ToString();
            this.txtNombrePlatillo.Text = dtPlatillo.SelectedRows[0].Cells[1].Value.ToString();
            this.nPrecio.Text = dtPlatillo.SelectedRows[0].Cells[2].Value.ToString();
            this.txtDescripcionPlatillo.Text = dtPlatillo.SelectedRows[0].Cells[3].Value.ToString();
            this.cbCategoriaPlatillo.Text = dtPlatillo.SelectedRows[0].Cells[4].Value.ToString();
        }

        private void frmPlatillo_Load(object sender, EventArgs e)
        {
            cargar();
            ListarCategoria();
        }
    }
}
