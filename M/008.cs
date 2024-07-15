namespace Graficos {
	public partial class Form1 : Form {
		//El objeto que se encarga de calcular
		//y cuadrar en pantalla la ecuación Z = F(X,Y)
		Grafico Grafico3D;

		public Form1() {
			InitializeComponent();
			Grafico3D = new Grafico();

			//Hace los cálculos de la ecuación primero.
			double MinX = -9;
			double MinY = -9;
			double MaxX = 9;
			double MaxY = 9;
			int numLineas = 30;
			Grafico3D.CalculaEcuacion(MinX, MinY, MaxX, MaxY, numLineas);
		}

		private void Form1_Paint(object sender, PaintEventArgs e) {
			Graphics Lienzo = e.Graphics;
			Pen Lapiz = new(Color.Black, 1);
			Brush Relleno = new SolidBrush(Color.White);

			int AnguloX = Convert.ToInt32(numGiroX.Value);
			int AnguloY = Convert.ToInt32(numGiroY.Value);
			int AnguloZ = Convert.ToInt32(numGiroZ.Value);

			int ZPersona = 5;

			//Tamaño de la pantalla
			int XpIni = 0;
			int YpIni = 0;
			int XpFin = 800;
			int YpFin = 800;

			//Después de los cálculos, entonces aplica giros,
			//conversión a 2D y cuadrar en pantalla
			Grafico3D.CalculaGrafico(AnguloX, AnguloY, AnguloZ,
									ZPersona,
									XpIni, YpIni,
									XpFin, YpFin);
			Grafico3D.Dibuja(Lienzo, Lapiz, Relleno);
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
	}

	internal class Grafico {

		//Donde almacena los poligonos
		private List<Poligono> poligono;

		public void CalculaEcuacion(double MinimoX, double MinimoY,
									double MaximoX, double MaximoY,
									int numLineas) {
			//Inicia el listado de polígonos que forma la figura			 
			poligono = [];

			//Mínimos y máximos para normalizar
			double MinimoZ = double.MaxValue;
			double MaximoZ = double.MinValue;

			//Calcula cada polígono dependiendo de la ecuación
			double IncrX = (MaximoX - MinimoX) / numLineas;
			double IncrY = (MaximoY - MinimoY) / numLineas;

			for (double ValX = MinimoX; ValX <= MaximoX; ValX += IncrX)
				for (double ValY = MinimoY; ValY <= MaximoY; ValY += IncrY) {

					//Calcula los 4 valores del eje Z del polígono
					double Z1 = Ecuacion(ValX, ValY);
					double Z2 = Ecuacion(ValX + IncrX, ValY);
					double Z3 = Ecuacion(ValX + IncrX, ValY + IncrY);
					double Z4 = Ecuacion(ValX, ValY + IncrY);

					//Si un valor de Z es inválido se pone en cero
					if (double.IsNaN(Z1) || double.IsInfinity(Z1)) Z1 = 0;
					if (double.IsNaN(Z2) || double.IsInfinity(Z2)) Z2 = 0;
					if (double.IsNaN(Z3) || double.IsInfinity(Z3)) Z3 = 0;
					if (double.IsNaN(Z4) || double.IsInfinity(Z4)) Z4 = 0;

					//Captura el mínimo valor de Z de todos los polígonos
					if (Z1 < MinimoZ) MinimoZ = Z1;
					if (Z2 < MinimoZ) MinimoZ = Z2;
					if (Z3 < MinimoZ) MinimoZ = Z3;
					if (Z4 < MinimoZ) MinimoZ = Z4;

					//Captura el máximo valor de Z de todos los polígonos
					if (Z1 > MaximoZ) MaximoZ = Z1;
					if (Z2 > MaximoZ) MaximoZ = Z2;
					if (Z3 > MaximoZ) MaximoZ = Z3;
					if (Z4 > MaximoZ) MaximoZ = Z4;

					//Añade un polígono a la lista
					poligono.Add(new Poligono(ValX, ValY, Z1,
											ValX + IncrX, ValY, Z2,
											ValX + IncrX, ValY + IncrY, Z3,
											ValX, ValY + IncrY, Z4));
				}

			//Luego normaliza los puntos X,Y,Z
			//para que queden entre -0.5 y 0.5
			for (int cont = 0; cont < poligono.Count; cont++)
				poligono[cont].Normaliza(MinimoX, MinimoY, MinimoZ,
										 MaximoX + IncrX, MaximoY + IncrY, MaximoZ);

		}

		//Aquí está la ecuación 3D que se desee
		//graficar con variable XY
		private double Ecuacion(double X, double Y) {
			double Z = Math.Sqrt(X * X + Y * Y);
			Z += 3 * Math.Cos(Math.Sqrt(X * X + Y * Y)) + 5;
			return Z;
		}

		public void CalculaGrafico(double AngX, double AngY, double AngZ,
									int ZPersona,
									int XpIni, int YpIni,
									int XpFin, int YpFin) {

			//Genera la matriz de rotación
			double CosX = Math.Cos(AngX * Math.PI / 180);
			double SinX = Math.Sin(AngX * Math.PI / 180);
			double CosY = Math.Cos(AngY * Math.PI / 180);
			double SinY = Math.Sin(AngY * Math.PI / 180);
			double CosZ = Math.Cos(AngZ * Math.PI / 180);
			double SinZ = Math.Sin(AngZ * Math.PI / 180);

			//Matriz de Rotación
			//https://en.wikipedia.org/wiki/Rotation_formalisms_in_three_dimensions
			double[,] Matriz = new double[3, 3] {
{CosY*CosZ,-CosX*SinZ+SinX*SinY*CosZ,SinX*SinZ+CosX*SinY*CosZ},
{CosY*SinZ,CosX*CosZ+SinX*SinY*SinZ,-SinX*CosZ+CosX*SinY*SinZ},
{-SinY,SinX*CosY,CosX*CosY}
			};

			//Los valores extremos al girar la figura en X, Y, Z
			//(de 0 a 360 grados), porque está contenida
			//en un cubo de 1*1*1
			double MaximoX = 0.87931543769177811;
			double MinimoX = -0.87931543769177811;
			double MaximoY = 0.87931543769177811;
			double MinimoY = -0.87931543769177811;

			//Las constantes de transformación
			double ConstanteX = (XpFin - XpIni) / (MaximoX - MinimoX);
			double ConstanteY = (YpFin - YpIni) / (MaximoY - MinimoY);

			//Gira los polígonos, proyecta a 2D y cuadra en pantalla
			for (int cont = 0; cont < poligono.Count; cont++)
				poligono[cont].CalculoPantalla(Matriz, ZPersona, 
												ConstanteX, ConstanteY,
												MinimoX, MinimoY,
												XpIni, YpIni);

			//Ordena del polígono más alejado al más cercano,
			//de esa manera los polígonos de adelante son
			//visibles y los de atrás son borrados.
			poligono.Sort();
		}

		//Dibuja el polígono
		public void Dibuja(Graphics Lienzo, Pen Lapiz, Brush Relleno) {
			for (int Cont = 0; Cont < poligono.Count; Cont++)
				poligono[Cont].Dibuja(Lienzo, Lapiz, Relleno);
		}
	}


	internal class Poligono : IComparable {
		//Un polígono son cuatro(4) coordenadas espaciales
		public double X1, Y1, Z1;
		public double X2, Y2, Z2;
		public double X3, Y3, Z3;
		public double X4, Y4, Z4;

		//Las coordenadas en pantalla
		public int X1p, Y1p, X2p, Y2p, X3p, Y3p, X4p, Y4p;

		//Centro del polígono
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

		//Normaliza puntos polígono entre -0.5 y 0.5
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
									int XPIni, int YPIni) {
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

			//Usado para ordenar los polígonos
			//del más lejano al más cercano
			Centro = (Z1g + Z2g + Z3g + Z4g) / 4;

			//Convierte de 3D a 2D (segunda dimensión)
			double X1sd = X1g * ZPersona / (ZPersona - Z1g);
			double Y1sd = Y1g * ZPersona / (ZPersona - Z1g);

			double X2sd = X2g * ZPersona / (ZPersona - Z2g);
			double Y2sd = Y2g * ZPersona / (ZPersona - Z2g);

			double X3sd = X3g * ZPersona / (ZPersona - Z3g);
			double Y3sd = Y3g * ZPersona / (ZPersona - Z3g);

			double X4sd = X4g * ZPersona / (ZPersona - Z4g);
			double Y4sd = Y4g * ZPersona / (ZPersona - Z4g);

			//Cuadra en pantalla física
			X1p = Convert.ToInt32(conX * (X1sd - MinimoX) + XPIni);
			Y1p = Convert.ToInt32(conY * (Y1sd - MinimoY) + YPIni);

			X2p = Convert.ToInt32(conX * (X2sd - MinimoX) + XPIni);
			Y2p = Convert.ToInt32(conY * (Y2sd - MinimoY) + YPIni);

			X3p = Convert.ToInt32(conX * (X3sd - MinimoX) + XPIni);
			Y3p = Convert.ToInt32(conY * (Y3sd - MinimoY) + YPIni);

			X4p = Convert.ToInt32(conX * (X4sd - MinimoX) + XPIni);
			Y4p = Convert.ToInt32(conY * (Y4sd - MinimoY) + YPIni);
		}

		//Hace el gráfico del polígono
		public void Dibuja(Graphics Lienzo, Pen Lapiz, Brush Relleno) {
			//Pone un color de fondo al polígono
			//para borrar lo que hay detrás
			Point Punto1 = new(X1p, Y1p);
			Point Punto2 = new(X2p, Y2p);
			Point Punto3 = new(X3p, Y3p);
			Point Punto4 = new(X4p, Y4p);
			Point[] ListaPuntos = [Punto1, Punto2, Punto3, Punto4];

			//Dibuja el polígono relleno y su perímetro
			Lienzo.FillPolygon(Relleno, ListaPuntos);
			Lienzo.DrawPolygon(Lapiz, ListaPuntos);
		}

		//Usado para ordenar los polígonos
		//del más lejano al más cercano
		public int CompareTo(object obj) {
			Poligono OrdenCompara = obj as Poligono;
			if (OrdenCompara.Centro < Centro) return 1;
			if (OrdenCompara.Centro > Centro) return -1;
			return 0;
			//https://stackoverflow.com/questions/3309188/how-to-sort-a-listt-by-a-property-in-the-object
		}
	}
}
