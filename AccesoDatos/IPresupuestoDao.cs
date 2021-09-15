using System.Data;

namespace WinFormCarpinteria.AccesoDatos
{
	interface IPresupuestoDao
	{
		bool Crear(Presupuesto oPresupuesto);
		int ObtenerProximoNumero();

		DataTable ListarProductos();
	}
}