namespace Ejemplo {
	internal class Program {
		static void Main() {
			//Arreglo unidimensional
			string[] cadenas = [ "raf", "ael", "alb", "ert", "omo", "ren", "opa", "rra" ];

			//Ordena el arreglo
			Array.Sort(cadenas);

			//Recorre el arreglo y lo imprime
			foreach(string texto in cadenas) {
				Console.WriteLine(texto);
			}
		}
	}
}