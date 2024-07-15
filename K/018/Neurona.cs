namespace Ejemplo {
	internal class Neurona {
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
