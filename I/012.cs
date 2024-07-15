namespace Ejemplo {
	internal class Program {
		static void Main() {
			/*  Encuentro de dos robots sin sensor visual
				en un tablero. 
				¿Cuál es la mejor estrategia?
				1. Un robot quieto y el otro moviéndose.
				2. Los dos robots moviéndose.
			*/

			Random Azar = new();

			//Tamaño del tablero
			int Filas = 50;
			int Columnas = 50;

			int Estra1 = 0;
			int Estra2 = 0;
			for (int Pruebas = 1; Pruebas <= 500; Pruebas++) {
				//Fila, Columna => Robot A
				int Fa = Azar.Next(Filas);
				int Ca = Azar.Next(Columnas);

				//Fila, Columna => Robot B
				int Fb, Cb;
				do {
					Fb = Azar.Next(Filas);
					Cb = Azar.Next(Columnas);
				} while (Fa == Fb || Ca == Cb);

				Estra1 += Estrategia1(Azar, Fa, Ca, Fb, Cb, Filas, Columnas);
				Estra2 += Estrategia2(Azar, Fa, Ca, Fb, Cb, Filas, Columnas);
			}

			Console.Write("Uno quieto y el otro moviéndose");
			Console.WriteLine(". Movimientos: " + Estra1);
			Console.Write("Ambos robots se están moviendo.");
			Console.WriteLine("  Movimientos: " + Estra2);
		}

		static int Estrategia1(Random Azar, int Fa, int Ca, int Fb, int Cb,
								int Filas, int Columnas) {

			//Estrategia 1. Un robot quieto (B) y el otro moviéndose (A)
			int TotalMovimientos = 0;
			do {
				TotalMovimientos++;
				int FilM, ColM;
				do {
					FilM = Azar.Next(-1, 2);
					ColM = Azar.Next(-1, 2);
				} while (Fa + FilM < 0 || Fa + FilM >= Filas ||
						 Ca + ColM < 0 || Ca + ColM >= Columnas ||
						 (FilM == 0 && ColM == 0));
				Fa += FilM;
				Ca += ColM;
			} while (Fa != Fb || Ca != Cb);
			return TotalMovimientos;
		}

		static int Estrategia2(Random Azar, int Fa, int Ca, int Fb, int Cb,
								int Filas, int Columnas) {
			//Estrategia 2. Los dos robots movéndose
			int TotalMovimientos = 0;
			do {
				TotalMovimientos++;

				//Mueve Robot A
				int A_FilM, A_ColM;
				do {
					A_FilM = Azar.Next(-1, 2);
					A_ColM = Azar.Next(-1, 2);
				} while (Fa + A_FilM < 0 || Fa + A_FilM >= Filas ||
						 Ca + A_ColM < 0 || Ca + A_ColM >= Columnas ||
						 (A_FilM == 0 && A_ColM == 0));
				Fa += A_FilM;
				Ca += A_ColM;

				//Mueve RobotB
				int B_FilM, B_ColM;
				do {
					B_FilM = Azar.Next(-1, 2);
					B_ColM = Azar.Next(-1, 2);
				} while (Fb + B_FilM < 0 || Fb + B_FilM >= Filas ||
						 Cb + B_ColM < 0 || Cb + B_ColM >= Columnas ||
						 (B_FilM == 0 && B_ColM == 0));
				Fb += B_FilM;
				Cb += B_ColM;

			} while (Fa != Fb || Ca != Cb);
			return TotalMovimientos;
		}
	}
}
