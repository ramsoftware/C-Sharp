namespace Ejemplo {
	class Ejemplo {
		//Atributos variados
		public int Entero { get; set; }
		public double Num { get; set; }
		public char Car { get; set; }
		public string Cad { get; set; }

		//Constructor
		public Ejemplo(int Entero, double Num, char Car, string Cad) {
			this.Entero = Entero;
			this.Num = Num;
			this.Car = Car;
			this.Cad = Cad;
		}

		//Imprime los valores
		public void Imprime() {
			Console.WriteLine("\r\nEntero: " + Entero);
			Console.WriteLine("Real: " + Num);
			Console.WriteLine("Caracter: " + Car);
			Console.WriteLine("Cadena: [" + Cad + "]");
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
			for (int cont = 0; cont < listado.Count; cont++)
				listado[cont].Imprime();

			//Inserta un objeto
			listado.Insert(1, new Ejemplo(88, 3.33, 'Z', "QQQQQ"));

			//Elimina un objeto
			listado.RemoveAt(3);

			//Llama al método de imprimir del objeto
			Console.WriteLine("\r\nDespués de modificar");
			for (int cont = 0; cont < listado.Count; cont++)
				listado[cont].Imprime();

			Console.WriteLine("\r\nFinal");
		}
	}
}
