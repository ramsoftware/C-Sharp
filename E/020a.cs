using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

namespace Ejemplo {
	class Program {
		static void Main() {
			/* Prueba de velocidad de los diferentes tipos de estructuras:
			 * arreglo estático, ArrayList, List
			 * Se usará el método de ordenación de burbuja en el que
			 * hace una gran cantidad de lectura y escritura sobre la estructura
			 * (por eso es el más lento pero muy bueno para hacer esta comparativa)
			 * */

			int minimoOrdena = 1000; //Mínimo número de elementos a ordenar
			int maximoOrdena = 9000; //Máximo número de elementos a ordenar
			int avanceOrdena = 500; //Avance de elementos a ordenar

			/* Número de pruebas por ordenamiento
			 * Luego el tiempo de ordenar N elementos es el promedio de esas pruebas
			 * así se evita que por algún motivo los tiempos tengan picos o valles */
			int numPruebas = 30;

			//Limite es el tamaño de datos que se vam a ordenar
			for (int Limite = minimoOrdena; Limite <= maximoOrdena; Limite += avanceOrdena)
				Ordenamiento(Limite, numPruebas);

			Console.WriteLine("\r\nFinal de la prueba");
		}

		static void Ordenamiento(int Limite, int numPruebas) {
			Random azar = new Random();
			
			//Las estructuras usadas: arreglo estático, ArrayList, List
			char[] numerosA = new char[Limite];
			char[] numerosB = new char[Limite];
			ArrayList arraylist = new ArrayList();
			List<char> list = new List<char>();

			//Medidor de tiempos
			Stopwatch temporizador = new Stopwatch();

			//Almacena los tiempos de cada método de ordenación
			long TParreglo = 0, TParraylist = 0, TPlist = 0;

			//Para evitar una optimización agresiva del compilador, se acumula el valor de diferentes
			//posiciones del arreglo ordenado.
			string valor = "";

			//Para disminuir picos o valles en el tiempo, se hacen varias pruebas 
			for (int prueba = 1; prueba <= numPruebas; prueba++) {

				//Llena con valores al azar el arreglo
				LlenaAzar(numerosA, azar);

				//Ordenación por Burbuja ArrayList
				arraylist.Clear();
				arraylist.AddRange(numerosA);
				temporizador.Reset();
				temporizador.Start();
				BurbujaArrayList(arraylist);
				TParraylist += temporizador.ElapsedMilliseconds;
				valor += Convert.ToChar(arraylist[0]);

				//Ordenación por Burbuja List
				list.Clear();
				list.AddRange(numerosA);
				temporizador.Reset();
				temporizador.Start();
				BurbujaList(list);
				TPlist += temporizador.ElapsedMilliseconds;
				valor += list[1];

				//Ordenación por Burbuja Arreglo estático unidimensional
				Array.Copy(numerosA, 0, numerosB, 0, numerosA.Length);
				temporizador.Reset();
				temporizador.Start();
				BurbujaArreglo(numerosB);
				TParreglo += temporizador.ElapsedMilliseconds;
				valor += numerosB[2];
			}

			double Tarreglo = (double)TParreglo / numPruebas;
			double Tarraylist = (double)TParraylist / numPruebas;
			double Tlist = (double)TPlist / numPruebas;

			Console.WriteLine("===========================================================");
			Console.WriteLine("\r\nValor de control (contra optimización agresiva): " + valor.ToString());
			Console.WriteLine("Número de elementos: " + Limite.ToString());
			Console.WriteLine("Burbuja arreglo estático unidimensional, tiempo promedio en milisegundos: " + Tarreglo.ToString());
			Console.WriteLine("Burbuja ArrayList, tiempo promedio en milisegundos: " + Tarraylist.ToString());
			Console.WriteLine("Burbuja List, tiempo promedio en milisegundos: " + Tlist.ToString());
		}

		//Llena el arreglo unidimensional con valores aleatorios
		static void LlenaAzar(char[] numerosA, Random azar) {
			string Permitido = "abcdefghijklmnñopqrstuvwxyzABCDEFGHIJKLMNÑOPQRSTUVWXYZ";
			for (int cont = 0; cont < numerosA.Length; cont++)
				numerosA[cont] = Permitido[azar.Next(Permitido.Length)];
		}

		//Ordenamiento por burbuja usando ArrayList
		static void BurbujaArrayList(ArrayList arraylist) {
			int tamano = arraylist.Count;
			object tmp;
			for (int i = 0; i < tamano - 1; i++) {
				for (int j = 0; j < tamano - 1; j++) {
					if (Convert.ToChar(arraylist[j]) > Convert.ToChar(arraylist[j + 1])) {
						tmp = arraylist[j];
						arraylist[j] = arraylist[j + 1];
						arraylist[j + 1] = tmp;
					}
				}
			}
		}

		//Ordenamiento por burbuja usando List
		static void BurbujaList(List<char> list) {
			int tamano = list.Count;
			char tmp;
			for (int i = 0; i < tamano - 1; i++) {
				for (int j = 0; j < tamano - 1; j++) {
					if (list[j] > list[j + 1]) {
						tmp = list[j];
						list[j] = list[j + 1];
						list[j + 1] = tmp;
					}
				}
			}
		}

		//Ordenamiento por burbuja usando arreglo unidimensional estático
		static void BurbujaArreglo(char[] arregloestatico) {
			int tamano = arregloestatico.Length;
			char tmp;
			for (int i = 0; i < tamano - 1; i++) {
				for (int j = 0; j < tamano - 1; j++) {
					if (arregloestatico[j] > arregloestatico[j + 1]) {
						tmp = arregloestatico[j];
						arregloestatico[j] = arregloestatico[j + 1];
						arregloestatico[j + 1] = tmp;
					}
				}
			}
		}
	}
}
