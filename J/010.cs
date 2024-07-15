namespace Ejemplo {
	internal class Program {
		static void Main() {
			//Buscar el mayor valor de una ecuación
			//modificando números de tipo double
			Poblacion pobl = new();

			int NumIndiv = 100;
			int Ciclos = 90000;
			double ValorMinimo = -10;
			double ValorMaximo = 10;
			pobl.Proceso(NumIndiv, Ciclos, ValorMinimo, ValorMaximo);
		}
	}

	//Cómo es el individuo
	internal class Individuo {
		public double valA, valB, valC, valD, valE;

		//Al nacer, tendrá un valor double entre 0 y 1
		public Individuo(Random Azar, double ValMin, double ValMax) {
			valA = Azar.NextDouble() * (ValMax - ValMin) + ValMin;
			valB = Azar.NextDouble() * (ValMax - ValMin) + ValMin;
			valC = Azar.NextDouble() * (ValMax - ValMin) + ValMin;
			valD = Azar.NextDouble() * (ValMax - ValMin) + ValMin;
			valE = Azar.NextDouble() * (ValMax - ValMin) + ValMin;
		}

		//Cambia el valor de una variable
		public void Muta(Random Azar, double ValMin, double ValMax) {
			switch (Azar.Next(5)) {
				case 0:
					valA = Azar.NextDouble() * (ValMax - ValMin) + ValMin;
					break;

				case 1:
					valB = Azar.NextDouble() * (ValMax - ValMin) + ValMin;
					break;

				case 2:
					valC = Azar.NextDouble() * (ValMax - ValMin) + ValMin;
					break;

				case 3: 
					valD = Azar.NextDouble() * (ValMax - ValMin) + ValMin; 
					break;

				case 4:
					valE = Azar.NextDouble() * (ValMax - ValMin) + ValMin;
					break;
			}
		}
	}

	//La población
	internal class Poblacion {
		public List<Individuo> objInd = [];
		private Random Azar = new();

		public void Proceso(int NumIndiv, int Ciclos, 
							double Minimo, double Maximo) {
			//Genera la población
			objInd.Clear();
			for (int Contador = 1; Contador <= NumIndiv; Contador++)
				objInd.Add(new Individuo(Azar, Minimo, Maximo));

			//El proceso evolutivo
			for (int Contador = 1; Contador <= Ciclos; Contador++) {
				//Seleccionar al azar dos individuos de esa población: A y B
				int PosA = Azar.Next(objInd.Count);
				int PosB;
				do {
					PosB = Azar.Next(objInd.Count);
				} while (PosB == PosA);

				//Evaluar adaptación de A
				double PuntajeA = Ecuacion(objInd[PosA].valA, objInd[PosA].valB,
											objInd[PosA].valC, objInd[PosA].valD,
											objInd[PosA].valE);

				//Evaluar adaptación de B
				double PuntajeB = Ecuacion(objInd[PosB].valA, objInd[PosB].valB,
											objInd[PosB].valC, objInd[PosB].valD,
											objInd[PosB].valE);

				//Si adaptación de A es mejor que adaptación de B entonces
				if (PuntajeA > PuntajeB) {
					//Eliminar individuo B y duplicar individuo A
					objInd[PosB].valA = objInd[PosA].valA;
					objInd[PosB].valB = objInd[PosA].valB;
					objInd[PosB].valC = objInd[PosA].valC;
					objInd[PosB].valD = objInd[PosA].valD;
					objInd[PosB].valE = objInd[PosA].valE;

					//Modificar levemente al azar el nuevo duplicado
					objInd[PosB].Muta(Azar, Minimo, Maximo);
				}
				else {
					//Eliminar individuo A y duplicar individuo B
					objInd[PosA].valA = objInd[PosB].valA;
					objInd[PosA].valB = objInd[PosB].valB;
					objInd[PosA].valC = objInd[PosB].valC;
					objInd[PosA].valD = objInd[PosB].valD;
					objInd[PosA].valE = objInd[PosB].valE;

					//Modificar levemente al azar el nuevo duplicado
					objInd[PosA].Muta(Azar, Minimo, Maximo);
				}
			}

			//Buscar individuo con mejor adaptación de la población
			double MejorPuntaje = double.MinValue;
			int Mejor = 0;
			for (int indiv = 0; indiv < objInd.Count; indiv++) {
				double Puntaje = Ecuacion(objInd[indiv].valA, objInd[indiv].valB,
											objInd[indiv].valC, objInd[indiv].valD,
											objInd[indiv].valE); ;
				if (Puntaje > MejorPuntaje) {
					MejorPuntaje = Puntaje;
					Mejor = indiv;
				}
			}

			//Imprime el mejor individuo
			Console.Write("Búsqueda del mayor valor Y");
			Console.WriteLine(" de una ecuación de múltiples variables");
			Console.Write("Entre Mínimo = " + Minimo);
			Console.WriteLine(" y Máximo = " + Maximo);
			Console.WriteLine("Variable A: " + objInd[Mejor].valA);
			Console.WriteLine("Variable B: " + objInd[Mejor].valB);
			Console.WriteLine("Variable C: " + objInd[Mejor].valC);
			Console.WriteLine("Variable D: " + objInd[Mejor].valD);
			Console.WriteLine("Variable E: " + objInd[Mejor].valE);
			Console.WriteLine("Valor Y: " + MejorPuntaje);
		}

		public double Ecuacion(double a, double b, double c,
								double d, double e) {
			return 0.3 * Math.Sin(a * c - d) +
					1.7 * Math.Sin(e * b + c) +
					2.8 * Math.Cos(3.1 * b - 4.4 * a) -
					3.1 * Math.Sin(a * d - e * c) +
					0.7 * Math.Cos(a + b * c - d);
		}
	}
}