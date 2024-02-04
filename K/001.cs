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

			//Hasta que aprenda la tabla AND
			do {
				Iteracion++;

				//Pesos al azar
				P0 = Azar.NextDouble();
				P1 = Azar.NextDouble();
				U = Azar.NextDouble();

				//Prueba la tabla AND
				Proceso = false;
				for (int Contador = 0; Contador < Entradas.GetLength(0); Contador++) {

					//Calcula el valor de entrada a la función
					double Operacion = Entradas[Contador][0] * P0 + Entradas[Contador][1] * P1 + U;

					//Función de activación
					int SalidaEntera = Operacion > 0.5 ? 1 : 0;

					//Si la salida no coincide con lo esperado, cambia los pesos
					if (SalidaEntera != Salidas[Contador]) {
						Proceso = true;
						break;
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