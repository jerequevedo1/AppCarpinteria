using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormCarpinteria
{
	static class Program
	{
		/// <summary>
		/// Punto de entrada principal para la aplicación.
		/// </summary>
		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new Formularios.FrmPrincipal());
			//Application.Run(new Formularios.FrmReporteProductos());
			//Application.Run(new Formularios.FrmNuevoPresupuesto());
			//Application.Run(new Formularios.FrmConsultar());
		}
	}
}
