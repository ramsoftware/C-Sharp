namespace Ejemplo {
	//Una clase con varios atributos
	class Ejemplo {
		public int Numero { get; set; }
		public double Valor { get; set; }
		public char Caracter { get; set; }
		public string Cadena { get; set; }

		public Ejemplo(int Numero, double Valor, char Caracter, string Cadena) {
			this.Numero = Numero;
			this.Valor = Valor;
			this.Caracter = Caracter;
			this.Cadena = Cadena;
		}
	}
	
	class Program {
		static void Main() {
			//Se define una pila de tipo objeto personalizado
			Stack<Ejemplo> Pila = new Stack<Ejemplo>();

			//Se agregan elementos a la pila
			Pila.Push(new Ejemplo(1, 0.2, 'r', "Leafar"));
			Pila.Push(new Ejemplo(8, -7.1, 'a', "Otrebla"));
			Pila.Push(new Ejemplo(23, -13.6, 'm', "Onerom"));
			Pila.Push(new Ejemplo(49, 16.83, 'p', "Arrap"));

			//Número de elmentos en la pila
			Console.WriteLine("Número de elementos: " + Pila.Count);

			//Imprimir la pila
			Console.WriteLine("\r\nElementos: ");
			foreach (Ejemplo elemento in Pila) Console.Write(elemento.Cadena + ", ");

			//Quitar elemento de la pila
			Pila.Pop(); //Último en llegar, primero en salir
			Console.WriteLine("\r\nAl quitar un elemento de la pila: ");
			foreach (Ejemplo elemento in Pila) Console.Write(elemento.Cadena + ", ");

			//Obtener el primer elemento de la pila sin borrar ese elemento
			Ejemplo PrimerElemento = Pila.Peek();
			Console.WriteLine("\r\n\r\nElemento más arriba de la pila: " + PrimerElemento.Cadena);

			//Leer y borrar la pila
			Console.WriteLine("\r\nLee y borra la pila: ");
			while (Pila.Count > 0)
				Console.Write(Pila.Pop().Cadena + "; ");
			Console.WriteLine("\r\nNúmero de elementos: " + Pila.Count);

			//Agrega elementos a la pila y luego la borra
			Pila.Push(new Ejemplo(7, 6.5, 'z', "qwerty"));
			Pila.Push(new Ejemplo(4, -3.2, 'y', "asdfg"));
			Console.WriteLine("\r\nNúmero de elementos: " + Pila.Count);
			Pila.Clear();
			Console.WriteLine("Después de borrar. Número de elementos: " + Pila.Count);
		}
	}
}
