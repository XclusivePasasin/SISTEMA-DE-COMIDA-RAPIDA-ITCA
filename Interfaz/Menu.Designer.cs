﻿
namespace SIVARS_BURGUERS.Interfaz
{
    partial class frmMenu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMenu));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnMesa = new System.Windows.Forms.Button();
            this.btnCerrarSesion = new System.Windows.Forms.Button();
            this.panelSubMenu = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnReportePorCategoria = new System.Windows.Forms.Button();
            this.btnReportePorSemana = new System.Windows.Forms.Button();
            this.btnReportePorDia = new System.Windows.Forms.Button();
            this.btnReportes = new System.Windows.Forms.Button();
            this.btnClientes = new System.Windows.Forms.Button();
            this.btnCobros = new System.Windows.Forms.Button();
            this.btnOrdenesPendientes = new System.Windows.Forms.Button();
            this.btnOrdenes = new System.Windows.Forms.Button();
            this.btnPedido = new System.Windows.Forms.Button();
            this.btnPlatillo = new System.Windows.Forms.Button();
            this.btnCategorias = new System.Windows.Forms.Button();
            this.btnUsuarios = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.pictureLogo = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.lblAcceso = new System.Windows.Forms.Label();
            this.lblBienvenida = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.panelDeskTop = new System.Windows.Forms.Panel();
            this.lbFecha = new System.Windows.Forms.Label();
            this.lbHora = new System.Windows.Forms.Label();
            this.pLogo = new System.Windows.Forms.PictureBox();
            this.tiempo = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            this.panelSubMenu.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureLogo)).BeginInit();
            this.panel2.SuspendLayout();
            this.panelDeskTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(60)))), ((int)(((byte)(117)))));
            this.panel1.Controls.Add(this.btnMesa);
            this.panel1.Controls.Add(this.btnCerrarSesion);
            this.panel1.Controls.Add(this.panelSubMenu);
            this.panel1.Controls.Add(this.btnReportes);
            this.panel1.Controls.Add(this.btnClientes);
            this.panel1.Controls.Add(this.btnCobros);
            this.panel1.Controls.Add(this.btnOrdenesPendientes);
            this.panel1.Controls.Add(this.btnOrdenes);
            this.panel1.Controls.Add(this.btnPedido);
            this.panel1.Controls.Add(this.btnPlatillo);
            this.panel1.Controls.Add(this.btnCategorias);
            this.panel1.Controls.Add(this.btnUsuarios);
            this.panel1.Controls.Add(this.flowLayoutPanel1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(160, 698);
            this.panel1.TabIndex = 0;
            // 
            // btnMesa
            // 
            this.btnMesa.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(71)))), ((int)(((byte)(171)))));
            this.btnMesa.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMesa.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnMesa.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnMesa.Font = new System.Drawing.Font("Microsoft YaHei", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMesa.ForeColor = System.Drawing.Color.White;
            this.btnMesa.Image = ((System.Drawing.Image)(resources.GetObject("btnMesa.Image")));
            this.btnMesa.Location = new System.Drawing.Point(0, 593);
            this.btnMesa.Name = "btnMesa";
            this.btnMesa.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btnMesa.Size = new System.Drawing.Size(160, 48);
            this.btnMesa.TabIndex = 15;
            this.btnMesa.Text = "Mesas";
            this.btnMesa.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMesa.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnMesa.UseVisualStyleBackColor = false;
            this.btnMesa.Click += new System.EventHandler(this.btnMesa_Click);
            // 
            // btnCerrarSesion
            // 
            this.btnCerrarSesion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(71)))), ((int)(((byte)(171)))));
            this.btnCerrarSesion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCerrarSesion.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCerrarSesion.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnCerrarSesion.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCerrarSesion.Font = new System.Drawing.Font("Microsoft YaHei", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCerrarSesion.ForeColor = System.Drawing.Color.White;
            this.btnCerrarSesion.Image = ((System.Drawing.Image)(resources.GetObject("btnCerrarSesion.Image")));
            this.btnCerrarSesion.Location = new System.Drawing.Point(0, 650);
            this.btnCerrarSesion.Name = "btnCerrarSesion";
            this.btnCerrarSesion.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btnCerrarSesion.Size = new System.Drawing.Size(160, 48);
            this.btnCerrarSesion.TabIndex = 14;
            this.btnCerrarSesion.Text = "Cerrar Sesion";
            this.btnCerrarSesion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCerrarSesion.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCerrarSesion.UseVisualStyleBackColor = false;
            this.btnCerrarSesion.Click += new System.EventHandler(this.btnCerrarSesion_Click);
            // 
            // panelSubMenu
            // 
            this.panelSubMenu.Controls.Add(this.panel6);
            this.panelSubMenu.Controls.Add(this.panel5);
            this.panelSubMenu.Controls.Add(this.panel4);
            this.panelSubMenu.Controls.Add(this.btnReportePorCategoria);
            this.panelSubMenu.Controls.Add(this.btnReportePorSemana);
            this.panelSubMenu.Controls.Add(this.btnReportePorDia);
            this.panelSubMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSubMenu.Location = new System.Drawing.Point(0, 468);
            this.panelSubMenu.Name = "panelSubMenu";
            this.panelSubMenu.Size = new System.Drawing.Size(160, 125);
            this.panelSubMenu.TabIndex = 13;
            this.panelSubMenu.Visible = false;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(194)))), ((int)(((byte)(22)))));
            this.panel6.Location = new System.Drawing.Point(12, 77);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(10, 26);
            this.panel6.TabIndex = 18;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(193)))), ((int)(((byte)(69)))));
            this.panel5.Location = new System.Drawing.Point(12, 35);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(10, 24);
            this.panel5.TabIndex = 17;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(107)))), ((int)(((byte)(108)))));
            this.panel4.Location = new System.Drawing.Point(12, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(10, 24);
            this.panel4.TabIndex = 16;
            // 
            // btnReportePorCategoria
            // 
            this.btnReportePorCategoria.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(71)))), ((int)(((byte)(171)))));
            this.btnReportePorCategoria.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReportePorCategoria.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnReportePorCategoria.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReportePorCategoria.ForeColor = System.Drawing.Color.White;
            this.btnReportePorCategoria.Location = new System.Drawing.Point(0, 62);
            this.btnReportePorCategoria.Name = "btnReportePorCategoria";
            this.btnReportePorCategoria.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btnReportePorCategoria.Size = new System.Drawing.Size(160, 55);
            this.btnReportePorCategoria.TabIndex = 15;
            this.btnReportePorCategoria.Text = "Ventas Por Categoria";
            this.btnReportePorCategoria.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnReportePorCategoria.UseVisualStyleBackColor = false;
            this.btnReportePorCategoria.Click += new System.EventHandler(this.btnReportePorCategoria_Click);
            // 
            // btnReportePorSemana
            // 
            this.btnReportePorSemana.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(71)))), ((int)(((byte)(171)))));
            this.btnReportePorSemana.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReportePorSemana.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnReportePorSemana.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReportePorSemana.ForeColor = System.Drawing.Color.White;
            this.btnReportePorSemana.Location = new System.Drawing.Point(0, 31);
            this.btnReportePorSemana.Name = "btnReportePorSemana";
            this.btnReportePorSemana.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btnReportePorSemana.Size = new System.Drawing.Size(160, 31);
            this.btnReportePorSemana.TabIndex = 14;
            this.btnReportePorSemana.Text = "   Ventas Semanales";
            this.btnReportePorSemana.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnReportePorSemana.UseVisualStyleBackColor = false;
            this.btnReportePorSemana.Click += new System.EventHandler(this.button5_Click);
            // 
            // btnReportePorDia
            // 
            this.btnReportePorDia.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(71)))), ((int)(((byte)(171)))));
            this.btnReportePorDia.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReportePorDia.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnReportePorDia.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReportePorDia.ForeColor = System.Drawing.Color.White;
            this.btnReportePorDia.Location = new System.Drawing.Point(0, 0);
            this.btnReportePorDia.Name = "btnReportePorDia";
            this.btnReportePorDia.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btnReportePorDia.Size = new System.Drawing.Size(160, 31);
            this.btnReportePorDia.TabIndex = 13;
            this.btnReportePorDia.Text = "Ventas Del Dia";
            this.btnReportePorDia.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnReportePorDia.UseVisualStyleBackColor = false;
            this.btnReportePorDia.Click += new System.EventHandler(this.button4_Click);
            // 
            // btnReportes
            // 
            this.btnReportes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(71)))), ((int)(((byte)(171)))));
            this.btnReportes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReportes.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnReportes.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnReportes.Font = new System.Drawing.Font("Microsoft YaHei", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReportes.ForeColor = System.Drawing.Color.White;
            this.btnReportes.Image = ((System.Drawing.Image)(resources.GetObject("btnReportes.Image")));
            this.btnReportes.Location = new System.Drawing.Point(0, 420);
            this.btnReportes.Name = "btnReportes";
            this.btnReportes.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btnReportes.Size = new System.Drawing.Size(160, 48);
            this.btnReportes.TabIndex = 12;
            this.btnReportes.Text = " Reportes";
            this.btnReportes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReportes.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnReportes.UseVisualStyleBackColor = false;
            this.btnReportes.Click += new System.EventHandler(this.btnReportes_Click);
            // 
            // btnClientes
            // 
            this.btnClientes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(71)))), ((int)(((byte)(171)))));
            this.btnClientes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClientes.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnClientes.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnClientes.Font = new System.Drawing.Font("Microsoft YaHei", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClientes.ForeColor = System.Drawing.Color.White;
            this.btnClientes.Image = ((System.Drawing.Image)(resources.GetObject("btnClientes.Image")));
            this.btnClientes.Location = new System.Drawing.Point(0, 372);
            this.btnClientes.Name = "btnClientes";
            this.btnClientes.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btnClientes.Size = new System.Drawing.Size(160, 48);
            this.btnClientes.TabIndex = 11;
            this.btnClientes.Text = "Clientes";
            this.btnClientes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClientes.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnClientes.UseVisualStyleBackColor = false;
            this.btnClientes.Click += new System.EventHandler(this.btnClientes_Click);
            // 
            // btnCobros
            // 
            this.btnCobros.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(71)))), ((int)(((byte)(171)))));
            this.btnCobros.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCobros.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnCobros.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCobros.Font = new System.Drawing.Font("Microsoft YaHei", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCobros.ForeColor = System.Drawing.Color.White;
            this.btnCobros.Image = ((System.Drawing.Image)(resources.GetObject("btnCobros.Image")));
            this.btnCobros.Location = new System.Drawing.Point(0, 324);
            this.btnCobros.Name = "btnCobros";
            this.btnCobros.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btnCobros.Size = new System.Drawing.Size(160, 48);
            this.btnCobros.TabIndex = 10;
            this.btnCobros.Text = " Cobros";
            this.btnCobros.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCobros.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCobros.UseVisualStyleBackColor = false;
            this.btnCobros.Click += new System.EventHandler(this.btnCobros_Click);
            // 
            // btnOrdenesPendientes
            // 
            this.btnOrdenesPendientes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(71)))), ((int)(((byte)(171)))));
            this.btnOrdenesPendientes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOrdenesPendientes.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnOrdenesPendientes.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnOrdenesPendientes.Font = new System.Drawing.Font("Microsoft YaHei", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOrdenesPendientes.ForeColor = System.Drawing.Color.White;
            this.btnOrdenesPendientes.Image = ((System.Drawing.Image)(resources.GetObject("btnOrdenesPendientes.Image")));
            this.btnOrdenesPendientes.Location = new System.Drawing.Point(0, 271);
            this.btnOrdenesPendientes.Name = "btnOrdenesPendientes";
            this.btnOrdenesPendientes.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.btnOrdenesPendientes.Size = new System.Drawing.Size(160, 53);
            this.btnOrdenesPendientes.TabIndex = 8;
            this.btnOrdenesPendientes.Text = " Ordenes Pendientes";
            this.btnOrdenesPendientes.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnOrdenesPendientes.UseVisualStyleBackColor = false;
            this.btnOrdenesPendientes.Click += new System.EventHandler(this.btnOrdenesPendientes_Click);
            // 
            // btnOrdenes
            // 
            this.btnOrdenes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(71)))), ((int)(((byte)(171)))));
            this.btnOrdenes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOrdenes.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnOrdenes.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnOrdenes.Font = new System.Drawing.Font("Microsoft YaHei", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOrdenes.ForeColor = System.Drawing.Color.White;
            this.btnOrdenes.Image = ((System.Drawing.Image)(resources.GetObject("btnOrdenes.Image")));
            this.btnOrdenes.Location = new System.Drawing.Point(0, 232);
            this.btnOrdenes.Name = "btnOrdenes";
            this.btnOrdenes.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.btnOrdenes.Size = new System.Drawing.Size(160, 39);
            this.btnOrdenes.TabIndex = 7;
            this.btnOrdenes.Text = "Ordenes";
            this.btnOrdenes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOrdenes.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnOrdenes.UseVisualStyleBackColor = false;
            this.btnOrdenes.Click += new System.EventHandler(this.btnOrdenes_Click);
            // 
            // btnPedido
            // 
            this.btnPedido.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(71)))), ((int)(((byte)(171)))));
            this.btnPedido.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPedido.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnPedido.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnPedido.Font = new System.Drawing.Font("Microsoft YaHei", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPedido.ForeColor = System.Drawing.Color.White;
            this.btnPedido.Image = ((System.Drawing.Image)(resources.GetObject("btnPedido.Image")));
            this.btnPedido.Location = new System.Drawing.Point(0, 193);
            this.btnPedido.Name = "btnPedido";
            this.btnPedido.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.btnPedido.Size = new System.Drawing.Size(160, 39);
            this.btnPedido.TabIndex = 6;
            this.btnPedido.Text = "  Pedidos";
            this.btnPedido.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPedido.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPedido.UseVisualStyleBackColor = false;
            this.btnPedido.Click += new System.EventHandler(this.btnPedido_Click);
            // 
            // btnPlatillo
            // 
            this.btnPlatillo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(71)))), ((int)(((byte)(171)))));
            this.btnPlatillo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPlatillo.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnPlatillo.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnPlatillo.Font = new System.Drawing.Font("Microsoft YaHei", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPlatillo.ForeColor = System.Drawing.Color.White;
            this.btnPlatillo.Image = ((System.Drawing.Image)(resources.GetObject("btnPlatillo.Image")));
            this.btnPlatillo.Location = new System.Drawing.Point(0, 154);
            this.btnPlatillo.Name = "btnPlatillo";
            this.btnPlatillo.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.btnPlatillo.Size = new System.Drawing.Size(160, 39);
            this.btnPlatillo.TabIndex = 5;
            this.btnPlatillo.Text = "  Platillos";
            this.btnPlatillo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPlatillo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPlatillo.UseVisualStyleBackColor = false;
            this.btnPlatillo.Click += new System.EventHandler(this.btnPlatillo_Click);
            // 
            // btnCategorias
            // 
            this.btnCategorias.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(71)))), ((int)(((byte)(171)))));
            this.btnCategorias.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCategorias.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCategorias.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnCategorias.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCategorias.Font = new System.Drawing.Font("Microsoft YaHei", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCategorias.ForeColor = System.Drawing.Color.White;
            this.btnCategorias.Image = ((System.Drawing.Image)(resources.GetObject("btnCategorias.Image")));
            this.btnCategorias.Location = new System.Drawing.Point(0, 115);
            this.btnCategorias.Name = "btnCategorias";
            this.btnCategorias.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnCategorias.Size = new System.Drawing.Size(160, 39);
            this.btnCategorias.TabIndex = 4;
            this.btnCategorias.Text = " Categorias";
            this.btnCategorias.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCategorias.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCategorias.UseVisualStyleBackColor = false;
            this.btnCategorias.Click += new System.EventHandler(this.btnCategorias_Click);
            // 
            // btnUsuarios
            // 
            this.btnUsuarios.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(71)))), ((int)(((byte)(171)))));
            this.btnUsuarios.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUsuarios.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnUsuarios.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnUsuarios.Font = new System.Drawing.Font("Microsoft YaHei", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUsuarios.ForeColor = System.Drawing.Color.White;
            this.btnUsuarios.Image = ((System.Drawing.Image)(resources.GetObject("btnUsuarios.Image")));
            this.btnUsuarios.Location = new System.Drawing.Point(0, 76);
            this.btnUsuarios.Name = "btnUsuarios";
            this.btnUsuarios.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnUsuarios.Size = new System.Drawing.Size(160, 39);
            this.btnUsuarios.TabIndex = 3;
            this.btnUsuarios.Text = "  Usuarios";
            this.btnUsuarios.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUsuarios.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnUsuarios.UseVisualStyleBackColor = false;
            this.btnUsuarios.Click += new System.EventHandler(this.btnUsuarios_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(71)))), ((int)(((byte)(171)))));
            this.flowLayoutPanel1.Controls.Add(this.pictureLogo);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(160, 76);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // pictureLogo
            // 
            this.pictureLogo.Image = ((System.Drawing.Image)(resources.GetObject("pictureLogo.Image")));
            this.pictureLogo.Location = new System.Drawing.Point(3, 3);
            this.pictureLogo.Name = "pictureLogo";
            this.pictureLogo.Size = new System.Drawing.Size(154, 73);
            this.pictureLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureLogo.TabIndex = 0;
            this.pictureLogo.TabStop = false;
            this.pictureLogo.UseWaitCursor = true;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(60)))), ((int)(((byte)(117)))));
            this.panel2.Controls.Add(this.btnCerrar);
            this.panel2.Controls.Add(this.lblTitulo);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(160, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(785, 76);
            this.panel2.TabIndex = 1;
            // 
            // btnCerrar
            // 
            this.btnCerrar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(60)))), ((int)(((byte)(117)))));
            this.btnCerrar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCerrar.Image = ((System.Drawing.Image)(resources.GetObject("btnCerrar.Image")));
            this.btnCerrar.Location = new System.Drawing.Point(697, 12);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(59, 51);
            this.btnCerrar.TabIndex = 1;
            this.btnCerrar.UseVisualStyleBackColor = false;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft YaHei", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(281, 20);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(202, 28);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "MENU PRINCIPAL";
            // 
            // lblUsuario
            // 
            this.lblUsuario.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Font = new System.Drawing.Font("Microsoft YaHei", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsuario.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(71)))), ((int)(((byte)(171)))));
            this.lblUsuario.Location = new System.Drawing.Point(339, 319);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(107, 31);
            this.lblUsuario.TabIndex = 2;
            this.lblUsuario.Text = "Usuario:";
            // 
            // lblAcceso
            // 
            this.lblAcceso.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblAcceso.AutoSize = true;
            this.lblAcceso.Font = new System.Drawing.Font("Microsoft YaHei", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAcceso.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(71)))), ((int)(((byte)(171)))));
            this.lblAcceso.Location = new System.Drawing.Point(339, 367);
            this.lblAcceso.Name = "lblAcceso";
            this.lblAcceso.Size = new System.Drawing.Size(184, 31);
            this.lblAcceso.TabIndex = 3;
            this.lblAcceso.Text = "Rol De Acceso:";
            // 
            // lblBienvenida
            // 
            this.lblBienvenida.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblBienvenida.AutoSize = true;
            this.lblBienvenida.Font = new System.Drawing.Font("Microsoft YaHei", 44.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBienvenida.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(71)))), ((int)(((byte)(171)))));
            this.lblBienvenida.Location = new System.Drawing.Point(320, 239);
            this.lblBienvenida.Name = "lblBienvenida";
            this.lblBienvenida.Size = new System.Drawing.Size(363, 78);
            this.lblBienvenida.TabIndex = 4;
            this.lblBienvenida.Text = "Bienvenido";
            // 
            // panelDeskTop
            // 
            this.panelDeskTop.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.panelDeskTop.BackColor = System.Drawing.Color.White;
            this.panelDeskTop.Controls.Add(this.lbFecha);
            this.panelDeskTop.Controls.Add(this.lbHora);
            this.panelDeskTop.Controls.Add(this.lblAcceso);
            this.panelDeskTop.Controls.Add(this.lblBienvenida);
            this.panelDeskTop.Controls.Add(this.lblUsuario);
            this.panelDeskTop.Controls.Add(this.pLogo);
            this.panelDeskTop.Location = new System.Drawing.Point(160, 76);
            this.panelDeskTop.Name = "panelDeskTop";
            this.panelDeskTop.Size = new System.Drawing.Size(785, 622);
            this.panelDeskTop.TabIndex = 5;
            // 
            // lbFecha
            // 
            this.lbFecha.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lbFecha.AutoSize = true;
            this.lbFecha.Font = new System.Drawing.Font("Microsoft YaHei UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbFecha.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(71)))), ((int)(((byte)(171)))));
            this.lbFecha.Location = new System.Drawing.Point(218, 93);
            this.lbFecha.Name = "lbFecha";
            this.lbFecha.Size = new System.Drawing.Size(81, 31);
            this.lbFecha.TabIndex = 7;
            this.lbFecha.Text = "Fecha";
            // 
            // lbHora
            // 
            this.lbHora.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lbHora.AutoSize = true;
            this.lbHora.Font = new System.Drawing.Font("Century Gothic", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbHora.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(71)))), ((int)(((byte)(171)))));
            this.lbHora.Location = new System.Drawing.Point(253, 35);
            this.lbHora.Name = "lbHora";
            this.lbHora.Size = new System.Drawing.Size(136, 58);
            this.lbHora.TabIndex = 6;
            this.lbHora.Text = "Hora";
            // 
            // pLogo
            // 
            this.pLogo.ErrorImage = null;
            this.pLogo.Image = ((System.Drawing.Image)(resources.GetObject("pLogo.Image")));
            this.pLogo.Location = new System.Drawing.Point(-181, 54);
            this.pLogo.Name = "pLogo";
            this.pLogo.Size = new System.Drawing.Size(768, 534);
            this.pLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pLogo.TabIndex = 5;
            this.pLogo.TabStop = false;
            // 
            // tiempo
            // 
            this.tiempo.Tick += new System.EventHandler(this.tiempo_Tick);
            // 
            // frmMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(945, 698);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelDeskTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmMenu";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menu";
            this.Load += new System.EventHandler(this.frmMenu_Load);
            this.panel1.ResumeLayout(false);
            this.panelSubMenu.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureLogo)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panelDeskTop.ResumeLayout(false);
            this.panelDeskTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pLogo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnCategorias;
        private System.Windows.Forms.Button btnUsuarios;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.PictureBox pictureLogo;
        private System.Windows.Forms.Button btnOrdenesPendientes;
        private System.Windows.Forms.Button btnOrdenes;
        private System.Windows.Forms.Button btnPedido;
        private System.Windows.Forms.Button btnPlatillo;
        private System.Windows.Forms.Button btnClientes;
        private System.Windows.Forms.Button btnCobros;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.Label lblAcceso;
        private System.Windows.Forms.Label lblBienvenida;
        private System.Windows.Forms.Panel panelSubMenu;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button btnReportePorCategoria;
        private System.Windows.Forms.Button btnReportePorSemana;
        private System.Windows.Forms.Button btnReportePorDia;
        private System.Windows.Forms.Button btnReportes;
        private System.Windows.Forms.Button btnCerrarSesion;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Panel panelDeskTop;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.Button btnMesa;
        private System.Windows.Forms.PictureBox pLogo;
        private System.Windows.Forms.Label lbFecha;
        private System.Windows.Forms.Label lbHora;
        private System.Windows.Forms.Timer tiempo;
    }
}