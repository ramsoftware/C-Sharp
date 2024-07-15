namespace Ejemplo {
	internal class Program {
		static void Main() {
			//Uso de funciones
			double ladoA = 3;
			double ladoB = 4;
			double ladoC = 5;
			bool Posible = TrianguloPosible(ladoA, ladoB, ladoC);
			Console.WriteLine("Posibilidad del triángulo: " + Posible);
		}

		//Retorna true si el triángulo es posible
		static bool TrianguloPosible(double valA, double valB, double valC) {
			return valA + valB >= valC && 
					valA + valC >= valB &&
					valB + valC >= valA;
		}
	}
}