namespace Ejemplo;

//Esta es una clase propia con
//sus atributos y métodos (encapsulación)
class MiClase {
	//Un constructor
	public MiClase(int Numero, char Letra, string Cadena, double Valor) {
		//Se asigna así this.atributo = valor parámetro
		this.Numero = Numero;
		this.Letra = Letra;
		this.Cadena = Cadena;
		this.Valor = Valor;
	}

	//Otra forma de definir atributos con los getters y setters
	public int Numero { get; set; }
	public char Letra { get; set; }
	public string Cadena { get; set; }
	public double Valor { get; set; }
}

//Inicia la aplicación aquí
class Program {
	static void Main() {
		//Instancia o crea un objeto de MiClase
		//llamando el constructor
		MiClase Mascotas = new(2016, 'T', "Tammy", 12.17);

		//Se imprimen los valores de ambas variables
		Console.WriteLine("Letra en Mascotas es: " + Mascotas.Letra);
		Console.WriteLine("Valor en Mascotas es: " + Mascotas.Valor);
	}
}