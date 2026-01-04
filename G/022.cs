namespace Ejemplo;

//Grafo básico
//Unidad básica en el grafo cuadrado.
//Apuntará Arriba, Abajo, Derecha e Izquierda
class Nodo {
	public string Cad { get; set; }

	//Apuntadores en las 4 direcciones
	public Nodo Arriba;
	public Nodo Abajo;
	public Nodo Derecha;
	public Nodo Izquierda;

	//Constructor
	public Nodo(string Cad) {
		this.Cad = Cad;
	}
}

class Program {
	public static void Main() {
		//Genera los nodos
		Nodo nodoA = new("aaaa");
		Nodo nodoB = new("bbbb");
		Nodo nodoC = new("cccc");
		Nodo nodoD = new("dddd");

		//Une los nodos para crear el grafo
		nodoA.Abajo = nodoB;
		nodoB.Arriba = nodoA;

		nodoB.Derecha = nodoC;
		nodoC.Izquierda = nodoB;

		nodoC.Arriba = nodoD;
		nodoD.Abajo = nodoC;

		//Imprime
		Console.WriteLine("nodoA: " + nodoA.Cad);

		Console.WriteLine("nodoA->Abajo: " + nodoA.Abajo.Cad);

		Console.Write("nodoA->Abajo->Derecha: ");
		Console.WriteLine(nodoA.Abajo.Derecha.Cad);

		Console.Write("nodoA->Abajo->Derecha->Arriba: ");
		Console.WriteLine(nodoA.Abajo.Derecha.Arriba.Cad);
	}
}