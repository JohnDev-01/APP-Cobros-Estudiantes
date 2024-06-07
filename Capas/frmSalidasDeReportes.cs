using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ControlDeEstudiantes.Capas;

namespace ControlDeEstudiantes.Capas
{
    public partial class frmSalidasDeReportes : Form
    {
        
        public frmSalidasDeReportes()
        {
            InitializeComponent();
        }
        

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            if (rbTodos.Checked == true)
            {
              
                    frmImprimirListadoClientes f = new frmImprimirListadoClientes();
                    f.ShowDialog();
              
            }
            if(rbAtrasos.Checked == true)
            {
                Capas_De_Imprimir.frmImprimirReporteAtrasos d = new Capas_De_Imprimir.frmImprimirReporteAtrasos();
                d.ShowDialog();
            }
            if (rbAdelantos.Checked == true)
            {
                Capas_De_Imprimir.frmImprimirReporteAdelanto d = new Capas_De_Imprimir.frmImprimirReporteAdelanto();
                d.ShowDialog();
            }
        }

        private void frmSalidasDeReportes_Load(object sender, EventArgs e)
        {
            
        }
    }
}
