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
    public partial class FormBase : Form
    {
        public FormBase()
        {
            InitializeComponent();
        }

        private void FormBase_Load(object sender, EventArgs e)
        {
            FormInicio Oinicio = new FormInicio();
            Oinicio.MdiParent = this;  /// para agregar dentro this.mdiparent
            Oinicio.Show();
        }
        private void sts()
        {




        }
    }
}
