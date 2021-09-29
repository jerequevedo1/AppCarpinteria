using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormCarpinteria.Entidades;

namespace WinFormCarpinteria.AccesoDatos
{
	interface IListadoPresupuestos
	{
		DataTable ConsultarPresupuestos();
		Presupuesto ConsultarUnPresupuesto(int nroPresupuesto);
		//DataTable ConsultarPresupuestoEditar(int nroPresupuesto);
		//DataTable ConsultarDetallesPresupuestoEditar(int nroPresupuesto);
		DataTable FiltrarNroPresupuesto(int nroPresupuesto);
		DataTable FiltrarFecha(DateTime fechaDesde, DateTime fechaHasta);
		DataTable FiltrarCliente(string cliente);
	}
}
