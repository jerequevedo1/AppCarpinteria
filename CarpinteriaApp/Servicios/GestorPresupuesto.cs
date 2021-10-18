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

		public GestorPresupuesto(AbstractDaoFactory factory)
		{
			dao = factory.CrearPresupuestoDao();
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
		public List<Presupuesto> CargarPresupuestos(List<Parametro> parametros)
		{
			return dao.ConsultarPresupuestos(parametros);
		}
		public Presupuesto CargarPresupuestoPorNro(int nroPresupuesto)
		{
			return dao.ConsultarUnPresupuesto(nroPresupuesto);
		}
	}

}
