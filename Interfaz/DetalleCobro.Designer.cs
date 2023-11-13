
namespace SIVARS_BURGUERS.Interfaz
{
    partial class frmDetalleCobro
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDetalleCobro));
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.nTotal = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.nRecibido = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.btnCobrar = new System.Windows.Forms.Button();
            this.nDevuelto = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nTotal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nRecibido)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nDevuelto)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(99, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(102, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(136, 126);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(46, 141);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(250, 22);
            this.label2.TabIndex = 2;
            this.label2.Text = "DETALLE COBRO DEL PEDIDO";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(50, 192);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 19);
            this.label3.TabIndex = 3;
            this.label3.Text = "Total:";
            // 
            // nTotal
            // 
            this.nTotal.DecimalPlaces = 2;
            this.nTotal.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nTotal.Increment = new decimal(new int[] {
            10,
            0,
            0,
            131072});
            this.nTotal.Location = new System.Drawing.Point(129, 190);
            this.nTotal.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nTotal.Name = "nTotal";
            this.nTotal.ReadOnly = true;
            this.nTotal.Size = new System.Drawing.Size(121, 23);
            this.nTotal.TabIndex = 4;
            this.nTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(50, 237);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 19);
            this.label4.TabIndex = 5;
            this.label4.Text = "Recibido:";
            // 
            // nRecibido
            // 
            this.nRecibido.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nRecibido.Increment = new decimal(new int[] {
            25,
            0,
            0,
            131072});
            this.nRecibido.Location = new System.Drawing.Point(129, 237);
            this.nRecibido.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nRecibido.Name = "nRecibido";
            this.nRecibido.Size = new System.Drawing.Size(121, 23);
            this.nRecibido.TabIndex = 6;
            this.nRecibido.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nRecibido.ValueChanged += new System.EventHandler(this.nRecibido_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(50, 285);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 19);
            this.label5.TabIndex = 7;
            this.label5.Text = "Devuelto:";
            // 
            // btnCobrar
            // 
            this.btnCobrar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(154)))), ((int)(((byte)(67)))));
            this.btnCobrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCobrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCobrar.Font = new System.Drawing.Font("Microsoft YaHei UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCobrar.ForeColor = System.Drawing.Color.White;
            this.btnCobrar.Image = ((System.Drawing.Image)(resources.GetObject("btnCobrar.Image")));
            this.btnCobrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCobrar.Location = new System.Drawing.Point(78, 335);
            this.btnCobrar.Name = "btnCobrar";
            this.btnCobrar.Padding = new System.Windows.Forms.Padding(6, 0, 12, 0);
            this.btnCobrar.Size = new System.Drawing.Size(181, 43);
            this.btnCobrar.TabIndex = 9;
            this.btnCobrar.Text = "Confirmar Cobro";
            this.btnCobrar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCobrar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCobrar.UseVisualStyleBackColor = false;
            this.btnCobrar.Click += new System.EventHandler(this.btnCobrar_Click);
            // 
            // nDevuelto
            // 
            this.nDevuelto.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nDevuelto.Increment = new decimal(new int[] {
            10,
            0,
            0,
            131072});
            this.nDevuelto.Location = new System.Drawing.Point(129, 285);
            this.nDevuelto.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nDevuelto.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            this.nDevuelto.Name = "nDevuelto";
            this.nDevuelto.ReadOnly = true;
            this.nDevuelto.Size = new System.Drawing.Size(121, 23);
            this.nDevuelto.TabIndex = 10;
            this.nDevuelto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // frmDetalleCobro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(337, 450);
            this.Controls.Add(this.nDevuelto);
            this.Controls.Add(this.btnCobrar);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.nRecibido);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.nTotal);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmDetalleCobro";
            this.Text = "DETALLE COBRO";
            this.Load += new System.EventHandler(this.frmDetalleCobro_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nTotal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nRecibido)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nDevuelto)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown nTotal;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown nRecibido;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnCobrar;
        private System.Windows.Forms.NumericUpDown nDevuelto;
    }
}