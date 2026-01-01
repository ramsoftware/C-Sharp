namespace Ejemplo;

//Declara una interface (el estándar dice
//que debe empezar con la letra "I")
interface IMetodosRequeridos {
	//Métodos requeridos en las clases que
	//implementen esta interface
	double Area();
	double Perimetro();
}

//Esta clase debe implementar lo que dice la interface
class Circulo : IMetodosRequeridos {
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
}

//Esta clase debe implementar lo que dice la interface
class Cuadrado : IMetodosRequeridos {
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
}

//Inicia la aplicación aquí
class Program {
	static void Main() {
		//Instancia las clases
		Cuadrado cuad = new(5);
		Circulo circ = new(5);

		//Imprime los valores
		Console.WriteLine("Área círculo: " + circ.Area());
		Console.WriteLine("Área cuadrado: " + cuad.Area());
		Console.WriteLine("Perímetro círculo: " + circ.Perimetro());
		Console.WriteLine("Perímetro cuadrado: " + cuad.Perimetro());
	}
}