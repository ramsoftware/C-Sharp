namespace Ejemplo {

	//Una clase con varios atributos
	class MiClase {
		public int Numero { get; set; }
		public double Valor { get; set; }
		public char Caracter { get; set; }
		public string Cadena { get; set; }

		public MiClase(int Numero, double Valor, char Caracter, string Cadena) {
			this.Numero = Numero;
			this.Valor = Valor;
			this.Caracter = Caracter;
			this.Cadena = Cadena;
		}
	}

	class Program {
		static void Main() {
			//Se define una lista enlazada
			LinkedList<MiClase> Lenguajes = new LinkedList<MiClase>();

			//Agrega al final
			Lenguajes.AddLast(new MiClase(16, 83.29, 'R', "Lenguaje R"));
			Lenguajes.AddLast(new MiClase(29, 89.7, 'A', "ADA"));
			Lenguajes.AddLast(new MiClase(2, 80.19, 'M', "Máquina"));
			Lenguajes.AddLast(new MiClase(95, 7.21, 'P', "PHP"));

			//Imprime esa lista
			Console.WriteLine("Agregando con AddLast");
			foreach (MiClase elemento in Lenguajes) Console.Write(elemento.Cadena + "; ");

			//Agrega al inicio
			Lenguajes.AddFirst(new MiClase(78, 12.32, 'C', "C#"));
			Lenguajes.AddFirst(new MiClase(55, -3.21, 'V', "Visual Basic .NET"));

			//Imprime esa lista
			Console.WriteLine("\r\n\r\nAgregando con AddFirst");
			foreach (MiClase elemento in Lenguajes) Console.Write(elemento.Cadena + "; ");

			//Agrega al final
			Lenguajes.AddLast(new MiClase(16, 83.29, 'T', "TypeScript"));
			Console.WriteLine("\r\n\r\nAgregando con AddLast");
			foreach (MiClase elemento in Lenguajes) Console.Write(elemento.Cadena + "; ");

			//Cantidad
			Console.WriteLine("\r\n\r\nCantidad es: " + Lenguajes.Count);

			//Elimina primer elemento
			Lenguajes.RemoveFirst();
			Console.WriteLine("\r\nEliminado el primer elemento");
			foreach (MiClase elemento in Lenguajes) Console.Write(elemento.Cadena + "; ");

			//Elimina último elemento
			Lenguajes.RemoveLast();
			Console.WriteLine("\r\n\r\nEliminado el último elemento");
			foreach (MiClase elemento in Lenguajes) Console.Write(elemento.Cadena + "; ");
		}
	}
}
