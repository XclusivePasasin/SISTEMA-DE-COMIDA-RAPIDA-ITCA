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
    public partial class frmMenu : Form
    {
        private Form activeForm;
        public frmMenu()
        {
            InitializeComponent();
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            string mensaje = "¿Seguro Que Desea Cerrar Sesion?";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            MessageBoxIcon icon = MessageBoxIcon.Question;
            DialogResult resultado = MessageBox.Show(mensaje, "Cierre De Sesion", buttons, icon);
            if (resultado == DialogResult.Yes)
            {
                //Cerrar Un Formulario De Menu y Mostrar El Formulario De Login
                this.Close();
            }
        }
        private void Reset()//Metodo para cargar inicio de nuevo
        {
            lblTitulo.Text = "MENU PRINCIPAL";
            lblBienvenida.Text = "BIENVENIDO";
            lblUsuario.Visible = true; 
            lblAcceso.Visible = true;
            btnCerrar.Visible = false;
        }
        private void OpenChildForm(Form childForm, object btnSender)
        {
            if (activeForm != null)
            activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.panelDeskTop.Controls.Add(childForm);
            this.panelDeskTop.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            lblTitulo.Text = childForm.Text;
            btnCerrar.Visible = true;
        }

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            panelSubMenu.Visible = false;
            lblUsuario.Visible = false;
            lblAcceso.Visible = false;
            OpenChildForm(new frmUsuarios(), sender);
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            if (activeForm != null)
                activeForm.Close();
            Reset();
        }

        private void frmMenu_Load(object sender, EventArgs e)
        {
            lblUsuario.Text = "Usuario: " + CacheUsuario.nombre;
            lblAcceso.Text = "Nivel De Acceso: " + CacheUsuario.rol;
            if (CacheUsuario.rol == "Cajero")
            {
                panelSubMenu.Visible = false;
            }
            else if (CacheUsuario.rol == "Mesero")
            {
                btnClientes.Visible = false;
                btnCobros.Visible = false;
                btnPlatillo.Visible = false;
                btnReportes.Visible = false;
                panelSubMenu.Visible = false;
                btnCategorias.Visible = false;
                btnOrdenes.Visible = false;


            }
        }

        private void btnReportes_Click(object sender, EventArgs e)
        {
            panelSubMenu.Visible = true;
        }

        private void btnCategorias_Click(object sender, EventArgs e)
        {
            panelSubMenu.Visible = false;
            lblUsuario.Visible = false;
            lblAcceso.Visible = false;
            OpenChildForm(new frmCategoria(), sender);
        }

        private void btnPlatillo_Click(object sender, EventArgs e)
        {
            panelSubMenu.Visible = false;
            lblUsuario.Visible = false;
            lblAcceso.Visible = false;
            OpenChildForm(new frmPlatillo(), sender);
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            panelSubMenu.Visible = false;
            lblUsuario.Visible = false;
            lblAcceso.Visible = false;
            OpenChildForm(new frmCliente(), sender);
        }
    }
}
