namespace Ejemplo;

internal class Program {
	static void Main() {
		//Leer un número por consola
		Console.Write("Escriba un número: ");
		double valorReal = Convert.ToDouble(Console.ReadLine());
		Console.WriteLine("Escribió: " + valorReal);
	}
}