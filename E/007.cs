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

			//Limpia el ArrayList
			Console.WriteLine("(Antes) Total de elementos: " + Ejemplo.Count);
			Ejemplo.Clear();
			Console.WriteLine("(Después) Total de elementos: " + Ejemplo.Count);
		}
	}
}
