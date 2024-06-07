using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControlDeEstudiantes.Capas
{
    public partial class frmBienvenido : Form
    {
        public frmBienvenido()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            while(this.Opacity > 0)
            {
                this.Opacity -= 0.00001;
            }
            this.Hide();
            FormInicio frm = new FormInicio();
            frm.Show();
            timer1.Stop();
        }

        private void frmBienvenido_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            timer1.Interval = 1500;
            timer1.Start();
        }
    }
}
