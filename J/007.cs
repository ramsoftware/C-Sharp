namespace Ejemplo {
	internal class Program {
		static void Main() {
			//Buscar el mayor valor de una ecuación
			//modificando números binarios
			Poblacion pobl = new();

			int NumInd = 100;
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

		//Al nacer, tendrá un valor double entre 0 y 1
		public Individuo(Random Azar, int NumeroBits) {
			Genotipo = Azar.Next((int)Math.Pow(2, NumeroBits));
		}

		//Cambia el valor en algun bit
		public void Muta(Random Azar, int NumeroBits) {
			int Mascara = 1 << Azar.Next(NumeroBits);
			Genotipo ^= Mascara;
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

				double Xa = Xmin + objInd[PosA].Genotipo * Factor;
				double Pa = Ecuacion(Xa); //Evaluar adaptación de A

				double Xb = Xmin + objInd[PosB].Genotipo * Factor;
				double Pb = Ecuacion(Xb); //Evaluar adaptación de B

				//Si adaptación de A es mejor que adaptación de B entonces
				if (Pa > Pb) {
					//Eliminar individuo B y duplicar individuo A
					objInd[PosB].Genotipo = objInd[PosA].Genotipo;
					//Modificar levemente al azar el nuevo duplicado
					objInd[PosB].Muta(Azar, Bits);
				}
				else if (Pb > Pa) {
					//Eliminar individuo A y duplicar individuo B
					objInd[PosA].Genotipo = objInd[PosB].Genotipo;
					//Modificar levemente al azar el nuevo duplicado
					objInd[PosA].Muta(Azar, Bits);
				}
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

			Console.WriteLine("Búsqueda del mayor valor Y de una ecuación");
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

