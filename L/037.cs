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
			double minX = -5;
			double maxX = 3;
			int numPuntos = 80;
			Logica(minX, maxX, numPuntos);
		}

		public void Logica(double Xini, double Xfin, int numPuntos) {
			//Calcula los puntos de la ecuación a graficar
			double pasoX = (Xfin - Xini) / numPuntos;
			double Ymin = double.MaxValue; //El mínimo valor de Y obtenido
			double Ymax = double.MinValue; //El máximo valor de Y obtenido

			//El máximo valor de X (difiere de Xfin)
			double maximoXreal = double.MinValue;

			punto.Clear();
			for (double X = Xini; X <= Xfin; X += pasoX) {
				//Se invierte el valor porque el eje Y
				//aumenta hacia abajo
				double valY = -1 * Ecuacion(X);
				if (valY > Ymax) Ymax = valY;
				if (valY < Ymin) Ymin = valY;
				if (X > maximoXreal) maximoXreal = X;
				punto.Add(new Puntos(X, valY));
			}
			//¡OJO! X puede que no llegue a ser Xfin,
			//por lo que la variable maximoXreal almacena
			//el valor máximo de X

			//Calcula los puntos a poner en la pantalla
			double conX = (XpFin - XpIni) / (maximoXreal - Xini);
			double conY = (YpFin - YpIni) / (Ymax - Ymin);

			for (int cont = 0; cont < punto.Count; cont++) {
				double pX = conX * (punto[cont].X - Xini) + XpIni;
				double pY = conY * (punto[cont].Y - Ymin) + YpIni;
				punto[cont].pX = Convert.ToInt32(pX);
				punto[cont].pY = Convert.ToInt32(pY);
			}
		}

		//Aquí está la ecuación que se desee graficar
		//con variable independiente X
		public double Ecuacion(double X) {
			double Y = 0.1 * Math.Pow(X, 6) + 0.6 * Math.Pow(X, 5);
			Y -= 0.7 * Math.Pow(X, 4) - 5.7 * Math.Pow(X, 3);
			Y += 2 * X * X + 2 * X + 1;
			return Y;
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