using System.Diagnostics;

namespace Ejemplo {
	internal class Program {
		static void Main() {
			/* ¿Qué es más rápido? ¿Un arreglo bidimensional o un arreglo de arreglos */

			//Limite ancho*alto de ambos arreglos
			int Limite = 80;

			//Arreglo Bidimensional
			int[,] bidimensional = new int[Limite, Limite];

			//Arreglo de arreglos
			int[][] arreglo = new int[Limite][];
			for (int subconjunto = 0; subconjunto < arreglo.Length; subconjunto++)
				arreglo[subconjunto] = new int[Limite];

			//Medidor de tiempos
			Stopwatch cronometro = new Stopwatch();

			//Llenando un arreglo bidimensional
			int valor = 0;
			cronometro.Reset();
			cronometro.Start();
			for (int fila = 0; fila < bidimensional.GetLength(0); fila++)
				for (int columna = 0; columna < bidimensional.GetLength(1); columna++)
					bidimensional[fila, columna] = valor++;
			long TBidim = cronometro.ElapsedTicks;

			//Llenando un arreglo de arreglos
			valor = 0;
			cronometro.Reset();
			cronometro.Start();
			for (int conjunto = 0; conjunto < arreglo.Length; conjunto++)
				for (int subconjunto = 0; subconjunto < arreglo[conjunto].Length; subconjunto++)
						arreglo[conjunto][subconjunto] = valor++;
			long TArreglo = cronometro.ElapsedTicks;

			//Imprime los tiempos
			Console.WriteLine("Tiempo arreglo bidimensional: " + TBidim.ToString());
			Console.WriteLine("Tiempo arreglo de arreglos: " + TArreglo.ToString());
		}
	}
}
