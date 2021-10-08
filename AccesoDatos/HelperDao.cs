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
	class HelperDao
	{
		private static HelperDao instancia;
		private string cadenaConexion;
		SqlConnection cnn;
		SqlCommand cmd;
		private HelperDao()
		{
			cadenaConexion = Properties.Resources.strConexion;
			cnn = new SqlConnection(cadenaConexion);
			cmd = new SqlCommand();
		}
		public static HelperDao ObtenerInstancia()
		{
			if (instancia==null)
			{
				instancia = new HelperDao();
			}
			return instancia;
		}
		public int ProximoID(string nombreSP, string nombreParam)
		{
			SqlParameter param = new SqlParameter(nombreParam, SqlDbType.Int);
			try
			{
				cmd.Parameters.Clear();
				cnn.Open();
				cmd.Connection = cnn;
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = nombreSP;
				param.Direction = ParameterDirection.Output;
				cmd.Parameters.Add(param);
				cmd.ExecuteNonQuery();
				return (int)param.Value;
			}
			catch (Exception ex)
			{
				throw ex;
			}
			finally
			{
				if (cnn.State == ConnectionState.Open)
					cnn.Close();
			}
		}
		public DataTable ConsultaSQL(string nombreSP)
		{
			DataTable tabla = new DataTable();
			try
			{
				cmd.Parameters.Clear();
				cnn.Open();
				cmd.Connection = cnn;				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = nombreSP;
				tabla.Load(cmd.ExecuteReader());
			}
			catch (Exception ex)
			{
				throw ex;
			}
			finally
			{
				if(cnn.State==ConnectionState.Open)
				cnn.Close();
			}
			return tabla;
		}
		public DataTable ConsultaSQLParametrosEntrada(string consulta, List<Parametro> parametros)
		{
			DataTable tabla = new DataTable();
			try
			{
				cmd.Parameters.Clear();
				cnn.Open();
				cmd.Connection = cnn;
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = consulta;

				foreach (Parametro p in parametros)
				{
					cmd.Parameters.AddWithValue(p.Nombre, p.Valor);
				}

				tabla.Load(cmd.ExecuteReader());
			}
			catch //(Exception ex)
			{
				//throw ex;
				tabla = null;
			}
			finally
			{
				if (cnn.State == ConnectionState.Open) cnn.Close();
			}

			return tabla;
		}
		public int EjecutarSQLParametrosEntrada(string sentencia, List<Parametro> parametros)
		{
			int filasAfectadas = 0;
			//SqlTransaction trans = null;
			try
			{
				cmd.Parameters.Clear();
				cnn.Open();
				//trans = cnn.BeginTransaction();
				cmd.Connection = cnn;
				//cmd.Transaction = trans;
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = sentencia;

				foreach (Parametro p in parametros)
				{
					cmd.Parameters.AddWithValue(p.Nombre, p.Valor);
				}
				filasAfectadas = cmd.ExecuteNonQuery();
				//trans.Commit();
			}
			catch //(Exception ex)
			{
				filasAfectadas = 0;
				//trans.Rollback();
				//throw ex;
			}
			finally
			{
				if (cnn.State == ConnectionState.Open) cnn.Close();
			}
			return filasAfectadas;
		}
		public int EjecutarSQLMaestroDetalle(string spMaestro,string spDetalle,Presupuesto oPresupuesto,Accion modo)
		{
			int filasAfectadas = 0;
			SqlTransaction trans = null;

			try
			{
				cmd.Parameters.Clear();
				cnn.Open();
				trans = cnn.BeginTransaction();
				cmd.Connection = cnn;
				cmd.Transaction = trans;
				cmd.CommandText = spMaestro;
				cmd.CommandType = CommandType.StoredProcedure;

				if (modo == Accion.Create)
				{
					cmd.Parameters.AddWithValue("@cliente", oPresupuesto.Cliente);
					cmd.Parameters.AddWithValue("@dto", oPresupuesto.Descuento);
					cmd.Parameters.AddWithValue("@total", oPresupuesto.Total);
					SqlParameter parameter = new SqlParameter("@presupuesto_nro", SqlDbType.Int);
					parameter.Direction = ParameterDirection.Output;
					cmd.Parameters.Add(parameter);

					cmd.ExecuteNonQuery();
					oPresupuesto.PresupuestoNro = Convert.ToInt32(parameter.Value);
				}
				if (modo == Accion.Update)
				{
					cmd.Parameters.AddWithValue("@nro_presupuesto", oPresupuesto.PresupuestoNro);
					cmd.Parameters.AddWithValue("@fecha", oPresupuesto.Fecha);
					cmd.Parameters.AddWithValue("@cliente", oPresupuesto.Cliente);
					cmd.Parameters.AddWithValue("@descuento", oPresupuesto.Descuento);
					cmd.Parameters.AddWithValue("@total", oPresupuesto.Total);
					cmd.ExecuteNonQuery();
				}

				int detalleNro = 1;

				foreach (DetallePresupuesto item in oPresupuesto.Detalles)
				{
					SqlCommand cmdDet = new SqlCommand();
					cmdDet.Connection = cnn;
					cmdDet.Transaction = trans;
					cmdDet.CommandText = spDetalle;
					cmdDet.CommandType = CommandType.StoredProcedure;

					cmdDet.Parameters.AddWithValue("@presupuesto_nro", oPresupuesto.PresupuestoNro);
					cmdDet.Parameters.AddWithValue("@detalle", detalleNro);
					cmdDet.Parameters.AddWithValue("@id_producto", item.Producto.IdProducto);
					cmdDet.Parameters.AddWithValue("@cantidad", item.Cantidad);
					filasAfectadas =cmdDet.ExecuteNonQuery();
					detalleNro++;
				}

				trans.Commit();
			}
			catch (Exception e)
			{
				throw e;
				string mensaje = e.Message;
				trans.Rollback();
				filasAfectadas = 0;
			}
			finally
			{
				if (cnn != null && cnn.State == ConnectionState.Open) cnn.Close();
			}

			return filasAfectadas;
		}

	}
}
