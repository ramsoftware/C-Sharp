namespace Ejemplo {
	class Nodo {
		//Atributos propios
		public string Cad { get; set; }
		public char Car { get; set; }
		public int Entero { get; set; }
		public double Num { get; set; }

		//Apuntadores para listas doblemente enlazadas
		public Nodo NodoIzq;
		public Nodo NodoDer;

		//Constructor
		public Nodo(string Cad, char Car, int Entero,
					double Num, Nodo NodoDer) {
			this.Cad = Cad;
			this.Car = Car;
			this.Entero = Entero;
			this.Num = Num;
			NodoIzq = null;
			this.NodoDer = NodoDer;
			if (NodoDer != null) NodoDer.NodoIzq = this;
		}

		//Imprime Contenido
		public void Imprime() {
			Console.Write("Cad: " + Cad + " Car: " + Car);
			Console.WriteLine(" Entero: " + Entero + " Real: " + Num);
		}
	}

	class Program {
		static void Main() {
			//Crea la lista
			Nodo lista = new("aaaa", 'A', 1, 0.1, null);
			lista = new("bbbb", 'B', 2, 0.2, lista);
			lista = new("cccc", 'C', 3, 0.3, lista);
			lista = new("dddd", 'D', 4, 0.4, lista);
			lista = new("eeee", 'E', 5, 0.5, lista);

			//Imprime la lista en ambos sentidos
			ImprimeIzquierdaDerecha(lista);
			ImprimeDerechaIzquierda(lista);

			//Agrega un nodo a la lista doblemente enlazada
			lista = BorraNodo(lista, 3);

			//Imprime la lista en ambos sentidos
			ImprimeIzquierdaDerecha(lista);
			ImprimeDerechaIzquierda(lista);
		}

		//Borra un nodo de la lista doblemente enlazada
		static public Nodo BorraNodo(Nodo lista, int posicion) {
			//Debe asegurarse de ponerse en el
			//primer nodo de la izquierda
			while (lista.NodoIzq != null) {
				lista = lista.NodoIzq;
			}

			//Si es al inicio de la lista
			if (posicion == 0) {
				lista = lista.NodoDer;
				lista.NodoIzq = null;
				return lista;
			}

			//Si es en una ubicación intermedia
			int ubicacion = 0;
			Nodo pasear = lista;
			while (pasear != null) {
				if (ubicacion+1 == posicion) {
					pasear.NodoDer = pasear.NodoDer.NodoDer;
					if (pasear.NodoDer != null)
						pasear.NodoDer.NodoIzq = pasear;
					
					return lista;
				}
				pasear = pasear.NodoDer;
				ubicacion++;
			}

			//Si es al final de la lista
			pasear = lista;
			while (pasear.NodoDer.NodoDer != null)
				pasear = pasear.NodoDer;
			
			pasear.NodoDer = null;
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
