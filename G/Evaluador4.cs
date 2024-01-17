/* Evaluador de expresiones versión 4 (enero de 2024)
 * Autor: Rafael Alberto Moreno Parra
 * Correo: ramsoftware@gmail.com ;  enginelife@hotmail.com
 * URL: http://darwin.50webs.com 
 * GitHub: https://github.com/ramsoftware
 * */

using System.Globalization;
using System.Text;

namespace Ejemplo {

	internal class ParteEvl4 {
		/* Constantes de los diferentes tipos de datos que tendrán las piezas */
		private const int ESFUNCION = 1;
		private const int ESPARABRE = 2;
		private const int ESOPERADOR = 4;
		private const int ESNUMERO = 5;
		private const int ESVARIABLE = 6;

		public int Tipo; /* Acumulador, función, paréntesis que abre, paréntesis que cierra, operador, número, variable */
		public int Funcion; /* Código de la función 0:seno, 1:coseno, 2:tangente, 3: valor absoluto, 4: arcoseno, 5: arcocoseno, 6: arcotangente, 7: logaritmo natural, 8: valor tope, 9: exponencial, 10: raíz cuadrada */
		public int Operador; /* + suma - resta * multiplicación / división ^ potencia */
		public int posNumero; /* Posición en lista de valores del número literal, por ejemplo: 3.141592 */
		public int posVariable; /* Posición en lista de valores del valor de la variable algebraica */
		public int posAcumula; /* Posición en lista de valores del valor de la pieza. Por ejemplo:
				3 + 2 / 5  se convierte así:
				|3| |+| |2| |/| |5| 
				|3| |+| |A|  A es un identificador de acumulador */

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
		public int PosResultado; /* Posición donde se almacena el valor que genera la pieza al evaluarse */
		public int Funcion; /* Código de la función 0:seno, 1:coseno, 2:tangente, 3: valor absoluto, 4: arcoseno, 5: arcocoseno, 6: arcotangente, 7: logaritmo natural, 8: valor tope, 9: exponencial, 10: raíz cuadrada, 11: raíz cúbica */
		public int PosValorA; /* Posición donde se almacena la primera parte de la pieza */
		public int Operador; /* 0 suma 1 resta 2 multiplicación 3 división 4 potencia */
		public int PosValorB; /* Posición donde se almacena la segunda parte de la pieza */
	}


	internal class Evaluador4 {
		/* Constantes de los diferentes tipos de datos que tendrán las piezas */
		private const int ESFUNCION = 1;
		private const int ESPARABRE = 2;
		private const int ESPARCIERRA = 3;
		private const int ESOPERADOR = 4;
		private const int ESNUMERO = 5;
		private const int ESVARIABLE = 6;
		private const int ESACUMULA = 7;

		/* Expresión algebraica convertida de la original dada por el usuario */
		private StringBuilder ParaSerAnalizada = new StringBuilder();

		/* Donde guarda los valores de variables, constantes y piezas */
		private List<double> Valores = new List<double>();

		/* Listado de partes en que se divide la expresión
		   Toma una expresión, por ejemplo: 1.68 + sen( 3 / x ) * ( 2.9 ^ 2 - 9 ) y la divide en partes así:
		   [1.68] [+] [sen(] [3] [/] [x] [)] [*] [(] [2.9] [^] [2] [-] [9] [)]
		   Cada parte puede tener un número, un operador, una función, un paréntesis que abre o un paréntesis que cierra.
		   En esta versión 4.0, las constantes, piezas y variables guardan sus valores en la lista Valores. En 
		   partes, se almacena la posición en Valores */
		private List<ParteEvl4> Partes = new List<ParteEvl4>();

		/* Listado de piezas que ejecutan
			Toma las partes y las divide en piezas con la siguiente estructura:
			acumula = funcion  numero/variable/acumula  operador  numero/variable/acumula
			Siguiendo el ejemplo anterior sería:
			A =  2.9  ^  2
			B =  A  -  9
			C =  seno ( 3  /  x )
			D =  C  *  B
			E =  1.68 + D

		   Esas piezas se evalúan de arriba a abajo y así se interpreta la ecuación */
		private List<PiezaEvl4> Piezas = new List<PiezaEvl4>();

		/* Analiza la expresión */
		public int Analizar(string ExpresionOriginal) {
			Partes.Clear();
			Piezas.Clear();
			Valores.Clear();

			/* Hace espacio para las 26 variables que puede manejar el evaluador */
			for (int Variables = 1; Variables <= 26; Variables++) Valores.Add(0);

			int Sintaxis = ChequeaSintaxis(ExpresionOriginal);
			if (Sintaxis == 0) {
				CrearPartes();
				CrearPiezas();
			}
			return Sintaxis;
		}

