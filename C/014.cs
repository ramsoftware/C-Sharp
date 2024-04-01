namespace Ejemplo {
	internal class Program {
		static void Main() {
			int DimensionX = 5;
			int DimensionY = 8;
			int DimensionZ = 3;

			//Declara un arreglo Tridimensional
			int[,,] Tablero = new int[DimensionX, DimensionY, DimensionZ];

			/* Llena ese arreglo tridimensional
			   Tablero.GetLength(0) Retorna la primera dimensión
			   Tablero.GetLength(1) Retorna la segunda dimensión
			   Tablero.GetLength(2) Retorna la tercera dimensión

			   Un arreglo tridimensional inicia en [0,0,0]
			*/
			Random azar = new Random();
			for (int posX = 0; posX < Tablero.GetLength(0); posX++)
				for (int posY = 0; posY < Tablero.GetLength(1); posY++)
					for (int posZ = 0; posZ < Tablero.GetLength(2); posZ++)
						Tablero[posX, posY, posZ] = azar.Next(0, 9);

			//Imprime ese arreglo tridimensional
			for (int posX = 0; posX < Tablero.GetLength(0); posX++) {
				Console.WriteLine(" ");
				for (int posY = 0; posY < Tablero.GetLength(1); posY++) {
					Console.Write("[");
					for (int posZ = 0; posZ < Tablero.GetLength(2); posZ++)
						Console.Write(Tablero[posX, posY, posZ].ToString() + ";");
					Console.Write("]  ");
				}
			}
		}
	}
}
