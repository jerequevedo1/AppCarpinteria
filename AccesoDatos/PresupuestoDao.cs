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

		public DataTable CargarDetallesPresupuestoEdicion(int nroPresupuesto)
		{
			SqlConnection cnn = new SqlConnection();
			cnn.ConnectionString = @"Data Source=NOTEBOOK-JERE\SQLEXPRESS;Initial Catalog=carpinteria_db;Integrated Security=True";
			cnn.Open();
			SqlCommand cmd2 = new SqlCommand();
			cmd2.Connection = cnn;
			cmd2.CommandType = CommandType.StoredProcedure;
			cmd2.CommandText = "SP_CONSULTAR_DETALLES";
			cmd2.Parameters.AddWithValue("@nro_presupuesto", nroPresupuesto);
			DataTable tabla2 = new DataTable();
			tabla2.Load(cmd2.ExecuteReader());
			cnn.Close();

			return tabla2;
		}

		public DataTable CargarPresupuestoEdicion(int nroPresupuesto)
		{
			SqlConnection cnn = new SqlConnection();
			cnn.ConnectionString = @"Data Source=NOTEBOOK-JERE\SQLEXPRESS;Initial Catalog=carpinteria_db;Integrated Security=True";
			cnn.Open();
			SqlCommand cmd = new SqlCommand();
			cmd.Connection = cnn;
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "SP_CONSULTAR_UN_PRESUPUESTO";
			cmd.Parameters.AddWithValue("@nroPresupuesto", nroPresupuesto);
			DataTable tabla = new DataTable();
			tabla.Load(cmd.ExecuteReader());
			cnn.Close();

			return tabla;
		}

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

		public DataTable ListarProductos()
		{
			DataTable tabla;
			try
			{
				SqlConnection cnn = new SqlConnection();
				cnn.ConnectionString = @"Data Source=NOTEBOOK-JERE\SQLEXPRESS;Initial Catalog=carpinteria_db;Integrated Security=True";
				cnn.Open();
				SqlCommand cmd = new SqlCommand();
				cmd.Connection = cnn;
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SP_CONSULTAR_PRODUCTOS";
				tabla = new DataTable();
				tabla.Load(cmd.ExecuteReader());
				cnn.Close();
			}
			catch (Exception)
			{
				tabla=null;
			}
			
			return tabla;
		}

		public int ObtenerProximoNumero()
		{
			int nro = 0;

			try
			{
				SqlConnection cnn = new SqlConnection();
				cnn.ConnectionString = @"Data Source=NOTEBOOK-JERE\SQLEXPRESS;Initial Catalog=carpinteria_db;Integrated Security=True";
				cnn.Open();
				SqlCommand cmd = new SqlCommand();
				cmd.Connection = cnn;
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SP_PROXIMO_ID";
				SqlParameter param = new SqlParameter("@next", SqlDbType.Int);
				param.Direction = ParameterDirection.Output;
				cmd.Parameters.Add(param);
				cmd.ExecuteNonQuery();
				cnn.Close();

				nro = (int)param.Value;
			}
			catch (Exception)
			{
				nro = -1;
			}

			return nro;
		}

		public DataTable ListarPresupuestos()
		{
			SqlConnection cnn = new SqlConnection();
			cnn.ConnectionString = @"Data Source=NOTEBOOK-JERE\SQLEXPRESS;Initial Catalog=carpinteria_db;Integrated Security=True";
			cnn.Open();
			SqlCommand cmd = new SqlCommand();
			cmd.Connection = cnn;
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "SP_CONSULTAR_PRESUPUESTOS";
			DataTable tabla = new DataTable();
			tabla.Load(cmd.ExecuteReader());
			cnn.Close();

			return tabla;
		}
	}
}
