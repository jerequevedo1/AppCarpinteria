using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormCarpinteria
{
	class Producto
	{
		public Producto(int idProducto, string nProducto, double precio)
		{
			IdProducto = idProducto;
			NProducto = nProducto;
			Precio = precio;
			Activo = true;
		}
		public Producto()
		{
			IdProducto = 0;
			NProducto = string.Empty;
			Precio = 0;
			Activo = true;
		}
		public int IdProducto { get; set; }
		public string NProducto { get; set; }
		public double Precio { get; set; }
		public bool Activo { get; set; }

		public override string ToString()
		{
			return NProducto;
		}
	}
}
