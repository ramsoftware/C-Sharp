namespace Ejemplo {
	internal class Program {
		static void Main() {
			//Una cadena
			string[] Cad = { "gato", "perro", "avestruz",
								"toro", "ballena", "kakapo" };

			/* Se ordena usando Linq
			 * Ordena por tamaño de las cadenas. */
			List<string> Resultado = Cad.OrderBy(str => str.Length).ToList();

			Console.WriteLine("Ordenado por tamaño");
			for (int Cont = 0; Cont < Resultado.Count; Cont++)
				Console.WriteLine("[" + Resultado[Cont] + "] ");
		}
	}
}
