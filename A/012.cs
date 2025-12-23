namespace Ejemplo;

internal class Program {
	static void Main() {
		//Declara variables de tipo double
		double valA = 2.76;
		double valB = 2.04;
		double valC = 0.14;

		//Imprime solo si la cifra es significativa
		//redondea también.
		Console.WriteLine("Valor A (redondea): {0:#.#}", valA);
		Console.WriteLine("Valor B (redondea): {0:#.#}", valB);
		Console.WriteLine("Valor C (redondea): {0:#.#}", valC);
	}
}