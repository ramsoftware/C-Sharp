namespace Ejemplo {
	internal class Program {
		static void Main() {
			//Declara variables de tipo float, hay que usar el cast (float)
			float valA = (float) 5.718987654321;
			float valB = (float) 3.420321098765;
			float valC = (float) 1.23456789012345678901234567890123456789012345678901234567890123456789;

			//Imprime esas variables
			Console.WriteLine("Valor A es: " + valA.ToString());
			Console.WriteLine("Valor B es: " + valB.ToString());
			Console.WriteLine("Valor C es: " + valC.ToString());
		}
	}
}