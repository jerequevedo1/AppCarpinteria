using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormCarpinteria.Formularios
{
	public partial class FrmPrincipal : Form
	{
		public FrmPrincipal()
		{
			InitializeComponent();
		}

		private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
		{
			FrmPresupuesto nuevo = new FrmPresupuesto(FrmPresupuesto.Accion.Create,0);
			nuevo.ShowDialog();
		}

		private void consultarToolStripMenuItem_Click(object sender, EventArgs e)
		{
			FrmConsultar consultar = new FrmConsultar();
			consultar.ShowDialog();
		}
	}
}
