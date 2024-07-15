namespace Ejemplo {
	//Esta es una clase propia con sus atributos
	//y métodos (encapsulación)
	class MiClase {
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
			MiClase Objeto = new();

			//Llama los setters
			Objeto.Cadena = "Suini, Capuchina, Grisú, Milú";
			Objeto.Cadena += ", Sally, Vikingo, Arian, Frac";
			Objeto.Numero = 7;
			Objeto.Letra = 'R';
			Objeto.Valor = 93.5;

			//Usa los getters
			Console.WriteLine(Objeto.Letra);
			Console.WriteLine(Objeto.Valor);
			Console.WriteLine(Objeto.Cadena);
			Console.WriteLine(Objeto.Numero);
		}
	}
}
