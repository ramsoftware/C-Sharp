namespace Ejemplo;
//Patrón de diseño: Facade

interface IFigura {
	void Dibujar();
}

class Circulo : IFigura {
	public void Dibujar() {
		Console.WriteLine("Dibujando un círculo");
	}
}

class Rectangulo : IFigura {
	public void Dibujar() {
		Console.WriteLine("Traza un rectángulo");
	}
}

class Triangulo : IFigura {
	public void Dibujar() {
		Console.WriteLine("Delinea un triángulo");
	}
}

class HacerFigura {
	private IFigura circulo;
	private IFigura rectangulo;
	private IFigura triangulo;

	public HacerFigura() {
		circulo = new Circulo();
		rectangulo = new Rectangulo();
		triangulo = new Triangulo();
	}

	public void DibujaCirculo() {
		circulo.Dibujar();
	}

	public void DibujaRectangulo() {
		rectangulo.Dibujar();
	}

	public void DibujaTriangulo() {
		triangulo.Dibujar();
	}
}

class Program {
	static void Main() {
		HacerFigura hacefigura = new();

		hacefigura.DibujaCirculo();
		hacefigura.DibujaRectangulo();
		hacefigura.DibujaTriangulo();
	}
}