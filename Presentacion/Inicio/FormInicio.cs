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
using System.Globalization;
using ControlDeEstudiantes.Capas;
using ControlDeEstudiantes.Capas.Capas_De_Imprimir;
namespace ControlDeEstudiantes
{
    public partial class FormInicio : Form
    {
        public FormInicio()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            listar();
        }
        
        public void listar()
        {
           SqlClase.ListarConsulta("select ID,Nombre,Apellido,Celular,Seccion,[Fecha Inscripcion],[Fecha Pago],Monto " + 
               "from RegistroEstudiantes where Habilitado = 1",dgvEstudiantes);
        }
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Capas.FormAgregarYEditar oagregar = new Capas.FormAgregarYEditar();
            oagregar.MdiParent = this.MdiParent;
            oagregar.Global = "Nuevo";
            oagregar.Show();
            
        }

        private void BtnDetalles_Click(object sender, EventArgs e)
        {
            //Capas.FormVerDetalles OverDetalles = new Capas.FormVerDetalles();
            //OverDetalles.MdiParent = this.MdiParent;
            //OverDetalles.Show();
        }

        private void btnpagosEmpleados_Click(object sender, EventArgs e)
        {
            Capas.FormPagosEmpleados oPagos = new Capas.FormPagosEmpleados();
            oPagos.MdiParent = this.MdiParent;
            oPagos.Show();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            Capas.FormAgregarYEditar oagregar = new Capas.FormAgregarYEditar();
            oagregar.MdiParent = this.MdiParent;
            oagregar.Global = "Editar";
            oagregar.Id = dgvEstudiantes.CurrentRow.Cells[0].Value.ToString();
            oagregar.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listar();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        { 
            string id = dgvEstudiantes.CurrentRow.Cells[0].Value.ToString();

            SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString);
            cn.Open();

            SqlCommand sc = new SqlCommand("eliminarEstudiantes", cn);
            sc.CommandType = CommandType.StoredProcedure;
            sc.Parameters.AddWithValue("@IdEstudiante", id);

           int r =  sc.ExecuteNonQuery();
            if (r == 1)
            {
                MessageBox.Show("Registro eliminado correctamente");
            }
        }

        private void txtBusquedaChanged(object sender, EventArgs e)
        {
            string busquedaTxt = txtBusqueda.Text;
            if (BuscarPorNombre.Checked == true)
            {
                
                SqlClase.FiltrarDatos("buscarPorNombre", "@nombre", busquedaTxt, dgvEstudiantes);
                if (txtBusqueda.Text == "")
                {
                    listar();
                }
            }
            if (buscarApellido.Checked == true)
            {
                SqlClase.FiltrarDatos("BuscarPorApelido", "@apellido", busquedaTxt, dgvEstudiantes);
                if (txtBusqueda.Text == "")
                {
                    listar();
                }
                  
            }
            if (buscarPorCel.Checked == true)
            {

                SqlClase.FiltrarDatos("BuscarPorCel", "@cel", busquedaTxt, dgvEstudiantes);
                if (txtBusqueda.Text == "")
                {
                    listar();
                }

            }
            if (buscarPorMonto.Checked == true)
            {
                SqlClase.FiltrarDatos("BuscarPorMonto", "@monto", busquedaTxt, dgvEstudiantes);
                if (txtBusqueda.Text == "")
                {
                    listar();
                }

            }
        }

        private void radGroupBox1_Click(object sender, EventArgs e)
        {

        }

        private void radButton1_Click(object sender, EventArgs e)
        {
            Capas.FormAgregarYEditar oagregar = new Capas.FormAgregarYEditar();
            oagregar.MdiParent = this.MdiParent;
            oagregar.Global = "Nuevo";
            oagregar.ShowDialog();
            if (oagregar.DialogResult == DialogResult.OK)
            {
                listar();
            }
        }

        private void radMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void btnActualizarTabla_Click(object sender, EventArgs e)
        {           
            listar();
        }

        private void btnEliminarRegistros_Click(object sender, EventArgs e)
        {
            MessageBoxButtons mss = MessageBoxButtons.YesNo;
            DialogResult Resultado = MessageBox.Show("¿Estas Seguro De Eliminar El Registro Seleccionado?", "Aviso:", mss, MessageBoxIcon.Warning);

            if (Resultado == DialogResult.Yes)
            {

                string id = dgvEstudiantes.CurrentRow.Cells[0].Value.ToString();

                SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString);
                cn.Open();

                SqlCommand sc = new SqlCommand("eliminarEstudiantes", cn);
                sc.CommandType = CommandType.StoredProcedure;
                sc.Parameters.AddWithValue("@IdEstudiante", id);

                int r = sc.ExecuteNonQuery();
                if (r == 1)
                {
                    MessageBox.Show("Registro Eliminado Correctamente","Aviso:",MessageBoxButtons.OK,MessageBoxIcon.Asterisk);
                    listar();
                }
            }
            else return;
        }

        private void btnEditarRegistros_Click(object sender, EventArgs e)
        {

            Capas.FormAgregarYEditar oagregar = new Capas.FormAgregarYEditar();
            oagregar.MdiParent = this.MdiParent;
            oagregar.Global = "Editar";
            oagregar.Id = dgvEstudiantes.CurrentRow.Cells[0].Value.ToString();
            oagregar.BtnAgregar.Text = "Guardar Cambios";
            oagregar.ShowDialog();
        }

        private void dgvEstudiantes_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            Capas.FormAgregarYEditar oagregar = new Capas.FormAgregarYEditar();
            oagregar.MdiParent = this.MdiParent;
            oagregar.Global = "Editar";
            oagregar.Id = dgvEstudiantes.CurrentRow.Cells[0].Value.ToString();
            oagregar.BtnAgregar.Text = "Guardar Cambios";
            oagregar.ShowDialog();
        }

        private void btnpagosEmpleadosa_Click(object sender, EventArgs e)
        {
            Capas.FormPagosEmpleados oPagos = new Capas.FormPagosEmpleados();
            oPagos.MdiParent = this.MdiParent;
            oPagos.ShowDialog();
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblhora.Text = DateTime.Now.ToString("hh:mm");
            lblFecha.Text = DateTime.Now.ToLongDateString();
        }

        
        private async Task Abrifrm()
        {
            await Task.Run(() =>
            {
                Capas.frmImprimirListadoClientes list = new Capas.frmImprimirListadoClientes();
                list.Refresh();
                list.Show();          
            });
        }
        private  void BtnImprimirDatos_Click(object sender, EventArgs e)
        {

            Capas.frmReportes _reports = new Capas.frmReportes();
            _reports.ShowDialog();

            //panelEspere.Visible = true;
            //lblEspere.Visible = true;
            //await Abrifrm(); 
            //panelEspere.Visible = false;
            //lblEspere.Visible = false;
        }

        private void dgvEstudiantes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        

        private void radButton1_Click_1(object sender, EventArgs e)
        {

        }

        private void btnCobrar_Click_1(object sender, EventArgs e)
        {
            Capas.FormPagosDeEstudiantes pgo = new Capas.FormPagosDeEstudiantes();
            pgo.Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            frmImprimirListadoClientes p = new frmImprimirListadoClientes();
            p.Show();
        }

        private void btnAtrasos_Click(object sender, EventArgs e)
        {
            frmImprimirReporteAtrasos atra = new frmImprimirReporteAtrasos();
            atra.ShowDialog();
        }

        private void btnAdelantos_Click(object sender, EventArgs e)
        {
            frmImprimirReporteAdelanto ade = new frmImprimirReporteAdelanto();
            ade.ShowDialog();
        }

        private void btnRecibosAdelantos_Click(object sender, EventArgs e)
        {
            frmImprmirRecibo r = new frmImprmirRecibo();
            r.ShowDialog();
        }

        private void administradorDeUsuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAministrarDatosDeSeccion oFrm = new frmAministrarDatosDeSeccion();
            oFrm.Show();
        }

        private void cerrarSeccionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void cerrarSeccionToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            //   DialogResult k = MessageBox.Show("¿Estás seguro de querer cerrar seccion?", "Confirmación:", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            //    if (k == DialogResult.Yes)
            //    {
            //        FrmLogin f = new FrmLogin();
            //        f.ShowDialog();
            //    }
            //    else
            //        return;
        }

        private void cerrarProgramaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            Capas.FormAgregarYEditar oagregar = new Capas.FormAgregarYEditar();
            oagregar.MdiParent = this.MdiParent;
            oagregar.Global = "Nuevo";
            oagregar.ShowDialog();
            if (oagregar.DialogResult == DialogResult.OK)
            {
                listar();
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {

            MessageBoxButtons mss = MessageBoxButtons.YesNo;
            DialogResult Resultado = MessageBox.Show("¿Estas Seguro De Eliminar El Registro Seleccionado?", "Aviso:", mss, MessageBoxIcon.Warning);

            if (Resultado == DialogResult.Yes)
            {

                string id = dgvEstudiantes.CurrentRow.Cells[0].Value.ToString();

                SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString);
                cn.Open();

                SqlCommand sc = new SqlCommand("eliminarEstudiantes", cn);
                sc.CommandType = CommandType.StoredProcedure;
                sc.Parameters.AddWithValue("@IdEstudiante", id);

                int r = sc.ExecuteNonQuery();
                if (r == 1)
                {
                    MessageBox.Show("Registro Eliminado Correctamente", "Aviso:", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    listar();
                }
            }
            else return;
        }

        private void btnEditar_Click_1(object sender, EventArgs e)
        {

            Capas.FormAgregarYEditar oagregar = new Capas.FormAgregarYEditar();
            oagregar.MdiParent = this.MdiParent;
            oagregar.Global = "Editar";
            oagregar.Id = dgvEstudiantes.CurrentRow.Cells[0].Value.ToString();
            oagregar.BtnAgregar.Text = "Guardar Cambios";
            oagregar.ShowDialog();
        }

        private void btn_cobrar_Click(object sender, EventArgs e)
        {
            Capas.FormPagosDeEstudiantes pgo = new Capas.FormPagosDeEstudiantes();
            pgo.ShowDialog();
        }

        private void btn_Reportes_Click(object sender, EventArgs e)
        {

            frmSalidasDeReportes _reports = new frmSalidasDeReportes();
            _reports.ShowDialog();
        }

        private void btn_PagosEmpleados_Click(object sender, EventArgs e)
        {
            Capas.FormPagosEmpleados oPagos = new Capas.FormPagosEmpleados();
            oPagos.MdiParent = this.MdiParent;
            oPagos.ShowDialog();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            listar();
        }

       

        private void consultaToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
            MessageBox.Show("Para realizar cualquier consulta o duda sobre el programa escribe por favor al 809-606-3232. John Kerlin Silvestre.", "INFO:", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
