using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using ControlDeEstudiantes.Clases;

namespace ControlDeEstudiantes.Capas
{
    public partial class frmBuscarClienteParaPagar : Form
    {
        public string IdCliente { get; set; }
        public frmBuscarClienteParaPagar()
        {
            InitializeComponent();
        }
        private void ListarBuscar()
        {
            SqlClase.ListarConsulta("select ID,Nombre,[Fecha Pago],Monto from RegistroEstudiantes where Habilitado= 1", dgvBuscarPagar);
        }
        private void frmBuscarClienteParaPagar_Load(object sender, EventArgs e)
        {
            rbNombre.Checked = true;
            ListarBuscar();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {

        }

        private void btnSeleccionar_Click_1(object sender, EventArgs e)
        {
            
            IdCliente = dgvBuscarPagar.CurrentRow.Cells[0].Value.ToString();
          
        }

        private void Evento_Buscar_Cliente(object sender, EventArgs e)
        {
            string busquedaTxt = txtbuscar.Text;
            if(rbNombre.Checked == true)
            {
              SqlClase.FiltrarDatos("BuscarPorNombre_ParaPagar", "@nombre", busquedaTxt, dgvBuscarPagar);
                if (txtbuscar.Text == "")
                {
                    ListarBuscar();
                }
            }
            if (rbMonto.Checked == true)
            {

                SqlClase.FiltrarDatos("buscarporMonto_paraPagar", "monto", busquedaTxt, dgvBuscarPagar);
                if(txtbuscar.Text == "")
                {
                    ListarBuscar();
                }
            }
        }

        private void dgvBuscarPagar_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            IdCliente = dgvBuscarPagar.CurrentRow.Cells[0].Value.ToString();
            this.DialogResult = DialogResult.OK;
        }
    }
}
