using System;
using System.Collections.Generic;
using System.Data;
using WinFormCarpinteria.Servicios;

namespace WinFormCarpinteria.AccesoDatos
{
	interface IPresupuestoDao
	{
		bool InsertarPresupuesto(Presupuesto oPresupuesto);
		bool EditarPresupuesto(Presupuesto oPresupuesto);
		bool BorrarPresupuesto(int nroPresupuesto);
		int ObtenerProximoNumero();
		List<Producto> ConsultarProductos();
		List<Presupuesto> ConsultarPresupuestos(List<Parametro> parametros);
		Presupuesto ConsultarUnPresupuesto(int nroPresupuesto);
	}
}