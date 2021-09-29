using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormCarpinteria.AccesoDatos
{
	class PresupuestoDao : IPresupuestoDao
	{
		public bool InsertarPresupuesto(Presupuesto oPresupuesto)
		{
			bool resultado = true;

			SqlConnection cnn = new SqlConnection();
			SqlTransaction trans = null;

			try
			{
				cnn.ConnectionString = @"Data Source=NOTEBOOK-JERE\SQLEXPRESS;Initial Catalog=carpinteria_db;Integrated Security=True";
				cnn.Open();
				trans = cnn.BeginTransaction();
				SqlCommand cmd = new SqlCommand();
				cmd.Connection = cnn;
				cmd.Transaction = trans;
				cmd.CommandText = "SP_INSERTAR_MAESTRO";
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.AddWithValue("@cliente", oPresupuesto.Cliente);
				cmd.Parameters.AddWithValue("@dto", oPresupuesto.Descuento);
				cmd.Parameters.AddWithValue("@total", oPresupuesto.Total);
				SqlParameter parameter = new SqlParameter("@presupuesto_nro", SqlDbType.Int);
				parameter.Direction = ParameterDirection.Output;
				cmd.Parameters.Add(parameter);
				cmd.ExecuteNonQuery();

				oPresupuesto.PresupuestoNro = Convert.ToInt32(parameter.Value);
				int detalleNro = 1;

				foreach (DetallePresupuesto item in oPresupuesto.Detalles)
				{
					SqlCommand cmdDet = new SqlCommand();
					cmdDet.Connection = cnn;
					cmdDet.Transaction = trans;
					cmdDet.CommandText = "SP_INSERTAR_DETALLE";
					cmdDet.CommandType = CommandType.StoredProcedure;
					cmdDet.Parameters.AddWithValue("@presupuesto_nro", oPresupuesto.PresupuestoNro);
					cmdDet.Parameters.AddWithValue("@detalle", detalleNro);
					cmdDet.Parameters.AddWithValue("@id_producto", item.Producto.IdProducto);
					cmdDet.Parameters.AddWithValue("@cantidad", item.Cantidad);
					cmdDet.ExecuteNonQuery();
					detalleNro++;
				}

				trans.Commit();
			}
			catch (Exception)
			{
				//en caso que quiera saber que error ocurre
				//MessageBox.Show("error: " + E.Message);
				trans.Rollback();
				resultado = false;
			}
			finally
			{
				if (cnn != null && cnn.State == ConnectionState.Open) cnn.Close();
			}

			return resultado;
		}
		public bool EditarPresupuesto(Presupuesto oPresupuesto)
		{

			bool resultado = true;

			SqlConnection cnn = new SqlConnection();
			SqlTransaction trans = null;

			try
			{
				cnn.ConnectionString = @"Data Source=NOTEBOOK-JERE\SQLEXPRESS;Initial Catalog=carpinteria_db;Integrated Security=True";
				cnn.Open();
				trans = cnn.BeginTransaction();
				SqlCommand cmd = new SqlCommand();
				cmd.Connection = cnn;
				cmd.Transaction = trans;
				cmd.CommandText = "SP_EDITAR_PRESUPUESTO";
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.AddWithValue("@nro_presupuesto", oPresupuesto.PresupuestoNro);
				cmd.Parameters.AddWithValue("@fecha", oPresupuesto.Fecha);
				cmd.Parameters.AddWithValue("@cliente", oPresupuesto.Cliente);
				cmd.Parameters.AddWithValue("@descuento", oPresupuesto.Descuento);
				cmd.Parameters.AddWithValue("@total", oPresupuesto.Total);
				cmd.ExecuteNonQuery();

				int detalleNro = 1;

				//borro todos los detalles y cargo detalles actuales nuevamente?
		
				SqlCommand cmdBorrado = new SqlCommand();
				cmdBorrado.Connection = cnn;
				cmdBorrado.Transaction = trans;
				cmdBorrado.CommandText = "SP_BORRAR_DETALLES";
				cmdBorrado.CommandType = CommandType.StoredProcedure;
				cmdBorrado.Parameters.AddWithValue("@nroPresupuesto", oPresupuesto.PresupuestoNro);
				cmdBorrado.ExecuteNonQuery();

				//como hago si elimina algun detalle el cliente? en bd quedaria un registro colgado

				foreach (DetallePresupuesto item in oPresupuesto.Detalles)
				{
					SqlCommand cmdDet = new SqlCommand();
					cmdDet.Connection = cnn;
					cmdDet.Transaction = trans;
					//cmdDet.CommandText = "SP_EDITAR_DETALLES_PRESUPUESTO"; edito o inserto de nuevo?
					cmdDet.CommandText = "SP_INSERTAR_DETALLE";
					cmdDet.CommandType = CommandType.StoredProcedure;
					cmdDet.Parameters.AddWithValue("@presupuesto_nro", oPresupuesto.PresupuestoNro);
					cmdDet.Parameters.AddWithValue("@detalle", detalleNro);
					cmdDet.Parameters.AddWithValue("@id_producto", item.Producto.IdProducto);
					cmdDet.Parameters.AddWithValue("@cantidad", item.Cantidad);
					cmdDet.ExecuteNonQuery();
					detalleNro++;
				}

				trans.Commit();
			}
			catch (Exception e)
			{
				string mensaje=e.Message;
				trans.Rollback();
				resultado = false;
			}
			finally
			{
				if (cnn != null && cnn.State == ConnectionState.Open) cnn.Close();
			}

			return resultado;
		}
		public bool BorrarPresupuesto(int nroPresupuesto)
		{
			bool resultado = true;
			SqlConnection cnn = new SqlConnection();
			SqlTransaction trans = null;

			try
			{
				cnn.ConnectionString = @"Data Source=NOTEBOOK-JERE\SQLEXPRESS;Initial Catalog=carpinteria_db;Integrated Security=True";
				cnn.Open();
				trans = cnn.BeginTransaction();
				SqlCommand cmd = new SqlCommand();
				cmd.Connection = cnn;
				cmd.Transaction = trans;
				cmd.CommandText = "SP_BORRAR_DETALLES";
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.AddWithValue("@nroPresupuesto", nroPresupuesto);
				cmd.ExecuteNonQuery();

				SqlCommand cmd2 = new SqlCommand();
				cmd2.Connection = cnn;
				cmd2.Transaction = trans;
				cmd2.CommandText = "SP_BORRAR_PRESUPUESTO";
				cmd2.CommandType = CommandType.StoredProcedure;
				cmd2.Parameters.AddWithValue("@nroPresupuesto", nroPresupuesto);
				cmd2.ExecuteNonQuery();

				trans.Commit();
			}
			catch (Exception)
			{
				trans.Rollback();
				resultado = false;
			}
			finally
			{
				if (cnn != null && cnn.State == ConnectionState.Open) cnn.Close();
			}

			return resultado;
		}
		public int ObtenerProximoNumero()
		{
			return HelperDao.ObtenerInstancia().ProximoID("SP_PROXIMO_ID", "@next");
		}
		public List<Producto> ConsultarProductos()
		{
			DataTable tabla = HelperDao.ObtenerInstancia().ConsultaSQL("SP_CONSULTAR_PRODUCTOS");
			List<Producto> lst = new List<Producto>();
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
		public List<Presupuesto> ConsultarPresupuestos()
		{
			List<Presupuesto> lst = new List<Presupuesto>();
			DataTable tabla = HelperDao.ObtenerInstancia().ConsultaSQL("SP_CONSULTAR_PRESUPUESTOS");

			foreach (DataRow row in tabla.Rows)
			{
				Presupuesto oPresupuesto = new Presupuesto();
				oPresupuesto.Cliente = row["cliente"].ToString();
				oPresupuesto.Fecha = Convert.ToDateTime(row["fecha"].ToString());
				oPresupuesto.Descuento = Convert.ToDouble(row["descuento"].ToString());
				oPresupuesto.PresupuestoNro = Convert.ToInt32(row["presupuesto_nro"].ToString());
				oPresupuesto.Total = Convert.ToDouble(row["total"].ToString());

				lst.Add(oPresupuesto);
			}

			return lst;
		}
		public Presupuesto ConsultarUnPresupuesto(int nroPresupuesto)
		{
			Presupuesto oPresupuesto = new Presupuesto();
			SqlConnection cnn = new SqlConnection();
			cnn.ConnectionString = @"Data Source=NOTEBOOK-JERE\SQLEXPRESS;Initial Catalog=carpinteria_db;Integrated Security=True";
			cnn.Open();
			SqlCommand cmd = new SqlCommand();
			cmd.Connection = cnn;
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "SP_CONSULTAR_PRESUPUESTO_POR_ID";
			cmd.Parameters.AddWithValue("@nro", nroPresupuesto);
			SqlDataReader lector = cmd.ExecuteReader();

			bool primerRegistro = true;

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
			cnn.Close();
			return oPresupuesto;
		}
		public List<Presupuesto> ConsultarPresupuestoNroPresupuesto(int nroPresupuesto)
		{
			List<Presupuesto> lst = new List<Presupuesto>();
			DataTable tabla = new DataTable();
			SqlConnection cnn = new SqlConnection();
			SqlCommand cmd = new SqlCommand();
			cnn.ConnectionString = @"Data Source=NOTEBOOK-JERE\SQLEXPRESS;Initial Catalog=carpinteria_db;Integrated Security=True";
			cnn.Open();
			cmd.Connection = cnn;
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "SP_FILTRO_NROPRESUP";
			cmd.Parameters.AddWithValue("@nro_presup", nroPresupuesto);
			tabla.Load(cmd.ExecuteReader());
			cnn.Close();

			foreach (DataRow row in tabla.Rows)
			{
				Presupuesto oPresupuesto = new Presupuesto();
				oPresupuesto.Cliente = row["cliente"].ToString();
				oPresupuesto.Fecha = Convert.ToDateTime(row["fecha"].ToString());
				oPresupuesto.Descuento = Convert.ToDouble(row["descuento"].ToString());
				oPresupuesto.PresupuestoNro = Convert.ToInt32(row["presupuesto_nro"].ToString());
				oPresupuesto.Total = Convert.ToDouble(row["total"].ToString());

				lst.Add(oPresupuesto);
			}

			return lst;
		}
		public List<Presupuesto> ConsultarPresupuestoFecha(DateTime fechaDesde, DateTime fechaHasta)
		{
			List<Presupuesto> lst = new List<Presupuesto>();
			DataTable tabla = new DataTable();
			SqlConnection cnn = new SqlConnection();
			SqlCommand cmd = new SqlCommand();
			cnn.ConnectionString = @"Data Source=NOTEBOOK-JERE\SQLEXPRESS;Initial Catalog=carpinteria_db;Integrated Security=True";
			cnn.Open();
			cmd.Connection = cnn;
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "SP_FILTRO_FECHA";
			cmd.Parameters.AddWithValue("@fechaDesde", fechaDesde);
			cmd.Parameters.AddWithValue("@fechaHasta", fechaHasta);
			tabla.Load(cmd.ExecuteReader());
			cnn.Close();

			foreach (DataRow row in tabla.Rows)
			{
				Presupuesto oPresupuesto = new Presupuesto();
				oPresupuesto.Cliente = row["cliente"].ToString();
				oPresupuesto.Fecha = Convert.ToDateTime(row["fecha"].ToString());
				oPresupuesto.Descuento = Convert.ToDouble(row["descuento"].ToString());
				oPresupuesto.PresupuestoNro = Convert.ToInt32(row["presupuesto_nro"].ToString());
				oPresupuesto.Total = Convert.ToDouble(row["total"].ToString());

				lst.Add(oPresupuesto);
			}

			return lst;
		}
		public List<Presupuesto> ConsultarPresupuestoCliente(string cliente)
		{
			List<Presupuesto> lst = new List<Presupuesto>();
			DataTable tabla = new DataTable();
			SqlConnection cnn = new SqlConnection();
			SqlCommand cmd = new SqlCommand();
			cnn.ConnectionString = @"Data Source=NOTEBOOK-JERE\SQLEXPRESS;Initial Catalog=carpinteria_db;Integrated Security=True";
			cnn.Open();
			cmd.Connection = cnn;
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "SP_FILTRO_CLIENTE";
			cmd.Parameters.AddWithValue("@cliente", cliente);
			tabla.Load(cmd.ExecuteReader());
			cnn.Close();

			foreach (DataRow row in tabla.Rows)
			{
				Presupuesto oPresupuesto = new Presupuesto();
				oPresupuesto.Cliente = row["cliente"].ToString();
				oPresupuesto.Fecha = Convert.ToDateTime(row["fecha"].ToString());
				oPresupuesto.Descuento = Convert.ToDouble(row["descuento"].ToString());
				oPresupuesto.PresupuestoNro = Convert.ToInt32(row["presupuesto_nro"].ToString());
				oPresupuesto.Total = Convert.ToDouble(row["total"].ToString());

				lst.Add(oPresupuesto);
			}

			return lst;
		}
	}
}
