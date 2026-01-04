namespace Ejemplo;

internal class Program {
	static void Main() {
		//Una lista de cadenas
		List<string> Cadenas = [ "gato", "perro", "avestruz", "toro",
							"ballena", "kakapo" ];

		/* Se ordena usando LINQ
			 * Ordena por la segunda letra. */
		List<string> Resultado = Cadenas.OrderBy(str => str).ToList();
		Resultado.Reverse();
		Console.WriteLine("Orden inverso");
		for (int Cont = 0; Cont < Resultado.Count; Cont++)
			Console.WriteLine("[" + Resultado[Cont] + "] ");
	}
}