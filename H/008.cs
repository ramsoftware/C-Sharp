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
			lista = new Nodo("dddd", 'D', 4, 0.4, lista);
			lista = new Nodo("eeee", 'E', 5, 0.5, lista);

			//Borra un nodo en una determinada posición
			lista = BorraNodo(lista, 3);
			ImprimeLista(lista);
		}

		//Borra nodo de una determinada posición
		static public Nodo BorraNodo(Nodo lista, int posicion) {
			//Si es al inicio de la lista
			if (posicion == 0) {
				lista = lista.Apuntador;
				return lista;
			}

			//Si es en una ubicación intermedia
			int ubicacion = 0;
			Nodo pasear = lista;
			while (pasear != null) {
				if (ubicacion + 1 == posicion) {
					pasear.Apuntador = pasear.Apuntador.Apuntador;
					return lista;
				}
				pasear = pasear.Apuntador;
				ubicacion++;
			}

			//Si es al final de la lista
			pasear = lista;
			while (pasear.Apuntador.Apuntador != null) pasear = pasear.Apuntador;
			pasear.Apuntador = null;
			return lista;
		}

		//Imprime la lista
		static public void ImprimeLista(Nodo pasear) {
			while (pasear != null) {
				pasear.Imprime();
				pasear = pasear.Apuntador;
			}
		}
	}
}