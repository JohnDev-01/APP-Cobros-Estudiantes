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
    public partial class frmImprimirListadoClientes : Form
    {
        public frmImprimirListadoClientes()
        {
            InitializeComponent();
        }

        private void frmImprimirListadoClientes_Load(object sender, EventArgs e)
        {
            crystalReportViewer1.Update();

            
        }
    }
}
