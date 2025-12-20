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
			int TotalBits = 10; //Número de bits para representar cada individuo
			MaximoValor(Azar, Xini, Xfin, TotalIndividuos, NumeroCiclos, TotalBits);
		}

		/* Método que realiza el proceso de encontrar el valor máximo */
		static void MaximoValor(Random Azar, double Xini, double Xfin, int TotalIndividuos, int NumeroCiclos, int TotalBits) {

			/* Genera población inicial con individuos con valores aleatorios */
			int[] Individuos = new int[TotalIndividuos];

			for (int indiv = 0; indiv < TotalIndividuos; indiv++) {
				Individuos[indiv] = Azar.Next((int)Math.Pow(2, TotalBits));
			}

			int Contador = 0;
			double MejorPuntaje = double.MinValue;
			int MejorIndividuo = -1;
			double MejorValorX, MayorValorY;

			//El factor de conversión
			double Divide = Math.Pow(2, TotalBits) - 1;
			double Factor = (Xfin - Xini) / Divide;

			for (int ciclos = 1; ciclos <= NumeroCiclos; ciclos++) {

				/* Seleccionar dos inviduos aleatoriamente */
				int Indice1 = Azar.Next(TotalIndividuos);
				int Indice2;
				do {
					Indice2 = Azar.Next(TotalIndividuos);
				} while (Indice2 == Indice1);

				/* Evalúa cada individuo */
				double Puntaje1 = Ecuacion(Xini + Individuos[Indice1] * Factor);
				double Puntaje2 = Ecuacion(Xini + Individuos[Indice2] * Factor);

				if (Puntaje1 > MejorPuntaje) { MejorPuntaje = Puntaje1; MejorIndividuo = Indice1; }
				if (Puntaje2 > MejorPuntaje) { MejorPuntaje = Puntaje2; MejorIndividuo = Indice2; }

				/* Genera un hijo con operador cruce */
				
				//En que posicion corta el genotipo de cada padre
				int Posicion = Azar.Next(sizeof(int) * 8); //Entero por los 8 bits de un byte

				//Extrae las partes de cada progenitor
				int Mascara = (1 << Posicion) - 1;
				int ParteA = Individuos[Indice1] >> Posicion;
				int ParteB = Individuos[Indice2] & Mascara;

				//Une las partes: inicial de A y la final de B
				int Hijo = (ParteA << Posicion) | ParteB;

				/* Muta el hijo */
				Mascara = 1 << Azar.Next(TotalBits);
				Hijo ^= Mascara;

				/* Evalúa el hijo */
				double PuntajeHijo = Ecuacion(Xini + Hijo * Factor);

				/* Si el hijo es mejor que algún progenitor, entonces se sobre-escribe el progenitor */
				if (PuntajeHijo > Puntaje1)
					Individuos[Indice1] = Hijo;

				if (PuntajeHijo > Puntaje2)
					Individuos[Indice2] = Hijo;

				/* Incrementar el contador e informar cada 1000 intentos */
				Contador++;
				if (Contador % 1000 == 0) {
					MejorValorX = Xini + Individuos[MejorIndividuo] * Factor;
					MayorValorY = Ecuacion(MejorValorX);
					Console.WriteLine($"Intento: {Contador:N0} Mejor individuo: [{MejorValorX}] con Valor: [{MayorValorY}]");
				}
			}

			MejorValorX = Xini + Individuos[MejorIndividuo] * Factor;
			MayorValorY = Ecuacion(MejorValorX);
			Console.WriteLine($"Intento: {Contador:N0} Mejor individuo: [{MejorValorX}] con Valor: [{MayorValorY}]");
		}

		static double Ecuacion(double x) {
			return 0.1 * Math.Pow(x, 6) + 0.6 * Math.Pow(x, 5) + (-0.9 * Math.Pow(x, 4)) - 6.2 * Math.Pow(x, 3) + 2 * x * x + 5 * x - 1;
		}
	}
}