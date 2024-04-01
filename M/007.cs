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
		//Un cubo tiene 8 coordenadas espaciales X, Y, Z
		private List<Poligono> poligonos;

		//Constructor
		public Cubo() {
			poligonos =
			[
				new Poligono(-0.5, 0.5, -0.5, 0.5, 0.5, -0.5, 0.5, -0.5, -0.5, -0.5, -0.5, -0.5),
				new Poligono(-0.5, 0.5, 0.5, 0.5, 0.5, 0.5, 0.5, -0.5, 0.5, -0.5, -0.5, 0.5),
				new Poligono(-0.5, 0.5, -0.5, -0.5, 0.5, 0.5, -0.5, -0.5, 0.5, -0.5, -0.5, -0.5),
				new Poligono(0.5, 0.5, -0.5, 0.5, 0.5, 0.5, 0.5, -0.5, 0.5, 0.5, -0.5, -0.5),
				new Poligono(-0.5, 0.5, -0.5, 0.5, 0.5, -0.5, 0.5, 0.5, 0.5, -0.5, 0.5, 0.5),
				new Poligono(-0.5, -0.5, -0.5, 0.5, -0.5, -0.5, 0.5, -0.5, 0.5, -0.5, -0.5, 0.5),
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
			double[,] Matriz = new double[3, 3] {
				{ CosY * CosZ, -CosX * SinZ + SinX * SinY * CosZ, SinX * SinZ + CosX * SinY * CosZ},
				{ CosY * SinZ, CosX * CosZ + SinX * SinY * SinZ, -SinX * CosZ + CosX * SinY * SinZ},
				{-SinY, SinX * CosY, CosX * CosY }
			};

			//Gira los 8 polígonos
			for (int cont = 0; cont < poligonos.Count; cont++) {
				poligonos[cont].Girar(Matriz);
			}
		}

		//Convierte de 3D a 2D las coordenadas giradas
		public void Convierte3Da2D(int ZPersona) {
			for (int cont = 0; cont < poligonos.Count; cont++) {
				poligonos[cont].Convierte3Da2D(ZPersona);
			}
		}

		//Convierte las coordenadas planas en coordenadas de pantalla
		public void CuadraPantalla(int XpantallaIni, int YpantallaIni, int XpantallaFin, int YpantallaFin) {
			//Los valores extremos de las coordenadas del cubo
			double MaximoX = 0.87931543769177811;
			double MinimoX = -0.87931543769177811;
			double MaximoY = 0.87931539875237918;
			double MinimoY = -0.87931539875237918;

			//Las constantes de transformación
			double ConstanteX = (XpantallaFin - XpantallaIni) / (MaximoX - MinimoX);
			double ConstanteY = (YpantallaFin - YpantallaIni) / (MaximoY - MinimoY);

			for (int cont = 0; cont < poligonos.Count; cont++) {
				poligonos[cont].CuadraPantalla(ConstanteX, ConstanteY, MinimoX, MinimoY, XpantallaIni, YpantallaIni);
			}

			//Ordena del polígono más alejado al más cercano, de esa manera los polígonos de adelante 
			//son visibles y los de atrás son borrados.
			poligonos.Sort();
		}


		//Dibuja el cubo
		public void Dibuja(Graphics lienzo, Pen lapiz, Brush relleno) {
			for (int cont = 0; cont < poligonos.Count; cont++) {
				poligonos[cont].Dibuja(lienzo, lapiz, relleno);
			}
		}
	}

	internal class Poligono : IComparable {
		//Un polígono son cuatro(4) coordenadas espaciales
		public double X1, Y1, Z1, X2, Y2, Z2, X3, Y3, Z3, X4, Y4, Z4;

		//Las coordenadas de giro
		public double PosX1g, PosY1g, PosZ1g, PosX2g, PosY2g, PosZ2g, PosX3g, PosY3g, PosZ3g, PosX4g, PosY4g, PosZ4g;

		//Las coordenadas planas (segunda dimensión)
		public double X1sd, Y1sd, X2sd, Y2sd, X3sd, Y3sd, X4sd, Y4sd;

		//Las coordenadas en pantalla
		public int X1p, Y1p, X2p, Y2p, X3p, Y3p, X4p, Y4p;

		//Centro del polígono
		public double Centro;

		public Poligono(double X1, double Y1, double Z1, double X2, double Y2, double Z2, double X3, double Y3, double Z3, double X4, double Y4, double Z4) {
			this.X1 = X1; this.Y1 = Y1; this.Z1 = Z1;
			this.X2 = X2; this.Y2 = Y2; this.Z2 = Z2;
			this.X3 = X3; this.Y3 = Y3; this.Z3 = Z3;
			this.X4 = X4; this.Y4 = Y4; this.Z4 = Z4;
		}

		//Gira en XYZ
		public void Girar(double[,] Matriz) {
			PosX1g = X1 * Matriz[0, 0] + Y1 * Matriz[1, 0] + Z1 * Matriz[2, 0];
			PosY1g = X1 * Matriz[0, 1] + Y1 * Matriz[1, 1] + Z1 * Matriz[2, 1];
			PosZ1g = X1 * Matriz[0, 2] + Y1 * Matriz[1, 2] + Z1 * Matriz[2, 2];

			PosX2g = X2 * Matriz[0, 0] + Y2 * Matriz[1, 0] + Z2 * Matriz[2, 0];
			PosY2g = X2 * Matriz[0, 1] + Y2 * Matriz[1, 1] + Z2 * Matriz[2, 1];
			PosZ2g = X2 * Matriz[0, 2] + Y2 * Matriz[1, 2] + Z2 * Matriz[2, 2];

			PosX3g = X3 * Matriz[0, 0] + Y3 * Matriz[1, 0] + Z3 * Matriz[2, 0];
			PosY3g = X3 * Matriz[0, 1] + Y3 * Matriz[1, 1] + Z3 * Matriz[2, 1];
			PosZ3g = X3 * Matriz[0, 2] + Y3 * Matriz[1, 2] + Z3 * Matriz[2, 2];

			PosX4g = X4 * Matriz[0, 0] + Y4 * Matriz[1, 0] + Z4 * Matriz[2, 0];
			PosY4g = X4 * Matriz[0, 1] + Y4 * Matriz[1, 1] + Z4 * Matriz[2, 1];
			PosZ4g = X4 * Matriz[0, 2] + Y4 * Matriz[1, 2] + Z4 * Matriz[2, 2];

			Centro = (PosZ1g + PosZ2g + PosZ3g + PosZ4g) / 4;
		}

		//Convierte de 3D a 2D (segunda dimensión)
		public void Convierte3Da2D(double ZPersona) {
			X1sd = PosX1g * ZPersona / (ZPersona - PosZ1g);
			Y1sd = PosY1g * ZPersona / (ZPersona - PosZ1g);

			X2sd = PosX2g * ZPersona / (ZPersona - PosZ2g);
			Y2sd = PosY2g * ZPersona / (ZPersona - PosZ2g);

			X3sd = PosX3g * ZPersona / (ZPersona - PosZ3g);
			Y3sd = PosY3g * ZPersona / (ZPersona - PosZ3g);

			X4sd = PosX4g * ZPersona / (ZPersona - PosZ4g);
			Y4sd = PosY4g * ZPersona / (ZPersona - PosZ4g);
		}

		//Cuadra en pantalla física
		public void CuadraPantalla(double ConstanteX, double ConstanteY, double MinimoX, double MinimoY, int XPantallaIni, int YPantallaIni) {
			X1p = Convert.ToInt32(ConstanteX * (X1sd - MinimoX) + XPantallaIni);
			Y1p = Convert.ToInt32(ConstanteY * (Y1sd - MinimoY) + YPantallaIni);

			X2p = Convert.ToInt32(ConstanteX * (X2sd - MinimoX) + XPantallaIni);
			Y2p = Convert.ToInt32(ConstanteY * (Y2sd - MinimoY) + YPantallaIni);

			X3p = Convert.ToInt32(ConstanteX * (X3sd - MinimoX) + XPantallaIni);
			Y3p = Convert.ToInt32(ConstanteY * (Y3sd - MinimoY) + YPantallaIni);

			X4p = Convert.ToInt32(ConstanteX * (X4sd - MinimoX) + XPantallaIni);
			Y4p = Convert.ToInt32(ConstanteY * (Y4sd - MinimoY) + YPantallaIni);
		}

		//Hace el gráfico del polígono
		public void Dibuja(Graphics Lienzo, Pen Lapiz, Brush Relleno) {
			//Pone un color de fondo al polígono para borrar lo que hay detrás
			Point Punto1 = new(X1p, Y1p);
			Point Punto2 = new(X2p, Y2p);
			Point Punto3 = new(X3p, Y3p);
			Point Punto4 = new(X4p, Y4p);
			Point[] poligono = [Punto1, Punto2, Punto3, Punto4];
			Lienzo.FillPolygon(Relleno, poligono);
			Lienzo.DrawPolygon(Lapiz, poligono);
		}

		//Usado para ordenar los polígonos del más lejano al más cercano
		//https://stackoverflow.com/questions/3309188/how-to-sort-a-listt-by-a-property-in-the-object
		public int CompareTo(object obj) {
			Poligono Comparar = obj as Poligono;
			if (Comparar.Centro < Centro) return 1;
			if (Comparar.Centro > Centro) return -1;
			return 0;
		}
	}

}
