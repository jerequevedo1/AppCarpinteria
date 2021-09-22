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
using WinFormCarpinteria.AccesoDatos;
using WinFormCarpinteria.Entidades;
using WinFormCarpinteria.Formularios;
using WinFormCarpinteria.Servicios;
using static WinFormCarpinteria.Formularios.FrmPresupuesto;

namespace WinFormCarpinteria.Formularios
{
	public partial class FrmConsultar : Form
	{
		private GestorPresupuesto gestor;
		private ListadoPresupuestos presupuestos;
		public FrmConsultar()
		{
			InitializeComponent();
			gestor = new GestorPresupuesto(new DaoFactory());
			presupuestos = new ListadoPresupuestos();
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
			string[] tiposFiltros = new string[] { "Numero Presupuesto", "Fecha", "Cliente" };
			cboFiltro.Items.Clear();
			cboFiltro.Items.AddRange(tiposFiltros);
			cboFiltro.SelectedIndex=0;
		}
		private void ConsultarPresupuestos()
		{
			DataTable tabla = new DataTable();
			tabla = gestor.ListarPresupuestos();

			DataTableReader lector=tabla.CreateDataReader();
			dgvConsultar.Rows.Clear();
			while (lector.Read())
			{
				Presupuesto p = new Presupuesto();
				p.PresupuestoNro = lector.GetInt32(0);
				p.Fecha = Convert.ToDateTime(lector.GetString(1));
				if (!lector.IsDBNull(2)) p.Cliente = lector.GetString(2);
				if (!lector.IsDBNull(3)) p.Descuento = Convert.ToDouble(lector.GetValue(3));
				p.Total = Convert.ToDouble(lector.GetValue(5));

				presupuestos.Agregar(p);
				dgvConsultar.Rows.Add(new object[] { p.PresupuestoNro,p.Fecha.ToString("dd/MM/yyyy"),p.Cliente,p.Total });
			}
			//dgvConsultar.Rows.Clear();
			//for (int i = 0; i < tabla.Rows.Count; i++)
			//{
			//	dgvConsultar.Rows.Add(tabla.Rows[i]["presupuesto_nro"], tabla.Rows[i][1], tabla.Rows[i][2], tabla.Rows[i][5]);
			//}
		}
		private void btnFiltrar_Click(object sender, EventArgs e)
		{
			DataTable tabla = new DataTable();
			SqlConnection cnn = new SqlConnection();
			SqlCommand cmd = new SqlCommand();

			//validar antes que el campo filtro tenga datos
			if (txtFiltro.Text.Equals(string.Empty) && cboFiltro.SelectedIndex != 1)
			{
				dgvConsultar.Rows.Clear();
				ConsultarPresupuestos();
				return;
			}

			switch (cboFiltro.SelectedIndex)
			{
				case 0:
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
			Close();
		}

		private void dgvConsultar_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
			int nroPresupuesto = int.Parse(dgvConsultar.CurrentRow.Cells[0].Value.ToString());

			if (dgvConsultar.CurrentCell.ColumnIndex==4)
			{
				FrmPresupuesto ofrmPresupuesto= new FrmPresupuesto();
				ofrmPresupuesto.HabilitarEdicion(EdicionPresupuesto.EdicionActiva);
				ofrmPresupuesto.CargarEdicionPresupuesto(nroPresupuesto);
				ofrmPresupuesto.ShowDialog();

				ConsultarPresupuestos();
			}
			if (dgvConsultar.CurrentCell.ColumnIndex == 5)
			{
				DialogResult dialogResult = MessageBox.Show("Desea borrar este presupuesto?", "Borrar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
				if (dialogResult==DialogResult.Yes)
				{
					if (gestor.BorrarPresupuesto(nroPresupuesto))
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

		private void btnNuevoP_Click(object sender, EventArgs e)
		{
			FrmPresupuesto ofrmPresupuesto = new FrmPresupuesto();
			ofrmPresupuesto.ShowDialog();
		}
		private void dgvConsultar_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			int nroPresupuesto = int.Parse(dgvConsultar.CurrentRow.Cells[0].Value.ToString());
			FrmPresupuesto ofrmPresupuesto = new FrmPresupuesto();
			ofrmPresupuesto.HabilitarEdicion(EdicionPresupuesto.EdicionActiva);
			ofrmPresupuesto.CargarEdicionPresupuesto(nroPresupuesto);
			ofrmPresupuesto.HabilitarConsulta(ModoConsulta.ConsultaActiva);
			ofrmPresupuesto.ShowDialog();
		}
	}
}
