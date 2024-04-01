//Gráfico matemático en 2D
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
			double maximoXreal = double.MinValue; //El máximo valor de X (difiere de Xfin)
			
			puntos.Clear();
			for (double X = Xini; X <= Xfin; X += pasoX) {
				double valY = -1*Ecuacion(X); //Se invierte el valor porque el eje Y aumenta hacia abajo
				if (valY > Ymax) Ymax = valY;
				if (valY < Ymin) Ymin = valY;
				if (X > maximoXreal) maximoXreal = X;
				puntos.Add(new Puntos(X, valY));
			}
			//¡OJO! X puede que no llegue a ser Xfin, por lo que la variable maximoXreal almacena el valor máximo de X

			//Calcula los puntos a poner en la pantalla
			double convierteX = (XpantallaFin - XpantallaIni) / (maximoXreal - Xini);
			double convierteY = (YpantallaFin - YpantallaIni) / (Ymax - Ymin);

			for (int cont = 0; cont < puntos.Count; cont++) {
				puntos[cont].pantallaX = Convert.ToInt32(convierteX * (puntos[cont].valorX - Xini) + XpantallaIni);
				puntos[cont].pantallaY = Convert.ToInt32(convierteY * (puntos[cont].valorY - Ymin) + YpantallaIni);
			}
		}

		//Aquí está la ecuación que se desee graficar con variable independiente X
		public double Ecuacion(double X) {
			return 0.1*Math.Pow(X,6)+0.6*Math.Pow(X,5)-0.7*Math.Pow(X,4)-5.7*Math.Pow(X,3)+2*X*X+2*X+1;
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