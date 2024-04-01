namespace Graficos {
	public partial class Form1 : Form {
		//El cubo que se proyecta y gira
		Cubo Figura3D;

		public Form1() {
			InitializeComponent();

			Figura3D = new Cubo();
			Figura3D.AplicaGiro(0, 0);
		}

		private void numGiroX_ValueChanged(object sender, EventArgs e) {
			numGiroY.Value = 0;
			numGiroZ.Value = 0;
			int AnguloX = Convert.ToInt32(numGiroX.Value);
			Figura3D.AplicaGiro(0, AnguloX);
			Refresh();
		}

		private void numGiroY_ValueChanged(object sender, EventArgs e) {
			numGiroX.Value = 0;
			numGiroZ.Value = 0;
			int AnguloY = Convert.ToInt32(numGiroY.Value);
			Figura3D.AplicaGiro(1, AnguloY);
			Refresh();
		}

		private void numGiroZ_ValueChanged(object sender, EventArgs e) {
			numGiroX.Value = 0;
			numGiroY.Value = 0;
			int AnguloZ = Convert.ToInt32(numGiroZ.Value);
			Figura3D.AplicaGiro(2, AnguloZ);
			Refresh();
		}

		private void Form1_Paint(object sender, PaintEventArgs e) {
			Graphics Lienzo = e.Graphics;
			Pen Lapiz = new(Color.Black, 2);

			int ZPersona = 180;
			Figura3D.Convierte3Da2D(ZPersona);
			Figura3D.CuadraPantalla(20, 20, 500, 500);
			Figura3D.Dibuja(Lienzo, Lapiz);
		}
	}

	internal class Cubo {
		//Un cubo tiene 8 coordenadas espaciales X, Y, Z
		private List<double> Coordenadas;

		//Un cubo tiene 8 coordenadas espaciales X, Y, Z que han sido giradas
		private List<double> Giradas;

		//Luego tiene 8 coordenadas planas
		private List<double> PlanoX;
		private List<double> PlanoY;

		//Luego tiene 8 coordenadas de pantalla
		private List<int> PantallaX;
		private List<int> PantallaY;


		//Constructor
		public Cubo() {
			//Ejemplo de coordenadas espaciales X,Y,Z
			Coordenadas = new List<double>() {
			-0.5, -0.5, -0.5,
			0.5, -0.5, -0.5,
			0.5, 0.5, -0.5,
			-0.5, 0.5, -0.5,
			-0.5, -0.5, 0.5,
			0.5, -0.5, 0.5,
			0.5, 0.5, 0.5,
			-0.5, 0.5, 0.5 };

			Giradas = [];
			PlanoX = [];
			PlanoY = [];
			PantallaX = [];
			PantallaY = [];
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
		public void Convierte3Da2D(int ZPersona) {
			PlanoX.Clear();
			PlanoY.Clear();

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

		//Convierte las coordenadas planas en coordenadas de pantalla
		public void CuadraPantalla(int XpantallaIni, int YpantallaIni, int XpantallaFin, int YpantallaFin) {
			//Los valores extremos de las coordenadas del cubo
			double maximoX = 0.785674201318386;
			double minimoX = -0.785674201318386;
			double maximoY = 0.785674201318386;
			double minimoY = -0.785674201318386;

			//Las constantes de transformación
			double convierteX = (XpantallaFin - XpantallaIni) / (maximoX - minimoX);
			double convierteY = (YpantallaFin - YpantallaIni) / (maximoY - minimoY);

			//Deduce las coordenadadas de pantalla
			PantallaX.Clear();
			PantallaY.Clear();
			for (int cont = 0; cont < PlanoX.Count; cont++) {
				int Xpantalla = Convert.ToInt32(convierteX * (PlanoX[cont] - minimoX) + XpantallaIni);
				int Ypantalla = Convert.ToInt32(convierteY * (PlanoY[cont] - minimoY) + YpantallaIni);
				PantallaX.Add(Xpantalla);
				PantallaY.Add(Ypantalla);
			}
		}


		//Dibuja el cubo
		public void Dibuja(Graphics lienzo, Pen lapiz) {
			lienzo.DrawLine(lapiz, PantallaX[0], PantallaY[0], PantallaX[1], PantallaY[1]);
			lienzo.DrawLine(lapiz, PantallaX[1], PantallaY[1], PantallaX[2], PantallaY[2]);
			lienzo.DrawLine(lapiz, PantallaX[2], PantallaY[2], PantallaX[3], PantallaY[3]);
			lienzo.DrawLine(lapiz, PantallaX[3], PantallaY[3], PantallaX[0], PantallaY[0]);

			lienzo.DrawLine(lapiz, PantallaX[4], PantallaY[4], PantallaX[5], PantallaY[5]);
			lienzo.DrawLine(lapiz, PantallaX[5], PantallaY[5], PantallaX[6], PantallaY[6]);
			lienzo.DrawLine(lapiz, PantallaX[6], PantallaY[6], PantallaX[7], PantallaY[7]);
			lienzo.DrawLine(lapiz, PantallaX[7], PantallaY[7], PantallaX[4], PantallaY[4]);

			lienzo.DrawLine(lapiz, PantallaX[0], PantallaY[0], PantallaX[4], PantallaY[4]);
			lienzo.DrawLine(lapiz, PantallaX[1], PantallaY[1], PantallaX[5], PantallaY[5]);
			lienzo.DrawLine(lapiz, PantallaX[2], PantallaY[2], PantallaX[6], PantallaY[6]);
			lienzo.DrawLine(lapiz, PantallaX[3], PantallaY[3], PantallaX[7], PantallaY[7]);
		}
	}

}
