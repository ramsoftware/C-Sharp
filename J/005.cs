namespace Ejemplo {
	internal class Program {

		static void Main() {
			/* Único generador de números aleatorios para todo el programa */
			Random Azar = new();

			/* Iniciar el proceso */
			double Xini = -4;
			double Xfin = 1;
			int TotalIndividuos = 100;
			int NumeroCiclos = 10000;
			MaximoValor(Azar, Xini, Xfin, TotalIndividuos, NumeroCiclos);
		}

		/* Método que realiza el proceso de encontrar el valor máximo */
		static void MaximoValor(Random Azar, double Xini, double Xfin, int TotalIndividuos, int NumeroCiclos) {

			/* Genera población inicial con individuos con valores aleatorios */
			double[] Individuos = new double[TotalIndividuos];

			for (int indiv = 0; indiv < TotalIndividuos; indiv++) {
				Individuos[indiv] = Azar.NextDouble();
			}

			int Contador = 0;
			double MejorPuntaje = double.MinValue;
			int MejorIndividuo = -1;
			double MejorValorX, MayorValorY;

			for (int ciclos = 1; ciclos <= NumeroCiclos; ciclos++) {

				/* Seleccionar dos inviduos aleatoriamente */
				int Indice1 = Azar.Next(TotalIndividuos);
				int Indice2;
				do {
					Indice2 = Azar.Next(TotalIndividuos);
				} while (Indice2 == Indice1);

				/* Evalúa cada individuo */
				double Puntaje1 = Ecuacion(Individuos[Indice1] * (Xfin - Xini) + Xini);
				double Puntaje2 = Ecuacion(Individuos[Indice2] * (Xfin - Xini) + Xini);

				if (Puntaje1 > MejorPuntaje) { MejorPuntaje = Puntaje1; MejorIndividuo = Indice1; }
				if (Puntaje2 > MejorPuntaje) { MejorPuntaje = Puntaje2; MejorIndividuo = Indice2; }

				/* Genera un hijo */
				double Hijo = (Individuos[Indice1] + Individuos[Indice2]) / 2.0;

				/* Muta el hijo */
				Hijo += (Azar.NextDouble() - 0.5) * 0.1;

				/* Evalúa el hijo */
				double PuntajeHijo = Ecuacion(Hijo * (Xfin - Xini) + Xini);

				/* Si el hijo es mejor que algún progenitor, entonces se sobre-escribe el progenitor */
				if (PuntajeHijo > Puntaje1)
					Individuos[Indice1] = Hijo;

				if (PuntajeHijo > Puntaje2)
					Individuos[Indice2] = Hijo;

				/* Incrementar el contador e informar cada 1000 intentos */
				Contador++;
				if (Contador % 1000 == 0) {
					MejorValorX = Individuos[MejorIndividuo] * (Xfin - Xini) + Xini;
					MayorValorY = Ecuacion(MejorValorX);
					Console.WriteLine($"Intento: {Contador:N0} Mejor individuo: [{MejorValorX}] con Valor: [{MayorValorY}]");
				}
			}

			MejorValorX = Individuos[MejorIndividuo] * (Xfin - Xini) + Xini;
			MayorValorY = Ecuacion(MejorValorX);
			Console.WriteLine($"Intento: {Contador:N0} Mejor individuo: [{MejorValorX}] con Valor: [{MayorValorY}]");
		}

		static double Ecuacion(double x) {
			return 0.1 * Math.Pow(x, 6) + 0.6 * Math.Pow(x, 5) + (-0.9 * Math.Pow(x, 4)) - 6.2 * Math.Pow(x, 3) + 2 * x * x + 5 * x - 1;
		}
	}
}