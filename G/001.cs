namespace Ejemplo {
	class Nodo {
		//Atributos propios
		public string Cad { get; set; }
		public char Car { get; set; }
		public int Entero { get; set; }
		public double Num { get; set; }

		//Apuntador para lista simplemente enlazada
		public Nodo Apuntador;

		//Constructor
		public Nodo(string Cad, char Car, int Entero, double Num) {
			this.Cad = Cad;
			this.Car = Car;
			this.Entero = Entero;
			this.Num = Num;
		}

		//Imprime Contenido
		public void Imprime() {
			Console.Write("Cad: " + Cad + " Car: " + Car);
			Console.WriteLine(" Entero: " + Entero + " Real: " + Num);
		}
	}

	class Program {
		static void Main() {
			//Crea dos nodos separados
			Nodo primero = new("Rafael", 'A', 16, 8.32);
			Nodo segundo = new("Moreno", 'P', 9, 2.9);
			Nodo tercero = new("Sally", 'C', 2010, 7.18);

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