namespace Ejemplo {
	internal class Program {
		static void Main() {
			/* Arreglo de arreglos (NO confundirlos con arreglos bidimensionales).
			 * Se entiende mejor haciendo analogía con un conjunto y subconjuntos */
			
			//Defino un arreglo (el conjunto)
			int[][] arreglo = new int[5][];

			//Defino los subconjuntos
			arreglo[0] = new int[7]; //Tendrá 7 elementos
			arreglo[1] = new int[3]; //Tendrá 3 elementos
			arreglo[2] = new int[9]; //Tendrá 9 elementos
			arreglo[3] = new int[4]; //Tendrá 4 elementos
			arreglo[4] = new int[8]; //Tendrá 8 elementos

			//Llenando un arreglo de arreglos
			Random azar = new Random();
			for (int conjunto = 0; conjunto < arreglo.Length; conjunto++)
				for (int subconjunto = 0; subconjunto < arreglo[conjunto].Length; subconjunto++)
						arreglo[conjunto][subconjunto] = azar.Next(0, 9);

			//Imprime ese arreglo de arreglos
			for (int conjunto = 0; conjunto < arreglo.Length; conjunto++) {
				Console.WriteLine(" ");
				for (int subconjunto = 0; subconjunto < arreglo[conjunto].Length; subconjunto++)
					Console.Write(arreglo[conjunto][subconjunto].ToString() + " ; ");
			}
		}
	}
}
