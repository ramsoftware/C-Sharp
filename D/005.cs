namespace Ejemplo {
	//Esta es una clase propia con sus
	//atributos y métodos (encapsulación)
	class MiClase {
		//Atributos privados. Un uso de los getters y setters
		private int edad;

		//Puede validar el dato de inicialización
		public int Edad {
			get {
				return edad;
			}
			set {
				if (value < 0)
					Console.WriteLine("Error: edad negativa");
				else
					edad = value;
			}
		}
	}

	//Inicia la aplicación aquí
	class Program {
		static void Main() {
			//Instancia o crea un objeto de MiClase
			MiClase Objeto = new();
			MiClase Otro = new();

			//Llama los setters
			Objeto.Edad = 17;
			Otro.Edad = -8;

			Console.WriteLine("Edad es: " + Objeto.Edad);
			Console.WriteLine("Edad es: " + Otro.Edad);
		}
	}
}
