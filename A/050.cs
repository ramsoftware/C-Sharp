namespace Ejemplo {
	internal class Program {
		static void Main() {

			for (int numA = 1; numA <= 3; numA++) {
				for (int numB = 1; numB <= 6; numB++) {
					for (int numC = 1; numC <= 9; numC++) {
						Console.Write(numA + "|");
						Console.WriteLine(numB + "|" + numC);
						 //Sale de todos los ciclos
						if (numC == 5) goto afuera;
					}
				}
			}

			afuera:  Console.WriteLine("Final");
		}
	}
}