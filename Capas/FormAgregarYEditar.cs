using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ControlDeEstudiantes;
using ControlDeEstudiantes.Clases;
using System.Globalization;

namespace ControlDeEstudiantes.Capas
{


    public partial class FormAgregarYEditar : Form
    {

        public string Global { get; set; }
        public string Id { get; set; }
        public FormAgregarYEditar()
        {
            InitializeComponent();
        }
        
        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            FormInicio finicio = new FormInicio();
            //Variable Locales del Registro del cliente...
            string nombre = txtNombre.Text;
            string apellido = txtApellido.Text;
            string monto = txtMonto.Text;
            string idd = txtId.Text;

            var fechaT = datetimepikerfecha.Value.ToString("dd/MM/yyyy");
            string cel = txtCel.Text;
            


            if (Global == "Nuevo")
            {
                if (txtNombre.Text == "" && txtMonto.Text == "")
                {
                    errorprov.SetError(txtNombre, "Digita Nombre");
                    errorprov.SetError(txtMonto, "Digita Monto");
                    MessageBox.Show("Los campos 'NOMBRE' y 'MONTO' son obligatorios", "Verifica:");
                    return;
                }
                else { errorprov.Clear(); }
                if (txtNombre.Text == "")
                {
                    errorprov.SetError(txtNombre, "Digita Nombre");
                    MessageBox.Show("El campo 'NOMBRE' es obligatorio", "Verifica:");
                    return;
                }
                else { errorprov.Clear(); }
                if (txtMonto.Text == "")
                {
                    errorprov.SetError(txtMonto, "Digita Monto");
                    MessageBox.Show("El campo 'MONTO' es obligatorio", "Verifica:");
                    return;
                }
                else { errorprov.Clear(); }
                
                //...........................................................
                SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString);
                cn.Open();

                SqlCommand sc = new SqlCommand("InsertarEstudiantes", cn);
                sc.CommandType = CommandType.StoredProcedure;
                sc.Parameters.AddWithValue("@nombre", nombre);
                sc.Parameters.AddWithValue("@apellido", apellido);
                sc.Parameters.AddWithValue("@monto", monto);
                sc.Parameters.AddWithValue("@fechaInicio", fechaT);
                sc.Parameters.AddWithValue("@celular", cel);
                //sc.Parameters.AddWithValue("@Diapago", Diapago);

                int r = sc.ExecuteNonQuery();
                if (r == 1)
                {
                    MessageBox.Show("Agregado Correctamente", "Aviso:", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtNombre.Clear();
                    txtApellido.Clear();
                    txtMonto.Clear();
                    txtCel.Clear();              
                    txtNombre.Focus();

                }
                else
                {
                    MessageBox.Show("Ya existe un cliente con un mismo nombre");
                }


                cn.Close();

                /*var Fecha = fecha.Value.ToString("dd/MM/yyyy"); // extrae la fecha
                MessageBox.Show("La fecha es: " + Fecha);*/
            }
            if (Global == "Editar")
            {




                SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString);
                cn.Open();

