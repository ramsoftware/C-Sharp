namespace Animacion {
	public partial class Form1 : Form {
		//Para la variable temporal
		private double TiempoValor, Tminimo, Tmaximo, Tincrementa;

		//Datos de la ecuación (desde donde inicia y termina Theta)
		double minTheta;
		double maxTheta;
		int numPuntos;

		//Donde almacena los puntos
		List<Puntos> puntos;

		//Datos de la pantalla
		int XpantallaIni, YpantallaIni, XpantallaFin, YpantallaFin;

		public Form1() {
			InitializeComponent();
			puntos = [];

			//Área dónde se dibujará el gráfico matemático
			XpantallaIni = 20;
			YpantallaIni = 20;
			XpantallaFin = 700;
			YpantallaFin = 500;

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
			if (TiempoValor <= Tminimo || TiempoValor >= Tmaximo) Tincrementa = -Tincrementa;
			Logica(minTheta, maxTheta, numPuntos, TiempoValor);
			Refresh();
		}

		public void Logica(double thetaIni, double thetaFin, int numPuntos, double Tiempo) {
			//Calcula los puntos de la ecuación a graficar
			double pasoTheta = (thetaFin - thetaIni) / numPuntos;
			double Ymin = double.MaxValue; //El mínimo valor de Y
			double Ymax = double.MinValue; //El máximo valor de Y
			double Xmin = double.MaxValue; //El máximo valor de X
			double Xmax = double.MinValue; //El máximo valor de X

			puntos.Clear();
			for (double theta = thetaIni; theta <= thetaFin; theta += pasoTheta) {
				double valorR = Ecuacion(theta, Tiempo);
				double X = valorR * Math.Cos(theta * Math.PI / 180);
				double Y = -1 * valorR * Math.Sin(theta * Math.PI / 180);

				if (Y > Ymax) Ymax = Y;
				if (Y < Ymin) Ymin = Y;
				if (X > Xmax) Xmax = X;
				if (X < Xmin) Xmin = X;
				puntos.Add(new Puntos(X, Y));
			}

			//Calcula los puntos a poner en la pantalla
			double convierteX = (XpantallaFin - XpantallaIni) / (Xmax - Xmin);
			double convierteY = (YpantallaFin - YpantallaIni) / (Ymax - Ymin);

			for (int cont = 0; cont < puntos.Count; cont++) {
				puntos[cont].pantallaX = Convert.ToInt32(convierteX * (puntos[cont].valorX - Xmin) + XpantallaIni);
				puntos[cont].pantallaY = Convert.ToInt32(convierteY * (puntos[cont].valorY - Ymin) + YpantallaIni);
			}
		}

		//Aquí está la ecuación que se desee graficar con variable Theta y T (tiempo)
		public double Ecuacion(double Theta, double T) {
			return 2 * (1 + Math.Sin(Theta * T * Math.PI / 180));
		}

		//Pinta la ecuación
		private void Form1_Paint(object sender, PaintEventArgs e) {
			Graphics lienzo = e.Graphics;
			Pen lapiz = new(Color.Blue, 3);

			//Un recuadro para ver el área del gráfico
			lienzo.FillRectangle(Brushes.Black, XpantallaIni, YpantallaIni, XpantallaFin - XpantallaIni, YpantallaFin - YpantallaIni);

			//Dibuja el gráfico matemático
			for (int cont = 0; cont < puntos.Count - 1; cont++) {
				lienzo.DrawLine(lapiz, puntos[cont].pantallaX, puntos[cont].pantallaY, puntos[cont + 1].pantallaX, puntos[cont + 1].pantallaY);
			}
		}
	}

	internal class Puntos {
		//Valor X, Y reales de la ecuación
		public double valorX, valorY;

		//Puntos convertidos a coordenadas enteras de pantalla
		public int pantallaX, pantallaY;

		public Puntos(double valorX, double valorY) {
			this.valorX = valorX;
			this.valorY = valorY;
		}
	}
}
