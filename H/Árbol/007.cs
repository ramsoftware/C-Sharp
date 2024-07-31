using System.Globalization;

//Forma el árbol binario dada una expresión matemática
//de números, variables, paréntesis, funciones y los operadores:
//Suma, resta, multiplicación, división y potencia
//Luego evalúa la expresión
namespace ArbolBinarioEvaluador {
	internal class Nodo {
		public int ID;
		public char Operador; //+ - * / ^
		public double Numero;
		public int Variable;
		public int Funcion;
		public Nodo Izquierda, Derecha;

		//Si el nodo tiene operador + - * / ^
		public Nodo(char Operador, int identifica) {
			Variable = -1;
			Numero = 0;
			this.Operador = Operador;
			Funcion = -1;
			Izquierda = null;
			Derecha = null;
			ID = identifica;
		}

		//Si el Nodo sólo tiene número
		public Nodo(double Numero, int identifica) {
			Variable = -1;
			this.Numero = Numero;
			Operador = '#';
			Funcion = -1;
			Izquierda = null;
			Derecha = null;
			ID = identifica;
		}

		//Si el Nodo sólo tiene variable
		public Nodo(int Variable, int identifica) {
			this.Variable = Variable;
			Numero = 0;
			Operador = '#';
			Funcion = -1;
			Izquierda = null;
			Derecha = null;
			ID = identifica;
		}

		//Si el Nodo es de una función
		public Nodo(int Funcion, int identifica, bool EsFuncion) {
			Variable = -1;
			Numero = 0;
			Operador = '#';
			this.Funcion = Funcion;
			Izquierda = null;
			Derecha = null;
			ID = identifica;
		}


		public void Imprime() {
			if (Operador != '#')
				Console.Write("\"[" + ID + "] " + Operador + "\"");
			else if (Variable != -1) {
				int Ascii = 'a' + Variable;
				char Letra = (char)Ascii;
				Console.Write("\"[" + ID + "] " + Letra + "\"");
			}
			else if (Funcion != -1) {
				Console.Write("\"[" + ID + "] ");
				/* Código de la función 0:seno, 1:coseno, 2:tangente,
				 * 3: valor absoluto, 4: arcoseno, 5: arcocoseno,
				 * 6: arcotangente, 7: logaritmo natural, 8: valor tope,
				 * 9: exponencial, 10: raíz cuadrada */
				switch (Funcion) {
					case 0: Console.Write("seno \""); break;
					case 1: Console.Write("coseno \""); break;
					case 2: Console.Write("tangente \""); break;
					case 3: Console.Write("absoluto \""); break;
					case 4: Console.Write("arcoseno \""); break;
					case 5: Console.Write("arcocoseno \""); break;
					case 6: Console.Write("arcotangente \""); break;
					case 7: Console.Write("log \""); break;
					case 8: Console.Write("ceil \""); break;
					case 9: Console.Write("exp \""); break;
					case 10: Console.Write("sqrt \""); break;
				}
			}
			else
				Console.Write("\"[" + ID + "] " + Numero + "\"");
		}
	}

	internal class Program {
		static int Identifica = 0;
		static double[] Valores = new double[26];

		static void Main(string[] args) {
			//Ecuación operadores, variables, funciones, paréntesis
			string Ecuacion = "sen(cos(x)+sen(y+z))/cos(78-q)";
			string Convertir = Convierte(Ecuacion);
			DarValorVariable('x', 120);
			DarValorVariable('y', 150);
			DarValorVariable('z', 45);
			DarValorVariable('q', -10);

			Nodo MiArbol = null;
			MiArbol = CreaArbol(Convertir, MiArbol);

			//Evalúa la expresión 
			double Resultado = EvaluaArbol(MiArbol);
			Console.WriteLine("Resultado es: " + Resultado);

			//Probarlo en: http://viz-js.com
			Console.WriteLine("digraph testgraph{");
			Dibujar(MiArbol);
			Console.WriteLine("}");
		}

