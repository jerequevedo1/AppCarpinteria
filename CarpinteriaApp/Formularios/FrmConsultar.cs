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
using WinFormCarpinteria.Formularios;
using WinFormCarpinteria.Servicios;
using static WinFormCarpinteria.Formularios.FrmPresupuesto;

namespace WinFormCarpinteria.Formularios
{
	public partial class FrmConsultar : Form
	{
		private GestorPresupuesto gestor;
		public FrmConsultar()
		{
			InitializeComponent();
			gestor = new GestorPresupuesto(new DaoFactory());
		}

		private void FrmConsultar_Load(object sender, EventArgs e)
		{
			CargarTiposFiltros();
			CargarFiltroFecha();
			CargarPresupuestos();
			CargarPropiedadesGrilla();			
		}
		private void btnConsultar_Click(object sender, EventArgs e)
		{
			CargarPresupuestos();
		}
		private void btnEliminarFiltro_Click(object sender, EventArgs e)
		{
			dgvConsultar.Rows.Clear();
			txtFiltro.Text = string.Empty;
			cboFiltro.SelectedIndex = 0;
			cboFiltrarFecha.SelectedIndex = 4; 
			CargarPresupuestos();
		}
		private void btnCancelar_Click(object sender, EventArgs e)
		{
			Close();
		}
		private void dgvConsultar_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
			if (dgvConsultar.CurrentCell.ColumnIndex==6)
			{
				int nroPresupuesto = int.Parse(dgvConsultar.CurrentRow.Cells[0].Value.ToString());
				FrmPresupuesto ofrmPresupuesto = new FrmPresupuesto(Accion.Read, nroPresupuesto);
				ofrmPresupuesto.ShowDialog();
			}

		}
		private void dgvConsultar_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			int nroPresupuesto = int.Parse(dgvConsultar.CurrentRow.Cells["cNroPresup"].Value.ToString());
			FrmPresupuesto ofrmPresupuesto = new FrmPresupuesto(Accion.Read, nroPresupuesto);
			ofrmPresupuesto.ShowDialog();
		}
		private void btnNuevoP_Click(object sender, EventArgs e)
		{
			FrmPresupuesto ofrmPresupuesto = new FrmPresupuesto(Accion.Create,0);
			ofrmPresupuesto.ShowDialog();
			CargarPresupuestos();
		}
		private void btnEditar_Click(object sender, EventArgs e)
		{
			int nroPresupuesto = int.Parse(dgvConsultar.CurrentRow.Cells[0].Value.ToString());
			FrmPresupuesto ofrmPresupuesto = new FrmPresupuesto(Accion.Update, nroPresupuesto);
			ofrmPresupuesto.ShowDialog();
			CargarPresupuestos();
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
					CargarPresupuestos();
				}
				else
				{
					MessageBox.Show("ERROR. No se pudo borrar el presupuesto.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
		}
		private void CargarGrilla(List<Presupuesto> lst)
		{
			foreach (Presupuesto item in lst)
			{
				dgvConsultar.Rows.Add(new object[] { item.PresupuestoNro, item.Fecha.ToString("dd/MM/yyyy"), item.Cliente, item.Descuento + " %", "$ " + item.Total,item.GetFechaBajaFormato() });
			}
		}
		private void dgvConsultar_SelectionChanged(object sender, EventArgs e)
		{
			if (dgvConsultar.CurrentRow.Cells["cFechaBaja"].Value.ToString() != "")
			{
				btnEditar.Enabled = false;
				btnBorrar.Enabled = false;
			}
			else
			{
				btnEditar.Enabled = true;
				btnBorrar.Enabled = true;
			}
		}
		private void cboFiltrarFecha_SelectedIndexChanged(object sender, EventArgs e)
		{
			switch (cboFiltrarFecha.SelectedIndex)
			{
				case 0:
					dtpFechaDesde.Value = DateTime.Today;
					break;
				case 1:
					dtpFechaDesde.Value = DateTime.Today.AddDays(-1);
					break;
				case 2:
					dtpFechaDesde.Value = DateTime.Today.AddDays(-7);
					break;
				case 3:
					dtpFechaDesde.Value = DateTime.Today.AddDays(-14);
					break;
				case 4:
					dtpFechaDesde.Value = DateTime.Today.AddDays(-28);
					break;
			}
		}
		private void CargarTiposFiltros()
		{
			string[] tiposFiltros = new string[] { "Numero Presupuesto", "Cliente", "Inactivos" };
			cboFiltro.Items.Clear();
			cboFiltro.Items.AddRange(tiposFiltros);
			cboFiltro.SelectedIndex = 0;
		}
		private void CargarFiltroFecha()
		{
			string[] filtrosFecha = new string[] { "Hoy", "Ayer", "Ultimos 7 dias", "Ultimos 14 dias", "Ultimos 28 dias" };
			cboFiltrarFecha.Items.Clear();
			cboFiltrarFecha.Items.AddRange(filtrosFecha);
			cboFiltrarFecha.SelectedIndex = 4;
		}
		private void CargarPresupuestos()
		{
			List<Parametro> filtros = new List<Parametro>();
			filtros.Add(new Parametro("@fechaDesde", dtpFechaDesde.Value));
			filtros.Add(new Parametro("@fechaHasta", dtpFechaHasta.Value));

			object filtroTexto = DBNull.Value;
			if (!String.IsNullOrEmpty(txtFiltro.Text))
				filtroTexto = txtFiltro.Text;
			if (cboFiltro.SelectedIndex == 0)
			{
				filtros.Add(new Parametro("@nro_presup", filtroTexto));
			}
			else
			{
				filtros.Add(new Parametro("@cliente", filtroTexto));
			}

			string conInactivos = "N";
			if (chkBajas.Checked)
				conInactivos = "S";
			filtros.Add(new Parametro("@activo", conInactivos));

			filtros.Add(new Parametro("@tipo", cboFiltro.SelectedIndex));

			List<Presupuesto> lst = gestor.CargarPresupuestos(filtros);

			dgvConsultar.Rows.Clear();
			CargarGrilla(lst);
		}
		private void CargarPropiedadesGrilla()
		{
			dgvConsultar.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
			dgvConsultar.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
			dgvConsultar.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
			dgvConsultar.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
			dgvConsultar.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
		}
	}
}
