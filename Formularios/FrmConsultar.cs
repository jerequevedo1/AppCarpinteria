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
using WinFormCarpinteria.Formularios;
using static WinFormCarpinteria.Formularios.FrmNuevoPresupuesto;

namespace WinFormCarpinteria.Formularios
{
	public partial class FrmConsultar : Form
	{
		public FrmConsultar()
		{
			InitializeComponent();
		}

		private void FrmConsultar_Load(object sender, EventArgs e)
		{
			ConsultarPresupuestos();
			CargarTiposFiltros();
			dtpFechaDesde.Enabled = false;
			dtpFechaHasta.Enabled = false;
		}

		private void CargarTiposFiltros()
		{
			//DataTable tabla = new DataTable();
			//tabla = ConsultaDatos("SP_TIPOS_FILTROS");

			//cboFiltro.DataSource = tabla;
			//cboFiltro.ValueMember = "posicion";
			//cboFiltro.DisplayMember = "columna";
			string[] tiposFiltros = new string[] { "Numero Presupuesto", "Fecha", "Cliente" };
			cboFiltro.Items.Clear();
			cboFiltro.Items.AddRange(tiposFiltros);
			cboFiltro.SelectedIndex=0;

		}

		private void ConsultarPresupuestos()
		{
			DataTable tabla = new DataTable();
			tabla =ConsultaDatos("SP_CONSULTAR_PRESUPUESTOS");

			dgvConsultar.Rows.Clear();
			for (int i = 0; i < tabla.Rows.Count; i++)
			{
				dgvConsultar.Rows.Add(tabla.Rows[i]["presupuesto_nro"], tabla.Rows[i][1], tabla.Rows[i][2], tabla.Rows[i][5]);
			}
		}

		private DataTable ConsultaDatos(string sp)
		{
			SqlConnection cnn = new SqlConnection();
			cnn.ConnectionString = @"Data Source=NOTEBOOK-JERE\SQLEXPRESS;Initial Catalog=carpinteria_db;Integrated Security=True";
			cnn.Open();
			SqlCommand cmd = new SqlCommand();
			cmd.Connection = cnn;
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = sp;
			DataTable tabla = new DataTable();
			tabla.Load(cmd.ExecuteReader());
			cnn.Close();

			return tabla;
		}

		private void btnFiltrar_Click(object sender, EventArgs e)
		{
			DataTable tabla = new DataTable();
			SqlConnection cnn = new SqlConnection();
			SqlCommand cmd = new SqlCommand();

			switch (cboFiltro.SelectedIndex)
			{
				case 0:
					//validar antes que el campo filtro tenga datos
					if (txtFiltro.Text.Equals(string.Empty))
					{
						dgvConsultar.Rows.Clear();
						ConsultarPresupuestos();
						return;
					}
					cnn.ConnectionString = @"Data Source=NOTEBOOK-JERE\SQLEXPRESS;Initial Catalog=carpinteria_db;Integrated Security=True";
					cnn.Open();
					cmd.Connection = cnn;
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.CommandText = "SP_FILTRO_NROPRESUP";
					cmd.Parameters.AddWithValue("@nro_presup", int.Parse(txtFiltro.Text));
					tabla.Load(cmd.ExecuteReader());
					cnn.Close();
					break;
				case 1:
					cnn.ConnectionString = @"Data Source=NOTEBOOK-JERE\SQLEXPRESS;Initial Catalog=carpinteria_db;Integrated Security=True";
					cnn.Open();
					cmd.Connection = cnn;
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.CommandText = "SP_FILTRO_FECHA";
					cmd.Parameters.AddWithValue("@fechaDesde", dtpFechaDesde.Value);
					cmd.Parameters.AddWithValue("@fechaHasta", dtpFechaHasta.Value);
					tabla.Load(cmd.ExecuteReader());
					cnn.Close();
					break;
				case 2:
					if (txtFiltro.Text.Equals(string.Empty))
					{
						dgvConsultar.Rows.Clear();
						ConsultarPresupuestos();
						return;
					}
					cnn.ConnectionString = @"Data Source=NOTEBOOK-JERE\SQLEXPRESS;Initial Catalog=carpinteria_db;Integrated Security=True";
					cnn.Open();
					cmd.Connection = cnn;
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.CommandText = "SP_FILTRO_CLIENTE";
					cmd.Parameters.AddWithValue("@cliente", txtFiltro.Text);
					tabla.Load(cmd.ExecuteReader());
					cnn.Close();
					break;
			}

			dgvConsultar.Rows.Clear();
			for (int i = 0; i < tabla.Rows.Count; i++)
			{
				dgvConsultar.Rows.Add(tabla.Rows[i]["presupuesto_nro"], tabla.Rows[i][1], tabla.Rows[i][2], tabla.Rows[i][5]);
			}
		}

		private void cboFiltro_SelectedIndexChanged(object sender, EventArgs e)
		{
			txtFiltro.Text = string.Empty;
			if (cboFiltro.SelectedIndex==1)
			{
				dtpFechaDesde.Enabled = true;
				dtpFechaHasta.Enabled = true;
				txtFiltro.Enabled = false;
				//txtFiltro.Hide();
			}
			else
			{
				dtpFechaDesde.Enabled = false;
				dtpFechaHasta.Enabled = false;
				txtFiltro.Enabled = true;
			}
		}

		private void btnEliminarFiltro_Click(object sender, EventArgs e)
		{
			dgvConsultar.Rows.Clear();
			ConsultarPresupuestos();
			txtFiltro.Text = string.Empty;
			cboFiltro.SelectedIndex = 0;
		}

		private void btnCancelar_Click(object sender, EventArgs e)
		{
			Dispose();
		}

		private void dgvConsultar_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
			if (dgvConsultar.CurrentCell.ColumnIndex==4)
			{
				int nroPresupuesto = int.Parse(dgvConsultar.CurrentRow.Cells[0].Value.ToString());
				//boton editar abre otro form
				FrmNuevoPresupuesto ofrmPresupuesto= new FrmNuevoPresupuesto();
				ofrmPresupuesto.HabilitarEdicion(EdicionPresupuesto.EdicionActiva);
				ofrmPresupuesto.CargarEdicionPresupuesto(nroPresupuesto);
				ofrmPresupuesto.ShowDialog();

				//como hago para setear el form?
			}
			if (dgvConsultar.CurrentCell.ColumnIndex == 5)
			{
				Presupuesto p = new Presupuesto();
				int nroPresupuesto =int.Parse( dgvConsultar.CurrentRow.Cells[0].Value.ToString());

				DialogResult dialogResult = MessageBox.Show("Desea borrar este presupuesto?", "Borrar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
				if (dialogResult==DialogResult.Yes)
				{
					if (p.Borrar(nroPresupuesto))
					{
						MessageBox.Show("Presupuesto borrado con exito.", "Informe", MessageBoxButtons.OK, MessageBoxIcon.Information);
						dgvConsultar.Rows.Clear();
						ConsultarPresupuestos();
					}
					else
					{
						MessageBox.Show("ERROR. No se pudo borrar el presupuesto.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					}

				}
				
			}

		}
	}
}
