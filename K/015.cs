namespace Ejemplo {
	class Program {
		static void Main() {
			//Tabla XOR
			int[][] XORentra = new int[][] {
				new int[] {1, 1},
				new int[] {1, 0},
				new int[] {0, 1},
				new int[] {0, 0}
			};
			int[] XORsale = new int[] { 0, 1, 1, 0 };

			int TotalEntradas = 2; //Número de entradas
			int NeuronasCapa0 = 3; //Total neuronas en la capa 0
			int NeuronasCapa1 = 2; //Total neuronas en la capa 1
			int NeuronasCapa2 = 1; //Total neuronas en la capa 2
			Perceptron RedNeuronal = new(TotalEntradas, NeuronasCapa0, NeuronasCapa1, NeuronasCapa2);

			//Estas serán las dos entradas externas al perceptrón
			List<double> Entradas = [0, 0];

			//Esta será la salida esperada externa al perceptrón
			List<double> SalidaEsperada = [0];

			//Ciclo que entrena la red neuronal
			int TotalCiclos = 90000; //Ciclos de entrenamiento
			for (int Ciclo = 1; Ciclo <= TotalCiclos; Ciclo++) {

				if (Ciclo % 200 == 0) Console.WriteLine("\r\nCiclo: " + Ciclo);

				//Por cada ciclo, se entrena el perceptrón con toda la tabla de XOR
				for (int Conjunto = 0; Conjunto < XORsale.Length; Conjunto++) {

					//Entradas y salidas esperadas
					Entradas[0] = XORentra[Conjunto][0];
					Entradas[1] = XORentra[Conjunto][1];
					SalidaEsperada[0] = XORsale[Conjunto];

					//Primero calcula la salida del perceptrón con esas entradas
					RedNeuronal.CalculaSalida(Entradas);

					//Luego entrena el perceptrón para ajustar los pesos y umbrales
					RedNeuronal.Entrena(Entradas, SalidaEsperada);

					//Cada 200 ciclos muestra como progresa el entrenamiento
					if (Ciclo % 200 == 0) RedNeuronal.SalidaPerceptron(Entradas, SalidaEsperada[0]);
				}
			}

			Console.WriteLine("Finaliza el entrenamiento");
		}
	}

	class Perceptron {
		public List<Capa> Capas;

		//Imprime los datos de las diferentes capas
		public void SalidaPerceptron(List<double> Entradas, double SalidaEsperada) {

			for (int Contador = 0; Contador < Entradas.Count; Contador++)
				Console.Write(Entradas[Contador] + " | ");

			Console.Write(" Esperada: " + SalidaEsperada + "  Calculada: ");
			for (int Contador = 0; Contador < Capas[2].Salidas.Count; Contador++) {
				if (Capas[2].Salidas[Contador] >= 0.5)
					Console.Write(" 1 | ");
				else
					Console.Write(" 0 | ");
				Console.Write(Capas[2].Salidas[Contador] + " | ");
			}
			Console.WriteLine(" ");
		}

		//Crea las diversas capas
		public Perceptron(int TotalEntradas, int NeuronasCapa0, int NeuronasCapa1, int NeuronasCapa2) {
			Random Azar = new();
			Capas =
			[
				new Capa(Azar, NeuronasCapa0, TotalEntradas), //Crea la capa 0
				new Capa(Azar, NeuronasCapa1, NeuronasCapa0), //Crea la capa 1
				new Capa(Azar, NeuronasCapa2, NeuronasCapa1), //Crea la capa 2
			];
		}

		//Dada las entradas al perceptrón, se calcula la salida de cada capa.
		//Con eso se sabrá que salidas se obtienen con los pesos y umbrales actuales.
		//Esas salidas son requeridas para el algoritmo de entrenamiento.
		public void CalculaSalida(List<double> Entradas) {
			Capas[0].CalculaCapa(Entradas);
			Capas[1].CalculaCapa(Capas[0].Salidas);
			Capas[2].CalculaCapa(Capas[1].Salidas);
		}


		//Con las salidas previamente calculadas con unas determinadas entradas
		//se ejecuta el algoritmo de entrenamiento "Backpropagation"  
		public void Entrena(List<double> Entradas, List<double> SalidaEsperada) {
			int NeuronasCapa0 = Capas[0].Neuronas.Count;
			int NeuronasCapa1 = Capas[1].Neuronas.Count;
			int NeuronasCapa2 = Capas[2].Neuronas.Count;

			//Factor de aprendizaje
			double Alpha = 0.4;

			//Procesa pesos capa 2
			for (int j = 0; j < NeuronasCapa1; j++) //Va de neurona en neurona de la capa 1
				for (int i = 0; i < NeuronasCapa2; i++) { //Va de neurona en neurona de la capa de salida (capa 2)
					double Yi = Capas[2].Salidas[i]; //Salida de la neurona de la capa de salida
					double Si = SalidaEsperada[i]; //Salida esperada
					double a1j = Capas[1].Salidas[j]; //Salida de la capa 1
					double dE2 = a1j * (Yi - Si) * Yi * (1 - Yi); //La fórmula del error
					Capas[2].Neuronas[i].NuevosPesos[j] = Capas[2].Neuronas[i].Pesos[j] - Alpha * dE2; //Ajusta el nuevo peso
				}

			//Procesa pesos capa 1
			for (int j = 0; j < NeuronasCapa0; j++) //Va de neurona en neurona de la capa 0
				for (int k = 0; k < NeuronasCapa1; k++) { //Va de neurona en neurona de la capa 1
					double Acumula = 0;
					for (int i = 0; i < NeuronasCapa2; i++) { //Va de neurona en neurona de la capa 2
						double Yi = Capas[2].Salidas[i]; //Salida de la capa 2
						double Si = SalidaEsperada[i]; //Salida esperada
						double W2ki = Capas[2].Neuronas[i].Pesos[k];
						Acumula += W2ki * (Yi - Si) * Yi * (1 - Yi); //Sumatoria
					}
					double a0j = Capas[0].Salidas[j];
					double a1k = Capas[1].Salidas[k];
					double dE1 = a0j * a1k * (1 - a1k) * Acumula;
					Capas[1].Neuronas[k].NuevosPesos[j] = Capas[1].Neuronas[k].Pesos[j] - Alpha * dE1;
				}

			//Procesa pesos capa 0
			for (int j = 0; j < Entradas.Count; j++) //Va de entrada en entrada
				for (int k = 0; k < NeuronasCapa0; k++) { //Va de neurona en neurona de la capa 0
					double Acumula = 0;
					for (int p = 0; p < NeuronasCapa1; p++) { //Va de neurona en neurona de la capa 1
						double InternoAcumula = 0;
						for (int i = 0; i < NeuronasCapa2; i++) { //Va de neurona en neurona de la capa 2
							double Yi = Capas[2].Salidas[i];
							double Si = SalidaEsperada[i]; //Salida esperada
							double W2pi = Capas[2].Neuronas[i].Pesos[p];
							InternoAcumula += W2pi * (Yi - Si) * Yi * (1 - Yi); //Sumatoria interna
						}
						double W1kp = Capas[1].Neuronas[p].Pesos[k];
						double a1p = Capas[1].Salidas[p];
						Acumula += W1kp * a1p * (1 - a1p) * InternoAcumula; //Sumatoria externa
					}
					double xj = Entradas[j];
					double a0k = Capas[0].Salidas[k];
					double dE0 = xj * a0k * (1 - a0k) * Acumula;
					double W0jk = Capas[0].Neuronas[k].Pesos[j];
					Capas[0].Neuronas[k].NuevosPesos[j] = W0jk - Alpha * dE0;
				}


			//Procesa umbrales capa 2
			for (int i = 0; i < NeuronasCapa2; i++) { //Va de neurona en neurona de la capa de salida (capa 2)
				double Yi = Capas[2].Salidas[i]; //Salida de la neurona de la capa de salida
				double Si = SalidaEsperada[i]; //Salida esperada
				double dE2 = (Yi - Si) * Yi * (1 - Yi);
				Capas[2].Neuronas[i].NuevoUmbral = Capas[2].Neuronas[i].Umbral - Alpha * dE2;
			}

			//Procesa umbrales capa 1
			for (int k = 0; k < NeuronasCapa1; k++) { //Va de neurona en neurona de la capa 1
				double Acumula = 0;
				for (int i = 0; i < NeuronasCapa2; i++) { //Va de neurona en neurona de la capa 2
					double Yi = Capas[2].Salidas[i]; //Salida de la capa 2
					double Si = SalidaEsperada[i];
					double W2ki = Capas[2].Neuronas[i].Pesos[k];
					Acumula += W2ki * (Yi - Si) * Yi * (1 - Yi);
				}
				double a1k = Capas[1].Salidas[k];
				double dE1 = a1k * (1 - a1k) * Acumula;
				Capas[1].Neuronas[k].NuevoUmbral = Capas[1].Neuronas[k].Umbral - Alpha * dE1;
			}

			//Procesa umbrales capa 0
			for (int k = 0; k < NeuronasCapa0; k++) { //Va de neurona en neurona de la capa 0
				double Acumula = 0;
				for (int p = 0; p < NeuronasCapa1; p++) { //Va de neurona en neurona de la capa 1
					double InternoAcumula = 0;
					for (int i = 0; i < NeuronasCapa2; i++) { //Va de neurona en neurona de la capa 2
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
				Capas[0].Neuronas[k].NuevoUmbral = Capas[0].Neuronas[k].Umbral - Alpha * dE0;
			}

			//Actualiza los pesos
			Capas[0].Actualiza();
			Capas[1].Actualiza();
			Capas[2].Actualiza();
		}

	}

	class Capa {
		public List<Neurona> Neuronas; //Las neuronas que tendrá la capa
		public List<double> Salidas; //Almacena las salidas de cada neurona

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
		public List<double> Pesos; //Los pesos para cada entrada
		public List<double> NuevosPesos; //Nuevos pesos dados por el algoritmo de "backpropagation"
		public double Umbral; //El peso del umbral
		public double NuevoUmbral; //Nuevo umbral dado por el algoritmo de "backpropagation"

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