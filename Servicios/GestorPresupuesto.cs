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

		public bool ConfirmarPresupuesto(Presupuesto oPresupeusto)
		{
			return dao.Crear(oPresupeusto);
		}
	}
}
