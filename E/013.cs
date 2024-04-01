using System.Collections;

namespace Ejemplo {
	class Program {
		public static void Main() {
			//Declara la lista que almacenará cadenas
			ArrayList Ejemplo = new ArrayList();

			//Adiciona elementos a la lista
			Ejemplo.Add("AB");
			Ejemplo.Add("CD");
			Ejemplo.Add("EF");
			Ejemplo.Add("GH");
			Ejemplo.Add("IJ");
			Ejemplo.Add("KL");
			Ejemplo.Add("MN");
			Ejemplo.Add("OP");

			//Imprime el ArrayList
			for (int cont = 0; cont < Ejemplo.Count; cont++) Console.Write(Ejemplo[cont] + "; ");
			Console.WriteLine("\r\n");

			//Aplica Reverse()
			Ejemplo.Reverse();

			//Imprime de nuevo el ArrayList
			for (int cont = 0; cont < Ejemplo.Count; cont++) Console.Write(Ejemplo[cont] + "; ");
		}
	}
}
