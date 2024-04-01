//Ordenar con un árbol binario
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
			//Va agregando nodo a nodo y los va ordenando
			Nodo Arbol = new Nodo(27);
			AgregaNodo(7, Arbol);
			AgregaNodo(17, Arbol);
			AgregaNodo(2, Arbol);
			AgregaNodo(5, Arbol);
			AgregaNodo(19, Arbol);
			AgregaNodo(15, Arbol);
			AgregaNodo(9, Arbol);
			AgregaNodo(10, Arbol);
			AgregaNodo(-1, Arbol);
			AgregaNodo(18, Arbol);
			AgregaNodo(3, Arbol);

			//Al leer en inorden el arbol, los datos salen ordenados
			Console.WriteLine("\n\nRecorrido InOrden (izquierdo, raiz, derecho)");
			InOrden(Arbol);
		}

		static void AgregaNodo(int Valor, Nodo Raiz) {
			if (Valor <= Raiz.Numero) {
				if (Raiz.Izquierda == null)
					Raiz.Izquierda = new Nodo(Valor);
				else
					AgregaNodo(Valor, Raiz.Izquierda);
			}
			else {
				if (Raiz.Derecha == null)
					Raiz.Derecha = new Nodo(Valor);
				else
					AgregaNodo(Valor, Raiz.Derecha);
			}
		}

		static void InOrden(Nodo Arbol) {
			if (Arbol != null) {
				InOrden(Arbol.Izquierda);
				Console.WriteLine(Arbol.Numero + ", ");
				InOrden(Arbol.Derecha);
			}
		}
	}
}
