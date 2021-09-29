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
using WinFormCarpinteria.Servicios;

namespace WinFormCarpinteria.Formularios
{
	public partial class FrmPresupuesto : Form
	{
		private Presupuesto oPresupuesto;
		private GestorPresupuesto gestor;

		private Accion modo;

		public FrmPresupuesto(Accion modo,int nro)
		{
			InitializeComponent();
			oPresupuesto = new Presupuesto();
			gestor = new GestorPresupuesto(new DaoFactory());
			this.modo = modo;

			if (modo.Equals(Accion.Read))
			{
				HabilitarConsulta();
				CargarPresupuesto(nro);
			}
			if (modo.Equals(Accion.Update))
			{
				Text = "Editar Presupuesto";
				CargarPresupuesto(nro);
			}
		}

		public enum Accion
		{
			Create,
			Read,
			Update,
			Delete
		}

		private void FrmNuevoPresupuesto_Load(object sender, EventArgs e)
		{
			if (modo.Equals(Accion.Create))
			{
				lblNroPresupuesto.Text += gestor.ProximoPresupuesto();
				txtFecha.Text = DateTime.Today.ToString("dd/MM/yyyy");
				txtCliente.Text = "Consumidor Final";
				txtDescuento.Text = "0";
				txtCantidad.Text = "1";
				CargarProductos();
			}
		}		
		private void btnAgregar_Click(object sender, EventArgs e)
		{
			if (cboProducto.Text.Equals(string.Empty))
			{
				MessageBox.Show("Debe seleccionar un producto", "Control", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return;
			}
			if (string.IsNullOrEmpty(txtCantidad.Text) || !int.TryParse(txtCantidad.Text,out _))
			{
				MessageBox.Show("Debe ingresar una cantidad valida", "Control", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return;
			}
			foreach (DataGridViewRow row in dgvDetalles.Rows)
			{
				if (row.Cells["ColProd"].Value.ToString().Equals(cboProducto.Text))
				{
					MessageBox.Show("Este producto ya se encuentra presupuestado", "Control", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					return;
				}
			}

			DataRowView item = (DataRowView)cboProducto.SelectedItem;

			int prod = Convert.ToInt32(item.Row.ItemArray[0]);
			string nom = item.Row.ItemArray[1].ToString();
			double pre = Convert.ToDouble(item.Row.ItemArray[2]);
			int cant = Convert.ToInt32(txtCantidad.Text);

			Producto p = new Producto(prod, nom, pre);
			DetallePresupuesto detalle = new DetallePresupuesto(p, cant);

			oPresupuesto.AgregarDetalle(detalle);
			dgvDetalles.Rows.Add(new object[] { prod, nom, pre, cant });

			CalcularTotales();
		}
		private void dgvDetalles_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
			if (dgvDetalles.CurrentCell.ColumnIndex == 4)
			{
				oPresupuesto.QuitarDetalle(dgvDetalles.CurrentRow.Index);
				dgvDetalles.Rows.Remove(dgvDetalles.CurrentRow);
				CalcularTotales();
			}
		}
		private void btnCancelar_Click(object sender, EventArgs e)
		{
			Close();
		}
		private void btnAceptar_Click(object sender, EventArgs e)
		{
			if (txtCliente.Text=="")
			{
				MessageBox.Show("Debe especificar un cliente.", "Control", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				txtCliente.Focus();
				return;
			}
			if (dgvDetalles.Rows.Count==0)
			{
				MessageBox.Show("Debe ingresar al menos un detalle.", "Control", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				cboProducto.Focus();
				return;
			}

			CalcularTotales();
			GuardarPresupuesto();
		}

		private void GuardarPresupuesto()
		{
			oPresupuesto.Fecha = Convert.ToDateTime(txtFecha.Text);
			oPresupuesto.Cliente = txtCliente.Text;
			oPresupuesto.Descuento = double.Parse(txtDescuento.Text);
			oPresupuesto.Total = Convert.ToDouble(txtTotal.Text);

			if (modo.Equals(Accion.Create))
			{
				if (gestor.NuevoPresupuesto(oPresupuesto))
				{
					MessageBox.Show("Presupuesto registrado con exito.", "Informe", MessageBoxButtons.OK, MessageBoxIcon.Information);
					Close();
				}
				else
				{
					MessageBox.Show("ERROR. No se pudo registrar el presupuesto.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
			else
			{
				if (gestor.EditarPresupuesto(oPresupuesto))
				{
					MessageBox.Show("Presupuesto editado con exito.", "Informe", MessageBoxButtons.OK, MessageBoxIcon.Information);
					Close();
				}
				else
				{
					MessageBox.Show("ERROR. No se pudo editar el presupuesto.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}

			
		}
		private void CargarProductos()
		{
			DataTable tabla = gestor.ObtenerProductos();

			if (tabla != null)
			{
				cboProducto.DataSource = tabla;
				cboProducto.ValueMember = tabla.Columns[0].ColumnName;
				cboProducto.DisplayMember = tabla.Columns[1].ColumnName;
			}

		}
		private void CalcularTotales()
		{
			txtSubtotal.Text = oPresupuesto.CalcularTotal().ToString();
			double desc = oPresupuesto.CalcularTotal() * Convert.ToDouble(txtDescuento.Text) / 100;
			txtTotal.Text = (oPresupuesto.CalcularTotal() - desc).ToString();
		}
		private void CargarPresupuesto(int nroPresupuesto)
		{
			CargarProductos();
			lblNroPresupuesto.Text += nroPresupuesto;
			oPresupuesto = gestor.CargarPresupuesto(nroPresupuesto);

			txtFecha.Text = oPresupuesto.Fecha.ToString();
			txtCliente.Text = oPresupuesto.Cliente;
			txtDescuento.Text = oPresupuesto.Descuento.ToString();
			txtCantidad.Text = "1";

			dgvDetalles.Rows.Clear();

			foreach (DetallePresupuesto oDetalle in oPresupuesto.Detalles)
			{
				dgvDetalles.Rows.Add(new object[] { oDetalle.Producto.NProducto, oDetalle.Producto.Precio, oDetalle.Cantidad, oDetalle.CalcularSubtotal()}); ;
			}

			CalcularTotales();
		}
		private void HabilitarConsulta()
		{
				btnAceptar.Hide();
				txtCliente.Enabled = false;
				txtDescuento.Enabled = false;
				cboProducto.Enabled = false;
				txtCantidad.Enabled = false;
				btnAgregar.Enabled = false;
				dgvDetalles.Enabled = false;
		}
	}
}
