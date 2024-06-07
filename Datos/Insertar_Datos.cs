using ControlDeEstudiantes.DataAccess;
using ControlDeEstudiantes.Logica;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ControlDeEstudiantes.Datos
{
    public class Insertar_Datos
    {
        //----------Cobros--------
        public static void PagoMensualidad(string id,string dineroProxPago,string FechaproximoPago, int AtrasoParaAplicar,string adelanto)
        {
            try
            {
                Conexion.abrir();

                SqlCommand sc = new SqlCommand("PagoMensualidad", Conexion.conectar);
                sc.CommandType = CommandType.StoredProcedure;
                sc.Parameters.AddWithValue("@id", id);
                sc.Parameters.AddWithValue("@monto", dineroProxPago);
                sc.Parameters.AddWithValue("@fechaProx", FechaproximoPago);
                sc.Parameters.AddWithValue("@atraso", AtrasoParaAplicar);
                sc.Parameters.AddWithValue("@adelanto", adelanto);
                sc.ExecuteNonQuery();
                
            }
            catch (Exception ex )
            {
               
            }
            finally
            {
                Conexion.cerrar();
            }
        }
        public bool PagoMensualidad(LPEstuadiantes pr)
        {
            try
            {
                Conexion.abrir();
                SqlCommand scommand = new SqlCommand("RegistrarPagos", Conexion.conectar);
                scommand.CommandType = CommandType.StoredProcedure;
                scommand.Parameters.AddWithValue("@id", pr.Id);
                scommand.Parameters.AddWithValue("@nombre", pr.Nombre);
                scommand.Parameters.AddWithValue("@f_pago", pr.Fecha_Pago);
                scommand.Parameters.AddWithValue("@inscripcion", pr.Inscripcion);
                scommand.Parameters.AddWithValue("@tipo", pr.Tipo);
                scommand.Parameters.AddWithValue("@montoAplicado", pr.Monto_Aplicado);
                scommand.Parameters.AddWithValue("@atraso", pr.Atraso);
                scommand.Parameters.AddWithValue("@adelanto",pr.Adelanto);
                scommand.Parameters.AddWithValue("@MontoCobrar", pr.Monto_A_Pagar);
                //scommand.Parameters.AddWithValue("@Cant",pr.Cant);
                int r = scommand.ExecuteNonQuery();
                Conexion.cerrar();
                return true;
            }
            catch (Exception ex)
            {
                
                return false;
            }
            finally
            {
                
            }
        }
        public static void RegistroAdelanto(Ladelanto Ad)
        {
            try
            {
                Conexion.abrir();
                SqlCommand sc = new SqlCommand("PagoMensualidad", Conexion.conectar);
                sc.CommandType = CommandType.StoredProcedure;
                sc.Parameters.AddWithValue("@id", Ad.Id);
                sc.Parameters.AddWithValue("@monto", Ad.Monto);
                sc.Parameters.AddWithValue("@fechaProx", Ad.FechaProx);
                sc.Parameters.AddWithValue("@atraso", Ad.atraso);
                sc.Parameters.AddWithValue("@adelanto", Ad.adelanto);
                var resultado = MessageBox.Show("¿Estas seguro de querer realizar el Adelanto?", "Confirmación:", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resultado == DialogResult.Yes)
                {
                   int r = sc.ExecuteNonQuery();
                    if (r >= 1)
                    {
                        MessageBox.Show("Adelanto realizado correctamente!!", "Aviso:", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ////____________GUARDANDO EN PAGO EN UNA TABLA_________________________

                        HistorialPagos();
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
            catch(Exception ex)
            {

            }
            finally
            {

            }    
        }

        private static  void HistorialPagos()
        {
            try
            {
                //Insertar Tabla Pagos
                Conexion.abrir();
                string iddd = txtID.Text;
                DataTable dtttt = SqlClase.ObtenerDatos("ObtenerDatosParaPagar", "@id", id);
                string montorr = dtttt.Rows[0][6].ToString();
                SqlCommand sscommand = new SqlCommand("RegistrarPagos", Conexion.conectar);
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
                Conexion.cerrar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
