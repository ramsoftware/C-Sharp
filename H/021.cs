namespace Ejemplo {
	class Nodo {
		//Atributos propios
		public string Cad { get; set; }
		public char Car { get; set; }
		public int Entero { get; set; }
		public double Num { get; set; }

		//Uso de una Lista para sostener los hijos del nodo
		public List<Nodo> Hijos;

		public Nodo(string Cad, char Car, int Entero, double Num) {
			this.Cad = Cad;
			this.Car = Car;
			this.Entero = Entero;
			this.Num = Num;
			Hijos = new List<Nodo>(); //Crea la lista vacía
		}

		public void Nuevo(Nodo hijo) {
			Hijos.Add(hijo); //Agrega hijo a la lista
		}

		//Imprime Contenido
		public void Imprime() {
			Console.Write("Cad: " + Cad + " Car: " + Car);
			Console.Write(" Entero: " + Entero + " Real: " + Num);
			Console.WriteLine(" Número de hijos: " + Hijos.Count);
		}
	}

	class Program {
		static void Main() {
			//Crea la raíz del árbol N-ario
			Nodo arbolN = new("AAAA", 'a', 1, 0.1);

			//Agrega varios hijos a esa raíz
			arbolN.Nuevo(new("BBBB", 'b', 2, 0.2));
			arbolN.Nuevo(new("CCCC", 'c', 3, 0.3));
			arbolN.Nuevo(new("DDDD", 'd', 4, 0.4));
			arbolN.Nuevo(new("EEEE", 'e', 5, 0.5));
			arbolN.Nuevo(new("FFFF", 'f', 6, 0.6));

			//Agrega varios hijos al nodo "BBBB"
			arbolN.Hijos[0].Nuevo(new("Bhhh", 'h', 7, 0.7));
			arbolN.Hijos[0].Nuevo(new("Biii", 'i', 8, 0.8));
			arbolN.Hijos[0].Nuevo(new("Bjjj", 'j', 9, 0.9));

			//Agrega varios hijos al nodo "EEEE"
			arbolN.Hijos[3].Nuevo(new("Ekkk", 'k', 10, 1.1));
			arbolN.Hijos[3].Nuevo(new("Elll", 'l', 11, 1.2));
			arbolN.Hijos[3].Nuevo(new("Emmm", 'm', 12, 1.3));

			//Agrega varios hijos al nodo "Biii"
			arbolN.Hijos[0].Hijos[1].Nuevo(new("Biiia", 'n', 13, 1.4));
			arbolN.Hijos[0].Hijos[1].Nuevo(new("Biiib", 'o', 14, 1.5));
			arbolN.Hijos[0].Hijos[1].Nuevo(new("Biiic", 'p', 15, 1.6));
			arbolN.Hijos[0].Hijos[1].Nuevo(new("Biiid", 'q', 16, 1.7));
			arbolN.Hijos[0].Hijos[1].Nuevo(new("Biiie", 'r', 17, 1.8));

			//Imprime el árbol
			RecorreArbolN(arbolN);
		}

		//Recorre el árbol
		static void RecorreArbolN(Nodo Arbol) {
			if (Arbol != null) {
				Arbol.Imprime();
				for (int cont = 0; cont < Arbol.Hijos.Count; cont++)
					RecorreArbolN(Arbol.Hijos[cont]);
			}
		}
	}
}
