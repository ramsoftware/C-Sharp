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

			//Elimina un rango de elementos del ArrayList
			Console.WriteLine("Antes");
			foreach (Object objeto in Ejemplo) 
				Console.Write("{0}{1}", ";", objeto);
			Console.WriteLine("\r\n");

			int posicion = 1;
			int cantidad = 4;
			Ejemplo.RemoveRange(posicion, cantidad);

			Console.WriteLine("Después");
			foreach (Object objeto in Ejemplo) 
				Console.Write("{0}{1}", ";", objeto);
		}
	}
}
