namespace Ejemplo;

//Clase con métodos estáticos
class Geometria {
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
class Program {
	static void Main() {
		//Acediendo a métodos estáticos
		double AreaUnCirculo = Geometria.AreaCirculo(7);
		Console.WriteLine("Área círculo es: " + AreaUnCirculo);

		//Accediendo a atributos estáticos
		Console.WriteLine("Cadena es: " + Geometria.unaCadena);
		Console.WriteLine("Valor entero es: " + Geometria.valorEntero);
		Console.WriteLine("Valor real es: " + Geometria.valorReal);

		//Se instancia la clase
		Geometria objGeometria = new Geometria();
		double Esfera = objGeometria.VolumenEsfera(7);
		Console.WriteLine("Volumen Esfera: " + Esfera);
	}
}