namespace Ejemplo;

internal class Program {
	static void Main() {
		//Funciones hiperbólicas
		double valorReal = -5.4713;

		double valSenoH = Math.Sinh(valorReal);
		double valCosenoH = Math.Cosh(valorReal);
		double valTangenteH = Math.Tanh(valorReal);

		Console.WriteLine("Valor: " + valorReal);
		Console.WriteLine("Seno hiperbólico: " + valSenoH);
		Console.WriteLine("Coseno hiperbólico: " + valCosenoH);
		Console.WriteLine("Tangente hiperbólico: " + valTangenteH);
	}
}