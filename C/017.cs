using System.Diagnostics;

namespace Ejemplo {
	internal class Program {
		static void Main() {
			Random Azar = new();

			//Limite de todos los arreglos
			int Lim = 60;

			//Arreglos
			int[,] dosDim = new int[Lim, Lim];
			int[,,] tresDim = new int[Lim, Lim, Lim];
			int[,,,] cuatroDim = new int[Lim, Lim, Lim, Lim];
			int[,,,,] cincoDim = new int[Lim, Lim, Lim, Lim, Lim];

			//Medidor de tiempos
			Stopwatch cronometro = new();

			//Evitar optimización de ciclos
			//haciendo que acumule los valores
			long Acumula = 0;

			//Llenando un arreglo bidimensional
			int valor = 0;
			cronometro.Reset();
			cronometro.Start();
			for (int a = 0; a < dosDim.GetLength(0); a++)
				for (int b = 0; b < dosDim.GetLength(1); b++)
					dosDim[a, b] = valor++;
			long TBidim = cronometro.ElapsedMilliseconds;

			int posA = Azar.Next(dosDim.GetLength(0));
			int posB = Azar.Next(dosDim.GetLength(1));
			Acumula += dosDim[posA, posB];

			//Llenando un arreglo tridimensional
			valor = 0;
			cronometro.Reset();
			cronometro.Start();
			for (int a = 0; a < tresDim.GetLength(0); a++)
				for (int b = 0; b < tresDim.GetLength(1); b++)
					for (int c = 0; c < tresDim.GetLength(2); c++)
						tresDim[a, b, c] = valor++;
			long TTridim = cronometro.ElapsedMilliseconds;

			posA = Azar.Next(tresDim.GetLength(0));
			posB = Azar.Next(tresDim.GetLength(1));
			int posC = Azar.Next(tresDim.GetLength(2));
			Acumula += tresDim[posA, posB, posC];

			//Llenando un arreglo de cuatro dimensiones
			valor = 0;
			cronometro.Reset();
			cronometro.Start();
			for (int a = 0; a < cuatroDim.GetLength(0); a++)
				for (int b = 0; b < cuatroDim.GetLength(1); b++)
					for (int c = 0; c < cuatroDim.GetLength(2); c++)
						for (int d = 0; d < cuatroDim.GetLength(3); d++)
							cuatroDim[a, b, c, d] = valor++;
			long TCuatrodim = cronometro.ElapsedMilliseconds;

			posA = Azar.Next(cuatroDim.GetLength(0));
			posB = Azar.Next(cuatroDim.GetLength(1));
			posC = Azar.Next(cuatroDim.GetLength(2));
			int posD = Azar.Next(cuatroDim.GetLength(3));
			Acumula += cuatroDim[posA, posB, posC, posD];

			//Llenando un arreglo de cinco dimensiones
			valor = 0;
			cronometro.Reset();
			cronometro.Start();
			for (int a = 0; a < cincoDim.GetLength(0); a++)
				for (int b = 0; b < cincoDim.GetLength(1); b++)
					for (int c = 0; c < cincoDim.GetLength(2); c++)
						for (int d = 0; d < cincoDim.GetLength(3); d++)
							for (int e = 0; e < cincoDim.GetLength(4); e++)
								cincoDim[a, b, c, d, e] = valor++;
			long TCincodim = cronometro.ElapsedMilliseconds;

			posA = Azar.Next(cincoDim.GetLength(0));
			posB = Azar.Next(cincoDim.GetLength(1));
			posC = Azar.Next(cincoDim.GetLength(2));
			posD = Azar.Next(cincoDim.GetLength(3));
			int posE = Azar.Next(cincoDim.GetLength(4));
			Acumula += cincoDim[posA, posB, posC, posD, posE];

			//Imprime los tiempos
			Console.WriteLine("Acumulado: " + Acumula);
			Console.WriteLine("Tiempo en milisegundos");
			Console.WriteLine("Arreglo bidimensional: " + TBidim);
			Console.WriteLine("Arreglo tridimensional: " + TTridim);
			Console.WriteLine("Arreglo cuatro dimensiones: " + TCuatrodim);
			Console.WriteLine("Arreglo cinco dimensiones: " + TCincodim);
		}
	}
}
