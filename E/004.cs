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
			Ejemplo.Add("Pingüinos");
			Ejemplo.Add("Calamar");
			Ejemplo.Add("Foca");
			Ejemplo.Add("Manaties");

			//Imprime valores
			foreach (Object objeto in Ejemplo) 
				Console.Write("{0}{1}", ";", objeto);
			Console.WriteLine("\r\n");

			//Inserta una cadena en la posición 4 de la lista
			Ejemplo.Insert(4, "CACATÚA");

			//Imprime valores
			foreach (Object objeto in Ejemplo) 
				Console.Write("{0}{1}", ";", objeto);
		}
	}
}
