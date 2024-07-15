namespace Ejemplo {
	internal class Program {
		static void Main() {
			//Comparar cadenas
			string cadenaA = "abcdefghij";
			string cadenaB = "Abcdefghij";
			string cadenaC = "aBCDEfghiJ";
			string cadenaD = "ABCDEFGHIj";

			//Forma 2 de comparar ignorando mayúsculas y minúsculas
			if (cadenaA.Equals(cadenaB, StringComparison.OrdinalIgnoreCase)) 
				Console.WriteLine("1. Iguales");
			else
				Console.WriteLine("1. Diferentes");

			if (cadenaA.Equals(cadenaC, StringComparison.OrdinalIgnoreCase))
				Console.WriteLine("2. Iguales");
			else
				Console.WriteLine("2. Diferentes");

			if (cadenaA.Equals(cadenaD, StringComparison.OrdinalIgnoreCase))
				Console.WriteLine("3. Iguales");
			else
				Console.WriteLine("3. Diferentes");
		}
	}
}

//Más información: https://docs.microsoft.com/en-us/dotnet/csharp/how-to/compare-strings 