namespace Ejemplo {
	internal class Program {
		static void Main() {
			//Buscar el mayor valor de una ecuación modificando números de tipo double
			Poblacion pobl = new Poblacion();

			int TotalPoblacion = 100;
			int TotalCiclos = 90000;
			double ValorXminimo = -4;
			double ValorXmaximo = 1;
			pobl.Proceso(TotalPoblacion, TotalCiclos, ValorXminimo, ValorXmaximo);
		}
	}

	//Cómo es el individuo
	internal class Individuo {
		public double Genotipo;

		//Al nacer, tendrá un valor double entre 0 y 1
		public Individuo(Random Azar) {
			Genotipo = Azar.NextDouble();
		}

		//Cambia el valor en algún decimal validando que no se salga del rango 0 a 1
		public void Muta(Random Azar) {
			double Copia;
			do {
				Copia = Genotipo;
				double Divide = Math.Pow(10, Azar.Next(2, 7));
				if (Azar.NextDouble() < 0.5)
					Copia -= 1 / Divide;
				else
					Copia += 1 / Divide;
			} while (Copia < 0 || Copia > 1);
			Genotipo = Copia;
		}
	}

	//La población
	internal class Poblacion {
		public List<Individuo> Individuos = new List<Individuo>();
		private Random Azar = new Random();

		public void Proceso(int TotalIndividuos, int TotalCiclos, double Xmin, double Xmax) {
			//Genera la población
			Individuos.Clear();
			for (int Contador = 1; Contador <= TotalIndividuos; Contador++)
				Individuos.Add(new Individuo(Azar));

			//El proceso evolutivo
			for (int Contador = 1; Contador <= TotalCiclos; Contador++) {
				//Seleccionar al azar dos individuos de esa población: A y B
				int PosA = Azar.Next(Individuos.Count);
				int PosB;
				do {
					PosB = Azar.Next(Individuos.Count);
				} while (PosB == PosA);

				double ValorXa = Individuos[PosA].Genotipo * (Xmax - Xmin) + Xmin;
				double PuntajeA = Ecuacion(ValorXa); //Evaluar adaptación de A

				double ValorXb = Individuos[PosB].Genotipo * (Xmax - Xmin) + Xmin;
				double PuntajeB = Ecuacion(ValorXb); //Evaluar adaptación de B

				//Si adaptación de A es mejor que adaptación de B entonces
				if (PuntajeA > PuntajeB) {
					//Eliminar individuo B y duplicar individuo A
					Individuos[PosB].Genotipo = Individuos[PosA].Genotipo;
					//Modificar levemente al azar el nuevo duplicado
					Individuos[PosB].Muta(Azar);
				}
				else {
					//Eliminar individuo A y duplicar individuo B
					Individuos[PosA].Genotipo = Individuos[PosB].Genotipo;
					//Modificar levemente al azar el nuevo duplicado
					Individuos[PosA].Muta(Azar);
				}
			}

			//Buscar individuo con mejor adaptación de la población
			double MejorPuntaje = double.MinValue;
			int MejorIndivid = 0;
			for (int indiv = 0; indiv < Individuos.Count; indiv++) {
				double ValorX = Individuos[indiv].Genotipo * (Xmax - Xmin) + Xmin;
				double Puntaje = Ecuacion(ValorX);
				if (Puntaje > MejorPuntaje) {
					MejorPuntaje = Puntaje;
					MejorIndivid = indiv;
				}
			}

			//Imprime el mejor individuo
			double MejorValorX = Individuos[MejorIndivid].Genotipo * (Xmax - Xmin) + Xmin;
			
			Console.WriteLine("Búsqueda del mayor valor Y de una ecuación");
			Console.WriteLine("Y = 0.1 * Math.Pow(x, 6) + 0.6 * Math.Pow(x, 5) - 0.9 * Math.Pow(x, 4) - 6.2 * Math.Pow(x, 3) + 2 * x * x + 5 * x - 1");
			Console.WriteLine("Entre Xmin = " + Xmin + " y Xmax = " + Xmax);
			Console.WriteLine("Valor X: " + MejorValorX);
			Console.WriteLine("Valor Y: " + Ecuacion(MejorValorX));
		}

		public double Ecuacion(double x) {
			return 0.1 * Math.Pow(x, 6) + 0.6 * Math.Pow(x, 5) - 0.9 * Math.Pow(x, 4) - 6.2 * Math.Pow(x, 3) + 2 * x * x + 5 * x - 1;
		}
	}
}