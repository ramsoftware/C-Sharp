namespace Ejemplo {
	//Dibujar el árbol en http://viz-js.com/
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

			//Probarlo en: http://viz-js.com
			Console.WriteLine("digraph testgraph{");
			Dibujar(Arbol);
			Console.WriteLine("}");
		}

		static void Dibujar(Nodo Arbol) {
			if (Arbol != null) {
				if (Arbol.Izquierda != null) {
					Console.Write(Arbol.Letra + "->");
					Console.WriteLine(Arbol.Izquierda.Letra);
					Dibujar(Arbol.Izquierda);
				}
				if (Arbol.Derecha != null) {
					Console.Write(Arbol.Letra + "->");
					Console.WriteLine(Arbol.Derecha.Letra);
					Dibujar(Arbol.Derecha);
				}
			}
		}
	}
}