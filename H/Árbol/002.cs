using System.Globalization;

//Forma el árbol binario dada una expresión matemática
//de números y operadores suma y resta
//Luego evalúa la expresión
namespace ArbolBinarioEvaluador {
	internal class Nodo {
		public int ID;
		public char Operador; //+ o -
		public double Numero;
		public Nodo Izquierda, Derecha;

		//Si el nodo tiene operador + o -
		public Nodo(char Operador, int identifica) {
			Numero = 0;
			this.Operador = Operador;
			Izquierda = null;
			Derecha = null;
			ID = identifica;
		}

		//Si el Nodo sólo tiene número
		public Nodo(double Numero, int identifica) {
			this.Numero = Numero;
			Operador = '#';
			Izquierda = null;
			Derecha = null;
			ID = identifica;
		}

		public void Imprime() {
			if (Operador != '#')
				Console.Write("\"[" + ID + "] " + Operador + "\"");
			else
				Console.Write("\"[" + ID + "] " + Numero + "\"");
		}
	}

	internal class Program {
		static int Identifica = 0;

		static void Main(string[] args) {
			//Ecuación con sólo sumas y restas
			string Ecuacion = "1+2-3+4-5";
			Nodo MiArbol = null;
			MiArbol = CreaArbol(Ecuacion, MiArbol);

			//Evalúa la expresión 
			double Resultado = EvaluaArbol(MiArbol);
			Console.WriteLine("Resultado es: " + Resultado);

			//Probarlo en: http://viz-js.com
			Console.WriteLine("digraph testgraph{");
			Dibujar(MiArbol);
			Console.WriteLine("}");
		}

		public static Nodo CreaArbol(string Cadena, Nodo Arbol) {
			//Busca +, -
			for (int Cont = Cadena.Length - 1; Cont >= 0; Cont--) {
				if (Cadena[Cont] == '+' || Cadena[Cont] == '-') {
					string Izquierda = Cadena.Substring(0, Cont);
					string Derecha = Cadena.Substring(Cont + 1);
					Arbol = new Nodo(Cadena[Cont], Identifica++);
					Arbol.Izquierda = CreaArbol(Izquierda, Arbol.Izquierda);
					Arbol.Derecha = CreaArbol(Derecha, Arbol.Derecha);
					return Arbol;
				}
			}

			//Sólo queda el número y se le crea el nodo
			double Numero;
			Numero = double.Parse(Cadena, CultureInfo.InvariantCulture);
			Arbol = new Nodo(Numero, Identifica++);
			return Arbol;
		}

		static void Dibujar(Nodo Arbol) {
			if (Arbol != null) {
				if (Arbol.Izquierda != null) {
					Arbol.Imprime();
					Console.Write(" -> ");
					Arbol.Izquierda.Imprime();
					Console.WriteLine(" ");
					Dibujar(Arbol.Izquierda);
				}
				if (Arbol.Derecha != null) {
					Arbol.Imprime();
					Console.Write(" -> ");
					Arbol.Derecha.Imprime();
					Console.WriteLine(" ");
					Dibujar(Arbol.Derecha);
				}
			}
		}

		// Recorrido en Post-Orden para 
		//evaluar el árbol binario
		public static double EvaluaArbol(Nodo Arbol) {
			//No hay ramas hijas, entonces es un número
			if (Arbol.Izquierda == null)
				return Arbol.Numero;

			//Recorrido Post-Orden
			double ValIzquierda = EvaluaArbol(Arbol.Izquierda);
			double ValDerecha = EvaluaArbol(Arbol.Derecha);

			//Aplica operador
			switch (Arbol.Operador) {
				case '+': return ValIzquierda + ValDerecha;
				case '-': return ValIzquierda - ValDerecha;
			}
			return 0;
		}
	}
}
