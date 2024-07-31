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
}
