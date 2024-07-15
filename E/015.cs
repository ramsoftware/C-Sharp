using System.Collections;

namespace Ejemplo {
	class Program {
		public static void Main() {
			//Declara la lista que almacenará cadenas
			ArrayList Ejemplo = new();

			//Adiciona elementos a la lista
			Ejemplo.Add("GH");
			Ejemplo.Add("MN");
			Ejemplo.Add("AB");
			Ejemplo.Add("OP");
			Ejemplo.Add("IJ");
			Ejemplo.Add("KL");
			Ejemplo.Add("CD");
			Ejemplo.Add("EF");

			//Imprime el ArrayList
			for (int cont = 0; cont < Ejemplo.Count; cont++) 
				Console.Write(Ejemplo[cont] + "; ");
			Console.WriteLine("\r\n");

			//Ordena el ArrayList
			Ejemplo.Sort();

			//Imprime de nuevo el ArrayList
			for (int cont = 0; cont < Ejemplo.Count; cont++) 
				Console.Write(Ejemplo[cont] + "; ");
		}
	}
}
