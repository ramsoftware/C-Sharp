namespace Ejemplo {
	internal class Program {
		static void Main() {
			//Constantes matemáticas
			double valA = Math.PI;
			double valB = Math.E;
			Console.WriteLine("PI es: " + valA);
			Console.WriteLine("E es: " + valB);

			//Máximo y mínimo valor entero
			int maximoEntero = int.MaxValue;
			int minimoEntero = int.MinValue;
			Console.WriteLine("Máximo entero: " + maximoEntero);
			Console.WriteLine("Mínimo entero: " + minimoEntero);

			//Máximo y mínimo valor float
			float maximofloat = float.MaxValue;
			float minimofloat = float.MinValue;
			float minimoCero = float.Epsilon; //El mínimo valor antes de ser cero
			Console.WriteLine("Máximo float: " + maximofloat);
			Console.WriteLine("Mínimo float: " + minimofloat);
			Console.WriteLine("El mínimo float antes de ser cero: " + minimoCero);

			//Máximo y mínimo valor double
			double maximodouble = double.MaxValue;
			double minimodouble = double.MinValue;
			
			//El mínimo valor antes de ser cero
			double CeroE = double.Epsilon;
			
			Console.WriteLine("Máximo double: " + maximodouble);
			Console.WriteLine("Mínimo double: " + minimodouble);
			Console.WriteLine("El mínimo double antes de ser cero: " + CeroE);
		}
	}
}