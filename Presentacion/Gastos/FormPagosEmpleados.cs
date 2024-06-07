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
using ControlDeEstudiantes.Clases;

namespace ControlDeEstudiantes.Capas
{
    public partial class FormPagosEmpleados : Form
    {
        public FormPagosEmpleados()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormRegistrar sh = new FormRegistrar();
            sh.ShowDialog();
            if (sh.DialogResult == DialogResult.OK)
            {
                Listar();
            }
        }
        private void Listar()
        {
            SqlClase.ListarConsulta("select Nombre,Fecha,Monto from PagosEmpleados where Habilitado= 1", dgvEmpleados);
        }
        private void FormPagosEmpleados_Load(object sender, EventArgs e)
        {
            Listar();
            txtBusqueda.Focus();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            string fecha = dgvEmpleados.CurrentRow.Cells[1].Value.ToString();
            string nombre = dgvEmpleados.CurrentRow.Cells[0].Value.ToString();
            string monto = dgvEmpleados.CurrentRow.Cells[2].Value.ToString();

            SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString);
            cn.Open();

            SqlCommand sc = new SqlCommand("ELIMINAR_PAGOS_EMPLEADOS", cn);
            sc.CommandType = CommandType.StoredProcedure;
            sc.Parameters.AddWithValue("@nom", nombre);
            sc.Parameters.AddWithValue("@fecha", fecha);
            sc.Parameters.AddWithValue("@monto", monto);

          DialogResult resp =   MessageBox.Show("¿Estás seguro de querer eliminar el pago seleccionado?", "Confirmación:", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resp == DialogResult.Yes)
            {
                int r = sc.ExecuteNonQuery();

                if (r == 1)
                {
                    MessageBox.Show("El Pago Se Elimino Correctamente", "Aviso:", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Listar();
                }
                else
                    MessageBox.Show("Ocurrio un error inesperado.");
            }
            else
                return;
        }

        private void Busqueda_txt(object sender, EventArgs e)
        {
            string busqueda = txtBusqueda.Text;

            if (rbFecha.Checked == true)
            {
                SqlClase.FiltrarDatos("BUSCAR_PAGOS_EMP_PORfecha", "@fecha", busqueda, dgvEmpleados);
                if(txtBusqueda.Text == "")
                {
                    Listar();
                }
            }
            if (rbNombre.Checked == true)
            {
                SqlClase.FiltrarDatos("BUSCAR_PAGOS_EMP_PORnombre", "@nom", busqueda, dgvEmpleados);
                if (txtBusqueda.Text == "")
                {
                    Listar();
                }
            }
        }

        private void btn_Reporte_Click(object sender, EventArgs e)
        {
            Capas_De_Imprimir.frmPagosEmpleadosImprimir sa = new Capas_De_Imprimir.frmPagosEmpleadosImprimir();
            sa.ShowDialog();
        }
    }
}
