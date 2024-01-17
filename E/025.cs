namespace Ejemplo {
	//Una clase con varios atributos
	class Ejemplo {
		public int Numero { get; set; }
		public double Valor { get; set; }
		public char Caracter { get; set; }
		public string Cadena { get; set; }

		public Ejemplo(int Numero, double Valor, char Caracter, string Cadena) {
			this.Numero = Numero;
			this.Valor = Valor;
			this.Caracter = Caracter;
			this.Cadena = Cadena;
		}
	}
	
	class Program {
		static void Main() {
			//Se define un diccionario: llave, objeto
			//En este caso la llave es una cadena
			var Objetos = new Dictionary<string, Ejemplo> {
				{"uno", new Ejemplo(1, 0.2, 'r', "Leafar") },
				{"dos", new Ejemplo(8, -7.1, 'a', "Otrebla")},
				{"tres", new Ejemplo(23, -13.6, 'm', "Onerom")},
				{"cuatro", new Ejemplo(49, 16.83, 'p', "Arrap")}
			};

			//Trae los datos del objeto guardado en el diccionario
			string Llave = "tres";
			Console.WriteLine("Llave: " + Llave + " atributo es: " + Objetos[Llave].Cadena);
			Console.WriteLine("Llave: " + Llave + " atributo es: " + Objetos[Llave].Numero);
			Console.WriteLine("Llave: " + Llave + " atributo es: " + Objetos[Llave].Valor);

			//Guarda las llaves en una lista
			Console.WriteLine("\r\nLista de Llaves:");
			var ListaLlaves = new List<string>(Objetos.Keys);
			foreach (string Llaves in ListaLlaves) {
				Console.WriteLine("Llave: " + Llaves);
			}

			//Verifica si existe una llave
			Console.WriteLine("\r\nVerifica si existe una llave:");
			if (Objetos.ContainsKey("cuatro")) {
				Console.WriteLine(Objetos["cuatro"].Cadena);
			}
			else {
				Console.WriteLine("No existe esa llave");
			}
		}
	}
}
