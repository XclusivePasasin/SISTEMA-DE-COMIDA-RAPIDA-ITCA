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
    public partial class frmVerOrdenes : Form
    {
        ClsVerPedido vp = new ClsVerPedido();
        public frmVerOrdenes()
        {
            InitializeComponent();
        }

        private void cargar()
        {
            dtVerPedidos.DataSource = vp.getDatos();
        }
        private void ListarEstados()
        {
            cbEstado.DisplayMember = "Tipo_Estado";
            cbEstado.ValueMember = "idEstado_Pedido";
            cbEstado.DataSource = vp.getDatos("Estado_Pedido");
        }
        private void ListarEstadosNuevos()
        {
            cbEstadoNuevo.DisplayMember = "Tipo_Estado";
            cbEstadoNuevo.ValueMember = "idEstado_Pedido";
            cbEstadoNuevo.DataSource = vp.getDatos("Estado_Pedido");
        }



        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            if (DateTime.TryParse(txtFecha.Text, out DateTime fecha))
            {
                int idEstadoPedido = (int)cbEstado.SelectedValue; // Obtén el ID del estado seleccionado desde el ComboBox.

                dtVerPedidos.DataSource = vp.buscarRegistro(fecha, idEstadoPedido);

                // Procede a mostrar los resultados en tu aplicación.
            }
            else
            {
                MessageBox.Show("La fecha ingresada no es válida.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmVerOrdenes_Load(object sender, EventArgs e)
        {
            DateTime fecha = DateTime.Now;
            string dataFecha = fecha.ToString("yyyy-MM-dd");
            txtFecha.Text = dataFecha;
            ListarEstados();
            cargar();
        }
        private void LimpiarCampos()
        {
            txtCodigoPedido.Text = "";
            cbEstadoNuevo.Text = "";
        }
        private void dtVerPedidos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ListarEstadosNuevos();
            this.txtCodigoPedido.Text = dtVerPedidos.SelectedRows[0].Cells[0].Value.ToString();
            this.cbEstadoNuevo.Text = dtVerPedidos.SelectedRows[0].Cells[4].Value.ToString();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                //Mandamos La Informacion Por Medio Del obj y Los Insertamos,Luego Limpiamos Campos y Cargamos Los Nuevos Datos
                vp.IdPedido = Convert.ToInt32(txtCodigoPedido.Text);
                vp.IdEstadoPedido = Convert.ToInt32(cbEstadoNuevo.SelectedValue);
                vp.modificarDatos(vp);
                LimpiarCampos();
                cargar();
            }
            catch (Exception err)
            {
                MessageBox.Show("ERROR AL ACTUALIZAR PEDIDO: " + err.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
