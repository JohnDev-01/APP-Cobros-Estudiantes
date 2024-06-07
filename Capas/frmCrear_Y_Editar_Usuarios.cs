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
    public partial class frmCrear_Y_Editar_Usuarios : Form
    {
        public string Titulo { get; set; }
        public string id { get; set; }
        public frmCrear_Y_Editar_Usuarios()
        {
            InitializeComponent();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void frmCrear_Y_Editar_Usuarios_Load(object sender, EventArgs e)
        {
            if (Titulo == "Nuevo")
            {
                this.Text = "Crear Nuevo Usuario";
                this.cbRol.Text = "Selecciona...";
            }
            if (Titulo == "Editar")
            {
                this.Text = "Editar Usuario Existente";
                DataTable dt = SqlClase.ObtenerDatos("ObtenerUsuariosParaEditar", "@id", id);
                txtNombre.Text = dt.Rows[0][0].ToString();
                txtUsuario.Text = dt.Rows[0][1].ToString();
                txtContra.Text = dt.Rows[0][2].ToString();
                cbRol.Text = dt.Rows[0][3].ToString();

            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            
            if (txtNombre.Text == "" || txtContra.Text == ""||txtUsuario.Text == ""|| cbRol.Text == "Selecciona...")
            {
                MessageBox.Show("No Pueden Haber Espacios Vacios.", "Verifica:",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            
            
            if (Titulo == "Nuevo")
            {
                string Roles = "";
                if (cbRol.SelectedItem.ToString() == "Asistente")
                {
                    Roles = "Asistente";
                }
                if (cbRol.SelectedItem.ToString() == "Administrador")
                {
                    Roles = "Administrador";
                }

                //Validacion de variable para insertar usuarios
                string nombre = txtNombre.Text;
                string usuario = txtUsuario.Text;
                string Rol = Roles;
                string Contra = txtContra.Text;



                SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString);
                cn.Open();

                SqlCommand c = new SqlCommand("InsertarUsuario", cn);
                c.CommandType = CommandType.StoredProcedure;
                c.Parameters.AddWithValue("@nombre", nombre);
                c.Parameters.AddWithValue("@usuario", usuario);
                c.Parameters.AddWithValue("@contra", Contra);
                c.Parameters.AddWithValue("@rol", Rol);

                DialogResult r = MessageBox.Show("¿Estás seguro de guardar el usuario '" + usuario + "'?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (r == DialogResult.Yes)
                {
                    int resul = c.ExecuteNonQuery();
                    if (resul >= 1)
                    {
                        MessageBox.Show("El usuario se a creado con exito", "Aviso:", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Ya existe un mismo nombre de usuario.", "Error:", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

            }

            if (Titulo == "Editar")
            {
                string nombre = txtNombre.Text;
                string usuario = txtUsuario.Text;
                string contra = txtContra.Text;
                string rol = cbRol.Text;
                

                SqlConnection sc = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString);
                sc.Open();

                SqlCommand coman = new SqlCommand("ActualizarUsuarios", sc);
                coman.CommandType = CommandType.StoredProcedure;
                coman.Parameters.AddWithValue("@nombre", nombre);
                coman.Parameters.AddWithValue("@usuario", usuario);
                coman.Parameters.AddWithValue("@contra", contra);
                coman.Parameters.AddWithValue("@rol", rol);
                coman.Parameters.AddWithValue("@id", id);

                DialogResult dt = MessageBox.Show("¿Estas seguro de querer actualizar el usuario?", "Confirmación:", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dt == DialogResult.Yes)
                {
                    int r = coman.ExecuteNonQuery();
                    if (r >= 1)
                    {
                        MessageBox.Show("El Usuario Se Actualizo Correctamente.", "Aviso:", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        sc.Close();
                    }
                    else
                        MessageBox.Show("El Usuario No Se Pudo Actualizar", "Error:", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                    return;

                sc.Close();
            }
           
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
