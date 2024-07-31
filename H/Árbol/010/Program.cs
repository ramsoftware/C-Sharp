using System.Diagnostics;

//Comparar los dos evaluadores
namespace ArbolBinarioEvaluador {
	internal class Program {

		static void Main(string[] args) {
			long TAnalisisEval4 = 0, TEvaluaEval4 = 0;
			long TAnalisisArbol = 0, TEvaluaArbol = 0;

			EvalArbolBin arbol = new();
			Evaluador4 eval4 = new();
			EcuacionAzar ecu = new();

			//Toma el tiempo
			Stopwatch temporizador = new();

			//Parámetros
			int TotalEcuaciones = 10000;
			int VecesEvalua = 3000;
			int Tamano = 400;

			//Valores de X al azar
			double[] valX = new double[VecesEvalua];
			Random azar = new();

			for (int cont = 1; cont <= TotalEcuaciones; cont++) {
				//Ecuación al azar
				string Ecuacion = ecu.Ecuacion(Tamano);

				//Valores de X al azar
				for (int xvalor = 0; xvalor < valX.Length; xvalor++) {
					valX[xvalor] = azar.NextDouble() - azar.NextDouble();
				}

				//Analiza la expresión con el árbol binario
				temporizador.Reset();
				temporizador.Start();
				arbol.Analizar(Ecuacion);
				temporizador.Stop();
				TAnalisisArbol += temporizador.ElapsedTicks;

				//Analiza la expresión con el evaluador 4.0
				temporizador.Reset();
				temporizador.Start();
				eval4.Analizar(Ecuacion);
				temporizador.Stop();
				TAnalisisEval4 += temporizador.ElapsedTicks;

				//Evalúa la expresión con el árbol binario
				temporizador.Reset();
				temporizador.Start();
				double ResArbol = 0;
				for (int xvalor = 0; xvalor < valX.Length; xvalor++) {
					arbol.DarValorVariable('x', valX[xvalor]);
					ResArbol += arbol.Evaluar();
				}
				temporizador.Stop();
				TEvaluaArbol += temporizador.ElapsedTicks;

				//Evalúa la expresión con el evaluador 4.0
				temporizador.Reset();
				temporizador.Start();
				double ResEval4 = 0;
				for (int xvalor = 0; xvalor < valX.Length; xvalor++) {
					eval4.DarValorVariable('x', valX[xvalor]);
					ResEval4 += eval4.Evaluar();
				}
				temporizador.Stop();
				TEvaluaEval4 += temporizador.ElapsedTicks;

				//Chequea si hay una diferencia entre ambos evaluadores
				if (Math.Abs(ResArbol - ResEval4) > 0.01) {
					Console.WriteLine(Ecuacion);
					Console.WriteLine("Arbol: " + ResArbol);
					Console.WriteLine("Eval4: " + ResEval4);
					break;
				}
			}

			Console.WriteLine("Tamaño ecuación: " + Tamano);
			Console.WriteLine("Total ecuaciones: " + TotalEcuaciones);
			Console.WriteLine("Veces evalúa: " + VecesEvalua);
			Console.WriteLine("[Eval4] Análisis: " + TAnalisisEval4 + " Evalúa: " + TEvaluaEval4);
			Console.WriteLine("[Arbol] Análisis: " + TAnalisisArbol + " Evalúa: " + TEvaluaArbol);
			Console.WriteLine("FIN");
		}
	}
}