                SqlCommand sc = new SqlCommand("ActualizarDatos", cn);
                sc.CommandType = CommandType.StoredProcedure;
                sc.Parameters.AddWithValue("@id", idd);
                sc.Parameters.AddWithValue("@nombre", nombre);
                sc.Parameters.AddWithValue("@apellido", apellido);
                sc.Parameters.AddWithValue("@monto", monto);
                sc.Parameters.AddWithValue("@fechaInicio", fechaT);
                sc.Parameters.AddWithValue("@celular", cel);
                //sc.Parameters.AddWithValue("@fechaProximoPago", Diapago);
                int r;
                MessageBoxButtons Mess = MessageBoxButtons.YesNo;
                DialogResult resultado = MessageBox.Show("¿Estas seguro de querer actualizar el registro?", "Confirmación:", Mess, MessageBoxIcon.Warning);
                if (resultado == DialogResult.Yes)
                {
                    r = sc.ExecuteNonQuery();
                    if (r == 1)
                    {
                        MessageBox.Show("Registro Actualizado Correctamente!!", "Aviso:", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    else
                    {
                        MessageBoxButtons m = MessageBoxButtons.OK;
                        MessageBox.Show("No han surgido nuevos cambios, verifica...", "Error:", m, MessageBoxIcon.Stop);
                    }
                }
                else
                {
                    return;
                }

            }
        }
        private void FormAgregarYEditar_Load(object sender, EventArgs e)
        {
            
            cboDiasQueTomaraClases.Enabled = true;
            cboDiasQueTomaraClases.Text = "Ninguno";
            txtNombre.Focus();
            var Fecha = datetimepikerfecha.Value.ToString("dd/MM/yyyy");
            if (Global == "Nuevo")
            {
                txtNombre.Focus();
                // Declaracion de variables 
                string nombre = txtNombre.Text;
                string apellido = txtApellido.Text;
                string monto = txtMonto.Text;
                var Fecha2 = datetimepikerfecha.Value.ToString("dd/MM/yyyy"); // extrae la fecha

                this.Text = "Registrar Estudiante"; // hago Referencia al titulo de la ventana

            }
            if (Global == "Editar")
            {
                this.Text = "Editar Estudiante Existente";

                //////////////////////////////////////////////////////////////////////
                DataTable tabla = SqlClase.ObtenerDatos("Obtenerdatos", "@idEstudiantes", Id);
                txtId.Text = tabla.Rows[0][0].ToString();
                txtNombre.Text = tabla.Rows[0][1].ToString();
                txtApellido.Text = tabla.Rows[0][2].ToString();
                txtCel.Text = tabla.Rows[0][3].ToString();
                txtMonto.Text = tabla.Rows[0][9].ToString();
                string FECHAPAGO = tabla.Rows[0][5].ToString();
                cboGrupos.Text = tabla.Rows[0][8].ToString();
                cboDiasQueTomaraClases.Text = tabla.Rows[0][10].ToString();
                txtMontoQueyaTiene.Text = tabla.Rows[0][6].ToString();
                string fecha = tabla.Rows[0][4].ToString();
                string formato = "dd/MM/yyyy";
                DateTime dateTime = DateTime.ParseExact(fecha, formato, CultureInfo.InvariantCulture);
                datetimepikerfecha.Value = dateTime;

                string formato2 = "dd/MM/yyyy";
                DateTime dia_pago = DateTime.ParseExact(FECHAPAGO, formato2, CultureInfo.InvariantCulture);
                dtDiaPago.Value = dia_pago;
                if (datetimepikerfecha.Value <= dtDiaPago.Value)
                {
                    cboDiasQueTomaraClases.Text = "Ninguno";
                    cboDiasQueTomaraClases.Enabled = true;
                }
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void cambioTxtNombre(object sender, EventArgs e)
        {

        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                txtApellido.Focus();
            }
        }

        private void txtapelid(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                txtCel.Focus();
            }
        }

