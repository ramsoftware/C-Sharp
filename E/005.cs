using System.Collections;

namespace Ejemplo {
	class Program {
		public static void Main() {
			//Declara la lista que almacenará cadenas
			ArrayList Ejemplo = new ArrayList();

			//Adiciona elementos a la lista
			Ejemplo.Add("Ballena");
			Ejemplo.Add("Tortuga marina");
			Ejemplo.Add("Tiburón");
			Ejemplo.Add("Estrella de mar");
			Ejemplo.Add("Hipocampo");
			Ejemplo.Add("Serpiente marina");
			Ejemplo.Add("Delfín");
			Ejemplo.Add("Pulpo");
			Ejemplo.Add("Caballito de mar");
			Ejemplo.Add("Coral");
			Ejemplo.Add("Pingüinos");

			//Imprime valores
			Console.WriteLine("Lista original");
			foreach (Object objeto in Ejemplo) Console.Write("{0}{1}", ";", objeto);
			Console.WriteLine("\r\n");

			//Genera nueva lista
			int posicionInicial = 5;
			int cantidad = 3;
			ArrayList nuevaLista = Ejemplo.GetRange(posicionInicial, cantidad);
			
			//Imprime valores de esa nueva lista
			Console.WriteLine("Nueva lista");
			foreach (Object objeto in nuevaLista) Console.Write("{0}{1}", ";", objeto);
			Console.WriteLine("\r\n");

			//Modifica un valor de la nueva lista
			nuevaLista[0] = "CACATÚA";

			//Imprime la lista nueva con el valor alterado
			Console.WriteLine("Nueva lista con primer valor alterado");
			foreach (Object objeto in nuevaLista) Console.Write("{0}{1}", ";", objeto);
			Console.WriteLine("\r\n");

			//Imprime de nuevo la lista original
			Console.WriteLine("Lista original");
			foreach (Object objeto in Ejemplo) Console.Write("{0}{1}", ";", objeto);
		}
	}
}
