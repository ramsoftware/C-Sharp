//Crear un árbol binario al azar
namespace Ejemplo {
	//Nodo de un árbol binario
	class Nodo {
		public int Numero { get; set; }
		public Nodo Izquierda; //Apuntador
		public Nodo Derecha; //Apuntador

		//Constructor
		public Nodo(int Numero) {
			this.Numero = Numero;
		}
	}
	
	class Program {
		static void Main(string[] args) {
			Random azar = new Random();
			Nodo Arbol = new Nodo(azar.Next(100));

			//Crea el árbol binario
			for (int cont = 1; cont <= 10; cont++)
				AzarNodoArbol(azar, Arbol);

			//Recorridos
			Console.WriteLine("\n\nRecorrido preOrden (raiz, izquierdo, derecho)");
			preOrden(Arbol);

			Console.WriteLine("\n\nRecorrido inOrden (izquierdo, raiz, derecho)");
			inOrden(Arbol);

			Console.WriteLine("\n\nRecorrido postOrden (izquierdo, derecho, raiz)");
			postOrden(Arbol);
		}

		//Pone un nodo en una posición al azar
		static void AzarNodoArbol(Random azar, Nodo Raiz) {
			//Por debajo de 0.5 pone una rama a la izquierda
			if (azar.NextDouble() < 0.5) {
				if (Raiz.Izquierda == null)
					Raiz.Izquierda = new Nodo(azar.Next(100));
				else
					AzarNodoArbol(azar, Raiz.Izquierda);
			}
			else {
				if (Raiz.Derecha == null)
					Raiz.Derecha = new Nodo(azar.Next(100));
				else
					AzarNodoArbol(azar, Raiz.Derecha);
			}
		}

		static void inOrden(Nodo Arbol) {
			if (Arbol != null) {
				inOrden(Arbol.Izquierda);
				Console.Write(Arbol.Numero + ", ");
				inOrden(Arbol.Derecha);
			}
		}

		static void preOrden(Nodo Arbol) {
			if (Arbol != null) {
				Console.Write(Arbol.Numero + ", ");
				preOrden(Arbol.Izquierda);
				preOrden(Arbol.Derecha);
			}
		}

		static void postOrden(Nodo Arbol) {
			if (Arbol != null) {
				postOrden(Arbol.Izquierda);
				postOrden(Arbol.Derecha);
				Console.Write(Arbol.Numero + ", ");
			}
		}
	}
}
