namespace Ejemplo {
	internal class Program {
		static void Main() {
			double valA = 1 + 2 + 3; //Operador suma
			double valB = 4 - 5 - 6; //Operador resta
			double valC = 7 * 8 * 9; //Operador multiplicación
			double valD = 178 / 2 / 3; //Operador división usando enteros
			double valE = 178 / 2.0 / 3.0; //Operador división usando números reales
			double valF = (double) 178 / 2 / 3; //Operador división usando números enteros haciendo cast
			double valG = 70 % 6; //Operador división modular

			Console.WriteLine("Valor A es: {0:0.0000}", valA);
			Console.WriteLine("Valor B es: {0:0.0000}", valB);
			Console.WriteLine("Valor C es: {0:0.0000}", valC);
			Console.WriteLine("Valor D es: {0:0.0000}", valD);
			Console.WriteLine("Valor E es: {0:0.0000}", valE);
			Console.WriteLine("Valor F es: {0:0.0000}", valF);
			Console.WriteLine("Valor G es: {0:0.0000}", valG);
		}
	}
}