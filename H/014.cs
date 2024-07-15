namespace Ejemplo {
//Recorrido (no recursivo) de un árbol binario
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
			Nodo Arbol = new('P');
			Arbol.Izquierda = new('F');
			Arbol.Derecha = new('S');
			Arbol.Izquierda.Izquierda = new('B');
			Arbol.Izquierda.Derecha = new('H');
			Arbol.Izquierda.Derecha.Izquierda = new('G');
			Arbol.Derecha.Izquierda = new('R');
			Arbol.Derecha.Derecha = new('Y');
			Arbol.Derecha.Derecha.Izquierda = new('T');
			Arbol.Derecha.Derecha.Derecha = new('Z');
			Arbol.Derecha.Derecha.Izquierda.Derecha = new('W');

			//Recorrido iterativo
			Console.WriteLine("Recorrido Iterativo");
			Iterativo(Arbol);
		}

		public static void Iterativo(Nodo arbol) {
			//Usa una pila para guardar 
			NodoPila inicia = new NodoPila(arbol, null);
			do {
				//Una variable tmp para ver el nodo del árbol
				Nodo tmp = inicia.Raiz;
				
				//Imprime el valor del nodo del árbol
				Console.Write(tmp.Letra + ", ");
				
				//Se quita un elemento de la pila
				inicia = inicia.Flecha;
				
				if (tmp.Izquierda != null) 
					//Si el nodo de árbol tiene un hijo a la 
					//izquierda entonces agrega este a la pila
					inicia = new NodoPila(tmp.Izquierda, inicia);
				
				if (tmp.Derecha != null) 
					//Si el nodo de árbol tiene un hijo a la derecha
					//entonces agrega este a la pila
					inicia = new NodoPila(tmp.Derecha, inicia);
				
			} while (inicia != null); //Hasta que se vacíe la pila
		}
	}
}
