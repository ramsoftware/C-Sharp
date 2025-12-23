namespace Ejemplo;

internal class Program {
	static void Main() {
		//Lee los lados de un triángulo
		Console.Write("Escriba valor lado A: ");
		double ladoA = Convert.ToDouble(Console.ReadLine());

		Console.Write("Escriba valor lado B: ");
		double ladoB = Convert.ToDouble(Console.ReadLine());

		Console.Write("Escriba valor lado C: ");
		double ladoC = Convert.ToDouble(Console.ReadLine());

		//Si condicional, uso del AND &&
		if (ladoA == ladoB && ladoA == ladoC) {
			Console.WriteLine("Triángulo equilátero");
		}
		else if (ladoA != ladoB && ladoA != ladoC && ladoB != ladoC) {
			Console.WriteLine("Triángulo escaleno");
		}
		else {
			Console.WriteLine("Triángulo isósceles");
		}
	}
}