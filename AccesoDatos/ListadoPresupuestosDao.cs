using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormCarpinteria.AccesoDatos
{
	class ListadoPresupuestosDao:IListadoPresupuestos
	{
		public DataTable ConsultarPresupuestos()
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
		public DataTable ConsultarPresupuestoEditar(int nroPresupuesto)
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
		public DataTable ConsultarDetallesPresupuestoEditar(int nroPresupuesto)
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
		public DataTable FiltrarNroPresupuesto(int nroPresupuesto)
		{
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

			return tabla;
		}
		public DataTable FiltrarFecha(DateTime fechaDesde, DateTime fechaHasta)
		{
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

			return tabla;
		}
		public DataTable FiltrarCliente(string cliente)
		{
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
			return tabla;
		}
	}
}
