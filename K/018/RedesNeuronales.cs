using System.Diagnostics;

namespace Ejemplo {
	internal class RedesNeuronales {
		public void Proceso(Random Azar, long TiempoParaOperar, int NeuronasCapa0, int NeuronasCapa1, DatosArchivo Datos, List<double> ResultadoNeuronal) {
			//======================================================================
			//Red Neuronal
			//======================================================================
			int TotalEntradas = 1; //Número de entradas
			int NeuronasCapa2 = 1; //Total neuronas en la capa 2
			Perceptron RedNeuronal = new(Azar, TotalEntradas, NeuronasCapa0, NeuronasCapa1, NeuronasCapa2);

			//Esta será la única entrada externa al perceptrón, es decir, X
			List<double> Entrada = [0];

			//Esta será la salida esperada externa al perceptrón, es decir, Y
			List<double> SalidaEsperada = [0];

			//Medidor de tiempos
			Stopwatch cronometro = new();
			cronometro.Reset();
			cronometro.Start();

			//Tiempo que repetirá el proceso evolutivo
			while (cronometro.ElapsedMilliseconds < TiempoParaOperar) {

				//Por cada iteración, se entrena el perceptrón con toda la tabla
				for (int Conjunto = 0; Conjunto < Datos.XentradaN.Count; Conjunto++) {

					//Entrada y salida esperadas
					Entrada[0] = Datos.XentradaN[Conjunto];
					SalidaEsperada[0] = Datos.YsalidasN[Conjunto];

					//Primero calcula la salida del perceptrón con esa entrada
					RedNeuronal.CalculaSalida(Entrada);

					//Luego entrena el perceptrón para ajustar los pesos y umbrales
					RedNeuronal.Entrena(Entrada, SalidaEsperada);
				}
			}

			//Muestra el ajuste de la red neuronal a los datos dados.
			ResultadoNeuronal.Clear();
			for (int Conjunto = 0; Conjunto < Datos.XentradaN.Count; Conjunto++) {
				//Entradas y salidas esperadas
				Entrada[0] = Datos.XentradaN[Conjunto];
				SalidaEsperada[0] = Datos.YsalidasN[Conjunto];

				//Calcula la salida del perceptrón con esas entradas
				RedNeuronal.CalculaSalida(Entrada);

				//Las salidas de la red desnormalizadas
				double Salir = RedNeuronal.Capas[2].Salidas[0] * (Datos.Ysalidas.Max() - Datos.Ysalidas.Min()) + Datos.Ysalidas.Min();
				ResultadoNeuronal.Add(Salir);
			}
		}
	}
}
