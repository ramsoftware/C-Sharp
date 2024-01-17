//Gráfico polar
namespace Graficos {
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
	
	
	public partial class Form1 : Form {
		List<Puntos> puntos;
		int XpantallaIni, YpantallaIni, XpantallaFin, YpantallaFin;

		public Form1() {
			InitializeComponent();
			puntos = new List<Puntos>();

			//Área dónde se dibujará el gráfico matemático
			XpantallaIni = 20;
			YpantallaIni = 20;
			XpantallaFin = 600;
			YpantallaFin = 400;

			//Algoritmo que calcula los puntos del gráfico
			double minTheta = 0;
			double maxTheta = 360;
			int numPuntos = 200;
			Logica(minTheta, maxTheta, numPuntos);
		}

		public void Logica(double thetaIni, double thetaFin, int numPuntos) {
			//Calcula los puntos de la ecuación a graficar
			double pasoTheta = (thetaFin - thetaIni) / numPuntos;
			double Ymin = double.MaxValue; //El mínimo valor de Y
			double Ymax = double.MinValue; //El máximo valor de Y
			double Xmin = double.MaxValue; //El máximo valor de X
			double Xmax = double.MinValue; //El máximo valor de X
			
			puntos.Clear();
			for (double theta = thetaIni; theta <= thetaFin; theta += pasoTheta) {
				double valorR = Ecuacion(theta);
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

		//Aquí está la ecuación polar que se desee graficar con variable Theta
		public double Ecuacion(double Theta) {
			return 2 * Math.Sin(4 * (Theta * Math.PI / 180));
		}

		//Pinta la ecuación
		private void Form1_Paint(object sender, PaintEventArgs e) {
			Graphics lienzo = e.Graphics;
			Pen lapiz = new Pen(Color.Blue, 3);

			//Un recuadro para ver el área del gráfico
			lienzo.FillRectangle(Brushes.Black, XpantallaIni, YpantallaIni, XpantallaFin-XpantallaIni, YpantallaFin-YpantallaIni);
			
			//Dibuja el gráfico matemático
			for (int cont = 0; cont < puntos.Count - 1; cont++) {
				lienzo.DrawLine(lapiz, puntos[cont].pantallaX, puntos[cont].pantallaY, puntos[cont + 1].pantallaX, puntos[cont + 1].pantallaY);
			}
		}
	}
}