namespace Graficos {

	public partial class Form1 : Form {
		//El objeto que se encarga de calcular
		//y cuadrar en pantalla la ecuaci�n que
		//genera el s�lido de revoluci�n
		Grafico Grafico3D;

		public Form1() {
			InitializeComponent();
			Grafico3D = new Grafico();

			double MinXreal = 0;
			double MaxXreal = 180;
			int numLineas = 40;
			Grafico3D.Calcula(MinXreal, MaxXreal, numLineas);
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
			int XpIni = 0;
			int YpIni = 0;
			int XpFin = 800;
			int YpFin = 800;

			//Despu�s de los c�lculos, entonces aplica giros,
			//conversi�n a 2D y cuadrar en pantalla
			Grafico3D.CalculaGrafico(AnguloX, AnguloY, AnguloZ,
									 ZPersona,
									 XpIni, YpIni,
									 XpFin, YpFin);
			Grafico3D.Dibuja(Lienzo, Lapiz, Relleno);
		}
	}

	internal class Poligono : IComparable {
		//Un pol�gono son cuatro(4) coordenadas espaciales
		public double X1, Y1, Z1;
		public double X2, Y2, Z2;
		public double X3, Y3, Z3;
		public double X4, Y4, Z4;

		//Las coordenadas en pantalla
		public int X1p, Y1p, X2p, Y2p, X3p, Y3p, X4p, Y4p;

		//Centro del pol�gono
		public double Centro;

		public Poligono(double X1, double Y1, double Z1,
						double X2, double Y2, double Z2,
						double X3, double Y3, double Z3,
						double X4, double Y4, double Z4) {
			this.X1 = X1; this.Y1 = Y1; this.Z1 = Z1;
			this.X2 = X2; this.Y2 = Y2; this.Z2 = Z2;
			this.X3 = X3; this.Y3 = Y3; this.Z3 = Z3;
			this.X4 = X4; this.Y4 = Y4; this.Z4 = Z4;
		}

		//Normaliza puntos pol�gono entre -0.5 y 0.5
		public void Normaliza(double MinX, double MinY, double MinZ,
							  double MaxX, double MaxY, double MaxZ) {
			X1 = (X1 - MinX) / (MaxX - MinX) - 0.5;
			Y1 = (Y1 - MinY) / (MaxY - MinY) - 0.5;
			Z1 = (Z1 - MinZ) / (MaxZ - MinZ) - 0.5;

			X2 = (X2 - MinX) / (MaxX - MinX) - 0.5;
			Y2 = (Y2 - MinY) / (MaxY - MinY) - 0.5;
			Z2 = (Z2 - MinZ) / (MaxZ - MinZ) - 0.5;

			X3 = (X3 - MinX) / (MaxX - MinX) - 0.5;
			Y3 = (Y3 - MinY) / (MaxY - MinY) - 0.5;
			Z3 = (Z3 - MinZ) / (MaxZ - MinZ) - 0.5;

			X4 = (X4 - MinX) / (MaxX - MinX) - 0.5;
			Y4 = (Y4 - MinY) / (MaxY - MinY) - 0.5;
			Z4 = (Z4 - MinZ) / (MaxZ - MinZ) - 0.5;
		}


