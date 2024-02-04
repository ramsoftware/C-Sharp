namespace Ejemplo {
	class Program {
		static void Main() {
			//Arreglo unidimensional. Funciones genéricas
			int[] numeros = new int[50];

			//Llena con valores al azar
			int minimo = 1, maximo = 30;
			LlenaArreglo(numeros, minimo, maximo);
			ImprimeArreglo(numeros);

			//Busca un valor determinado y retorna su posición
			int valorBusca = 17;
			int encuentra = PosArregloDato(numeros, valorBusca);
			if (encuentra == -1)
				Console.WriteLine("Valor no encontrado");
			else
				Console.WriteLine("Valor " + valorBusca.ToString() +  " encontrado en posición: " + encuentra.ToString());
		}

		//Llena el arreglo con valores al azar entre min y max (ambos incluídos)
		static void LlenaArreglo(int[] arreglo, int min, int max) {
			Random azar = new Random();
			for (int posicion = 0; posicion < arreglo.Length; posicion++) {
				arreglo[posicion] = azar.Next(min, max+1);
			}
		}

		//Imprime el arreglo en consola
		static void ImprimeArreglo(int [] arreglo) {
			for (int posicion = 0; posicion < arreglo.Length; posicion++) {
				Console.Write(arreglo[posicion].ToString() + " ; ");
			}
			Console.WriteLine(" ");
		}

		//Retorna la posición del dato en el arreglo o retorna -1 si no lo encuentra
		static int PosArregloDato(int[] arreglo, int valor) {
			for (int posicion = 0; posicion < arreglo.Length; posicion++) {
				if (arreglo[posicion] == valor)
					return posicion;
			}
			return -1;
		}
	}
}
