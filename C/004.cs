namespace Ejemplo {
	internal class Program {
		static void Main() {
			//Arreglo unidimensional. Tamaños.
			string[] cadenas = [ "naranja", "manzana", "pera", "coco" ];
			int[] numeros = new int[8];

			//Tamaños de los arreglos
			int TamanoCadenas = cadenas.Length;
			int TamanoNumeros = numeros.Length;

			//Imprime
			Console.WriteLine("Tamaño de arreglo cadenas:" + TamanoCadenas.ToString());
			Console.WriteLine("Tamaño de arreglo numeros:" + TamanoNumeros.ToString());
		}
	}
}
