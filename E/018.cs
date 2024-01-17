using System.Collections;

namespace Ejemplo {
	class Program {
		public static void Main() {
			//Declara la lista que almacenará cadenas
			ArrayList Ejemplo = new ArrayList();

			//Agrega diferentes tipos de datos
			Ejemplo.Add("Rafael Alberto Moreno Parra");
			Ejemplo.Add(720626);
			Ejemplo.Add(1.6832929);
			Ejemplo.Add('J');
			Ejemplo.Add(true);

			//Muestra el contenido y el tipo de cada elemento
			for (int cont=0; cont < Ejemplo.Count; cont++) {
				Console.WriteLine(Ejemplo[cont] + " tipo es: " + Ejemplo[cont].GetType());
			}
			Console.WriteLine("\r\n");

			//Y compara
			for (int cont = 0; cont < Ejemplo.Count; cont++) {
				Console.Write(Ejemplo[cont]);
				if (Ejemplo[cont].GetType() == typeof(int)) Console.WriteLine(" es un entero");
				if (Ejemplo[cont].GetType() == typeof(char)) Console.WriteLine(" es un caracter");
				if (Ejemplo[cont].GetType() == typeof(double)) Console.WriteLine(" es un real");
				if (Ejemplo[cont].GetType() == typeof(string)) Console.WriteLine(" es una cadena");
				if (Ejemplo[cont].GetType() == typeof(bool)) Console.WriteLine(" es un booleano");
			}
		}
	}
}
