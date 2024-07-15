namespace Ejemplo {
	internal class Program {
		static void Main() {
			//Una cadena
			string[] Cadenas = { "gato", "perro", "avestruz", "toro",
								"ballena", "kakapo" };

			/* Invierte el orden en que fueron declarados */
			IEnumerable<string> resultado = Cadenas.Reverse();
			Console.WriteLine("Invierte el orden");
			foreach (string valor in resultado) {
				Console.WriteLine("[" + valor + "] ");
			}
		}
	}
}