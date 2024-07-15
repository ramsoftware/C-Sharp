namespace Ejemplo {
	class Program {
		static void Main() {
			Random Azar = new();

			//Genera una ecuación al azar para generar el dataset
			double cfA, cfB, cfC, cfD;
			double cfE, cfF, cfG, cfH, cfI;

			double cfMin = -10;
			double cfMax = 10;
			cfA = Azar.NextDouble() * (cfMax - cfMin) + cfMin;
			cfB = Azar.NextDouble() * (cfMax - cfMin) + cfMin;
			cfC = Azar.NextDouble() * (cfMax - cfMin) + cfMin;
			cfD = Azar.NextDouble() * (cfMax - cfMin) + cfMin;
			cfE = Azar.NextDouble() * (cfMax - cfMin) + cfMin;
			cfF = Azar.NextDouble() * (cfMax - cfMin) + cfMin;
			cfG = Azar.NextDouble() * (cfMax - cfMin) + cfMin;
			cfH = Azar.NextDouble() * (cfMax - cfMin) + cfMin;
			cfI = Azar.NextDouble() * (cfMax - cfMin) + cfMin;

			List<double> Xentra = new List<double>();
			List<double> Ysale = new List<double>();

			//Genera el dataset con esta ecuación
			double Y;
			for (double X = -360; X <= 360; X++) {
				Y = cfA * Math.Sin((cfB * X + cfC) * Math.PI / 180);
				Y += cfD * Math.Sin((cfE * X + cfF) * Math.PI / 180);
				Y += cfG * Math.Sin((cfH * X + cfI) * Math.PI / 180);

				Xentra.Add(X);
				Ysale.Add(Y);
			}

			//Con los datos de entrada y salida
			//generados (el dataset), ahora procede
			//a normalizarlos
			double MinX = double.MaxValue;
			double MaxX = double.MinValue;

			double MinY = double.MaxValue;
			double MaxY = double.MinValue;

			for (int Datos = 0; Datos < Ysale.Count; Datos++) {
				if (Xentra[Datos] < MinX) MinX = Xentra[Datos];
				if (Xentra[Datos] > MaxX) MaxX = Xentra[Datos];
				if (Ysale[Datos] < MinY) MinY = Ysale[Datos];
				if (Ysale[Datos] > MaxY) MaxY = Ysale[Datos];
			}

			for (int Datos = 0; Datos < Ysale.Count; Datos++) {
				Xentra[Datos] = (Xentra[Datos] - MinX) / (MaxX - MinX);
				Ysale[Datos] = (Ysale[Datos] - MinY) / (MaxY - MinY);
			}

			//Con los datos normalizados, ahora se entrena
			//a la red neuronal para que detecte el patrón
			int TotalEntradas = 1; //Número de entradas
			int NeuronasCapa0 = 5; //Total neuronas en la capa 0
			int NeuronasCapa1 = 5; //Total neuronas en la capa 1
			int NeuronasCapa2 = 1; //Total neuronas en la capa 2
			Perceptron RedNeuronal = new(TotalEntradas, NeuronasCapa0,
										NeuronasCapa1, NeuronasCapa2);

			//Esta será la única entrada externa
			//al perceptrón, es decir, X
			List<double> Entrada = [0];

			//Esta será la salida esperada 
			//externa al perceptrón, es decir, Y
			List<double> SalidaEsperada = [0];

			//Ciclo que entrena la red neuronal
			int TotalCiclos = 25000; //Ciclos de entrenamiento
			for (int Ciclo = 1; Ciclo <= TotalCiclos; Ciclo++) {

				if (Ciclo % 5000 == 0)
					Console.WriteLine("Ciclo: " + Ciclo);

				//Por cada ciclo, se entrena 
				//el perceptrón con toda la tabla
				for (int Cnj = 0; Cnj < Xentra.Count; Cnj++) {

					//Entrada y salida esperadas
					Entrada[0] = Xentra[Cnj];
					SalidaEsperada[0] = Ysale[Cnj];

					//Primero calcula la salida 
					//del perceptrón con esa entrada
					RedNeuronal.CalculaSalida(Entrada);

					//Luego entrena el perceptrón para
					//ajustar los pesos y umbrales
					RedNeuronal.Entrena(Entrada, SalidaEsperada);
				}
			}

			Console.Write("Entrada normalizada;");
			Console.Write("Salida esperada normalizada;");
			Console.WriteLine("Salida perceptrón normalizada");

			for (int Cnj = 0; Cnj < Xentra.Count; Cnj++) {
				//Entradas y salidas esperadas
				Entrada[0] = Xentra[Cnj];
				SalidaEsperada[0] = Ysale[Cnj];

				//Calcula la salida del perceptrón con esas entradas
				RedNeuronal.CalculaSalida(Entrada);

				//Muestra la salida
				RedNeuronal.SalidaPerceptron(Entrada, SalidaEsperada);
			}
			Console.WriteLine("Finaliza el entrenamiento");
		}
	}

	class Perceptron {
		public List<Capa> Capas;

		//Imprime los datos de las diferentes capas
		public void SalidaPerceptron(List<double> Entradas,
									 List<double> SalidaEsperada) {
			//Personalizado para series de tiempo:
			//Una entrada y una salida
			Console.Write(Entradas[0] + ";");
			Console.Write(SalidaEsperada[0] + ";");
			Console.WriteLine(Capas[2].Salidas[0]);
		}

		//Crea las diversas capas
		public Perceptron(int TotalEntradas, int NeuronasCapa0,
							int NeuronasCapa1, int NeuronasCapa2) {
			Random Azar = new();
			Capas =
			[
				new Capa(Azar, NeuronasCapa0, TotalEntradas), //Crea la capa 0
				new Capa(Azar, NeuronasCapa1, NeuronasCapa0), //Crea la capa 1
				new Capa(Azar, NeuronasCapa2, NeuronasCapa1), //Crea la capa 2
			];
		}

		//Dada las entradas al perceptrón, se calcula
		//la salida de cada capa. Con eso se sabrá que salidas
		//se obtienen con los pesos y umbrales actuales. Esas
		//salidas son requeridas para el algoritmo de entrenamiento.
		public void CalculaSalida(List<double> Entradas) {
			Capas[0].CalculaCapa(Entradas);
			Capas[1].CalculaCapa(Capas[0].Salidas);
			Capas[2].CalculaCapa(Capas[1].Salidas);
		}


		//Con las salidas previamente calculadas con
		//unas determinadas entradas se ejecuta el algoritmo
		//de entrenamiento "Backpropagation"  
		public void Entrena(List<double> Entradas,
							List<double> SalidaEsperada) {
			int NeuronasCapa0 = Capas[0].Neuronas.Count;
			int NeuronasCapa1 = Capas[1].Neuronas.Count;
			int NeuronasCapa2 = Capas[2].Neuronas.Count;

			//Factor de aprendizaje
			double Alpha = 0.4;

			//====================
			//Procesa pesos capa 2
			//====================

			//Va de neurona en neurona de la capa 1
			for (int j = 0; j < NeuronasCapa1; j++)

				//Va de neurona en neurona de la capa de salida (capa 2)
				for (int i = 0; i < NeuronasCapa2; i++) {

					//Salida de la neurona de la capa de salida
					double Yi = Capas[2].Salidas[i];

					//Salida esperada
					double Si = SalidaEsperada[i];

					//Salida de la capa 1
					double a1j = Capas[1].Salidas[j];

					//La fórmula del error
					double dE2 = a1j * (Yi - Si) * Yi * (1 - Yi);

					//Ajusta el nuevo peso
					double Nuevo = Capas[2].Neuronas[i].Pesos[j] - Alpha * dE2;
					Capas[2].Neuronas[i].NuevosPesos[j] = Nuevo;
				}

			//====================
			//Procesa pesos capa 1
			//====================

			//Va de neurona en neurona de la capa 0
			for (int j = 0; j < NeuronasCapa0; j++)

				//Va de neurona en neurona de la capa 1
				for (int k = 0; k < NeuronasCapa1; k++) {
					double Acumula = 0;

					//Va de neurona en neurona de la capa 2
					for (int i = 0; i < NeuronasCapa2; i++) {

						//Salida de la capa 2
						double Yi = Capas[2].Salidas[i];

						//Salida esperada
						double Si = SalidaEsperada[i];
						double W2ki = Capas[2].Neuronas[i].Pesos[k];
						Acumula += W2ki * (Yi - Si) * Yi * (1 - Yi); //Sumatoria
					}
					double a0j = Capas[0].Salidas[j];
					double a1k = Capas[1].Salidas[k];
					double dE1 = a0j * a1k * (1 - a1k) * Acumula;
					double Nuevo = Capas[1].Neuronas[k].Pesos[j] - Alpha * dE1;
					Capas[1].Neuronas[k].NuevosPesos[j] = Nuevo;
				}

			//====================
			//Procesa pesos capa 0
			//====================

			//Va de entrada en entrada
			for (int j = 0; j < Entradas.Count; j++)

				//Va de neurona en neurona de la capa 0
				for (int k = 0; k < NeuronasCapa0; k++) {
					double Acumula = 0;

					//Va de neurona en neurona de la capa 1
					for (int p = 0; p < NeuronasCapa1; p++) {
						double InternoAcumula = 0;

						//Va de neurona en neurona de la capa 2
						for (int i = 0; i < NeuronasCapa2; i++) {
							double Yi = Capas[2].Salidas[i];
							double Si = SalidaEsperada[i]; //Salida esperada
							double W2pi = Capas[2].Neuronas[i].Pesos[p];

							//Sumatoria interna
							InternoAcumula += W2pi * (Yi - Si) * Yi * (1 - Yi);
						}
						double W1kp = Capas[1].Neuronas[p].Pesos[k];
						double a1p = Capas[1].Salidas[p];

						//Sumatoria externa
						Acumula += W1kp * a1p * (1 - a1p) * InternoAcumula;
					}
					double xj = Entradas[j];
					double a0k = Capas[0].Salidas[k];
					double dE0 = xj * a0k * (1 - a0k) * Acumula;
					double W0jk = Capas[0].Neuronas[k].Pesos[j];
					Capas[0].Neuronas[k].NuevosPesos[j] = W0jk - Alpha * dE0;
				}

			//=======================
			//Procesa umbrales capa 2
			//=======================

			//Va de neurona en neurona de la capa de salida (capa 2)
			for (int i = 0; i < NeuronasCapa2; i++) {

				//Salida de la neurona de la capa de salida
				double Yi = Capas[2].Salidas[i];

				//Salida esperada
				double Si = SalidaEsperada[i];
				double dE2 = (Yi - Si) * Yi * (1 - Yi);
				double Nuevo = Capas[2].Neuronas[i].Umbral - Alpha * dE2;
				Capas[2].Neuronas[i].NuevoUmbral = Nuevo;
			}

			//=======================
			//Procesa umbrales capa 1
			//=======================

			//Va de neurona en neurona de la capa 1
			for (int k = 0; k < NeuronasCapa1; k++) {
				double Acumula = 0;

				//Va de neurona en neurona de la capa 2
				for (int i = 0; i < NeuronasCapa2; i++) {

					//Salida de la capa 2
					double Yi = Capas[2].Salidas[i];
					double Si = SalidaEsperada[i];
					double W2ki = Capas[2].Neuronas[i].Pesos[k];
					Acumula += W2ki * (Yi - Si) * Yi * (1 - Yi);
				}
				double a1k = Capas[1].Salidas[k];
				double dE1 = a1k * (1 - a1k) * Acumula;
				double Nuevo = Capas[1].Neuronas[k].Umbral - Alpha * dE1;
				Capas[1].Neuronas[k].NuevoUmbral = Nuevo;
			}

			//=======================
			//Procesa umbrales capa 0
			//=======================

			//Va de neurona en neurona de la capa 0
			for (int k = 0; k < NeuronasCapa0; k++) {
				double Acumula = 0;

				//Va de neurona en neurona de la capa 1
				for (int p = 0; p < NeuronasCapa1; p++) {
					double InternoAcumula = 0;

					//Va de neurona en neurona de la capa 2
					for (int i = 0; i < NeuronasCapa2; i++) {
						double Yi = Capas[2].Salidas[i];
						double Si = SalidaEsperada[i];
						double W2pi = Capas[2].Neuronas[i].Pesos[p];
						InternoAcumula += W2pi * (Yi - Si) * Yi * (1 - Yi);
					}
					double W1kp = Capas[1].Neuronas[p].Pesos[k];
					double a1p = Capas[1].Salidas[p];
					Acumula += W1kp * a1p * (1 - a1p) * InternoAcumula;
				}
				double a0k = Capas[0].Salidas[k];
				double dE0 = a0k * (1 - a0k) * Acumula;
				double Nuevo = Capas[0].Neuronas[k].Umbral - Alpha * dE0;
				Capas[0].Neuronas[k].NuevoUmbral = Nuevo;
			}

			//Actualiza los pesos
			Capas[0].Actualiza();
			Capas[1].Actualiza();
			Capas[2].Actualiza();
		}

	}

	class Capa {
		//Las neuronas que tendrá la capa
		public List<Neurona> Neuronas;

		//Almacena las salidas de cada neurona
		public List<double> Salidas;

		public Capa(Random Azar, int TotalNeuronas, int TotalEntradas) {
			Neuronas = [];
			Salidas = [];

			//Genera las neuronas
			for (int Contador = 0; Contador < TotalNeuronas; Contador++) {
				Neuronas.Add(new Neurona(Azar, TotalEntradas));
				Salidas.Add(0);
			}
		}

		//Calcula las salidas de cada neurona de la capa
		public void CalculaCapa(List<double> Entradas) {
			for (int Contador = 0; Contador < Neuronas.Count; Contador++)
				Salidas[Contador] = Neuronas[Contador].CalculaSalida(Entradas);
		}

		//Actualiza los pesos y umbrales de las neuronas
		public void Actualiza() {
			for (int Contador = 0; Contador < Neuronas.Count; Contador++)
				Neuronas[Contador].Actualiza();
		}
	}

	class Neurona {
		//Los pesos para cada entrada
		public List<double> Pesos;

		//Nuevos pesos dados por el algoritmo de "backpropagation"
		public List<double> NuevosPesos;

		//El peso del umbral
		public double Umbral;

		//Nuevo umbral dado por el algoritmo de "backpropagation"
		public double NuevoUmbral;

		//Inicializa los pesos y umbral con un valor al azar
		public Neurona(Random Azar, int TotalEntradas) {
			Pesos = [];
			NuevosPesos = [];
			for (int Contador = 0; Contador < TotalEntradas; Contador++) {
				Pesos.Add(Azar.NextDouble());
				NuevosPesos.Add(0);
			}
			Umbral = Azar.NextDouble();
			NuevoUmbral = 0;
		}

		//Calcula la salida de la neurona dependiendo de las entradas
		public double CalculaSalida(List<double> Entradas) {
			double Valor = 0;
			for (int Contador = 0; Contador < Pesos.Count; Contador++)
				Valor += Entradas[Contador] * Pesos[Contador];
			Valor += Umbral;
			return 1 / (1 + Math.Exp(-Valor));
		}

		//Reemplaza viejos pesos por nuevos
		public void Actualiza() {
			for (int Contador = 0; Contador < Pesos.Count; Contador++)
				Pesos[Contador] = NuevosPesos[Contador];
			Umbral = NuevoUmbral;
		}
	}
}