namespace Ejemplo {
	internal class Program {
		static void Main() {
			//Generando números al azar.

			//La semilla del generador la define el .NET
			Random azar = new();

			//Números enteros al azar
			Console.Write("Enteros positivos: ");
			for (int Contador = 1; Contador <= 10; Contador++) {
				int numEntero = azar.Next();
				Console.Write(numEntero + " | ");
			}

			//Números entre 0 y 1 al azar
			Console.Write("\r\n\r\nReales: ");
			for (int Contador = 1; Contador <= 10; Contador++) {
				double numReal = azar.NextDouble();
				Console.Write(numReal + " | ");
			}

			//Números entre 15 y 44 al azar.
			Console.Write("\r\n\r\nEnteros positivos entre 15 y 44: ");
			for (int Contador = 1; Contador <= 10; Contador++) {
				//El segundo parámetro debe ser +1 del
				//rango máximo que se busca
				int numEntero = azar.Next(15, 45);
				Console.Write(numEntero + " | ");
			}

			//Generando los mismos valores
			Console.Write("\r\n\r\nGenerando los mismos valores");
			Console.Write("al usar la misma semilla: ");
			Random AleatorioA = new(500);
			Random AleatorioB = new(500);
			for (int Contador = 1; Contador <= 20; Contador++) {
				int numA = AleatorioA.Next(55, 95);
				int numB = AleatorioB.Next(55, 95);
				Console.Write(numA + " y " + numB + " | ");
			}

			Console.WriteLine(" Final");
		}
	}
}