		//Gira en XYZ, convierte a 2D y cuadra en pantalla
		public void CalculoPantalla(double[,] Mt, double ZPersona,
									double conX, double conY,
									double MinimoX, double MinimoY,
									int XpIni, int YpIni) {
			double X1g = X1 * Mt[0, 0] + Y1 * Mt[1, 0] + Z1 * Mt[2, 0];
			double Y1g = X1 * Mt[0, 1] + Y1 * Mt[1, 1] + Z1 * Mt[2, 1];
			double Z1g = X1 * Mt[0, 2] + Y1 * Mt[1, 2] + Z1 * Mt[2, 2];

			double X2g = X2 * Mt[0, 0] + Y2 * Mt[1, 0] + Z2 * Mt[2, 0];
			double Y2g = X2 * Mt[0, 1] + Y2 * Mt[1, 1] + Z2 * Mt[2, 1];
			double Z2g = X2 * Mt[0, 2] + Y2 * Mt[1, 2] + Z2 * Mt[2, 2];

			double X3g = X3 * Mt[0, 0] + Y3 * Mt[1, 0] + Z3 * Mt[2, 0];
			double Y3g = X3 * Mt[0, 1] + Y3 * Mt[1, 1] + Z3 * Mt[2, 1];
			double Z3g = X3 * Mt[0, 2] + Y3 * Mt[1, 2] + Z3 * Mt[2, 2];

			double X4g = X4 * Mt[0, 0] + Y4 * Mt[1, 0] + Z4 * Mt[2, 0];
			double Y4g = X4 * Mt[0, 1] + Y4 * Mt[1, 1] + Z4 * Mt[2, 1];
			double Z4g = X4 * Mt[0, 2] + Y4 * Mt[1, 2] + Z4 * Mt[2, 2];

			//Usado para ordenar los pol�gonos
			//del m�s lejano al m�s cercano
			Centro = (Z1g + Z2g + Z3g + Z4g) / 4;

			//Convierte de 3D a 2D (segunda dimensi�n)
			double X1sd = X1g * ZPersona / (ZPersona - Z1g);
			double Y1sd = Y1g * ZPersona / (ZPersona - Z1g);

			double X2sd = X2g * ZPersona / (ZPersona - Z2g);
			double Y2sd = Y2g * ZPersona / (ZPersona - Z2g);

			double X3sd = X3g * ZPersona / (ZPersona - Z3g);
			double Y3sd = Y3g * ZPersona / (ZPersona - Z3g);

			double X4sd = X4g * ZPersona / (ZPersona - Z4g);
			double Y4sd = Y4g * ZPersona / (ZPersona - Z4g);

			//Cuadra en pantalla f�sica
			X1p = Convert.ToInt32(conX * (X1sd - MinimoX) + XpIni);
			Y1p = Convert.ToInt32(conY * (Y1sd - MinimoY) + YpIni);

			X2p = Convert.ToInt32(conX * (X2sd - MinimoX) + XpIni);
			Y2p = Convert.ToInt32(conY * (Y2sd - MinimoY) + YpIni);

			X3p = Convert.ToInt32(conX * (X3sd - MinimoX) + XpIni);
			Y3p = Convert.ToInt32(conY * (Y3sd - MinimoY) + YpIni);

			X4p = Convert.ToInt32(conX * (X4sd - MinimoX) + XpIni);
			Y4p = Convert.ToInt32(conY * (Y4sd - MinimoY) + YpIni);
		}

		//Hace el gr�fico del pol�gono
		public void Dibuja(Graphics Lienzo, Pen Lapiz, Brush Relleno) {
			//Pone un color de fondo al pol�gono
			//para borrar lo que hay detr�s
			Point Punto1 = new(X1p, Y1p);
			Point Punto2 = new(X2p, Y2p);
			Point Punto3 = new(X3p, Y3p);
			Point Punto4 = new(X4p, Y4p);
			Point[] ListaPuntos = [Punto1, Punto2, Punto3, Punto4];

			//Dibuja el pol�gono relleno y su per�metro
			Lienzo.FillPolygon(Relleno, ListaPuntos);
			Lienzo.DrawPolygon(Lapiz, ListaPuntos);
		}

		//Usado para ordenar los pol�gonos
		//del m�s lejano al m�s cercano
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
		private List<Poligono> poligono;

