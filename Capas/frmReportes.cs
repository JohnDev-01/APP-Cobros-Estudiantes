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
    public partial class frmReportes : Form
    {
        public frmReportes()
        {
            InitializeComponent();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }
        private async Task IMPRIMIR()
        {
            await Task.Run(() =>
            {

                if (rbReportes.Checked == true)
                {
                    if (RbListadoClientesReporte.Checked == true)
                    {
                        frmImprimirListadoClientes L_todos_Clientes = new frmImprimirListadoClientes();
                        L_todos_Clientes.Show();
                    }
                    if (rbConAdelantosReportes.Checked == true)
                    {
                        Capas_De_Imprimir.frmImprimirReporteAdelanto RAdelato = new Capas_De_Imprimir.frmImprimirReporteAdelanto();
                        RAdelato.Show();
                    }
                    if (RbConAtrasosReportes.Checked == true)
                    {
                        Capas_De_Imprimir.frmImprimirReporteAtrasos RAtrasos = new Capas_De_Imprimir.frmImprimirReporteAtrasos();
                        RAtrasos.Show();
                    }
                }
            });
        }
        private async void  button3_Click(object sender, EventArgs e)
        {
            panelGenerando.Visible = true;
            await IMPRIMIR();
            panelGenerando.Visible = false;
        }

        private void frmReportes_Load(object sender, EventArgs e)
        {
            panelGenerando.Visible = false;
        }
    }
}
