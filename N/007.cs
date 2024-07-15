namespace Animacion {
	public partial class Form1 : Form {
		//Para la variable temporal
		private double TiempoValor, Tminimo, Tmaximo, Tincrementa;

		//Datos de la ecuación (desde donde inicia y termina X)
		double minX;
		double maxX;
		int totalPuntos;

		//Donde almacena los puntos
		List<PuntosGrafico> punto;

		//Datos de la pantalla
		int XpIni, YpIni, XpFin, YpFin;

		private void timer1_Tick(object sender, EventArgs e) {
			TiempoValor += Tincrementa;
			if (TiempoValor <= Tminimo || TiempoValor >= Tmaximo)
				Tincrementa = -Tincrementa;

			Logica();
			Refresh();
		}

		public Form1() {
			InitializeComponent();
			punto = new List<PuntosGrafico>();

			//Área dónde se dibujará el gráfico matemático
			XpIni = 20;
			YpIni = 20;
			XpFin = 700;
			YpFin = 500;

			//Inicia el tiempo
			Tminimo = 0;
			Tmaximo = 2;
			Tincrementa = 0.05;
			TiempoValor = Tminimo;

			//Datos de la ecuación
			minX = -5; //Valor X mínimo
			maxX = 5; //Valor X máximo
			totalPuntos = 300;
		}

		public void Logica() {
			//Calcula los puntos de la ecuación a graficar
			double pasoX = (maxX - minX) / totalPuntos;
			double Ymin = double.MaxValue; //El mínimo valor de Y obtenido
			double Ymax = double.MinValue; //El máximo valor de Y obtenido
			double maximoXreal = double.MinValue; //El máximo valor de X

			punto.Clear();
			for (double X = minX; X <= maxX; X += pasoX) {
				//Se invierte el valor porque el eje Y aumenta hacia abajo
				double valY = -1 * Ecuacion(X, TiempoValor);
				if (valY > Ymax) Ymax = valY;
				if (valY < Ymin) Ymin = valY;
				if (X > maximoXreal) maximoXreal = X;
				punto.Add(new PuntosGrafico(X, valY));
			}
			//¡OJO! X puede que no llegue a ser Xfin, por lo que
			//la variable maximoXreal almacena el valor máximo de X

			//Calcula los puntos a poner en la pantalla
			double conX = (XpFin - XpIni) / (maximoXreal - minX);
			double conY = (YpFin - YpIni) / (Ymax - Ymin);

			for (int cont = 0; cont < punto.Count; cont++) {
				double Xr = conX * (punto[cont].X - minX) + XpIni;
				double Yr = conY * (punto[cont].Y - Ymin) + YpIni;
				punto[cont].pX = Convert.ToInt32(Xr);
				punto[cont].pY = Convert.ToInt32(Yr);
			}
		}

		//Aquí está la ecuación que se desee graficar con variable
		//independiente X y T
		public double Ecuacion(double X, double T) {
			return X * (T + 1) * Math.Sin(X * X * T * T);
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

	internal class PuntosGrafico {
		//Valor X, Y reales de la ecuación
		public double X, Y;

		//Puntos convertidos a coordenadas enteras de pantalla
		public int pX, pY;

		public PuntosGrafico(double X, double Y) {
			this.X = X;
			this.Y = Y;
		}
	}
}