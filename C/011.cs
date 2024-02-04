namespace Ejemplo {
	internal class Program {
		static void Main() {
			//Ordenación
			int Limite = 30;
			int[] numA = new int[Limite];
			int[] numB = new int[Limite];

			int minimo = 10, maximo = 99;
			LlenaArreglo(numB, minimo, maximo);

			//Ordena por inserción
			Console.WriteLine("\nOrdena por inserción");
			Array.Copy(numB, 0, numA, 0, numB.Length); //Copia arreglo numB ===> numA
			ImprimeArreglo(numA);
			Insercion(numA);
			ImprimeArreglo(numA);

			//Ordena por selección
			Console.WriteLine("\nOrdena por selección");
			Array.Copy(numB, 0, numA, 0, numB.Length);
			ImprimeArreglo(numA);
			Seleccion(numA);
			ImprimeArreglo(numA);

			//Ordena por burbuja
			Console.WriteLine("\nOrdena por burbuja");
			Array.Copy(numB, 0, numA, 0, numB.Length);
			ImprimeArreglo(numA);
			Burbuja(numA);
			ImprimeArreglo(numA);

			//Ordena por shell
			Console.WriteLine("\nOrdena por shell");
			Array.Copy(numB, 0, numA, 0, numB.Length);
			ImprimeArreglo(numA);
			Shell(numA);
			ImprimeArreglo(numA);

			//Ordena por QuickSort
			Console.WriteLine("\nOrdena por quicksort");
			Array.Copy(numB, 0, numA, 0, numB.Length);
			ImprimeArreglo(numA);
			QuickSort(numA, 0, numA.Length - 1);
			ImprimeArreglo(numA);
		}

		//Llena el arreglo con valores al azar entre min y max (ambos incluídos)
		static void LlenaArreglo(int[] arreglo, int min, int max) {
			Random azar = new Random();
			for (int posicion = 0; posicion < arreglo.Length; posicion++) {
				arreglo[posicion] = azar.Next(min, max + 1);
			}
		}

		//Imprime el arreglo en consola
		static void ImprimeArreglo(int[] arreglo) {
			for (int posicion = 0; posicion < arreglo.Length; posicion++) {
				Console.Write(arreglo[posicion].ToString() + ";");
			}
			Console.WriteLine(" ");
		}

		//Ordenamiento por Insert
		static void Insercion(int[] arreglo) {
			int j;
			for (int i = 1; i < arreglo.Length; i++) {
				int tmp = arreglo[i];
				for (j = i - 1; j >= 0 && arreglo[j] > tmp; j--) {
					arreglo[j + 1] = arreglo[j];
				}
				arreglo[j + 1] = tmp;
			}
		}

		//Ordenamiento por Selección
		static void Seleccion(int[] arreglo) {
			for (int i = 0; i < arreglo.Length - 1; i++) {
				int min = i;
				for (int j = i + 1; j < arreglo.Length; j++) {
					if (arreglo[j] < arreglo[min]) {
						min = j;
					}
				}
				if (i != min) {
					int aux = arreglo[i];
					arreglo[i] = arreglo[min];
					arreglo[min] = aux;
				}
			}
		}

		//Ordenamiento por Burbuja
		static void Burbuja(int[] arreglo) {
			int n = arreglo.Length;
			int tmp;
			for (int i = 0; i < n - 1; i++) {
				for (int j = 0; j < n - 1; j++) {
					if (arreglo[j] > arreglo[j + 1]) {
						tmp = arreglo[j];
						arreglo[j] = arreglo[j + 1];
						arreglo[j + 1] = tmp;
					}
				}
			}
		}

		//Ordenamiento por Shell
		static void Shell(int[] arreglo) {
			int incremento = arreglo.Length;
			do {
				incremento /= 2;
				for (int k = 0; k < incremento; k++) {
					for (int i = incremento + k; i < arreglo.Length; i += incremento) {
						int j = i;
						while (j - incremento >= 0 && arreglo[j] < arreglo[j - incremento]) {
							int tmp = arreglo[j];
							arreglo[j] = arreglo[j - incremento];
							arreglo[j - incremento] = tmp;
							j -= incremento;
						}
					}
				}
			} while (incremento > 1);
		}

		//Ordenación por QuickSort
		static void QuickSort(int[] arreglo, int primero, int ultimo) {
			int i, j, central;
			int pivote;
			central = (primero + ultimo) / 2;
			pivote = arreglo[central];
			i = primero;
			j = ultimo;
			do {
				while (arreglo[i] < pivote) i++;
				while (arreglo[j] > pivote) j--;
				if (i <= j) {
					int tmp = arreglo[i];
					arreglo[i] = arreglo[j];
					arreglo[j] = tmp;
					i++;
					j--;
				}
			} while (i <= j);

			if (primero < j) {
				QuickSort(arreglo, primero, j);
			}
			if (i < ultimo) {
				QuickSort(arreglo, i, ultimo);
			}
		}
	}
}