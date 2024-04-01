namespace Ejemplo {

	internal class Cubo {
		//Un cubo tiene 8 coordenadas espaciales X, Y, Z
		private List<double> Coordenadas;

		//Se convierten en 8 coordenadas espaciales X, Y, Z al girarse
		private List<double> Giradas;

		//Luego tiene 8 coordenadas planas
		private List<double> PlanoX;
		private List<double> PlanoY;

		//Constructor
		public Cubo() {
			//Coordenadas espaciales X,Y,Z para hacer el cubo
			Coordenadas = [
			-0.5, -0.5, -0.5,
			0.5, -0.5, -0.5,
			0.5, 0.5, -0.5,
			-0.5, 0.5, -0.5,
			-0.5, -0.5, 0.5,
			0.5, -0.5, 0.5,
			0.5, 0.5, 0.5,
			-0.5, 0.5, 0.5 ];

			Giradas = [];
			PlanoX = [];
			PlanoY = [];
		}

		//Gira en X
		private void GiroX(double AnguloGrados) {
			double AnguloRadianes = AnguloGrados * Math.PI / 180;

			double[,] Matriz = new double[3, 3] {
				{1, 0, 0},
				{0, Math.Cos(AnguloRadianes), Math.Sin(AnguloRadianes)},
				{0, -Math.Sin(AnguloRadianes), Math.Cos(AnguloRadianes) }
			};

			AplicaMatrizGiro(Matriz);
		}

		//Gira en Y
		private void GiroY(double AnguloGrados) {
			double AnguloRadianes = AnguloGrados * Math.PI / 180;

			double[,] Matriz = new double[3, 3] {
				{Math.Cos(AnguloRadianes), 0, -Math.Sin(AnguloRadianes)},
				{0, 1, 0},
				{Math.Sin(AnguloRadianes), 0, Math.Cos(AnguloRadianes) }
			};

			AplicaMatrizGiro(Matriz);
		}

		//Gira en Z
		private void GiroZ(double AnguloGrados) {
			double AnguloRadianes = AnguloGrados * Math.PI / 180;

			double[,] Matriz = new double[3, 3] {
				{Math.Cos(AnguloRadianes), Math.Sin(AnguloRadianes), 0},
				{-Math.Sin(AnguloRadianes), Math.Cos(AnguloRadianes), 0},
				{0, 0, 1 }
			};

			AplicaMatrizGiro(Matriz);
		}

		private void AplicaMatrizGiro(double[,] Matriz) {
			Giradas.Clear();

			//Gira las 8 coordenadas
			for (int Contador = 0; Contador < Coordenadas.Count; Contador += 3) {
				//Extrae las coordenadas espaciales
				double X = Coordenadas[Contador];
				double Y = Coordenadas[Contador + 1];
				double Z = Coordenadas[Contador + 2];

				//Hace el giro
				double posXg = X * Matriz[0, 0] + Y * Matriz[1, 0] + Z * Matriz[2, 0];
				double posYg = X * Matriz[0, 1] + Y * Matriz[1, 1] + Z * Matriz[2, 1];
				double posZg = X * Matriz[0, 2] + Y * Matriz[1, 2] + Z * Matriz[2, 2];

				//Guarda en la lista de giro
				Giradas.Add(posXg);
				Giradas.Add(posYg);
				Giradas.Add(posZg);
			}
		}

		//Convierte de 3D a 2D las coordenadas giradas
		private void Convierte3Da2D(int ZPersona) {
			for (int Contador = 0; Contador < Giradas.Count; Contador += 3) {
				//Extrae las coordenadas espaciales
				double X = Giradas[Contador];
				double Y = Giradas[Contador + 1];
				double Z = Giradas[Contador + 2];

				//Convierte a coordenadas planas
				double Xp = ZPersona * X / (ZPersona - Z);
				double Yp = ZPersona * Y / (ZPersona - Z);

				//Agrega las coordenadas planas a la lista
				PlanoX.Add(Xp);
				PlanoY.Add(Yp);
			}
		}

		//Calcula los extremos de las coordenadas del cubo al girar y proyectarse
		public void CalculaExtremo(int ZPersona) {
			double maximoX = double.MinValue;
			double minimoX = double.MaxValue;
			double maximoY = double.MinValue;
			double minimoY = double.MaxValue;

			for (double angX = 0; angX <= 360; angX++) {
				GiroX(angX);
				Convierte3Da2D(ZPersona);
			}

			for (double angY = 0; angY <= 360; angY++) {
				GiroY(angY);
				Convierte3Da2D(ZPersona);
			}

			for (double angZ = 0; angZ <= 360; angZ++) {
				GiroZ(angZ);
				Convierte3Da2D(ZPersona);
			}

			for (int Contador = 0; Contador < PlanoX.Count; Contador++) {
				if (PlanoX[Contador] < minimoX) minimoX = PlanoX[Contador];
				if (PlanoX[Contador] > maximoX) maximoX = PlanoX[Contador];
				if (PlanoY[Contador] < minimoY) minimoY = PlanoY[Contador];
				if (PlanoY[Contador] > maximoY) maximoY = PlanoY[Contador];
			}

			Console.WriteLine("Extremos en X y Y (proyección a 2D del cubo)");
			Console.WriteLine("MinimoX: " + minimoX.ToString());
			Console.WriteLine("MaximoX: " + maximoX.ToString());
			Console.WriteLine("MinimoY: " + minimoY.ToString());
			Console.WriteLine("MaximoY: " + maximoY.ToString());
		}
	}


	class Program {
		static void Main() {
			Cubo Figura3D = new();
			Figura3D.CalculaExtremo(5);
		}
	}
}
