namespace Ejemplo {
	internal class Program {
		static void Main() {
			//Una cadena
			List<string> Cad = [ "gato", "perro", "avestruz",
								"toro", "ballena", "kakapo" ];

			/* Se ordena usando LINQ
			 * Ordena por tamaño de las cadenas. */
			IEnumerable<string> Res = Cad.OrderBy(str => str.Length);
			Console.WriteLine("Ordenado por tamaño");
			foreach (string valor in Res) {
				Console.WriteLine("[" + valor + "] ");
			}
		}
	}
}