
namespace ControlDeEstudiantes.Capas
{
    partial class FrmLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmLogin));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panelAviso1 = new System.Windows.Forms.Panel();
            this.LblDatos = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnminimizar = new System.Windows.Forms.PictureBox();
            this.btncerrar = new System.Windows.Forms.PictureBox();
            this.btnlogin = new System.Windows.Forms.Button();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtContra = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.MenuStrip15 = new System.Windows.Forms.MenuStrip();
            this.tver = new System.Windows.Forms.ToolStripMenuItem();
            this.tocultar = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            this.panelAviso1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnminimizar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btncerrar)).BeginInit();
            this.MenuStrip15.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(100)))), ((int)(((byte)(182)))));
            this.panel1.Controls.Add(this.panelAviso1);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(250, 348);
            this.panel1.TabIndex = 2;
            // 
            // panelAviso1
            // 
            this.panelAviso1.BackColor = System.Drawing.Color.Silver;
            this.panelAviso1.Controls.Add(this.LblDatos);
            this.panelAviso1.Location = new System.Drawing.Point(0, 272);
            this.panelAviso1.Name = "panelAviso1";
            this.panelAviso1.Size = new System.Drawing.Size(250, 40);
            this.panelAviso1.TabIndex = 1;
            this.panelAviso1.Visible = false;
            // 
            // LblDatos
            // 
            this.LblDatos.AutoSize = true;
            this.LblDatos.Font = new System.Drawing.Font("Microsoft YaHei", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblDatos.ForeColor = System.Drawing.Color.Red;
            this.LblDatos.Location = new System.Drawing.Point(35, 7);
            this.LblDatos.Name = "LblDatos";
            this.LblDatos.Size = new System.Drawing.Size(181, 26);
            this.LblDatos.TabIndex = 0;
            this.LblDatos.Text = "Datos Incorecctos";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(26, 53);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(204, 218);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(415, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 32);
            this.label1.TabIndex = 5;
            this.label1.Text = "LOGIN";
            // 
            // btnminimizar
            // 
            this.btnminimizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnminimizar.Image = ((System.Drawing.Image)(resources.GetObject("btnminimizar.Image")));
            this.btnminimizar.Location = new System.Drawing.Point(620, 2);
            this.btnminimizar.Name = "btnminimizar";
            this.btnminimizar.Size = new System.Drawing.Size(15, 15);
            this.btnminimizar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnminimizar.TabIndex = 10;
            this.btnminimizar.TabStop = false;
            this.btnminimizar.Click += new System.EventHandler(this.btnminimizar_Click);
            // 
            // btncerrar
            // 
            this.btncerrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btncerrar.Image = ((System.Drawing.Image)(resources.GetObject("btncerrar.Image")));
            this.btncerrar.Location = new System.Drawing.Point(641, 2);
            this.btncerrar.Name = "btncerrar";
            this.btncerrar.Size = new System.Drawing.Size(15, 15);
            this.btncerrar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btncerrar.TabIndex = 9;
            this.btncerrar.TabStop = false;
            this.btncerrar.Click += new System.EventHandler(this.btncerrar_Click);
            // 
            // btnlogin
            // 
            this.btnlogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(53)))), ((int)(((byte)(73)))));
            this.btnlogin.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(159)))), ((int)(((byte)(127)))));
            this.btnlogin.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.btnlogin.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(118)))), ((int)(((byte)(126)))));
            this.btnlogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnlogin.ForeColor = System.Drawing.Color.LightGray;
            this.btnlogin.Location = new System.Drawing.Point(330, 265);
            this.btnlogin.Name = "btnlogin";
            this.btnlogin.Size = new System.Drawing.Size(274, 47);
            this.btnlogin.TabIndex = 11;
            this.btnlogin.Text = "ACCEDER";
            this.btnlogin.UseVisualStyleBackColor = false;
            this.btnlogin.Click += new System.EventHandler(this.btnlogin_Click);
            // 
            // txtUsuario
            // 
            this.txtUsuario.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.txtUsuario.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUsuario.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtUsuario.Font = new System.Drawing.Font("Century Gothic", 12F);
            this.txtUsuario.Location = new System.Drawing.Point(406, 123);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(184, 27);
            this.txtUsuario.TabIndex = 15;
            this.txtUsuario.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            this.txtUsuario.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtUsuario_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 12F);
            this.label2.ForeColor = System.Drawing.Color.Silver;
            this.label2.Location = new System.Drawing.Point(301, 126);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 21);
            this.label2.TabIndex = 16;
            this.label2.Text = "Usuario.........:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 12F);
            this.label3.ForeColor = System.Drawing.Color.Silver;
            this.label3.Location = new System.Drawing.Point(301, 177);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 21);
            this.label3.TabIndex = 17;
            this.label3.Text = "Contraseña:";
            // 
            // txtContra
            // 
            this.txtContra.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.txtContra.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtContra.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtContra.Font = new System.Drawing.Font("Century Gothic", 12F);
            this.txtContra.Location = new System.Drawing.Point(406, 174);
            this.txtContra.Name = "txtContra";
            this.txtContra.Size = new System.Drawing.Size(184, 27);
            this.txtContra.TabIndex = 18;
            this.txtContra.UseSystemPasswordChar = true;
            this.txtContra.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtContra_KeyPress);
            // 
            // MenuStrip15
            // 
            this.MenuStrip15.AutoSize = false;
            this.MenuStrip15.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(57)))), ((int)(((byte)(80)))));
            this.MenuStrip15.Dock = System.Windows.Forms.DockStyle.None;
            this.MenuStrip15.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tver,
            this.tocultar});
            this.MenuStrip15.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.MenuStrip15.Location = new System.Drawing.Point(588, 174);
            this.MenuStrip15.Name = "MenuStrip15";
            this.MenuStrip15.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.MenuStrip15.ShowItemToolTips = true;
            this.MenuStrip15.Size = new System.Drawing.Size(72, 28);
            this.MenuStrip15.TabIndex = 607;
            this.MenuStrip15.Text = "MenuStrip15";
            // 
            // tver
            // 
            this.tver.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(57)))), ((int)(((byte)(80)))));
            this.tver.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.tver.ForeColor = System.Drawing.Color.Black;
            this.tver.Image = ((System.Drawing.Image)(resources.GetObject("tver.Image")));
            this.tver.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tver.ImageTransparentColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tver.Name = "tver";
            this.tver.Size = new System.Drawing.Size(28, 24);
            this.tver.ToolTipText = "Ver contraseña";
            this.tver.Click += new System.EventHandler(this.tver_Click);
            // 
            // tocultar
            // 
            this.tocultar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(57)))), ((int)(((byte)(80)))));
            this.tocultar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.tocultar.ForeColor = System.Drawing.Color.Black;
            this.tocultar.Image = ((System.Drawing.Image)(resources.GetObject("tocultar.Image")));
            this.tocultar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tocultar.ImageTransparentColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tocultar.Name = "tocultar";
            this.tocultar.Size = new System.Drawing.Size(28, 24);
            this.tocultar.ToolTipText = "Ocultar contraseña";
            this.tocultar.Visible = false;
            this.tocultar.Click += new System.EventHandler(this.tocultar_Click);
            // 
            // FrmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(57)))), ((int)(((byte)(80)))));
            this.ClientSize = new System.Drawing.Size(662, 348);
            this.Controls.Add(this.txtContra);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtUsuario);
            this.Controls.Add(this.btnlogin);
            this.Controls.Add(this.btnminimizar);
            this.Controls.Add(this.btncerrar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.MenuStrip15);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmLogin";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Inicio De Seccion";
            this.Load += new System.EventHandler(this.FrmLogin_Load);
            this.panel1.ResumeLayout(false);
            this.panelAviso1.ResumeLayout(false);
            this.panelAviso1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnminimizar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btncerrar)).EndInit();
            this.MenuStrip15.ResumeLayout(false);
            this.MenuStrip15.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox btnminimizar;
        private System.Windows.Forms.PictureBox btncerrar;
        private System.Windows.Forms.Button btnlogin;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtContra;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Panel panelAviso1;
        private System.Windows.Forms.Label LblDatos;
        private System.Windows.Forms.Timer timer2;
        internal System.Windows.Forms.MenuStrip MenuStrip15;
        internal System.Windows.Forms.ToolStripMenuItem tver;
        internal System.Windows.Forms.ToolStripMenuItem tocultar;
    }
}