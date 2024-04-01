namespace Animacion {
	public partial class Form1 : Form {
		//Para la variable temporal
		private double TiempoValor, Tminimo, Tmaximo, Tincrementa;

		//Datos de la ecuación (desde donde inicia y termina X)
		double minX;
		double maxX;
		int numPuntos;

		//Donde almacena los puntos
		List<Puntos> puntos;

		//Datos de la pantalla
		int XpantallaIni, YpantallaIni, XpantallaFin, YpantallaFin;

		private void timer1_Tick(object sender, EventArgs e) {
			TiempoValor += Tincrementa;
			if (TiempoValor <= Tminimo || TiempoValor >= Tmaximo) Tincrementa = -Tincrementa;
			Logica(minX, maxX, numPuntos, TiempoValor);
			Refresh();
		}

		public Form1() {
			InitializeComponent();
			puntos = new List<Puntos>();

			//Área dónde se dibujará el gráfico matemático
			XpantallaIni = 20;
			YpantallaIni = 20;
			XpantallaFin = 700;
			YpantallaFin = 500;

			//Inicia el tiempo
			Tminimo = 0;
			Tmaximo = 2;
			Tincrementa = 0.05;
			TiempoValor = Tminimo;

			//Datos de la ecuación
			minX = -5;
			maxX = 3;
			numPuntos = 200;
		}

		public void Logica(double Xini, double Xfin, int numPuntos, double Tiempo) {
			//Calcula los puntos de la ecuación a graficar
			double pasoX = (Xfin - Xini) / numPuntos;
			double Ymin = double.MaxValue; //El mínimo valor de Y obtenido
			double Ymax = double.MinValue; //El máximo valor de Y obtenido
			double maximoXreal = double.MinValue; //El máximo valor de X (difiere de Xfin)

			puntos.Clear();
			for (double X = Xini; X <= Xfin; X += pasoX) {
				double valY = -1 * Ecuacion(X, Tiempo); //Se invierte el valor porque el eje Y aumenta hacia abajo
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

		//Aquí está la ecuación que se desee graficar con variable independiente X y T
		public double Ecuacion(double X, double T) {
			return X * (T + 1) * Math.Sin(X * X * T * T);
		}

		//Pinta la ecuación
		private void Form1_Paint(object sender, PaintEventArgs e) {
			//Un recuadro para ver el área del gráfico
			e.Graphics.DrawRectangle(Pens.Blue, XpantallaIni, YpantallaIni, XpantallaFin - XpantallaIni, YpantallaFin - YpantallaIni);

			//Dibuja el gráfico matemático
			for (int cont = 0; cont < puntos.Count - 1; cont++) {
				e.Graphics.DrawLine(Pens.Black, puntos[cont].pantallaX, puntos[cont].pantallaY, puntos[cont + 1].pantallaX, puntos[cont + 1].pantallaY);
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