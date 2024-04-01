using System.Collections;

namespace Ejemplo {
	class Program {
		public static void Main() {
			//Declara tres ArrayList
			ArrayList ListaA = new ArrayList();
			ArrayList ListaB = new ArrayList();
			ArrayList ListaC = new ArrayList();

			//Adiciona elementos a esos ArrayList
			ListaA.Add("A");
			ListaA.Add("B");
			ListaA.Add("C");
			ListaB.Add("7");
			ListaB.Add("8");
			ListaB.Add("9");
			ListaC.Add("qw");
			ListaC.Add("er");
			ListaC.Add("ty");

			//Inserta los dos primeros ArrayList en el tercero
			int posicionInserta = 1;
			ListaC.InsertRange(posicionInserta, ListaA);

			posicionInserta = 5;
			ListaC.InsertRange(posicionInserta, ListaB);

			//Imprime el ArrayList
			for (int cont = 0; cont < ListaC.Count; cont++) Console.Write(ListaC[cont] + "; ");
			Console.WriteLine("\r\n");

			//Modifica ListaA y se chequea si eso afectó a ListaC 
			ListaA[0] = "CACATÚA";
			for (int cont = 0; cont < ListaC.Count; cont++) Console.Write(ListaC[cont] + "; ");
		}
	}
}
