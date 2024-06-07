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

namespace ControlDeEstudiantes.Capas
{
    public partial class FormRegistrar : Form
    {
        public FormRegistrar()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {

            if (txtNombre.Text == "")
            {
                MessageBox.Show("No puedes guardar un pago sin asignarle un nombre al empleado.", "Aviso:", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                return;
            }


            //Declaracion Variables
            string nombre = txtNombre.Text;
            string monto = txtMonto.Text;
            string fecha = DtFecha.Value.ToString("dd/MM/yyyy");

            SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString);
            cn.Open();

            SqlCommand sc = new SqlCommand("PagosEmp", cn);
            sc.CommandType = CommandType.StoredProcedure;
            sc.Parameters.AddWithValue("@Nombre", nombre);
            sc.Parameters.AddWithValue("@Fecha",fecha);
            sc.Parameters.AddWithValue("@monto",monto);

            int R = sc.ExecuteNonQuery();
            if (R == 1)
            {
                MessageBox.Show("El Pago Se Registro Correctamente", "Aviso:",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Ocurrio un error inesperado...","Uyyy:");
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
