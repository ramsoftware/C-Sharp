namespace Ejemplo {
	//Esta es una clase propia con sus atributos
	//y métodos (encapsulación)
	class MiClase {
		//Atributos privados
		private int numero;
		private char letra;
		private string cadena;
		private double valor;

		//Los getters y setters
		public int Numero { get => numero; set => numero = value; }
		public char Letra { get => letra; set => letra = value; }
		public string Cadena { get => cadena; set => cadena = value; }
		public double Valor { get => valor; set => valor = value; }
	}

	//Inicia la aplicación aquí
	class Program {
		static void Main() {
			//Instancia o crea un objeto de MiClase
			MiClase Objeto = new();

			//Llama los setters
			Objeto.Cadena = "Suini, Capuchina, Grisú, Milú";
			Objeto.Numero = 7;
			Objeto.Letra = 'R';
			Objeto.Valor = 16.83;

			//Usa los getters
			Console.WriteLine(Objeto.Letra);
			Console.WriteLine(Objeto.Valor);
			Console.WriteLine(Objeto.Cadena);
			Console.WriteLine(Objeto.Numero);
		}
	}
}