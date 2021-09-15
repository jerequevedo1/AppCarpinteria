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
