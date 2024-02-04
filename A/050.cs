namespace Ejemplo {
	internal class Program {
		static void Main() {

			for (int numA = 1; numA <= 3; numA++) {
				for (int numB = 1; numB <= 6; numB++) {
					for (int numC = 1; numC <= 9; numC++) {
						Console.WriteLine(numA.ToString() + "|" + numB.ToString() + "|" + numC.ToString());
						if (numC == 5) goto afuera; //Sale de todos los ciclos
					}
				}
			}

			afuera:  Console.WriteLine("Final");
		}
	}
}