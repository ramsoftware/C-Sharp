namespace Ejemplo;

//Esta es una clase propia con sus
//atributos y métodos (encapsulación)
class MiClase {
	//Atributos privados. Un uso de los getters y setters
	private int numero;
	private char letra;
	private string cadena;
	private double valor;

	//Puede auditar cuando se leyó o cambió
	//el valor de un atributo
	public int Numero {
		get {
			Console.WriteLine("Lee numero: ");
			string T = DateTime.Now.ToString("yyyy-MM-dd h:mm:ss tt");
			Console.WriteLine(T);
			return numero;
		}
		set {
			Console.WriteLine("Cambia numero: ");
			string T = DateTime.Now.ToString("yyyy-MM-dd h:mm:ss tt");
			Console.WriteLine(T);
			numero = value;
		}
	}

	public char Letra {
		get {
			Console.WriteLine("Lee letra: ");
			string T = DateTime.Now.ToString("yyyy-MM-dd h:mm:ss tt");
			Console.WriteLine(T);
			return letra;
		}
		set {
			Console.WriteLine("Cambia letra: ");
			string T = DateTime.Now.ToString("yyyy-MM-dd h:mm:ss tt");
			Console.WriteLine(T);
			letra = value;
		}
	}

	public string Cadena {
		get {
			Console.WriteLine("Lee cadena: ");
			string T = DateTime.Now.ToString("yyyy-MM-dd h:mm:ss tt");
			Console.WriteLine(T);
			return cadena;
		}
		set {
			Console.WriteLine("Cambia cadena: ");
			string T = DateTime.Now.ToString("yyyy-MM-dd h:mm:ss tt");
			Console.WriteLine(T);
			cadena = value;
		}
	}

	public double Valor {
		get {
			Console.WriteLine("Lee valor: ");
			string T = DateTime.Now.ToString("yyyy-MM-dd h:mm:ss tt");
			Console.WriteLine(T);
			return valor;
		}
		set {
			Console.WriteLine("Cambia valor: ");
			string T = DateTime.Now.ToString("yyyy-MM-dd h:mm:ss tt");
			Console.WriteLine(T);
			valor = value;
		}
	}
}

//Inicia la aplicación aquí
class Program {
	static void Main() {
		//Instancia o crea un objeto de MiClase.
		//Otra forma de inicializar los atributos.
		MiClase Objeto = new MiClase {

			//Llama los setters
			Cadena = "Suini, Capuchina, Grisú, Milú, Sally, Vikingo",
			Numero = 7,
			Letra = 'R',
			Valor = 93.5
		};

		//Usa los getters
		char unaletra = Objeto.Letra;
		double unvalor = Objeto.Valor;
		string unacadena = Objeto.Cadena;
		int unnumero = Objeto.Numero;

		Console.WriteLine("Letra es: " + unaletra);
		Console.WriteLine("Valor es: " + unvalor);
		Console.WriteLine("Cadena es: " + unacadena);
		Console.WriteLine("Número es: " + unnumero);
	}
}