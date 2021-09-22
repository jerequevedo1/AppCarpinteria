using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormCarpinteria.Entidades
{
	class ListadoPresupuestos
	{
		public ListadoPresupuestos()
		{
			LPresupuestos = new List<Presupuesto>();
		}

		private List<Presupuesto> LPresupuestos { get; set; }

		public void Agregar(Presupuesto oPresupuesto)
		{
			LPresupuestos.Add(oPresupuesto);
		}
	}
}
