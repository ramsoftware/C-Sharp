namespace Graficos {
	public partial class Form1 : Form {
		//El objeto que se encarga de calcular
		//y cuadrar en pantalla la ecuación polar
		Grafico Grafico3D;

		public Form1() {
			InitializeComponent();
			Grafico3D = new Grafico();

			int numLineas = 70;
			Grafico3D.CalculaEcuacion(numLineas);
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

		private void Form1_Paint(object sender, PaintEventArgs e) {
			Graphics Lienzo = e.Graphics;
			Pen Lapiz = new(Color.Black, 1);
			Brush Relleno = new SolidBrush(Color.White);

			int AnguloX = Convert.ToInt32(numGiroX.Value);
			int AnguloY = Convert.ToInt32(numGiroY.Value);
			int AnguloZ = Convert.ToInt32(numGiroZ.Value);

			int ZPersona = 5;
			int XPantallaIni = 0;
			int YPantallaIni = 0;
			int XPantallaFin = 800;
			int YPantallaFin = 800;

			//Después de los cálculos, entonces aplica giros,
			//conversión a 2D y cuadrar en pantalla
			Grafico3D.CalculaGrafico(AnguloX, AnguloY, AnguloZ,
										ZPersona,
										XPantallaIni, YPantallaIni,
										XPantallaFin, YPantallaFin);
			Grafico3D.Dibuja(Lienzo, Lapiz, Relleno);
		}
	}

	internal class Grafico {

		//Donde almacena los poligonos
		private List<Poligono> poligono;

		public void CalculaEcuacion(int numLineas) {
			//Inicia el listado de polígonos que forma la figura			 
			poligono = [];

			//Mínimos y máximos para normalizar
			double MinimoX = double.MaxValue;
			double MaximoX = double.MinValue;
			double MinimoY = double.MaxValue;
			double MaximoY = double.MinValue;
			double MinimoZ = double.MaxValue;
			double MaximoZ = double.MinValue;

			//Calcula cada polígono dependiendo de la ecuación
			double MinTheta = 0, MaxTheta = 360, MinPhi = 0, MaxPhi = 360;

			double IncTheta = (MaxTheta - MinTheta) / numLineas;
			double IncPhi = (MaxPhi - MinPhi) / numLineas;

			for (double Th = MinTheta; Th <= MaxTheta; Th += IncTheta)
				for (double Phi = MinPhi; Phi <= MaxPhi; Phi += IncPhi) {

					//Calcula los 4 valores del eje Z del polígono

					//Con los ángulos
					double Theta1 = Th * Math.PI / 180;
					double Phi1 = Phi * Math.PI / 180;
					double R1 = Ecuacion(Theta1, Phi1);
					if (double.IsNaN(R1) || double.IsInfinity(R1)) R1 = 0;

					//Conversión a coordenadas X,Y,Z
					double X1 = R1 * Math.Cos(Phi1) * Math.Sin(Theta1);
					double Y1 = R1 * Math.Sin(Phi1) * Math.Sin(Theta1);
					double Z1 = R1 * Math.Cos(Theta1);

					double Theta2 = (Th + IncTheta) * Math.PI / 180;
					double Phi2 = Phi * Math.PI / 180;
					double R2 = Ecuacion(Theta2, Phi2);
					if (double.IsNaN(R2) || double.IsInfinity(R2)) R2 = 0;
					double X2 = R2 * Math.Cos(Phi2) * Math.Sin(Theta2);
					double Y2 = R2 * Math.Sin(Phi2) * Math.Sin(Theta2);
					double Z2 = R2 * Math.Cos(Theta2);

					double Theta3 = (Th + IncTheta) * Math.PI / 180;
					double Phi3 = (Phi + IncPhi) * Math.PI / 180;
					double R3 = Ecuacion(Theta3, Phi3);
					if (double.IsNaN(R3) || double.IsInfinity(R3)) R3 = 0;
					double X3 = R3 * Math.Cos(Phi3) * Math.Sin(Theta3);
					double Y3 = R3 * Math.Sin(Phi3) * Math.Sin(Theta3);
					double Z3 = R3 * Math.Cos(Theta3);

					double Theta4 = Th * Math.PI / 180;
					double Phi4 = (Phi + IncPhi) * Math.PI / 180;
					double R4 = Ecuacion(Theta4, Phi4);
					if (double.IsNaN(R4) || double.IsInfinity(R4)) R4 = 0;
					double X4 = R4 * Math.Cos(Phi4) * Math.Sin(Theta4);
					double Y4 = R4 * Math.Sin(Phi4) * Math.Sin(Theta4);
					double Z4 = R4 * Math.Cos(Theta4);

					if (X1 < MinimoX) MinimoX = X1;
					if (X2 < MinimoX) MinimoX = X2;
					if (X3 < MinimoX) MinimoX = X3;
					if (X4 < MinimoX) MinimoX = X4;

					if (Y1 < MinimoY) MinimoY = Y1;
					if (Y2 < MinimoY) MinimoY = Y2;
					if (Y3 < MinimoY) MinimoY = Y3;
					if (Y4 < MinimoY) MinimoY = Y4;

					if (Z1 < MinimoZ) MinimoZ = Z1;
					if (Z2 < MinimoZ) MinimoZ = Z2;
					if (Z3 < MinimoZ) MinimoZ = Z3;
					if (Z4 < MinimoZ) MinimoZ = Z4;

					if (X1 > MaximoX) MaximoX = X1;
					if (X2 > MaximoX) MaximoX = X2;
					if (X3 > MaximoX) MaximoX = X3;
					if (X4 > MaximoX) MaximoX = X4;

					if (Y1 > MaximoY) MaximoY = Y1;
					if (Y2 > MaximoY) MaximoY = Y2;
					if (Y3 > MaximoY) MaximoY = Y3;
					if (Y4 > MaximoY) MaximoY = Y4;

					if (Z1 > MaximoZ) MaximoZ = Z1;
					if (Z2 > MaximoZ) MaximoZ = Z2;
					if (Z3 > MaximoZ) MaximoZ = Z3;
					if (Z4 > MaximoZ) MaximoZ = Z4;

					//Añade un polígono a la lista
					poligono.Add(new Poligono(X1, Y1, Z1,
												X2, Y2, Z2,
												X3, Y3, Z3,
												X4, Y4, Z4));
				}

			//Luego normaliza los puntos X,Y,Z
			//para que queden entre -0.5 y 0.5
			for (int cont = 0; cont < poligono.Count; cont++)
				poligono[cont].Normaliza(MinimoX, MinimoY, MinimoZ,
										MaximoX, MaximoY, MaximoZ);

		}

		//Aquí está la ecuación polar 3D que se desee graficar
		//con variable Theta y PHI
		public double Ecuacion(double Theta, double Phi) {
			return Math.Cos(Phi + Theta) - Math.Sin(Theta - Phi);
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

			//Matriz de Rotación: https://en.wikipedia.org/wiki/Rotation_formalisms_in_three_dimensions
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
			double conX = (XpFin - XpIni) / (MaximoX - MinimoX);
			double conY = (YpFin - YpIni) / (MaximoY - MinimoY);

			//Gira los polígonos, proyecta a 2D y cuadra en pantalla
			for (int cont = 0; cont < poligono.Count; cont++)
				poligono[cont].CalculoPantalla(Matriz, ZPersona,
												conX, conY,
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
		public double X1, Y1, Z1, X2, Y2, Z2, X3, Y3, Z3, X4, Y4, Z4;

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
		public void Normaliza(double MinimoX, double MinimoY, double MinimoZ,
							  double MaximoX, double MaximoY, double MaximoZ) {
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
		public void CalculoPantalla(double[,] Mt, double ZPersona,
									double ConstanteX, double ConstanteY,
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

			//Usado para ordenar los polígonos del más lejano al más cercano
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
			X1p = Convert.ToInt32(ConstanteX * (X1sd - MinimoX) + XpIni);
			Y1p = Convert.ToInt32(ConstanteY * (Y1sd - MinimoY) + YpIni);

			X2p = Convert.ToInt32(ConstanteX * (X2sd - MinimoX) + XpIni);
			Y2p = Convert.ToInt32(ConstanteY * (Y2sd - MinimoY) + YpIni);

			X3p = Convert.ToInt32(ConstanteX * (X3sd - MinimoX) + XpIni);
			Y3p = Convert.ToInt32(ConstanteY * (Y3sd - MinimoY) + YpIni);

			X4p = Convert.ToInt32(ConstanteX * (X4sd - MinimoX) + XpIni);
			Y4p = Convert.ToInt32(ConstanteY * (Y4sd - MinimoY) + YpIni);
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