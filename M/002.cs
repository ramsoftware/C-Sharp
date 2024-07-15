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
			Pen Lapiz = new(Color.Blue, 3);

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
		//Un cubo tiene 8 puntos con
		//coordenadas espaciales X, Y, Z
		private List<int> Punto;

		//Un cubo tiene 8 coordenadas
		//espaciales X, Y, Z que han sido giradas
		private List<double> Giradas;

		//Luego tiene 8 coordenadas planas
		private List<int> pX;
		private List<int> pY;

		//Constructor
		public Cubo() {
			//Ejemplo de coordenadas
			//espaciales X,Y,Z
			Punto = [
			50, 50, 50,
			100, 50, 50,
			100, 100, 50,
			50, 100, 50,
			50, 50, 100,
			100, 50, 100,
			100, 100, 100,
			50, 100, 100 ];

			Giradas = [];
			pX = [];
			pY = [];
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

		private void AplicaMatrizGiro(double[,] Mt) {
			Giradas.Clear();

			//Gira las 8 coordenadas
			for (int Cont = 0; Cont < Punto.Count; Cont += 3) {
				//Extrae las coordenadas espaciales
				int X = Punto[Cont];
				int Y = Punto[Cont + 1];
				int Z = Punto[Cont + 2];

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
		public void Convierte3Da2D(int ZPersona) {
			pX.Clear();
			pY.Clear();

			for (int cont = 0; cont < Giradas.Count; cont += 3) {
				//Extrae las coordenadas espaciales
				double X = Giradas[cont];
				double Y = Giradas[cont + 1];
				double Z = Giradas[cont + 2];

				//Convierte a coordenadas planas
				int Xp = Convert.ToInt32(ZPersona * X / (ZPersona - Z));
				int Yp = Convert.ToInt32(ZPersona * Y / (ZPersona - Z));

				//Agrega las coordenadas planas a la lista
				pX.Add(Xp);
				pY.Add(Yp);
			}
		}

		//Dibuja el cubo
		public void Dibuja(Graphics lienzo, Pen lapiz) {
			lienzo.DrawLine(lapiz, pX[0], pY[0], pX[1], pY[1]);
			lienzo.DrawLine(lapiz, pX[1], pY[1], pX[2], pY[2]);
			lienzo.DrawLine(lapiz, pX[2], pY[2], pX[3], pY[3]);
			lienzo.DrawLine(lapiz, pX[3], pY[3], pX[0], pY[0]);

			lienzo.DrawLine(lapiz, pX[4], pY[4], pX[5], pY[5]);
			lienzo.DrawLine(lapiz, pX[5], pY[5], pX[6], pY[6]);
			lienzo.DrawLine(lapiz, pX[6], pY[6], pX[7], pY[7]);
			lienzo.DrawLine(lapiz, pX[7], pY[7], pX[4], pY[4]);

			lienzo.DrawLine(lapiz, pX[0], pY[0], pX[4], pY[4]);
			lienzo.DrawLine(lapiz, pX[1], pY[1], pX[5], pY[5]);
			lienzo.DrawLine(lapiz, pX[2], pY[2], pX[6], pY[6]);
			lienzo.DrawLine(lapiz, pX[3], pY[3], pX[7], pY[7]);
		}
	}
}