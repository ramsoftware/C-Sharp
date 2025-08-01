namespace Ejemplo {
	class Geometria {
		//Calcula el área del círculo
		public double Area(double radio) {
			return Math.PI * Math.Pow(radio, 2);
		}

		//Calcula el área del rectángulo
		public double Area(double baseR, double alturaR) {
			return baseR * alturaR;
		}

		//Calcula el área del triángulo
		public double Area(double ladoA, double ladoB, double ladoC) {
			double S = (ladoA + ladoB + ladoC) / 2;
			return Math.Sqrt(S * (S - ladoA) * (S - ladoB) * (S - ladoC));
		}
	}

	//Inicia la aplicación aquí
	class Program {
		static void Main() {
			//Instancia o crea un objeto Geometria
			Geometria geometria = new();

			//Dependiendo del número de parámetros
			//llama a un método u otro
			double areaCirculo = geometria.Area(8);
			double areaTriangulo = geometria.Area(4, 5, 6);
			double areaRectangulo = geometria.Area(17, 19);

			Console.WriteLine("Área del círculo: " + areaCirculo);
			Console.WriteLine("Área del triángulo: " + areaTriangulo);
			Console.WriteLine("Área del rectángulo: " + areaRectangulo);
		}
	}
}
