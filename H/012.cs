﻿//Recorrido de un árbol binario
namespace Ejemplo {
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
			Nodo Arbol = new Nodo('M');
			Arbol.Izquierda = new Nodo('E');
			Arbol.Derecha = new Nodo('P');
			Arbol.Izquierda.Izquierda = new Nodo('B');
			Arbol.Izquierda.Derecha = new Nodo('L');
			Arbol.Izquierda.Izquierda.Izquierda = new Nodo('A');
			Arbol.Izquierda.Izquierda.Derecha = new Nodo('D');
			Arbol.Derecha.Izquierda = new Nodo('N');
			Arbol.Derecha.Derecha = new Nodo('V');
			Arbol.Derecha.Derecha.Izquierda = new Nodo('T');
			Arbol.Derecha.Derecha.Derecha = new Nodo('Z');

			//Recorridos
			Console.WriteLine("Recorrido preOrden (raiz, izquierdo, derecho)");
			PreOrden(Arbol);

			Console.WriteLine("\n\nRecorrido inOrden (izquierdo, raiz, derecho)");
			InOrden(Arbol);

			Console.WriteLine("\n\nRecorrido postOrden (izquierdo, derecho, raiz)");
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
}