		/* Retorna mensaje de error sintáctico */
		public string MensajeError(int CodigoError) {
			string Mensaje = "";
			switch (CodigoError) {
				case 1: Mensaje = "1. Un número seguido de una letra. Ejemplo: 2q-(*3)"; break;
				case 2: Mensaje = "2. Un número seguido de un paréntesis que abre. Ejemplo: 7-2(5-6)"; break;
				case 3: Mensaje = "3. Doble punto seguido. Ejemplo: 3..1"; break;
				case 4: Mensaje = "4. Punto seguido de operador. Ejemplo: 3.*1"; break;
				case 5: Mensaje = "5. Un punto y sigue una letra. Ejemplo: 3+5.w-8"; break;
				case 6: Mensaje = "6. Punto seguido de paréntesis que abre. Ejemplo: 2-5.(4+1)*3"; break;
				case 7: Mensaje = "7. Punto seguido de paréntesis que cierra. Ejemplo: 2-(5.)*3"; break;
				case 8: Mensaje = "8. Un operador seguido de un punto. Ejemplo: 2-(4+.1)-7"; break;
				case 9: Mensaje = "9. Dos operadores estén seguidos. Ejemplo: 2++4, 5-*3"; break;
				case 10: Mensaje = "10. Un operador seguido de un paréntesis que cierra. Ejemplo: 2-(4+)-7"; break;
				case 11: Mensaje = "11. Una letra seguida de número. Ejemplo: 7-2a-6"; break;
				case 12: Mensaje = "12. Una letra seguida de punto. Ejemplo: 7-a.-6"; break;
				case 13: Mensaje = "13. Una letra seguida de otra letra. Ejemplo: 4-xy+3"; break;
				case 14: Mensaje = "14. Una letra seguida de un paréntesis que abre. Ejemplo: 2-a(8*3)"; break;
				case 15: Mensaje = "15. Un paréntesis que abre seguido de un punto. Ejemplo: 7-(.8+4)-6"; break;
				case 16: Mensaje = "16. Un paréntesis que abre y sigue un operador. Ejemplo: (+3-5)*7"; break;
				case 17: Mensaje = "17. Un paréntesis que abre y sigue un paréntesis que cierra. Ejemplo: 4+()*2"; break;
				case 18: Mensaje = "18. Un paréntesis que cierra y sigue un número. Ejemplo: (3-5)8"; break;
				case 19: Mensaje = "19. Un paréntesis que cierra y sigue un punto. Ejemplo: (3-5).+2"; break;
				case 20: Mensaje = "20. Un paréntesis que cierra y sigue una letra. Ejemplo: 2-(7*3)k+7"; break;
				case 21: Mensaje = "21. Un paréntesis que cierra y sigue un paréntesis que abre. Ejemplo: (4-3)(2+1)"; break;
				case 22: Mensaje = "22. Inicia con un operador. Ejemplo: *3+5"; break;
				case 23: Mensaje = "23. Finaliza con un operador. Ejemplo: 7+9*"; break;
				case 24: Mensaje = "24. No hay correspondencia entre paréntesis que cierran y abren"; break;
				case 25: Mensaje = "25. El número de paréntesis que cierran no es igual al número de paréntesis que abren"; break;
				case 26: Mensaje = "26. Dos o más puntos en número real"; break;
			}
			return Mensaje;
		}

		/* Da valor a las variables que tendrá la expresión algebraica */
		public void DarValorVariable(char varAlgebra, double Valor) {
			Valores[varAlgebra - 'a'] = Valor;
		}

		/* Evalúa la expresión convertida en piezas */
		public double Evaluar() {
			double Resultado = 0;
			PiezaEvl4 tmpPieza;

			/* Va de pieza en pieza */
			for (int Posicion = 0; Posicion < Piezas.Count; Posicion++) {
				tmpPieza = Piezas[Posicion];

				switch (tmpPieza.Operador) {
					case 0: Resultado = Valores[tmpPieza.PosValorA] + Valores[tmpPieza.PosValorB]; break;
					case 1: Resultado = Valores[tmpPieza.PosValorA] - Valores[tmpPieza.PosValorB]; break;
					case 2: Resultado = Valores[tmpPieza.PosValorA] * Valores[tmpPieza.PosValorB]; break;
					case 3: Resultado = Valores[tmpPieza.PosValorA] / Valores[tmpPieza.PosValorB]; break;
					default: Resultado = Math.Pow(Valores[tmpPieza.PosValorA], Valores[tmpPieza.PosValorB]); break;
				}

				switch (tmpPieza.Funcion) {
					case 0: Resultado = Math.Sin(Resultado); break;
					case 1: Resultado = Math.Cos(Resultado); break;
					case 2: Resultado = Math.Tan(Resultado); break;
					case 3: Resultado = Math.Abs(Resultado); break;
					case 4: Resultado = Math.Asin(Resultado); break;
					case 5: Resultado = Math.Acos(Resultado); break;
					case 6: Resultado = Math.Atan(Resultado); break;
					case 7: Resultado = Math.Log(Resultado); break;
					case 8: Resultado = Math.Ceiling(Resultado); break;
					case 9: Resultado = Math.Exp(Resultado); break;
					case 10: Resultado = Math.Sqrt(Resultado); break;
				}

				Valores[tmpPieza.PosResultado] = Resultado;
			}
			return Resultado;
		}