		public void Calcula(double minX, double maxX, int numLineas) {
			//Inicia el listado de pol�gonos
			//que forma la figura			 
			poligono = [];

			//M�nimos y m�ximos para normalizar
			double MinimoX = double.MaxValue;
			double MaximoX = double.MinValue;
			double MinimoY = double.MaxValue;
			double MaximoY = double.MinValue;
			double MinimoZ = double.MaxValue;
			double MaximoZ = double.MinValue;

			double IncAng = 360 / numLineas;
			double IncX = (maxX - minX) / numLineas;
			double radian = Math.PI / 180;

			//Usando la matriz de Giro en X, se toma cada punto
			//del gr�fico 2D Y=F(X) y se hace girar en X
			for (double ang = 0; ang < 360; ang += IncAng)
				for (double X = minX; X <= maxX; X += IncX) {

					//Primer punto
					double X1 = X;
					double Y1 = Ecuacion(X1);
					if (double.IsNaN(Y1) || double.IsInfinity(Y1)) Y1 = 0;

					//Hace giro
					double X1g = X1;
					double Y1g = Y1 * Math.Cos(ang * radian);
					double Z1g = Y1 * Math.Sin(ang * radian);

					//Segundo punto
					double X2 = X + IncX;
					double Y2 = Ecuacion(X2);
					if (double.IsNaN(Y2) || double.IsInfinity(Y2)) Y2 = 0;

					//Hace giro
					double X2g = X2;
					double Y2g = Y2 * Math.Cos(ang * radian);
					double Z2g = Y2 * Math.Sin(ang * radian);

					//Tercer punto ya girado
					double X3g = X2;
					double Y3g = Y2 * Math.Cos((ang + IncAng) * radian);
					double Z3g = Y2 * Math.Sin((ang + IncAng) * radian);

					//Cuarto punto ya girado
					double X4g = X1;
					double Y4g = Y1 * Math.Cos((ang + IncAng) * radian);
					double Z4g = Y1 * Math.Sin((ang + IncAng) * radian);

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

					poligono.Add(new Poligono(X1g, Y1g, Z1g,
												X2g, Y2g, Z2g,
												X3g, Y3g, Z3g,
												X4g, Y4g, Z4g));
				}

			//Luego normaliza los puntos X,Y,Z
			//para que queden entre -0.5 y 0.5
			for (int cont = 0; cont < poligono.Count; cont++)
				poligono[cont].Normaliza(MinimoX, MinimoY, MinimoZ,
										  MaximoX, MaximoY, MaximoZ);

		}

		//Aqu� est� la ecuaci�n Y=F(X) que se desee
		//graficar para hacer el s�lido de revoluci�n.
		public double Ecuacion(double X) {
			return 1.7 * Math.Sin((2 * X - 3) * Math.PI / 180);
		}

		public void CalculaGrafico(double AngX, double AngY, double AngZ,
									int ZPersona,
									int XpIni, int YpIni,
									int XpFin, int YpFin) {

			//Genera la matriz de rotaci�n
			double CosX = Math.Cos(AngX * Math.PI / 180);
			double SinX = Math.Sin(AngX * Math.PI / 180);
			double CosY = Math.Cos(AngY * Math.PI / 180);
			double SinY = Math.Sin(AngY * Math.PI / 180);
			double CosZ = Math.Cos(AngZ * Math.PI / 180);
			double SinZ = Math.Sin(AngZ * Math.PI / 180);

			//Matriz de Rotaci�n
			//https://en.wikipedia.org/wiki/Rotation_formalisms_in_three_dimensions
			double[,] Matriz = new double[3, 3] {
{CosY*CosZ,-CosX*SinZ+SinX*SinY*CosZ,SinX*SinZ+CosX*SinY*CosZ},
{CosY*SinZ,CosX*CosZ+SinX*SinY*SinZ,-SinX*CosZ+CosX*SinY*SinZ},
{-SinY,SinX*CosY,CosX*CosY}
			};

			//Los valores extremos al girar la figura en
			//X, Y, Z (de 0 a 360 grados), porque est�
			//contenida en un cubo de 1*1*1
			double MaximoX = 0.87931543769177811;
			double MinimoX = -0.87931543769177811;
			double MaximoY = 0.87931543769177811;
			double MinimoY = -0.87931543769177811;

			//Las constantes de transformaci�n
			double conX = (XpFin - XpIni) / (MaximoX - MinimoX);
			double conY = (YpFin - YpIni) / (MaximoY - MinimoY);

			//Gira los pol�gonos, proyecta a 2D y cuadra en pantalla
			for (int cont = 0; cont < poligono.Count; cont++)
				poligono[cont].CalculoPantalla(Matriz, ZPersona,
												conX, conY,
												MinimoX, MinimoY,
												XpIni, YpIni);

			//Ordena del pol�gono m�s alejado al m�s cercano,
			//de esa manera los pol�gonos de adelante son
			//visibles y los de atr�s son borrados.
			poligono.Sort();
		}

		//Dibuja el pol�gono
		public void Dibuja(Graphics Lienzo, Pen Lapiz, Brush Relleno) {
			for (int Cont = 0; Cont < poligono.Count; Cont++)
				poligono[Cont].Dibuja(Lienzo, Lapiz, Relleno);
		}
	}

}
