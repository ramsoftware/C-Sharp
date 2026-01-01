namespace Ejemplo;

//Declara una interface (el estándar
//dice que debe empezar con la letra "I")
interface ICalculos {
	//Métodos requeridos en las clases
	//que implementen esta interface
	double Area();
	double Perimetro();

}

//Otra interface para obligar a mostrar los resultados
interface IMuestra {
	void VerArea();
	void VerPerimetro();
}

//Implementa de varios Interface
class Circulo : ICalculos, IMuestra {
	public double Radio { get; set; }

	public Circulo(double Radio) {
		this.Radio = Radio;
	}

	//Implementa los métodos señalados por la interface
	public double Area() {
		return Math.PI * Radio * Radio;
	}

	public double Perimetro() {
		return 2 * Math.PI * Radio;
	}

	public void VerArea() {
		Console.WriteLine("Área círculo: " + Area());
	}

	public void VerPerimetro() {
		Console.WriteLine("Perímetro círculo: " + Perimetro());
	}
}

class Cuadrado : ICalculos, IMuestra {
	public double Lado { get; set; }

	public Cuadrado(double Lado) {
		this.Lado = Lado;
	}

	//Implementa los métodos señalados por la interface
	public double Area() {
		return Lado * Lado;
	}

	public double Perimetro() {
		return 4 * Lado;
	}

	public void VerArea() {
		Console.WriteLine("Área cuadrado: " + Area());
	}

	public void VerPerimetro() {
		Console.WriteLine("Perímetro cuadrado: " + Perimetro());
	}
}

//Inicia la aplicación aquí
class Program {
	static void Main() {
		//Instancia las clases
		Cuadrado objCuadrado = new(5);
		Circulo objCirculo = new(5);

		//Imprime los valores
		objCuadrado.VerArea();
		objCuadrado.VerPerimetro();

		objCirculo.VerArea();
		objCirculo.VerPerimetro();
	}
}