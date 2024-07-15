namespace Ejemplo {
	class Program {
		static void Main() {
			//Se define una lista ordenada: llave, cadena
			//En este caso la llave es una cadena
			SortedList<string, string> Ext = new SortedList<string, string> {
				{"exe", "Ejecutable"},
				{"com", "Ejecutable DOS"},
				{"vb", "Visual Basic .NET"},
				{"cs", "C#"},
				{"js", "JavaScript"},
				{"xlsx", "Excel"},
				{"docx", "Word"},
				{"html", "HTML 5"}
			};

			Ext.Add("pptx", "PowerPoint"); //Otra forma de adicionar

			//Imprime la lista ordenada
			foreach (object elemento in Ext)
				Console.WriteLine(elemento);

			//Imprime llave y valor
			var ListaLlaves = Ext.Keys;
			Console.WriteLine("\r\nImprime llave y valor en separado");
			foreach (string Llave in ListaLlaves) {
				Console.Write("Llave: " + Llave);
				Console.WriteLine(" Valor: " + Ext[Llave]);
			}
		}
	}
}
