namespace Ejemplo {
	internal class Program {
		static void Main() {
			//Arreglo unidimensional. Definición.
			int[] arreglo = new int[5];

			//Asignando valores a cada posición del arreglo
			arreglo[0] = 891;
			arreglo[1] = 302;
			arreglo[2] = 465;
			arreglo[3] = 743;
			arreglo[4] = 847;

			//Imprimiendo valores
			Console.WriteLine("En posición 0 el valor es " + arreglo[0].ToString());
			Console.WriteLine("En posición 1 el valor es " + arreglo[1].ToString());
			Console.WriteLine("En posición 2 el valor es " + arreglo[2].ToString());
			Console.WriteLine("En posición 3 el valor es " + arreglo[3].ToString());
			Console.WriteLine("En posición 4 el valor es " + arreglo[4].ToString());
		}
	}
}
