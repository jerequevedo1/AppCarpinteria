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
		//public bool InsertarPresupuesto(Presupuesto oPresupuesto)
		//{
		//	bool resultado = true;

		//	SqlConnection cnn = new SqlConnection();
		//	SqlTransaction trans = null;

		//	try
		//	{
		//		cnn.ConnectionString = @"Data Source=NOTEBOOK-JERE\SQLEXPRESS;Initial Catalog=carpinteria_db;Integrated Security=True";
		//		cnn.Open();
		//		trans = cnn.BeginTransaction();
		//		SqlCommand cmd = new SqlCommand();
		//		cmd.Connection = cnn;
		//		cmd.Transaction = trans;
		//		cmd.CommandText = "SP_INSERTAR_MAESTRO";
		//		cmd.CommandType = CommandType.StoredProcedure;
		//		cmd.Parameters.AddWithValue("@cliente", oPresupuesto.Cliente);
		//		cmd.Parameters.AddWithValue("@dto", oPresupuesto.Descuento);
		//		cmd.Parameters.AddWithValue("@total", oPresupuesto.Total);
		//		SqlParameter parameter = new SqlParameter("@presupuesto_nro", SqlDbType.Int);
		//		parameter.Direction = ParameterDirection.Output;
		//		cmd.Parameters.Add(parameter);
		//		cmd.ExecuteNonQuery();

		//		oPresupuesto.PresupuestoNro = Convert.ToInt32(parameter.Value);
		//		int detalleNro = 1;

		//		foreach (DetallePresupuesto item in oPresupuesto.Detalles)
		//		{
		//			SqlCommand cmdDet = new SqlCommand();
		//			cmdDet.Connection = cnn;
		//			cmdDet.Transaction = trans;
		//			cmdDet.CommandText = "SP_INSERTAR_DETALLE";
		//			cmdDet.CommandType = CommandType.StoredProcedure;
		//			cmdDet.Parameters.AddWithValue("@presupuesto_nro", oPresupuesto.PresupuestoNro);
		//			cmdDet.Parameters.AddWithValue("@detalle", detalleNro);
		//			cmdDet.Parameters.AddWithValue("@id_producto", item.Producto.IdProducto);
		//			cmdDet.Parameters.AddWithValue("@cantidad", item.Cantidad);
		//			cmdDet.ExecuteNonQuery();
		//			detalleNro++;
		//		}

		//		trans.Commit();
		//	}
		//	catch (Exception)
		//	{
		//		//en caso que quiera saber que error ocurre
		//		//MessageBox.Show("error: " + E.Message);
		//		trans.Rollback();
		//		resultado = false;
		//	}
		//	finally
		//	{
		//		if (cnn != null && cnn.State == ConnectionState.Open) cnn.Close();
		//	}

		//	return resultado;
		//}
		public bool InsertarPresupuesto(Presupuesto oPresupuesto)
		{
			bool resultado = true;
			int filasAfectadas = 0;
			//List<Parametro> parametrosMaestro = new List<Parametro>();
			//parametrosMaestro.Add(new Parametro("@cliente", oPresupuesto.Cliente));
			//parametrosMaestro.Add(new Parametro("@dto", oPresupuesto.Descuento));
			//parametrosMaestro.Add(new Parametro("@total", oPresupuesto.Total));

			filasAfectadas = HelperDao.ObtenerInstancia().EjecutarSQLMaestroDetalle("SP_INSERTAR_MAESTRO", "SP_INSERTAR_DETALLE", oPresupuesto, Accion.Create);

			if (filasAfectadas == 0) resultado = false;

			return resultado;
		}
		//public bool EditarPresupuesto(Presupuesto oPresupuesto)
		//{

		//	bool resultado = true;
		//	SqlConnection cnn = new SqlConnection();
		//	SqlTransaction trans = null;

		//	try
		//	{
		//		cnn.ConnectionString = @"Data Source=NOTEBOOK-JERE\SQLEXPRESS;Initial Catalog=carpinteria_db;Integrated Security=True";
		//		cnn.Open();
		//		trans = cnn.BeginTransaction();
		//		SqlCommand cmd = new SqlCommand();
		//		cmd.Connection = cnn;
		//		cmd.Transaction = trans;
		//		cmd.CommandText = "SP_EDITAR_PRESUPUESTO";
		//		cmd.CommandType = CommandType.StoredProcedure;
		//		cmd.Parameters.AddWithValue("@nro_presupuesto", oPresupuesto.PresupuestoNro);
		//		cmd.Parameters.AddWithValue("@fecha", oPresupuesto.Fecha);
		//		cmd.Parameters.AddWithValue("@cliente", oPresupuesto.Cliente);
		//		cmd.Parameters.AddWithValue("@descuento", oPresupuesto.Descuento);
		//		cmd.Parameters.AddWithValue("@total", oPresupuesto.Total);
		//		cmd.ExecuteNonQuery();

		//		int detalleNro = 1;

		//		SqlCommand cmdBorrado = new SqlCommand();
		//		cmdBorrado.Connection = cnn;
		//		cmdBorrado.Transaction = trans;
		//		cmdBorrado.CommandText = "SP_BORRAR_DETALLES";
		//		cmdBorrado.CommandType = CommandType.StoredProcedure;
		//		cmdBorrado.Parameters.AddWithValue("@nroPresupuesto", oPresupuesto.PresupuestoNro);
		//		cmdBorrado.ExecuteNonQuery();

		//		foreach (DetallePresupuesto item in oPresupuesto.Detalles)
		//	{
		//			SqlCommand cmdDet = new SqlCommand();
		//			cmdDet.Connection = cnn;
		//			cmdDet.Transaction = trans;
		//			cmdDet.CommandText = "SP_INSERTAR_DETALLE";
		//			cmdDet.CommandType = CommandType.StoredProcedure;
		//			cmdDet.Parameters.AddWithValue("@presupuesto_nro", oPresupuesto.PresupuestoNro);
		//			cmdDet.Parameters.AddWithValue("@detalle", detalleNro);
		//			cmdDet.Parameters.AddWithValue("@id_producto", item.Producto.IdProducto);
		//			cmdDet.Parameters.AddWithValue("@cantidad", item.Cantidad);
		//			cmdDet.ExecuteNonQuery();
		//			detalleNro++;
		//	}

		//		trans.Commit();
		//	}
		//	catch (Exception e)
		//	{
		//		string mensaje = e.Message;
		//		trans.Rollback();
		//		resultado = false;
		//	}
		//	finally
		//	{
		//		if (cnn != null && cnn.State == ConnectionState.Open) cnn.Close();
		//	}

		//	return resultado;
		//}
		public bool EditarPresupuesto(Presupuesto oPresupuesto)
		{
			bool resultado = true;
			int filasAfectadas = 0;
			//List<Parametro> parametrosMaestro = new List<Parametro>();
			//parametrosMaestro.Add(new Parametro("@nro_presupuesto", oPresupuesto.PresupuestoNro));
			//parametrosMaestro.Add(new Parametro("@fecha", oPresupuesto.Fecha));
			//parametrosMaestro.Add(new Parametro("@cliente", oPresupuesto.Cliente));
			//parametrosMaestro.Add(new Parametro("@descuento", oPresupuesto.Descuento));
			//parametrosMaestro.Add(new Parametro("@total", oPresupuesto.Total));

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
