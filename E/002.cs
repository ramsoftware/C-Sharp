using System.Collections;

namespace Ejemplo {
	class Program {
		static void Main() {
			//Declara la lista
			ArrayList ListaAnimales = new ArrayList();

			//Adiciona elementos a la lista
			ListaAnimales.Add("Ballena");
			ListaAnimales.Add("Tortuga marina");
			ListaAnimales.Add("Tiburón");
			ListaAnimales.Add("Hipocampo");
			ListaAnimales.Add("Delfín");
			ListaAnimales.Add("Pulpo");
			ListaAnimales.Add("Caballito de mar");
			ListaAnimales.Add("Coral");
			ListaAnimales.Add("Pingüinos");

			//Imprime la lista
			foreach (object elemento in ListaAnimales) Console.Write("{0}{1}", ";", elemento);
			Console.WriteLine(" ");

			//Retira elemento de la lista
			ListaAnimales.Remove("Hipocampo");

			//Imprime de nuevo la lista
			foreach (object elemento in ListaAnimales) Console.Write("{0}{1}", ";", elemento);
			Console.WriteLine(" ");

			//Elimina el objeto de determinada posición.
			ListaAnimales.RemoveAt(5);

			//Imprime de nuevo la lista
			foreach (object elemento in ListaAnimales) Console.Write("{0}{1}", ";", elemento);
		}
	}
}
