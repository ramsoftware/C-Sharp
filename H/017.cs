namespace Ejemplo {
	//Ordenar, buscar en árbol binario ordenado,
	//número de nodos y altura del árbol
	class Nodo {
		public int Numero { get; set; }
		public Nodo Izquierda;
		public Nodo Derecha;

		public Nodo(int Numero) {
			this.Numero = Numero;
			this.Izquierda = null;
			this.Derecha = null;
		}
	}
	
	class Program {

		public static void Main() {

			Nodo Arbol = new(27);
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
			Console.WriteLine("Valores ordenados");
			InOrden(Arbol);

			//Ahora a buscar un determinado valor
			Console.Write("\r\n\r\nBusca el valor: 185...");
			bool encontrar = BuscaArbol(Arbol, 185);
			if (encontrar)
				Console.WriteLine(" Valor encontrado");
			else
				Console.WriteLine(" Valor NO encontrado");

			//Busca valor en el árbol
			Console.Write("\r\nBusca el valor: 19...");
			Nodo nodoEncuentra = Buscanodo(Arbol, 19);
			if (nodoEncuentra != null)
				Console.WriteLine(" Valor encontrado");
			else
				Console.WriteLine(" Valor no encontrado");

			//Contar los nodos
			Console.WriteLine("\r\nTotal nodos: " + CuentaNodosArbol(Arbol));

			//Altura del árbol
			Console.WriteLine("\nAltura del árbol: " + AlturaArbol(Arbol));
		}

		public static void AgregaNodo(int Valor, Nodo Raiz) {
			if (Valor <= Raiz.Numero) {
				if (Raiz.Izquierda == null)
					Raiz.Izquierda = new(Valor);
				else
					AgregaNodo(Valor, Raiz.Izquierda);
			}
			else {
				if (Raiz.Derecha == null)
					Raiz.Derecha = new(Valor);
				else
					AgregaNodo(Valor, Raiz.Derecha);
			}
		}

		//Recorrido dél árbol en InOrden
		static void InOrden(Nodo Arbol) {
			if (Arbol != null) {
				InOrden(Arbol.Izquierda);
				Console.Write(Arbol.Numero + ", ");
				InOrden(Arbol.Derecha);
			}
		}

		//Retorna true si encuentra el valor en el árbol binario
		static bool BuscaArbol(Nodo Arbol, int valor) {
			if (Arbol != null) {
				if (Arbol.Numero == valor) return true;
				bool encuentraI = BuscaArbol(Arbol.Izquierda, valor);
				bool encuentraD = BuscaArbol(Arbol.Derecha, valor);
				if (encuentraI || encuentraD) return true;
			}
			return false;
		}

		//Retorna el Nodo donde se encuentra el valor buscado
		static Nodo Buscanodo(Nodo Raiz, int valor) {
			if (valor == Raiz.Numero)
				return Raiz;
			
			if (valor < Raiz.Numero && Raiz.Izquierda != null)
				return Buscanodo(Raiz.Izquierda, valor);
			
			if (valor > Raiz.Numero && Raiz.Derecha != null)
				return Buscanodo(Raiz.Derecha, valor);
			
			return null;
		}

		//Cuenta los nodos de un árbol
		static int CuentaNodosArbol(Nodo Arbol) {
			if (Arbol == null) return 0;
			int contarI = CuentaNodosArbol(Arbol.Izquierda);
			int contarD = CuentaNodosArbol(Arbol.Derecha);
			return contarI + contarD + 1;
		}

		//Calcula la altura de un árbol
		static int AlturaArbol(Nodo Arbol) {
			if (Arbol == null) return 0;
			int alturaI = AlturaArbol(Arbol.Izquierda);
			int alturaD = AlturaArbol(Arbol.Derecha);
			if (alturaI > alturaD) return alturaI + 1;
			return alturaD + 1;
		}
	}
}