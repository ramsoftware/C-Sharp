namespace Ejemplo;

//Recorrido de un árbol binario
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
	public static void Main() {
		//Crea el árbol
		Nodo Arbol = new('M');
		Arbol.Izquierda = new('E');
		Arbol.Derecha = new('P');
		Arbol.Izquierda.Izquierda = new('B');
		Arbol.Izquierda.Derecha = new('L');
		Arbol.Izquierda.Izquierda.Izquierda = new('A');
		Arbol.Izquierda.Izquierda.Derecha = new('D');
		Arbol.Derecha.Izquierda = new('N');
		Arbol.Derecha.Derecha = new('V');
		Arbol.Derecha.Derecha.Izquierda = new('T');
		Arbol.Derecha.Derecha.Derecha = new('Z');

		//Recorridos
		Console.WriteLine("PreOrden (raiz, izquierdo, derecho)");
		PreOrden(Arbol);

		Console.WriteLine("\n\nInOrden (izquierdo, raiz, derecho)");
		InOrden(Arbol);

		Console.WriteLine("\n\nPostOrden (izquierdo, derecho, raiz)");
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
