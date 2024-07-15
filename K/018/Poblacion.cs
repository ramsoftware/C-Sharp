using System.Diagnostics;

namespace Ejemplo {
	internal class Poblacion {
		//Para agilizar cálculos
		static private double Radian;

		//Los individuos
		double[][] Indiv;
		double[] Ajuste;

		//Inicializa la población con los individuos
		public Poblacion(Random Azar, int TamanoPoblacion) {
			Indiv = new double[TamanoPoblacion][];
			Ajuste = new double[TamanoPoblacion];

			Radian = Math.PI / 180;
			for (int cont = 0; cont < Indiv.Length; cont++) {
				Ajuste[cont] = double.MaxValue;
				Indiv[cont] = new double[30];
				for (int valor = 0; valor < 30; valor++) {
					Indiv[cont][valor] = Azar.NextDouble() * 2 - 1;
				}
			}
		}

		//Proceso evolutivo.
		public void Proceso(Random Azar, List<double> Entradas, 
							List<double> SalidaEsperada, 
							long TiempoParaOperar, 
							List<double> ResultadoEvolutivo) {

			//Medidor de tiempos
			Stopwatch cronometro = new();
			cronometro.Reset();
			cronometro.Start();

			//Tiempo que repetirá el proceso evolutivo
			int Turno = 0;
			while (cronometro.ElapsedMilliseconds <= TiempoParaOperar) {

				//Guarda los valores anteriores
				int CualMuta = Azar.Next(30);
				double ValorAnterior = Indiv[Turno][CualMuta];
				Indiv[Turno][CualMuta] += Azar.NextDouble() * 2 - 1;

				//Deduce el ajuste
				double NuevoAjuste = 0;
				for (int Xval = 0; Xval < Entradas.Count; Xval++) {

					//Entrada del ambiente
					double X = Entradas[Xval] * 1000;

					//Deduce el valor Y del individuo con
					//esa entrada X del ambiente
					double Y = 0;
					for (int cont=0; cont <= 27; cont += 3) {
						double valA = Indiv[Turno][cont];
						double valB = Indiv[Turno][cont + 1] * X;
						double valC = Indiv[Turno][cont + 2];
						Y += valA * Math.Sin((valB + valC) * Radian);
					}

					//Diferencia entre la salida calculada y la esperada
					NuevoAjuste += Math.Abs(Y - SalidaEsperada[Xval] * 1000);

					//Si el nuevo ajuste supera al
					//ajuste anterior, sale del ciclo
					if (NuevoAjuste > Ajuste[Turno]) break;
				}

				//Si el cambio mejora al individuo se conserva,
				//caso contrario se restaura el valor anterior
				if (NuevoAjuste > Ajuste[Turno])
					Indiv[Turno][CualMuta] = ValorAnterior;
				else
					Ajuste[Turno] = NuevoAjuste;

				if (++Turno >= Indiv.Length) Turno = 0;
			}

			//Imprime el mejor individuo
			int Mejor = -1;
			double MejorAjuste = double.MaxValue;
			for (int cont = 0; cont < Indiv.Length; cont++)
				if (Ajuste[cont] < MejorAjuste) {
					MejorAjuste = Ajuste[cont];
					Mejor = cont;
				}

			for (int Xval = 0; Xval < Entradas.Count; Xval++) {
				//Entrada del ambiente
				double X = Entradas[Xval] * 1000;

				//Deduce el valor Y del individuo con
				//esa entrada X del ambiente
				double Y = 0;
				for (int cont = 0; cont <= 27; cont += 3) {
					double valA = Indiv[Mejor][cont];
					double valB = Indiv[Mejor][cont + 1] * X;
					double valC = Indiv[Mejor][cont + 2];
					Y += valA * Math.Sin((valB + valC) * Radian);
				}
				ResultadoEvolutivo.Add(Y);
			}
		}
	}
}
