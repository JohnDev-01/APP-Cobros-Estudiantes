
namespace ControlDeEstudiantes.Capas
{
    partial class FormPagosDeEstudiantes
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPagosDeEstudiantes));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.lblVerificarSiSeActivo = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.rbAdelanto = new System.Windows.Forms.RadioButton();
            this.rbMensualidad = new System.Windows.Forms.RadioButton();
            this.rbAtraso = new System.Windows.Forms.RadioButton();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.txtID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.cboAdelanto = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtCoutaMensual = new System.Windows.Forms.TextBox();
            this.txtAdelant = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtAtraso = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtMonto = new System.Windows.Forms.TextBox();
            this.btnRetornarPago = new System.Windows.Forms.Button();
            this.btnLimpiarCampos = new System.Windows.Forms.Button();
            this.btnCobrar = new System.Windows.Forms.Button();
            this.DgvCobro = new System.Windows.Forms.DataGridView();
            this.txtPagar = new System.Windows.Forms.TextBox();
            this.txtfechaPago = new System.Windows.Forms.TextBox();
            this.txtIngreso = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvCobro)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.panel5);
            this.panel1.Controls.Add(this.lblVerificarSiSeActivo);
            this.panel1.Controls.Add(this.panel6);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.btnBuscar);
            this.panel1.Controls.Add(this.txtID);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(861, 597);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.White;
            this.panel5.Location = new System.Drawing.Point(3, 149);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(851, 10);
            this.panel5.TabIndex = 26;
            // 
            // lblVerificarSiSeActivo
            // 
            this.lblVerificarSiSeActivo.AutoSize = true;
            this.lblVerificarSiSeActivo.Location = new System.Drawing.Point(241, 4);
            this.lblVerificarSiSeActivo.Name = "lblVerificarSiSeActivo";
            this.lblVerificarSiSeActivo.Size = new System.Drawing.Size(14, 13);
            this.lblVerificarSiSeActivo.TabIndex = 27;
            this.lblVerificarSiSeActivo.Text = "si";
            this.lblVerificarSiSeActivo.Visible = false;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.White;
            this.panel6.Location = new System.Drawing.Point(3, 195);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(851, 10);
            this.panel6.TabIndex = 25;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Controls.Add(this.rbAdelanto);
            this.panel3.Controls.Add(this.rbMensualidad);
            this.panel3.Controls.Add(this.rbAtraso);
            this.panel3.Location = new System.Drawing.Point(622, 17);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(228, 25);
            this.panel3.TabIndex = 6;
            // 
            // rbAdelanto
            // 
            this.rbAdelanto.AutoSize = true;
            this.rbAdelanto.Location = new System.Drawing.Point(157, 2);
            this.rbAdelanto.Name = "rbAdelanto";
            this.rbAdelanto.Size = new System.Drawing.Size(67, 17);
            this.rbAdelanto.TabIndex = 2;
            this.rbAdelanto.Text = "Adelanto";
            this.rbAdelanto.UseVisualStyleBackColor = true;
            this.rbAdelanto.CheckedChanged += new System.EventHandler(this.radioButton3_CheckedChanged);
            // 
            // rbMensualidad
            // 
            this.rbMensualidad.AutoSize = true;
            this.rbMensualidad.Checked = true;
            this.rbMensualidad.Location = new System.Drawing.Point(68, 2);
            this.rbMensualidad.Name = "rbMensualidad";
            this.rbMensualidad.Size = new System.Drawing.Size(85, 17);
            this.rbMensualidad.TabIndex = 1;
            this.rbMensualidad.TabStop = true;
            this.rbMensualidad.Text = "Mensualidad";
            this.rbMensualidad.UseVisualStyleBackColor = true;
            this.rbMensualidad.CheckedChanged += new System.EventHandler(this.rbMensualidad_CheckedChanged);
            // 
            // rbAtraso
            // 
            this.rbAtraso.AutoSize = true;
            this.rbAtraso.Location = new System.Drawing.Point(10, 2);
            this.rbAtraso.Name = "rbAtraso";
            this.rbAtraso.Size = new System.Drawing.Size(55, 17);
            this.rbAtraso.TabIndex = 0;
            this.rbAtraso.Text = "Atraso";
            this.rbAtraso.UseVisualStyleBackColor = true;
            this.rbAtraso.CheckedChanged += new System.EventHandler(this.rbAtraso_CheckedChanged);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscar.Location = new System.Drawing.Point(193, 16);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(41, 22);
            this.btnBuscar.TabIndex = 4;
            this.btnBuscar.Text = "...";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // txtID
            // 
            this.txtID.BackColor = System.Drawing.Color.Orange;
            this.txtID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtID.Location = new System.Drawing.Point(83, 17);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(107, 21);
            this.txtID.TabIndex = 2;
            this.txtID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtID.TextChanged += new System.EventHandler(this.txtID_TextChanged);
            this.txtID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.PresionaTeclaEnter);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(4, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 25);
            this.label1.TabIndex = 3;
            this.label1.Text = "Codigo:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(617, 2);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(214, 16);
            this.label9.TabIndex = 7;
            this.label9.Text = "Selecciona El Tipo De Cobro:";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.LightGray;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Controls.Add(this.txtCoutaMensual);
            this.panel2.Controls.Add(this.txtAdelant);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.txtAtraso);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.txtMonto);
            this.panel2.Controls.Add(this.btnRetornarPago);
            this.panel2.Controls.Add(this.btnLimpiarCampos);
            this.panel2.Controls.Add(this.btnCobrar);
            this.panel2.Controls.Add(this.DgvCobro);
            this.panel2.Controls.Add(this.txtPagar);
            this.panel2.Controls.Add(this.txtfechaPago);
            this.panel2.Controls.Add(this.txtIngreso);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.txtNombre);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Location = new System.Drawing.Point(9, 43);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(841, 543);
            this.panel2.TabIndex = 1;
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel4.Controls.Add(this.cboAdelanto);
            this.panel4.Controls.Add(this.label11);
            this.panel4.Location = new System.Drawing.Point(555, 38);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(279, 60);
            this.panel4.TabIndex = 23;
            // 
            // cboAdelanto
            // 
            this.cboAdelanto.BackColor = System.Drawing.Color.White;
            this.cboAdelanto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAdelanto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboAdelanto.FormattingEnabled = true;
            this.cboAdelanto.Items.AddRange(new object[] {
            "1 Mes",
            "2  Meses",
            "3 Meses",
            "4 Meses",
            "5 Meses",
            "6 Meses",
            "7 Meses",
            "8 Meses",
            "9 Meses",
            "10 Meses",
            "11 Meses",
            "1 AÑO"});
            this.cboAdelanto.Location = new System.Drawing.Point(139, 2);
            this.cboAdelanto.Name = "cboAdelanto";
            this.cboAdelanto.Size = new System.Drawing.Size(136, 23);
            this.cboAdelanto.TabIndex = 1;
            this.cboAdelanto.SelectedIndexChanged += new System.EventHandler(this.cboAdelanto_SelectedIndexChanged);
            this.cboAdelanto.TextChanged += new System.EventHandler(this.Evento_Mes_Adelanto);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(-2, 5);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(142, 16);
            this.label11.TabIndex = 0;
            this.label11.Text = "Meses En Adelanto";
            // 
            // txtCoutaMensual
            // 
            this.txtCoutaMensual.BackColor = System.Drawing.Color.Black;
            this.txtCoutaMensual.Font = new System.Drawing.Font("Microsoft YaHei", 11.25F);
            this.txtCoutaMensual.ForeColor = System.Drawing.Color.Gold;
            this.txtCoutaMensual.Location = new System.Drawing.Point(399, 71);
            this.txtCoutaMensual.Name = "txtCoutaMensual";
            this.txtCoutaMensual.ReadOnly = true;
            this.txtCoutaMensual.Size = new System.Drawing.Size(141, 27);
            this.txtCoutaMensual.TabIndex = 21;
            this.txtCoutaMensual.Text = "0";
            // 
            // txtAdelant
            // 
            this.txtAdelant.BackColor = System.Drawing.Color.Black;
            this.txtAdelant.Font = new System.Drawing.Font("Microsoft YaHei", 11.25F);
            this.txtAdelant.ForeColor = System.Drawing.Color.Gold;
            this.txtAdelant.Location = new System.Drawing.Point(398, 38);
            this.txtAdelant.Name = "txtAdelant";
            this.txtAdelant.ReadOnly = true;
            this.txtAdelant.Size = new System.Drawing.Size(141, 27);
            this.txtAdelant.TabIndex = 19;
            this.txtAdelant.Text = "0";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F);
            this.label8.Location = new System.Drawing.Point(291, 45);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(106, 19);
            this.label8.TabIndex = 20;
            this.label8.Text = "Adelanto.............:";
            // 
            // txtAtraso
            // 
            this.txtAtraso.BackColor = System.Drawing.Color.Black;
            this.txtAtraso.Font = new System.Drawing.Font("Microsoft YaHei", 11.25F);
            this.txtAtraso.ForeColor = System.Drawing.Color.Yellow;
            this.txtAtraso.Location = new System.Drawing.Point(397, 6);
            this.txtAtraso.Name = "txtAtraso";
            this.txtAtraso.ReadOnly = true;
            this.txtAtraso.Size = new System.Drawing.Size(141, 27);
            this.txtAtraso.TabIndex = 17;
            this.txtAtraso.Text = "0";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F);
            this.label7.Location = new System.Drawing.Point(291, 11);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(103, 19);
            this.label7.TabIndex = 18;
            this.label7.Text = "Atraso.................:";
            // 
            // txtMonto
            // 
            this.txtMonto.BackColor = System.Drawing.Color.Black;
            this.txtMonto.Font = new System.Drawing.Font("Microsoft YaHei", 11.25F);
            this.txtMonto.ForeColor = System.Drawing.Color.Gold;
            this.txtMonto.Location = new System.Drawing.Point(693, 3);
            this.txtMonto.Name = "txtMonto";
            this.txtMonto.ReadOnly = true;
            this.txtMonto.Size = new System.Drawing.Size(141, 27);
            this.txtMonto.TabIndex = 15;
            this.txtMonto.Text = "0.0";
            this.txtMonto.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtMonto.TextChanged += new System.EventHandler(this.txtMonto_TextChanged);
            // 
            // btnRetornarPago
            // 
            this.btnRetornarPago.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRetornarPago.Location = new System.Drawing.Point(589, 487);
            this.btnRetornarPago.Name = "btnRetornarPago";
            this.btnRetornarPago.Size = new System.Drawing.Size(163, 47);
            this.btnRetornarPago.TabIndex = 13;
            this.btnRetornarPago.Text = "Retornar Pago";
            this.btnRetornarPago.UseVisualStyleBackColor = true;
            this.btnRetornarPago.Click += new System.EventHandler(this.btnRetornarPago_Click);
            // 
            // btnLimpiarCampos
            // 
            this.btnLimpiarCampos.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimpiarCampos.Location = new System.Drawing.Point(343, 488);
            this.btnLimpiarCampos.Name = "btnLimpiarCampos";
            this.btnLimpiarCampos.Size = new System.Drawing.Size(163, 47);
            this.btnLimpiarCampos.TabIndex = 12;
            this.btnLimpiarCampos.Text = "Limpiar Campos";
            this.btnLimpiarCampos.UseVisualStyleBackColor = true;
            this.btnLimpiarCampos.Click += new System.EventHandler(this.btnLimpiarCampos_Click);
            // 
            // btnCobrar
            // 
            this.btnCobrar.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCobrar.Location = new System.Drawing.Point(91, 489);
            this.btnCobrar.Name = "btnCobrar";
            this.btnCobrar.Size = new System.Drawing.Size(163, 47);
            this.btnCobrar.TabIndex = 11;
            this.btnCobrar.Text = "Efectuar Cobro>>";
            this.btnCobrar.UseVisualStyleBackColor = true;
            this.btnCobrar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // DgvCobro
            // 
            this.DgvCobro.AllowUserToAddRows = false;
            this.DgvCobro.AllowUserToDeleteRows = false;
            this.DgvCobro.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DgvCobro.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.Desktop;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvCobro.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DgvCobro.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DgvCobro.DefaultCellStyle = dataGridViewCellStyle2;
            this.DgvCobro.EnableHeadersVisualStyles = false;
            this.DgvCobro.Location = new System.Drawing.Point(6, 166);
            this.DgvCobro.Name = "DgvCobro";
            this.DgvCobro.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvCobro.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.DgvCobro.RowHeadersVisible = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Goldenrod;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            this.DgvCobro.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.DgvCobro.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvCobro.Size = new System.Drawing.Size(826, 317);
            this.DgvCobro.TabIndex = 10;
            // 
            // txtPagar
            // 
            this.txtPagar.BackColor = System.Drawing.Color.Gold;
            this.txtPagar.Font = new System.Drawing.Font("Microsoft YaHei", 11.25F);
            this.txtPagar.Location = new System.Drawing.Point(83, 118);
            this.txtPagar.Name = "txtPagar";
            this.txtPagar.Size = new System.Drawing.Size(161, 27);
            this.txtPagar.TabIndex = 6;
            // 
            // txtfechaPago
            // 
            this.txtfechaPago.Font = new System.Drawing.Font("Microsoft YaHei", 11.25F);
            this.txtfechaPago.Location = new System.Drawing.Point(82, 74);
            this.txtfechaPago.Name = "txtfechaPago";
            this.txtfechaPago.ReadOnly = true;
            this.txtfechaPago.Size = new System.Drawing.Size(194, 27);
            this.txtfechaPago.TabIndex = 5;
            // 
            // txtIngreso
            // 
            this.txtIngreso.Font = new System.Drawing.Font("Microsoft YaHei", 11.25F);
            this.txtIngreso.Location = new System.Drawing.Point(81, 42);
            this.txtIngreso.Name = "txtIngreso";
            this.txtIngreso.ReadOnly = true;
            this.txtIngreso.Size = new System.Drawing.Size(195, 27);
            this.txtIngreso.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F);
            this.label4.Location = new System.Drawing.Point(0, 79);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 19);
            this.label4.TabIndex = 3;
            this.label4.Text = "Fecha Pago:";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F);
            this.label3.Location = new System.Drawing.Point(0, 44);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 19);
            this.label3.TabIndex = 2;
            this.label3.Text = "Inscripcion.:";
            // 
            // txtNombre
            // 
            this.txtNombre.Font = new System.Drawing.Font("Microsoft YaHei", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombre.Location = new System.Drawing.Point(81, 9);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.ReadOnly = true;
            this.txtNombre.Size = new System.Drawing.Size(195, 27);
            this.txtNombre.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(0, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 19);
            this.label2.TabIndex = 0;
            this.label2.Text = "Nombre......:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F);
            this.label6.Location = new System.Drawing.Point(553, 8);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(140, 19);
            this.label6.TabIndex = 16;
            this.label6.Text = "Total A Cobrar.............:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(3, 121);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 22);
            this.label5.TabIndex = 8;
            this.label5.Text = "Aplicar..:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F);
            this.label10.Location = new System.Drawing.Point(291, 77);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(105, 19);
            this.label10.TabIndex = 22;
            this.label10.Text = "Cuota Mensual:";
            // 
            // FormPagosDeEstudiantes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(885, 612);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormPagosDeEstudiantes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pagos";
            this.Load += new System.EventHandler(this.FormDetalles_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvCobro)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Button btnLimpiarCampos;
        private System.Windows.Forms.Button btnCobrar;
        private System.Windows.Forms.DataGridView DgvCobro;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtPagar;
        private System.Windows.Forms.TextBox txtfechaPago;
        private System.Windows.Forms.TextBox txtIngreso;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnRetornarPago;
        private System.Windows.Forms.TextBox txtMonto;
        private System.Windows.Forms.Label label6;
        public System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.RadioButton rbAdelanto;
        private System.Windows.Forms.RadioButton rbMensualidad;
        private System.Windows.Forms.RadioButton rbAtraso;
        private System.Windows.Forms.TextBox txtAdelant;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtAtraso;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtCoutaMensual;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.ComboBox cboAdelanto;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lblVerificarSiSeActivo;
        private System.Windows.Forms.Panel panel5;
    }
}