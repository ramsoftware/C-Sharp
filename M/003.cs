namespace Ejemplo {

	internal class Cubo {
		//Un cubo tiene 8 coordenadas
		//espaciales X, Y, Z
		private List<double> Coordenadas;

		//Se convierten en 8 coordenadas
		//espaciales X, Y, Z al girarse
		private List<double> Giradas;

		//Luego tiene 8 coordenadas planas
		private List<double> PlanoX;
		private List<double> PlanoY;

		//Constructor
		public Cubo() {
			//Coordenadas espaciales X,Y,Z
			//para hacer el cubo
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
			double Radianes = AnguloGrados * Math.PI / 180;

			double[,] Matriz = new double[3, 3] {
				{1, 0, 0},
				{0, Math.Cos(Radianes), Math.Sin(Radianes)},
				{0, -Math.Sin(Radianes), Math.Cos(Radianes) }
			};

			AplicaMatrizGiro(Matriz);
		}

		//Gira en Y
		private void GiroY(double AnguloGrados) {
			double Radianes = AnguloGrados * Math.PI / 180;

			double[,] Matriz = new double[3, 3] {
				{Math.Cos(Radianes), 0, -Math.Sin(Radianes)},
				{0, 1, 0},
				{Math.Sin(Radianes), 0, Math.Cos(Radianes) }
			};

			AplicaMatrizGiro(Matriz);
		}

		//Gira en Z
		private void GiroZ(double AnguloGrados) {
			double Radianes = AnguloGrados * Math.PI / 180;

			double[,] Matriz = new double[3, 3] {
				{Math.Cos(Radianes), Math.Sin(Radianes), 0},
				{-Math.Sin(Radianes), Math.Cos(Radianes), 0},
				{0, 0, 1 }
			};

			AplicaMatrizGiro(Matriz);
		}

		private void AplicaMatrizGiro(double[,] Mt) {
			Giradas.Clear();

			//Gira las 8 coordenadas
			for (int cont = 0; cont < Coordenadas.Count; cont += 3) {
				//Extrae las coordenadas espaciales
				double X = Coordenadas[cont];
				double Y = Coordenadas[cont + 1];
				double Z = Coordenadas[cont + 2];

				//Hace el giro
				double Xg = X * Mt[0, 0] + Y * Mt[1, 0] + Z * Mt[2, 0];
				double Yg = X * Mt[0, 1] + Y * Mt[1, 1] + Z * Mt[2, 1];
				double Zg = X * Mt[0, 2] + Y * Mt[1, 2] + Z * Mt[2, 2];

				//Guarda en la lista de giro
				Giradas.Add(Xg);
				Giradas.Add(Yg);
				Giradas.Add(Zg);
			}
		}

		//Convierte de 3D a 2D las coordenadas giradas
		private void Convierte3Da2D(int ZPersona) {
			for (int cont = 0; cont < Giradas.Count; cont += 3) {
				//Extrae las coordenadas espaciales
				double X = Giradas[cont];
				double Y = Giradas[cont + 1];
				double Z = Giradas[cont + 2];

				//Convierte a coordenadas planas
				double Xp = ZPersona * X / (ZPersona - Z);
				double Yp = ZPersona * Y / (ZPersona - Z);

				//Agrega las coordenadas planas a la lista
				PlanoX.Add(Xp);
				PlanoY.Add(Yp);
			}
		}

		//Calcula los extremos de las coordenadas
		//del cubo al girar y proyectarse
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

			for (int cont = 0; cont < PlanoX.Count; cont++) {
				if (PlanoX[cont] < minimoX) minimoX = PlanoX[cont];
				if (PlanoX[cont] > maximoX) maximoX = PlanoX[cont];
				if (PlanoY[cont] < minimoY) minimoY = PlanoY[cont];
				if (PlanoY[cont] > maximoY) maximoY = PlanoY[cont];
			}

			Console.WriteLine("Proyección a 2D del cubo");
			Console.WriteLine("MinimoX: " + minimoX);
			Console.WriteLine("MaximoX: " + maximoX);
			Console.WriteLine("MinimoY: " + minimoY);
			Console.WriteLine("MaximoY: " + maximoY);
		}
	}


	class Program {
		static void Main() {
			Cubo Figura3D = new();
			Figura3D.CalculaExtremo(5);
		}
	}
}