        private void TxtCelularPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                
            }
        }

        private void PresionarTXTX(object sender, KeyPressEventArgs e)
        {

        }

        private void txtDiaPago_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                txtMonto.Focus();
            }
        }

        private void txtDiaPago_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void BtnAgregar_Click_1(object sender, EventArgs e)
        {
            //Region de Variable Locales del Registro del cliente...
            #region
            string grupo = cboGrupos.Text;
            int para_calcular_por_ciento = 0;
            string nombre = txtNombre.Text;
            string apellido = txtApellido.Text;
            string montoReal = txtMonto.Text;
            string monto = txtMonto.Text;
            string monto_Si_es_mayor = txtMonto.Text;
            string idd = txtId.Text;
            var fechaT = datetimepikerfecha.Value.ToString("dd/MM/yyyy"); // FECHA INGRESO
            DateTime dtFechaInscripcion = datetimepikerfecha.Value;
            string cel = txtCel.Text;
            int ValorDeDiasMensual = 4;
            var fechaHoy = DateTime.Today;
            DateTime diaPagodelControl = dtDiaPago.Value;
            string fpgo = dtDiaPago.Value.ToString("dd/MM/yyyy");
            string diaPagoString = diaPagodelControl.ToString("dd");
            string Insertar_Cantidad_Dias = cboDiasQueTomaraClases.Text;

            #endregion

            //____________________________________________________________________________________________
            //Sumatoria de la Fecha Ingresada por el usuario
            string DiasDePagoConFechaActual = dtDiaPago.Value.ToString("dd/MM/yyyy");/*diaPagoString + "/"+mesactualString+"/"+anoActualString;*/

            // Conversion de string a DateTime        
            string formato = "dd/MM/yyyy";
            DateTime DtFechaUsuarioConDiaPago = DateTime.ParseExact(DiasDePagoConFechaActual, formato, CultureInfo.InvariantCulture);
            //_________________________________________________________________________________________________

            string formato2 = "dd/MM/yyyy";
            DateTime fecainscripcionParaVALIDAR = DateTime.ParseExact(fechaT, formato2, CultureInfo.InvariantCulture);
            fecainscripcionParaVALIDAR = fecainscripcionParaVALIDAR.AddMonths(1);
            //___________________________________________________________________________________________________
            if (Global == "Nuevo")
            {
                // Region de validacion si estan vacios los espacios
                #region
                if (txtNombre.Text == "" && txtMonto.Text == "0.0" && cboGrupos.Text == "")
                {
                    errorprov.SetError(txtNombre, "Digita Nombre");
                    errorprov.SetError(txtMonto, "Digita Monto");
                    errorprov.SetError(cboGrupos, "Selecciona el grupo que pertenece!!");
                    MessageBox.Show("Los campos 'NOMBRE', 'MONTO' y 'SECCION' son obligatorios", "Verifica:");
                    this.DialogResult = DialogResult.None;
                    return;
                }
                else { errorprov.Clear(); }

                if(txtMonto.Text == "0.0" || txtMonto.Text == "")
                {
                    errorprov.SetError(txtMonto, "Digita Monto");
                    this.DialogResult = DialogResult.None;
                    return;
                }
                else
                {
                    errorprov.Clear();
                }

                if (txtNombre.Text == "")
                {
                    errorprov.SetError(txtNombre, "Digita Nombre");
                    MessageBox.Show("El campo 'NOMBRE' es obligatorio", "Verifica:");
                    this.DialogResult = DialogResult.None;
                    return;
                }
                else { errorprov.Clear(); }          

                if (cboGrupos.Text == "")
                {
                    errorprov.SetError(cboGrupos, "Selecciona El Grupo Que Le Pertenece.");
                    this.DialogResult = DialogResult.None;
                    return;
                }
                else { errorprov.Clear(); }

                if (dtDiaPago.Value > datetimepikerfecha.Value && cboDiasQueTomaraClases.Text == "")
                {
                    errorprov.SetError(cboDiasQueTomaraClases, "Selecciona la cantidad de dias que laboraras en el transcurso de la fecha de pago");
                    this.DialogResult = DialogResult.None;
                    return;
                }
                else
                {
                    errorprov.Clear();
                }
                #endregion


                //Para Calcular la fecha actual con el dia ingresado por el usuario
                #region
                // OPERACION DIA ACTUAL
                int diaActualParaComparar = fechaHoy.Day;
                if (diaActualParaComparar <= 9)
                {
                    diaPagoString = "0" + diaPagoString;
                }
                // Variable diapagoString tengo el dia que el usuario elige 


                //OPERACION MES ACTUAL..........!!!!
                int mesactual = fechaHoy.Month;
                string mesactualString = mesactual.ToString();
                int mesActualSoloParaComparar = fechaHoy.Month;
                if (mesActualSoloParaComparar <= 9)
                {
                    mesactualString = "0" + mesactual.ToString();

                }

                //Operacion Ano Actual.....:

                int anoActual = fechaHoy.Year;
                string anoActualString = anoActual.ToString();
                #endregion

                

                //PARA VALIDAR SI EL DIA DE PAGO ES MENOR O MAYOR AL DIA DE INSCRIPCION
                int diaDePago = int.Parse(diaPagoString);
                string incripcion = dtFechaInscripcion.ToString("dd/MM/yyyy");
                //int DiaInscripcionValidacion = int.Parse(incripcion);
                if (DtFechaUsuarioConDiaPago <= dtFechaInscripcion)
                {
                    if (DtFechaUsuarioConDiaPago <= dtFechaInscripcion)
                    {
                        DtFechaUsuarioConDiaPago = DtFechaUsuarioConDiaPago.AddMonths(1);

                    }
                    string Prox_FechaDePago = DtFechaUsuarioConDiaPago.ToString("dd/MM/yyyy");

                    //AQUI TENGO LA PROXIMA FECHA DE PAGO:   Prox_FechaDePago

                    try
                    {
                        //region de conexion e insercion de datos
                        #region
                        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString);
                        cn.Open();

                        SqlCommand sc = new SqlCommand("InsertarEstudiantes", cn);
                        sc.CommandType = CommandType.StoredProcedure;
                        sc.Parameters.AddWithValue("@nombre", nombre);
                        sc.Parameters.AddWithValue("@apellido", apellido);
                        sc.Parameters.AddWithValue("@monto", monto);
                        sc.Parameters.AddWithValue("@fechaInicio", fechaT);
                        sc.Parameters.AddWithValue("@celular", cel);
                        sc.Parameters.AddWithValue("@fechapago", Prox_FechaDePago);
                        sc.Parameters.AddWithValue("@montoreal", montoReal);
                        sc.Parameters.AddWithValue("@seccion", grupo);
                        sc.Parameters.AddWithValue("@cantdias", Insertar_Cantidad_Dias);


                        int r = sc.ExecuteNonQuery();
                        if (r == 1)
                        {
                            MessageBox.Show("Agregado Correctamente", "Aviso:", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            txtNombre.Clear();
                            txtApellido.Clear();
                            txtMonto.Clear();
                            txtCel.Clear();
                            txtNombre.Focus();

                        }
                        else
                        {
                            MessageBox.Show("Ya existe un cliente con un mismo nombre");
                        }


                        cn.Close();
                    }
                    catch (System.Data.SqlClient.SqlException)
                    {
                        MessageBox.Show("SOLO SE ACEPTAN FORMATO NUMERICO EN EL ESPACIO MONTO", "ERROR:", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.DialogResult = DialogResult.None;
                        return;
                    }
                    return;
                    #endregion
                }
                else
                {
                    try
                    {
                        if (DtFechaUsuarioConDiaPago > dtFechaInscripcion)
                        {
                            //para validar los dias a calcular porciento
                            #region
                            if (cboDiasQueTomaraClases.Text == "1 DIA")
                            {
                                para_calcular_por_ciento = 1;
                            }
                            if (cboDiasQueTomaraClases.Text == "2 DIAS")
                            {
                                para_calcular_por_ciento = 2;
                            }
                            if (cboDiasQueTomaraClases.Text == "3 DIAS ")
                            {
                                para_calcular_por_ciento = 3;
                            }
                            #endregion


                            //calculo de dias a pagar si la fecha es mayor a la de inscripcion


                            int DiasParaSacarPorciento = para_calcular_por_ciento;
                            int monto1 = int.Parse(monto_Si_es_mayor);


                            int PagoDiario = monto1 / ValorDeDiasMensual;
                            int CobrarDias = PagoDiario * DiasParaSacarPorciento;

                            string pago_Si_es_mayor = CobrarDias.ToString();

                            string prox_fPago_si_esMayor = DtFechaUsuarioConDiaPago.ToString("dd/MM/yyyy");

                            //conexion y insertar si es mayor
                            #region
                            SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString);
                            cnn.Open();

                            SqlCommand scc = new SqlCommand("InsertarEstudiantes", cnn);
                            scc.CommandType = CommandType.StoredProcedure;
                            scc.Parameters.AddWithValue("@nombre", nombre);
                            scc.Parameters.AddWithValue("@apellido", apellido);
                            scc.Parameters.AddWithValue("@monto", pago_Si_es_mayor);
                            scc.Parameters.AddWithValue("@fechaInicio", fechaT);
                            scc.Parameters.AddWithValue("@celular", cel);
                            scc.Parameters.AddWithValue("@fechapago", prox_fPago_si_esMayor);
                            scc.Parameters.AddWithValue("@montoreal", montoReal);
                            scc.Parameters.AddWithValue("@seccion", grupo);
                            scc.Parameters.AddWithValue("@cantdias", Insertar_Cantidad_Dias);

                            int rr = scc.ExecuteNonQuery();
                            if (rr == 1)
                            {
                                MessageBox.Show("Agregado Correctamente", "Aviso:", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                txtNombre.Clear();
                                txtApellido.Clear();
                                txtMonto.Clear();
                                txtCel.Clear();
                                txtNombre.Focus();

                            }
                            else
                            {
                                MessageBox.Show("Ya existe un cliente con un mismo nombre");
                            }


                            cnn.Close();

                            #endregion
                            return;
                        }
                    }
                    catch (System.FormatException)
                    {

                        MessageBox.Show("SOLO SE ACEPTA FORMATO NUMERICO EN EL ESPACIO MONTO", "ERROR:", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.DialogResult = DialogResult.None;
                        return;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "UYYY OCURRIO UN ERROR:");
                    }
                }
            }
            
            if (Global == "Editar")
            {

                if (DtFechaUsuarioConDiaPago <= dtFechaInscripcion)
                {
                    
                    if (DtFechaUsuarioConDiaPago <= dtFechaInscripcion)
                    {
                        DtFechaUsuarioConDiaPago = DtFechaUsuarioConDiaPago.AddMonths(1);

                    }
                    string Prox_FechaDePago = DtFechaUsuarioConDiaPago.ToString("dd/MM/yyyy");



                    SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString);
                    cn.Open();

                    SqlCommand sc = new SqlCommand("ActualizarDatos", cn);
                    sc.CommandType = CommandType.StoredProcedure;
                    sc.Parameters.AddWithValue("@id", idd);
                    sc.Parameters.AddWithValue("@nombre", nombre);
                    sc.Parameters.AddWithValue("@apellido", apellido);
                    sc.Parameters.AddWithValue("@monto", montoReal);
                    sc.Parameters.AddWithValue("@fechaInicio", fechaT);
                    sc.Parameters.AddWithValue("@montoreal", montoReal);
                    sc.Parameters.AddWithValue("@celular", cel);
                    sc.Parameters.AddWithValue("@fechaProximoPago", Prox_FechaDePago);
                    sc.Parameters.AddWithValue("@seccion", grupo);
                    sc.Parameters.AddWithValue("@cant_dias", Insertar_Cantidad_Dias);
                    int r;
                    MessageBoxButtons Mess = MessageBoxButtons.YesNo;
                    DialogResult resultado = MessageBox.Show("¿Estas seguro de querer actualizar el registro?", "Confirmación:", Mess, MessageBoxIcon.Warning);
                    if (resultado == DialogResult.Yes)
                    {
                        r = sc.ExecuteNonQuery();
                        if (r == 1)
                        {
                            MessageBox.Show("Registro Actualizado Correctamente!!", "Aviso:", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                        else
                        {
                            MessageBoxButtons m = MessageBoxButtons.OK;
                            MessageBox.Show("No han surgido nuevos cambios, verifica...", "Error:", m, MessageBoxIcon.Stop);
                        }
                    }
                    else
                    {
                        return;
                    }
                    return;
                }
                if (DtFechaUsuarioConDiaPago > dtFechaInscripcion && DtFechaUsuarioConDiaPago < fecainscripcionParaVALIDAR) 
                { 
                    //para validar los dias a calcular porciento
                    #region
                    if (cboDiasQueTomaraClases.Text == "1 DIA")
                    {
                        para_calcular_por_ciento = 1;
                    }
                    if (cboDiasQueTomaraClases.Text == "2 DIAS")
                    {
                      para_calcular_por_ciento = 2;
                    }
                    if (cboDiasQueTomaraClases.Text == "3 DIAS ")
                    {
                       para_calcular_por_ciento = 3;
                    }
                    if (cboDiasQueTomaraClases.Text == "Ninguno")
                    {
                        para_calcular_por_ciento = 0;
                    }
                   #endregion
 
                   
                    
                    int DiasParaSacarPorciento = para_calcular_por_ciento;
                    int monto1 = int.Parse(monto_Si_es_mayor);


                    int PagoDiario = monto1 / ValorDeDiasMensual;
                    int CobrarDias = PagoDiario * DiasParaSacarPorciento;

                    string pago_Si_es_mayor = CobrarDias.ToString();

                    string prox_fPago_si_esMayor = DtFechaUsuarioConDiaPago.ToString("dd/MM/yyyy");



                    SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString);
                    cn.Open();

                    SqlCommand sc = new SqlCommand("ActualizarDatos", cn);
                    sc.CommandType = CommandType.StoredProcedure;
                    sc.Parameters.AddWithValue("@id", idd);
                    sc.Parameters.AddWithValue("@nombre", nombre);
                    sc.Parameters.AddWithValue("@apellido", apellido);
                    sc.Parameters.AddWithValue("@monto", pago_Si_es_mayor);
                    sc.Parameters.AddWithValue("@fechaInicio", fechaT);
                    sc.Parameters.AddWithValue("@montoreal", montoReal);
                    sc.Parameters.AddWithValue("@celular", cel);
                    sc.Parameters.AddWithValue("@fechaProximoPago", prox_fPago_si_esMayor);
                    sc.Parameters.AddWithValue("@seccion", grupo);
                    sc.Parameters.AddWithValue("@cant_dias", Insertar_Cantidad_Dias);
                    int r;
                    MessageBoxButtons Mess = MessageBoxButtons.YesNo;
                    DialogResult resultado = MessageBox.Show("¿Estas seguro de querer actualizar el registro?", "Confirmación:", Mess, MessageBoxIcon.Warning);
                    if (resultado == DialogResult.Yes)
                    {
                        r = sc.ExecuteNonQuery();
                        if (r == 1)
                        {
                            MessageBox.Show("Registro Actualizado Correctamente!!", "Aviso:", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                        else
                        {
                            MessageBoxButtons m = MessageBoxButtons.OK;
                            MessageBox.Show("No han surgido nuevos cambios, verifica...", "Error:", m, MessageBoxIcon.Stop);
                        }
                    }
                    else
                    {
                        return;
                    }
                }
                else
                {
                    SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString);
                    cn.Open();

                    SqlCommand sc = new SqlCommand("ActualizarDatos", cn);
                    sc.CommandType = CommandType.StoredProcedure;
                    sc.Parameters.AddWithValue("@id", idd);
                    sc.Parameters.AddWithValue("@nombre", nombre);
                    sc.Parameters.AddWithValue("@apellido", apellido);
                    sc.Parameters.AddWithValue("@monto", montoReal);
                    sc.Parameters.AddWithValue("@fechaInicio", fechaT);
                    sc.Parameters.AddWithValue("@montoreal", montoReal);
                    sc.Parameters.AddWithValue("@celular", cel);
                    sc.Parameters.AddWithValue("@fechaProximoPago", fpgo);
                    sc.Parameters.AddWithValue("@seccion", grupo);
                    sc.Parameters.AddWithValue("@cant_dias", Insertar_Cantidad_Dias);
                    int r;
                    MessageBoxButtons Mess = MessageBoxButtons.YesNo;
                    DialogResult resultado = MessageBox.Show("¿Estas seguro de querer actualizar el registro?", "Confirmación:", Mess, MessageBoxIcon.Warning);
                    if (resultado == DialogResult.Yes)
                    {
                        r = sc.ExecuteNonQuery();
                        if (r == 1)
                        {
                            MessageBox.Show("Registro Actualizado Correctamente!!", "Aviso:", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                        else
                        {
                            MessageBoxButtons m = MessageBoxButtons.OK;
                            MessageBox.Show("No han surgido nuevos cambios, verifica...", "Error:", m, MessageBoxIcon.Stop);
                        }
                    }
                    else
                    {
                        return;
                    }
                }
            }
            
            this.DialogResult = DialogResult.None;
        }

        private void btnCancelar_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Evento_Cambio_dia(object sender, EventArgs e)
        {
            //    if (dtDiaPago.Value > datetimepikerfecha.Value)
            //    {

            //        cboDiasQueTomaraClases.Enabled = true;

            //    }
            //    else
            //    {

            //        cboDiasQueTomaraClases.Enabled = false;
            //    }
        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}