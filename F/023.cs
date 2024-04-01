namespace Ejemplo {
	internal class Program {
		static void Main() {
			//Una cadena
			string[] Cadenas = { "gato", "perro", "avestruz", "toro", "ballena", "kakapo" };

			/* Se ordena usando Linq
			 * Ordena por tamaño de las cadenas. */
			IEnumerable<string> resultado = Cadenas.OrderBy(str => str.Length);
			Console.WriteLine("Ordenado por tamaño");
			foreach (string valor in resultado) {
				Console.WriteLine("[" + valor + "] ");
			}
		}
	}
}