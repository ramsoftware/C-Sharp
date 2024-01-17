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

			//Guarda el ArrayList en un arreglo estático de tipo objeto
			Console.WriteLine("Arreglo estático de tipo objeto");
			object[] arregloEstatico = Ejemplo.ToArray();
			foreach (Object objeto in arregloEstatico) Console.Write("{0}{1}", ";", objeto);
			Console.WriteLine("\r\n");

			//Guarda el ArrayList en un arreglo estático de tipo string
			Console.WriteLine("Arreglo estático de tipo cadena");
			string[] cadenas = Ejemplo.ToArray(typeof(string)) as string[];
			for (int cont = 0; cont < cadenas.Length; cont++)
				Console.Write(cadenas[cont] + ";");
		}
	}
}
