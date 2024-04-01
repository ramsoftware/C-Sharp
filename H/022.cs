//Grafo básico
namespace Ejemplo {
	//Unidad básica en el grafo cuadrado. Apuntará Arriba, Abajo, Derecha e Izquierda
	class Nodo {
		public string Cadena { get; set; }

		//Apuntadores en las 4 direcciones
		public Nodo Arriba;
		public Nodo Abajo;
		public Nodo Derecha;
		public Nodo Izquierda;

		//Constructor
		public Nodo(string Cadena) {
			this.Cadena = Cadena;
		}
	}
	
	class Program {
		public static void Main() {
			//Genera los nodos
			Nodo nodoA = new Nodo("aaaa");
			Nodo nodoB = new Nodo("bbbb");
			Nodo nodoC = new Nodo("cccc");
			Nodo nodoD = new Nodo("dddd");

			//Une los nodos para crear el grafo
			nodoA.Abajo = nodoB;
			nodoB.Arriba = nodoA;

			nodoB.Derecha = nodoC;
			nodoC.Izquierda = nodoB;

			nodoC.Arriba = nodoD;
			nodoD.Abajo = nodoC;

			//Imprime
			Console.WriteLine("nodoA: " + nodoA.Cadena);
			Console.WriteLine("nodoA->Abajo: " + nodoA.Abajo.Cadena);
			Console.WriteLine("nodoA->Abajo->Derecha: " + nodoA.Abajo.Derecha.Cadena);
			Console.WriteLine("nodoA->Abajo->Derecha->Arriba: " + nodoA.Abajo.Derecha.Arriba.Cadena);
		}
	}
}