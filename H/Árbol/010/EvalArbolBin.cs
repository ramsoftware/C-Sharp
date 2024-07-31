using System.Globalization;

namespace ArbolBinarioEvaluador {
	internal class EvalArbolBin {
		/* Las 26 variables que puede tener la expresión */
		private double[] Valores = new double[26];

		/* Árbol binario */
		private Nodo MiArbol;

		public int Analizar(string ExpresionOriginal) {
			int Sintaxis = ChequeaSintaxis(ExpresionOriginal);
			if (Sintaxis == 0) {
				for (int cont = 0; cont < Valores.Length; cont++)
					Valores[cont] = 0;
				string Convertir = Convierte(ExpresionOriginal);
				MiArbol = null;
				MiArbol = CreaArbol(Convertir, MiArbol);
			}
			return Sintaxis;
		}

		/* Da valor a las variables que tendrá
		 * la expresión algebraica */
		public void DarValorVariable(char varAlgebra, double Valor) {
			Valores[varAlgebra - 'a'] = Valor;
		}

		/* Evalía la expresión ya analizada */
		public double Evaluar() {
			return EvaluaArbol(MiArbol);
		}

		/* Retorna mensaje de error sintáctico */
		public string MensajeError(int CodigoError) {
			string Msj = "";
			switch (CodigoError) {
				case 1:
					Msj = "1. Número seguido de letra";
					break;

				case 2:
					Msj = "2. Número seguido de paréntesis que abre";
					break;

				case 3:
					Msj = "3. Doble punto seguido";
					break;

				case 4:
					Msj = "4. Punto seguido de operador";
					break;

				case 5:
					Msj = "5. Punto y sigue una letra";
					break;

				case 6:
					Msj = "6. Punto seguido de paréntesis que abre";
					break;

				case 7:
					Msj = "7. Punto seguido de paréntesis que cierra";
					break;

				case 8:
					Msj = "8. Operador seguido de un punto";
					break;

				case 9:
					Msj = "9. Dos operadores estén seguidos";
					break;

				case 10:
					Msj = "10. Operador seguido de paréntesis que cierra";
					break;

				case 11:
					Msj = "11. Letra seguida de número";
					break;

				case 12:
					Msj = "12. Letra seguida de punto";
					break;

				case 13:
					Msj = "13. Letra seguida de otra letra";
					break;

				case 14:
					Msj = "14. Letra seguida de paréntesis que abre";
					break;

				case 15:
					Msj = "15. Paréntesis que abre seguido de punto";
					break;

				case 16:
					Msj = "16. Paréntesis que abre y sigue operador";
					break;

				case 17:
					Msj = "17. Paréntesis que abre y luego cierra";
					break;

				case 18:
					Msj = "18. Paréntesis que cierra y sigue número";
					break;

				case 19:
					Msj = "19. Paréntesis que cierra y sigue punto";
					break;

				case 20:
					Msj = "20. Paréntesis que cierra y sigue letra";
					break;

				case 21:
					Msj = "21. Paréntesis que cierra y luego abre";
					break;

				case 22:
					Msj = "22. Inicia con operador";
					break;

				case 23:
					Msj = "23. Finaliza con operador";
					break;

				case 24:
					Msj = "24. No hay correspondencia entre paréntesis";
					break;

				case 25:
					Msj = "25. Paréntesis desbalanceados";
					break;

				case 26:
					Msj = "26. Dos o más puntos en número real";
					break;
			}
			return Msj;
		}

		/* Analiza la expresión generando un árbol binario */
		private Nodo CreaArbol(string Cad, Nodo Arbol) {
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
					Arbol = new Nodo(Ascii, true);
					Arbol.Derecha = new Nodo(0.0);

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
					Arbol = new Nodo(Cad[Cont]);
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
					Arbol = new Nodo(Cad[Cont]);
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
					Arbol = new Nodo(Cad[Cont]);
					Arbol.Izquierda = CreaArbol(Izquierda, Arbol.Izquierda);
					Arbol.Derecha = CreaArbol(Derecha, Arbol.Derecha);
					return Arbol;
				}
			}

			//Sólo queda el número o la variable y se le crea el nodo
			if (Cad[0] >= 'a' && Cad[0] <= 'z') {
				int Variable = Cad[0] - 'a';
				Arbol = new Nodo(Variable);
			}
			else {
				double Numero;
				Numero = double.Parse(Cad, CultureInfo.InvariantCulture);
				Arbol = new Nodo(Numero);
			}

