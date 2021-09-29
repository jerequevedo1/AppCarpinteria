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
		DataTable ConsultarPresupuestoNroPresupuesto(int nroPresupuesto);
		DataTable ConsultarPresupuestoFecha(DateTime fechaDesde, DateTime fechaHasta);
		DataTable ConsultarPresupuestoCliente(string cliente);
	}
}
