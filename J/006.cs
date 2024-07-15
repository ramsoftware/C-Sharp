namespace Ejemplo {
	internal class Program {
		static void Main() {
			//Buscar el mayor valor de una ecuación
			//modificando números de tipo double
			Poblacion pobl = new();

			int Poblacion = 100;
			int Ciclos = 90000;
			double Xminimo = -4;
			double Xmaximo = 1;
			pobl.Proceso(Poblacion, Ciclos, Xminimo, Xmaximo);
		}
	}

	//Cómo es el individuo
	internal class Individuo {
		public double Genotipo;

		//Al nacer, tendrá un valor double entre 0 y 1
		public Individuo(Random Azar) {
			Genotipo = Azar.NextDouble();
		}

		//Cambia el valor en algún decimal validando que
		//no se salga del rango 0 a 1
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
		public List<Individuo> objInd = [];
		private Random Azar = new();

		public void Proceso(int NumInd, int Ciclos, double Xmin, double Xmax) {
			//Genera la población
			objInd.Clear();
			for (int Contador = 1; Contador <= NumInd; Contador++)
				objInd.Add(new Individuo(Azar));

			//El proceso evolutivo
			for (int Contador = 1; Contador <= Ciclos; Contador++) {
				//Seleccionar al azar dos individuos de esa población: A y B
				int PosA = Azar.Next(objInd.Count);
				int PosB;
				do {
					PosB = Azar.Next(objInd.Count);
				} while (PosB == PosA);

				double ValorXa = objInd[PosA].Genotipo * (Xmax - Xmin) + Xmin;
				double PuntajeA = Ecuacion(ValorXa); //Evaluar adaptación de A

				double ValorXb = objInd[PosB].Genotipo * (Xmax - Xmin) + Xmin;
				double PuntajeB = Ecuacion(ValorXb); //Evaluar adaptación de B

				//Si adaptación de A es mejor que adaptación de B entonces
				if (PuntajeA > PuntajeB) {
					//Eliminar individuo B y duplicar individuo A
					objInd[PosB].Genotipo = objInd[PosA].Genotipo;
					//Modificar levemente al azar el nuevo duplicado
					objInd[PosB].Muta(Azar);
				}
				else {
					//Eliminar individuo A y duplicar individuo B
					objInd[PosA].Genotipo = objInd[PosB].Genotipo;
					//Modificar levemente al azar el nuevo duplicado
					objInd[PosA].Muta(Azar);
				}
			}

			//Buscar individuo con mejor adaptación de la población
			double MejorPuntaje = double.MinValue;
			int Mejor = 0;
			for (int indiv = 0; indiv < objInd.Count; indiv++) {
				double ValorX = objInd[indiv].Genotipo * (Xmax - Xmin) + Xmin;
				double Puntaje = Ecuacion(ValorX);
				if (Puntaje > MejorPuntaje) {
					MejorPuntaje = Puntaje;
					Mejor = indiv;
				}
			}

			//Imprime el mejor individuo
			double MejorValorX = objInd[Mejor].Genotipo * (Xmax - Xmin) + Xmin;

			Console.WriteLine("Búsqueda del mayor valor Y de una ecuación");
			Console.WriteLine("Entre Xmin = " + Xmin + " y Xmax = " + Xmax);
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