		/* Divide la expresión en partes, yendo de caracter en caracter */
		private void CrearPartes() {
			StringBuilder Numero = new StringBuilder();
			for (int Posicion = 0; Posicion < this.ParaSerAnalizada.Length; Posicion++) {
				char Letra = this.ParaSerAnalizada[Posicion];
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
					case '9':   /* Si es un digito o un punto va acumulando el número */
						Numero.Append(Letra); break;
					case '+':
					case '-':
					case '*':
					case '/':
					case '^':   /* Si es un operador matemático entonces verifica si hay un número que se ha acumulado */
						if (Numero.Length > 0) {
							Valores.Add(double.Parse(Numero.ToString(), CultureInfo.InvariantCulture));
							Partes.Add(new ParteEvl4(ESNUMERO, Valores.Count - 1));
							Numero.Clear();
						}
						/* Agregar el operador matemático */
						Partes.Add(new ParteEvl4(Letra));
						break;

					case '(':   /* Es paréntesis que abre */
						Partes.Add(new ParteEvl4(ESPARABRE, 0));
						break;

					case ')':   /* Si es un paréntesis que cierra entonces verifica si hay un número que se ha acumulado */
						if (Numero.Length > 0) {
							Valores.Add(double.Parse(Numero.ToString(), CultureInfo.InvariantCulture));
							Partes.Add(new ParteEvl4(ESNUMERO, Valores.Count - 1));
							Numero.Clear();
						}

						/* Si sólo había un número o variable dentro del paréntesis le agrega + 0 (por ejemplo:  sen(x) o 3*(2) ) */
						if (Partes[Partes.Count - 2].Tipo == ESPARABRE || Partes[Partes.Count - 2].Tipo == ESFUNCION) {
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
						Posicion++;
						break;
					default:
						Partes.Add(new ParteEvl4(ESVARIABLE, Letra - 'a'));
						break;
				}
			}
		}

		/* Convierte las partes en las piezas finales de ejecución */
		private void CrearPiezas() {
			int Contador = Partes.Count - 1;
			do {
				ParteEvl4 tmpParte = Partes[Contador];
				if (tmpParte.Tipo == ESPARABRE || tmpParte.Tipo == ESFUNCION) {
					GenerarPiezasOperador(4, 4, Contador);  /* Evalúa las potencias */
					GenerarPiezasOperador(2, 3, Contador);  /* Luego evalúa multiplicar y dividir */
					GenerarPiezasOperador(0, 1, Contador);  /* Finalmente evalúa sumar y restar */

					if (tmpParte.Tipo == ESFUNCION) { /* Agrega la función a la última pieza */
						Piezas[Piezas.Count - 1].Funcion = tmpParte.Funcion;
					}

					/* Quita el paréntesis/función que abre y el que cierra, dejando el centro */
					Partes.RemoveAt(Contador);
					Partes.RemoveAt(Contador + 1);
				}
				Contador--;
			} while (Contador >= 0);
		}

		/* Genera las piezas buscando determinado operador */
		private void GenerarPiezasOperador(int OperA, int OperB, int Inicia) {
			int Contador = Inicia + 1;
			do {
				ParteEvl4 tmpParte = Partes[Contador];
				if (tmpParte.Tipo == ESOPERADOR && (tmpParte.Operador == OperA || tmpParte.Operador == OperB)) {
					ParteEvl4 tmpParteIzq = Partes[Contador - 1];
					ParteEvl4 tmpParteDer = Partes[Contador + 1];

					/* Crea Pieza */
					PiezaEvl4 NuevaPieza = new PiezaEvl4();
					NuevaPieza.Funcion = -1;

					switch (tmpParteIzq.Tipo) {
						case ESNUMERO: NuevaPieza.PosValorA = tmpParteIzq.posNumero; break;
						case ESVARIABLE: NuevaPieza.PosValorA = tmpParteIzq.posVariable; break;
						default: NuevaPieza.PosValorA = tmpParteIzq.posAcumula; break;
					}

					NuevaPieza.Operador = tmpParte.Operador;

					switch (tmpParteDer.Tipo) {
						case ESNUMERO: NuevaPieza.PosValorB = tmpParteDer.posNumero; break;
						case ESVARIABLE: NuevaPieza.PosValorB = tmpParteDer.posVariable; break;
						default: NuevaPieza.PosValorB = tmpParteDer.posAcumula; break;
					}

					/* Añade a lista de piezas y crea una nueva posición en Valores */
					Valores.Add(0);
					NuevaPieza.PosResultado = Valores.Count - 1;
					Piezas.Add(NuevaPieza);

					/* Elimina la parte del operador y la siguiente */
					Partes.RemoveAt(Contador);
					Partes.RemoveAt(Contador);

					/* Retorna el contador en uno para tomar la siguiente operación */
					Contador--;

					/* Cambia la parte anterior por parte que acumula */
					tmpParteIzq.Tipo = ESACUMULA;
					tmpParteIzq.posAcumula = NuevaPieza.PosResultado;
				}
				Contador++;
			} while (Partes[Contador].Tipo != ESPARCIERRA);
		}

