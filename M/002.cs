namespace Graficos {

	public partial class Form1 : Form {
		//El cubo que se proyecta y gira
		Cubo Figura3D;

		public Form1() {
			InitializeComponent();
			Figura3D = new Cubo();
			Figura3D.AplicaGiro(0, 0);
		}

		private void Form1_Paint(object sender, PaintEventArgs e) {
			Graphics Lienzo = e.Graphics;
			Pen Lapiz = new Pen(Color.Blue, 3);

			int ZPersona = 180;
			Figura3D.Convierte3Da2D(ZPersona);
			Figura3D.Dibuja(Lienzo, Lapiz);
		}

		private void numGiroX_ValueChanged(object sender, EventArgs e) {
			//Se anulan los dos valores de los otros ángulos
			numGiroY.Value = 0;
			numGiroZ.Value = 0;

			//Sólo puede girar en un ángulo
			int AnguloX = Convert.ToInt32(numGiroX.Value);
			Figura3D.AplicaGiro(0, AnguloX); //O es giro en X
			Refresh();
		}

		private void numGiroY_ValueChanged(object sender, EventArgs e) {
			numGiroX.Value = 0;
			numGiroZ.Value = 0;
			int AnguloY = Convert.ToInt32(numGiroY.Value);
			Figura3D.AplicaGiro(1, AnguloY); //1 es giro en Y
			Refresh();
		}

		private void numGiroZ_ValueChanged(object sender, EventArgs e) {
			numGiroX.Value = 0;
			numGiroY.Value = 0;
			int AnguloZ = Convert.ToInt32(numGiroZ.Value);
			Figura3D.AplicaGiro(2, AnguloZ); //2 es giro en Z
			Refresh();
		}
	}

	internal class Cubo {
		//Un cubo tiene 8 coordenadas espaciales X, Y, Z
		private List<int> Coordenadas;

		//Un cubo tiene 8 coordenadas espaciales X, Y, Z que han sido giradas
		private List<double> Giradas;

		//Luego tiene 8 coordenadas planas
		private List<int> PlanoX;
		private List<int> PlanoY;

		//Constructor
		public Cubo() {
			//Ejemplo de coordenadas espaciales X,Y,Z
			Coordenadas = [
			50, 50, 50,
			100, 50, 50,
			100, 100, 50,
			50, 100, 50,
			50, 50, 100,
			100, 50, 100,
			100, 100, 100,
			50, 100, 100 ];

			Giradas = [];
			PlanoX = [];
			PlanoY = [];
		}

		public void AplicaGiro(int CualAnguloGira, int ValorAngulo) {
			//Dependiendo de cuál ángulo gira
			switch (CualAnguloGira) {
				case 0: GiroX(ValorAngulo); break;
				case 1: GiroY(ValorAngulo); break;
				case 2: GiroZ(ValorAngulo); break;
			}
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
				int X = Coordenadas[Contador];
				int Y = Coordenadas[Contador + 1];
				int Z = Coordenadas[Contador + 2];

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
		public void Convierte3Da2D(int ZPersona) {
			PlanoX.Clear();
			PlanoY.Clear();

			for (int cont = 0; cont < Giradas.Count; cont += 3) {
				//Extrae las coordenadas espaciales
				double X = Giradas[cont];
				double Y = Giradas[cont + 1];
				double Z = Giradas[cont + 2];

				//Convierte a coordenadas planas
				int Xp = Convert.ToInt32(ZPersona * X / (ZPersona - Z));
				int Yp = Convert.ToInt32(ZPersona * Y / (ZPersona - Z));

				//Agrega las coordenadas planas a la lista
				PlanoX.Add(Xp);
				PlanoY.Add(Yp);
			}
		}

		//Dibuja el cubo
		public void Dibuja(Graphics lienzo, Pen lapiz) {
			lienzo.DrawLine(lapiz, PlanoX[0], PlanoY[0], PlanoX[1], PlanoY[1]);
			lienzo.DrawLine(lapiz, PlanoX[1], PlanoY[1], PlanoX[2], PlanoY[2]);
			lienzo.DrawLine(lapiz, PlanoX[2], PlanoY[2], PlanoX[3], PlanoY[3]);
			lienzo.DrawLine(lapiz, PlanoX[3], PlanoY[3], PlanoX[0], PlanoY[0]);

			lienzo.DrawLine(lapiz, PlanoX[4], PlanoY[4], PlanoX[5], PlanoY[5]);
			lienzo.DrawLine(lapiz, PlanoX[5], PlanoY[5], PlanoX[6], PlanoY[6]);
			lienzo.DrawLine(lapiz, PlanoX[6], PlanoY[6], PlanoX[7], PlanoY[7]);
			lienzo.DrawLine(lapiz, PlanoX[7], PlanoY[7], PlanoX[4], PlanoY[4]);

			lienzo.DrawLine(lapiz, PlanoX[0], PlanoY[0], PlanoX[4], PlanoY[4]);
			lienzo.DrawLine(lapiz, PlanoX[1], PlanoY[1], PlanoX[5], PlanoY[5]);
			lienzo.DrawLine(lapiz, PlanoX[2], PlanoY[2], PlanoX[6], PlanoY[6]);
			lienzo.DrawLine(lapiz, PlanoX[3], PlanoY[3], PlanoX[7], PlanoY[7]);
		}

	}
}