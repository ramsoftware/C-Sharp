//Dibujar el árbol en http://viz-js.com/
namespace Ejemplo {
	class Nodo {
		public char Letra { get; set; }
		public Nodo Izquierda;
		public Nodo Derecha;

		public Nodo(char Letra) {
			this.Letra = Letra;
			this.Izquierda = null;
			this.Derecha = null;
		}
	}
	
	class Program {

		public static void Main() {

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

			//Probarlo en: http://viz-js.com
			Console.WriteLine("digraph testgraph{");
			Dibujar(Arbol);
			Console.WriteLine("}");
		}

		static void Dibujar(Nodo Arbol) {
			if (Arbol != null) {
				if (Arbol.Izquierda != null) {
					Console.WriteLine(Arbol.Letra + "->" + Arbol.Izquierda.Letra);
					Dibujar(Arbol.Izquierda);
				}
				if (Arbol.Derecha != null) {
					Console.WriteLine(Arbol.Letra + "->" + Arbol.Derecha.Letra);
					Dibujar(Arbol.Derecha);
				}
			}
		}
	}
}