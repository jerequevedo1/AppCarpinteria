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
		private void btnFiltrar_Click(object sender, EventArgs e)
		{
			int nroPresup=0;
			string cliente=string.Empty;
			DateTime fechaDesde=DateTime.Today;
			DateTime fechaHasta=DateTime.Today;

			if (txtFiltro.Text.Equals(string.Empty))
			{

				if (cboFiltro.SelectedIndex != 0 && cboFiltro.SelectedIndex != 4)
				{
					MessageBox.Show("Debe ingresar parametros", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
					return;
				}
			}
			else
			{
				nroPresup = int.Parse(txtFiltro.Text);
				cliente = txtFiltro.Text;
				fechaDesde = dtpFechaDesde.Value;
				fechaHasta = dtpFechaHasta.Value;
			}

			List<Presupuesto> lst = new List<Presupuesto>();

			switch (cboFiltro.SelectedIndex)
			{
				case 0:
					lst = gestor.CargarPresupuestos();
					break;
				case 1:
					lst = gestor.FiltrarNroPresupuesto(nroPresup);
					break;
				case 2:
					lst = gestor.FiltrarFecha(fechaDesde,fechaHasta);
					break;
				case 3:
					lst = gestor.FiltrarCliente(cliente);
					break;
				case 4:
					lst = gestor.FiltrarInactivos();
					break;
			}

			dgvConsultar.Rows.Clear();
			foreach (Presupuesto item in lst)
			{
				dgvConsultar.Rows.Add(new object[] { item.PresupuestoNro, item.Fecha.ToString("dd/MM/yyyy"), item.Cliente, item.Total });
			}
		}
		private void cboFiltro_SelectedIndexChanged(object sender, EventArgs e)
		{
			txtFiltro.Text = string.Empty;
			if (cboFiltro.SelectedIndex==2)
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
			if (cboFiltro.SelectedIndex == 4 || cboFiltro.SelectedIndex == 0)
			{
				dtpFechaDesde.Enabled = false;
				dtpFechaHasta.Enabled = false;
				txtFiltro.Enabled = false;
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

			if (dgvConsultar.CurrentCell.ColumnIndex==5)
			{
				dgvConsultar_CellDoubleClick(null, null);
			}

		}
		private void btnNuevoP_Click(object sender, EventArgs e)
		{
			FrmPresupuesto ofrmPresupuesto = new FrmPresupuesto(Accion.Create,0);
			ofrmPresupuesto.ShowDialog();
			ConsultarPresupuestos();
		}
		private void dgvConsultar_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			int nroPresupuesto = int.Parse(dgvConsultar.CurrentRow.Cells["cNroPresup"].Value.ToString());
			FrmPresupuesto ofrmPresupuesto = new FrmPresupuesto(Accion.Read,nroPresupuesto);
			ofrmPresupuesto.ShowDialog();
		}

		private void CargarTiposFiltros()
		{
			string[] tiposFiltros = new string[] { "Todo","Numero Presupuesto", "Fecha", "Cliente","Inactivos" };
			cboFiltro.Items.Clear();
			cboFiltro.Items.AddRange(tiposFiltros);
			cboFiltro.SelectedIndex = 0;
		}
		private void ConsultarPresupuestos()
		{
			List<Presupuesto> lst = new List<Presupuesto>();
			lst = gestor.CargarPresupuestos();
			dgvConsultar.Rows.Clear();
			foreach (Presupuesto item in lst)
			{
				dgvConsultar.Rows.Add(new object[] { item.PresupuestoNro, item.Fecha.ToString("dd/MM/yyyy"), item.Cliente,item.Descuento+" %", "$ "+item.Total });
			}
		}

		private void btnEditar_Click(object sender, EventArgs e)
		{
			int nroPresupuesto = int.Parse(dgvConsultar.CurrentRow.Cells[0].Value.ToString());
			FrmPresupuesto ofrmPresupuesto = new FrmPresupuesto(Accion.Update, nroPresupuesto);
			ofrmPresupuesto.ShowDialog();

			ConsultarPresupuestos();
		}

		private void btnBorrar_Click(object sender, EventArgs e)
		{
			int nroPresupuesto = int.Parse(dgvConsultar.CurrentRow.Cells[0].Value.ToString());
			DialogResult dialogResult = MessageBox.Show("Desea borrar este presupuesto?", "Borrar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
			if (dialogResult == DialogResult.Yes)
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
}
