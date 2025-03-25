namespace Ejemplo {
	internal class Program {
		static void Main() {
			List<string> Cadenas = [ "gato", "perro", "avestruz", "toro",
													  "ballena", "kakapo" ];

			IEnumerable<string> resultado = Cadenas.AsEnumerable().Reverse();
			Console.WriteLine("Invierte el orden");
			foreach (string valor in resultado) {
				Console.WriteLine("[" + valor + "] ");
			}
		}
	}
}