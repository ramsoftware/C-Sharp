namespace Ejemplo;

//Clase estática, no necesita instanciarse
static class Geometria {
	//Todos los métodos deben ser static
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
}

//Inicia la aplicación aquí
internal class Program {
	static void Main() {
		//Hace uso de la clase sin instanciarla
		double unRadio = 7;
		double AreaUnCirculo = Geometria.AreaCirculo(unRadio);
		Console.WriteLine("Área círculo es: " + AreaUnCirculo);

		double AreaTri = Geometria.AreaTriangulo(3, 4, 5);
		Console.WriteLine("Área triángulo es: " + AreaTri);
	}
}