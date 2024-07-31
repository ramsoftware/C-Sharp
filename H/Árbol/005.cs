using System.Globalization;

//Forma el árbol binario dada una expresión matemática
//de paréntesis, números y los operadores:
//Suma, resta, multiplicación, división y potencia
//Luego evalúa la expresión
namespace ArbolBinarioEvaluador {
	internal class Nodo {
		public int ID;
		public char Operador; //+ - * / ^
		public double Numero;
		public Nodo Izquierda, Derecha;

		//Si el nodo tiene operador + - * / ^
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
			//Ecuación los cuatro operadores
			string Ecuacion = "(1+6)-((8*3)+2/9)+2/9";
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

		public static Nodo CreaArbol(string Cad, Nodo Arbol) {
			/* Elimina paréntesis al inicio y al final si es
			   una expresión del tipo:
					(expresión de números y operadores)
			   la convierte en:
					expresión de números y operadores
			   Ejemplo:
					(2^3-8+7*2-14+7/2)
			   Se vuelve:
					2^3-8+7*2-14+7/2
			
			   Pero si encuentra algo así:
					(2+4) * (5-2)
			   No aplica tal conversión porque no son
			   paréntesis que cubren toda la expresión
			*/
			int Prntss;
			bool EsFinal;
			do {
				EsFinal = false;
				if (Cad[0] == '(') {
					EsFinal = true;
					Prntss = 0;
					for (int Cont = 1; Cont < Cad.Length - 1; Cont++) {
						if (Cad[Cont] == '(') Prntss++;
						if (Cad[Cont] == ')') Prntss--;
						if (Prntss < 0) {
							EsFinal = false;
							break;
						}
					}
				}
				if (EsFinal)
					Cad = Cad.Substring(1, Cad.Length - 2);
			} while (EsFinal == true);

			//Busca +, -
			Prntss = 0;
			for (int Cont = Cad.Length - 1; Cont >= 0; Cont--) {
				if (Cad[Cont] == '(') Prntss++;
				if (Cad[Cont] == ')') Prntss--;
				if ((Cad[Cont] == '+' || Cad[Cont] == '-') && Prntss == 0) {
					string Izquierda = Cad.Substring(0, Cont);
					string Derecha = Cad.Substring(Cont + 1);
					Arbol = new Nodo(Cad[Cont], Identifica++);
					Arbol.Izquierda = CreaArbol(Izquierda, Arbol.Izquierda);
					Arbol.Derecha = CreaArbol(Derecha, Arbol.Derecha);
					return Arbol;
				}
			}

			//Busca *, /
			for (int Cont = Cad.Length - 1; Cont >= 0; Cont--) {
				if (Cad[Cont] == '(') Prntss++;
				if (Cad[Cont] == ')') Prntss--;
				if ((Cad[Cont] == '*' || Cad[Cont] == '/') && Prntss == 0) {
					string Izquierda = Cad.Substring(0, Cont);
					string Derecha = Cad.Substring(Cont + 1);
					Arbol = new Nodo(Cad[Cont], Identifica++);
					Arbol.Izquierda = CreaArbol(Izquierda, Arbol.Izquierda);
					Arbol.Derecha = CreaArbol(Derecha, Arbol.Derecha);
					return Arbol;
				}
			}

			//Busca ^
			for (int Cont = Cad.Length - 1; Cont >= 0; Cont--) {
				if (Cad[Cont] == '(') Prntss++;
				if (Cad[Cont] == ')') Prntss--;
				if (Cad[Cont] == '^' && Prntss == 0) {
					string Izquierda = Cad.Substring(0, Cont);
					string Derecha = Cad.Substring(Cont + 1);
					Arbol = new Nodo(Cad[Cont], Identifica++);
					Arbol.Izquierda = CreaArbol(Izquierda, Arbol.Izquierda);
					Arbol.Derecha = CreaArbol(Derecha, Arbol.Derecha);
					return Arbol;
				}
			}

			//Sólo queda el número y se le crea el nodo
			double Numero = double.Parse(Cad, CultureInfo.InvariantCulture);
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

		//Recorrido en Post-Orden para 
		//evaluar el árbol binario
		public static double EvaluaArbol(Nodo Arbol) {
			//No hay ramas hijas entonces es un número
			if (Arbol.Izquierda == null)
				return Arbol.Numero;

			//Recorrido Post-Orden
			double ValIzquierda = EvaluaArbol(Arbol.Izquierda);
			double ValDerecha = EvaluaArbol(Arbol.Derecha);

			//Aplica operador
			switch (Arbol.Operador) {
				case '+': return ValIzquierda + ValDerecha;
				case '-': return ValIzquierda - ValDerecha;
				case '*': return ValIzquierda * ValDerecha;
				case '/': return ValIzquierda / ValDerecha;
				case '^': return Math.Pow(ValIzquierda, ValDerecha);
			}
			return 0;
		}
	}
}
