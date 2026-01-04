using System.Collections;

namespace Ejemplo;

internal class Program {
	static void Main() {
		ArrayList Varios =
		[
			1822,
			'M',
			true,
			639.9,
			"Rafael",
			6094,
			'J',
			false,
			55.5,
			"José",
		];

		//Muestra los ítems que son strings
		Console.WriteLine("Strings en el listado:");
		List<string> Cadenas = (from nombre in
								Varios.OfType<string>()
								select nombre).ToList();
		for (int Cont = 0; Cont < Cadenas.Count; Cont++) {
			Console.WriteLine(Cadenas[Cont]);
		}

		//Muestra los ítems que son booleanos
		Console.WriteLine("\r\nBooleanos en el listado:");
		List<bool> Booleanos = (from valorbool in
								Varios.OfType<bool>()
								select valorbool).ToList();
		for (int Cont = 0; Cont < Cadenas.Count; Cont++) {
			Console.WriteLine(Booleanos[Cont]);
		}

		//Muestra los ítems que son enteros
		Console.WriteLine("\r\nEnteros en el listado:");
		List<int> Enteros = (from valorentero in
							Varios.OfType<int>()
							 select valorentero).ToList();
		for (int Cont = 0; Cont < Cadenas.Count; Cont++) {
			Console.WriteLine(Enteros[Cont]);
		}
	}
}