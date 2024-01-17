namespace Ejemplo {
	//Esta es una clase propia con sus atributos y métodos (encapsulación)
	internal class MiClase {
		//Un constructor
		public MiClase(int Numero, char Letra, string Cadena, double Valor) {
			this.Numero = Numero; //Se asigna así this.atributo = valor parámetro
			this.Letra = Letra;
			this.Cadena = Cadena;
			this.Valor = Valor;
		}

		//Método que permite copiar un objeto
		public MiClase CopiarObjeto() {
			MiClase copia = new MiClase(Numero, Letra, Cadena, Valor);
			return copia;
		}

		//Otra forma de definir atributos con los getters y setters
		public int Numero { get; set; }
		public char Letra { get; set; }
		public string Cadena { get; set; }
		public double Valor { get; set; }
	}

	//Inicia la aplicación aquí
	internal class Program {
		static void Main() {
			//Instancia o crea un objeto de MiClase llamando el constructor
			MiClase Mascotas = new MiClase(2016, 'T', "Tammy", 12.17);

			//Hace una copia de ese objeto
			MiClase UnaCopia = Mascotas.CopiarObjeto();

			//Se imprimen los valores de los dos objetos
			Console.WriteLine("Después de copiar");
			Console.WriteLine("Cadena en Mascotas es: " + Mascotas.Cadena);
			Console.WriteLine("Cadena en UnaCopia es: " + UnaCopia.Cadena);

			//Cambia el valor de cadena en UnaCopia
			UnaCopia.Cadena = "Krousky";

			//Imprime de nuevo los valores
			Console.WriteLine("\r\nDespués de cambiar la cadena");
			Console.WriteLine("Cadena en Mascotas es: " + Mascotas.Cadena);
			Console.WriteLine("Cadena en UnaCopia es: " + UnaCopia.Cadena);
		}
	}
}
