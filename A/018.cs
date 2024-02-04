namespace Ejemplo {
	internal class Program {
		static void Main() {
			//Falla porque se interpreta como operación de enteros
			double valA = (4 / 3) + (1 / 2) - (25 / 4);

			//Falla porque el cast solo cubre la primera operación
			double valB = (double)4 / 3 + (1 / 2) - (25 / 4);

			//Operación correcta
			double valC = (4.0 / 3.0) + (1.0 / 2.0) - (25.0 / 4.0);

			//Operación correcta pero se deben usar varios cast
			double valD = (double)4 / 3 + (double)1 / 2 - (double)25 / 4;

			//Falla porque el cast solo cubre la primera operación
			double valE = (double)4 / 3 + 1 / 2 - 25 / 4;

			Console.WriteLine("Valor A es: " + valA.ToString());
			Console.WriteLine("Valor B es: " + valB.ToString());
			Console.WriteLine("Valor C es: " + valC.ToString());
			Console.WriteLine("Valor D es: " + valD.ToString());
			Console.WriteLine("Valor E es: " + valE.ToString());
		}
	}
}