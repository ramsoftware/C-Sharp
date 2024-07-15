using System.Globalization;
using System.Text;

/* Evaluador de expresiones versión 4 (enero de 2024)
 * Autor: Rafael Alberto Moreno Parra
 * Correo: ramsoftware@gmail.com ;  enginelife@hotmail.com
 * URL: http://darwin.50webs.com 
 * GitHub: https://github.com/ramsoftware
 * */

namespace Ejemplo {

	internal class ParteEvl4 {
		/* Constantes de los diferentes tipos
		 * de datos que tendrán las piezas */
		private const int ESFUNCION = 1;
		private const int ESPARABRE = 2;
		private const int ESOPERADOR = 4;
		private const int ESNUMERO = 5;
		private const int ESVARIABLE = 6;

		/* Acumulador, función, paréntesis que abre,
		 * paréntesis que cierra, operador, 
		 * número, variable */
		public int Tipo;

		/* Código de la función 0:seno, 1:coseno, 2:tangente,
		 * 3: valor absoluto, 4: arcoseno, 5: arcocoseno,
		 * 6: arcotangente, 7: logaritmo natural, 8: valor tope,
		 * 9: exponencial, 10: raíz cuadrada */
		public int Funcion;

		/* + suma - resta * multiplicación / división ^ potencia */
		public int Operador;

		/* Posición en lista de valores del número literal
		 * por ejemplo: 3.141592 */
		public int posNumero;

		/* Posición en lista de valores del 
		 * valor de la variable algebraica */
		public int posVariable;

		/* Posición en lista de valores del valor de la pieza.
		 * Por ejemplo:
		   3 + 2 / 5  se convierte así:
		   |3| |+| |2| |/| |5| 
		   |3| |+| |A|  A es un identificador de acumulador */
		public int posAcumula;

		public ParteEvl4(int TipoParte, int Valor) {
			this.Tipo = TipoParte;
			switch (TipoParte) {
				case ESFUNCION: this.Funcion = Valor; break;
				case ESNUMERO: this.posNumero = Valor; break;
				case ESVARIABLE: this.posVariable = Valor; break;
				case ESPARABRE: this.Funcion = -1; break;
			}
		}

		public ParteEvl4(char Operador) {
			this.Tipo = ESOPERADOR;
			switch (Operador) {
				case '+': this.Operador = 0; break;
				case '-': this.Operador = 1; break;
				case '*': this.Operador = 2; break;
				case '/': this.Operador = 3; break;
				case '^': this.Operador = 4; break;
			}
		}
	}


	internal class PiezaEvl4 {
		/* Posición donde se almacena el valor que genera
		 * la pieza al evaluarse */
		public int PosResultado;

		/* Código de la función 0:seno, 1:coseno, 2:tangente,
		 * 3: valor absoluto, 4: arcoseno, 5: arcocoseno,
		 * 6: arcotangente, 7: logaritmo natural, 8: valor tope,
		 * 9: exponencial, 10: raíz cuadrada, 11: raíz cúbica */
		public int Funcion;

		/* Posición donde se almacena la primera parte de la pieza */
		public int pA;

		/* 0 suma 1 resta 2 multiplicación 3 división 4 potencia */
		public int Operador;

		/* Posición donde se almacena la segunda parte de la pieza */
		public int pB;
	}


	internal class Evaluador4 {
		/* Constantes de los diferentes tipos 
		 * de datos que tendrán las piezas */
		private const int ESFUNCION = 1;
		private const int ESPARABRE = 2;
		private const int ESPARCIERRA = 3;
		private const int ESOPERADOR = 4;
		private const int ESNUMERO = 5;
		private const int ESVARIABLE = 6;
		private const int ESACUMULA = 7;

		/* Expresión algebraica convertida de la
		 * original dada por el usuario */
		private StringBuilder Analizada = new();

		/* Donde guarda los valores de variables, constantes y piezas */
		private List<double> Valores = new List<double>();

		/* Listado de partes en que se divide la expresión
		   Toma una expresión, por ejemplo:
		   1.68 + sen( 3 / x ) * ( 2.92 - 9 )
		   y la divide en partes así:
		   [1.68] [+] [sen(] [3] [/] [x] [)] [*] [(] [2.92] [-] [9] [)]
		   Cada parte puede tener un número, un operador, una función,
		   un paréntesis que abre o un paréntesis que cierra.
		   En esta versión 4.0, las constantes, piezas y variables guardan
		   sus valores en la lista Valores.
		   En partes, se almacena la posición en Valores */
		private List<ParteEvl4> Partes = new List<ParteEvl4>();

