using System.Collections;

namespace Ejemplo {
	internal class Program {
		static void Main() {
			ArrayList ListadoVarios = new ArrayList();

			ListadoVarios.Add(1822);
			ListadoVarios.Add('M');
			ListadoVarios.Add(true);
			ListadoVarios.Add(639.9);
			ListadoVarios.Add("Rafael");

			ListadoVarios.Add(6094);
			ListadoVarios.Add('J');
			ListadoVarios.Add(false);
			ListadoVarios.Add(55.5);
			ListadoVarios.Add("José");

			//Muestra los ítems que son strings
			Console.WriteLine("Strings en el listado:");
			List<string> Cadenas = (from nombre in ListadoVarios.OfType<string>() select nombre).ToList();
			for (int Contador = 0; Contador < Cadenas.Count; Contador++) {
				Console.WriteLine(Cadenas[Contador]);
			}

			//Muestra los ítems que son booleanos
			Console.WriteLine("\r\nBooleanos en el listado:");
			List<bool> Booleanos = (from valorbool in ListadoVarios.OfType<bool>() select valorbool).ToList();
			for (int Contador = 0; Contador < Cadenas.Count; Contador++) {
				Console.WriteLine(Booleanos[Contador]);
			}

			//Muestra los ítems que son enteros
			Console.WriteLine("\r\nEnteros en el listado:");
			List<int> Enteros = (from valorentero in ListadoVarios.OfType<int>() select valorentero).ToList();
			for (int Contador = 0; Contador < Cadenas.Count; Contador++) {
				Console.WriteLine(Enteros[Contador]);
			}
		}
	}
}