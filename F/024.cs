namespace Ejemplo {
	internal class Program {
		static void Main() {
			//Una cadena
			string[] Cad = { "gato", "perro", "avestruz", "toro",
								"ballena", "kakapo" };

			/* Se ordena usando Linq
			 * Ordena por la segunda letra. */
			IEnumerable<string> resultado = Cad.OrderBy(str => str[1]);
			Console.WriteLine("Ordenado por la segunda letra");
			foreach (string valor in resultado) {
				Console.WriteLine("[" + valor + "] ");
			}
		}
	}
}
