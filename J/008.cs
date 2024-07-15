namespace Ejemplo {
	internal class Program {
		static void Main() {
			//Buscar el mayor valor de una ecuación
			//modificando números binarios
			Poblacion pobl = new();

			int NumInd = 1000;
			int Ciclos = 90000;
			int Bits = 20;
			double Xmin = -4;
			double Xmax = 1;
			pobl.Proceso(NumInd, Bits, Ciclos, Xmin, Xmax);
		}
	}

	//Cómo es el individuo
	internal class Individuo {
		public int Genotipo;

		//Al nacer, tendrá un valor dependiendo del número de bits
		public Individuo(Random Azar, int NumeroBits) {
			Genotipo = Azar.Next((int)Math.Pow(2, NumeroBits));
		}

		//Operador cruce.
		public Individuo(Random Azar, int GeneticoA, int GeneticoB) {
			//En que posicion corta el genotipo de cada padre
			int Posicion = Azar.Next(sizeof(int) * 8);

			//Extrae las partes de cada progenitor
			int Mascara = (1 << Posicion) - 1;
			int ParteA = GeneticoA >> Posicion;
			int ParteB = GeneticoB & Mascara;

			//Une las partes las inicial de A y la final de B
			Genotipo = (ParteA << Posicion) | ParteB;
		}
	}

	//La población
	internal class Poblacion {
		public List<Individuo> objInd = [];
		private Random Azar = new();

		public void Proceso(int NumInd, int Bits, int Ciclos,
							double Xmin, double Xmax) {
			//Genera la población
			objInd.Clear();
			for (int Contador = 1; Contador <= NumInd; Contador++)
				objInd.Add(new Individuo(Azar, Bits));

			//El factor de conversión
			double Divide = Math.Pow(2, Bits) - 1;
			double Factor = (Xmax - Xmin) / Divide;

			//El proceso evolutivo
			for (int Contador = 1; Contador <= Ciclos; Contador++) {
				//Seleccionar al azar dos individuos
				//de esa población: A y B
				int PosA = Azar.Next(objInd.Count);
				int PosB;
				do {
					PosB = Azar.Next(objInd.Count);
				} while (PosB == PosA);

				//Generan un hijo que nace del cruce
				Individuo Hijo = new(Azar, objInd[PosA].Genotipo,
										   objInd[PosB].Genotipo);

				double Xa = Xmin + objInd[PosA].Genotipo * Factor;
				double Pa = Ecuacion(Xa); //Evaluar adaptación de A

				double Xb = Xmin + objInd[PosB].Genotipo * Factor;
				double Pb = Ecuacion(Xb); //Evaluar adaptación de B

				double ValorXHijo = Xmin + Hijo.Genotipo * Factor;

				//Evaluar adaptación de Hijo
				double PuntajeHijo = Ecuacion(ValorXHijo);

				if (PuntajeHijo > Pa)
					objInd[PosA].Genotipo = Hijo.Genotipo;

				if (PuntajeHijo > Pb)
					objInd[PosB].Genotipo = Hijo.Genotipo;
			}

			//Buscar individuo con mejor adaptación de la población
			double MejorPuntaje = double.MinValue;
			int Mejor = 0;
			for (int indiv = 0; indiv < objInd.Count; indiv++) {
				double ValorX = Xmin + objInd[indiv].Genotipo * Factor;
				double Puntaje = Ecuacion(ValorX);
				if (Puntaje > MejorPuntaje) {
					MejorPuntaje = Puntaje;
					Mejor = indiv;
				}
			}

			//Imprime el mejor individuo
			double MejorValorX = Xmin + objInd[Mejor].Genotipo * Factor;

			Console.Write("Búsqueda del mayor valor Y");
			Console.WriteLine(". Operador cruce.");
			Console.WriteLine("Entre Xmin = " + Xmin + " y Xmax = " + Xmax);
			Console.WriteLine("Número de bits: " + Bits);
			Console.WriteLine("Valor X: " + MejorValorX);
			Console.WriteLine("Valor Y: " + Ecuacion(MejorValorX));
		}

		public double Ecuacion(double x) {
			double y = 0.1 * Math.Pow(x, 6) + 0.6 * Math.Pow(x, 5);
			y += (-0.9 * Math.Pow(x, 4)) - 6.2 * Math.Pow(x, 3);
			y += 2 * x * x + 5 * x - 1;
			return y;
		}
	}
}