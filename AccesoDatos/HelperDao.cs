using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormCarpinteria.Servicios;

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
		public int ProximoID(string nombreSP,string nombreParam)
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
		public int EjecutarSQLParametrosEntrada(string sentencia, List<Parametro> parametros)
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
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = sentencia;

				foreach (Parametro p in parametros)
				{
					cmd.Parameters.AddWithValue(p.Nombre, p.Valor);
				}
				filasAfectadas = cmd.ExecuteNonQuery();
				trans.Commit();
			}
			catch //(Exception ex)
			{
				filasAfectadas = 0;
				trans.Rollback();
				//throw ex;
			}
			finally
			{
				if (cnn.State == ConnectionState.Open) cnn.Close();
			}
			return filasAfectadas;
		}

		public DataTable ConsultaSQLParametrosEntrada(string consulta,List<Parametro> parametros)
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
	}
}
