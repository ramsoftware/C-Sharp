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

			//Un arreglo estático
			string[] Cadenas = { "Gato", "Conejo", "Liebre" };

			//Adiciona el arreglo estático al ArrayList
			Ejemplo.AddRange(Cadenas);

			//Imprime el ArrayList
			for (int cont = 0; cont < Ejemplo.Count; cont++)
				Console.Write(Ejemplo[cont] + "; ");
		}
	}
}
