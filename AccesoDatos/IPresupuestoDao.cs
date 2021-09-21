using System.Data;

namespace WinFormCarpinteria.AccesoDatos
{
	interface IPresupuestoDao
	{
		bool InsertarPresupuesto(Presupuesto oPresupuesto);
		int ObtenerProximoNumero();
		DataTable ListarProductos();
		bool BorrarPresupuesto(int nroPresupuesto);
		bool EditarPresupuesto(Presupuesto oPresupuesto);
		DataTable CargarPresupuestoEdicion(int nroPresupuesto);
		DataTable CargarDetallesPresupuestoEdicion(int nroPresupuesto);
		DataTable ListarPresupuestos();
	}
}