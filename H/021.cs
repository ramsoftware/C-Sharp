namespace Ejemplo {
	class Nodo {
		//Atributos propios
		public string Cadena { get; set; }
		public char Caracter { get; set; }
		public int Entero { get; set; }
		public double NumReal { get; set; }

		public List<Nodo> Hijos; //Uso de una Lista para sostener los hijos del nodo

		public Nodo(string Cadena, char Caracter, int Entero, double NumReal) {
			this.Cadena = Cadena;
			this.Caracter = Caracter;
			this.Entero = Entero;
			this.NumReal = NumReal;
			Hijos = new List<Nodo>(); //Crea la lista vacía
		}

		public void AgregaHijo(Nodo hijo) {
			Hijos.Add(hijo); //Agrega hijo a la lista
		}

		//Imprime Contenido
		public void Imprime() {
			Console.Write("Cadena: " + Cadena + " Caracter: " + Caracter.ToString());
			Console.Write(" Entero: " + Entero.ToString() + " Real: " + NumReal.ToString());
			Console.WriteLine(" Número de hijos: " + Hijos.Count);
		}
	}
	
	class Program {
		static void Main() {
			//Crea la raíz del árbol N-ario
			Nodo arbolN = new Nodo("AAAA", 'a', 1, 0.1);

			//Agrega varios hijos a esa raíz
			arbolN.AgregaHijo(new Nodo("BBBB", 'b', 2, 0.2));
			arbolN.AgregaHijo(new Nodo("CCCC", 'c', 3, 0.3));
			arbolN.AgregaHijo(new Nodo("DDDD", 'd', 4, 0.4));
			arbolN.AgregaHijo(new Nodo("EEEE", 'e', 5, 0.5));
			arbolN.AgregaHijo(new Nodo("FFFF", 'f', 6, 0.6));

			//Agrega varios hijos al nodo "BBBB"
			arbolN.Hijos[0].AgregaHijo(new Nodo("Bhhh", 'h', 7, 0.7));
			arbolN.Hijos[0].AgregaHijo(new Nodo("Biii", 'i', 8, 0.8));
			arbolN.Hijos[0].AgregaHijo(new Nodo("Bjjj", 'j', 9, 0.9));

			//Agrega varios hijos al nodo "EEEE"
			arbolN.Hijos[3].AgregaHijo(new Nodo("Ekkk", 'k', 10, 1.1));
			arbolN.Hijos[3].AgregaHijo(new Nodo("Elll", 'l', 11, 1.2));
			arbolN.Hijos[3].AgregaHijo(new Nodo("Emmm", 'm', 12, 1.3));

			//Agrega varios hijos al nodo "Biii"
			arbolN.Hijos[0].Hijos[1].AgregaHijo(new Nodo("Biiia", 'n', 13, 1.4));
			arbolN.Hijos[0].Hijos[1].AgregaHijo(new Nodo("Biiib", 'o', 14, 1.5));
			arbolN.Hijos[0].Hijos[1].AgregaHijo(new Nodo("Biiic", 'p', 15, 1.6));
			arbolN.Hijos[0].Hijos[1].AgregaHijo(new Nodo("Biiid", 'q', 16, 1.7));
			arbolN.Hijos[0].Hijos[1].AgregaHijo(new Nodo("Biiie", 'r', 17, 1.8));

			//Imprime el árbol
			RecorreArbolN(arbolN);
		}

		//Recorre el árbol
		static void RecorreArbolN(Nodo Arbol) {
			if (Arbol != null) {
				Arbol.Imprime();
				for (int cont=0; cont<Arbol.Hijos.Count; cont++)
					RecorreArbolN(Arbol.Hijos[cont]);
			}
		}
	}
}