		private int ChequeaSintaxis(string ExpresionOriginal) {
			/* Primero a minúsculas */
			StringBuilder Minusculas = new StringBuilder(ExpresionOriginal.ToLower());

			/* Sólo los caracteres válidos */
			HashSet<char> Permitidos = new HashSet<char>("abcdefghijklmnopqrstuvwxyz0123456789.+-*/^()");
			StringBuilder ConLetrasValidas = new StringBuilder("(");
			for (int Contador = 0; Contador < Minusculas.Length; Contador++)
				if (Permitidos.Contains(Minusculas[Contador]))
					ConLetrasValidas.Append(Minusculas[Contador]);
			ConLetrasValidas.Append(')');

			/* Agrega +0) donde exista )) porque es necesario para crear las piezas */
			string nuevo = ConLetrasValidas.ToString();
			while (nuevo.IndexOf("))") != -1) nuevo = nuevo.Replace("))", ")+0)");
			ConLetrasValidas = new StringBuilder(nuevo);

			/* Validación de sintaxis, se genera una copia y allí se reemplaza las funciones por a+( */
			StringBuilder ParaChequearSintaxis = new StringBuilder();
			ParaChequearSintaxis.Append(ConLetrasValidas);
			ParaChequearSintaxis.Replace("sen(", "a+(").Replace("cos(", "a+(").Replace("tan(", "a+(").Replace("abs(", "a+(").Replace("asn(", "a+(").Replace("acs(", "a+(").Replace("atn(", "a+(").Replace("log(", "a+(").Replace("cei(", "a+(").Replace("exp(", "a+(").Replace("sqr(", "a+(");

			for (int Contador = 1; Contador < ParaChequearSintaxis.Length - 2; Contador++) {
				char cA = ParaChequearSintaxis[Contador];
				char cB = ParaChequearSintaxis[Contador + 1];

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
			if (EsUnOperador(ParaChequearSintaxis[1])) return 22;
			if (EsUnOperador(ParaChequearSintaxis[ParaChequearSintaxis.Length - 2])) return 23;

			/* Valida balance de paréntesis */
			int ParentesisAbre = 0; /* Contador de paréntesis que abre */
			int ParentesisCierra = 0; /* Contador de paréntesis que cierra */
			for (int Contador = 1; Contador < ParaChequearSintaxis.Length-1; Contador++) {
				switch (ParaChequearSintaxis[Contador]) {
					case '(': ParentesisAbre++; break;
					case ')': ParentesisCierra++; break;
				}
				if (ParentesisCierra > ParentesisAbre) return 24;
			}
			if (ParentesisAbre != ParentesisCierra) return 25;

			/* Validar los puntos decimales de un número real */
			int TotalPuntos = 0;
			for (int Contador = 0; Contador < ParaChequearSintaxis.Length; Contador++) {
				if (EsUnOperador(ParaChequearSintaxis[Contador])) TotalPuntos = 0;
				if (ParaChequearSintaxis[Contador] == '.') TotalPuntos++;
				if (TotalPuntos > 1) return 26;
			}

			/* Deja la expresión para ser analizada. Reemplaza las funciones de tres letras por una letra mayúscula. Cambia los )) por )+0) porque es requerido al crear las piezas */
			this.ParaSerAnalizada.Length = 0;
			this.ParaSerAnalizada.Append(ConLetrasValidas);
			this.ParaSerAnalizada.Replace("sen", "A").Replace("cos", "B").Replace("tan", "C").Replace("abs", "D").Replace("asn", "E").Replace("acs", "F").Replace("atn", "G").Replace("log", "H").Replace("exp", "I").Replace("sqr", "J");

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

