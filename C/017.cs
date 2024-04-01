using System.Diagnostics;

namespace Ejemplo {
	internal class Program {
		static void Main() {
			Random Azar = new Random();

			//Limite de todos los arreglos
			int Limite = 10;

			//Arreglos
			int[,] bidimensional = new int[Limite, Limite];
			int[,,] tridimensional = new int[Limite, Limite, Limite];
			int[,,,] cuatrodimensiones = new int[Limite, Limite, Limite, Limite];
			int[,,,,] cincodimensiones = new int[Limite, Limite, Limite, Limite, Limite];

			//Medidor de tiempos
			Stopwatch cronometro = new Stopwatch();

			//Evitar optimización de ciclos, haciendo que acumule los valores
			long Acumula = 0;

			//Llenando un arreglo bidimensional
			int valor = 0;
			cronometro.Reset();
			cronometro.Start();
			for (int a = 0; a < bidimensional.GetLength(0); a++)
				for (int b = 0; b < bidimensional.GetLength(1); b++)
					bidimensional[a, b] = valor++;
			long TBidim = cronometro.ElapsedTicks;

			int posA = Azar.Next(bidimensional.GetLength(0));
			int posB = Azar.Next(bidimensional.GetLength(1));
			Acumula += bidimensional[posA, posB];

			//Llenando un arreglo tridimensional
			valor = 0;
			cronometro.Reset();
			cronometro.Start();
			for (int a = 0; a < tridimensional.GetLength(0); a++)
				for (int b = 0; b < tridimensional.GetLength(1); b++)
					for (int c = 0; c < tridimensional.GetLength(2); c++)
						tridimensional[a, b, c] = valor++;
			long TTridim = cronometro.ElapsedTicks;

			posA = Azar.Next(tridimensional.GetLength(0));
			posB = Azar.Next(tridimensional.GetLength(1));
			int posC = Azar.Next(tridimensional.GetLength(2));
			Acumula += tridimensional[posA, posB, posC];

			//Llenando un arreglo de cuatro dimensiones
			valor = 0;
			cronometro.Reset();
			cronometro.Start();
			for (int a = 0; a < cuatrodimensiones.GetLength(0); a++)
				for (int b = 0; b < cuatrodimensiones.GetLength(1); b++)
					for (int c = 0; c < cuatrodimensiones.GetLength(2); c++)
						for (int d = 0; d < cuatrodimensiones.GetLength(3); d++)
							cuatrodimensiones[a, b, c, d] = valor++;
			long TCuatrodim = cronometro.ElapsedTicks;

			posA = Azar.Next(cuatrodimensiones.GetLength(0));
			posB = Azar.Next(cuatrodimensiones.GetLength(1));
			posC = Azar.Next(cuatrodimensiones.GetLength(2));
			int posD = Azar.Next(cuatrodimensiones.GetLength(3));
			Acumula += cuatrodimensiones[posA, posB, posC, posD];

			//Llenando un arreglo de cinco dimensiones
			valor = 0;
			cronometro.Reset();
			cronometro.Start();
			for (int a = 0; a < cincodimensiones.GetLength(0); a++)
				for (int b = 0; b < cincodimensiones.GetLength(1); b++)
					for (int c = 0; c < cincodimensiones.GetLength(2); c++)
						for (int d = 0; d < cincodimensiones.GetLength(3); d++)
							for (int e = 0; e < cincodimensiones.GetLength(4); e++)
								cincodimensiones[a, b, c, d, e] = valor++;
			long TCincodim = cronometro.ElapsedTicks;

			posA = Azar.Next(cincodimensiones.GetLength(0));
			posB = Azar.Next(cincodimensiones.GetLength(1));
			posC = Azar.Next(cincodimensiones.GetLength(2));
			posD = Azar.Next(cincodimensiones.GetLength(3));
			int posE = Azar.Next(cincodimensiones.GetLength(4));
			Acumula += cincodimensiones[posA, posB, posC, posD, posE];

			//Imprime los tiempos
			Console.WriteLine("Acumulado: " + Acumula.ToString());
			Console.WriteLine("Tiempo arreglo bidimensional: " + TBidim.ToString());
			Console.WriteLine("Tiempo arreglo tridimensional: " + TTridim.ToString());
			Console.WriteLine("Tiempo arreglo cuatro dimensiones: " + TCuatrodim.ToString());
			Console.WriteLine("Tiempo arreglo cinco dimensiones: " + TCincodim.ToString());
		}
	}
}

