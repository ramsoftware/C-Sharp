namespace Ejemplo {
	internal class Program {
		static void Main() {
			// Genera un NaN: Not a Number
			double valorReal = -70;
			double valLogaritmoNatural = Math.Log(valorReal);
			double valLogaritmoBase10 = Math.Log10(valorReal);
			double valRaizC = Math.Sqrt(valorReal); //raiz cuadrada
			double arcoSeno = Math.Asin(valorReal);
			double arcoCoseno = Math.Acos(valorReal);

			Console.WriteLine("Valor: " + valorReal.ToString());
			Console.WriteLine("Logaritmo Natural es: " + valLogaritmoNatural.ToString());
			Console.WriteLine("Logaritmo Base 10 es: " + valLogaritmoBase10.ToString());
			Console.WriteLine("Raiz cuadrada es: " + valRaizC.ToString());
			Console.WriteLine("Arcoseno es: " + arcoSeno.ToString());
			Console.WriteLine("Arcocoseno es: " + arcoCoseno.ToString());

			//Genera infinito positivo
			float valA = 10;
			float valB = 0;
			float valC = valA / valB;
			Console.WriteLine("Valor C es: " + valC);

			//Genera infinito negativo
			valA = -10;
			valB = 0;
			valC = valA / valB;
			Console.WriteLine("Valor C es: " + valC);
		}
	}
}