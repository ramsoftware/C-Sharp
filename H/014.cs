//Recorrido (no recursivo) de un árbol binario
namespace Ejemplo {
		//Nodo de un árbol binario
		class Nodo {
		public char Letra { get; set; }
		public Nodo Izquierda; //Apuntador
		public Nodo Derecha; //Apuntador

		//Constructor
		public Nodo(char Letra) {
			this.Letra = Letra;
		}
	}
	
	//Nodo de una pila para recorrer iterativamente un árbol binario
	class NodoPila {
		public NodoPila Flecha;
		public Nodo Raiz;
		public NodoPila(Nodo Raiz, NodoPila Flecha) {
			this.Raiz = Raiz;
			this.Flecha = Flecha;
		}
	}
	
	class Program {
		static void Main(string[] args) {
			//Crea el árbol
			Nodo Arbol = new Nodo('P');
			Arbol.Izquierda = new Nodo('F');
			Arbol.Derecha = new Nodo('S');
			Arbol.Izquierda.Izquierda = new Nodo('B');
			Arbol.Izquierda.Derecha = new Nodo('H');
			Arbol.Izquierda.Derecha.Izquierda = new Nodo('G');
			Arbol.Derecha.Izquierda = new Nodo('R');
			Arbol.Derecha.Derecha = new Nodo('Y');
			Arbol.Derecha.Derecha.Izquierda = new Nodo('T');
			Arbol.Derecha.Derecha.Derecha = new Nodo('Z');
			Arbol.Derecha.Derecha.Izquierda.Derecha = new Nodo('W');

			//Recorrido iterativo
			Console.WriteLine("Recorrido Iterativo");
			Iterativo(Arbol);
		}

		public static void Iterativo(Nodo arbol) {
			//Usa una pila para guardar 
			NodoPila inicia = new NodoPila(arbol, null);
			do {
				Nodo tmp = inicia.Raiz; //Una variable tmp para ver el nodo del árbol
				Console.Write(tmp.Letra + ", "); //Imprime el valor del nodo del árbol
				inicia = inicia.Flecha; //Se quita un elemento de la pila
				if (tmp.Izquierda != null) inicia = new NodoPila(tmp.Izquierda, inicia); //Si el nodo de árbol tiene un hijo a la izquierda entonces agrega este a la pila
				if (tmp.Derecha != null) inicia = new NodoPila(tmp.Derecha, inicia); //Si el nodo de árbol tiene un hijo a la derecha entonces agrega este a la pila
			} while (inicia != null); //Hasta que se vacíe la pila
		}
	}
}
