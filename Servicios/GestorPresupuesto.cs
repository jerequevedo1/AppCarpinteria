﻿using System;
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
			return dao.CargarPresupuestoEdicion(nroPresupuesto);
		}
		public DataTable CargarDetallesPresupuestoEdicion(int nroPresupuesto)
		{
			return dao.CargarDetallesPresupuestoEdicion(nroPresupuesto);
		}
		public bool EditarPresupuesto(Presupuesto oPresupuesto)
		{
			return dao.EditarPresupuesto(oPresupuesto);
		}

		public DataTable ListarPresupuestos()
		{
			return dao.ListarPresupuestos();
		}
	}
}
