namespace Ejemplo {
	internal class Program {
		static void Main() {
			/* Orden de evaluación de los operadores:
			 * Primero potencia
			 * Segundo multiplicación y división
			 * Tercero suma y resta
			 * */
			double valA = (double)7 - 1 + 2 * Math.Pow(2, 5);
			double valB = (double)1 + 2 * 3 / 4 - 5;
			double valC = (double)3 + 5 - 2 * 4 / 8;
			double valD = (double)3 * 2 + Math.Pow(3, 2);

			Console.WriteLine("Valor A: " + valA);
			Console.WriteLine("Valor B: " + valB);
			Console.WriteLine("Valor C: " + valC);
			Console.WriteLine("Valor D: " + valD);
		}
	}
}