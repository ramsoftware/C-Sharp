namespace Ejemplo {
	class Ejemplo {
		//Atributos variados
		public int ValorEntero { get; set; }
		public double NumeroReal { get; set; }
		public char Caracter { get; set; }
		public string Cadena { get; set; }

		//Constructor
		public Ejemplo(int ValorEntero, double NumeroReal, char Caracter, string Cadena) {
			this.ValorEntero = ValorEntero;
			this.NumeroReal = NumeroReal;
			this.Caracter = Caracter;
			this.Cadena = Cadena;
		}

		//Imprime los valores
		public void Imprime() {
			Console.WriteLine("\r\nEntero: " + ValorEntero.ToString());
			Console.WriteLine("Real: " + NumeroReal.ToString());
			Console.WriteLine("Caracter: " + Caracter.ToString());
			Console.WriteLine("Cadena: [" + Cadena + "]");
		}
	}
	
	class Program {
		static void Main() {
			List<Ejemplo> listado = new List<Ejemplo>();

			//Adiciona objetos a la lista
			listado.Add(new Ejemplo(16, 83.29, 'R', "Ruiseñor"));
			listado.Add(new Ejemplo(29, 89.7, 'A', "Águila"));
			listado.Add(new Ejemplo(2, 80.19, 'M', "Manatí"));
			listado.Add(new Ejemplo(95, 7.21, 'P', "Puma"));

			//Llama al método de imprimir del objeto
			for (int cont = 0; cont < listado.Count; cont++) listado[cont].Imprime();

			//Inserta un objeto
			listado.Insert(1, new Ejemplo(88, 3.33, 'Z', "QQQQQQQQ"));

			//Elimina un objeto
			listado.RemoveAt(3);

			//Llama al método de imprimir del objeto
			Console.WriteLine("\r\nDespués de modificar");
			for (int cont = 0; cont < listado.Count; cont++) listado[cont].Imprime();

			Console.WriteLine("\r\nFinal");
		}
	}
}
