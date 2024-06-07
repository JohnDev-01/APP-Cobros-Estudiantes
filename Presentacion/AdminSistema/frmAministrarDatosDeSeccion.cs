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
    public partial class frmAministrarDatosDeSeccion : Form
    {
        public frmAministrarDatosDeSeccion()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            frmCrear_Y_Editar_Usuarios oCrear = new frmCrear_Y_Editar_Usuarios();
            oCrear.Titulo = "Nuevo";
            oCrear.Show();
        }
        private void Listar()
        {
            SqlClase.ListarConsulta("select ID,Nombre,[Nombre Usuario],Contraseña,Rol from Usuarios Where Habilitado = 1", dgvUsuarios);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Listar();
        }

        private void Btn_Nuevo_Click(object sender, EventArgs e)
        {
            frmCrear_Y_Editar_Usuarios oCrear = new frmCrear_Y_Editar_Usuarios();
            oCrear.Titulo = "Nuevo";
            oCrear.Show();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {

        }

        private void btn_Actualizar_Click(object sender, EventArgs e)
        {
            Listar();
        }

        private void btn_Eliminar_Click(object sender, EventArgs e)
        {
            string ID =  dgvUsuarios.CurrentRow.Cells[0].Value.ToString();
            SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString);
            cn.Open();
            SqlCommand sc = new SqlCommand("EliminarUsuarioLogin", cn);
            sc.CommandType = CommandType.StoredProcedure;
            sc.Parameters.AddWithValue("@id", ID);

            DialogResult jk = MessageBox.Show("Si elimina el usuario seleccionado ya no podra acceder al sistema con este usuario" +
                ", ¿Estás seguro de eliminar el usuario?", "Confirmación:", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (jk == DialogResult.Yes)
            {
                int r = sc.ExecuteNonQuery();
                if (r >= 1)
                {
                    MessageBox.Show("El Usuario a sido eliminado correctamente.", "Aviso:", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    MessageBox.Show("El Usuario No Se Pudo Eliminar Debido A Un Error Inesperado, Vuelve a Intentar", "Upss...");
            }
            else
                return;
            cn.Close();

            Listar();
        }

        private void frmAministrarDatosDeSeccion_Load(object sender, EventArgs e)
        {
            Listar();
        }

        private void btn_Editar_Click(object sender, EventArgs e)
        {
            frmCrear_Y_Editar_Usuarios oCrear = new frmCrear_Y_Editar_Usuarios();
            oCrear.Titulo = "Editar";
            oCrear.id = dgvUsuarios.CurrentRow.Cells[0].Value.ToString();
            oCrear.ShowDialog();
        }
    }
}
