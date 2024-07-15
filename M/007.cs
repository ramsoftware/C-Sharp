namespace Graficos {
	public partial class Form1 : Form {
		//El cubo que se proyecta y gira
		Cubo Figura3D;

		public Form1() {
			InitializeComponent();
			Figura3D = new Cubo();
		}

		private void Form1_Paint(object sender, PaintEventArgs e) {
			Graphics Lienzo = e.Graphics;
			Pen Lapiz = new(Color.Black, 1);
			Brush Relleno = new SolidBrush(Color.White);

			int AnguloX = Convert.ToInt32(numGiroX.Value);
			int AnguloY = Convert.ToInt32(numGiroY.Value);
			int AnguloZ = Convert.ToInt32(numGiroZ.Value);

			int ZPersona = 5;
			Figura3D.GirarFigura(AnguloX, AnguloY, AnguloZ);
			Figura3D.Convierte3Da2D(ZPersona);
			Figura3D.CuadraPantalla(20, 20, 500, 500);
			Figura3D.Dibuja(Lienzo, Lapiz, Relleno);
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

	internal class Cubo {
		//Un cubo tiene 8 coordenadas
		//espaciales X, Y, Z
		private List<Poligono> poligono;

		//Constructor
		public Cubo() {
			double P = -0.5;
			double Q = 0.5;
			poligono =
			[
				new Poligono(P, Q, P, Q, Q, P, Q, P, P, P, P, P),
				new Poligono(P, Q, Q, Q, Q, Q, Q, P, Q, P, P, Q),
				new Poligono(P, Q, P, P, Q, Q, P, P, Q, P, P, P),
				new Poligono(Q, Q, P, Q, Q, Q, Q, P, Q, Q, P, P),
				new Poligono(P, Q, P, Q, Q, P, Q, Q, Q, P, Q, Q),
				new Poligono(P, P, P, Q, P, P, Q, P, Q, P, P, Q),
			];
		}

		public void GirarFigura(double angX, double angY, double angZ) {
			double CosX = Math.Cos(angX * Math.PI / 180);
			double SinX = Math.Sin(angX * Math.PI / 180);
			double CosY = Math.Cos(angY * Math.PI / 180);
			double SinY = Math.Sin(angY * Math.PI / 180);
			double CosZ = Math.Cos(angZ * Math.PI / 180);
			double SinZ = Math.Sin(angZ * Math.PI / 180);

			//Matriz de Rotación
			//https://en.wikipedia.org/wiki/Rotation_formalisms_in_three_dimensions
			double[,] Mt = new double[3, 3] {
{CosY*CosZ,-CosX*SinZ+SinX*SinY*CosZ,SinX*SinZ+CosX*SinY*CosZ},
{CosY*SinZ,CosX*CosZ+SinX*SinY*SinZ,-SinX*CosZ+CosX*SinY*SinZ},
{-SinY,SinX*CosY,CosX*CosY}
			};

			//Gira los 8 polígonos
			for (int cont = 0; cont < poligono.Count; cont++) {
				poligono[cont].Girar(Mt);
			}
		}

		//Convierte de 3D a 2D las coordenadas giradas
		public void Convierte3Da2D(int ZPersona) {
			for (int cont = 0; cont < poligono.Count; cont++) {
				poligono[cont].Convierte3Da2D(ZPersona);
			}
		}

		//Convierte las coordenadas planas en coordenadas de pantalla
		public void CuadraPantalla(int XpIni, int YpIni,
								   int XpFin, int YpFin) {
			//Los valores extremos de las coordenadas del cubo
			double MaximoX = 0.87931543769177811;
			double MinimoX = -0.87931543769177811;
			double MaximoY = 0.87931539875237918;
			double MinimoY = -0.87931539875237918;

			//Las constantes de transformación
			double conX = (XpFin - XpIni) / (MaximoX - MinimoX);
			double conY = (YpFin - YpIni) / (MaximoY - MinimoY);

			for (int cont = 0; cont < poligono.Count; cont++) {
				poligono[cont].CuadraPantalla(conX, conY, 
											   MinimoX, MinimoY,
											   XpIni, YpIni);
			}

			//Ordena del polígono más alejado al más cercano,
			//de esa manera los polígonos de adelante 
			//son visibles y los de atrás son borrados.
			poligono.Sort();
		}


		//Dibuja el cubo
		public void Dibuja(Graphics lienzo, Pen lapiz, Brush relleno) {
			for (int cont = 0; cont < poligono.Count; cont++) {
				poligono[cont].Dibuja(lienzo, lapiz, relleno);
			}
		}
	}

	internal class Poligono : IComparable {
		//Un polígono son cuatro(4) coordenadas espaciales
		public double X1, Y1, Z1, X2, Y2, Z2, X3, Y3, Z3, X4, Y4, Z4;

		//Las coordenadas de giro
		public double X1g, Y1g, Z1g;
		public double X2g, Y2g, Z2g;
		public double X3g, Y3g, Z3g;
		public double X4g, Y4g, Z4g;

		//Las coordenadas planas (segunda dimensión)
		public double X1sd, Y1sd, X2sd, Y2sd, X3sd, Y3sd, X4sd, Y4sd;

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

		//Gira en XYZ
		public void Girar(double[,] Mt) {
			X1g = X1 * Mt[0, 0] + Y1 * Mt[1, 0] + Z1 * Mt[2, 0];
			Y1g = X1 * Mt[0, 1] + Y1 * Mt[1, 1] + Z1 * Mt[2, 1];
			Z1g = X1 * Mt[0, 2] + Y1 * Mt[1, 2] + Z1 * Mt[2, 2];

			X2g = X2 * Mt[0, 0] + Y2 * Mt[1, 0] + Z2 * Mt[2, 0];
			Y2g = X2 * Mt[0, 1] + Y2 * Mt[1, 1] + Z2 * Mt[2, 1];
			Z2g = X2 * Mt[0, 2] + Y2 * Mt[1, 2] + Z2 * Mt[2, 2];

			X3g = X3 * Mt[0, 0] + Y3 * Mt[1, 0] + Z3 * Mt[2, 0];
			Y3g = X3 * Mt[0, 1] + Y3 * Mt[1, 1] + Z3 * Mt[2, 1];
			Z3g = X3 * Mt[0, 2] + Y3 * Mt[1, 2] + Z3 * Mt[2, 2];

			X4g = X4 * Mt[0, 0] + Y4 * Mt[1, 0] + Z4 * Mt[2, 0];
			Y4g = X4 * Mt[0, 1] + Y4 * Mt[1, 1] + Z4 * Mt[2, 1];
			Z4g = X4 * Mt[0, 2] + Y4 * Mt[1, 2] + Z4 * Mt[2, 2];

			Centro = (Z1g + Z2g + Z3g + Z4g) / 4;
		}

		//Convierte de 3D a 2D (segunda dimensión)
		public void Convierte3Da2D(double ZPersona) {
			X1sd = X1g * ZPersona / (ZPersona - Z1g);
			Y1sd = Y1g * ZPersona / (ZPersona - Z1g);

			X2sd = X2g * ZPersona / (ZPersona - Z2g);
			Y2sd = Y2g * ZPersona / (ZPersona - Z2g);

			X3sd = X3g * ZPersona / (ZPersona - Z3g);
			Y3sd = Y3g * ZPersona / (ZPersona - Z3g);

			X4sd = X4g * ZPersona / (ZPersona - Z4g);
			Y4sd = Y4g * ZPersona / (ZPersona - Z4g);
		}

		//Cuadra en pantalla física
		public void CuadraPantalla(double conX, double conY,
									double MinimoX, double MinimoY,
									int XPIni, int YPIni) {
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
			Point[] poligono = [Punto1, Punto2, Punto3, Punto4];
			Lienzo.FillPolygon(Relleno, poligono);
			Lienzo.DrawPolygon(Lapiz, poligono);
		}

		//Usado para ordenar los polígonos
		//del más lejano al más cercano
		//https://stackoverflow.com/questions/3309188/how-to-sort-a-listt-by-a-property-in-the-object
		public int CompareTo(object obj) {
			Poligono Comparar = obj as Poligono;
			if (Comparar.Centro < Centro) return 1;
			if (Comparar.Centro > Centro) return -1;
			return 0;
		}
	}
}
