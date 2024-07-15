namespace Ejemplo {
	internal class Program {
		static void Main() {
			//Único generador de números aleatorios
			Random Azar = new();

			//Tabla AND
			int[][] Entra = [
				[1, 1],
				[1, 0],
				[0, 1],
				[0, 0]
			];
			int[] Sale = [1, 0, 0, 0];

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
				for (int Con = 0; Con < Entra.GetLength(0); Con++) {

					//Calcula el valor de entrada a la función
					double Oper = Entra[Con][0] * P0 + Entra[Con][1] * P1 + U;

					//Función de activación
					int Salida = Oper > 0.5 ? 1 : 0;

					//Si la salida no coincide con lo esperado,
					//cambia los pesos
					if (Salida != Sale[Con]) {
						Proceso = true;
						break;
					}
				}
			} while (Proceso);

			//Muestra aprendizaje perceptrón simple
			for (int Cont = 0; Cont < Entra.GetLength(0); Cont++) {
				double Oper = Entra[Cont][0] * P0 + Entra[Cont][1] * P1 + U;

				//Función de activación
				int Salida = Oper > 0.5 ? 1 : 0;

				Console.Write("Entradas: " + Entra[Cont][0]);
				Console.Write(" y " + Entra[Cont][1] + " = ");
				Console.WriteLine(Sale[Cont] + " red: " + Salida);

			}

			Console.Write("Pesos encontrados P0= " + P0);
			Console.WriteLine(" P1= " + P1 + " U= " + U);
			Console.WriteLine("Total Iteraciones: " + Iteracion);
		}
	}
}