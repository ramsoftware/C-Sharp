namespace Ejemplo {
	//Esta es una clase propia con sus atributos y métodos (encapsulación)
	class MiClase {
		//Atributos privados. Un uso de los getters y setters
		private int numero;
		private char letra;
		private string cadena;
		private double valor;

		//Puede auditar cuando se leyó o cambió el valor de un atributo
		public int Numero {
			get {
				Console.WriteLine("Lee numero: " + DateTime.Now.ToString("yyyy-MM-dd h:mm:ss tt"));
				return numero;
			}
			set {
				Console.WriteLine("Cambia numero: " + DateTime.Now.ToString("yyyy-MM-dd h:mm:ss tt"));
				numero = value;
			}
		}

		public char Letra {
			get {
				Console.WriteLine("Lee letra: " + DateTime.Now.ToString("yyyy-MM-dd h:mm:ss tt"));
				return letra;
			}
			set {
				Console.WriteLine("Cambia letra: " + DateTime.Now.ToString("yyyy-MM-dd h:mm:ss tt"));
				letra = value;
			}
		}

		public string Cadena {
			get {
				Console.WriteLine("Lee cadena: " + DateTime.Now.ToString("yyyy-MM-dd h:mm:ss tt"));
				return cadena;
			}
			set {
				Console.WriteLine("Cambia cadena: " + DateTime.Now.ToString("yyyy-MM-dd h:mm:ss tt"));
				cadena = value;
			}
		}

		public double Valor {
			get {
				Console.WriteLine("Lee valor: " + DateTime.Now.ToString("yyyy-MM-dd h:mm:ss tt"));
				return valor;
			}
			set {
				Console.WriteLine("Cambia valor: " + DateTime.Now.ToString("yyyy-MM-dd h:mm:ss tt"));
				valor = value;
			}
		}
	}

	//Inicia la aplicación aquí
	class Program {
		static void Main() {
			//Instancia o crea un objeto de MiClase
			MiClase Objeto = new MiClase();

			//Llama los setters
			Objeto.Cadena = "Suini, Capuchina, Grisú, Milú, Sally, Vikingo";
			Objeto.Numero = 7;
			Objeto.Letra = 'R';
			Objeto.Valor = 93.5;

			//Usa los getters
			char unaletra = Objeto.Letra;
			double unvalor = Objeto.Valor;
			string unacadena = Objeto.Cadena;
			int unnumero = Objeto.Numero;

			Console.WriteLine("Letra es: " + unaletra.ToString());
			Console.WriteLine("Valor es: " + unvalor.ToString());
			Console.WriteLine("Cadena es: " + unacadena);
			Console.WriteLine("Número es: " + unnumero.ToString());
		}
	}
}
