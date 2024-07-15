using System.Collections;

namespace Ejemplo {
	class Program {
		public static void Main() {
			//Declara la lista que almacenará cadenas
			ArrayList Ejemplo = new();

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

			//Recorrido con foreach
			Console.WriteLine("Recorrido con foreach");
			foreach (Object objeto in Ejemplo) 
				Console.Write("{0}{1}", ";", objeto);
			Console.WriteLine("\r\n");

			//Recorrido con for
			Console.WriteLine("Recorrido con for");
			for (int cont = 0; cont < Ejemplo.Count; cont++) 
				Console.Write("{0}{1}", ";", Ejemplo[cont]);
			Console.WriteLine("\r\n");

			//Recorrido con un IEnumerator
			Console.WriteLine("Recorrido con un IEnumerator");
			IEnumerator elemento = Ejemplo.GetEnumerator();
			while (elemento.MoveNext()) 
				Console.Write("{0}{1}", ";", elemento.Current);
		}
	}
}
