//Recorridos de un árbol binario
namespace Ejemplo {
	class Nodo {
		public char Letra { get; set; }
		public Nodo Izquierda; //Apuntador
		public Nodo Derecha; //Apuntador

		//Constructor
		public Nodo(char Letra) {
			this.Letra = Letra;
		}
	}
	
	class Program {
		static void Main(string[] args) {
			//Crea el árbol
			Nodo Arbol = new Nodo('2');
			Arbol.Izquierda = new Nodo('5');
			Arbol.Derecha = new Nodo('8');
			Arbol.Izquierda.Izquierda = new Nodo('1');
			Arbol.Izquierda.Derecha = new Nodo('4');
			Arbol.Izquierda.Izquierda.Derecha = new Nodo('7');
			Arbol.Derecha.Derecha = new Nodo('0');
			Arbol.Derecha.Derecha.Izquierda = new Nodo('6');

			//Recorridos
			Console.WriteLine("Recorrido preOrden (raiz, izquierdo, derecho)");
			PreOrden(Arbol);

			Console.WriteLine("\n\nRecorrido inOrden (izquierdo, raiz, derecho)");
			InOrden(Arbol);

			Console.WriteLine("\n\nRecorrido postOrden (izquierdo, derecho, raiz)");
			PostOrden(Arbol);
		}

		static void PreOrden(Nodo Arbol) {
			if (Arbol != null) {
				Console.Write(Arbol.Letra + ", ");
				PreOrden(Arbol.Izquierda);
				PreOrden(Arbol.Derecha);
			}
		}

		static void InOrden(Nodo Arbol) {
			if (Arbol != null) {
				InOrden(Arbol.Izquierda);
				Console.Write(Arbol.Letra + ", ");
				InOrden(Arbol.Derecha);
			}
		}

		static void PostOrden(Nodo Arbol) {
			if (Arbol != null) {
				PostOrden(Arbol.Izquierda);
				PostOrden(Arbol.Derecha);
				Console.Write(Arbol.Letra + ", ");
			}
		}
	}
}
