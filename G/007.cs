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
		public Nodo(string Cad, char Car, int Entero,
					double Num, Nodo Apuntador) {
			this.Cad = Cad;
			this.Car = Car;
			this.Entero = Entero;
			this.Num = Num;
			this.Apuntador = Apuntador;
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

			//Añade un nodo en una determinada posición
			Nodo particular = new("zzzz", 'Z', 7, 0.7, null);
			lista = AdicionaNodo(particular, lista, 3);
			ImprimeLista(lista);
		}

		//Adiciona un nodo en determinada posición
		static public Nodo AdicionaNodo(Nodo nodo, Nodo lista, int pos) {
			//Si es al inicio de la lista
			if (pos == 0) {
				nodo.Apuntador = lista;
				return nodo;
			}

			//Si es en una ubicación intermedia
			int ubicacion = 0;
			Nodo pasear = lista;
			while (pasear != null) {
				if (ubicacion + 1 == pos) {
					nodo.Apuntador = pasear.Apuntador;
					pasear.Apuntador = nodo;
					return lista;
				}
				pasear = pasear.Apuntador;
				ubicacion++;
			}

			//Si es al final de la lista
			pasear = lista;
			while (pasear.Apuntador != null)
				pasear = pasear.Apuntador;

			pasear.Apuntador = nodo;
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