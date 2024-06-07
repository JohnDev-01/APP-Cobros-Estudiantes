
namespace ControlDeEstudiantes
{
    partial class FormInicio
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormInicio));
            this.dgvEstudiantes = new System.Windows.Forms.DataGridView();
            this.txtBusqueda = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.buscarPorMonto = new System.Windows.Forms.RadioButton();
            this.buscarPorCel = new System.Windows.Forms.RadioButton();
            this.buscarApellido = new System.Windows.Forms.RadioButton();
            this.BuscarPorNombre = new System.Windows.Forms.RadioButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.btn_PagosEmpleados = new System.Windows.Forms.Button();
            this.btn_Reportes = new System.Windows.Forms.Button();
            this.btn_cobrar = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblFecha = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.lblhora = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.Salidas = new System.Windows.Forms.ToolStripMenuItem();
            this.configuracionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.administradorDeUsuariosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.consultaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEstudiantes)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvEstudiantes
            // 
            this.dgvEstudiantes.AllowUserToAddRows = false;
            this.dgvEstudiantes.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Gainsboro;
            this.dgvEstudiantes.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvEstudiantes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvEstudiantes.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.dgvEstudiantes.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvEstudiantes.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvEstudiantes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.Gray;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft YaHei", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Orange;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvEstudiantes.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvEstudiantes.GridColor = System.Drawing.Color.Black;
            this.dgvEstudiantes.Location = new System.Drawing.Point(3, 3);
            this.dgvEstudiantes.Name = "dgvEstudiantes";
            this.dgvEstudiantes.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvEstudiantes.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvEstudiantes.RowHeadersVisible = false;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.Gainsboro;
            this.dgvEstudiantes.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvEstudiantes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvEstudiantes.Size = new System.Drawing.Size(1001, 486);
            this.dgvEstudiantes.TabIndex = 0;
            this.dgvEstudiantes.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvEstudiantes_CellContentClick);
            this.dgvEstudiantes.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvEstudiantes_CellContentDoubleClick);
            // 
            // txtBusqueda
            // 
            this.txtBusqueda.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.txtBusqueda.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtBusqueda.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBusqueda.ForeColor = System.Drawing.Color.White;
            this.txtBusqueda.Location = new System.Drawing.Point(96, 53);
            this.txtBusqueda.Name = "txtBusqueda";
            this.txtBusqueda.Size = new System.Drawing.Size(679, 29);
            this.txtBusqueda.TabIndex = 5;
            this.txtBusqueda.TextChanged += new System.EventHandler(this.txtBusquedaChanged);
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Controls.Add(this.buscarPorMonto);
            this.panel3.Controls.Add(this.buscarPorCel);
            this.panel3.Controls.Add(this.buscarApellido);
            this.panel3.Controls.Add(this.BuscarPorNombre);
            this.panel3.Location = new System.Drawing.Point(781, 52);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(242, 30);
            this.panel3.TabIndex = 9;
            // 
            // buscarPorMonto
            // 
            this.buscarPorMonto.AutoSize = true;
            this.buscarPorMonto.Location = new System.Drawing.Point(184, 5);
            this.buscarPorMonto.Name = "buscarPorMonto";
            this.buscarPorMonto.Size = new System.Drawing.Size(55, 17);
            this.buscarPorMonto.TabIndex = 3;
            this.buscarPorMonto.TabStop = true;
            this.buscarPorMonto.Text = "Monto";
            this.buscarPorMonto.UseVisualStyleBackColor = true;
            // 
            // buscarPorCel
            // 
            this.buscarPorCel.AutoSize = true;
            this.buscarPorCel.Location = new System.Drawing.Point(135, 5);
            this.buscarPorCel.Name = "buscarPorCel";
            this.buscarPorCel.Size = new System.Drawing.Size(43, 17);
            this.buscarPorCel.TabIndex = 2;
            this.buscarPorCel.TabStop = true;
            this.buscarPorCel.Text = "Cel.";
            this.buscarPorCel.UseVisualStyleBackColor = true;
            // 
            // buscarApellido
            // 
            this.buscarApellido.AutoSize = true;
            this.buscarApellido.Location = new System.Drawing.Point(69, 5);
            this.buscarApellido.Name = "buscarApellido";
            this.buscarApellido.Size = new System.Drawing.Size(62, 17);
            this.buscarApellido.TabIndex = 1;
            this.buscarApellido.TabStop = true;
            this.buscarApellido.Text = "Apellido";
            this.buscarApellido.UseVisualStyleBackColor = true;
            // 
            // BuscarPorNombre
            // 
            this.BuscarPorNombre.AutoSize = true;
            this.BuscarPorNombre.Checked = true;
            this.BuscarPorNombre.Location = new System.Drawing.Point(4, 5);
            this.BuscarPorNombre.Name = "BuscarPorNombre";
            this.BuscarPorNombre.Size = new System.Drawing.Size(62, 17);
            this.BuscarPorNombre.TabIndex = 0;
            this.BuscarPorNombre.TabStop = true;
            this.BuscarPorNombre.Text = "Nombre";
            this.BuscarPorNombre.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(1051, 88);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(303, 328);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 13;
            this.pictureBox1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Silver;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.btnActualizar);
            this.panel1.Controls.Add(this.btn_PagosEmpleados);
            this.panel1.Controls.Add(this.btn_Reportes);
            this.panel1.Controls.Add(this.btn_cobrar);
            this.panel1.Controls.Add(this.btnEditar);
            this.panel1.Controls.Add(this.btnNuevo);
            this.panel1.Controls.Add(this.btnEliminar);
            this.panel1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panel1.Location = new System.Drawing.Point(12, 589);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1011, 114);
            this.panel1.TabIndex = 18;
            // 
            // btnActualizar
            // 
            this.btnActualizar.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.btnActualizar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnActualizar.Font = new System.Drawing.Font("Microsoft YaHei", 14.25F);
            this.btnActualizar.ForeColor = System.Drawing.Color.Maroon;
            this.btnActualizar.Location = new System.Drawing.Point(793, 31);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(198, 43);
            this.btnActualizar.TabIndex = 34;
            this.btnActualizar.Text = "Resfrecar Datos...";
            this.btnActualizar.UseVisualStyleBackColor = false;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // btn_PagosEmpleados
            // 
            this.btn_PagosEmpleados.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.btn_PagosEmpleados.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_PagosEmpleados.Font = new System.Drawing.Font("Microsoft YaHei", 14.25F);
            this.btn_PagosEmpleados.ForeColor = System.Drawing.Color.Maroon;
            this.btn_PagosEmpleados.Location = new System.Drawing.Point(563, 7);
            this.btn_PagosEmpleados.Name = "btn_PagosEmpleados";
            this.btn_PagosEmpleados.Size = new System.Drawing.Size(198, 43);
            this.btn_PagosEmpleados.TabIndex = 35;
            this.btn_PagosEmpleados.Text = "Pagos Empleados";
            this.btn_PagosEmpleados.UseVisualStyleBackColor = false;
            this.btn_PagosEmpleados.Click += new System.EventHandler(this.btn_PagosEmpleados_Click);
            // 
            // btn_Reportes
            // 
            this.btn_Reportes.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.btn_Reportes.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_Reportes.Font = new System.Drawing.Font("Microsoft YaHei", 14.25F);
            this.btn_Reportes.ForeColor = System.Drawing.Color.Maroon;
            this.btn_Reportes.Location = new System.Drawing.Point(563, 56);
            this.btn_Reportes.Name = "btn_Reportes";
            this.btn_Reportes.Size = new System.Drawing.Size(198, 43);
            this.btn_Reportes.TabIndex = 36;
            this.btn_Reportes.Text = "Reportes";
            this.btn_Reportes.UseVisualStyleBackColor = false;
            this.btn_Reportes.Click += new System.EventHandler(this.btn_Reportes_Click);
            // 
            // btn_cobrar
            // 
            this.btn_cobrar.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.btn_cobrar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_cobrar.Font = new System.Drawing.Font("Microsoft YaHei", 14.25F);
            this.btn_cobrar.ForeColor = System.Drawing.Color.Maroon;
            this.btn_cobrar.Location = new System.Drawing.Point(303, 56);
            this.btn_cobrar.Name = "btn_cobrar";
            this.btn_cobrar.Size = new System.Drawing.Size(198, 43);
            this.btn_cobrar.TabIndex = 37;
            this.btn_cobrar.Text = "Cobrar";
            this.btn_cobrar.UseVisualStyleBackColor = false;
            this.btn_cobrar.Click += new System.EventHandler(this.btn_cobrar_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.btnEditar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnEditar.Font = new System.Drawing.Font("Microsoft YaHei", 14.25F);
            this.btnEditar.ForeColor = System.Drawing.Color.Maroon;
            this.btnEditar.Location = new System.Drawing.Point(303, 7);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(198, 43);
            this.btnEditar.TabIndex = 38;
            this.btnEditar.Text = "Editar";
            this.btnEditar.UseVisualStyleBackColor = false;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click_1);
            // 
            // btnNuevo
            // 
            this.btnNuevo.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.btnNuevo.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnNuevo.Font = new System.Drawing.Font("Microsoft YaHei", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNuevo.ForeColor = System.Drawing.Color.Maroon;
            this.btnNuevo.Location = new System.Drawing.Point(26, 7);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(198, 43);
            this.btnNuevo.TabIndex = 30;
            this.btnNuevo.Text = "Nuevo";
            this.btnNuevo.UseVisualStyleBackColor = false;
            this.btnNuevo.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnEliminar.Font = new System.Drawing.Font("Microsoft YaHei", 14.25F);
            this.btnEliminar.ForeColor = System.Drawing.Color.Maroon;
            this.btnEliminar.Location = new System.Drawing.Point(26, 56);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(198, 43);
            this.btnEliminar.TabIndex = 31;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(1229, 694);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(137, 16);
            this.label1.TabIndex = 19;
            this.label1.Text = "CONEXION SEGURA 🔐";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft YaHei", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(1029, 419);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 28);
            this.label2.TabIndex = 20;
            this.label2.Text = "HOY ES:";
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Font = new System.Drawing.Font("MS Reference Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFecha.ForeColor = System.Drawing.Color.Maroon;
            this.lblFecha.Location = new System.Drawing.Point(1029, 456);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(319, 24);
            this.lblFecha.TabIndex = 21;
            this.lblFecha.Text = "Miercoles, 17 de marzo de 2021";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft YaHei", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(1029, 499);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 28);
            this.label3.TabIndex = 22;
            this.label3.Text = "SON LAS:";
            // 
            // lblhora
            // 
            this.lblhora.AutoSize = true;
            this.lblhora.Font = new System.Drawing.Font("MS Reference Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblhora.ForeColor = System.Drawing.Color.Maroon;
            this.lblhora.Location = new System.Drawing.Point(1028, 539);
            this.lblhora.Name = "lblhora";
            this.lblhora.Size = new System.Drawing.Size(84, 29);
            this.lblhora.TabIndex = 23;
            this.lblhora.Text = "10;16";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.dgvEstudiantes);
            this.panel2.Location = new System.Drawing.Point(12, 89);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1011, 498);
            this.panel2.TabIndex = 24;
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.DarkGray;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Salidas,
            this.configuracionToolStripMenuItem,
            this.consultaToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1364, 24);
            this.menuStrip1.TabIndex = 29;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // Salidas
            // 
            this.Salidas.Name = "Salidas";
            this.Salidas.Size = new System.Drawing.Size(51, 20);
            this.Salidas.Text = "Cerrar";
            this.Salidas.Click += new System.EventHandler(this.cerrarSeccionToolStripMenuItem_Click);
            // 
            // configuracionToolStripMenuItem
            // 
            this.configuracionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.administradorDeUsuariosToolStripMenuItem});
            this.configuracionToolStripMenuItem.Name = "configuracionToolStripMenuItem";
            this.configuracionToolStripMenuItem.Size = new System.Drawing.Size(95, 20);
            this.configuracionToolStripMenuItem.Text = "Configuracion";
            // 
            // administradorDeUsuariosToolStripMenuItem
            // 
            this.administradorDeUsuariosToolStripMenuItem.Name = "administradorDeUsuariosToolStripMenuItem";
            this.administradorDeUsuariosToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
            this.administradorDeUsuariosToolStripMenuItem.Text = "Administrador De Usuarios";
            this.administradorDeUsuariosToolStripMenuItem.Click += new System.EventHandler(this.administradorDeUsuariosToolStripMenuItem_Click);
            // 
            // consultaToolStripMenuItem
            // 
            this.consultaToolStripMenuItem.Name = "consultaToolStripMenuItem";
            this.consultaToolStripMenuItem.Size = new System.Drawing.Size(66, 20);
            this.consultaToolStripMenuItem.Text = "Consulta";
            this.consultaToolStripMenuItem.Click += new System.EventHandler(this.consultaToolStripMenuItem_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft YaHei", 12.25F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(10, 56);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 24);
            this.label4.TabIndex = 30;
            this.label4.Text = "BUSCAR:";
            // 
            // FormInicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ClientSize = new System.Drawing.Size(1364, 711);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.lblhora);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblFecha);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.txtBusqueda);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormInicio";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Registro De Estudiantes";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEstudiantes)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtBusqueda;
        private System.Windows.Forms.Panel panel3;
        public System.Windows.Forms.DataGridView dgvEstudiantes;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblhora;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem consultaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem administradorDeUsuariosToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem configuracionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem Salidas;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Button btn_Reportes;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.Button btnEliminar;
        public System.Windows.Forms.Button btn_cobrar;
        public System.Windows.Forms.Button btn_PagosEmpleados;
        private System.Windows.Forms.RadioButton buscarPorMonto;
        private System.Windows.Forms.RadioButton buscarPorCel;
        private System.Windows.Forms.RadioButton buscarApellido;
        private System.Windows.Forms.RadioButton BuscarPorNombre;
        private System.Windows.Forms.Label label4;
    }
}

