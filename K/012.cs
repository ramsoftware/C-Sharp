namespace Ejemplo {
	class Program {
		static void Main() {
		}
	}

	class Perceptron {
		List<Capa>? Capas;

		//Crea las diversas capas
		public void CreaCapas(Random Azar, int NumeroEntradas, int TotalNeuronasCapa0, int TotalNeuronasCapa1, int TotalNeuronasCapa2) {
			Capas =
			[
				//Crea la capa 0
				new Capa(Azar, TotalNeuronasCapa0, NumeroEntradas),

				//Crea la capa 1 (el número de entradas es el número de neuronas de la capa anterior)
				new Capa(Azar, TotalNeuronasCapa1, TotalNeuronasCapa0),

				//Crea la capa 2 (el número de entradas es el número de neuronas de la capa anterior)
				new Capa(Azar, TotalNeuronasCapa2, TotalNeuronasCapa1),
			];
		}
	}

	class Capa {
		List<Neurona> Neuronas; //Las neuronas que tendrá la capa
		List<double> Salidas; //Almacena la salida de cada neurona

		public Capa(Random Azar, int TotalNeuronas, int TotalEntradas) {
			Neuronas = [];
			Salidas = [];

			//Genera las neuronas e inicializa sus salidas
			for (int Contador = 0; Contador < TotalNeuronas; Contador++) {
				Neuronas.Add(new Neurona(Azar, TotalEntradas));
				Salidas.Add(0);
			}
		}

		//Calcula la salida de cada neurona de la capa
		public void CalculaCapa(List<double> Entradas) {
			for (int cont = 0; cont < Neuronas.Count; cont++)
				Salidas[cont] = Neuronas[cont].CalculaSalida(Entradas);
		}
	}
}

class Neurona {
	private List<double> Pesos; //Los pesos para cada entrada
	double Umbral; //El peso del umbral

	//Inicializa los pesos y umbral con un valor al azar
	public Neurona(Random Azar, int TotalEntradas) {
		Pesos = [];
		for (int Contador = 0; Contador < TotalEntradas; Contador++)
			Pesos.Add(Azar.NextDouble());
		Umbral = Azar.NextDouble();
	}

	//Calcula la salida de la neurona dependiendo de las entradas
	public double CalculaSalida(List<double> Entradas) {
		double Valor = 0;
		for (int Contador = 0; Contador < Pesos.Count; Contador++)
			Valor += Entradas[Contador] * Pesos[Contador];
		Valor += Umbral;
		return 1 / (1 + Math.Exp(-Valor));
	}
}