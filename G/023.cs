namespace Ejemplo {
	//Generando un grafo aleatoriamente
	//Unidad básica en el grafo cuadrado.
	//Apuntará Arriba, Abajo, Derecha e Izquierda
	class Nodo {
		public int Numero { get; set; }

		//Apuntadores en las 4 direcciones
		public Nodo Arriba;
		public Nodo Abajo;
		public Nodo Derecha;
		public Nodo Izquierda;

		//Constructor
		public Nodo(int Numero) {
			this.Numero = Numero;
		}
	}

	class Program {
		public static void Main() {
			Random azar = new();

			//Usa una lista para guardar los nodos
			List<Nodo> listado = [];

			//Genera los nodos dentro de un List
			int Total = azar.Next(20, 30);
			for (int cont = 1; cont <= Total; cont++) {
				listado.Add(new(cont));
			}

			//Ahora interconecta los nodos al azar
			Total = azar.Next(50, 200);
			for (int cont = 1; cont <= Total; cont++) {
				int nodoA = azar.Next(listado.Count);
				int nodoB;
				do {
					nodoB = azar.Next(listado.Count);
				} while (nodoA == nodoB);

				switch (azar.Next(4)) {
					case 0:
						listado[nodoA].Arriba = listado[nodoB];
						break;

					case 1:
						listado[nodoA].Abajo = listado[nodoB];
						break;

					case 2:
						listado[nodoA].Izquierda = listado[nodoB];
						break;

					case 3:
						listado[nodoA].Derecha = listado[nodoB];
						break;
				}
			}

			//Imprime el grafo para ser interpretado por viz.js
			Console.WriteLine("digraph testgraph{");
			for (int cont = 0; cont < listado.Count; cont++) {
				if (listado[cont].Arriba != null) {
					Console.Write(listado[cont].Numero + "->");
					Console.WriteLine(listado[cont].Arriba.Numero);
				}

				if (listado[cont].Abajo != null) {
					Console.Write(listado[cont].Numero + "->");
					Console.WriteLine(listado[cont].Abajo.Numero);
				}

				if (listado[cont].Izquierda != null) {
					Console.Write(listado[cont].Numero + "->");
					Console.WriteLine(listado[cont].Izquierda.Numero);
				}

				if (listado[cont].Derecha != null) {
					Console.Write(listado[cont].Numero + "->");
					Console.WriteLine(listado[cont].Derecha.Numero);
				}
			}
			Console.WriteLine("}");
		}
	}
}