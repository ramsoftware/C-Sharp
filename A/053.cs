namespace Ejemplo {
	internal class Program {
		static void Main() {
			//Uso de funciones
			double ladoA = 3;
			double ladoB = 4;
			double ladoC = 5;
			double Area = AreaTrianguloHeron(ladoA, ladoB, ladoC);
			Console.WriteLine("Area triángulo es: " + Area.ToString());
		}

		//Fórmula de Herón para el cálculo del área de un triángulo dado los lados
		static double AreaTrianguloHeron(double valA, double valB, double valC) {
			double s = (valA + valB + valC) / 2;
			double area = Math.Sqrt(s * (s - valA) * (s - valB) * (s - valC));
			return area;
		}
	}
}