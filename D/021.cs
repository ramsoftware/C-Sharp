namespace Ejemplo {
	class Abuela {
		//Constructor
		public Abuela() {
			Console.WriteLine("Constructor de la clase abuela");
		}

		//Método
		public void Mostrar() {
			Console.WriteLine("Mostrar en Abuela");
		}
	}

	class Madre : Abuela {
		//Constructor
		public Madre() {
			Console.WriteLine("Constructor de la clase madre");
		}

		public new void Mostrar() {
			Console.WriteLine("Mostrar en Madre");
		}
	}

	class Hija : Madre {
		//Constructor
		public Hija() {
			Console.WriteLine("Constructor de la clase hija");
		}
		public new void Mostrar() {
			Console.WriteLine("Mostrar en Hija");
		}
	}

	//Inicia la aplicación aquí
	class Program {
		static void Main() {
			//Instancia a la hija
			Hija objHija = new Hija();

			//Ejecuta método
			objHija.Mostrar();
		}
	}
}