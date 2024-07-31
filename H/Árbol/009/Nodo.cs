namespace ArbolBinarioEvaluador {
	internal class Nodo {
		public char Operador; //+ - * / ^
		public double Numero;
		public int Variable;
		public int Funcion;
		public Nodo Izquierda, Derecha;

		//Si el nodo tiene operador + - * / ^
		public Nodo(char Operador) {
			Variable = -1;
			Numero = 0;
			this.Operador = Operador;
			Funcion = -1;
			Izquierda = null;
			Derecha = null;
		}

		//Si el Nodo sólo tiene número
		public Nodo(double Numero) {
			Variable = -1;
			this.Numero = Numero;
			Operador = '#';
			Funcion = -1;
			Izquierda = null;
			Derecha = null;
		}

		//Si el Nodo sólo tiene variable
		public Nodo(int Variable) {
			this.Variable = Variable;
			Numero = 0;
			Operador = '#';
			Funcion = -1;
			Izquierda = null;
			Derecha = null;
		}

		//Si el Nodo es de una función
		public Nodo(int Funcion, bool EsFuncion) {
			Variable = -1;
			Numero = 0;
			Operador = '#';
			this.Funcion = Funcion;
			Izquierda = null;
			Derecha = null;
		}
	}
}
