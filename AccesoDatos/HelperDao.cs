using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormCarpinteria.AccesoDatos
{
	class HelperDao
	{
		private static HelperDao instancia;
		private string cadenaConexion;
		SqlConnection cnn = new SqlConnection();
		SqlCommand cmd = new SqlCommand();
		private HelperDao()
		{
			cadenaConexion = @"Data Source=NOTEBOOK-JERE\SQLEXPRESS;Initial Catalog=carpinteria_db;Integrated Security=True";			
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
				cnn.ConnectionString = cadenaConexion;
				cnn.Open();
				cmd.Connection = cnn;
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = nombreSP;
				tabla.Load(cmd.ExecuteReader());

				return tabla;
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
		}
		public int ProximoID(string nombreSP,string nombreParam)
		{
			SqlParameter param = new SqlParameter(nombreParam, SqlDbType.Int);
			try
			{
				
				cnn.ConnectionString = cadenaConexion;
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

	}
}
