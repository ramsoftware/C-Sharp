namespace Ejemplo;

internal class Program {
	static void Main() {
		//Potencia (^)
		double valA = Math.Pow(2, 5);

		//Raíz cúbica de 729
		double valB = Math.Pow(729, (double)1 / 3);

		//Raíz cuadrada de 64
		double valC = Math.Pow(64, (double)1 / 2);

		// 4^(-2) = 1/(4^2) = 1/16
		double valD = Math.Pow(4, -2);

		// 4^0
		double valE = Math.Pow(4, 0);

		Console.WriteLine("Valor A es: " + valA);
		Console.WriteLine("Valor B es: " + valB);
		Console.WriteLine("Valor C es: " + valC);
		Console.WriteLine("Valor D es: " + valD);
		Console.WriteLine("Valor E es: " + valE);
	}
}