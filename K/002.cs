namespace Ejemplo {
	internal class Program {
		static void Main() {
			//Único generador de números aleatorios
			Random Azar = new();

			//Tabla AND
			int[][] Entradas = new int[][] {
				new int[] {1, 1},
				new int[] {1, 0},
				new int[] {0, 1},
				new int[] {0, 0}
			};
			int[] Salidas = new int[] { 1, 0, 0, 0 };

			//Los pesos
			double P0, P1, U;

			//Mantiene el proceso activo
			bool Proceso;

			//Número de iteraciones
			int Iteracion = 0;

			//Tasa de aprendizaje
			double TasaAprende = 0.3;

			//Pesos inician al azar
			P0 = Azar.NextDouble();
			P1 = Azar.NextDouble();
			U = Azar.NextDouble();

			//Hasta que aprenda la tabla AND
			do {
				Iteracion++;

				//Prueba la tabla AND
				Proceso = false;
				for (int Contador = 0; Contador < Entradas.GetLength(0); Contador++) {

					//Calcula el valor de entrada a la función
					double Operacion = Entradas[Contador][0] * P0 + Entradas[Contador][1] * P1 + U;

					//Función de activación
					int SalidaEntera = Operacion > 0.5 ? 1 : 0;

					//El error
					int Error = Salidas[Contador] - SalidaEntera;

					//Si hay error, cambia los pesos con la Tasa de Aprendizaje
					if (Error != 0) {
						P0 += TasaAprende * Error * Entradas[Contador][0];
						P1 += TasaAprende * Error * Entradas[Contador][1];
						U += TasaAprende * Error * 1;
						Proceso = true;
					}
				}
			} while (Proceso);

			//Muestra aprendizaje perceptrón simple
			for (int Contador = 0; Contador < Entradas.GetLength(0); Contador++) {
				double Operacion = Entradas[Contador][0] * P0 + Entradas[Contador][1] * P1 + U;

				//Función de activación
				int SalidaEntera = Operacion > 0.5 ? 1 : 0;

				Console.WriteLine("Entradas: " + Entradas[Contador][0] + " y " + Entradas[Contador][1] + " = " +
				Salidas[Contador] + " perceptron: " + SalidaEntera);
			}

			Console.WriteLine("Pesos encontrados P0= " + P0 + " P1= " + P1 + " U= " + U);
			Console.WriteLine("Total Iteraciones: " + Iteracion);
		}
	}
}
