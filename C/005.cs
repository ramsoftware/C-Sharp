namespace Ejemplo {
	internal class Program {
		static void Main() {
			//Arreglo unidimensional
			string[] cadenas = [ "naranja", "manzana", "pera", "coco" ];

			//Tamaño
			int TamanoCadenas = cadenas.Length;

			//Recorre el arreglo y lo imprime
			for (int posicion=0; posicion<TamanoCadenas; posicion++) {
				Console.WriteLine(cadenas[posicion]);
			}
		}
	}
}