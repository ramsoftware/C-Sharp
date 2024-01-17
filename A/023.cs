namespace Ejemplo {
	internal class Program {
		static void Main() {
			//Constantes matemáticas
			double valA = Math.PI;
			double valB = Math.E;
			Console.WriteLine("PI es: " + valA.ToString());
			Console.WriteLine("E es: " + valB.ToString());

			//Máximo y mínimo valor entero
			int maximoEntero = int.MaxValue;
			int minimoEntero = int.MinValue;
			Console.WriteLine("Máximo entero: " + maximoEntero.ToString());
			Console.WriteLine("Mínimo entero: " + minimoEntero.ToString());

			//Máximo y mínimo valor float
			float maximofloat = float.MaxValue;
			float minimofloat = float.MinValue;
			float minimoCero = float.Epsilon; //El mínimo valor antes de ser cero
			Console.WriteLine("Máximo float: " + maximofloat.ToString());
			Console.WriteLine("Mínimo float: " + minimofloat.ToString());
			Console.WriteLine("El mínimo float antes de ser cero: " + minimoCero.ToString());

			//Máximo y mínimo valor double
			double maximodouble = double.MaxValue;
			double minimodouble = double.MinValue;
			double minimoCerodouble = double.Epsilon; //El mínimo valor antes de ser cero
			Console.WriteLine("Máximo double: " + maximodouble.ToString());
			Console.WriteLine("Mínimo double: " + minimodouble.ToString());
			Console.WriteLine("El mínimo double antes de ser cero: " + minimoCerodouble.ToString());
		}
	}
}