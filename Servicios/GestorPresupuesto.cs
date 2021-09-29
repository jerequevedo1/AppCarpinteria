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
		public List<Producto> ObtenerProductos()
		{
			return dao.ConsultarProductos();
		}

		public DataTable ListarPresupuestos()
		{
			return daoL.ConsultarPresupuestos();
		}
		public Presupuesto CargarPresupuesto(int nroPresupuesto)
		{
			return daoL.ConsultarUnPresupuesto(nroPresupuesto);
		}
		public DataTable FiltrarNroPresupuesto(int nroPresupuesto)
		{
			return daoL.ConsultarPresupuestoNroPresupuesto(nroPresupuesto);
		}
		public DataTable FiltrarFecha(DateTime fechaDesde, DateTime fechaHasta)
		{
			return daoL.ConsultarPresupuestoFecha(fechaDesde,fechaHasta);
		}
		public DataTable FiltrarCliente(string cliente)
		{
			return daoL.ConsultarPresupuestoCliente(cliente);
		}
	}
}
