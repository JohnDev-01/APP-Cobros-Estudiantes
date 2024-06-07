using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControlDeEstudiantes.Capas
{
    public partial class frmImprmirRecibo : Form
    {
        public frmImprmirRecibo()
        {
            InitializeComponent();
        }
        private void Parametor()
        {
            var sqlCon = "server= localhost; database=RegistroEstudiantes; Integrated Security=true"; ;
            try
            {
                SqlConnection cn = new SqlConnection();
                cn.ConnectionString = sqlCon;
                cn.Open();

                SqlCommand com = new SqlCommand("Prueba_recibos", cn);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@id",459);
                com.ExecuteNonQuery();
                cn.Close();
            }
            catch (Exception EX)
            {
                MessageBox.Show(EX.Message);
            }
        }
        private void frmImprmirRecibo_Load(object sender, EventArgs e)
        {
            Parametor();
            //crystalReportViewer1.ReportSource = "Recibos1[ControlDeEstudiantes.ParaImprimir.Recibos]";
            //crystalReportViewer1.PrintReport();
            //crystalReportViewer1.Update();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ParaImprimir.Recibos d = new ParaImprimir.Recibos();
            d.PrintToPrinter(1, true, 0, 0);
        }
    }
}
