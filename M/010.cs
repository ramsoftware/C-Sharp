namespace Graficos {

	public partial class Form1 : Form {
		//El objeto que se encarga de calcular y cuadrar en pantalla la ecuaci�n que genera el s�lido de revoluci�n
		Grafico Grafico3D;

		public Form1() {
			InitializeComponent();
			Grafico3D = new Grafico();

			double MinXreal = 0;
			double MaxXreal = 180;
			int NumeroLineasGrafico = 40;
			Grafico3D.CalculaEcuacion(MinXreal, MaxXreal, NumeroLineasGrafico);
		}

		private void numGiroX_ValueChanged(object sender, EventArgs e) {
			Refresh();
		}

		private void numGiroY_ValueChanged(object sender, EventArgs e) {
			Refresh();
		}

		private void numGiroZ_ValueChanged(object sender, EventArgs e) {
			Refresh();
		}

		//Pinta el gr�fico generado por la ecuaci�n
		private void Form1_Paint(object sender, PaintEventArgs e) {
			Graphics Lienzo = e.Graphics;
			Pen Lapiz = new(Color.Black, 1);
			Brush Relleno = new SolidBrush(Color.White);

			int AnguloX = Convert.ToInt32(numGiroX.Value);
			int AnguloY = Convert.ToInt32(numGiroY.Value);
			int AnguloZ = Convert.ToInt32(numGiroZ.Value);

			//Extremos de la ventana para dibujar
			int ZPersona = 5;
			int XPantallaIni = 0;
			int YPantallaIni = 0;
			int XPantallaFin = 800;
			int YPantallaFin = 800;

			//Despu�s de los c�lculos, entonces aplica giros, conversi�n a 2D y cuadrar en pantalla
			Grafico3D.CalculaGrafico(AnguloX, AnguloY, AnguloZ, ZPersona, XPantallaIni, YPantallaIni, XPantallaFin, YPantallaFin);
			Grafico3D.Dibuja(Lienzo, Lapiz, Relleno);
		}
	}

	internal class Poligono : IComparable {
		//Un pol�gono son cuatro(4) coordenadas espaciales
		public double X1, Y1, Z1, X2, Y2, Z2, X3, Y3, Z3, X4, Y4, Z4;

		//Las coordenadas en pantalla
		public int X1p, Y1p, X2p, Y2p, X3p, Y3p, X4p, Y4p;

		//Centro del pol�gono
		public double Centro;

		public Poligono(double X1, double Y1, double Z1, double X2, double Y2, double Z2, double X3, double Y3, double Z3, double X4, double Y4, double Z4) {
			this.X1 = X1; this.Y1 = Y1; this.Z1 = Z1;
			this.X2 = X2; this.Y2 = Y2; this.Z2 = Z2;
			this.X3 = X3; this.Y3 = Y3; this.Z3 = Z3;
			this.X4 = X4; this.Y4 = Y4; this.Z4 = Z4;
		}

		//Normaliza puntos pol�gono entre -0.5 y 0.5
		public void Normaliza(double MinimoX, double MinimoY, double MinimoZ, double MaximoX, double MaximoY, double MaximoZ) {
			X1 = (X1 - MinimoX) / (MaximoX - MinimoX) - 0.5;
			Y1 = (Y1 - MinimoY) / (MaximoY - MinimoY) - 0.5;
			Z1 = (Z1 - MinimoZ) / (MaximoZ - MinimoZ) - 0.5;

			X2 = (X2 - MinimoX) / (MaximoX - MinimoX) - 0.5;
			Y2 = (Y2 - MinimoY) / (MaximoY - MinimoY) - 0.5;
			Z2 = (Z2 - MinimoZ) / (MaximoZ - MinimoZ) - 0.5;

			X3 = (X3 - MinimoX) / (MaximoX - MinimoX) - 0.5;
			Y3 = (Y3 - MinimoY) / (MaximoY - MinimoY) - 0.5;
			Z3 = (Z3 - MinimoZ) / (MaximoZ - MinimoZ) - 0.5;

			X4 = (X4 - MinimoX) / (MaximoX - MinimoX) - 0.5;
			Y4 = (Y4 - MinimoY) / (MaximoY - MinimoY) - 0.5;
			Z4 = (Z4 - MinimoZ) / (MaximoZ - MinimoZ) - 0.5;
		}


		//Gira en XYZ, convierte a 2D y cuadra en pantalla
		public void CalculoPantalla(double[,] MatrizGiro, double ZPersona, double ConstanteX, double ConstanteY, double MinimoX, double MinimoY, int XPantallaIni, int YPantallaIni) {
			double PosX1g = X1 * MatrizGiro[0, 0] + Y1 * MatrizGiro[1, 0] + Z1 * MatrizGiro[2, 0];
			double PosY1g = X1 * MatrizGiro[0, 1] + Y1 * MatrizGiro[1, 1] + Z1 * MatrizGiro[2, 1];
			double PosZ1g = X1 * MatrizGiro[0, 2] + Y1 * MatrizGiro[1, 2] + Z1 * MatrizGiro[2, 2];

			double PosX2g = X2 * MatrizGiro[0, 0] + Y2 * MatrizGiro[1, 0] + Z2 * MatrizGiro[2, 0];
			double PosY2g = X2 * MatrizGiro[0, 1] + Y2 * MatrizGiro[1, 1] + Z2 * MatrizGiro[2, 1];
			double PosZ2g = X2 * MatrizGiro[0, 2] + Y2 * MatrizGiro[1, 2] + Z2 * MatrizGiro[2, 2];

			double PosX3g = X3 * MatrizGiro[0, 0] + Y3 * MatrizGiro[1, 0] + Z3 * MatrizGiro[2, 0];
			double PosY3g = X3 * MatrizGiro[0, 1] + Y3 * MatrizGiro[1, 1] + Z3 * MatrizGiro[2, 1];
			double PosZ3g = X3 * MatrizGiro[0, 2] + Y3 * MatrizGiro[1, 2] + Z3 * MatrizGiro[2, 2];

			double PosX4g = X4 * MatrizGiro[0, 0] + Y4 * MatrizGiro[1, 0] + Z4 * MatrizGiro[2, 0];
			double PosY4g = X4 * MatrizGiro[0, 1] + Y4 * MatrizGiro[1, 1] + Z4 * MatrizGiro[2, 1];
			double PosZ4g = X4 * MatrizGiro[0, 2] + Y4 * MatrizGiro[1, 2] + Z4 * MatrizGiro[2, 2];

			//Usado para ordenar los pol�gonos del m�s lejano al m�s cercano
			Centro = (PosZ1g + PosZ2g + PosZ3g + PosZ4g) / 4;

			//Convierte de 3D a 2D (segunda dimensi�n)
			double X1sd = PosX1g * ZPersona / (ZPersona - PosZ1g);
			double Y1sd = PosY1g * ZPersona / (ZPersona - PosZ1g);

			double X2sd = PosX2g * ZPersona / (ZPersona - PosZ2g);
			double Y2sd = PosY2g * ZPersona / (ZPersona - PosZ2g);

			double X3sd = PosX3g * ZPersona / (ZPersona - PosZ3g);
			double Y3sd = PosY3g * ZPersona / (ZPersona - PosZ3g);

			double X4sd = PosX4g * ZPersona / (ZPersona - PosZ4g);
			double Y4sd = PosY4g * ZPersona / (ZPersona - PosZ4g);

			//Cuadra en pantalla f�sica
			X1p = Convert.ToInt32(ConstanteX * (X1sd - MinimoX) + XPantallaIni);
			Y1p = Convert.ToInt32(ConstanteY * (Y1sd - MinimoY) + YPantallaIni);

			X2p = Convert.ToInt32(ConstanteX * (X2sd - MinimoX) + XPantallaIni);
			Y2p = Convert.ToInt32(ConstanteY * (Y2sd - MinimoY) + YPantallaIni);

			X3p = Convert.ToInt32(ConstanteX * (X3sd - MinimoX) + XPantallaIni);
			Y3p = Convert.ToInt32(ConstanteY * (Y3sd - MinimoY) + YPantallaIni);

			X4p = Convert.ToInt32(ConstanteX * (X4sd - MinimoX) + XPantallaIni);
			Y4p = Convert.ToInt32(ConstanteY * (Y4sd - MinimoY) + YPantallaIni);
		}

		//Hace el gr�fico del pol�gono
		public void Dibuja(Graphics Lienzo, Pen Lapiz, Brush Relleno) {
			//Pone un color de fondo al pol�gono para borrar lo que hay detr�s
			Point Punto1 = new(X1p, Y1p);
			Point Punto2 = new(X2p, Y2p);
			Point Punto3 = new(X3p, Y3p);
			Point Punto4 = new(X4p, Y4p);
			Point[] ListaPuntos = [Punto1, Punto2, Punto3, Punto4];

			//Dibuja el pol�gono relleno y su per�metro
			Lienzo.FillPolygon(Relleno, ListaPuntos);
			Lienzo.DrawPolygon(Lapiz, ListaPuntos);
		}

		//Usado para ordenar los pol�gonos del m�s lejano al m�s cercano
		public int CompareTo(object obj) {
			Poligono OrdenCompara = obj as Poligono;
			if (OrdenCompara.Centro < Centro) return 1;
			if (OrdenCompara.Centro > Centro) return -1;
			return 0;
			//https://stackoverflow.com/questions/3309188/how-to-sort-a-listt-by-a-property-in-the-object
		}
	}

	internal class Grafico {

		//Donde almacena los poligonos
		private List<Poligono> Poligonos;

		public void CalculaEcuacion(double MinXreal, double MaxXreal, int NumeroLineasGrafico) {
			//Inicia el listado de pol�gonos que forma la figura			 
			Poligonos = [];

			double IncrAngulo = 360 / NumeroLineasGrafico;
			double IncrXreal = (MaxXreal - MinXreal) / NumeroLineasGrafico;

			//M�nimos y m�ximos para normalizar
			double MinimoX = double.MaxValue;
			double MaximoX = double.MinValue;
			double MinimoY = double.MaxValue;
			double MaximoY = double.MinValue;
			double MinimoZ = double.MaxValue;
			double MaximoZ = double.MinValue;

			//Usando la matriz de Giro en X, se toma cada punto del gr�fico 2D Y=F(X) y se hace girar en X
			for (double Angulo = 0; Angulo < 360; Angulo += IncrAngulo)
				for (double valX = MinXreal; valX <= MaxXreal; valX += IncrXreal) {

					//Primer punto
					double X1 = valX;
					double Y1 = Ecuacion(X1);
					if (double.IsNaN(Y1) || double.IsInfinity(Y1)) Y1 = 0;

					//Hace giro
					double X1g = X1;
					double Y1g = Y1 * Math.Cos(Angulo * Math.PI / 180);
					double Z1g = Y1 * Math.Sin(Angulo * Math.PI / 180);

					//Segundo punto
					double X2 = valX + IncrXreal;
					double Y2 = Ecuacion(X2);
					if (double.IsNaN(Y2) || double.IsInfinity(Y2)) Y2 = 0;

					//Hace giro
					double X2g = X2;
					double Y2g = Y2 * Math.Cos(Angulo * Math.PI / 180);
					double Z2g = Y2 * Math.Sin(Angulo * Math.PI / 180);

					//Tercer punto ya girado
					double X3g = X2;
					double Y3g = Y2 * Math.Cos((Angulo + IncrAngulo) * Math.PI / 180);
					double Z3g = Y2 * Math.Sin((Angulo + IncrAngulo) * Math.PI / 180);

					//Cuarto punto ya girado
					double X4g = X1;
					double Y4g = Y1 * Math.Cos((Angulo + IncrAngulo) * Math.PI / 180);
					double Z4g = Y1 * Math.Sin((Angulo + IncrAngulo) * Math.PI / 180);

					//Obtener los valores extremos para poder normalizar
					if (X1g < MinimoX) MinimoX = X1g;
					if (X2g < MinimoX) MinimoX = X2g;
					if (X3g < MinimoX) MinimoX = X3g;
					if (X4g < MinimoX) MinimoX = X4g;

					if (Y1g < MinimoY) MinimoY = Y1g;
					if (Y2g < MinimoY) MinimoY = Y2g;
					if (Y3g < MinimoY) MinimoY = Y3g;
					if (Y4g < MinimoY) MinimoY = Y4g;

					if (Z1g < MinimoZ) MinimoZ = Z1g;
					if (Z2g < MinimoZ) MinimoZ = Z2g;
					if (Z3g < MinimoZ) MinimoZ = Z3g;
					if (Z4g < MinimoZ) MinimoZ = Z4g;

					if (X1g > MaximoX) MaximoX = X1g;
					if (X2g > MaximoX) MaximoX = X2g;
					if (X3g > MaximoX) MaximoX = X3g;
					if (X4g > MaximoX) MaximoX = X4g;

					if (Y1g > MaximoY) MaximoY = Y1g;
					if (Y2g > MaximoY) MaximoY = Y2g;
					if (Y3g > MaximoY) MaximoY = Y3g;
					if (Y4g > MaximoY) MaximoY = Y4g;

					if (Z1g > MaximoZ) MaximoZ = Z1g;
					if (Z2g > MaximoZ) MaximoZ = Z2g;
					if (Z3g > MaximoZ) MaximoZ = Z3g;
					if (Z4g > MaximoZ) MaximoZ = Z4g;

					Poligonos.Add(new Poligono(X1g, Y1g, Z1g, X2g, Y2g, Z2g, X3g, Y3g, Z3g, X4g, Y4g, Z4g));
				}

			//Luego normaliza los puntos X,Y,Z para que queden entre -0.5 y 0.5
			for (int cont = 0; cont < Poligonos.Count; cont++) Poligonos[cont].Normaliza(MinimoX, MinimoY, MinimoZ, MaximoX, MaximoY, MaximoZ);

		}

		//Aqu� est� la ecuaci�n Y=F(X) que se desee graficar para hacer el s�lido de revoluci�n.
		public double Ecuacion(double X) {
			return 1.7 * Math.Sin((2*X - 3) * Math.PI / 180);
		}

		public void CalculaGrafico(double AngX, double AngY, double AngZ, int ZPersona, int XPantallaIni, int YPantallaIni, int XPantallaFin, int YPantallaFin) {

			//Genera la matriz de rotaci�n
			double CosX = Math.Cos(AngX * Math.PI / 180);
			double SinX = Math.Sin(AngX * Math.PI / 180);
			double CosY = Math.Cos(AngY * Math.PI / 180);
			double SinY = Math.Sin(AngY * Math.PI / 180);
			double CosZ = Math.Cos(AngZ * Math.PI / 180);
			double SinZ = Math.Sin(AngZ * Math.PI / 180);

			//Matriz de Rotaci�n: https://en.wikipedia.org/wiki/Rotation_formalisms_in_three_dimensions
			double[,] Matriz = new double[3, 3] {
				{ CosY * CosZ, -CosX * SinZ + SinX * SinY * CosZ, SinX * SinZ + CosX * SinY * CosZ},
				{ CosY * SinZ, CosX * CosZ + SinX * SinY * SinZ, -SinX * CosZ + CosX * SinY * SinZ},
				{-SinY, SinX * CosY, CosX * CosY }
			};

			//Los valores extremos al girar la figura en X, Y, Z (de 0 a 360 grados), porque est� contenida en un cubo de 1*1*1
			double MaximoX = 0.87931543769177811;
			double MinimoX = -0.87931543769177811;
			double MaximoY = 0.87931543769177811;
			double MinimoY = -0.87931543769177811;

			//Las constantes de transformaci�n
			double ConstanteX = (XPantallaFin - XPantallaIni) / (MaximoX - MinimoX);
			double ConstanteY = (YPantallaFin - YPantallaIni) / (MaximoY - MinimoY);

			//Gira los pol�gonos, proyecta a 2D y cuadra en pantalla
			for (int cont = 0; cont < Poligonos.Count; cont++)
				Poligonos[cont].CalculoPantalla(Matriz, ZPersona, ConstanteX, ConstanteY, MinimoX, MinimoY, XPantallaIni, YPantallaIni);

			//Ordena del pol�gono m�s alejado al m�s cercano, de esa manera los pol�gonos de adelante son visibles y los de atr�s son borrados.
			Poligonos.Sort();
		}

		//Dibuja el pol�gono
		public void Dibuja(Graphics Lienzo, Pen Lapiz, Brush Relleno) {
			for (int Cont = 0; Cont < Poligonos.Count; Cont++)
				Poligonos[Cont].Dibuja(Lienzo, Lapiz, Relleno);
		}
	}

}
