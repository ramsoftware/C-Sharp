namespace Graficos {
	internal class Puntos {
		//Valor X, Y reales de la ecuación
		public double X, Y;

		//Puntos convertidos a coordenadas enteras de pantalla
		public int pX, pY;

		public Puntos(double X, double Y) {
			this.X = X;
			this.Y = Y;
		}
	}

	public partial class Form1 : Form {
		List<Puntos> punto;
		int XpIni, YpIni, XpFin, YpFin;

		public Form1() {
			InitializeComponent();
			punto = [];

			//Área dónde se dibujará el gráfico matemático
			XpIni = 20;
			YpIni = 20;
			XpFin = 600;
			YpFin = 400;

			//Algoritmo que calcula los puntos del gráfico
			double minTheta = 0;
			double maxTheta = 360;
			int numPuntos = 200;
			Logica(minTheta, maxTheta, numPuntos);
		}

		public void Logica(double thIni, double thFin, int numPuntos) {
			//Calcula los puntos de la ecuación a graficar
			double pasoT = (thFin - thIni) / numPuntos;
			double Ymin = double.MaxValue; //El mínimo valor de Y
			double Ymax = double.MinValue; //El máximo valor de Y
			double Xmin = double.MaxValue; //El máximo valor de X
			double Xmax = double.MinValue; //El máximo valor de X

			punto.Clear();
			for (double theta = thIni; theta <= thFin; theta += pasoT) {
				double valorR = Ecuacion(theta);
				double X = valorR * Math.Cos(theta * Math.PI / 180);
				double Y = -1 * valorR * Math.Sin(theta * Math.PI / 180);

				if (Y > Ymax) Ymax = Y;
				if (Y < Ymin) Ymin = Y;
				if (X > Xmax) Xmax = X;
				if (X < Xmin) Xmin = X;
				punto.Add(new Puntos(X, Y));
			}

			//Calcula los puntos a poner en la pantalla
			double conX = (XpFin - XpIni) / (Xmax - Xmin);
			double conY = (YpFin - YpIni) / (Ymax - Ymin);

			for (int cont = 0; cont < punto.Count; cont++) {
				double pX = conX * (punto[cont].X - Xmin) + XpIni;
				double pY = conY * (punto[cont].Y - Ymin) + YpIni;
				punto[cont].pX = Convert.ToInt32(pX);
				punto[cont].pY = Convert.ToInt32(pY);
			}
		}

		//Aquí está la ecuación polar que se desee
		//graficar con variable Theta
		public double Ecuacion(double Theta) {
			return 2 * Math.Sin(4 * (Theta * Math.PI / 180));
		}

		//Pinta la ecuación
		private void Form1_Paint(object sender, PaintEventArgs e) {
			Graphics lienzo = e.Graphics;
			Pen lapiz = new(Color.Blue, 3);
			Brush llena = new SolidBrush(Color.Black);

			//Un recuadro para ver el área del gráfico
			int Xini = XpIni;
			int Yini = YpIni;
			int Xfin = XpFin - XpIni;
			int Yfin = YpFin - YpIni;
			lienzo.FillRectangle(llena, Xini, Yini, Xfin, Yfin);

			//Dibuja el gráfico matemático
			for (int cont = 0; cont < punto.Count - 1; cont++) {
				Xini = punto[cont].pX;
				Yini = punto[cont].pY;
				Xfin = punto[cont + 1].pX;
				Yfin = punto[cont + 1].pY;
				lienzo.DrawLine(lapiz, Xini, Yini, Xfin, Yfin);
			}
		}
	}
}