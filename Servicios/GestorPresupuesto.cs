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

		public bool NuevoPresupuesto(Presupuesto oPresupuesto)
		{
			return dao.InsertarPresupuesto(oPresupuesto);
		}

		public bool BorrarPresupuesto(int nroPresupuesto)
		{
			return dao.BorrarPresupuesto(nroPresupuesto);
		}
		public DataTable CargarPresupuestoEdicion(int nroPresupuesto)
		{
			return daoL.CargarPresupuestoEdicion(nroPresupuesto);
		}
		public DataTable CargarDetallesPresupuestoEdicion(int nroPresupuesto)
		{
			return daoL.CargarDetallesPresupuestoEdicion(nroPresupuesto);
		}
		public bool EditarPresupuesto(Presupuesto oPresupuesto)
		{
			return dao.EditarPresupuesto(oPresupuesto);
		}

		public DataTable ListarPresupuestos()
		{
			return daoL.ListarPresupuestos();
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
