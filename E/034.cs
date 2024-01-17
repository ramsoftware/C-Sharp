namespace Ejemplo {
	class Program {
		static void Main() {
			//Se define una lista ordenada: llave, cadena
			//En este caso la llave es una cadena
			SortedList<string, string> Extensiones = new SortedList<string, string> {
				{"exe", "Ejecutable"},
				{"com", "Ejecutable DOS"},
				{"vb", "Visual Basic .NET"},
				{"cs", "C#"},
				{"js", "JavaScript"},
				{"xlsx", "Excel"},
				{"docx", "Word"},
				{"html", "HTML 5"}
			};

			Extensiones.Add("pptx", "PowerPoint"); //Otra forma de adicionar

			//Imprime la lista ordenada
			foreach (object elemento in Extensiones) Console.WriteLine(elemento);

			//Imprime llave y valor
			var ListaLlaves = Extensiones.Keys;
			Console.WriteLine("\r\nImprime llave y valor en separado");
			foreach (string Llave in ListaLlaves) {
				Console.WriteLine("Llave: " + Llave +  " Valor: " + Extensiones[Llave]);
			}
		}
	}
}
