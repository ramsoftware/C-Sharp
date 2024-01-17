namespace Ejemplo {
	internal class Program {
		static void Main() {
			//Compara la precisión entre float y double
			float valA = (float)(1.7 / 2.8 * 4.8 / 6.7 / 5.3);
			double valB = 1.7 / 2.8 * 4.8 / 6.7 / 5.3;
			decimal valC = (decimal) 1.7 / (decimal) 2.8 * (decimal) 4.8 / (decimal) 6.7 / (decimal) 5.3;

			Console.WriteLine("Valor A es: " + valA.ToString());
			Console.WriteLine("Valor B es: " + valB.ToString());
			Console.WriteLine("Valor C es: " + valC.ToString());
		}
	}
}