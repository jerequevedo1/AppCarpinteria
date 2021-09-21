using System.Data;

namespace WinFormCarpinteria.AccesoDatos
{
	interface IPresupuestoDao
	{
		bool CrearPresupuesto(Presupuesto oPresupuesto);
		int ObtenerProximoNumero();
		DataTable ListarProductos();
		bool BorrarPresupuesto(int nroPresupuesto);
		void EditarPresupuesto(int nroPresupuesto);
		DataTable CargarPresupuestoEdicion(int nroPresupuesto);
		DataTable CargarDetallesPresupuestoEdicion(int nroPresupuesto);
	}
}