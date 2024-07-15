namespace Ejemplo {
	internal class Program {
		static void Main() {
			int TotalFilas = 5;
			int TotalColumnas = 10;

			//Declara un arreglo bidimensional
			int[,] Tablero = new int[TotalFilas, TotalColumnas];

			/* Llena ese arreglo bidimensional
				Retorna el número de filas (la primera dimensión)
					Tablero.GetLength(0)
				
				Retorna el número de columnas (la segunda dimensión)
					Tablero.GetLength(1)
				
				Un arreglo bidimensional inicia en [0,0] y 
				termina en [TotalFilas-1, TotalColumnas-1]
			*/
			Random azar = new();
			for (int fila = 0; fila < Tablero.GetLength(0); fila++)
				for (int col = 0; col < Tablero.GetLength(1); col++)
					Tablero[fila, col] = azar.Next(0, 9);

			//Imprime ese arreglo bidimensional
			for (int fila = 0; fila < Tablero.GetLength(0); fila++) {
				Console.WriteLine(" ");
				for (int col = 0; col < Tablero.GetLength(1); col++)
					Console.Write(Tablero[fila, col] + " ; ");
			}
		}
	}
}
