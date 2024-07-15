namespace Ejemplo {
	internal class Capa {
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
}
