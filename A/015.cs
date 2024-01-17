namespace Ejemplo {
	internal class Program {
		static void Main() {
			//Potencia (^)
			double valA = Math.Pow(2, 5); // 2 ^ 5 
			double valB = Math.Pow(729, (double)1 / 3); //Raíz cúbica de 729
			double valC = Math.Pow(64, (double)1 / 2); //Raíz cuadrada de 64
			double valD = Math.Pow(4, -2); // 4^(-2) = 1/(4^2) = 1/16
			double valE = Math.Pow(4, 0); // 4^0

			Console.WriteLine("Valor A es: " + valA.ToString());
			Console.WriteLine("Valor B es: " + valB.ToString());
			Console.WriteLine("Valor C es: " + valC.ToString());
			Console.WriteLine("Valor D es: " + valD.ToString());
			Console.WriteLine("Valor E es: " + valE.ToString());
		}
	}
}