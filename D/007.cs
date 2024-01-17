namespace Ejemplo {
	//Esta es una clase propia con sus atributos y métodos (encapsulación)
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
			//Instancia o crea un objeto de MiClase.
			MiClase Mascotas = new MiClase {
				Cadena = "Suini, Capuchina, Grisú, Milú, Sally, Vikingo",
				Numero = 7,
				Letra = 'R',
				Valor = 93.5
			};

			//Crea una variable de tipo MiClase
			MiClase otraVariable;

			//Asigna el primer objeto a esa variable
			otraVariable = Mascotas;

			//¿Qué sucede? Que tenemos dos variables apuntando al mismo objeto en memoria

			//Se imprimen los valores de ambas variables
			Console.WriteLine("Letra en Mascotas es: " + Mascotas.Letra.ToString());
			Console.WriteLine("Valor en Mascotas es: " + Mascotas.Valor.ToString());
			Console.WriteLine("Letra en otraVariable es: " + otraVariable.Letra.ToString());
			Console.WriteLine("Valor en otraVariable es: " + otraVariable.Valor.ToString());

			//Si se modifican los valores en otraVariable afecta a Mascotas
			//porque ambas apuntan al mismo objeto en memoria
			otraVariable.Valor = 12345.67;
			Console.WriteLine("Nuevo Valor en Mascotas es: " + Mascotas.Valor.ToString());
		}
	}
}
