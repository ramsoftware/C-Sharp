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
			int pos = PosArregloDato(numeros, valorBusca);
			if (pos == -1)
				Console.WriteLine("Valor no encontrado");
			else {
				Console.Write("Valor " + valorBusca);
				Console.WriteLine(" en posición: " + pos);
			}
		}

		//Llena el arreglo con valores al azar 
		//entre min y max (ambos incluídos)
		static void LlenaArreglo(int[] arreglo, int min, int max) {
			Random azar = new Random();
			for (int pos = 0; pos < arreglo.Length; pos++) {
				arreglo[pos] = azar.Next(min, max+1);
			}
		}

		//Imprime el arreglo en consola
		static void ImprimeArreglo(int [] arreglo) {
			for (int pos = 0; pos < arreglo.Length; pos++) {
				Console.Write(arreglo[pos]	 + " ; ");
			}
			Console.WriteLine(" ");
		}

		//Retorna la posición del dato en el arreglo
		//o retorna -1 si no lo pos
		static int PosArregloDato(int[] arreglo, int valor) {
			for (int pos = 0; pos < arreglo.Length; pos++) {
				if (arreglo[pos] == valor)
					return pos;
			}
			return -1;
		}
	}
}