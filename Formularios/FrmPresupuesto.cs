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
				Text = "Presupuesto";
				HabilitarConsulta();
				CargarPresupuesto(nro);
			}
			if (modo.Equals(Accion.Update))
			{
				Text = "Editar Presupuesto";
				CargarPresupuesto(nro);
			}
			CargarPropiedadesGrilla();
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
			CargarProductos();
			txtCantidad.Text = "1";
			if (modo.Equals(Accion.Create))
			{
				lblNroPresupuesto.Text += gestor.ProximoPresupuesto();
				txtFecha.Text = DateTime.Today.ToString("dd/MM/yyyy");
				txtCliente.Text = "Consumidor Final";
				txtDescuento.Text = "0";
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

			Producto oProducto = (Producto)cboProducto.SelectedItem;
			DetallePresupuesto detalle = new DetallePresupuesto();

			detalle.Producto = oProducto;
			detalle.Cantidad = Convert.ToInt32(txtCantidad.Text);			

			oPresupuesto.AgregarDetalle(detalle);
			dgvDetalles.Rows.Add(new object[] { oProducto.IdProducto, oProducto.NProducto,"$ "+ oProducto.Precio, detalle.Cantidad, "$ " + detalle.CalcularSubtotal() });

			CalcularTotales();
		}
		private void dgvDetalles_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
			if (dgvDetalles.CurrentCell.ColumnIndex == 5)
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
			List<Producto> lst = gestor.ObtenerProductos();
			cboProducto.DataSource = lst;
			cboProducto.ValueMember = "IdProducto";
			cboProducto.DisplayMember = "NProducto";
		}
		private void CalcularTotales()
		{
			txtSubtotal.Text = oPresupuesto.CalcularTotal().ToString();
			double desc = oPresupuesto.CalcularTotal() * Convert.ToDouble(txtDescuento.Text) / 100;
			txtTotalDescuento.Text = desc.ToString();
			txtTotal.Text = (oPresupuesto.CalcularTotal() - desc).ToString();
		}
		private void CargarPresupuesto(int nroPresupuesto)
		{
			oPresupuesto = gestor.CargarPresupuestoPorNro(nroPresupuesto);
			lblNroPresupuesto.Text += oPresupuesto.PresupuestoNro.ToString();
			txtFecha.Text = oPresupuesto.Fecha.ToString("dd/MM/yyyy");
			txtCliente.Text = oPresupuesto.Cliente;
			txtDescuento.Text = oPresupuesto.Descuento.ToString();

			dgvDetalles.Rows.Clear();

			foreach (DetallePresupuesto oDetalle in oPresupuesto.Detalles)
			{
				dgvDetalles.Rows.Add(new object[] { oDetalle.Producto.IdProducto,oDetalle.Producto.NProducto, "$ " + oDetalle.Producto.Precio, oDetalle.Cantidad, "$ " + oDetalle.CalcularSubtotal()}); ;
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
		private void CargarPropiedadesGrilla()
		{
			dgvDetalles.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
			dgvDetalles.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
			dgvDetalles.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
			dgvDetalles.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
		}
	}
}