			return Arbol;
		}

		/*  Recorrido en Post-Orden para 
			evaluar el árbol binario */
		private double EvaluaArbol(Nodo Arbol) {
			//No hay nodos hijos, entonces
			//es un número o una variable
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
			 * 9: exponencial, 10: raíz cuadrada, -1 no es función */
			switch (Arbol.Funcion) {
				case 0: return Math.Sin(ValIzquierda);
				case 1: return Math.Cos(ValIzquierda);
				case 2: return Math.Tan(ValIzquierda);
				case 3: return Math.Abs(ValIzquierda);
				case 4: return Math.Asin(ValIzquierda);
				case 5: return Math.Acos(ValIzquierda);
				case 6: return Math.Atan(ValIzquierda);
				case 7: return Math.Log(ValIzquierda);
				case 8: return Math.Exp(ValIzquierda);
				case 9: return Math.Sqrt(ValIzquierda);
			}

			//Aplica operador
			return Arbol.Operador switch {
				'+' => ValIzquierda + ValDerecha,
				'-' => ValIzquierda - ValDerecha,
				'*' => ValIzquierda * ValDerecha,
				'/' => ValIzquierda / ValDerecha,
				'^' => Math.Pow(ValIzquierda, ValDerecha),
				_ => 0,
			};
		}

		/* Chequea la sintaxis de la expresión algebraica */
		private int ChequeaSintaxis(string ExpOrig) {
			/* Primero a minúsculas */
			string Minusculas = ExpOrig.ToLower();

			/* Sólo los caracteres válidos */
			string Valido = "abcdefghijklmnopqrstuvwxyz0123456789.+-*/^()";
			HashSet<char> Permite = new HashSet<char>(Valido);
			string ConLetrasValidas = "";
			for (int Cont = 0; Cont < Minusculas.Length; Cont++)
				if (Permite.Contains(Minusculas[Cont]))
					ConLetrasValidas += Minusculas[Cont].ToString();

			/* Validación de sintaxis, se genera una copia 
			 * y allí se reemplaza las funciones por a+( */
			string sbSintax = ConLetrasValidas;
			sbSintax = sbSintax.Replace("sen(", "a+(");
			sbSintax = sbSintax.Replace("cos(", "a+(");
			sbSintax = sbSintax.Replace("tan(", "a+(");
			sbSintax = sbSintax.Replace("abs(", "a+(");
			sbSintax = sbSintax.Replace("asn(", "a+(");
			sbSintax = sbSintax.Replace("acs(", "a+(");
			sbSintax = sbSintax.Replace("atn(", "a+(");
			sbSintax = sbSintax.Replace("log(", "a+(");
			sbSintax = sbSintax.Replace("exp(", "a+(");
			sbSintax = sbSintax.Replace("sqr(", "a+(");

			for (int Cont = 0; Cont < sbSintax.Length - 1; Cont++) {
				char cA = sbSintax[Cont];
				char cB = sbSintax[Cont + 1];

				if (Char.IsDigit(cA) && Char.IsLower(cB)) return 1;
				if (Char.IsDigit(cA) && cB == '(') return 2;
				if (cA == '.' && cB == '.') return 3;
				if (cA == '.' && EsUnOperador(cB)) return 4;
				if (cA == '.' && Char.IsLower(cB)) return 5;
				if (cA == '.' && cB == '(') return 6;
				if (cA == '.' && cB == ')') return 7;
				if (EsUnOperador(cA) && cB == '.') return 8;
				if (EsUnOperador(cA) && EsUnOperador(cB)) return 9;
				if (EsUnOperador(cA) && cB == ')') return 10;
				if (Char.IsLower(cA) && Char.IsDigit(cB)) return 11;
				if (Char.IsLower(cA) && cB == '.') return 12;
				if (Char.IsLower(cA) && Char.IsLower(cB)) return 13;
				if (Char.IsLower(cA) && cB == '(') return 14;
				if (cA == '(' && cB == '.') return 15;
				if (cA == '(' && EsUnOperador(cB)) return 16;
				if (cA == '(' && cB == ')') return 17;
				if (cA == ')' && Char.IsDigit(cB)) return 18;
				if (cA == ')' && cB == '.') return 19;
				if (cA == ')' && Char.IsLower(cB)) return 20;
				if (cA == ')' && cB == '(') return 21;
			}

			/* Valida el inicio y fin de la expresión */
			if (EsUnOperador(sbSintax[0])) return 22;
			if (EsUnOperador(sbSintax[sbSintax.Length - 1])) return 23;

			/* Valida balance de paréntesis */
			int ParentesisAbre = 0; /* Contador de paréntesis que abre */
			int ParentesisCierra = 0; /* Contador de paréntesis que cierra */
			for (int Cont = 0; Cont < sbSintax.Length; Cont++) {
				switch (sbSintax[Cont]) {
					case '(': ParentesisAbre++; break;
					case ')': ParentesisCierra++; break;
				}
				if (ParentesisCierra > ParentesisAbre) return 24;
			}
			if (ParentesisAbre != ParentesisCierra) return 25;

			/* Validar los puntos decimales de un número real */
			int TotalPuntos = 0;
			for (int Cont = 0; Cont < sbSintax.Length; Cont++) {
				if (EsUnOperador(sbSintax[Cont])) TotalPuntos = 0;
				if (sbSintax[Cont] == '.') TotalPuntos++;
				if (TotalPuntos > 1) return 26;
			}

			return 0;
		}

		/* Convierte la expresión algebraica, escrita por el usuario,
			a un formato que pueda ser interpretado por el evaluador */
		private string Convierte(string ExpOrig) {
			/* Primero a minúsculas */
			string Minusculas = ExpOrig.ToLower();

			/* Sólo los caracteres válidos */
			string Valido = "abcdefghijklmnopqrstuvwxyz0123456789.+-*/^()";
			HashSet<char> Permite = new HashSet<char>(Valido);
			string ConLetrasValidas = "";
			for (int Cont = 0; Cont < Minusculas.Length; Cont++)
				if (Permite.Contains(Minusculas[Cont]))
					ConLetrasValidas += Minusculas[Cont].ToString();

			/* Cadena a evaluar */
			string Cadena = ConLetrasValidas;
			Cadena = Cadena.Replace("sen", "A");
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

		/* Retorna true si el Caracter es
		 * un operador matemático */
		private bool EsUnOperador(char Caracter) {
			return Caracter switch {
				'+' or '-' or '*' or '/' or '^' => true,
				_ => false,
			};
		}
	}
}
