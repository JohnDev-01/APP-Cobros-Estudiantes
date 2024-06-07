using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using System.Configuration;

namespace ControlDeEstudiantes.Clases
{
    public class SqlClase
    {

        //Conexion Global:
        string REConexion = "";
        private static SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString);

        public static void ListarConsulta(string consulta, DataGridView grilla)
        {
            SqlCommand Sc = new SqlCommand(consulta, cn);

            SqlDataAdapter ada = new SqlDataAdapter(Sc);

            DataTable table = new DataTable();

            ada.Fill(table);

            grilla.DataSource = table;
        }

        public static void FiltrarDatos(string nombreProcedure, string NombreParametro, string valorParametro, DataGridView Grid)
        {
            SqlCommand cmd = new SqlCommand(nombreProcedure, cn);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue(NombreParametro, valorParametro);

            DataTable tabla = new DataTable();

            SqlDataAdapter sda = new SqlDataAdapter(cmd);

            sda.Fill(tabla);

            Grid.DataSource = tabla;

        }
        public static DataTable ObtenerDatos(string nombreProcedure, string NombreParametro, string valorParametro)
        {
           
            SqlCommand cmd = new SqlCommand(nombreProcedure, cn);

            cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue(NombreParametro, valorParametro);

                DataTable tabla = new DataTable();

                SqlDataAdapter sda = new SqlDataAdapter(cmd);
            try
            {
                sda.Fill(tabla);
            }
            catch (System.Data.SqlClient.SqlException)
            {
            }


            return tabla;
        }
        public static void ListarProcedureSql(string NombreProcedure, DataGridView dgv)
        {
            //OJO NO SE AGREGO SQLCONEXION PORQUE ESTA ARRIBA COMO VARIABLE GLOBAL

            SqlCommand cmd = new SqlCommand(NombreProcedure, cn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable tabla = new DataTable();
            sda.Fill(tabla);
            dgv.DataSource = tabla;
        }

    }
}
