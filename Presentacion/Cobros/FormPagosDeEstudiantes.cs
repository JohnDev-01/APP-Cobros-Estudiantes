using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ControlDeEstudiantes.Clases;
using ControlDeEstudiantes.DataAccess;
using ControlDeEstudiantes.Datos;
using ControlDeEstudiantes.Logica;

namespace ControlDeEstudiantes.Capas
{
    public partial class FormPagosDeEstudiantes : Form
    {
        public string Id { get; set; }
        string tipo;
        string id;
        string montoDeCuotaMensual;
        string monto_Deuda_Actual;
        string fechaDePago;
        public FormPagosDeEstudiantes()
        {
            InitializeComponent();
        }

        private void toolStripDropDownButton1_Click(object sender, EventArgs e)
        {

        }
        private void Validacion_Cobro()
        {
            if (txtPagar.Text == "")
            {
                MessageBox.Show("El Monto De Pago Está En Blanco.", "Verifica:", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            tipo = "";
            id = txtID.Text;
            montoDeCuotaMensual = "";
            fechaDePago = txtfechaPago.Text;
            if (rbAdelanto.Checked == true) tipo = "Adelanto";
            if (rbAtraso.Checked == true) tipo = "Atraso";
            if (rbMensualidad.Checked == true) tipo = "Mensualidad";


            if (rbAdelanto.Checked == true && cboAdelanto.Text == "")
            {
                MessageBox.Show("Selecciona La Cantidad De Meses En Adelanto");
                return;
            }
            if (rbAdelanto.Checked == true && cboAdelanto.Text == "Selecciona...")
            {
                MessageBox.Show("Selecciona La Cantidad De Meses En Adelanto");
                return;
            }

        }
        private void Obtener_Datos_Cobro()
        {
            try
            {
                DataTable dt = SqlClase.ObtenerDatos("obtenerMontoReal", "@id", id);
                montoDeCuotaMensual = dt.Rows[0][0].ToString();
                monto_Deuda_Actual = dt.Rows[0][1].ToString();
                string MontoRt = dt.Rows[0][1].ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No puedes realizar pagos con el codigo en blanco", "Verifica:", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        private void Pago_Mensualidad()
        {
            DialogResult resultado = MessageBox.Show("¿Estas seguro de querer realizar el pago?", "Confirmación:", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resultado == DialogResult.Yes)
            {
                //----Efectivo----
                string adelanto = "0";
                int monto_que_pagoEN = int.Parse(txtPagar.Text);
                int deuda_actual = int.Parse(monto_Deuda_Actual);
                int CuotaMensual = int.Parse(montoDeCuotaMensual);
                int resta = deuda_actual - monto_que_pagoEN;
                int MontoParaProximoPago = resta + CuotaMensual;
                //----Fechas-----
                string fechaDePagoAnterior = txtfechaPago.Text;
                DateTime fechaProx_Pago = DateTime.ParseExact(fechaDePagoAnterior, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                fechaProx_Pago = fechaProx_Pago.AddMonths(1);
                string FechaproximoPago = fechaProx_Pago.ToString("dd/MM/yyyy");
                //----Ejecutar pago------

                //Insertar Pago concreto 
                Insertar_Datos.PagoMensualidad(id, MontoParaProximoPago.ToString(), FechaproximoPago, resta, adelanto);
                //Insertar Tabla para historial Pagos
                LPEstuadiantes lp = new LPEstuadiantes();
                Insertar_Datos dt = new Insertar_Datos();
                lp.Id = Convert.ToInt32(txtID.Text);
                lp.Nombre = txtNombre.Text;
                lp.Fecha_Pago = txtfechaPago.Text;
                lp.Inscripcion = txtIngreso.Text;
                lp.Tipo = tipo;
                lp.Monto_Aplicado = Convert.ToInt32(txtPagar.Text);
                lp.Atraso = Convert.ToInt32(txtAtraso.Text);
                lp.Adelanto = Convert.ToInt32(txtAdelant.Text);
                lp.Monto_A_Pagar = Convert.ToInt32(txtMonto.Text);
                lp.Cant = "**Pago De Mensualidad**";

                if (dt.PagoMensualidad(lp) == true)
                {
                    MessageBox.Show("Pago realizado correctamente!!", "Aviso:", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }

                LimpiarControles();
               
            }
            else
            {
                return;
            }
        }
        private void Registrar_Atraso()
        {
            //Calculo Dinero
            int cuotaMensual = int.Parse(montoDeCuotaMensual);
            int AtrasoParaAplicar = int.Parse(txtPagar.Text);
            int DineroAPagar = cuotaMensual + AtrasoParaAplicar;
            string dineroProxPago = DineroAPagar.ToString();
            //Calculo fechas
            string fechaDePago = txtfechaPago.Text;
            string formato = "dd/MM/yyyy";

            DateTime fechaProx_Pago = DateTime.ParseExact(fechaDePago, formato, CultureInfo.InvariantCulture);
            fechaProx_Pago = fechaProx_Pago.AddMonths(1);

            string FechaproximoPago = fechaProx_Pago.ToString("dd/MM/yyyy");
            //_______________________________________________________________//
            
            DialogResult resultado = MessageBox.Show("¿Estas seguro de querer realizar el atraso?", "Confirmación:", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resultado == DialogResult.Yes)
            {
                //Insertar Tabla de pagos real
                Insertar_Datos.PagoMensualidad(id, dineroProxPago, FechaproximoPago, AtrasoParaAplicar,"0");
                //Insertar Tabla para historial Pagos
                LPEstuadiantes lp = new LPEstuadiantes();
                Insertar_Datos dt = new Insertar_Datos();
                lp.Id =Convert.ToInt32( txtID.Text);
                lp.Nombre = txtNombre.Text;
                lp.Fecha_Pago = txtfechaPago.Text;
                lp.Inscripcion = txtIngreso.Text;
                lp.Tipo = tipo;
                lp.Monto_Aplicado = Convert.ToInt32(txtPagar.Text);
                lp.Atraso = Convert.ToInt32(txtAtraso.Text);
                lp.Adelanto = Convert.ToInt32(txtAdelant.Text);
                lp.Monto_A_Pagar = Convert.ToInt32(txtMonto.Text);
                lp.Cant = "ATRASO";
                if (dt.PagoMensualidad(lp) == true)
                {
                    MessageBox.Show("Atraso realizado correctamente!!", "Aviso:", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                LimpiarControles();
            }
        }
        private void LimpiarControles()
        {
            txtMonto.Enabled = false;
            txtIngreso.Enabled = false;
            txtPagar.Enabled = false;
            txtNombre.Enabled = false;
            txtfechaPago.Enabled = false;
            btnLimpiarCampos.Enabled = false;
            btnCobrar.Enabled = false;
            btnRetornarPago.Enabled = false;
            txtAdelant.Enabled = false;
            txtAtraso.Enabled = false;
            lblVerificarSiSeActivo.Text = "no";
            cboAdelanto.Enabled = false;
            txtCoutaMensual.Enabled = false;
            txtCoutaMensual.Text = "0";
            txtMonto.Text = "0.0";
            DgvCobro.DataSource = "";
            txtNombre.Text = "";
            txtIngreso.Text = "";
            txtfechaPago.Text = "";
            txtPagar.Text = "";
            cboAdelanto.Text = "";
            txtAdelant.Text = "0";
            txtMonto.Text = "0";
        }
        private void Pago_Adelanto()
        {
            string montoAplicado = txtPagar.Text;
            int montoaplicado = int.Parse(montoAplicado);


            string atrasoTxt = txtAtraso.Text;
            int EnAtraso = int.Parse(atrasoTxt);
            int montoApagar = int.Parse(monto_Deuda_Actual) + EnAtraso;
            string Atraso = "0";

            string fecha = txtfechaPago.Text;
            string formato = "dd/MM/yyyy";
            DateTime fechapago = DateTime.ParseExact(fecha, formato, CultureInfo.InvariantCulture);


            //_______-AQUI COMIENZA LA VERIFICACION DE LOS MESES __________________________________

            if (cboAdelanto.Text == "1 Mes")
            {
                string TotalCobrar = txtMonto.Text;
                int MontoParaPagar = int.Parse(txtMonto.Text);

                if (montoaplicado > MontoParaPagar)
                {
                    MessageBox.Show("El Monto Aplicado No Corresponde Al Maximo A Pagar En El Mes Seleccionado", "Error:");
                    return;
                }
                if (montoaplicado == MontoParaPagar)
                {
                    string formatoto = "dd/MM/yyyy";

                    DateTime fechaProx_Pago = DateTime.ParseExact(fechaDePago, formatoto, CultureInfo.InvariantCulture);

                    fechaProx_Pago = fechaProx_Pago.AddMonths(1);

                    string FechaproximoPago = fechaProx_Pago.ToString("dd/MM/yyyy");

                    //Conexionnn .............
                    SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString);
                    cn.Open();

                    SqlCommand sc = new SqlCommand("PagoMensualidad", cn);
                    sc.CommandType = CommandType.StoredProcedure;
                    sc.Parameters.AddWithValue("@id", id);
                    sc.Parameters.AddWithValue("@monto", montoDeCuotaMensual);
                    sc.Parameters.AddWithValue("@fechaProx", FechaproximoPago);
                    sc.Parameters.AddWithValue("@atraso", "0");
                    sc.Parameters.AddWithValue("@adelanto", "0");
                    int r;
                    MessageBoxButtons Mess = MessageBoxButtons.YesNo;
                    DialogResult resultado = MessageBox.Show("¿Estas seguro de querer realizar el Adelanto?", "Confirmación:", Mess, MessageBoxIcon.Question);
                    if (resultado == DialogResult.Yes)
                    {
                        r = sc.ExecuteNonQuery();
                        if (r == 1)
                        {
                            MessageBox.Show("Adelanto realizado correctamente!!", "Aviso:", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ////____________GUARDANDO EN PAGO EN UNA TABLA_________________________
                            try
                            {
                                //Insertar Tabla Pagos
                                SqlConnection conne = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString);
                                conne.Open();
                                string iddd = txtID.Text;
                                DataTable dtttt = SqlClase.ObtenerDatos("ObtenerDatosParaPagar", "@id", id);
                                string montorr = dtttt.Rows[0][6].ToString();
                                SqlCommand sscommand = new SqlCommand("RegistrarPagos", conne);
                                sscommand.CommandType = CommandType.StoredProcedure;
                                sscommand.Parameters.AddWithValue("@id", txtID.Text);
                                sscommand.Parameters.AddWithValue("@nombre", txtNombre.Text);
                                sscommand.Parameters.AddWithValue("@f_pago", txtfechaPago.Text);
                                sscommand.Parameters.AddWithValue("@inscripcion", txtIngreso.Text);
                                sscommand.Parameters.AddWithValue("@tipo", tipo);
                                sscommand.Parameters.AddWithValue("@montoAplicado", txtPagar.Text);
                                sscommand.Parameters.AddWithValue("@atraso", txtAtraso.Text);
                                sscommand.Parameters.AddWithValue("@adelanto", txtAdelant.Text);
                                sscommand.Parameters.AddWithValue("@MontoCobrar", montorr);
                                sscommand.Parameters.AddWithValue("@Cant", "Un Mes En Adelanto");
                                sscommand.ExecuteNonQuery();

                                conne.Close();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                            //_____________________________________________________
                            //Para Ocultar Los Controles
                            #region
                            txtMonto.Enabled = false;
                            txtIngreso.Enabled = false;
                            txtPagar.Enabled = false;
                            txtNombre.Enabled = false;
                            txtfechaPago.Enabled = false;
                            btnLimpiarCampos.Enabled = false;
                            btnCobrar.Enabled = false;
                            btnRetornarPago.Enabled = false;
                            txtAdelant.Enabled = false;
                            txtAtraso.Enabled = false;
                            lblVerificarSiSeActivo.Text = "no";
                            cboAdelanto.Enabled = false;
                            txtCoutaMensual.Enabled = false;
                            txtCoutaMensual.Text = "0";
                            txtMonto.Text = "0.0";
                            DgvCobro.DataSource = "";
                            txtNombre.Text = "";
                            txtIngreso.Text = "";
                            txtfechaPago.Text = "";
                            txtPagar.Text = "";
                            cboAdelanto.Text = "";
                            txtAdelant.Text = "0";
                            txtMonto.Text = "0";
                            #endregion
                        }
                        else
                        {
                            MessageBoxButtons m = MessageBoxButtons.OK;
                            MessageBox.Show("han surgido errores, verifica...", "Error:", m, MessageBoxIcon.Stop);
                        }
                    }
                    else
                    {
                        return;
                    }
                    return;
                }
                if (montoaplicado == EnAtraso)
                {
                    SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString);
                    cn.Open();

                    SqlCommand sc = new SqlCommand("PagoMensualidad", cn);
                    sc.CommandType = CommandType.StoredProcedure;
                    sc.Parameters.AddWithValue("@id", id);
                    sc.Parameters.AddWithValue("@monto", montoDeCuotaMensual);
                    sc.Parameters.AddWithValue("@fechaProx", txtfechaPago.Text);
                    sc.Parameters.AddWithValue("@atraso", "0");
                    sc.Parameters.AddWithValue("@adelanto", "0");
                    int r;
                    MessageBoxButtons Mess = MessageBoxButtons.YesNo;
                    DialogResult resultado = MessageBox.Show("¿Estas seguro de querer realizar el Adelanto?", "Confirmación:", Mess, MessageBoxIcon.Question);
                    if (resultado == DialogResult.Yes)
                    {
                        r = sc.ExecuteNonQuery();
                        if (r == 1)
                        {
                            MessageBox.Show("Adelanto realizado correctamente!!", "Aviso:", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ////____________GUARDANDO EN PAGO EN UNA TABLA_________________________
                            try
                            {
                                //Insertar Tabla Pagos
                                SqlConnection conne = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString);
                                conne.Open();
                                string iddd = txtID.Text;
                                DataTable dtttt = SqlClase.ObtenerDatos("ObtenerDatosParaPagar", "@id", id);
                                string montorr = dtttt.Rows[0][6].ToString();
                                SqlCommand sscommand = new SqlCommand("RegistrarPagos", conne);
                                sscommand.CommandType = CommandType.StoredProcedure;
                                sscommand.Parameters.AddWithValue("@id", txtID.Text);
                                sscommand.Parameters.AddWithValue("@nombre", txtNombre.Text);
                                sscommand.Parameters.AddWithValue("@f_pago", txtfechaPago.Text);
                                sscommand.Parameters.AddWithValue("@inscripcion", txtIngreso.Text);
                                sscommand.Parameters.AddWithValue("@tipo", tipo);
                                sscommand.Parameters.AddWithValue("@montoAplicado", txtPagar.Text);
                                sscommand.Parameters.AddWithValue("@atraso", txtAtraso.Text);
                                sscommand.Parameters.AddWithValue("@adelanto", txtAdelant.Text);
                                sscommand.Parameters.AddWithValue("@MontoCobrar", montorr);
                                sscommand.Parameters.AddWithValue("@Cant", "Pago De Atraso");
                                sscommand.ExecuteNonQuery();

                                conne.Close();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                            //_____________________________________________________
                            //Para Ocultar Los Controles
                            #region
                            txtMonto.Enabled = false;
                            txtIngreso.Enabled = false;
                            txtPagar.Enabled = false;
                            txtNombre.Enabled = false;
                            txtfechaPago.Enabled = false;
                            btnLimpiarCampos.Enabled = false;
                            btnCobrar.Enabled = false;
                            btnRetornarPago.Enabled = false;
                            txtAdelant.Enabled = false;
                            txtAtraso.Enabled = false;
                            lblVerificarSiSeActivo.Text = "no";
                            cboAdelanto.Enabled = false;
                            txtCoutaMensual.Enabled = false;
                            txtCoutaMensual.Text = "0";
                            txtMonto.Text = "0.0";
                            DgvCobro.DataSource = "";
                            txtNombre.Text = "";
                            txtIngreso.Text = "";
                            txtfechaPago.Text = "";
                            txtPagar.Text = "";
                            cboAdelanto.Text = "";
                            txtAdelant.Text = "0";
                            txtMonto.Text = "0";
                            #endregion
                        }
                        else
                        {
                            MessageBoxButtons m = MessageBoxButtons.OK;
                            MessageBox.Show("han surgido errores, verifica...", "Error:", m, MessageBoxIcon.Stop);
                        }
                    }
                    else
                    {
                        return;
                    }
                    return;
                }
                if (montoaplicado < EnAtraso)
                {
                    int _montoDeCuotaMensual = int.Parse(montoDeCuotaMensual);
                    int proximop = EnAtraso - montoaplicado;
                    string mt = proximop.ToString();

                    int prox = _montoDeCuotaMensual + proximop;

                    SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString);
                    cn.Open();

                    SqlCommand sc = new SqlCommand("PagoMensualidad", cn);
                    sc.CommandType = CommandType.StoredProcedure;
                    sc.Parameters.AddWithValue("@id", id);
                    sc.Parameters.AddWithValue("@monto", prox.ToString());
                    sc.Parameters.AddWithValue("@fechaProx", txtfechaPago.Text);
                    sc.Parameters.AddWithValue("@atraso", mt);
                    sc.Parameters.AddWithValue("@adelanto", "0");
                    int r;
                    MessageBoxButtons Mess = MessageBoxButtons.YesNo;
                    DialogResult resultado = MessageBox.Show("¿Estas seguro de querer realizar el Adelanto?", "Confirmación:", Mess, MessageBoxIcon.Question);
                    if (resultado == DialogResult.Yes)
                    {
                        r = sc.ExecuteNonQuery();
                        if (r == 1)
                        {
                            MessageBox.Show("Adelanto realizado correctamente!!", "Aviso:", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ////____________GUARDANDO EN PAGO EN UNA TABLA_________________________
                            try
                            {
                                //Insertar Tabla Pagos
                                SqlConnection conne = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString);
                                conne.Open();
                                string iddd = txtID.Text;
                                DataTable dtttt = SqlClase.ObtenerDatos("ObtenerDatosParaPagar", "@id", id);
                                string montorr = dtttt.Rows[0][6].ToString();
                                SqlCommand sscommand = new SqlCommand("RegistrarPagos", conne);
                                sscommand.CommandType = CommandType.StoredProcedure;
                                sscommand.Parameters.AddWithValue("@id", txtID.Text);
                                sscommand.Parameters.AddWithValue("@nombre", txtNombre.Text);
                                sscommand.Parameters.AddWithValue("@f_pago", txtfechaPago.Text);
                                sscommand.Parameters.AddWithValue("@inscripcion", txtIngreso.Text);
                                sscommand.Parameters.AddWithValue("@tipo", tipo);
                                sscommand.Parameters.AddWithValue("@montoAplicado", txtPagar.Text);
                                sscommand.Parameters.AddWithValue("@atraso", txtAtraso.Text);
                                sscommand.Parameters.AddWithValue("@adelanto", txtAdelant.Text);
                                sscommand.Parameters.AddWithValue("@MontoCobrar", montorr);
                                sscommand.Parameters.AddWithValue("@Cant", "Abono A La Deuda En Atraso");
                                sscommand.ExecuteNonQuery();

                                conne.Close();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                            //_____________________________________________________
                            //Para Ocultar Los Controles
                            #region
                            txtMonto.Enabled = false;
                            txtIngreso.Enabled = false;
                            txtPagar.Enabled = false;
                            txtNombre.Enabled = false;
                            txtfechaPago.Enabled = false;
                            btnLimpiarCampos.Enabled = false;
                            btnCobrar.Enabled = false;
                            btnRetornarPago.Enabled = false;
                            txtAdelant.Enabled = false;
                            txtAtraso.Enabled = false;
                            lblVerificarSiSeActivo.Text = "no";
                            cboAdelanto.Enabled = false;
                            txtCoutaMensual.Enabled = false;
                            txtCoutaMensual.Text = "0";
                            txtMonto.Text = "0.0";
                            DgvCobro.DataSource = "";
                            txtNombre.Text = "";
                            txtIngreso.Text = "";
                            txtfechaPago.Text = "";
                            txtPagar.Text = "";
                            cboAdelanto.Text = "";
                            txtAdelant.Text = "0";
                            txtMonto.Text = "0";
                            #endregion
                        }
                        else
                        {
                            MessageBoxButtons m = MessageBoxButtons.OK;
                            MessageBox.Show("han surgido errores, verifica...", "Error:", m, MessageBoxIcon.Stop);
                        }
                    }
                    else
                    {
                        return;
                    }
                    return;
                }
                if (montoaplicado > EnAtraso)
                {
                    int loquequedaDelPago_Pagandoelatraso = montoaplicado - EnAtraso;

                    int montoApagarSinAtraso = int.Parse(montoDeCuotaMensual);
                    int resultadopagonuevo = montoApagarSinAtraso - loquequedaDelPago_Pagandoelatraso;



                    SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString);
                    cn.Open();

                    SqlCommand sc = new SqlCommand("P_Adelantos", cn);
                    sc.CommandType = CommandType.StoredProcedure;
                    sc.Parameters.AddWithValue("@id", id);
                    sc.Parameters.AddWithValue("@monto", resultadopagonuevo);
                    sc.Parameters.AddWithValue("@fechaProx", txtfechaPago.Text);
                    sc.Parameters.AddWithValue("@atraso", "0");
                    sc.Parameters.AddWithValue("@adelanto", loquequedaDelPago_Pagandoelatraso.ToString());
                    int r;
                    MessageBoxButtons Mess = MessageBoxButtons.YesNo;
                    DialogResult resultado = MessageBox.Show("¿Estas seguro de querer realizar el Adelanto?", "Confirmación:", Mess, MessageBoxIcon.Question);
                    if (resultado == DialogResult.Yes)
                    {

                        r = sc.ExecuteNonQuery();
                        if (r == 1)
                        {
                            MessageBox.Show("Adelanto realizado correctamente!!", "Aviso:", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ////____________GUARDANDO EN PAGO EN UNA TABLA_________________________
                            try
                            {
                                //Insertar Tabla Pagos
                                SqlConnection conne = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString);
                                conne.Open();
                                string iddd = txtID.Text;
                                DataTable dtttt = SqlClase.ObtenerDatos("ObtenerDatosParaPagar", "@id", id);
                                string montorr = dtttt.Rows[0][6].ToString();
                                SqlCommand sscommand = new SqlCommand("RegistrarPagos", conne);
                                sscommand.CommandType = CommandType.StoredProcedure;
                                sscommand.Parameters.AddWithValue("@id", txtID.Text);
                                sscommand.Parameters.AddWithValue("@nombre", txtNombre.Text);
                                sscommand.Parameters.AddWithValue("@f_pago", txtfechaPago.Text);
                                sscommand.Parameters.AddWithValue("@inscripcion", txtIngreso.Text);
                                sscommand.Parameters.AddWithValue("@tipo", tipo);
                                sscommand.Parameters.AddWithValue("@montoAplicado", txtPagar.Text);
                                sscommand.Parameters.AddWithValue("@atraso", txtAtraso.Text);
                                sscommand.Parameters.AddWithValue("@adelanto", txtAdelant.Text);
                                sscommand.Parameters.AddWithValue("@MontoCobrar", txtMonto.Text);
                                sscommand.Parameters.AddWithValue("@Cant", "Abono Al Adelanto De Un Mes");
                                sscommand.ExecuteNonQuery();

                                conne.Close();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                            //_____________________________________________________
                            //Para Ocultar Los Controles
                            #region
                            txtMonto.Enabled = false;
                            txtIngreso.Enabled = false;
                            txtPagar.Enabled = false;
                            txtNombre.Enabled = false;
                            txtfechaPago.Enabled = false;
                            btnLimpiarCampos.Enabled = false;
                            btnCobrar.Enabled = false;
                            btnRetornarPago.Enabled = false;
                            txtAdelant.Enabled = false;
                            txtAtraso.Enabled = false;
                            lblVerificarSiSeActivo.Text = "no";
                            cboAdelanto.Enabled = false;
                            txtCoutaMensual.Enabled = false;
                            txtCoutaMensual.Text = "0";
                            txtMonto.Text = "0.0";
                            DgvCobro.DataSource = "";
                            txtNombre.Text = "";
                            txtIngreso.Text = "";
                            txtfechaPago.Text = "";
                            txtPagar.Text = "";
                            cboAdelanto.Text = "";
                            txtAdelant.Text = "0";
                            txtMonto.Text = "0";
                            #endregion
                        }
                        else
                        {
                            MessageBoxButtons m = MessageBoxButtons.OK;
                            MessageBox.Show("han surgido errores, verifica...", "Error:", m, MessageBoxIcon.Stop);
                        }
                    }
                    else
                    {
                        return;
                    }
                    return;
                }


            }
            if (cboAdelanto.Text == "2  Meses")
            {


                string Aplicado = txtPagar.Text;
                int _aplicado = int.Parse(Aplicado);


                string a_pagar = txtMonto.Text;
                int pagar = int.Parse(a_pagar);

                int mreal = int.Parse(montoDeCuotaMensual);

                int paraValidar = pagar - mreal;

                if (_aplicado < paraValidar)
                {
                    MessageBox.Show("El Monto Aplicado No Corresponde Al Minimo A Pagar En Los Meses Seleccionados", "Error:");
                    return;
                }
                if (_aplicado > pagar)
                {
                    MessageBox.Show("El Monto Aplicado No Corresponde Al Maximo A Pagar En Los Meses Seleccionados", "Error:");
                    return;
                }

                if (_aplicado == pagar)
                {
                    fechapago = fechapago.AddMonths(2);
                    //Conexionnn .............
                    SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString);
                    cn.Open();

                    SqlCommand sc = new SqlCommand("PagoMensualidad", cn);
                    sc.CommandType = CommandType.StoredProcedure;
                    sc.Parameters.AddWithValue("@id", id);
                    sc.Parameters.AddWithValue("@monto", montoDeCuotaMensual);
                    sc.Parameters.AddWithValue("@fechaProx", fechapago.ToString("dd/MM/yyyy"));
                    sc.Parameters.AddWithValue("@atraso", "0");
                    sc.Parameters.AddWithValue("@adelanto", "0");
                    int r;
                    MessageBoxButtons Mess = MessageBoxButtons.YesNo;
                    DialogResult resultado = MessageBox.Show("¿Estas seguro de querer realizar el Adelanto?", "Confirmación:", Mess, MessageBoxIcon.Question);
                    if (resultado == DialogResult.Yes)
                    {
                        r = sc.ExecuteNonQuery();
                        if (r == 1)
                        {
                            MessageBox.Show("Adelanto realizado correctamente!!", "Aviso:", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ////____________GUARDANDO EN PAGO EN UNA TABLA_________________________
                            try
                            {
                                //Insertar Tabla Pagos
                                SqlConnection conne = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString);
                                conne.Open();
                                string iddd = txtID.Text;
                                DataTable dtttt = SqlClase.ObtenerDatos("ObtenerDatosParaPagar", "@id", id);
                                string montorr = dtttt.Rows[0][6].ToString();
                                SqlCommand sscommand = new SqlCommand("RegistrarPagos", conne);
                                sscommand.CommandType = CommandType.StoredProcedure;
                                sscommand.Parameters.AddWithValue("@id", txtID.Text);
                                sscommand.Parameters.AddWithValue("@nombre", txtNombre.Text);
                                sscommand.Parameters.AddWithValue("@f_pago", txtfechaPago.Text);
                                sscommand.Parameters.AddWithValue("@inscripcion", txtIngreso.Text);
                                sscommand.Parameters.AddWithValue("@tipo", tipo);
                                sscommand.Parameters.AddWithValue("@montoAplicado", txtPagar.Text);
                                sscommand.Parameters.AddWithValue("@atraso", txtAtraso.Text);
                                sscommand.Parameters.AddWithValue("@adelanto", txtAdelant.Text);
                                sscommand.Parameters.AddWithValue("@MontoCobrar", montorr);
                                sscommand.Parameters.AddWithValue("@Cant", "Dos Meses En Adelanto");
                                sscommand.ExecuteNonQuery();

                                conne.Close();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                            //_____________________________________________________
                            //Para Ocultar Los Controles
                            #region
                            txtMonto.Enabled = false;
                            txtIngreso.Enabled = false;
                            txtPagar.Enabled = false;
                            txtNombre.Enabled = false;
                            txtfechaPago.Enabled = false;
                            btnLimpiarCampos.Enabled = false;
                            btnCobrar.Enabled = false;
                            btnRetornarPago.Enabled = false;
                            txtAdelant.Enabled = false;
                            txtAtraso.Enabled = false;
                            lblVerificarSiSeActivo.Text = "no";
                            cboAdelanto.Enabled = false;
                            txtCoutaMensual.Enabled = false;
                            txtCoutaMensual.Text = "0";
                            txtMonto.Text = "0.0";
                            DgvCobro.DataSource = "";
                            txtNombre.Text = "";
                            txtIngreso.Text = "";
                            txtfechaPago.Text = "";
                            txtPagar.Text = "";
                            cboAdelanto.Text = "";
                            txtAdelant.Text = "0";
                            txtMonto.Text = "0";
                            #endregion
                        }
                        else
                        {
                            MessageBoxButtons m = MessageBoxButtons.OK;
                            MessageBox.Show("han surgido errores, verifica...", "Error:", m, MessageBoxIcon.Stop);
                        }
                    }
                    else
                    {
                        return;
                    }
                    return;
                }
                if (_aplicado < pagar)
                {
                    int pago = pagar - _aplicado;
                    fechapago = fechapago.AddMonths(1);


                    //Conexionnn .............
                    SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString);
                    cn.Open();

                    SqlCommand sc = new SqlCommand("PagoMensualidad", cn);
                    sc.CommandType = CommandType.StoredProcedure;
                    sc.Parameters.AddWithValue("@id", id);
                    sc.Parameters.AddWithValue("@monto", pago);
                    sc.Parameters.AddWithValue("@fechaProx", fechapago.ToString("dd/MM/yyyy"));
                    sc.Parameters.AddWithValue("@atraso", "0");
                    sc.Parameters.AddWithValue("@adelanto", _aplicado.ToString());
                    int r;
                    MessageBoxButtons Mess = MessageBoxButtons.YesNo;
                    DialogResult resultado = MessageBox.Show("¿Estas seguro de querer realizar el Adelanto?", "Confirmación:", Mess, MessageBoxIcon.Question);
                    if (resultado == DialogResult.Yes)
                    {
                        r = sc.ExecuteNonQuery();
                        if (r == 1)
                        {
                            MessageBox.Show("Adelanto realizado correctamente!!", "Aviso:", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ////____________GUARDANDO EN PAGO EN UNA TABLA_________________________
                            try
                            {
                                //Insertar Tabla Pagos
                                SqlConnection conne = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString);
                                conne.Open();
                                string iddd = txtID.Text;
                                DataTable dtttt = SqlClase.ObtenerDatos("ObtenerDatosParaPagar", "@id", id);
                                string montorr = dtttt.Rows[0][6].ToString();
                                SqlCommand sscommand = new SqlCommand("RegistrarPagos", conne);
                                sscommand.CommandType = CommandType.StoredProcedure;
                                sscommand.Parameters.AddWithValue("@id", txtID.Text);
                                sscommand.Parameters.AddWithValue("@nombre", txtNombre.Text);
                                sscommand.Parameters.AddWithValue("@f_pago", txtfechaPago.Text);
                                sscommand.Parameters.AddWithValue("@inscripcion", txtIngreso.Text);
                                sscommand.Parameters.AddWithValue("@tipo", tipo);
                                sscommand.Parameters.AddWithValue("@montoAplicado", txtPagar.Text);
                                sscommand.Parameters.AddWithValue("@atraso", txtAtraso.Text);
                                sscommand.Parameters.AddWithValue("@adelanto", txtAdelant.Text);
                                sscommand.Parameters.AddWithValue("@MontoCobrar", montorr);
                                sscommand.Parameters.AddWithValue("@Cant", "Abono A Dos Meses En Adelanto");
                                sscommand.ExecuteNonQuery();

                                conne.Close();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                            //_____________________________________________________
                            //Para Ocultar Los Controles
                            #region
                            txtMonto.Enabled = false;
                            txtIngreso.Enabled = false;
                            txtPagar.Enabled = false;
                            txtNombre.Enabled = false;
                            txtfechaPago.Enabled = false;
                            btnLimpiarCampos.Enabled = false;
                            btnCobrar.Enabled = false;
                            btnRetornarPago.Enabled = false;
                            txtAdelant.Enabled = false;
                            txtAtraso.Enabled = false;
                            lblVerificarSiSeActivo.Text = "no";
                            cboAdelanto.Enabled = false;
                            txtCoutaMensual.Enabled = false;
                            txtCoutaMensual.Text = "0";
                            txtMonto.Text = "0.0";
                            DgvCobro.DataSource = "";
                            txtNombre.Text = "";
                            txtIngreso.Text = "";
                            txtfechaPago.Text = "";
                            txtPagar.Text = "";
                            cboAdelanto.Text = "";
                            txtAdelant.Text = "0";
                            txtMonto.Text = "0";
                            #endregion
                        }
                        else
                        {
                            MessageBoxButtons m = MessageBoxButtons.OK;
                            MessageBox.Show("han surgido errores, verifica...", "Error:", m, MessageBoxIcon.Stop);
                        }
                    }
                    else
                    {
                        return;
                    }
                    return;
                }


            }
            if (cboAdelanto.Text == "3 Meses")
            {


                string Aplicado = txtPagar.Text;
                int _aplicado = int.Parse(Aplicado);


                string a_pagar = txtMonto.Text;
                int pagar = int.Parse(a_pagar);

                int mreal = int.Parse(montoDeCuotaMensual);
                mreal = mreal * 2;
                int paraValidar = pagar - mreal;

                if (_aplicado < paraValidar)
                {
                    MessageBox.Show("El Monto Aplicado No Corresponde Al Minimo A Pagar En Los Meses Seleccionados", "Error:");
                    return;
                }
                if (_aplicado > pagar)
                {
                    MessageBox.Show("El Monto Aplicado No Corresponde Al Maximo A Pagar En Los Meses Seleccionados", "Error:");
                    return;
                }

                if (_aplicado == pagar)
                {
                    fechapago = fechapago.AddMonths(3);
                    //Conexionnn .............
                    SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString);
                    cn.Open();

                    SqlCommand sc = new SqlCommand("PagoMensualidad", cn);
                    sc.CommandType = CommandType.StoredProcedure;
                    sc.Parameters.AddWithValue("@id", id);
                    sc.Parameters.AddWithValue("@monto", montoDeCuotaMensual);
                    sc.Parameters.AddWithValue("@fechaProx", fechapago.ToString("dd/MM/yyyy"));
                    sc.Parameters.AddWithValue("@atraso", "0");
                    sc.Parameters.AddWithValue("@adelanto", "0");
                    int r;
                    MessageBoxButtons Mess = MessageBoxButtons.YesNo;
                    DialogResult resultado = MessageBox.Show("¿Estas seguro de querer realizar el Adelanto?", "Confirmación:", Mess, MessageBoxIcon.Question);
                    if (resultado == DialogResult.Yes)
                    {
                        r = sc.ExecuteNonQuery();
                        if (r == 1)
                        {
                            MessageBox.Show("Adelanto realizado correctamente!!", "Aviso:", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ////____________GUARDANDO EN PAGO EN UNA TABLA_________________________
                            try
                            {
                                //Insertar Tabla Pagos
                                SqlConnection conne = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString);
                                conne.Open();
                                string iddd = txtID.Text;
                                DataTable dtttt = SqlClase.ObtenerDatos("ObtenerDatosParaPagar", "@id", id);
                                string montorr = dtttt.Rows[0][6].ToString();
                                SqlCommand sscommand = new SqlCommand("RegistrarPagos", conne);
                                sscommand.CommandType = CommandType.StoredProcedure;
                                sscommand.Parameters.AddWithValue("@id", txtID.Text);
                                sscommand.Parameters.AddWithValue("@nombre", txtNombre.Text);
                                sscommand.Parameters.AddWithValue("@f_pago", txtfechaPago.Text);
                                sscommand.Parameters.AddWithValue("@inscripcion", txtIngreso.Text);
                                sscommand.Parameters.AddWithValue("@tipo", tipo);
                                sscommand.Parameters.AddWithValue("@montoAplicado", txtPagar.Text);
                                sscommand.Parameters.AddWithValue("@atraso", txtAtraso.Text);
                                sscommand.Parameters.AddWithValue("@adelanto", txtAdelant.Text);
                                sscommand.Parameters.AddWithValue("@MontoCobrar", montorr);
                                sscommand.Parameters.AddWithValue("@Cant", "Tres Meses En Adelanto");
                                sscommand.ExecuteNonQuery();

                                conne.Close();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                            //_____________________________________________________
                            //Para Ocultar Los Controles
                            #region
                            txtMonto.Enabled = false;
                            txtIngreso.Enabled = false;
                            txtPagar.Enabled = false;
                            txtNombre.Enabled = false;
                            txtfechaPago.Enabled = false;
                            btnLimpiarCampos.Enabled = false;
                            btnCobrar.Enabled = false;
                            btnRetornarPago.Enabled = false;
                            txtAdelant.Enabled = false;
                            txtAtraso.Enabled = false;
                            lblVerificarSiSeActivo.Text = "no";
                            cboAdelanto.Enabled = false;
                            txtCoutaMensual.Enabled = false;
                            txtCoutaMensual.Text = "0";
                            txtMonto.Text = "0.0";
                            DgvCobro.DataSource = "";
                            txtNombre.Text = "";
                            txtIngreso.Text = "";
                            txtfechaPago.Text = "";
                            txtPagar.Text = "";
                            cboAdelanto.Text = "";
                            txtAdelant.Text = "0";
                            txtMonto.Text = "0";
                            #endregion
                        }
                        else
                        {
                            MessageBoxButtons m = MessageBoxButtons.OK;
                            MessageBox.Show("han surgido errores, verifica...", "Error:", m, MessageBoxIcon.Stop);
                        }
                    }
                    else
                    {
                        return;
                    }
                    return;
                }
                if (_aplicado < pagar)
                {
                    int pago = pagar - _aplicado;
                    fechapago = fechapago.AddMonths(2);
                    //Conexionnn .............
                    SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString);
                    cn.Open();

                    SqlCommand sc = new SqlCommand("PagoMensualidad", cn);
                    sc.CommandType = CommandType.StoredProcedure;
                    sc.Parameters.AddWithValue("@id", id);
                    sc.Parameters.AddWithValue("@monto", pago);
                    sc.Parameters.AddWithValue("@fechaProx", fechapago.ToString("dd/MM/yyyy"));
                    sc.Parameters.AddWithValue("@atraso", "0");
                    sc.Parameters.AddWithValue("@adelanto", _aplicado.ToString());
                    int r;
                    MessageBoxButtons Mess = MessageBoxButtons.YesNo;
                    DialogResult resultado = MessageBox.Show("¿Estas seguro de querer realizar el Adelanto?", "Confirmación:", Mess, MessageBoxIcon.Question);
                    if (resultado == DialogResult.Yes)
                    {
                        r = sc.ExecuteNonQuery();
                        if (r == 1)
                        {
                            MessageBox.Show("Adelanto realizado correctamente!!", "Aviso:", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ////____________GUARDANDO EN PAGO EN UNA TABLA_________________________
                            try
                            {
                                //Insertar Tabla Pagos
                                SqlConnection conne = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString);
                                conne.Open();
                                string iddd = txtID.Text;
                                DataTable dtttt = SqlClase.ObtenerDatos("ObtenerDatosParaPagar", "@id", id);
                                string montorr = dtttt.Rows[0][6].ToString();
                                SqlCommand sscommand = new SqlCommand("RegistrarPagos", conne);
                                sscommand.CommandType = CommandType.StoredProcedure;
                                sscommand.Parameters.AddWithValue("@id", txtID.Text);
                                sscommand.Parameters.AddWithValue("@nombre", txtNombre.Text);
                                sscommand.Parameters.AddWithValue("@f_pago", txtfechaPago.Text);
                                sscommand.Parameters.AddWithValue("@inscripcion", txtIngreso.Text);
                                sscommand.Parameters.AddWithValue("@tipo", tipo);
                                sscommand.Parameters.AddWithValue("@montoAplicado", txtPagar.Text);
                                sscommand.Parameters.AddWithValue("@atraso", txtAtraso.Text);
                                sscommand.Parameters.AddWithValue("@adelanto", txtAdelant.Text);
                                sscommand.Parameters.AddWithValue("@MontoCobrar", montorr);
                                sscommand.Parameters.AddWithValue("@Cant", "Abono A Tres Meses En Adelanto");
                                sscommand.ExecuteNonQuery();

                                conne.Close();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                            //_____________________________________________________
                            //Para Ocultar Los Controles
                            #region
                            txtMonto.Enabled = false;
                            txtIngreso.Enabled = false;
                            txtPagar.Enabled = false;
                            txtNombre.Enabled = false;
                            txtfechaPago.Enabled = false;
                            btnLimpiarCampos.Enabled = false;
                            btnCobrar.Enabled = false;
                            btnRetornarPago.Enabled = false;
                            txtAdelant.Enabled = false;
                            txtAtraso.Enabled = false;
                            lblVerificarSiSeActivo.Text = "no";
                            cboAdelanto.Enabled = false;
                            txtCoutaMensual.Enabled = false;
                            txtCoutaMensual.Text = "0";
                            txtMonto.Text = "0.0";
                            DgvCobro.DataSource = "";
                            txtNombre.Text = "";
                            txtIngreso.Text = "";
                            txtfechaPago.Text = "";
                            txtPagar.Text = "";
                            cboAdelanto.Text = "";
                            txtAdelant.Text = "0";
                            txtMonto.Text = "0";
                            #endregion
                        }
                        else
                        {
                            MessageBoxButtons m = MessageBoxButtons.OK;
                            MessageBox.Show("han surgido errores, verifica...", "Error:", m, MessageBoxIcon.Stop);
                        }
                    }
                    else
                    {
                        return;
                    }
                    return;
                }

            }
            if (cboAdelanto.Text == "4 Meses")
            {


                string Aplicado = txtPagar.Text;
                int _aplicado = int.Parse(Aplicado);


                string a_pagar = txtMonto.Text;
                int pagar = int.Parse(a_pagar);

                int mreal = int.Parse(montoDeCuotaMensual);
                mreal = mreal * 3;
                int paraValidar = pagar - mreal;

                if (_aplicado < paraValidar)
                {
                    MessageBox.Show("El Monto Aplicado No Corresponde Al Minimo A Pagar En Los Meses Seleccionados", "Error:");
                    return;
                }
                if (_aplicado > pagar)
                {
                    MessageBox.Show("El Monto Aplicado No Corresponde Al Maximo A Pagar En Los Meses Seleccionados", "Error:");
                    return;
                }

                if (_aplicado == pagar)
                {
                    fechapago = fechapago.AddMonths(4);
                    //Conexionnn .............
                    SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString);
                    cn.Open();

                    SqlCommand sc = new SqlCommand("PagoMensualidad", cn);
                    sc.CommandType = CommandType.StoredProcedure;
                    sc.Parameters.AddWithValue("@id", id);
                    sc.Parameters.AddWithValue("@monto", montoDeCuotaMensual);
                    sc.Parameters.AddWithValue("@fechaProx", fechapago.ToString("dd/MM/yyyy"));
                    sc.Parameters.AddWithValue("@atraso", "0");
                    sc.Parameters.AddWithValue("@adelanto", "0");
                    int r;
                    MessageBoxButtons Mess = MessageBoxButtons.YesNo;
                    DialogResult resultado = MessageBox.Show("¿Estas seguro de querer realizar el Adelanto?", "Confirmación:", Mess, MessageBoxIcon.Question);
                    if (resultado == DialogResult.Yes)
                    {
                        r = sc.ExecuteNonQuery();
                        if (r == 1)
                        {
                            MessageBox.Show("Adelanto realizado correctamente!!", "Aviso:", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ////____________GUARDANDO EN PAGO EN UNA TABLA_________________________
                            try
                            {
                                //Insertar Tabla Pagos
                                SqlConnection conne = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString);
                                conne.Open();
                                string iddd = txtID.Text;
                                DataTable dtttt = SqlClase.ObtenerDatos("ObtenerDatosParaPagar", "@id", id);
                                string montorr = dtttt.Rows[0][6].ToString();
                                SqlCommand sscommand = new SqlCommand("RegistrarPagos", conne);
                                sscommand.CommandType = CommandType.StoredProcedure;
                                sscommand.Parameters.AddWithValue("@id", txtID.Text);
                                sscommand.Parameters.AddWithValue("@nombre", txtNombre.Text);
                                sscommand.Parameters.AddWithValue("@f_pago", txtfechaPago.Text);
                                sscommand.Parameters.AddWithValue("@inscripcion", txtIngreso.Text);
                                sscommand.Parameters.AddWithValue("@tipo", tipo);
                                sscommand.Parameters.AddWithValue("@montoAplicado", txtPagar.Text);
                                sscommand.Parameters.AddWithValue("@atraso", txtAtraso.Text);
                                sscommand.Parameters.AddWithValue("@adelanto", txtAdelant.Text);
                                sscommand.Parameters.AddWithValue("@MontoCobrar", montorr);
                                sscommand.Parameters.AddWithValue("@Cant", "Cuatro Meses En Adelanto");
                                sscommand.ExecuteNonQuery();

                                conne.Close();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                            //_____________________________________________________
                            //Para Ocultar Los Controles
                            #region
                            txtMonto.Enabled = false;
                            txtIngreso.Enabled = false;
                            txtPagar.Enabled = false;
                            txtNombre.Enabled = false;
                            txtfechaPago.Enabled = false;
                            btnLimpiarCampos.Enabled = false;
                            btnCobrar.Enabled = false;
                            btnRetornarPago.Enabled = false;
                            txtAdelant.Enabled = false;
                            txtAtraso.Enabled = false;
                            lblVerificarSiSeActivo.Text = "no";
                            cboAdelanto.Enabled = false;
                            txtCoutaMensual.Enabled = false;
                            txtCoutaMensual.Text = "0";
                            txtMonto.Text = "0.0";
                            DgvCobro.DataSource = "";
                            txtNombre.Text = "";
                            txtIngreso.Text = "";
                            txtfechaPago.Text = "";
                            txtPagar.Text = "";
                            cboAdelanto.Text = "";
                            txtAdelant.Text = "0";
                            txtMonto.Text = "0";
                            #endregion
                        }
                        else
                        {
                            MessageBoxButtons m = MessageBoxButtons.OK;
                            MessageBox.Show("han surgido errores, verifica...", "Error:", m, MessageBoxIcon.Stop);
                        }
                    }
                    else
                    {
                        return;
                    }
                    return;
                }
                if (_aplicado < pagar)
                {
                    int pago = pagar - _aplicado;
                    fechapago = fechapago.AddMonths(3);
                    //Conexionnn .............
                    SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString);
                    cn.Open();

                    SqlCommand sc = new SqlCommand("PagoMensualidad", cn);
                    sc.CommandType = CommandType.StoredProcedure;
                    sc.Parameters.AddWithValue("@id", id);
                    sc.Parameters.AddWithValue("@monto", pago);
                    sc.Parameters.AddWithValue("@fechaProx", fechapago.ToString("dd/MM/yyyy"));
                    sc.Parameters.AddWithValue("@atraso", "0");
                    sc.Parameters.AddWithValue("@adelanto", _aplicado.ToString());
                    int r;
                    MessageBoxButtons Mess = MessageBoxButtons.YesNo;
                    DialogResult resultado = MessageBox.Show("¿Estas seguro de querer realizar el Adelanto?", "Confirmación:", Mess, MessageBoxIcon.Question);
                    if (resultado == DialogResult.Yes)
                    {
                        r = sc.ExecuteNonQuery();
                        if (r == 1)
                        {
                            MessageBox.Show("Adelanto realizado correctamente!!", "Aviso:", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ////____________GUARDANDO EN PAGO EN UNA TABLA_________________________
                            try
                            {
                                //Insertar Tabla Pagos
                                SqlConnection conne = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString);
                                conne.Open();
                                string iddd = txtID.Text;
                                DataTable dtttt = SqlClase.ObtenerDatos("ObtenerDatosParaPagar", "@id", id);
                                string montorr = dtttt.Rows[0][6].ToString();
                                SqlCommand sscommand = new SqlCommand("RegistrarPagos", conne);
                                sscommand.CommandType = CommandType.StoredProcedure;
                                sscommand.Parameters.AddWithValue("@id", txtID.Text);
                                sscommand.Parameters.AddWithValue("@nombre", txtNombre.Text);
                                sscommand.Parameters.AddWithValue("@f_pago", txtfechaPago.Text);
                                sscommand.Parameters.AddWithValue("@inscripcion", txtIngreso.Text);
                                sscommand.Parameters.AddWithValue("@tipo", tipo);
                                sscommand.Parameters.AddWithValue("@montoAplicado", txtPagar.Text);
                                sscommand.Parameters.AddWithValue("@atraso", txtAtraso.Text);
                                sscommand.Parameters.AddWithValue("@adelanto", txtAdelant.Text);
                                sscommand.Parameters.AddWithValue("@MontoCobrar", montorr);
                                sscommand.Parameters.AddWithValue("@Cant", "Abono A Cuatro Meses En Adelanto");
                                sscommand.ExecuteNonQuery();

                                conne.Close();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                            //_____________________________________________________
                            //Para Ocultar Los Controles
                            #region
                            txtMonto.Enabled = false;
                            txtIngreso.Enabled = false;
                            txtPagar.Enabled = false;
                            txtNombre.Enabled = false;
                            txtfechaPago.Enabled = false;
                            btnLimpiarCampos.Enabled = false;
                            btnCobrar.Enabled = false;
                            btnRetornarPago.Enabled = false;
                            txtAdelant.Enabled = false;
                            txtAtraso.Enabled = false;
                            lblVerificarSiSeActivo.Text = "no";
                            cboAdelanto.Enabled = false;
                            txtCoutaMensual.Enabled = false;
                            txtCoutaMensual.Text = "0";
                            txtMonto.Text = "0.0";
                            DgvCobro.DataSource = "";
                            txtNombre.Text = "";
                            txtIngreso.Text = "";
                            txtfechaPago.Text = "";
                            txtPagar.Text = "";
                            cboAdelanto.Text = "";
                            txtAdelant.Text = "0";
                            txtMonto.Text = "0";
                            #endregion
                        }
                        else
                        {
                            MessageBoxButtons m = MessageBoxButtons.OK;
                            MessageBox.Show("han surgido errores, verifica...", "Error:", m, MessageBoxIcon.Stop);
                        }
                    }
                    else
                    {
                        return;
                    }
                    return;
                }

            }
            if (cboAdelanto.Text == "5 Meses")
            {

                string Aplicado = txtPagar.Text;
                int _aplicado = int.Parse(Aplicado);


                string a_pagar = txtMonto.Text;
                int pagar = int.Parse(a_pagar);

                int mreal = int.Parse(montoDeCuotaMensual);
                mreal = mreal * 4;
                int paraValidar = pagar - mreal;

                if (_aplicado < paraValidar)
                {
                    MessageBox.Show("El Monto Aplicado No Corresponde Al Minimo A Pagar En Los Meses Seleccionados", "Error:");
                    return;
                }
                if (_aplicado > pagar)
                {
                    MessageBox.Show("El Monto Aplicado No Corresponde Al Maximo A Pagar En Los Meses Seleccionados", "Error:");
                    return;
                }

                if (_aplicado == pagar)
                {
                    fechapago = fechapago.AddMonths(5);
                    //Conexionnn .............
                    SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString);
                    cn.Open();

                    SqlCommand sc = new SqlCommand("PagoMensualidad", cn);
                    sc.CommandType = CommandType.StoredProcedure;
                    sc.Parameters.AddWithValue("@id", id);
                    sc.Parameters.AddWithValue("@monto", montoDeCuotaMensual);
                    sc.Parameters.AddWithValue("@fechaProx", fechapago.ToString("dd/MM/yyyy"));
                    sc.Parameters.AddWithValue("@atraso", "0");
                    sc.Parameters.AddWithValue("@adelanto", "0");
                    int r;
                    MessageBoxButtons Mess = MessageBoxButtons.YesNo;
                    DialogResult resultado = MessageBox.Show("¿Estas seguro de querer realizar el Adelanto?", "Confirmación:", Mess, MessageBoxIcon.Question);
                    if (resultado == DialogResult.Yes)
                    {
                        r = sc.ExecuteNonQuery();
                        if (r == 1)
                        {
                            MessageBox.Show("Adelanto realizado correctamente!!", "Aviso:", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ////____________GUARDANDO EN PAGO EN UNA TABLA_________________________
                            try
                            {
                                //Insertar Tabla Pagos
                                SqlConnection conne = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString);
                                conne.Open();
                                string iddd = txtID.Text;
                                DataTable dtttt = SqlClase.ObtenerDatos("ObtenerDatosParaPagar", "@id", id);
                                string montorr = dtttt.Rows[0][6].ToString();
                                SqlCommand sscommand = new SqlCommand("RegistrarPagos", conne);
                                sscommand.CommandType = CommandType.StoredProcedure;
                                sscommand.Parameters.AddWithValue("@id", txtID.Text);
                                sscommand.Parameters.AddWithValue("@nombre", txtNombre.Text);
                                sscommand.Parameters.AddWithValue("@f_pago", txtfechaPago.Text);
                                sscommand.Parameters.AddWithValue("@inscripcion", txtIngreso.Text);
                                sscommand.Parameters.AddWithValue("@tipo", tipo);
                                sscommand.Parameters.AddWithValue("@montoAplicado", txtPagar.Text);
                                sscommand.Parameters.AddWithValue("@atraso", txtAtraso.Text);
                                sscommand.Parameters.AddWithValue("@adelanto", txtAdelant.Text);
                                sscommand.Parameters.AddWithValue("@MontoCobrar", montorr);
                                sscommand.Parameters.AddWithValue("@Cant", "Cinco Meses En Adelanto");
                                sscommand.ExecuteNonQuery();

                                conne.Close();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                            //_____________________________________________________
                            //Para Ocultar Los Controles
                            #region
                            txtMonto.Enabled = false;
                            txtIngreso.Enabled = false;
                            txtPagar.Enabled = false;
                            txtNombre.Enabled = false;
                            txtfechaPago.Enabled = false;
                            btnLimpiarCampos.Enabled = false;
                            btnCobrar.Enabled = false;
                            btnRetornarPago.Enabled = false;
                            txtAdelant.Enabled = false;
                            txtAtraso.Enabled = false;
                            lblVerificarSiSeActivo.Text = "no";
                            cboAdelanto.Enabled = false;
                            txtCoutaMensual.Enabled = false;
                            txtCoutaMensual.Text = "0";
                            txtMonto.Text = "0.0";
                            DgvCobro.DataSource = "";
                            txtNombre.Text = "";
                            txtIngreso.Text = "";
                            txtfechaPago.Text = "";
                            txtPagar.Text = "";
                            cboAdelanto.Text = "";
                            txtAdelant.Text = "0";
                            txtMonto.Text = "0";
                            #endregion
                        }
                        else
                        {
                            MessageBoxButtons m = MessageBoxButtons.OK;
                            MessageBox.Show("han surgido errores, verifica...", "Error:", m, MessageBoxIcon.Stop);
                        }
                    }
                    else
                    {
                        return;
                    }
                    return;
                }
                if (_aplicado < pagar)
                {
                    int pago = pagar - _aplicado;
                    fechapago = fechapago.AddMonths(4);
                    //Conexionnn .............
                    SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString);
                    cn.Open();

                    SqlCommand sc = new SqlCommand("PagoMensualidad", cn);
                    sc.CommandType = CommandType.StoredProcedure;
                    sc.Parameters.AddWithValue("@id", id);
                    sc.Parameters.AddWithValue("@monto", pago);
                    sc.Parameters.AddWithValue("@fechaProx", fechapago.ToString("dd/MM/yyyy"));
                    sc.Parameters.AddWithValue("@atraso", "0");
                    sc.Parameters.AddWithValue("@adelanto", _aplicado.ToString());
                    int r;
                    MessageBoxButtons Mess = MessageBoxButtons.YesNo;
                    DialogResult resultado = MessageBox.Show("¿Estas seguro de querer realizar el Adelanto?", "Confirmación:", Mess, MessageBoxIcon.Question);
                    if (resultado == DialogResult.Yes)
                    {
                        r = sc.ExecuteNonQuery();
                        if (r == 1)
                        {
                            MessageBox.Show("Adelanto realizado correctamente!!", "Aviso:", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ////____________GUARDANDO EN PAGO EN UNA TABLA_________________________
                            try
                            {
                                //Insertar Tabla Pagos
                                SqlConnection conne = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString);
                                conne.Open();
                                string iddd = txtID.Text;
                                DataTable dtttt = SqlClase.ObtenerDatos("ObtenerDatosParaPagar", "@id", id);
                                string montorr = dtttt.Rows[0][6].ToString();
                                SqlCommand sscommand = new SqlCommand("RegistrarPagos", conne);
                                sscommand.CommandType = CommandType.StoredProcedure;
                                sscommand.Parameters.AddWithValue("@id", txtID.Text);
                                sscommand.Parameters.AddWithValue("@nombre", txtNombre.Text);
                                sscommand.Parameters.AddWithValue("@f_pago", txtfechaPago.Text);
                                sscommand.Parameters.AddWithValue("@inscripcion", txtIngreso.Text);
                                sscommand.Parameters.AddWithValue("@tipo", tipo);
                                sscommand.Parameters.AddWithValue("@montoAplicado", txtPagar.Text);
                                sscommand.Parameters.AddWithValue("@atraso", txtAtraso.Text);
                                sscommand.Parameters.AddWithValue("@adelanto", txtAdelant.Text);
                                sscommand.Parameters.AddWithValue("@MontoCobrar", montorr);
                                sscommand.Parameters.AddWithValue("@Cant", "Abono A Cinco Meses En Adelanto");
                                sscommand.ExecuteNonQuery();

                                conne.Close();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                            //_____________________________________________________
                            //Para Ocultar Los Controles
                            #region
                            txtMonto.Enabled = false;
                            txtIngreso.Enabled = false;
                            txtPagar.Enabled = false;
                            txtNombre.Enabled = false;
                            txtfechaPago.Enabled = false;
                            btnLimpiarCampos.Enabled = false;
                            btnCobrar.Enabled = false;
                            btnRetornarPago.Enabled = false;
                            txtAdelant.Enabled = false;
                            txtAtraso.Enabled = false;
                            lblVerificarSiSeActivo.Text = "no";
                            cboAdelanto.Enabled = false;
                            txtCoutaMensual.Enabled = false;
                            txtCoutaMensual.Text = "0";
                            txtMonto.Text = "0.0";
                            DgvCobro.DataSource = "";
                            txtNombre.Text = "";
                            txtIngreso.Text = "";
                            txtfechaPago.Text = "";
                            txtPagar.Text = "";
                            cboAdelanto.Text = "";
                            txtAdelant.Text = "0";
                            txtMonto.Text = "0";
                            #endregion
                        }
                        else
                        {
                            MessageBoxButtons m = MessageBoxButtons.OK;
                            MessageBox.Show("han surgido errores, verifica...", "Error:", m, MessageBoxIcon.Stop);
                        }
                    }
                    else
                    {
                        return;
                    }
                    return;
                }

            }
            if (cboAdelanto.Text == "6 Meses")
            {


                string Aplicado = txtPagar.Text;
                int _aplicado = int.Parse(Aplicado);


                string a_pagar = txtMonto.Text;
                int pagar = int.Parse(a_pagar);

                int mreal = int.Parse(montoDeCuotaMensual);
                mreal = mreal * 5;
                int paraValidar = pagar - mreal;

                if (_aplicado < paraValidar)
                {
                    MessageBox.Show("El Monto Aplicado No Corresponde Al Minimo A Pagar En Los Meses Seleccionados", "Error:");
                    return;
                }
                if (_aplicado > pagar)
                {
                    MessageBox.Show("El Monto Aplicado No Corresponde Al Maximo A Pagar En Los Meses Seleccionados", "Error:");
                    return;
                }

                if (_aplicado == pagar)
                {
                    fechapago = fechapago.AddMonths(6);
                    //Conexionnn .............
                    SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString);
                    cn.Open();

                    SqlCommand sc = new SqlCommand("PagoMensualidad", cn);
                    sc.CommandType = CommandType.StoredProcedure;
                    sc.Parameters.AddWithValue("@id", id);
                    sc.Parameters.AddWithValue("@monto", montoDeCuotaMensual);
                    sc.Parameters.AddWithValue("@fechaProx", fechapago.ToString("dd/MM/yyyy"));
                    sc.Parameters.AddWithValue("@atraso", "0");
                    sc.Parameters.AddWithValue("@adelanto", "0");
                    int r;
                    MessageBoxButtons Mess = MessageBoxButtons.YesNo;
                    DialogResult resultado = MessageBox.Show("¿Estas seguro de querer realizar el Adelanto?", "Confirmación:", Mess, MessageBoxIcon.Question);
                    if (resultado == DialogResult.Yes)
                    {
                        r = sc.ExecuteNonQuery();
                        if (r == 1)
                        {
                            MessageBox.Show("Adelanto realizado correctamente!!", "Aviso:", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //_____________________________________________________
                            ////____________GUARDANDO EN PAGO EN UNA TABLA_________________________
                            try
                            {
                                //Insertar Tabla Pagos
                                SqlConnection conne = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString);
                                conne.Open();
                                string iddd = txtID.Text;
                                DataTable dtttt = SqlClase.ObtenerDatos("ObtenerDatosParaPagar", "@id", id);
                                string montorr = dtttt.Rows[0][6].ToString();
                                SqlCommand sscommand = new SqlCommand("RegistrarPagos", conne);
                                sscommand.CommandType = CommandType.StoredProcedure;
                                sscommand.Parameters.AddWithValue("@id", txtID.Text);
                                sscommand.Parameters.AddWithValue("@nombre", txtNombre.Text);
                                sscommand.Parameters.AddWithValue("@f_pago", txtfechaPago.Text);
                                sscommand.Parameters.AddWithValue("@inscripcion", txtIngreso.Text);
                                sscommand.Parameters.AddWithValue("@tipo", tipo);
                                sscommand.Parameters.AddWithValue("@montoAplicado", txtPagar.Text);
                                sscommand.Parameters.AddWithValue("@atraso", txtAtraso.Text);
                                sscommand.Parameters.AddWithValue("@adelanto", txtAdelant.Text);
                                sscommand.Parameters.AddWithValue("@MontoCobrar", montorr);
                                sscommand.Parameters.AddWithValue("@Cant", "Seis Meses En Adelanto");
                                sscommand.ExecuteNonQuery();

                                conne.Close();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                            //_____________________________________________________
                            //Para Ocultar Los Controles
                            #region
                            txtMonto.Enabled = false;
                            txtIngreso.Enabled = false;
                            txtPagar.Enabled = false;
                            txtNombre.Enabled = false;
                            txtfechaPago.Enabled = false;
                            btnLimpiarCampos.Enabled = false;
                            btnCobrar.Enabled = false;
                            btnRetornarPago.Enabled = false;
                            txtAdelant.Enabled = false;
                            txtAtraso.Enabled = false;
                            lblVerificarSiSeActivo.Text = "no";
                            cboAdelanto.Enabled = false;
                            txtCoutaMensual.Enabled = false;
                            txtCoutaMensual.Text = "0";
                            txtMonto.Text = "0.0";
                            DgvCobro.DataSource = "";
                            txtNombre.Text = "";
                            txtIngreso.Text = "";
                            txtfechaPago.Text = "";
                            txtPagar.Text = "";
                            cboAdelanto.Text = "";
                            txtAdelant.Text = "0";
                            txtMonto.Text = "0";
                            #endregion
                        }
                        else
                        {
                            MessageBoxButtons m = MessageBoxButtons.OK;
                            MessageBox.Show("han surgido errores, verifica...", "Error:", m, MessageBoxIcon.Stop);
                        }
                    }
                    else
                    {
                        return;
                    }
                    return;
                }
                if (_aplicado < pagar)
                {
                    int pago = pagar - _aplicado;
                    fechapago = fechapago.AddMonths(5);
                    //Conexionnn .............
                    SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString);
                    cn.Open();

                    SqlCommand sc = new SqlCommand("PagoMensualidad", cn);
                    sc.CommandType = CommandType.StoredProcedure;
                    sc.Parameters.AddWithValue("@id", id);
                    sc.Parameters.AddWithValue("@monto", pago);
                    sc.Parameters.AddWithValue("@fechaProx", fechapago.ToString("dd/MM/yyyy"));
                    sc.Parameters.AddWithValue("@atraso", "0");
                    sc.Parameters.AddWithValue("@adelanto", _aplicado.ToString());
                    int r;
                    MessageBoxButtons Mess = MessageBoxButtons.YesNo;
                    DialogResult resultado = MessageBox.Show("¿Estas seguro de querer realizar el Adelanto?", "Confirmación:", Mess, MessageBoxIcon.Question);
                    if (resultado == DialogResult.Yes)
                    {
                        r = sc.ExecuteNonQuery();
                        if (r == 1)
                        {
                            MessageBox.Show("Adelanto realizado correctamente!!", "Aviso:", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //_____________________________________________________
                            ////____________GUARDANDO EN PAGO EN UNA TABLA_________________________
                            try
                            {
                                //Insertar Tabla Pagos
                                SqlConnection conne = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString);
                                conne.Open();
                                string iddd = txtID.Text;
                                DataTable dtttt = SqlClase.ObtenerDatos("ObtenerDatosParaPagar", "@id", id);
                                string montorr = dtttt.Rows[0][6].ToString();
                                SqlCommand sscommand = new SqlCommand("RegistrarPagos", conne);
                                sscommand.CommandType = CommandType.StoredProcedure;
                                sscommand.Parameters.AddWithValue("@id", txtID.Text);
                                sscommand.Parameters.AddWithValue("@nombre", txtNombre.Text);
                                sscommand.Parameters.AddWithValue("@f_pago", txtfechaPago.Text);
                                sscommand.Parameters.AddWithValue("@inscripcion", txtIngreso.Text);
                                sscommand.Parameters.AddWithValue("@tipo", tipo);
                                sscommand.Parameters.AddWithValue("@montoAplicado", txtPagar.Text);
                                sscommand.Parameters.AddWithValue("@atraso", txtAtraso.Text);
                                sscommand.Parameters.AddWithValue("@adelanto", txtAdelant.Text);
                                sscommand.Parameters.AddWithValue("@MontoCobrar", montorr);
                                sscommand.Parameters.AddWithValue("@Cant", "Abono A Seis Meses En Adelanto");
                                sscommand.ExecuteNonQuery();

                                conne.Close();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                            //_____________________________________________________
                            //Para Ocultar Los Controles
                            #region
                            txtMonto.Enabled = false;
                            txtIngreso.Enabled = false;
                            txtPagar.Enabled = false;
                            txtNombre.Enabled = false;
                            txtfechaPago.Enabled = false;
                            btnLimpiarCampos.Enabled = false;
                            btnCobrar.Enabled = false;
                            btnRetornarPago.Enabled = false;
                            txtAdelant.Enabled = false;
                            txtAtraso.Enabled = false;
                            lblVerificarSiSeActivo.Text = "no";
                            cboAdelanto.Enabled = false;
                            txtCoutaMensual.Enabled = false;
                            txtCoutaMensual.Text = "0";
                            txtMonto.Text = "0.0";
                            DgvCobro.DataSource = "";
                            txtNombre.Text = "";
                            txtIngreso.Text = "";
                            txtfechaPago.Text = "";
                            txtPagar.Text = "";
                            cboAdelanto.Text = "";
                            txtAdelant.Text = "0";
                            txtMonto.Text = "0";
                            #endregion
                        }
                        else
                        {
                            MessageBoxButtons m = MessageBoxButtons.OK;
                            MessageBox.Show("han surgido errores, verifica...", "Error:", m, MessageBoxIcon.Stop);
                        }
                    }
                    else
                    {
                        return;
                    }
                    return;
                }

            }
            if (cboAdelanto.Text == "7 Meses")
            {



                string Aplicado = txtPagar.Text;
                int _aplicado = int.Parse(Aplicado);


                string a_pagar = txtMonto.Text;
                int pagar = int.Parse(a_pagar);

                int mreal = int.Parse(montoDeCuotaMensual);
                mreal = mreal * 6;
                int paraValidar = pagar - mreal;

                if (_aplicado < paraValidar)
                {
                    MessageBox.Show("El Monto Aplicado No Corresponde Al Minimo A Pagar En Los Meses Seleccionados", "Error:");
                    return;
                }
                if (_aplicado > pagar)
                {
                    MessageBox.Show("El Monto Aplicado No Corresponde Al Maximo A Pagar En Los Meses Seleccionados", "Error:");
                    return;
                }

                if (_aplicado == pagar)
                {
                    fechapago = fechapago.AddMonths(7);
                    //Conexionnn .............
                    SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString);
                    cn.Open();

                    SqlCommand sc = new SqlCommand("PagoMensualidad", cn);
                    sc.CommandType = CommandType.StoredProcedure;
                    sc.Parameters.AddWithValue("@id", id);
                    sc.Parameters.AddWithValue("@monto", montoDeCuotaMensual);
                    sc.Parameters.AddWithValue("@fechaProx", fechapago.ToString("dd/MM/yyyy"));
                    sc.Parameters.AddWithValue("@atraso", "0");
                    sc.Parameters.AddWithValue("@adelanto", "0");
                    int r;
                    MessageBoxButtons Mess = MessageBoxButtons.YesNo;
                    DialogResult resultado = MessageBox.Show("¿Estas seguro de querer realizar el Adelanto?", "Confirmación:", Mess, MessageBoxIcon.Question);
                    if (resultado == DialogResult.Yes)
                    {
                        r = sc.ExecuteNonQuery();
                        if (r == 1)
                        {
                            MessageBox.Show("Adelanto realizado correctamente!!", "Aviso:", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ////____________GUARDANDO EN PAGO EN UNA TABLA_________________________
                            try
                            {
                                //Insertar Tabla Pagos
                                SqlConnection conne = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString);
                                conne.Open();
                                string iddd = txtID.Text;
                                DataTable dtttt = SqlClase.ObtenerDatos("ObtenerDatosParaPagar", "@id", id);
                                string montorr = dtttt.Rows[0][6].ToString();
                                SqlCommand sscommand = new SqlCommand("RegistrarPagos", conne);
                                sscommand.CommandType = CommandType.StoredProcedure;
                                sscommand.Parameters.AddWithValue("@id", txtID.Text);
                                sscommand.Parameters.AddWithValue("@nombre", txtNombre.Text);
                                sscommand.Parameters.AddWithValue("@f_pago", txtfechaPago.Text);
                                sscommand.Parameters.AddWithValue("@inscripcion", txtIngreso.Text);
                                sscommand.Parameters.AddWithValue("@tipo", tipo);
                                sscommand.Parameters.AddWithValue("@montoAplicado", txtPagar.Text);
                                sscommand.Parameters.AddWithValue("@atraso", txtAtraso.Text);
                                sscommand.Parameters.AddWithValue("@adelanto", txtAdelant.Text);
                                sscommand.Parameters.AddWithValue("@MontoCobrar", montorr);
                                sscommand.Parameters.AddWithValue("@Cant", "Siete Meses En Adelanto");
                                sscommand.ExecuteNonQuery();

                                conne.Close();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                            //_____________________________________________________
                            //Para Ocultar Los Controles
                            #region
                            txtMonto.Enabled = false;
                            txtIngreso.Enabled = false;
                            txtPagar.Enabled = false;
                            txtNombre.Enabled = false;
                            txtfechaPago.Enabled = false;
                            btnLimpiarCampos.Enabled = false;
                            btnCobrar.Enabled = false;
                            btnRetornarPago.Enabled = false;
                            txtAdelant.Enabled = false;
                            txtAtraso.Enabled = false;
                            lblVerificarSiSeActivo.Text = "no";
                            cboAdelanto.Enabled = false;
                            txtCoutaMensual.Enabled = false;
                            txtCoutaMensual.Text = "0";
                            txtMonto.Text = "0.0";
                            DgvCobro.DataSource = "";
                            txtNombre.Text = "";
                            txtIngreso.Text = "";
                            txtfechaPago.Text = "";
                            txtPagar.Text = "";
                            cboAdelanto.Text = "";
                            txtAdelant.Text = "0";
                            txtMonto.Text = "0";
                            #endregion
                        }
                        else
                        {
                            MessageBoxButtons m = MessageBoxButtons.OK;
                            MessageBox.Show("han surgido errores, verifica...", "Error:", m, MessageBoxIcon.Stop);
                        }
                    }
                    else
                    {
                        return;
                    }
                    return;
                }
                if (_aplicado < pagar)
                {
                    int pago = pagar - _aplicado;
                    fechapago = fechapago.AddMonths(6);
                    //Conexionnn .............
                    SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString);
                    cn.Open();

                    SqlCommand sc = new SqlCommand("PagoMensualidad", cn);
                    sc.CommandType = CommandType.StoredProcedure;
                    sc.Parameters.AddWithValue("@id", id);
                    sc.Parameters.AddWithValue("@monto", pago);
                    sc.Parameters.AddWithValue("@fechaProx", fechapago.ToString("dd/MM/yyyy"));
                    sc.Parameters.AddWithValue("@atraso", "0");
                    sc.Parameters.AddWithValue("@adelanto", _aplicado.ToString());
                    int r;
                    MessageBoxButtons Mess = MessageBoxButtons.YesNo;
                    DialogResult resultado = MessageBox.Show("¿Estas seguro de querer realizar el Adelanto?", "Confirmación:", Mess, MessageBoxIcon.Question);
                    if (resultado == DialogResult.Yes)
                    {
                        r = sc.ExecuteNonQuery();
                        if (r == 1)
                        {
                            MessageBox.Show("Adelanto realizado correctamente!!", "Aviso:", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ////____________GUARDANDO EN PAGO EN UNA TABLA_________________________
                            try
                            {
                                //Insertar Tabla Pagos
                                SqlConnection conne = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString);
                                conne.Open();
                                string iddd = txtID.Text;
                                DataTable dtttt = SqlClase.ObtenerDatos("ObtenerDatosParaPagar", "@id", id);
                                string montorr = dtttt.Rows[0][6].ToString();
                                SqlCommand sscommand = new SqlCommand("RegistrarPagos", conne);
                                sscommand.CommandType = CommandType.StoredProcedure;
                                sscommand.Parameters.AddWithValue("@id", txtID.Text);
                                sscommand.Parameters.AddWithValue("@nombre", txtNombre.Text);
                                sscommand.Parameters.AddWithValue("@f_pago", txtfechaPago.Text);
                                sscommand.Parameters.AddWithValue("@inscripcion", txtIngreso.Text);
                                sscommand.Parameters.AddWithValue("@tipo", tipo);
                                sscommand.Parameters.AddWithValue("@montoAplicado", txtPagar.Text);
                                sscommand.Parameters.AddWithValue("@atraso", txtAtraso.Text);
                                sscommand.Parameters.AddWithValue("@adelanto", txtAdelant.Text);
                                sscommand.Parameters.AddWithValue("@MontoCobrar", montorr);
                                sscommand.Parameters.AddWithValue("@Cant", "Abono A Siete Meses En Adelanto");
                                sscommand.ExecuteNonQuery();

                                conne.Close();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                            //_____________________________________________________
                            //Para Ocultar Los Controles
                            #region
                            txtMonto.Enabled = false;
                            txtIngreso.Enabled = false;
                            txtPagar.Enabled = false;
                            txtNombre.Enabled = false;
                            txtfechaPago.Enabled = false;
                            btnLimpiarCampos.Enabled = false;
                            btnCobrar.Enabled = false;
                            btnRetornarPago.Enabled = false;
                            txtAdelant.Enabled = false;
                            txtAtraso.Enabled = false;
                            lblVerificarSiSeActivo.Text = "no";
                            cboAdelanto.Enabled = false;
                            txtCoutaMensual.Enabled = false;
                            txtCoutaMensual.Text = "0";
                            txtMonto.Text = "0.0";
                            DgvCobro.DataSource = "";
                            txtNombre.Text = "";
                            txtIngreso.Text = "";
                            txtfechaPago.Text = "";
                            txtPagar.Text = "";
                            cboAdelanto.Text = "";
                            txtAdelant.Text = "0";
                            txtMonto.Text = "0";
                            #endregion
                        }
                        else
                        {
                            MessageBoxButtons m = MessageBoxButtons.OK;
                            MessageBox.Show("han surgido errores, verifica...", "Error:", m, MessageBoxIcon.Stop);
                        }
                    }
                    else
                    {
                        return;
                    }
                    return;
                }


            }
            if (cboAdelanto.Text == "8 Meses")
            {


                string Aplicado = txtPagar.Text;
                int _aplicado = int.Parse(Aplicado);


                string a_pagar = txtMonto.Text;
                int pagar = int.Parse(a_pagar);

                int mreal = int.Parse(montoDeCuotaMensual);
                mreal = mreal * 7;
                int paraValidar = pagar - mreal;

                if (_aplicado < paraValidar)
                {
                    MessageBox.Show("El Monto Aplicado No Corresponde Al Minimo A Pagar En Los Meses Seleccionados", "Error:");
                    return;
                }
                if (_aplicado > pagar)
                {
                    MessageBox.Show("El Monto Aplicado No Corresponde Al Maximo A Pagar En Los Meses Seleccionados", "Error:");
                    return;
                }

                if (_aplicado == pagar)
                {
                    fechapago = fechapago.AddMonths(8);
                    //Conexionnn .............
                    SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString);
                    cn.Open();

                    SqlCommand sc = new SqlCommand("PagoMensualidad", cn);
                    sc.CommandType = CommandType.StoredProcedure;
                    sc.Parameters.AddWithValue("@id", id);
                    sc.Parameters.AddWithValue("@monto", montoDeCuotaMensual);
                    sc.Parameters.AddWithValue("@fechaProx", fechapago.ToString("dd/MM/yyyy"));
                    sc.Parameters.AddWithValue("@atraso", "0");
                    sc.Parameters.AddWithValue("@adelanto", "0");
                    int r;
                    MessageBoxButtons Mess = MessageBoxButtons.YesNo;
                    DialogResult resultado = MessageBox.Show("¿Estas seguro de querer realizar el Adelanto?", "Confirmación:", Mess, MessageBoxIcon.Question);
                    if (resultado == DialogResult.Yes)
                    {
                        r = sc.ExecuteNonQuery();
                        if (r == 1)
                        {
                            MessageBox.Show("Adelanto realizado correctamente!!", "Aviso:", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ////____________GUARDANDO EN PAGO EN UNA TABLA_________________________
                            try
                            {
                                //Insertar Tabla Pagos
                                SqlConnection conne = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString);
                                conne.Open();
                                string iddd = txtID.Text;
                                DataTable dtttt = SqlClase.ObtenerDatos("ObtenerDatosParaPagar", "@id", id);
                                string montorr = dtttt.Rows[0][6].ToString();
                                SqlCommand sscommand = new SqlCommand("RegistrarPagos", conne);
                                sscommand.CommandType = CommandType.StoredProcedure;
                                sscommand.Parameters.AddWithValue("@id", txtID.Text);
                                sscommand.Parameters.AddWithValue("@nombre", txtNombre.Text);
                                sscommand.Parameters.AddWithValue("@f_pago", txtfechaPago.Text);
                                sscommand.Parameters.AddWithValue("@inscripcion", txtIngreso.Text);
                                sscommand.Parameters.AddWithValue("@tipo", tipo);
                                sscommand.Parameters.AddWithValue("@montoAplicado", txtPagar.Text);
                                sscommand.Parameters.AddWithValue("@atraso", txtAtraso.Text);
                                sscommand.Parameters.AddWithValue("@adelanto", txtAdelant.Text);
                                sscommand.Parameters.AddWithValue("@MontoCobrar", montorr);
                                sscommand.Parameters.AddWithValue("@Cant", "Ocho Meses En Adelanto");
                                sscommand.ExecuteNonQuery();

                                conne.Close();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                            //_____________________________________________________
                            //Para Ocultar Los Controles
                            #region
                            txtMonto.Enabled = false;
                            txtIngreso.Enabled = false;
                            txtPagar.Enabled = false;
                            txtNombre.Enabled = false;
                            txtfechaPago.Enabled = false;
                            btnLimpiarCampos.Enabled = false;
                            btnCobrar.Enabled = false;
                            btnRetornarPago.Enabled = false;
                            txtAdelant.Enabled = false;
                            txtAtraso.Enabled = false;
                            lblVerificarSiSeActivo.Text = "no";
                            cboAdelanto.Enabled = false;
                            txtCoutaMensual.Enabled = false;
                            txtCoutaMensual.Text = "0";
                            txtMonto.Text = "0.0";
                            DgvCobro.DataSource = "";
                            txtNombre.Text = "";
                            txtIngreso.Text = "";
                            txtfechaPago.Text = "";
                            txtPagar.Text = "";
                            cboAdelanto.Text = "";
                            txtAdelant.Text = "0";
                            txtMonto.Text = "0";
                            #endregion
                        }
                        else
                        {
                            MessageBoxButtons m = MessageBoxButtons.OK;
                            MessageBox.Show("han surgido errores, verifica...", "Error:", m, MessageBoxIcon.Stop);
                        }
                    }
                    else
                    {
                        return;
                    }
                    return;
                }
                if (_aplicado < pagar)
                {
                    int pago = pagar - _aplicado;
                    fechapago = fechapago.AddMonths(7);
                    //Conexionnn .............
                    SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString);
                    cn.Open();

                    SqlCommand sc = new SqlCommand("PagoMensualidad", cn);
                    sc.CommandType = CommandType.StoredProcedure;
                    sc.Parameters.AddWithValue("@id", id);
                    sc.Parameters.AddWithValue("@monto", pago);
                    sc.Parameters.AddWithValue("@fechaProx", fechapago.ToString("dd/MM/yyyy"));
                    sc.Parameters.AddWithValue("@atraso", "0");
                    sc.Parameters.AddWithValue("@adelanto", _aplicado.ToString());
                    int r;
                    MessageBoxButtons Mess = MessageBoxButtons.YesNo;
                    DialogResult resultado = MessageBox.Show("¿Estas seguro de querer realizar el Adelanto?", "Confirmación:", Mess, MessageBoxIcon.Question);
                    if (resultado == DialogResult.Yes)
                    {
                        r = sc.ExecuteNonQuery();
                        if (r == 1)
                        {
                            MessageBox.Show("Adelanto realizado correctamente!!", "Aviso:", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ////____________GUARDANDO EN PAGO EN UNA TABLA_________________________
                            try
                            {
                                //Insertar Tabla Pagos
                                SqlConnection conne = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString);
                                conne.Open();
                                string iddd = txtID.Text;
                                DataTable dtttt = SqlClase.ObtenerDatos("ObtenerDatosParaPagar", "@id", id);
                                string montorr = dtttt.Rows[0][6].ToString();
                                SqlCommand sscommand = new SqlCommand("RegistrarPagos", conne);
                                sscommand.CommandType = CommandType.StoredProcedure;
                                sscommand.Parameters.AddWithValue("@id", txtID.Text);
                                sscommand.Parameters.AddWithValue("@nombre", txtNombre.Text);
                                sscommand.Parameters.AddWithValue("@f_pago", txtfechaPago.Text);
                                sscommand.Parameters.AddWithValue("@inscripcion", txtIngreso.Text);
                                sscommand.Parameters.AddWithValue("@tipo", tipo);
                                sscommand.Parameters.AddWithValue("@montoAplicado", txtPagar.Text);
                                sscommand.Parameters.AddWithValue("@atraso", txtAtraso.Text);
                                sscommand.Parameters.AddWithValue("@adelanto", txtAdelant.Text);
                                sscommand.Parameters.AddWithValue("@MontoCobrar", montorr);
                                sscommand.Parameters.AddWithValue("@Cant", "Abono A Ocho Meses En Adelanto");
                                sscommand.ExecuteNonQuery();

                                conne.Close();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                            //_____________________________________________________
                            //Para Ocultar Los Controles
                            #region
                            txtMonto.Enabled = false;
                            txtIngreso.Enabled = false;
                            txtPagar.Enabled = false;
                            txtNombre.Enabled = false;
                            txtfechaPago.Enabled = false;
                            btnLimpiarCampos.Enabled = false;
                            btnCobrar.Enabled = false;
                            btnRetornarPago.Enabled = false;
                            txtAdelant.Enabled = false;
                            txtAtraso.Enabled = false;
                            lblVerificarSiSeActivo.Text = "no";
                            cboAdelanto.Enabled = false;
                            txtCoutaMensual.Enabled = false;
                            txtCoutaMensual.Text = "0";
                            txtMonto.Text = "0.0";
                            DgvCobro.DataSource = "";
                            txtNombre.Text = "";
                            txtIngreso.Text = "";
                            txtfechaPago.Text = "";
                            txtPagar.Text = "";
                            cboAdelanto.Text = "";
                            txtAdelant.Text = "0";
                            txtMonto.Text = "0";
                            #endregion
                        }
                        else
                        {
                            MessageBoxButtons m = MessageBoxButtons.OK;
                            MessageBox.Show("han surgido errores, verifica...", "Error:", m, MessageBoxIcon.Stop);
                        }
                    }
                    else
                    {
                        return;
                    }
                    return;
                }

            }
            if (cboAdelanto.Text == "9 Meses")
            {

                string Aplicado = txtPagar.Text;
                int _aplicado = int.Parse(Aplicado);


                string a_pagar = txtMonto.Text;
                int pagar = int.Parse(a_pagar);

                int mreal = int.Parse(montoDeCuotaMensual);
                mreal = mreal * 8;
                int paraValidar = pagar - mreal;

                if (_aplicado < paraValidar)
                {
                    MessageBox.Show("El Monto Aplicado No Corresponde Al Minimo A Pagar En Los Meses Seleccionados", "Error:");
                    return;
                }
                if (_aplicado > pagar)
                {
                    MessageBox.Show("El Monto Aplicado No Corresponde Al Maximo A Pagar En Los Meses Seleccionados", "Error:");
                    return;
                }

                if (_aplicado == pagar)
                {
                    fechapago = fechapago.AddMonths(9);
                    //Conexionnn .............
                    SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString);
                    cn.Open();

                    SqlCommand sc = new SqlCommand("PagoMensualidad", cn);
                    sc.CommandType = CommandType.StoredProcedure;
                    sc.Parameters.AddWithValue("@id", id);
                    sc.Parameters.AddWithValue("@monto", montoDeCuotaMensual);
                    sc.Parameters.AddWithValue("@fechaProx", fechapago.ToString("dd/MM/yyyy"));
                    sc.Parameters.AddWithValue("@atraso", "0");
                    sc.Parameters.AddWithValue("@adelanto", "0");
                    int r;
                    MessageBoxButtons Mess = MessageBoxButtons.YesNo;
                    DialogResult resultado = MessageBox.Show("¿Estas seguro de querer realizar el Adelanto?", "Confirmación:", Mess, MessageBoxIcon.Question);
                    if (resultado == DialogResult.Yes)
                    {
                        r = sc.ExecuteNonQuery();
                        if (r == 1)
                        {
                            MessageBox.Show("Adelanto realizado correctamente!!", "Aviso:", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ////____________GUARDANDO EN PAGO EN UNA TABLA_________________________
                            try
                            {
                                //Insertar Tabla Pagos
                                SqlConnection conne = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString);
                                conne.Open();
                                string iddd = txtID.Text;
                                DataTable dtttt = SqlClase.ObtenerDatos("ObtenerDatosParaPagar", "@id", id);
                                string montorr = dtttt.Rows[0][6].ToString();
                                SqlCommand sscommand = new SqlCommand("RegistrarPagos", conne);
                                sscommand.CommandType = CommandType.StoredProcedure;
                                sscommand.Parameters.AddWithValue("@id", txtID.Text);
                                sscommand.Parameters.AddWithValue("@nombre", txtNombre.Text);
                                sscommand.Parameters.AddWithValue("@f_pago", txtfechaPago.Text);
                                sscommand.Parameters.AddWithValue("@inscripcion", txtIngreso.Text);
                                sscommand.Parameters.AddWithValue("@tipo", tipo);
                                sscommand.Parameters.AddWithValue("@montoAplicado", txtPagar.Text);
                                sscommand.Parameters.AddWithValue("@atraso", txtAtraso.Text);
                                sscommand.Parameters.AddWithValue("@adelanto", txtAdelant.Text);
                                sscommand.Parameters.AddWithValue("@MontoCobrar", montorr);
                                sscommand.Parameters.AddWithValue("@Cant", "Nueve Meses En Adelanto");
                                sscommand.ExecuteNonQuery();

                                conne.Close();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                            //_____________________________________________________
                            //Para Ocultar Los Controles
                            #region
                            txtMonto.Enabled = false;
                            txtIngreso.Enabled = false;
                            txtPagar.Enabled = false;
                            txtNombre.Enabled = false;
                            txtfechaPago.Enabled = false;
                            btnLimpiarCampos.Enabled = false;
                            btnCobrar.Enabled = false;
                            btnRetornarPago.Enabled = false;
                            txtAdelant.Enabled = false;
                            txtAtraso.Enabled = false;
                            lblVerificarSiSeActivo.Text = "no";
                            cboAdelanto.Enabled = false;
                            txtCoutaMensual.Enabled = false;
                            txtCoutaMensual.Text = "0";
                            txtMonto.Text = "0.0";
                            DgvCobro.DataSource = "";
                            txtNombre.Text = "";
                            txtIngreso.Text = "";
                            txtfechaPago.Text = "";
                            txtPagar.Text = "";
                            cboAdelanto.Text = "";
                            txtAdelant.Text = "0";
                            txtMonto.Text = "0";
                            #endregion
                        }
                        else
                        {
                            MessageBoxButtons m = MessageBoxButtons.OK;
                            MessageBox.Show("han surgido errores, verifica...", "Error:", m, MessageBoxIcon.Stop);
                        }
                    }
                    else
                    {
                        return;
                    }
                    return;
                }
                if (_aplicado < pagar)
                {
                    int pago = pagar - _aplicado;
                    fechapago = fechapago.AddMonths(8);
                    //Conexionnn .............
                    SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString);
                    cn.Open();

                    SqlCommand sc = new SqlCommand("PagoMensualidad", cn);
                    sc.CommandType = CommandType.StoredProcedure;
                    sc.Parameters.AddWithValue("@id", id);
                    sc.Parameters.AddWithValue("@monto", pago);
                    sc.Parameters.AddWithValue("@fechaProx", fechapago.ToString("dd/MM/yyyy"));
                    sc.Parameters.AddWithValue("@atraso", "0");
                    sc.Parameters.AddWithValue("@adelanto", _aplicado.ToString());
                    int r;
                    MessageBoxButtons Mess = MessageBoxButtons.YesNo;
                    DialogResult resultado = MessageBox.Show("¿Estas seguro de querer realizar el Adelanto?", "Confirmación:", Mess, MessageBoxIcon.Question);
                    if (resultado == DialogResult.Yes)
                    {
                        r = sc.ExecuteNonQuery();
                        if (r == 1)
                        {
                            MessageBox.Show("Adelanto realizado correctamente!!", "Aviso:", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ////____________GUARDANDO EN PAGO EN UNA TABLA_________________________
                            try
                            {
                                //Insertar Tabla Pagos
                                SqlConnection conne = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString);
                                conne.Open();
                                string iddd = txtID.Text;
                                DataTable dtttt = SqlClase.ObtenerDatos("ObtenerDatosParaPagar", "@id", id);
                                string montorr = dtttt.Rows[0][6].ToString();
                                SqlCommand sscommand = new SqlCommand("RegistrarPagos", conne);
                                sscommand.CommandType = CommandType.StoredProcedure;
                                sscommand.Parameters.AddWithValue("@id", txtID.Text);
                                sscommand.Parameters.AddWithValue("@nombre", txtNombre.Text);
                                sscommand.Parameters.AddWithValue("@f_pago", txtfechaPago.Text);
                                sscommand.Parameters.AddWithValue("@inscripcion", txtIngreso.Text);
                                sscommand.Parameters.AddWithValue("@tipo", tipo);
                                sscommand.Parameters.AddWithValue("@montoAplicado", txtPagar.Text);
                                sscommand.Parameters.AddWithValue("@atraso", txtAtraso.Text);
                                sscommand.Parameters.AddWithValue("@adelanto", txtAdelant.Text);
                                sscommand.Parameters.AddWithValue("@MontoCobrar", montorr);
                                sscommand.Parameters.AddWithValue("@Cant", "Abono A Nueve Meses En Adelanto");
                                sscommand.ExecuteNonQuery();

                                conne.Close();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                            //_____________________________________________________
                            //Para Ocultar Los Controles
                            #region
                            txtMonto.Enabled = false;
                            txtIngreso.Enabled = false;
                            txtPagar.Enabled = false;
                            txtNombre.Enabled = false;
                            txtfechaPago.Enabled = false;
                            btnLimpiarCampos.Enabled = false;
                            btnCobrar.Enabled = false;
                            btnRetornarPago.Enabled = false;
                            txtAdelant.Enabled = false;
                            txtAtraso.Enabled = false;
                            lblVerificarSiSeActivo.Text = "no";
                            cboAdelanto.Enabled = false;
                            txtCoutaMensual.Enabled = false;
                            txtCoutaMensual.Text = "0";
                            txtMonto.Text = "0.0";
                            DgvCobro.DataSource = "";
                            txtNombre.Text = "";
                            txtIngreso.Text = "";
                            txtfechaPago.Text = "";
                            txtPagar.Text = "";
                            cboAdelanto.Text = "";
                            txtAdelant.Text = "0";
                            txtMonto.Text = "0";
                            #endregion
                        }
                        else
                        {
                            MessageBoxButtons m = MessageBoxButtons.OK;
                            MessageBox.Show("han surgido errores, verifica...", "Error:", m, MessageBoxIcon.Stop);
                        }
                    }
                    else
                    {
                        return;
                    }
                    return;
                }

            }
            if (cboAdelanto.Text == "10 Meses")
            {


                string Aplicado = txtPagar.Text;
                int _aplicado = int.Parse(Aplicado);


                string a_pagar = txtMonto.Text;
                int pagar = int.Parse(a_pagar);

                int mreal = int.Parse(montoDeCuotaMensual);
                mreal = mreal * 9;
                int paraValidar = pagar - mreal;

                if (_aplicado < paraValidar)
                {
                    MessageBox.Show("El Monto Aplicado No Corresponde Al Minimo A Pagar En Los Meses Seleccionados", "Error:");
                    return;
                }
                if (_aplicado > pagar)
                {
                    MessageBox.Show("El Monto Aplicado No Corresponde Al Maximo A Pagar En Los Meses Seleccionados", "Error:");
                    return;
                }

                if (_aplicado == pagar)
                {
                    fechapago = fechapago.AddMonths(10);
                    //Conexionnn .............
                    SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString);
                    cn.Open();

                    SqlCommand sc = new SqlCommand("PagoMensualidad", cn);
                    sc.CommandType = CommandType.StoredProcedure;
                    sc.Parameters.AddWithValue("@id", id);
                    sc.Parameters.AddWithValue("@monto", montoDeCuotaMensual);
                    sc.Parameters.AddWithValue("@fechaProx", fechapago.ToString("dd/MM/yyyy"));
                    sc.Parameters.AddWithValue("@atraso", "0");
                    sc.Parameters.AddWithValue("@adelanto", "0");
                    int r;
                    MessageBoxButtons Mess = MessageBoxButtons.YesNo;
                    DialogResult resultado = MessageBox.Show("¿Estas seguro de querer realizar el Adelanto?", "Confirmación:", Mess, MessageBoxIcon.Question);
                    if (resultado == DialogResult.Yes)
                    {
                        r = sc.ExecuteNonQuery();
                        if (r == 1)
                        {
                            MessageBox.Show("Adelanto realizado correctamente!!", "Aviso:", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ////____________GUARDANDO EN PAGO EN UNA TABLA_________________________
                            try
                            {
                                //Insertar Tabla Pagos
                                SqlConnection conne = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString);
                                conne.Open();
                                string iddd = txtID.Text;
                                DataTable dtttt = SqlClase.ObtenerDatos("ObtenerDatosParaPagar", "@id", id);
                                string montorr = dtttt.Rows[0][6].ToString();
                                SqlCommand sscommand = new SqlCommand("RegistrarPagos", conne);
                                sscommand.CommandType = CommandType.StoredProcedure;
                                sscommand.Parameters.AddWithValue("@id", txtID.Text);
                                sscommand.Parameters.AddWithValue("@nombre", txtNombre.Text);
                                sscommand.Parameters.AddWithValue("@f_pago", txtfechaPago.Text);
                                sscommand.Parameters.AddWithValue("@inscripcion", txtIngreso.Text);
                                sscommand.Parameters.AddWithValue("@tipo", tipo);
                                sscommand.Parameters.AddWithValue("@montoAplicado", txtPagar.Text);
                                sscommand.Parameters.AddWithValue("@atraso", txtAtraso.Text);
                                sscommand.Parameters.AddWithValue("@adelanto", txtAdelant.Text);
                                sscommand.Parameters.AddWithValue("@MontoCobrar", montorr);
                                sscommand.Parameters.AddWithValue("@Cant", "**Diez Meses En Adelanto**");
                                sscommand.ExecuteNonQuery();

                                conne.Close();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                            //_____________________________________________________
                            //Para Ocultar Los Controles
                            #region
                            txtMonto.Enabled = false;
                            txtIngreso.Enabled = false;
                            txtPagar.Enabled = false;
                            txtNombre.Enabled = false;
                            txtfechaPago.Enabled = false;
                            btnLimpiarCampos.Enabled = false;
                            btnCobrar.Enabled = false;
                            btnRetornarPago.Enabled = false;
                            txtAdelant.Enabled = false;
                            txtAtraso.Enabled = false;
                            lblVerificarSiSeActivo.Text = "no";
                            cboAdelanto.Enabled = false;
                            txtCoutaMensual.Enabled = false;
                            txtCoutaMensual.Text = "0";
                            txtMonto.Text = "0.0";
                            DgvCobro.DataSource = "";
                            txtNombre.Text = "";
                            txtIngreso.Text = "";
                            txtfechaPago.Text = "";
                            txtPagar.Text = "";
                            cboAdelanto.Text = "";
                            txtAdelant.Text = "0";
                            txtMonto.Text = "0";
                            #endregion
                        }
                        else
                        {
                            MessageBoxButtons m = MessageBoxButtons.OK;
                            MessageBox.Show("han surgido errores, verifica...", "Error:", m, MessageBoxIcon.Stop);
                        }
                    }
                    else
                    {
                        return;
                    }
                    return;
                }
                if (_aplicado < pagar)
                {
                    int pago = pagar - _aplicado;
                    fechapago = fechapago.AddMonths(9);
                    //Conexionnn .............
                    SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString);
                    cn.Open();

                    SqlCommand sc = new SqlCommand("PagoMensualidad", cn);
                    sc.CommandType = CommandType.StoredProcedure;
                    sc.Parameters.AddWithValue("@id", id);
                    sc.Parameters.AddWithValue("@monto", pago);
                    sc.Parameters.AddWithValue("@fechaProx", fechapago.ToString("dd/MM/yyyy"));
                    sc.Parameters.AddWithValue("@atraso", "0");
                    sc.Parameters.AddWithValue("@adelanto", _aplicado.ToString());
                    int r;
                    MessageBoxButtons Mess = MessageBoxButtons.YesNo;
                    DialogResult resultado = MessageBox.Show("¿Estas seguro de querer realizar el Adelanto?", "Confirmación:", Mess, MessageBoxIcon.Question);
                    if (resultado == DialogResult.Yes)
                    {
                        r = sc.ExecuteNonQuery();
                        if (r == 1)
                        {
                            MessageBox.Show("Adelanto realizado correctamente!!", "Aviso:", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ////____________GUARDANDO EN PAGO EN UNA TABLA_________________________
                            try
                            {
                                //Insertar Tabla Pagos
                                SqlConnection conne = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString);
                                conne.Open();
                                string iddd = txtID.Text;
                                DataTable dtttt = SqlClase.ObtenerDatos("ObtenerDatosParaPagar", "@id", id);
                                string montorr = dtttt.Rows[0][6].ToString();
                                SqlCommand sscommand = new SqlCommand("RegistrarPagos", conne);
                                sscommand.CommandType = CommandType.StoredProcedure;
                                sscommand.Parameters.AddWithValue("@id", txtID.Text);
                                sscommand.Parameters.AddWithValue("@nombre", txtNombre.Text);
                                sscommand.Parameters.AddWithValue("@f_pago", txtfechaPago.Text);
                                sscommand.Parameters.AddWithValue("@inscripcion", txtIngreso.Text);
                                sscommand.Parameters.AddWithValue("@tipo", tipo);
                                sscommand.Parameters.AddWithValue("@montoAplicado", txtPagar.Text);
                                sscommand.Parameters.AddWithValue("@atraso", txtAtraso.Text);
                                sscommand.Parameters.AddWithValue("@adelanto", txtAdelant.Text);
                                sscommand.Parameters.AddWithValue("@MontoCobrar", montorr);
                                sscommand.Parameters.AddWithValue("@Cant", "*Abono A Diez Meses En Adelanto*");
                                sscommand.ExecuteNonQuery();

                                conne.Close();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                            //_____________________________________________________
                            //Para Ocultar Los Controles
                            #region
                            txtMonto.Enabled = false;
                            txtIngreso.Enabled = false;
                            txtPagar.Enabled = false;
                            txtNombre.Enabled = false;
                            txtfechaPago.Enabled = false;
                            btnLimpiarCampos.Enabled = false;
                            btnCobrar.Enabled = false;
                            btnRetornarPago.Enabled = false;
                            txtAdelant.Enabled = false;
                            txtAtraso.Enabled = false;
                            lblVerificarSiSeActivo.Text = "no";
                            cboAdelanto.Enabled = false;
                            txtCoutaMensual.Enabled = false;
                            txtCoutaMensual.Text = "0";
                            txtMonto.Text = "0.0";
                            DgvCobro.DataSource = "";
                            txtNombre.Text = "";
                            txtIngreso.Text = "";
                            txtfechaPago.Text = "";
                            txtPagar.Text = "";
                            cboAdelanto.Text = "";
                            txtAdelant.Text = "0";
                            txtMonto.Text = "0";
                            #endregion
                        }
                        else
                        {
                            MessageBoxButtons m = MessageBoxButtons.OK;
                            MessageBox.Show("han surgido errores, verifica...", "Error:", m, MessageBoxIcon.Stop);
                        }
                    }
                    else
                    {
                        return;
                    }
                    return;
                }

            }
            if (cboAdelanto.Text == "11 Meses")
            {


                string Aplicado = txtPagar.Text;
                int _aplicado = int.Parse(Aplicado);

                string a_pagar = txtMonto.Text;
                int pagar = int.Parse(a_pagar);

                int mreal = int.Parse(montoDeCuotaMensual);
                mreal = mreal * 10;
                int paraValidar = pagar - mreal;

                if (_aplicado < paraValidar)
                {
                    MessageBox.Show("El Monto Aplicado No Corresponde Al Minimo A Pagar En Los Meses Seleccionados", "Error:");
                    return;
                }
                if (_aplicado > pagar)
                {
                    MessageBox.Show("El Monto Aplicado No Corresponde Al Maximo A Pagar En Los Meses Seleccionados", "Error:");
                    return;
                }

                if (_aplicado == pagar)
                {
                    fechapago = fechapago.AddMonths(11);
                    //Conexionnn .............
                    SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString);
                    cn.Open();

                    SqlCommand sc = new SqlCommand("PagoMensualidad", cn);
                    sc.CommandType = CommandType.StoredProcedure;
                    sc.Parameters.AddWithValue("@id", id);
                    sc.Parameters.AddWithValue("@monto", montoDeCuotaMensual);
                    sc.Parameters.AddWithValue("@fechaProx", fechapago.ToString("dd/MM/yyyy"));
                    sc.Parameters.AddWithValue("@atraso", "0");
                    sc.Parameters.AddWithValue("@adelanto", "0");
                    int r;
                    MessageBoxButtons Mess = MessageBoxButtons.YesNo;
                    DialogResult resultado = MessageBox.Show("¿Estas seguro de querer realizar el Adelanto?", "Confirmación:", Mess, MessageBoxIcon.Question);
                    if (resultado == DialogResult.Yes)
                    {
                        r = sc.ExecuteNonQuery();
                        if (r == 1)
                        {
                            MessageBox.Show("Adelanto realizado correctamente!!", "Aviso:", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ////____________GUARDANDO EN PAGO EN UNA TABLA_________________________
                            try
                            {
                                //Insertar Tabla Pagos
                                SqlConnection conne = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString);
                                conne.Open();
                                string iddd = txtID.Text;
                                DataTable dtttt = SqlClase.ObtenerDatos("ObtenerDatosParaPagar", "@id", id);
                                string montorr = dtttt.Rows[0][6].ToString();
                                SqlCommand sscommand = new SqlCommand("RegistrarPagos", conne);
                                sscommand.CommandType = CommandType.StoredProcedure;
                                sscommand.Parameters.AddWithValue("@id", txtID.Text);
                                sscommand.Parameters.AddWithValue("@nombre", txtNombre.Text);
                                sscommand.Parameters.AddWithValue("@f_pago", txtfechaPago.Text);
                                sscommand.Parameters.AddWithValue("@inscripcion", txtIngreso.Text);
                                sscommand.Parameters.AddWithValue("@tipo", tipo);
                                sscommand.Parameters.AddWithValue("@montoAplicado", txtPagar.Text);
                                sscommand.Parameters.AddWithValue("@atraso", txtAtraso.Text);
                                sscommand.Parameters.AddWithValue("@adelanto", txtAdelant.Text);
                                sscommand.Parameters.AddWithValue("@MontoCobrar", montorr);
                                sscommand.Parameters.AddWithValue("@Cant", "**Once Meses En Adelanto**");
                                sscommand.ExecuteNonQuery();

                                conne.Close();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                            //_____________________________________________________
                            //Para Ocultar Los Controles
                            #region
                            txtMonto.Enabled = false;
                            txtIngreso.Enabled = false;
                            txtPagar.Enabled = false;
                            txtNombre.Enabled = false;
                            txtfechaPago.Enabled = false;
                            btnLimpiarCampos.Enabled = false;
                            btnCobrar.Enabled = false;
                            btnRetornarPago.Enabled = false;
                            txtAdelant.Enabled = false;
                            txtAtraso.Enabled = false;
                            lblVerificarSiSeActivo.Text = "no";
                            cboAdelanto.Enabled = false;
                            txtCoutaMensual.Enabled = false;
                            txtCoutaMensual.Text = "0";
                            txtMonto.Text = "0.0";
                            DgvCobro.DataSource = "";
                            txtNombre.Text = "";
                            txtIngreso.Text = "";
                            txtfechaPago.Text = "";
                            txtPagar.Text = "";
                            cboAdelanto.Text = "";
                            txtAdelant.Text = "0";
                            txtMonto.Text = "0";
                            #endregion
                        }
                        else
                        {
                            MessageBoxButtons m = MessageBoxButtons.OK;
                            MessageBox.Show("han surgido errores, verifica...", "Error:", m, MessageBoxIcon.Stop);
                        }
                    }
                    else
                    {
                        return;
                    }
                    return;
                }
                if (_aplicado < pagar)
                {
                    int pago = pagar - _aplicado;
                    fechapago = fechapago.AddMonths(10);
                    //Conexionnn .............
                    SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString);
                    cn.Open();

                    SqlCommand sc = new SqlCommand("PagoMensualidad", cn);
                    sc.CommandType = CommandType.StoredProcedure;
                    sc.Parameters.AddWithValue("@id", id);
                    sc.Parameters.AddWithValue("@monto", pago);
                    sc.Parameters.AddWithValue("@fechaProx", fechapago.ToString("dd/MM/yyyy"));
                    sc.Parameters.AddWithValue("@atraso", "0");
                    sc.Parameters.AddWithValue("@adelanto", _aplicado.ToString());
                    int r;
                    MessageBoxButtons Mess = MessageBoxButtons.YesNo;
                    DialogResult resultado = MessageBox.Show("¿Estas seguro de querer realizar el Adelanto?", "Confirmación:", Mess, MessageBoxIcon.Question);
                    if (resultado == DialogResult.Yes)
                    {
                        r = sc.ExecuteNonQuery();
                        if (r == 1)
                        {
                            MessageBox.Show("Adelanto realizado correctamente!!", "Aviso:", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ////____________GUARDANDO EN PAGO EN UNA TABLA_________________________
                            try
                            {
                                //Insertar Tabla Pagos
                                SqlConnection conne = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString);
                                conne.Open();
                                string iddd = txtID.Text;
                                DataTable dtttt = SqlClase.ObtenerDatos("ObtenerDatosParaPagar", "@id", id);
                                string montorr = dtttt.Rows[0][6].ToString();
                                SqlCommand sscommand = new SqlCommand("RegistrarPagos", conne);
                                sscommand.CommandType = CommandType.StoredProcedure;
                                sscommand.Parameters.AddWithValue("@id", txtID.Text);
                                sscommand.Parameters.AddWithValue("@nombre", txtNombre.Text);
                                sscommand.Parameters.AddWithValue("@f_pago", txtfechaPago.Text);
                                sscommand.Parameters.AddWithValue("@inscripcion", txtIngreso.Text);
                                sscommand.Parameters.AddWithValue("@tipo", tipo);
                                sscommand.Parameters.AddWithValue("@montoAplicado", txtPagar.Text);
                                sscommand.Parameters.AddWithValue("@atraso", txtAtraso.Text);
                                sscommand.Parameters.AddWithValue("@adelanto", txtAdelant.Text);
                                sscommand.Parameters.AddWithValue("@MontoCobrar", montorr);
                                sscommand.Parameters.AddWithValue("@Cant", "*Abono A Once Meses En Adelanto*");
                                sscommand.ExecuteNonQuery();

                                conne.Close();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                            //_____________________________________________________
                            //Para Ocultar Los Controles
                            #region
                            txtMonto.Enabled = false;
                            txtIngreso.Enabled = false;
                            txtPagar.Enabled = false;
                            txtNombre.Enabled = false;
                            txtfechaPago.Enabled = false;
                            btnLimpiarCampos.Enabled = false;
                            btnCobrar.Enabled = false;
                            btnRetornarPago.Enabled = false;
                            txtAdelant.Enabled = false;
                            txtAtraso.Enabled = false;
                            lblVerificarSiSeActivo.Text = "no";
                            cboAdelanto.Enabled = false;
                            txtCoutaMensual.Enabled = false;
                            txtCoutaMensual.Text = "0";
                            txtMonto.Text = "0.0";
                            DgvCobro.DataSource = "";
                            txtNombre.Text = "";
                            txtIngreso.Text = "";
                            txtfechaPago.Text = "";
                            txtPagar.Text = "";
                            cboAdelanto.Text = "";
                            #endregion
                        }
                        else
                        {
                            MessageBoxButtons m = MessageBoxButtons.OK;
                            MessageBox.Show("han surgido errores, verifica...", "Error:", m, MessageBoxIcon.Stop);
                        }
                    }
                    else
                    {
                        return;
                    }
                    return;

                }

            }
            if (cboAdelanto.Text == "1 AÑO")
            {


                string Aplicado = txtPagar.Text;
                int _aplicado = int.Parse(Aplicado);


                string a_pagar = txtMonto.Text;
                int pagar = int.Parse(a_pagar);

                int mreal = int.Parse(montoDeCuotaMensual);
                mreal = mreal * 11;
                int paraValidar = pagar - mreal;

                if (_aplicado < paraValidar)
                {
                    MessageBox.Show("El Monto Aplicado No Corresponde Al Minimo A Pagar En Los Meses Seleccionados", "Error:");
                    return;
                }
                if (_aplicado > pagar)
                {
                    MessageBox.Show("El Monto Aplicado No Corresponde Al Maximo A Pagar En Los Meses Seleccionados", "Error:");
                    return;
                }

                if (_aplicado == pagar)
                {
                    fechapago = fechapago.AddMonths(12);
                    //Conexionnn .............
                    SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString);
                    cn.Open();

                    SqlCommand sc = new SqlCommand("PagoMensualidad", cn);
                    sc.CommandType = CommandType.StoredProcedure;
                    sc.Parameters.AddWithValue("@id", id);
                    sc.Parameters.AddWithValue("@monto", montoDeCuotaMensual);
                    sc.Parameters.AddWithValue("@fechaProx", fechapago.ToString("dd/MM/yyyy"));
                    sc.Parameters.AddWithValue("@atraso", "0");
                    sc.Parameters.AddWithValue("@adelanto", "0");
                    int r;
                    MessageBoxButtons Mess = MessageBoxButtons.YesNo;
                    DialogResult resultado = MessageBox.Show("¿Estas seguro de querer realizar el Adelanto?", "Confirmación:", Mess, MessageBoxIcon.Question);
                    if (resultado == DialogResult.Yes)
                    {
                        r = sc.ExecuteNonQuery();
                        if (r == 1)
                        {
                            MessageBox.Show("Adelanto realizado correctamente!!", "Aviso:", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ////____________GUARDANDO EN PAGO EN UNA TABLA_________________________
                            try
                            {
                                //Insertar Tabla Pagos
                                SqlConnection conne = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString);
                                conne.Open();
                                string iddd = txtID.Text;
                                DataTable dtttt = SqlClase.ObtenerDatos("ObtenerDatosParaPagar", "@id", id);
                                string montorr = dtttt.Rows[0][6].ToString();
                                SqlCommand sscommand = new SqlCommand("RegistrarPagos", conne);
                                sscommand.CommandType = CommandType.StoredProcedure;
                                sscommand.Parameters.AddWithValue("@id", txtID.Text);
                                sscommand.Parameters.AddWithValue("@nombre", txtNombre.Text);
                                sscommand.Parameters.AddWithValue("@f_pago", txtfechaPago.Text);
                                sscommand.Parameters.AddWithValue("@inscripcion", txtIngreso.Text);
                                sscommand.Parameters.AddWithValue("@tipo", tipo);
                                sscommand.Parameters.AddWithValue("@montoAplicado", txtPagar.Text);
                                sscommand.Parameters.AddWithValue("@atraso", txtAtraso.Text);
                                sscommand.Parameters.AddWithValue("@adelanto", txtAdelant.Text);
                                sscommand.Parameters.AddWithValue("@MontoCobrar", montorr);
                                sscommand.Parameters.AddWithValue("@Cant", "***TODO UN AÑO EN ADELANTO***");
                                sscommand.ExecuteNonQuery();

                                conne.Close();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                            //_____________________________________________________
                            //Para Ocultar Los Controles
                            #region
                            txtMonto.Enabled = false;
                            txtIngreso.Enabled = false;
                            txtPagar.Enabled = false;
                            txtNombre.Enabled = false;
                            txtfechaPago.Enabled = false;
                            btnLimpiarCampos.Enabled = false;
                            btnCobrar.Enabled = false;
                            btnRetornarPago.Enabled = false;
                            txtAdelant.Enabled = false;
                            txtAtraso.Enabled = false;
                            lblVerificarSiSeActivo.Text = "no";
                            cboAdelanto.Enabled = false;
                            txtCoutaMensual.Enabled = false;
                            txtCoutaMensual.Text = "0";
                            txtMonto.Text = "0.0";
                            DgvCobro.DataSource = "";
                            txtNombre.Text = "";
                            txtIngreso.Text = "";
                            txtfechaPago.Text = "";
                            txtPagar.Text = "";
                            cboAdelanto.Text = "";
                            txtAdelant.Text = "0";
                            txtMonto.Text = "0";
                            #endregion
                        }
                        else
                        {
                            MessageBoxButtons m = MessageBoxButtons.OK;
                            MessageBox.Show("han surgido errores, verifica...", "Error:", m, MessageBoxIcon.Stop);
                        }
                    }
                    else
                    {
                        return;
                    }
                    return;
                }
                if (_aplicado < pagar)
                {
                    int pago = pagar - _aplicado;
                    fechapago = fechapago.AddMonths(11);
                    //Conexionnn .............
                    SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString);
                    cn.Open();

                    SqlCommand sc = new SqlCommand("PagoMensualidad", cn);
                    sc.CommandType = CommandType.StoredProcedure;
                    sc.Parameters.AddWithValue("@id", id);
                    sc.Parameters.AddWithValue("@monto", pago);
                    sc.Parameters.AddWithValue("@fechaProx", fechapago.ToString("dd/MM/yyyy"));
                    sc.Parameters.AddWithValue("@atraso", "0");
                    sc.Parameters.AddWithValue("@adelanto", _aplicado.ToString());
                    int r;
                    MessageBoxButtons Mess = MessageBoxButtons.YesNo;
                    DialogResult resultado = MessageBox.Show("¿Estas seguro de querer realizar el Adelanto?", "Confirmación:", Mess, MessageBoxIcon.Question);
                    if (resultado == DialogResult.Yes)
                    {
                        r = sc.ExecuteNonQuery();
                        if (r == 1)
                        {
                            MessageBox.Show("Adelanto realizado correctamente!!", "Aviso:", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ////____________GUARDANDO EN PAGO EN UNA TABLA_________________________
                            try
                            {
                                //Insertar Tabla Pagos
                                SqlConnection conne = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString);
                                conne.Open();
                                string iddd = txtID.Text;
                                DataTable dtttt = SqlClase.ObtenerDatos("ObtenerDatosParaPagar", "@id", id);
                                string montorr = dtttt.Rows[0][6].ToString();
                                SqlCommand sscommand = new SqlCommand("RegistrarPagos", conne);
                                sscommand.CommandType = CommandType.StoredProcedure;
                                sscommand.Parameters.AddWithValue("@id", txtID.Text);
                                sscommand.Parameters.AddWithValue("@nombre", txtNombre.Text);
                                sscommand.Parameters.AddWithValue("@f_pago", txtfechaPago.Text);
                                sscommand.Parameters.AddWithValue("@inscripcion", txtIngreso.Text);
                                sscommand.Parameters.AddWithValue("@tipo", tipo);
                                sscommand.Parameters.AddWithValue("@montoAplicado", txtPagar.Text);
                                sscommand.Parameters.AddWithValue("@atraso", txtAtraso.Text);
                                sscommand.Parameters.AddWithValue("@adelanto", txtAdelant.Text);
                                sscommand.Parameters.AddWithValue("@MontoCobrar", montorr);
                                sscommand.Parameters.AddWithValue("@Cant", "**Abono De Un Año En Adelanto**");
                                sscommand.ExecuteNonQuery();

                                conne.Close();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                            //_____________________________________________________
                            //Para Ocultar Los Controles
                            #region
                            txtMonto.Enabled = false;
                            txtIngreso.Enabled = false;
                            txtPagar.Enabled = false;
                            txtNombre.Enabled = false;
                            txtfechaPago.Enabled = false;
                            btnLimpiarCampos.Enabled = false;
                            btnCobrar.Enabled = false;
                            btnRetornarPago.Enabled = false;
                            txtAdelant.Enabled = false;
                            txtAtraso.Enabled = false;
                            lblVerificarSiSeActivo.Text = "no";
                            cboAdelanto.Enabled = false;
                            txtCoutaMensual.Enabled = false;
                            txtCoutaMensual.Text = "0";
                            txtMonto.Text = "0.0";
                            DgvCobro.DataSource = "";
                            txtNombre.Text = "";
                            txtIngreso.Text = "";
                            txtfechaPago.Text = "";
                            txtPagar.Text = "";
                            cboAdelanto.Text = "";
                            txtAdelant.Text = "0";
                            txtMonto.Text = "0";
                            #endregion
                        }
                        else
                        {
                            MessageBoxButtons m = MessageBoxButtons.OK;
                            MessageBox.Show("han surgido errores, verifica...", "Error:", m, MessageBoxIcon.Stop);
                        }
                    }
                    else
                    {
                        return;
                    }
                    return;

                }

            }
        }
        private void Cobrar()
        {

            Validacion_Cobro();
            Obtener_Datos_Cobro();
            if (rbMensualidad.Checked == true)
            {
                Pago_Mensualidad();
            }
            if (rbAtraso.Checked == true)
            {
                Registrar_Atraso();
            }
            if (rbAdelanto.Checked == true)
            {
                Pago_Adelanto();
            }
            //_____________________________________________________
            //Para Ocultar Los Controles
            #region
            txtMonto.Enabled = false;
            txtIngreso.Enabled = false;
            txtPagar.Enabled = false;
            txtNombre.Enabled = false;
            txtfechaPago.Enabled = false;
            btnLimpiarCampos.Enabled = false;
            btnCobrar.Enabled = false;
            btnRetornarPago.Enabled = false;
            txtAdelant.Enabled = false;
            txtAtraso.Enabled = false;
            lblVerificarSiSeActivo.Text = "no";
            cboAdelanto.Enabled = false;
            txtCoutaMensual.Enabled = false;
            txtCoutaMensual.Text = "0";
            txtMonto.Text = "0.0";
            DgvCobro.DataSource = "";
            txtNombre.Text = "";
            txtIngreso.Text = "";
            txtfechaPago.Text = "";
            txtPagar.Text = "";
            cboAdelanto.Text = "";
            #endregion

        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Cobrar();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            frmBuscarClienteParaPagar buscarpagar = new frmBuscarClienteParaPagar();
            DialogResult res = buscarpagar.ShowDialog();
            if (res == DialogResult.OK)
            {
                txtID.Text = buscarpagar.IdCliente;
                txtID.Focus();
            }
        }

        private void btnRenombrar_Click(object sender, EventArgs e)
        {

        }

        private void FormDetalles_Load(object sender, EventArgs e)
        {
            LimpiarControles();
        }

        private void PresionaTeclaEnter(object sender, KeyPressEventArgs e)
        {
          
         if (e.KeyChar == Convert.ToChar(Keys.Enter))
         {
                try
                {
                    cboAdelanto.SelectedItem = "1 Mes";
                    txtCoutaMensual.Enabled = true;
                    txtMonto.Enabled = true;
                    txtIngreso.Enabled = true;
                    txtPagar.Enabled = true;
                    txtNombre.Enabled = true;
                    txtfechaPago.Enabled = true;
                    btnLimpiarCampos.Enabled = true;
                    btnCobrar.Enabled = true;
                    btnRetornarPago.Enabled = true;
                    txtAtraso.Enabled = true;
                    txtAdelant.Enabled = true;
                    lblVerificarSiSeActivo.Text = "Si";
                    string id = txtID.Text;
                    DataTable dt = SqlClase.ObtenerDatos("ObtenerDatosParaPagar", "@id", id);
                    txtNombre.Text = dt.Rows[0][0].ToString();
                    txtIngreso.Text = dt.Rows[0][1].ToString();
                    txtfechaPago.Text = dt.Rows[0][2].ToString();
                    txtCoutaMensual.Text = dt.Rows[0][3].ToString();
                    txtAtraso.Text = dt.Rows[0][4].ToString();
                    txtAdelant.Text = dt.Rows[0][5].ToString();
                    txtMonto.Text = dt.Rows[0][6].ToString();

                   

                    SqlClase.FiltrarDatos("MOSTRAR_PAGOS_YA_REALIZADOS", "@Id", txtID.Text, DgvCobro);
                    cboAdelanto.Text = "Selecciona...";
                    txtPagar.Focus();
                }
                catch (System.IndexOutOfRangeException)
                {
                    txtMonto.Enabled = false;
                    txtIngreso.Enabled = false;
                    txtPagar.Enabled = false;
                    txtNombre.Enabled = false;
                    txtfechaPago.Enabled = false;
                    btnLimpiarCampos.Enabled = false;
                    btnCobrar.Enabled = false;
                    btnRetornarPago.Enabled = false;
                    txtAdelant.Enabled = false;
                    txtAtraso.Enabled = false;
                    lblVerificarSiSeActivo.Text = "no";
                    cboAdelanto.Enabled = false;
                    txtCoutaMensual.Enabled = false;
                    txtCoutaMensual.Text = "0";
                    txtMonto.Text = "0.0";
                    DgvCobro.DataSource = "";
                    txtNombre.Text = "";
                    txtIngreso.Text = "";
                    txtfechaPago.Text = "";
                    txtPagar.Text = "";
                    cboAdelanto.Text = "";
                    MessageBox.Show("No existe ningun cliente con el codigo especificado", "Codigo Incorrecto:", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
         }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (rbAdelanto.Checked == true && lblVerificarSiSeActivo.Text == "Si") 
            {
                cboAdelanto.Enabled = true;
            }
            else 
            { 
                cboAdelanto.Enabled = false; 
            }
        }

        private void txtID_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtMonto_TextChanged(object sender, EventArgs e)
        {

        }

        private void Evento_Mes_Adelanto(object sender, EventArgs e)
        {
            try
            {

                string id = txtID.Text;
                DataTable dtdd = SqlClase.ObtenerDatos("ObtenerDatosParaPagar", "@id", id);
                DataTable dt = SqlClase.ObtenerDatos("obtenerMontoReal", "@id", id);
                string montoDeCuotaMensual = dt.Rows[0][0].ToString();
                string monto = dt.Rows[0][1].ToString();
                string a_pagar = txtMonto.Text;
                int pgoNuevo = 0;
                int monto___real = int.Parse(montoDeCuotaMensual);
                int montoYa = int.Parse(monto);

                int mt = monto___real * 2;

                if (cboAdelanto.Text == "1 Mes")
                {
                    txtMonto.Text = dtdd.Rows[0][6].ToString();
                }
                if (cboAdelanto.Text == "2  Meses")
                {
                    pgoNuevo = montoYa + monto___real;
                    txtMonto.Text = pgoNuevo.ToString();
                }
                if (cboAdelanto.Text == "3 Meses")
                {
                    pgoNuevo = montoYa + mt;
                    txtMonto.Text = pgoNuevo.ToString();
                }
                if (cboAdelanto.Text == "4 Meses")
                {
                    pgoNuevo = montoYa + monto___real * 3;
                    txtMonto.Text = pgoNuevo.ToString();
                }
                if (cboAdelanto.Text == "5 Meses")
                {
                    pgoNuevo = montoYa + monto___real * 4;
                    txtMonto.Text = pgoNuevo.ToString();
                }
                if (cboAdelanto.Text == "6 Meses")
                {
                    pgoNuevo = montoYa + monto___real * 5;
                    txtMonto.Text = pgoNuevo.ToString();
                }
                if (cboAdelanto.Text == "7 Meses")
                {
                    pgoNuevo = montoYa + monto___real * 6;
                    txtMonto.Text = pgoNuevo.ToString();
                }
                if (cboAdelanto.Text == "8 Meses")
                {
                    pgoNuevo = montoYa + monto___real * 7;
                    txtMonto.Text = pgoNuevo.ToString();
                }
                if (cboAdelanto.Text == "9 Meses")
                {
                    pgoNuevo = montoYa + monto___real * 8;
                    txtMonto.Text = pgoNuevo.ToString();
                }
                if (cboAdelanto.Text == "10 Meses")
                {
                    pgoNuevo = montoYa + monto___real * 9;
                    txtMonto.Text = pgoNuevo.ToString();
                }
                if (cboAdelanto.Text == "11 Meses")
                {
                    pgoNuevo = montoYa + monto___real * 10;
                    txtMonto.Text = pgoNuevo.ToString();

                }
                if (cboAdelanto.Text == "1 AÑO")
                {
                    pgoNuevo = montoYa + monto___real * 11;
                    txtMonto.Text = pgoNuevo.ToString();
                }
            }
            catch (Exception)
            {

            }
        }

        private void cboAdelanto_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DgvCobro.DataSource = "";
        }

        private void rbMensualidad_CheckedChanged(object sender, EventArgs e)
        {
            if(rbMensualidad.Checked == true)
            {
                cboAdelanto.Enabled = false;
            }
        }

        private void rbAtraso_CheckedChanged(object sender, EventArgs e)
        {
            if (rbAtraso.Checked == true)
            {
                cboAdelanto.Enabled = false;
            }
        }

        private void btnLimpiarCampos_Click(object sender, EventArgs e)
        {
            txtMonto.Enabled = false;
            txtIngreso.Enabled = false;
            txtPagar.Enabled = false;
            txtNombre.Enabled = false;
            txtfechaPago.Enabled = false;
            btnLimpiarCampos.Enabled = false;
            btnCobrar.Enabled = false;
            btnRetornarPago.Enabled = false;
            txtAdelant.Enabled = false;
            txtAtraso.Enabled = false;
            lblVerificarSiSeActivo.Text = "no";
            cboAdelanto.Enabled = false;
            txtCoutaMensual.Enabled = false;
            txtCoutaMensual.Text = "0";
            txtMonto.Text = "0.0";
            DgvCobro.DataSource = "";
            txtNombre.Text = "";
            txtIngreso.Text = "";
            txtfechaPago.Text = "";
            txtPagar.Text = "";
            cboAdelanto.Text = "";
        }

        private void btnRetornarPago_Click(object sender, EventArgs e)
        {
            string id = DgvCobro.CurrentRow.Cells[0].Value.ToString();
            string fechaProxima = DgvCobro.CurrentRow.Cells[3].Value.ToString();
            string montoAPagar = DgvCobro.CurrentRow.Cells[8].Value.ToString();
            string adelanto = DgvCobro.CurrentRow.Cells[7].Value.ToString();
            string atraso = DgvCobro.CurrentRow.Cells[6].Value.ToString();


            //______________________________ACTUALIZACION Y LLAMADO A BASE DE DATOS ________________
            SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString);
            cn.Open();

            SqlCommand sc = new SqlCommand("RETORNAR_PAGO", cn);
            sc.CommandType = CommandType.StoredProcedure;
            sc.Parameters.AddWithValue("@ID", id);
            sc.Parameters.AddWithValue("@PROX_FECHA", fechaProxima);
            sc.Parameters.AddWithValue("@montoPagar", montoAPagar);
            sc.Parameters.AddWithValue("@adelanto", adelanto);
            sc.Parameters.AddWithValue("@atraso", atraso);

            MessageBoxButtons MS = MessageBoxButtons.YesNo;
            DialogResult si = MessageBox.Show("¿Estás Seguro De Retornar El Pago Seleccionado A: " + txtNombre.Text + "?", "Confirmación", MS, MessageBoxIcon.Question);
            if (si == DialogResult.Yes)
            {
                int r = sc.ExecuteNonQuery();
                if (r >= 1)
                {
                    MessageBox.Show("Se A Retornado El Pago Con Exito.", "Aviso:", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    //_____________________________________________________
                    //Para Ocultar Los Controles
                    #region
                    txtMonto.Enabled = false;
                    txtIngreso.Enabled = false;
                    txtPagar.Enabled = false;
                    txtNombre.Enabled = false;
                    txtfechaPago.Enabled = false;
                    btnLimpiarCampos.Enabled = false;
                    btnCobrar.Enabled = false;
                    btnRetornarPago.Enabled = false;
                    txtAdelant.Enabled = false;
                    txtAtraso.Enabled = false;
                    lblVerificarSiSeActivo.Text = "no";
                    cboAdelanto.Enabled = false;
                    txtCoutaMensual.Enabled = false;
                    txtCoutaMensual.Text = "0";
                    txtMonto.Text = "0.0";
                    DgvCobro.DataSource = "";
                    txtNombre.Text = "";
                    txtIngreso.Text = "";
                    txtfechaPago.Text = "";
                    txtPagar.Text = "";
                    cboAdelanto.Text = "";
                    txtAdelant.Text = "0";
                    txtMonto.Text = "0";
                    #endregion
                }
                else
                    MessageBox.Show("Ocurrio Un Error Inesperado");
            }
            else
            {
                return;
            }
        }
    }
}
