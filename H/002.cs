namespace Ejemplo {
	class Nodo {
		//Atributos propios
		public string Cadena { get; set; }
		public char Caracter { get; set; }
		public int Entero { get; set; }
		public double NumReal { get; set; }

		//Apuntador para lista simplemente enlazada
		public Nodo Apuntador;

		//Constructor
		public Nodo(string Cadena, char Caracter, int Entero, double NumReal, Nodo Apuntador) {
			this.Cadena = Cadena;
			this.Caracter = Caracter;
			this.Entero = Entero;
			this.NumReal = NumReal;
			this.Apuntador = Apuntador;
		}

		//Imprime Contenido
		public void Imprime() {
			Console.Write("Cadena: " + Cadena + " Caracter: " + Caracter.ToString());
			Console.WriteLine(" Entero: " + Entero.ToString() + " Real: " + NumReal.ToString());
		}
	}
	
	class Program {
		static void Main() {
			//Crea la lista
			Nodo lista = new Nodo("aaaa", 'A', 1, 0.1, null);
			lista = new Nodo("bbbb", 'B', 2, 0.2, lista);
			lista = new Nodo("cccc", 'C', 3, 0.3, lista);

			//Imprime la lista
			lista.Imprime(); //Primer nodo
			lista.Apuntador.Imprime(); //Segundo nodo
			lista.Apuntador.Apuntador.Imprime(); //Tercer nodo
		}
	}
}
