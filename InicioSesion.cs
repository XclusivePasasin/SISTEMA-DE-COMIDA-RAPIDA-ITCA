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
using SIVARS_BURGUERS.Interfaz;

namespace SIVARS_BURGUERS
{
    public partial class frmInicioSesion : Form
    {
        public frmInicioSesion()
        {
            InitializeComponent();
        }
        private void GetMensaje(string mensaje)
        {
            MessageBoxButtons buttons = MessageBoxButtons.OK;
            MessageBoxIcon icon = MessageBoxIcon.Warning;
            MessageBox.Show(mensaje, "INFORMACION", buttons, icon);

        }

        private void frmInicioSesion_Load(object sender, EventArgs e)
        {

        }

        private void btnIniciarSesion_Click(object sender, EventArgs e)
        {

            if (txtUsuario.Text != "")
            {
                if (txtContraseña.Text != "")
                {
                    ClsUsuario us = new ClsUsuario();
                    //SET A LOS ATRIBUTOS DE LA CLASE
                    us.Usuario = txtUsuario.Text;
                    us.Contraseña = txtContraseña.Text;
                    var ValidadLogin = us.getLogin();
                    if (ValidadLogin == true)
                    {
                        frmMenu menu = new frmMenu(); //Instancia Al Formulario Menu
                        menu.Show(); //Mostrar El Formulario Del Menu
                        //Sobrecargar El Metodo FormClose Del Formulario Menu Para Cuando Cerremos La Sesion
                        menu.FormClosed += CerrarSesion;
                        this.Hide();
                    }
                    else
                    {
                        GetMensaje("Usuario y Contraseña Incorrectos");
                    }
                }
                else
                {
                    GetMensaje("El Campo Contraseña Es Obligatorio");
                }
            }
            else
            {
                GetMensaje("El Campo Usuario Es Obligatorio");
            }
        }
        private void CerrarSesion(object sender, FormClosedEventArgs e)
        {
            txtUsuario.Text = "";
            txtContraseña.Text = "";
            this.Show();
            txtUsuario.Focus();
        }
    }
}

