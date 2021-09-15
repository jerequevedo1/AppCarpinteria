using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormCarpinteria
{
	class Presupuesto
	{
		public int PresupuestoNro { get; set; }
		public DateTime Fecha { get; set; }
		public string Cliente { get; set; }
		public double Total { get; set; }
		public double Descuento { get; set; }
		public DateTime FechaBaja { get; set; }
		public List<DetallePresupuesto> Detalles { get; set; }

		public Presupuesto()
		{
			Detalles = new List<DetallePresupuesto>();
		}
		
		public void AgregarDetalle(DetallePresupuesto detalle)
		{
			Detalles.Add(detalle);
		}
		public void QuitarDetalle(int indice)
		{
			Detalles.RemoveAt(indice);
		}
		public double CalcularTotal()
		{
			double total = 0;
			foreach (DetallePresupuesto item in Detalles)
			{
				total += item.CalcularSubtotal();
			}

			return total;
		}

		public bool Confirmar()
		{
			//aca confirmo la operacion sql
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
				cmd.Parameters.AddWithValue("@cliente", this.Cliente);
				cmd.Parameters.AddWithValue("@dto", this.Descuento);
				cmd.Parameters.AddWithValue("@total", this.Total);
				SqlParameter parameter = new SqlParameter("@presupuesto_nro", SqlDbType.Int);
				parameter.Direction = ParameterDirection.Output;
				cmd.Parameters.Add(parameter);
				cmd.ExecuteNonQuery();

				this.PresupuestoNro = Convert.ToInt32(parameter.Value);
				int detalleNro = 1;

				foreach (DetallePresupuesto item in Detalles)
				{
					SqlCommand cmdDet = new SqlCommand();
					cmdDet.Connection = cnn;
					cmdDet.Transaction = trans;
					cmdDet.CommandText = "SP_INSERTAR_DETALLE";
					cmdDet.CommandType = CommandType.StoredProcedure;
					cmdDet.Parameters.AddWithValue("@presupuesto_nro", this.PresupuestoNro);
					cmdDet.Parameters.AddWithValue("@detalle", detalleNro);
					cmdDet.Parameters.AddWithValue("@id_producto",item.Producto.IdProducto);
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
				resultado=false;
			}
			finally
			{
				if (cnn != null && cnn.State == ConnectionState.Open ) cnn.Close();
			}

			return resultado;
		}

		public bool Borrar(int nroPresupuesto)
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
			catch (Exception e)
			{
				trans.Rollback();
				resultado = false;
				MessageBox.Show("error: "+e.Message);
			}
			finally
			{
				if (cnn != null && cnn.State == ConnectionState.Open) cnn.Close();
			}

			return resultado;
		}
	}
}
