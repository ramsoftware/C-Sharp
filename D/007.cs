namespace Ejemplo;

//Esta es una clase propia con sus
//atributos y métodos (encapsulación)
class MiClase {
	//Otra forma de definir atributos con
	//los getters y setters
	public int Numero { get; set; }
	public char Letra { get; set; }
	public string Cadena { get; set; }
	public double Valor { get; set; }
}

//Inicia la aplicación aquí
class Program {
	static void Main() {
		//Instancia o crea un objeto de MiClase.
		MiClase Mascotas = new MiClase {
			Cadena = "Suini, Capuchina, Grisú, Milú",
			Numero = 7,
			Letra = 'R',
			Valor = 93.5
		};

		//Crea una variable de tipo MiClase
		MiClase otra;

		//Asigna el primer objeto a esa variable
		otra = Mascotas;

		//¿Qué sucede? Que tenemos dos variables
		//apuntando al mismo objeto en memoria

		//Se imprimen los valores de ambas variables
		Console.WriteLine("Letra en Mascotas: " + Mascotas.Letra);
		Console.WriteLine("Valor en Mascotas: " + Mascotas.Valor);
		Console.WriteLine("Letra en otraVariable: " + otra.Letra);
		Console.WriteLine("Valor en otraVariable: " + otra.Valor);

		//Si se modifican los valores en "otra"
		//afecta a Mascotas porque ambas apuntan
		//al mismo objeto en memoria
		otra.Valor = 12345.67;
		Console.WriteLine("Nuevo Valor: " + Mascotas.Valor);
	}
}