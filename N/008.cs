namespace Animacion {
	public partial class Form1 : Form {
		//Para la variable temporal
		private double TiempoValor, Tminimo, Tmaximo, Tincrementa;

		//Datos de la ecuación (desde donde inicia y termina Theta)
		double minTheta;
		double maxTheta;
		int numPuntos;

		//Donde almacena los puntos
		List<Puntos> punto;

		//Datos de la pantalla
		int XpIni, YpIni, XpFin, YpFin;

		public Form1() {
			InitializeComponent();
			punto = [];

			//Área dónde se dibujará el gráfico matemático
			XpIni = 20;
			YpIni = 20;
			XpFin = 700;
			YpFin = 500;

			//Inicia el tiempo
			Tminimo = 0;
			Tmaximo = 5;
			Tincrementa = 0.05;
			TiempoValor = Tminimo;

			//Datos de la ecuación
			minTheta = 0;
			maxTheta = 360;
			numPuntos = 200;
		}

		private void timer1_Tick(object sender, EventArgs e) {
			TiempoValor += Tincrementa;
			if (TiempoValor <= Tminimo || TiempoValor >= Tmaximo)
				Tincrementa = -Tincrementa;

			Logica();
			Refresh();
		}

		public void Logica() {
			//Calcula los puntos de la ecuación a graficar
			double paso = (maxTheta - minTheta) / numPuntos;
			double Ymin = double.MaxValue; //El mínimo valor de Y
			double Ymax = double.MinValue; //El máximo valor de Y
			double Xmin = double.MaxValue; //El máximo valor de X
			double Xmax = double.MinValue; //El máximo valor de X

			punto.Clear();
			for (double theta = minTheta; theta <= maxTheta; theta += paso) {
				double valorR = Ecuacion(theta, TiempoValor);
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
				double Xr = conX * (punto[cont].X - Xmin) + XpIni;
				double Yr = conY * (punto[cont].Y - Ymin) + YpIni;
				punto[cont].pX = Convert.ToInt32(Xr);
				punto[cont].pY = Convert.ToInt32(Yr);
			}
		}

		//Aquí está la ecuación que se desee graficar
		//con variable Theta y T (tiempo)
		public double Ecuacion(double Theta, double T) {
			return 2 * (1 + Math.Sin(Theta * T * Math.PI / 180));
		}

		//Pinta la ecuación
		private void Form1_Paint(object sender, PaintEventArgs e) {
			Graphics lienzo = e.Graphics;
			Pen lapiz = new(Color.Blue, 1);

			//Un recuadro para ver el área del gráfico
			int Xini = XpIni;
			int Yini = YpIni;
			int Xfin = XpFin - XpIni;
			int Yfin = YpFin - YpIni;
			lienzo.DrawRectangle(lapiz, Xini, Yini, Xfin, Yfin);

			//Dibuja el gráfico matemático
			for (int cont = 0; cont < punto.Count - 1; cont++) {
				Xini = punto[cont].pX;
				Yini = punto[cont].pY;
				Xfin = punto[cont + 1].pX;
				Yfin = punto[cont + 1].pY;
				lienzo.DrawLine(Pens.Black, Xini, Yini, Xfin, Yfin);
			}
		}
	}

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
}
