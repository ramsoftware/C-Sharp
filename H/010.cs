namespace Ejemplo {
	class Nodo {
		//Atributos propios
		public string Cadena { get; set; }
		public char Caracter { get; set; }
		public int Entero { get; set; }
		public double NumReal { get; set; }

		//Apuntadores para listas doblemente enlazadas
		public Nodo NodoIzq;
		public Nodo NodoDer;

		//Constructor
		public Nodo(string Cadena, char Caracter, int Entero, double NumReal, Nodo NodoDer) {
			this.Cadena = Cadena;
			this.Caracter = Caracter;
			this.Entero = Entero;
			this.NumReal = NumReal;
			NodoIzq = null;
			this.NodoDer = NodoDer;
			if (NodoDer != null) NodoDer.NodoIzq = this;
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

			//Imprime la lista en ambos sentidos
			ImprimeIzquierdaDerecha(lista);
			ImprimeDerechaIzquierda(lista);

			//Agrega un nodo a la lista doblemente enlazada
			Nodo nuevo = new Nodo("zzzz", 'Z', 13, 14.15, null);
			lista = AgregaNodo(nuevo, lista, 3);

			//Imprime la lista en ambos sentidos
			ImprimeIzquierdaDerecha(lista);
			ImprimeDerechaIzquierda(lista);
		}

		//Agrega un nodo a la lista doblemente enlazada
		static public Nodo AgregaNodo(Nodo nuevo, Nodo lista, int posicion) {
			//Debe asegurarse de ponerse en el primer nodo de la izquierda
			while (lista.NodoIzq != null) {
				lista = lista.NodoIzq;
			}

			//Si es al inicio de la lista
			if (posicion == 0) {
				nuevo.NodoDer = lista;
				lista.NodoIzq = nuevo;
				return nuevo;
			}

			//Si es en una ubicación intermedia
			int ubicacion = 0;
			Nodo pasear = lista;
			while (pasear != null) {
				if (ubicacion + 1 == posicion) {
					nuevo.NodoDer = pasear.NodoDer;
					pasear.NodoDer.NodoIzq = nuevo;
					pasear.NodoDer = nuevo;
					nuevo.NodoIzq = pasear;
					return lista;
				}
				pasear = pasear.NodoDer;
				ubicacion++;
			}

			//Si es al final de la lista
			pasear = lista;
			while (pasear.NodoDer != null) pasear = pasear.NodoDer;
			pasear.NodoDer = nuevo;
			nuevo.NodoIzq = pasear;
			return lista;
		}


		//Imprime la lista de izquierda a derecha
		static public void ImprimeIzquierdaDerecha(Nodo pasear) {
			Console.WriteLine("\r\nDe izquierda a derecha");

			//Debe ponerse en el primer nodo de la izquierda
			while (pasear.NodoIzq != null) {
				pasear = pasear.NodoIzq;
			}

			//Una vez en el primer nodo de la izquierda, entonces va
			//de izquierda a derecha imprimiendo
			while (pasear != null) {
				pasear.Imprime();
				pasear = pasear.NodoDer;
			}
		}

		//Imprime la lista de derecha a izquierda
		static public void ImprimeDerechaIzquierda(Nodo pasear) {
			Console.WriteLine("\r\nDe derecha a izquierda");

			//Debe ponerse en el primer nodo de la derecha
			while (pasear.NodoDer != null) {
				pasear = pasear.NodoDer;
			}

			//Una vez en el primer nodo de la derecha, entonces va
			//de derecha a izquierda imprimiendo
			while (pasear != null) {
				pasear.Imprime();
				pasear = pasear.NodoIzq;
			}
		}
	}
}
