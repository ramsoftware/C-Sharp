using System.Diagnostics;

namespace Ejemplo {
	internal class Poblacion {
		//Para agilizar cálculos
		static private double Radian;

		//Los individuos
		double[][] Individuos;
		double[] Ajuste;

		//Inicializa la población con los individuos
		public Poblacion(Random Azar, int TamanoPoblacion) {
			Individuos = new double[TamanoPoblacion][];
			Ajuste = new double[TamanoPoblacion];

			Radian = Math.PI / 180;
			for (int cont = 0; cont < Individuos.Length; cont++) {
				Ajuste[cont] = double.MaxValue;
				Individuos[cont] = new double[30];
				for (int valor = 0; valor < 30; valor++) {
					Individuos[cont][valor] = Azar.NextDouble() * 2 - 1;
				}
			}
		}

		//Proceso evolutivo.
		public void Proceso(Random Azar, List<double> Entradas, List<double> SalidasEsperadas, long TiempoParaOperar, List<double> ResultadoEvolutivo) {

			//Medidor de tiempos
			Stopwatch cronometro = new();
			cronometro.Reset();
			cronometro.Start();

			//Tiempo que repetirá el proceso evolutivo
			int Turno = 0;
			while (cronometro.ElapsedMilliseconds <= TiempoParaOperar) {

				//Guarda los valores anteriores
				int CualMuta = Azar.Next(30);
				double ValorAnterior = Individuos[Turno][CualMuta];
				Individuos[Turno][CualMuta] += Azar.NextDouble() * 2 - 1;

				//Deduce el ajuste
				double NuevoAjuste = 0;
				for (int Xval = 0; Xval < Entradas.Count; Xval++) {

					//Entrada del ambiente
					double X = Entradas[Xval] * 1000;

					//Deduce el valor Y del individuo con esa entrada X del ambiente
					double Y = Individuos[Turno][0] * Math.Sin((Individuos[Turno][1] * X + Individuos[Turno][2]) * Radian) +
	Individuos[Turno][3] * Math.Sin((Individuos[Turno][4] * X + Individuos[Turno][5]) * Radian) +
	Individuos[Turno][6] * Math.Sin((Individuos[Turno][7] * X + Individuos[Turno][8]) * Radian) +
	Individuos[Turno][9] * Math.Sin((Individuos[Turno][10] * X + Individuos[Turno][11]) * Radian) +
	Individuos[Turno][12] * Math.Sin((Individuos[Turno][13] * X + Individuos[Turno][14]) * Radian) +
	Individuos[Turno][15] * Math.Sin((Individuos[Turno][16] * X + Individuos[Turno][17]) * Radian) +
	Individuos[Turno][18] * Math.Sin((Individuos[Turno][19] * X + Individuos[Turno][20]) * Radian) +
	Individuos[Turno][21] * Math.Sin((Individuos[Turno][22] * X + Individuos[Turno][23]) * Radian) +
	Individuos[Turno][24] * Math.Sin((Individuos[Turno][25] * X + Individuos[Turno][26]) * Radian) +
	Individuos[Turno][27] * Math.Sin((Individuos[Turno][28] * X + Individuos[Turno][29]) * Radian);

					//Diferencia entre la salida calculada y la esperada
					NuevoAjuste += Math.Abs(Y - SalidasEsperadas[Xval] * 1000);

					//Si el nuevo ajuste supera al ajuste anterior, sale del ciclo
					if (NuevoAjuste > Ajuste[Turno]) break;
				}

				//Si el cambio mejora al individuo se conserva, caso contrario se restaura el valor anterior
				if (NuevoAjuste > Ajuste[Turno])
					Individuos[Turno][CualMuta] = ValorAnterior;
				else
					Ajuste[Turno] = NuevoAjuste;

				if (++Turno >= Individuos.Length) Turno = 0;
			}

			//Imprime el mejor individuo
			int Mejor = -1;
			double MejorAjuste = double.MaxValue;
			for (int cont = 0; cont < Individuos.Length; cont++)
				if (Ajuste[cont] < MejorAjuste) {
					MejorAjuste = Ajuste[cont];
					Mejor = cont;
				}

			for (int Xval = 0; Xval < Entradas.Count; Xval++) {
				//Entrada del ambiente
				double X = Entradas[Xval] * 1000;

				//Deduce el valor Y del individuo con esa entrada X del ambiente
				double Y = Individuos[Mejor][0] * Math.Sin((Individuos[Mejor][1] * X + Individuos[Mejor][2]) * Radian) +
Individuos[Mejor][3] * Math.Sin((Individuos[Mejor][4] * X + Individuos[Mejor][5]) * Radian) +
Individuos[Mejor][6] * Math.Sin((Individuos[Mejor][7] * X + Individuos[Mejor][8]) * Radian) +
Individuos[Mejor][9] * Math.Sin((Individuos[Mejor][10] * X + Individuos[Mejor][11]) * Radian) +
Individuos[Mejor][12] * Math.Sin((Individuos[Mejor][13] * X + Individuos[Mejor][14]) * Radian) +
Individuos[Mejor][15] * Math.Sin((Individuos[Mejor][16] * X + Individuos[Mejor][17]) * Radian) +
Individuos[Mejor][18] * Math.Sin((Individuos[Mejor][19] * X + Individuos[Mejor][20]) * Radian) +
Individuos[Mejor][21] * Math.Sin((Individuos[Mejor][22] * X + Individuos[Mejor][23]) * Radian) +
Individuos[Mejor][24] * Math.Sin((Individuos[Mejor][25] * X + Individuos[Mejor][26]) * Radian) +
Individuos[Mejor][27] * Math.Sin((Individuos[Mejor][28] * X + Individuos[Mejor][29]) * Radian);

				ResultadoEvolutivo.Add(Y);
			}
		}
	}
}