		public static Nodo CreaArbol(string Cad, Nodo Arbol) {
			int Prntss;
			bool EsFinal;

			//Detecta si es función
			if (Cad[0] >= 'A' && Cad[0] <= 'J') {
				//Busca el paréntesis que cierra la función
				EsFinal = true;
				Prntss = 0;
				for (int Cont = 2; Cont < Cad.Length - 1; Cont++) {
					if (Cad[Cont] == '(') Prntss++;
					if (Cad[Cont] == ')') Prntss--;
					if (Prntss < 0) {
						EsFinal = false;
						break;
					}
				}

				//¿Es una función en solitario?
				if (EsFinal) {
					int Ascii = Cad[0] - 'A';
					Arbol = new Nodo(Ascii, Identifica++, true);
					Arbol.Derecha = new Nodo(0.0, Identifica);

					//Retira la letra A, el primer y último paréntesis
					Cad = Cad.Substring(2, Cad.Length - 3);
					Arbol.Izquierda = CreaArbol(Cad, Arbol.Izquierda);
					return Arbol;
				}
			}

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

			//Sólo queda el número o la variable y se le crea el nodo
			if (Cad[0] >= 'a' && Cad[0] <= 'z') {
				int Variable = Cad[0] - 'a';
				Arbol = new Nodo(Variable, Identifica++);
			}
			else {
				double Numero;
				Numero = double.Parse(Cad, CultureInfo.InvariantCulture);
				Arbol = new Nodo(Numero, Identifica++);
			}

			return Arbol;
		}

		/* Da valor a las variables que tendrá
		 * la expresión algebraica */
		public static void DarValorVariable(char varAlgebra, double Valor) {
			Valores[varAlgebra - 'a'] = Valor;
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
			//No hay rama hija entonces es número o variable
			if (Arbol.Izquierda == null)
				if (Arbol.Variable != -1)
					return Valores[Arbol.Variable];
				else
					return Arbol.Numero;

			//Recorrido Post-Orden
			double ValIzquierda = EvaluaArbol(Arbol.Izquierda);
			double ValDerecha = EvaluaArbol(Arbol.Derecha);

			/* Código de la función 0:seno, 1:coseno, 2:tangente,
			 * 3: valor absoluto, 4: arcoseno, 5: arcocoseno,
			 * 6: arcotangente, 7: logaritmo natural, 8: valor tope,
			 * 9: exponencial, 10: raíz cuadrada */
			if (Arbol.Funcion != -1) {
				switch (Arbol.Funcion) {
					case 0: return Math.Sin(ValIzquierda);
					case 1: return Math.Cos(ValIzquierda);
					case 2: return Math.Tan(ValIzquierda);
					case 3: return Math.Abs(ValIzquierda);
					case 4: return Math.Asin(ValIzquierda);
					case 5: return Math.Acos(ValIzquierda);
					case 6: return Math.Atan(ValIzquierda);
					case 7: return Math.Log(ValIzquierda);
					case 8: return Math.Ceiling(ValIzquierda);
					case 9: return Math.Exp(ValIzquierda);
					case 10: return Math.Sqrt(ValIzquierda);
				}
			}

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

		//Convierte la expresión algebraica, escrita por el usuario,
		//a un formato que pueda ser interpretado por el evaluador
		static string Convierte(string ExpOrig) {
			/* Primero a minúsculas */
			string Minusculas = ExpOrig.ToLower();

			/* Cadena a evaluar */
			string Cadena = Minusculas.Replace("sen", "A");
			Cadena = Cadena.Replace("cos", "B");
			Cadena = Cadena.Replace("tan", "C");
			Cadena = Cadena.Replace("abs", "D");
			Cadena = Cadena.Replace("asn", "E");
			Cadena = Cadena.Replace("acs", "F");
			Cadena = Cadena.Replace("atn", "G");
			Cadena = Cadena.Replace("log", "H");
			Cadena = Cadena.Replace("exp", "I");
			Cadena = Cadena.Replace("sqr", "J");

			return Cadena;
		}
	}
}