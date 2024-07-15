using System.Data;
using System.Diagnostics;

namespace Ejemplo {
	internal class Program {
		static void Main() {
			Random Azar = new();

			//Versión 2024
			Evaluador4 evaluador2024 = new();

			//Arreglos que guardan valores de X, Y, Z
			double[] arregloX = new double[200];
			double[] arregloY = new double[200];
			double[] arregloZ = new double[200];
			for (int cont = 0; cont < arregloX.Length; cont++) {
				arregloX[cont] = Azar.NextDouble();
				arregloY[cont] = Azar.NextDouble();
				arregloZ[cont] = Azar.NextDouble();
			}

			//Prueba evaluador
			long TotalTiempo2024Evalua = 0, TotalTiempo2024Analiza = 0;
			double valor2024, AcumValor2024 = 0;

			//Evaluador interno
			long TotalTiempoInterno = 0;
			double valorInterno, AcumInterno = 0;

			//Toma el tiempo
			Stopwatch temporizador = new();

			for (int num = 1; num <= 1000; num++) {
				string ecuacion = EcuacionAzar(350, Azar);
				//Console.WriteLine(ecuacion);

				//Versión 2024. Análisis.
				temporizador.Reset();
				temporizador.Start();
				evaluador2024.Analizar(ecuacion);
				temporizador.Stop();
				TotalTiempo2024Analiza += temporizador.ElapsedTicks;

				//Versión 2024. Evaluación
				temporizador.Reset();
				temporizador.Start();
				valor2024 = 0;
				for (int cont = 0; cont < arregloX.Length; cont++) {
					evaluador2024.DarValorVariable('x', arregloX[cont]);
					evaluador2024.DarValorVariable('y', arregloY[cont]);
					evaluador2024.DarValorVariable('z', arregloZ[cont]);
					valor2024 += Math.Abs(evaluador2024.Evaluar());
				}
				temporizador.Stop();
				TotalTiempo2024Evalua += temporizador.ElapsedTicks;

				//Compara contra el evaluador de
				//expresiones propio que tiene C#
				var EvaluadorInterno = new DataTable();
				temporizador.Reset();
				temporizador.Start();
				valorInterno = 0;
				for (int cont = 0; cont < arregloX.Length; cont++) {
					string ec1 = ecuacion;
					string ec2 = ec1.Replace("x", arregloX[cont].ToString());
					string ec3 = ec2.Replace("y", arregloY[cont].ToString());
					string ec4 = ec3.Replace("z", arregloZ[cont].ToString());
					string ec5 = ec4.Replace(",", ".");
					var Result = EvaluadorInterno.Compute(ec5, "");
					valorInterno += Math.Abs(Convert.ToDouble(Result));
				}
				temporizador.Stop();
				TotalTiempoInterno += temporizador.ElapsedTicks;

				if (Math.Abs(valor2024) > 10000000) continue;
				if (double.IsNaN(valor2024) || double.IsInfinity(valor2024))
					continue;

				AcumValor2024 += valor2024;
				AcumInterno += valorInterno;
			}
			Console.WriteLine("Evaluador 2024 acumula: " + AcumValor2024);
			Console.WriteLine("Interno C#	 acumula: " + AcumInterno);

			Console.Write("\r\nEvaluador 2024 tiempo para  evaluar: ");
			Console.WriteLine(TotalTiempo2024Evalua);

			Console.Write("Evaluador 2024 tiempo para analizar: ");
			Console.WriteLine(TotalTiempo2024Analiza);

			long TotalTiempo = TotalTiempo2024Evalua + TotalTiempo2024Analiza;

			Console.Write("\r\nEvaluador 2024 tiempo: analizar y evaluar: ");
			Console.WriteLine(TotalTiempo);

			Console.Write("Interno		tiempo: analizar y evaluar: ");
			Console.WriteLine(TotalTiempoInterno);
		}

		public static string EcuacionAzar(int Longitud, Random Azar) {
			int cont = 0;
			int numParentesisAbre = 0;

			string Ecuacion = "";
			while (cont < Longitud) {

				//Función o paréntesis o nada
				if (Azar.NextDouble() < 0.5) {
					Ecuacion += "(";
					numParentesisAbre++;
					cont++;
				}

				//Variable o número
				cont++;
				switch (Azar.Next(4)) {
					case 0: Ecuacion += NumeroAzar(Azar); break;
					case 1: Ecuacion += "x"; break;
					case 2: Ecuacion += "y"; break;
					case 3: Ecuacion += "z"; break;
				}

				//Paréntesis que cierra
				int numParentesisCierra = Azar.Next(numParentesisAbre + 1);
				for (int num = 1; num <= numParentesisCierra; num++) {
					Ecuacion += ")";
					numParentesisAbre--;
					cont++;
				}

				//Operador
				cont++;
				Ecuacion += OperadorAzar(Azar);
			}

			//Variable o número
			switch (Azar.Next(4)) {
				case 0: Ecuacion += NumeroAzar(Azar); break;
				case 1: Ecuacion += "x"; break;
				case 2: Ecuacion += "y"; break;
				case 3: Ecuacion += "z"; break;
			}

			for (int num = 0; num < numParentesisAbre; num++)
				Ecuacion += ")";

			return Ecuacion;
		}

		private static string OperadorAzar(Random azar) {
			string[] operadores = { "+", "-", "*" };
			return operadores[azar.Next(operadores.Length)];
		}

		private static string NumeroAzar(Random azar) {
			return "0." + Convert.ToString(azar.Next(1000000) + 1);
		}
	}
}
