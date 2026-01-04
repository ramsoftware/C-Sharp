namespace Ejemplo;

internal class Program {
	static void Main() {
		List<string> Animales = ["Gato", "Condor", "Perro", "Conejo", "Loro"];

		List<string> Mamiferos = ["Perro", "Conejo", "Gato"];

		/* Extrae los animales que no están en mamíferos */
		List<string> Resultado = Animales.Except(Mamiferos).ToList();

		for (int Cont = 0; Cont < Resultado.Count; Cont++) {
			Console.WriteLine(Resultado[Cont]);
		}
	}
}