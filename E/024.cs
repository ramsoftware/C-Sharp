namespace Ejemplo {
	class Program {
		static void Main() {
			//Se define un diccionario: llave, cadena
			//En este caso la llave es una cadena
			Dictionary<string, string> Extensiones = new Dictionary<string, string> {
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

			//Trae un elemento dada una llave
			string Llave = "cs";
			Console.WriteLine("Llave: " + Llave + " valor es: " + Extensiones[Llave]);

			//Tamaño del diccionario
			Console.WriteLine("Tamaño:" + Extensiones.Count);

			//Elimina un elemento
			Extensiones.Remove("docx");

			//Tamaño del diccionario
			Console.WriteLine("Después de eliminar. Tamaño: " + Extensiones.Count);
		}
	}
}
