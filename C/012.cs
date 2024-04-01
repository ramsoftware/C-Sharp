using System.Diagnostics;

namespace Ejemplo {
	internal class Program {
		static void Main() {
			int Limite = 15000;
			int[] numerosA = new int[Limite];
			int[] numerosB = new int[Limite];

			//Medidor de tiempos
			Stopwatch cronometro = new Stopwatch();

			long TPShell = 0, TPIns = 0, TPSel = 0, TPBur = 0, TPQuick = 0;

			/* Si el compilador detecta que no se hace nada con el arreglo ordenado,
			 * entonces quita la instrucción de llamado al método de ordenación, luego la
			 * métrica de tiempo de cada método de ordenación sería errónea. Para evitar
			 * esa optimización, se acumula el primer valor del arreglo ordenado en cada llamado
			 * en la siguiente variable y luego se muestra su valor en consola */
			long ValorMuestra = 0;

			//Para disminuir oscilaciones en el tiempo, se hacen
			//N pruebas con cada grupo de pruebas
			int TotalPruebas = 5;
			for (int prueba = 1; prueba <= TotalPruebas; prueba++) {
				LlenaArreglo(numerosA, 10, 90);

				//Ordenación por método Shell
				Array.Copy(numerosA, 0, numerosB, 0, numerosA.Length);
				cronometro.Reset();
				cronometro.Start();
				Shell(numerosB);
				TPShell += cronometro.ElapsedMilliseconds;
				ValorMuestra += numerosB[0];

				//Ordenación por método Inserción
				Array.Copy(numerosA, 0, numerosB, 0, numerosA.Length);
				cronometro.Reset();
				cronometro.Start();
				Insercion(numerosB);
				TPIns += cronometro.ElapsedMilliseconds;
				ValorMuestra += numerosB[0];

				//Ordenación por método Selección
				Array.Copy(numerosA, 0, numerosB, 0, numerosA.Length);
				cronometro.Reset();
				cronometro.Start();
				Seleccion(numerosB);
				TPSel += cronometro.ElapsedMilliseconds;
				ValorMuestra += numerosB[0];

				//Ordenación por método Burbuja
				Array.Copy(numerosA, 0, numerosB, 0, numerosA.Length);
				cronometro.Reset();
				cronometro.Start();
				Burbuja(numerosB);
				TPBur += cronometro.ElapsedMilliseconds;
				ValorMuestra += numerosB[0];

				//Ordenación por método QuickSort
				Array.Copy(numerosA, 0, numerosB, 0, numerosA.Length);
				cronometro.Reset();
				cronometro.Start();
				QuickSort(numerosB, 0, numerosB.Length - 1);
				TPQuick += cronometro.ElapsedMilliseconds;
				ValorMuestra += numerosB[0];
			}

			double TS = (double)TPShell / TotalPruebas;
			double TI = (double)TPIns / TotalPruebas;
			double TL = (double)TPSel / TotalPruebas;
			double TB = (double)TPBur / TotalPruebas;
			double TQ = (double)TPQuick / TotalPruebas;

			Console.WriteLine("===========================================================");
			Console.WriteLine("Número de elementos: " + Limite.ToString());
			Console.WriteLine("Valor muestra: " + ValorMuestra.ToString());
			Console.WriteLine("ShellSort, tiempo promedio en milisegundos: " + TS.ToString());
			Console.WriteLine("InsertSort, tiempo promedio en milisegundos: " + TI.ToString());
			Console.WriteLine("Seleccion, tiempo promedio en milisegundos: " + TL.ToString());
			Console.WriteLine("Burbuja, tiempo promedio en milisegundos: " + TB.ToString());
			Console.WriteLine("QuickSort, tiempo promedio en milisegundos: " + TQ.ToString());
		}

		//Llena el arreglo con valores al azar entre min y max (ambos incluídos)
		static void LlenaArreglo(int[] arreglo, int min, int max) {
			Random azar = new Random();
			for (int posicion = 0; posicion < arreglo.Length; posicion++) {
				arreglo[posicion] = azar.Next(min, max + 1);
			}
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