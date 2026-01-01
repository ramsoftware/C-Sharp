namespace Ejemplo;

//Clase con métodos estáticos
internal class Geometria {
	public static int valorEntero;
	public static double valorReal;
	public static string unaCadena;

	//Constructor static (para inicializar atributos static)
	static Geometria() {
		valorEntero = 7;
		valorReal = 16.832;
		unaCadena = "Rafael";
		Console.WriteLine("Se ha ejecutado el constructor static");
	}

	//Constructor de clase
	public Geometria() {
		Console.WriteLine("Ejecuta el constructor de la clase");
	}

	//Este método estático puede ser usado sin instanciar la clase
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
		//Se instancia la clase la primera vez
		Geometria objGeometria = new();
		double Esfera = objGeometria.VolumenEsfera(7);
		Console.WriteLine("Volumen Esfera A: " + Esfera);

		//Se instancia la clase la segunda vez
		Geometria objOtro = new();
		double OtraEsfera = objOtro.VolumenEsfera(7);
		Console.WriteLine("Volumen Esfera B: " + OtraEsfera);
	}
}