namespace Ejemplo;

internal class Program {
	static void Main() {
		//Declara variables de tipo double
		double valA = 17902.8421;
		double valB = -871901372.420821098765;
		double valC = 89341759342.1678;

		//Imprime con un formato de miles
		Console.WriteLine("Impresión con formato de miles y 3 decimales");
		Console.WriteLine("Valor A: {0:0,0.0}", valA);
		Console.WriteLine("Valor A: {0:0,0.000}", valA);

		Console.WriteLine("\r\nValor B: {0:0,0.0}", valB);
		Console.WriteLine("Valor B: {0:0,0.000}", valB);

		Console.WriteLine("\r\nValor C: {0:0,0.0}", valC);
		Console.WriteLine("Valor C: {0:0,0.000}", valC);
	}
}