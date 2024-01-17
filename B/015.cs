namespace Ejemplo {
	internal class Program {
		static void Main() {
			//Comparar cadenas
			string cadenaA = "abcdefghij";
			string cadenaB = "Abcdefghij";
			string cadenaC = "abcdefghij ";
			string cadenaD = "abcdefg hij";

			//Forma 1 de comparar. No recomendada.
			if (cadenaA == cadenaB) 
				Console.WriteLine("1. Iguales");
			else
				Console.WriteLine("1. Diferentes");

			if (cadenaA == cadenaC)
				Console.WriteLine("2. Iguales");
			else
				Console.WriteLine("2. Diferentes");

			if (cadenaA == cadenaD)
				Console.WriteLine("3. Iguales");
			else
				Console.WriteLine("3. Diferentes");
		}
	}
}
