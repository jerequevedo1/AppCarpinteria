using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormCarpinteria.AccesoDatos;

namespace WinFormCarpinteria.Servicios
{
	class GestorPresupuesto
	{
		private IPresupuestoDao dao;
		private IListadoPresupuestos daoL;

		public GestorPresupuesto(AbstractDaoFactory factory)
		{
			dao = factory.CrearPresupuestoDao();
			daoL = factory.CrearListadoPresupuestosDao();
		}
		public bool NuevoPresupuesto(Presupuesto oPresupuesto)
		{
			return dao.InsertarPresupuesto(oPresupuesto);
		}
		public bool EditarPresupuesto(Presupuesto oPresupuesto)
		{
			return dao.EditarPresupuesto(oPresupuesto);
		}
		public bool BorrarPresupuesto(int nroPresupuesto)
		{
			return dao.BorrarPresupuesto(nroPresupuesto);
		}
		public int ProximoPresupuesto()
		{
			return dao.ObtenerProximoNumero();
		}
		public DataTable ObtenerProductos()
		{
			DataTable tabla = new DataTable();
			tabla = dao.ListarProductos();

			return tabla;
		}

		public DataTable ListarPresupuestos()
		{
			return daoL.ConsultarPresupuestos();
		}
		public DataTable CargarEditarPresupuesto(int nroPresupuesto)
		{
			return daoL.ConsultarPresupuestoEditar(nroPresupuesto);
		}
		public DataTable CargarDetallesEditarPresupuesto(int nroPresupuesto)
		{
			return daoL.ConsultarDetallesPresupuestoEditar(nroPresupuesto);
		}
		public DataTable FiltrarNroPresupuesto(int nroPresupuesto)
		{
			return daoL.FiltrarNroPresupuesto(nroPresupuesto);
		}
		public DataTable FiltrarFecha(DateTime fechaDesde, DateTime fechaHasta)
		{
			return daoL.FiltrarFecha(fechaDesde,fechaHasta);
		}
		public DataTable FiltrarCliente(string cliente)
		{
			return daoL.FiltrarCliente(cliente);
		}
	}
}
