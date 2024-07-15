namespace Ejemplo {
	//Clase con métodos estáticos
	internal class Geometria {
		//Estos métodos estáticos pueden ser usados sin instanciar la clase
		public static double AreaTriangulo(double baseT, double alturaT) {
			return baseT * alturaT / 2;
		}

		public static double AreaTriangulo(double ladoA, double ladoB,
											double ladoC) {
			double s = (ladoA + ladoB + ladoC) / 2;
			return Math.Sqrt(s * (s - ladoA) * (s - ladoB) * (s - ladoC));
		}

		public static double AreaCirculo(double radio) {
			return Math.PI * radio * radio;
		}

		//Este método requiere instanciar la clase
		public double VolumenEsfera(double radio) {
			return 4 / 3 * Math.PI * Math.Pow(radio, 3);
		}
	}

	//Inicia la aplicación aquí
	internal class Program {
		static void Main() {
			double unRadio = 7;
			double AreaUnCirculo = Geometria.AreaCirculo(unRadio);
			Console.WriteLine("Área círculo es: " + AreaUnCirculo);

			double AreaTri = Geometria.AreaTriangulo(3, 4, 5);
			Console.WriteLine("Área triángulo es: " + AreaTri);

			//Instancio la clase
			Geometria objGeometria = new();
			double Esfera = objGeometria.VolumenEsfera(7);
			Console.WriteLine("Volumen Esfera: " + Esfera);
		}
	}
}
