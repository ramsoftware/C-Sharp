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
		public Nodo(string Cadena, char Caracter, int Entero, double NumReal) {
			this.Cadena = Cadena;
			this.Caracter = Caracter;
			this.Entero = Entero;
			this.NumReal = NumReal;
		}

		//Imprime Contenido
		public void Imprime() {
			Console.Write("Cadena: " + Cadena + " Caracter: " + Caracter.ToString());
			Console.WriteLine(" Entero: " + Entero.ToString() + " Real: " + NumReal.ToString());
		}
	}
	
	
	class Program {
		static void Main() {
			//Crea dos nodos separados
			Nodo primero = new Nodo("Rafael", 'A', 16, 8.32);
			Nodo segundo = new Nodo("Moreno", 'P', 9, 2.9);
			Nodo tercero = new Nodo("Sally", 'C', 2010, 7.18);

			//Une el primer nodo con el segundo, creando una simple lista
			primero.Apuntador = segundo;

			//Une el segundo nodo con el tercero, aumentando la lista
			segundo.Apuntador = tercero;

			//Imprime la lista
			primero.Imprime();
			primero.Apuntador.Imprime();
			primero.Apuntador.Apuntador.Imprime();
		}
	}
}
