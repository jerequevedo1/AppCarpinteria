using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormCarpinteria.Servicios;
using static WinFormCarpinteria.Formularios.FrmPresupuesto;

namespace WinFormCarpinteria.AccesoDatos
{
	class PresupuestoDao : IPresupuestoDao
	{
		//prueba
		//codigo
		public bool InsertarPresupuesto(Presupuesto oPresupuesto)
		{
			bool resultado = true;
			int filasAfectadas = 0;

			filasAfectadas = HelperDao.ObtenerInstancia().EjecutarSQLMaestroDetalle("SP_INSERTAR_MAESTRO", "SP_INSERTAR_DETALLE", oPresupuesto, Accion.Create);

			if (filasAfectadas == 0) resultado = false;

			return resultado;
		}
		
		public bool EditarPresupuesto(Presupuesto oPresupuesto)
		{
			bool resultado = true;
			int filasAfectadas = 0;

			filasAfectadas = HelperDao.ObtenerInstancia().EjecutarSQLMaestroDetalle("SP_EDITAR_PRESUPUESTO", "SP_INSERTAR_DETALLE", oPresupuesto,Accion.Update);
			
			if (filasAfectadas == 0) resultado = false;

			return resultado;
		}
		public bool BorrarPresupuesto(int nroPresupuesto)
		{
			List<Parametro> parametros = new List<Parametro>();
			parametros.Add(new Parametro("@nroPresupuesto", nroPresupuesto));

			bool resultado = true;
			int filasAfectadas = 0;

			filasAfectadas = HelperDao.ObtenerInstancia().EjecutarSQLParametrosEntrada("SP_BAJA_PRESUPUESTO", parametros);

			if (filasAfectadas == 0) resultado = false;

			return resultado;
		}
		public int ObtenerProximoNumero()
		{
			return HelperDao.ObtenerInstancia().ProximoID("SP_PROXIMO_ID", "@next");
		}
		public List<Producto> ConsultarProductos()
		{
			List<Producto> lst = new List<Producto>();
			DataTable tabla = HelperDao.ObtenerInstancia().ConsultaSQL("SP_CONSULTAR_PRODUCTOS");
			foreach (DataRow row in tabla.Rows)
			{
				Producto oProducto = new Producto();
				oProducto.IdProducto = Convert.ToInt32(row["id_producto"].ToString());
				oProducto.NProducto = row["n_producto"].ToString();
				oProducto.Precio = Convert.ToDouble(row["precio"].ToString());
				oProducto.Activo = row["activo"].ToString().Equals("S");

				lst.Add(oProducto);
			}
			return lst;
		}
		public List<Presupuesto> ConsultarPresupuestos(List<Parametro> parametros)
		{
			List<Presupuesto> lst = new List<Presupuesto>();
			DataTable tabla = new DataTable();
			try
			{
				tabla = HelperDao.ObtenerInstancia().ConsultaSQLParametrosEntrada("SP_FILTRO_PRESUPUESTOS", parametros);

				foreach (DataRow row in tabla.Rows)
				{
					Presupuesto oPresupuesto = new Presupuesto();
					oPresupuesto.Cliente = row["cliente"].ToString();
					oPresupuesto.Fecha = Convert.ToDateTime(row["fecha"].ToString());
					oPresupuesto.Descuento = Convert.ToDouble(row["descuento"].ToString());
					oPresupuesto.PresupuestoNro = Convert.ToInt32(row["presupuesto_nro"].ToString());
					oPresupuesto.Total = Convert.ToDouble(row["total"].ToString());

					if (!row["fecha_baja"].Equals(DBNull.Value))
						oPresupuesto.FechaBaja = Convert.ToDateTime(row["fecha_baja"].ToString());

					lst.Add(oPresupuesto);
				}
			}
			catch (SqlException)
			{
				lst = null;
			}
			return lst;
		}
		public Presupuesto ConsultarUnPresupuesto(int nroPresupuesto)
		{
			Presupuesto oPresupuesto = new Presupuesto();
			DataTable tabla = new DataTable();
			List<Parametro> parametros = new List<Parametro>();
			parametros.Add(new Parametro("@nro", nroPresupuesto));

			tabla = HelperDao.ObtenerInstancia().ConsultaSQLParametrosEntrada("SP_CONSULTAR_PRESUPUESTO_POR_ID", parametros);

			bool primerRegistro = true;

			DataTableReader lector = tabla.CreateDataReader();

			while (lector.Read())
			{
				if (primerRegistro)
				{
					oPresupuesto.PresupuestoNro = Convert.ToInt32(lector["presupuesto_nro"].ToString());
					oPresupuesto.Cliente = lector["cliente"].ToString();
					oPresupuesto.Fecha = Convert.ToDateTime(lector["fecha"].ToString());
					oPresupuesto.Descuento = Convert.ToDouble(lector["descuento"].ToString());
					oPresupuesto.PresupuestoNro = Convert.ToInt32(lector["presupuesto_nro"].ToString());
					oPresupuesto.Total = Convert.ToDouble(lector["total"].ToString());
					if (!lector.IsDBNull(4))
					{
						oPresupuesto.FechaBaja = Convert.ToDateTime(lector["fecha_baja"].ToString());
					}
					else
					{
						oPresupuesto.FechaBaja = DateTime.MinValue;
					}
					
					primerRegistro = false;
				}

				Producto oProducto = new Producto();
				DetallePresupuesto oDetalle = new DetallePresupuesto();
				oProducto.IdProducto = Convert.ToInt32(lector["id_producto"].ToString());
				oProducto.NProducto = lector["n_producto"].ToString();
				oProducto.Precio = Convert.ToDouble(lector["precio"].ToString());
				oProducto.Activo = lector["activo"].ToString().Equals("S");

				oDetalle.Producto = oProducto;
				oDetalle.Cantidad = Convert.ToInt32(lector["cantidad"].ToString());

				oPresupuesto.AgregarDetalle(oDetalle);
			}
			return oPresupuesto;
		}
	}
}