		/* Listado de piezas que ejecutan
			Toma las partes y las divide en piezas con 
			la siguiente estructura:

			acumula = funcion valor operador valor

			donde valor puede ser un número, una variable o 
			un acumulador
			
			Siguiendo el ejemplo anterior sería:
			A =  2.92 - 9
			B =  sen( 3 / x )
			C =  B * A
			D =  1.68 + C

		   Esas piezas se evalúan de arriba a abajo y así
		se interpreta la ecuación */
		private List<PiezaEvl4> Piezas = new List<PiezaEvl4>();

		/* Analiza la expresión */
		public int Analizar(string ExpresionOriginal) {
			Partes.Clear();
			Piezas.Clear();
			Valores.Clear();

			/* Hace espacio para las 26 variables que
			 * puede manejar el evaluador */
			for (int Variables = 1; Variables <= 26; Variables++)
				Valores.Add(0);

			int Sintaxis = ChequeaSintaxis(ExpresionOriginal);
			if (Sintaxis == 0) {
				CrearPartes();
				CrearPiezas();
			}
			return Sintaxis;
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

		/* Da valor a las variables que tendrá
		 * la expresión algebraica */
		public void DarValorVariable(char varAlgebra, double Valor) {
			Valores[varAlgebra - 'a'] = Valor;
		}

		/* Evalúa la expresión convertida en piezas */
		public double Evaluar() {
			double Resulta = 0;
			PiezaEvl4 tmp;

			/* Va de pieza en pieza */
			for (int Posicion = 0; Posicion < Piezas.Count; Posicion++) {
				tmp = Piezas[Posicion];

				switch (tmp.Operador) {
					case 0:
						Resulta = Valores[tmp.pA] + Valores[tmp.pB];
						break;
					case 1:
						Resulta = Valores[tmp.pA] - Valores[tmp.pB];
						break;
					case 2:
						Resulta = Valores[tmp.pA] * Valores[tmp.pB];
						break;
					case 3:
						Resulta = Valores[tmp.pA] / Valores[tmp.pB];
						break;
					default:
						Resulta = Math.Pow(Valores[tmp.pA], Valores[tmp.pB]);
						break;
				}

				switch (tmp.Funcion) {
					case 0: Resulta = Math.Sin(Resulta); break;
					case 1: Resulta = Math.Cos(Resulta); break;
					case 2: Resulta = Math.Tan(Resulta); break;
					case 3: Resulta = Math.Abs(Resulta); break;
					case 4: Resulta = Math.Asin(Resulta); break;
					case 5: Resulta = Math.Acos(Resulta); break;
					case 6: Resulta = Math.Atan(Resulta); break;
					case 7: Resulta = Math.Log(Resulta); break;
					case 8: Resulta = Math.Ceiling(Resulta); break;
					case 9: Resulta = Math.Exp(Resulta); break;
					case 10: Resulta = Math.Sqrt(Resulta); break;
				}

				Valores[tmp.PosResultado] = Resulta;
			}
			return Resulta;
		}

		/* Divide la expresión en partes, yendo de caracter en caracter */
		private void CrearPartes() {
			StringBuilder Numero = new StringBuilder();
			for (int Pos = 0; Pos < this.Analizada.Length; Pos++) {
				char Letra = this.Analizada[Pos];
				switch (Letra) {
					case '.':
					case '0':
					case '1':
					case '2':
					case '3':
					case '4':
					case '5':
					case '6':
					case '7':
					case '8':
					case '9':   /* Si es un digito o un punto 
								 * va acumulando el número */
						Numero.Append(Letra); break;
					case '+':
					case '-':
					case '*':
					case '/':
					case '^': 
						/* Si es un operador matemático entonces verifica
						 * si hay un número que se ha acumulado */
						if (Numero.Length > 0) {
							Valores.Add(Convierte(Numero));
							Partes.Add(new ParteEvl4(ESNUMERO, Valores.Count - 1));
							Numero.Clear();
						}
						/* Agregar el operador matemático */
						Partes.Add(new ParteEvl4(Letra));
						break;

					case '(':   /* Es paréntesis que abre */
						Partes.Add(new ParteEvl4(ESPARABRE, 0));
						break;

					case ')':
						/* Si es un paréntesis que cierra entonces verifica
						 * si hay un número que se ha acumulado */
						if (Numero.Length > 0) {
							Valores.Add(Convierte(Numero));
							Partes.Add(new ParteEvl4(ESNUMERO, Valores.Count - 1));
							Numero.Clear();
						}

						/* Si sólo había un número o variable
						 * dentro del paréntesis le agrega + 0
						 * (por ejemplo:  sen(x) o 3*(2) ) */
						if (Partes[Partes.Count - 2].Tipo == ESPARABRE ||
							Partes[Partes.Count - 2].Tipo == ESFUNCION) {
							Partes.Add(new ParteEvl4(ESOPERADOR, 0));
							Valores.Add(0);
							Partes.Add(new ParteEvl4(ESNUMERO, Valores.Count - 1));
						}

						/* Adiciona el paréntesis que cierra */
						Partes.Add(new ParteEvl4(ESPARCIERRA, 0));
						break;
					case 'A':   /* Seno */
					case 'B':   /* Coseno */
					case 'C':   /* Tangente */
					case 'D':   /* Valor absoluto */
					case 'E':   /* Arcoseno */
					case 'F':   /* Arcocoseno */
					case 'G':   /* Arcotangente */
					case 'H':   /* Logaritmo natural */
					case 'I':   /* Exponencial */
					case 'J':   /* Raíz cuadrada */
						Partes.Add(new ParteEvl4(ESFUNCION, Letra - 'A'));
						Pos++;
						break;
					default:
						Partes.Add(new ParteEvl4(ESVARIABLE, Letra - 'a'));
						break;
				}
			}
		}

		private double Convierte(StringBuilder Numero) {
			string Cad = Numero.ToString();
			return double.Parse(Cad, CultureInfo.InvariantCulture);
		}

		/* Convierte las partes en las piezas finales de ejecución */
		private void CrearPiezas() {
			int Contador = Partes.Count - 1;
			do {
				ParteEvl4 tmpParte = Partes[Contador];
				if (tmpParte.Tipo == ESPARABRE || tmpParte.Tipo == ESFUNCION) {
					
					/* Evalúa las potencias */
					GeneraPiezaOpera(4, 4, Contador);

					/* Luego evalúa multiplicar y dividir */
					GeneraPiezaOpera(2, 3, Contador);

					/* Finalmente evalúa sumar y restar */
					GeneraPiezaOpera(0, 1, Contador);

					/* Agrega la función a la última pieza */
					if (tmpParte.Tipo == ESFUNCION) {
						Piezas[Piezas.Count - 1].Funcion = tmpParte.Funcion;
					}

					/* Quita el paréntesis/función que abre y
					 * el que cierra, dejando el centro */
					Partes.RemoveAt(Contador);
					Partes.RemoveAt(Contador + 1);
				}
				Contador--;
			} while (Contador >= 0);
		}

		/* Genera las piezas buscando determinado operador */
		private void GeneraPiezaOpera(int OperA, int OperB, int Inicia) {
			int Contador = Inicia + 1;
			do {
				ParteEvl4 tmpParte = Partes[Contador];
				if (tmpParte.Tipo == ESOPERADOR && 
					(tmpParte.Operador == OperA || tmpParte.Operador == OperB)) {
					ParteEvl4 tmpParteIzq = Partes[Contador - 1];
					ParteEvl4 tmpParteDer = Partes[Contador + 1];

					/* Crea Pieza */
					PiezaEvl4 NuevaPieza = new PiezaEvl4();
					NuevaPieza.Funcion = -1;

					switch (tmpParteIzq.Tipo) {
						case ESNUMERO:
							NuevaPieza.pA = tmpParteIzq.posNumero;
							break;

						case ESVARIABLE:
							NuevaPieza.pA = tmpParteIzq.posVariable;
							break;

						default:
							NuevaPieza.pA = tmpParteIzq.posAcumula;
							break;
					}

					NuevaPieza.Operador = tmpParte.Operador;

					switch (tmpParteDer.Tipo) {
						case ESNUMERO:
							NuevaPieza.pB = tmpParteDer.posNumero;
							break;

						case ESVARIABLE:
							NuevaPieza.pB = tmpParteDer.posVariable;
							break;

						default:
							NuevaPieza.pB = tmpParteDer.posAcumula;
							break;
					}

					/* Añade a lista de piezas y crea una
					 * nueva posición en Valores */
					Valores.Add(0);
					NuevaPieza.PosResultado = Valores.Count - 1;
					Piezas.Add(NuevaPieza);

					/* Elimina la parte del operador y la siguiente */
					Partes.RemoveAt(Contador);
					Partes.RemoveAt(Contador);

					/* Retorna el contador en uno para tomar
					 * la siguiente operación */
					Contador--;

					/* Cambia la parte anterior por parte que acumula */
					tmpParteIzq.Tipo = ESACUMULA;
					tmpParteIzq.posAcumula = NuevaPieza.PosResultado;
				}
				Contador++;
			} while (Partes[Contador].Tipo != ESPARCIERRA);
		}

		private int ChequeaSintaxis(string ExpOrig) {
			/* Primero a minúsculas */
			StringBuilder Minusculas = new StringBuilder(ExpOrig.ToLower());

			/* Sólo los caracteres válidos */
			string Valido = "abcdefghijklmnopqrstuvwxyz0123456789.+-*/^()";
			HashSet<char> Permite = new HashSet<char>(Valido);
			StringBuilder ConLetrasValidas = new StringBuilder("(");
			for (int Cont = 0; Cont < Minusculas.Length; Cont++)
				if (Permite.Contains(Minusculas[Cont]))
					ConLetrasValidas.Append(Minusculas[Cont]);
			ConLetrasValidas.Append(')');

			/* Agrega +0) donde exista )) porque es 
			 * necesario para crear las piezas */
			string nuevo = ConLetrasValidas.ToString();
			while (nuevo.IndexOf("))") != -1) 
				nuevo = nuevo.Replace("))", ")+0)");
			ConLetrasValidas = new StringBuilder(nuevo);

			/* Validación de sintaxis, se genera una copia 
			 * y allí se reemplaza las funciones por a+( */
			StringBuilder sbSintax = new StringBuilder();
			sbSintax.Append(ConLetrasValidas);
			sbSintax.Replace("sen(", "a+(");
			sbSintax.Replace("cos(", "a+(");
			sbSintax.Replace("tan(", "a+(");
			sbSintax.Replace("abs(", "a+(");
			sbSintax.Replace("asn(", "a+(");
			sbSintax.Replace("acs(", "a+(");
			sbSintax.Replace("atn(", "a+(");
			sbSintax.Replace("log(", "a+(");
			sbSintax.Replace("cei(", "a+(");
			sbSintax.Replace("exp(", "a+(");
			sbSintax.Replace("sqr(", "a+(");

			for (int Cont = 1; Cont < sbSintax.Length - 2; Cont++) {
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
			if (EsUnOperador(sbSintax[1])) return 22;
			if (EsUnOperador(sbSintax[sbSintax.Length - 2])) return 23;

			/* Valida balance de paréntesis */
			int ParentesisAbre = 0; /* Contador de paréntesis que abre */
			int ParentesisCierra = 0; /* Contador de paréntesis que cierra */
			for (int Cont = 1; Cont < sbSintax.Length - 1; Cont++) {
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

			/* Deja la expresión para ser analizada. 
			 * Reemplaza las funciones de tres letras
			 * por una letra mayúscula. Cambia los )) 
			 * por )+0) porque es requerido al crear las piezas */
			this.Analizada.Length = 0;
			this.Analizada.Append(ConLetrasValidas);
			this.Analizada.Replace("sen", "A");
			this.Analizada.Replace("cos", "B");
			this.Analizada.Replace("tan", "C");
			this.Analizada.Replace("abs", "D");
			this.Analizada.Replace("asn", "E");
			this.Analizada.Replace("acs", "F");
			this.Analizada.Replace("atn", "G");
			this.Analizada.Replace("log", "H");
			this.Analizada.Replace("exp", "I");
			this.Analizada.Replace("sqr", "J");

			/* Sintaxis correcta */
			return 0;
		}

		/* Retorna si el Caracter es un operador matemático */
		private static bool EsUnOperador(char Caracter) {
			switch (Caracter) {
				case '+':
				case '-':
				case '*':
				case '/':
				case '^':
					return true;
				default:
					return false;
			}
		}
	}
}