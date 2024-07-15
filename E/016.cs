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
			Ejemplo.Add("KL");
			Ejemplo.Add("OP");
			Ejemplo.Add("IJ");
			Ejemplo.Add("CD");
			Ejemplo.Add("EF");

			//Imprime el ArrayList
			Console.WriteLine("ArrayList Original");
			for (int cont = 0; cont < Ejemplo.Count; cont++) 
				Console.Write(Ejemplo[cont] + "; ");
			Console.WriteLine("\r\n");

			//Ordena el ArrayList
			Ejemplo.Sort();

			//Imprime de nuevo el ArrayList
			Console.WriteLine("ArrayList Ordenado");
			for (int cont = 0; cont < Ejemplo.Count; cont++) 
				Console.Write(Ejemplo[cont] + "; ");
			Console.WriteLine("\r\n");

			//Busca en forma binaria en el ArrayList
			string Buscar = "KL";
			int pos = Ejemplo.BinarySearch(Buscar);
			Console.WriteLine("Buscando: " + Buscar);
			Console.WriteLine("Encontrado en: " + pos);
		}
	}
}
