using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControlDeEstudiantes.Capas
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {

        }

        private void btncerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnminimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        
        private async void Login()
        {
            string Usuario = txtUsuario.Text;
            string contra = txtContra.Text;

            string Rl = "";


            try
            {
                SqlConnection cns = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString);
                cns.Open();
                SqlCommand sd = new SqlCommand("VerificarLogin", cns);
                sd.CommandType = CommandType.StoredProcedure;
                sd.Parameters.AddWithValue("@usuario", Usuario);
                sd.Parameters.AddWithValue("@contra", contra);
                sd.ExecuteNonQuery();
                SqlDataReader dr = sd.ExecuteReader();
                if (dr.Read())
                {

                    Rl = dr["Rol"].ToString();


                    timer1.Enabled = true;
                    timer1.Interval = 1500;
                    timer1.Start();
                    while (this.Opacity > 0)
                    {
                        this.Opacity -= 0.00001;
                    }
                    
                    
                 
                    FormInicio fr = new FormInicio();
                    if(Rl == "Asistente")
                    {
                        fr.configuracionToolStripMenuItem.Visible = false;
                        fr.btn_cobrar.Enabled = false;
                        fr.btn_PagosEmpleados.Enabled = false;
                    }
                    else
                    {
                        fr.configuracionToolStripMenuItem.Visible = true;
                        fr.btn_cobrar.Enabled = true;
                        fr.btn_PagosEmpleados.Enabled = true;
                    }
                    fr.Show();
                    this.Hide();
                    timer1.Stop();
                }
                else
                {
                   
                    panelAviso1.Visible = true;
                    await Task.Run(() =>
                    {
                        Thread.Sleep(4000);
                    });
                  
                    panelAviso1.Visible = false;
                }
                cns.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ocurrio Un Error:");
            }
        }
        private void btnlogin_Click(object sender, EventArgs e)
        {
            Login();
        }

        private void tver_Click(object sender, EventArgs e)
        {
            txtContra.UseSystemPasswordChar = false ;
            tocultar.Visible = true;
            tver.Visible = false;
        }

        private void tocultar_Click(object sender, EventArgs e)
        {
            txtContra.UseSystemPasswordChar = true;
            tocultar.Visible = false;
            tver.Visible = true;
        }

        private void txtUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                txtContra.Focus();
            }
        }

        private void txtContra_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                Login();
            }
        }
    }
}
