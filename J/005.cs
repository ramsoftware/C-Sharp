namespace Ejemplo {
	internal class Program {
		static void Main() {
			//Buscar el mayor valor de una ecuación
			//modificando números de tipo double
			Evolutivo objEvolutivo = new();

			int TamanoPoblacion = 100;
			int Ciclos = 90000;
			double Xminimo = -4;
			double Xmaximo = 1;
			objEvolutivo.Proceso(TamanoPoblacion, Ciclos, Xminimo, Xmaximo);
		}
	}

	//Cómo es el individuo
	internal class Individuo {
		public double Genotipo;

		//Al nacer, tendrá un valor double entre 0 y 1
		public Individuo(Random Azar) {
			Genotipo = Azar.NextDouble();
		}

		//Cambia el valor validando que no se salga del rango 0 a 1
		public void Muta(Random Azar) {
			double Copia;
			do {
				Copia = Genotipo + Azar.NextDouble() - 0.5;
			} while (Copia < 0 || Copia > 1);
			Genotipo = Copia;
		}
	}

	//La población
	internal class Evolutivo {
		public List<Individuo> poblacion = [];
		private Random Azar = new();

		public void Proceso(int TamanoPoblacion, int Ciclos, double Xmin, double Xmax) {
			//Genera la población
			poblacion.Clear();
			for (int Contador = 1; Contador <= TamanoPoblacion; Contador++)
				poblacion.Add(new Individuo(Azar));

			//El proceso evolutivo
			for (int Contador = 1; Contador <= Ciclos; Contador++) {
				//Seleccionar al azar dos individuos de esa población: A y B
				int PosA = Azar.Next(poblacion.Count);
				int PosB;
				do {
					PosB = Azar.Next(poblacion.Count);
				} while (PosB == PosA);

				double ValorXa = poblacion[PosA].Genotipo * (Xmax - Xmin) + Xmin;
				double PuntajeA = Ecuacion(ValorXa); //Evaluar adaptación de A

				double ValorXb = poblacion[PosB].Genotipo * (Xmax - Xmin) + Xmin;
				double PuntajeB = Ecuacion(ValorXb); //Evaluar adaptación de B

				//Si adaptación de A es mejor que adaptación de B entonces
				if (PuntajeA > PuntajeB) {
					//Eliminar individuo B y duplicar individuo A
					poblacion[PosB].Genotipo = poblacion[PosA].Genotipo;
					//Modificar levemente al azar el nuevo duplicado
					poblacion[PosB].Muta(Azar);
				}
				else {
					//Eliminar individuo A y duplicar individuo B
					poblacion[PosA].Genotipo = poblacion[PosB].Genotipo;
					//Modificar levemente al azar el nuevo duplicado
					poblacion[PosA].Muta(Azar);
				}
			}

			//Buscar individuo con mejor adaptación de la población
			double MejorPuntaje = double.MinValue;
			int Mejor = 0;
			for (int Cont = 0; Cont < poblacion.Count; Cont++) {
				double ValorX = poblacion[Cont].Genotipo * (Xmax - Xmin) + Xmin;
				double Puntaje = Ecuacion(ValorX);
				if (Puntaje > MejorPuntaje) {
					MejorPuntaje = Puntaje;
					Mejor = Cont;
				}
			}

			//Imprime el mejor individuo
			double MejorValorX = poblacion[Mejor].Genotipo * (Xmax - Xmin) + Xmin;

			Console.WriteLine("Búsqueda del mayor valor Y de una ecuación");
			Console.WriteLine("Entre Xmin = " + Xmin + " y Xmax = " + Xmax);
			Console.WriteLine("Cuando el valor de X es: " + MejorValorX);
			Console.WriteLine("Y tiene máximo valor de: " + Ecuacion(MejorValorX));
		}

		public double Ecuacion(double x) {
			return 0.1 * Math.Pow(x, 6) + 0.6 * Math.Pow(x, 5) + (-0.9 * Math.Pow(x, 4)) - 6.2 * Math.Pow(x, 3) + 2 * x * x + 5 * x - 1;
		}
	}
}
