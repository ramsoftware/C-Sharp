namespace Ejemplo {
	internal class Program {
		static void Main() {
			//Arreglo unidimensional
			string[] cadenas = [ "naranja", "manzana", "pera", "coco" ];

			//Tamaño
			int TCadenas = cadenas.Length;

			//Recorre el arreglo y lo imprime
			for (int pos=0; pos < TCadenas; pos++) {
				Console.WriteLine(cadenas[pos]);
			}
		}
	}
}