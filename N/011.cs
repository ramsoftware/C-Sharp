namespace Animacion {
	public partial class Form1 : Form {
		//Para la variable temporal
		private double Tminimo, Tmaximo, Tincrementa, Tiempo;

		//El objeto que se encarga de calcular y cuadrar en pantalla la ecuación polar
		Grafico Grafico3D;

		//Para el movimiento aleatorio del gráfico 3D
		private int AnguloX, AnguloY, AnguloZ;
		private int IncrAngX, IncrAngY, IncrAngZ;

		private int AnguloXNuevo, AnguloYNuevo, AnguloZNuevo;
		Random Azar;

		public Form1() {
			InitializeComponent();
			Grafico3D = new Grafico();

			//Ángulos aleatorios para simular animación
			Azar = new Random();
			AnguloX = Azar.Next(0, 360);
			AnguloY = Azar.Next(0, 360);
			AnguloZ = Azar.Next(0, 360);
			AnguloXNuevo = Azar.Next(0, 360);
			AnguloYNuevo = Azar.Next(0, 360);
			AnguloZNuevo = Azar.Next(0, 360);

			//Variable Tiempo
			Tminimo = 0.2;
			Tmaximo = 1.2;
			Tincrementa = 0.05;
			Tiempo = Tminimo;
		}

		//Pinta el gráfico generado por la ecuación
		private void Form1_Paint(object sender, PaintEventArgs e) {
			Graphics Lienzo = e.Graphics;
			Pen Lapiz = new Pen(Color.Black, 1);
			Brush Relleno = new SolidBrush(Color.White);

			int NumeroLineasGrafico = 70;
			Grafico3D.CalculaEcuacion(NumeroLineasGrafico, Tiempo);

			int ZPersona = 5;
			int XPantallaIni = 0;
			int YPantallaIni = 0;
			int XPantallaFin = 800;
			int YPantallaFin = 800;

			//Después de los cálculos, entonces aplica giros, conversión a 2D y cuadrar en pantalla
			Grafico3D.CalculaGrafico(AnguloX, AnguloY, AnguloZ, ZPersona, XPantallaIni, YPantallaIni, XPantallaFin, YPantallaFin);
			Grafico3D.Dibuja(Lienzo, Lapiz, Relleno);
		}

		private void timer1_Tick(object sender, EventArgs e) {
			//Cambia los ángulos de giro
			if (AnguloX > AnguloXNuevo) IncrAngX = -1; else IncrAngX = 1;
			if (AnguloY > AnguloYNuevo) IncrAngY = -1; else IncrAngY = 1;
			if (AnguloZ > AnguloZNuevo) IncrAngZ = -1; else IncrAngZ = 1;

			AnguloX += IncrAngX;
			AnguloY += IncrAngY;
			AnguloZ += IncrAngZ;

			if (AnguloX == AnguloXNuevo) AnguloXNuevo = Azar.Next(0, 360);
			if (AnguloY == AnguloYNuevo) AnguloYNuevo = Azar.Next(0, 360);
			if (AnguloZ == AnguloZNuevo) AnguloZNuevo = Azar.Next(0, 360);

			//Cambia el valor de la variable tiempo
			Tiempo += Tincrementa;
			if (Tiempo <= Tminimo || Tiempo >= Tmaximo) Tincrementa = -Tincrementa;

			Refresh();
		}
	}

	internal class Grafico {

		//Donde almacena los poligonos
		private List<Poligono> Poligonos;

		public void CalculaEcuacion(int NumeroLineasGrafico, double Tiempo) {
			//Inicia el listado de polígonos que forma la figura			 
			Poligonos = [];

			//Mínimos y máximos para normalizar
			double MinimoX = double.MaxValue;
			double MaximoX = double.MinValue;
			double MinimoY = double.MaxValue;
			double MaximoY = double.MinValue;
			double MinimoZ = double.MaxValue;
			double MaximoZ = double.MinValue;

			//Calcula cada polígono dependiendo de la ecuación
			double MinTheta = 0, MaxTheta = 360, MinPhi = 0, MaxPhi = 360;

			double IncTheta = (MaxTheta - MinTheta) / NumeroLineasGrafico;
			double IncPhi = (MaxPhi - MinPhi) / NumeroLineasGrafico;

			for (double valTheta = MinTheta; valTheta <= MaxTheta; valTheta += IncTheta)
				for (double valPhi = MinPhi; valPhi <= MaxPhi; valPhi += IncPhi) {

					//Calcula los 4 valores del eje Z del polígono
					double Theta1 = valTheta * Math.PI / 180;
					double Phi1 = valPhi * Math.PI / 180;
					double R1 = Ecuacion(Theta1, Phi1, Tiempo);
					if (double.IsNaN(R1) || double.IsInfinity(R1)) R1 = 0;
					double X1 = R1 * Math.Cos(Phi1) * Math.Sin(Theta1);
					double Y1 = R1 * Math.Sin(Phi1) * Math.Sin(Theta1);
					double Z1 = R1 * Math.Cos(Theta1);

					double Theta2 = (valTheta + IncTheta) * Math.PI / 180;
					double Phi2 = valPhi * Math.PI / 180;
					double R2 = Ecuacion(Theta2, Phi2, Tiempo);
					if (double.IsNaN(R2) || double.IsInfinity(R2)) R2 = 0;
					double X2 = R2 * Math.Cos(Phi2) * Math.Sin(Theta2);
					double Y2 = R2 * Math.Sin(Phi2) * Math.Sin(Theta2);
					double Z2 = R2 * Math.Cos(Theta2);

					double Theta3 = (valTheta + IncTheta) * Math.PI / 180;
					double Phi3 = (valPhi + IncPhi) * Math.PI / 180;
					double R3 = Ecuacion(Theta3, Phi3, Tiempo);
					if (double.IsNaN(R3) || double.IsInfinity(R3)) R3 = 0;
					double X3 = R3 * Math.Cos(Phi3) * Math.Sin(Theta3);
					double Y3 = R3 * Math.Sin(Phi3) * Math.Sin(Theta3);
					double Z3 = R3 * Math.Cos(Theta3);

					double Theta4 = valTheta * Math.PI / 180;
					double Phi4 = (valPhi + IncPhi) * Math.PI / 180;
					double R4 = Ecuacion(Theta4, Phi4, Tiempo);
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
					if (Math.Abs(MaximoZ - MinimoZ) > 0.00001)
						Poligonos.Add(new Poligono(X1, Y1, Z1, X2, Y2, Z2, X3, Y3, Z3, X4, Y4, Z4));
				}

			//Luego normaliza los puntos X,Y,Z para que queden entre -0.5 y 0.5
			for (int cont = 0; cont < Poligonos.Count; cont++) Poligonos[cont].Normaliza(MinimoX, MinimoY, MinimoZ, MaximoX, MaximoY, MaximoZ);

		}

		//Aquí está la ecuación polar 3D que se desee graficar con variable Theta, PHI y Tiempo
		public double Ecuacion(double Theta, double Phi, double Tiempo) {
			return 2 * Math.Sin(Phi + Tiempo) - Math.Sin(Theta - Tiempo);
		}

		public void CalculaGrafico(double AngX, double AngY, double AngZ, int ZPersona, int XPantallaIni, int YPantallaIni, int XPantallaFin, int YPantallaFin) {

			//Genera la matriz de rotación
			double CosX = Math.Cos(AngX * Math.PI / 180);
			double SinX = Math.Sin(AngX * Math.PI / 180);
			double CosY = Math.Cos(AngY * Math.PI / 180);
			double SinY = Math.Sin(AngY * Math.PI / 180);
			double CosZ = Math.Cos(AngZ * Math.PI / 180);
			double SinZ = Math.Sin(AngZ * Math.PI / 180);

			//Matriz de Rotación: https://en.wikipedia.org/wiki/Rotation_formalisms_in_three_dimensions
			double[,] Matriz = new double[3, 3] {
				{ CosY * CosZ, -CosX * SinZ + SinX * SinY * CosZ, SinX * SinZ + CosX * SinY * CosZ},
				{ CosY * SinZ, CosX * CosZ + SinX * SinY * SinZ, -SinX * CosZ + CosX * SinY * SinZ},
				{-SinY, SinX * CosY, CosX * CosY }
			};

			//Los valores extremos al girar la figura en X, Y, Z (de 0 a 360 grados), porque está contenida en un cubo de 1*1*1
			double MaximoX = 0.87931543769177811;
			double MinimoX = -0.87931543769177811;
			double MaximoY = 0.87931543769177811;
			double MinimoY = -0.87931543769177811;

			//Las constantes de transformación
			double ConstanteX = (XPantallaFin - XPantallaIni) / (MaximoX - MinimoX);
			double ConstanteY = (YPantallaFin - YPantallaIni) / (MaximoY - MinimoY);

			//Gira los polígonos, proyecta a 2D y cuadra en pantalla
			for (int cont = 0; cont < Poligonos.Count; cont++)
				Poligonos[cont].CalculoPantalla(Matriz, ZPersona, ConstanteX, ConstanteY, MinimoX, MinimoY, XPantallaIni, YPantallaIni);

			//Ordena del polígono más alejado al más cercano, de esa manera los polígonos de adelante son visibles y los de atrás son borrados.
			Poligonos.Sort();
		}

		//Dibuja el polígono
		public void Dibuja(Graphics Lienzo, Pen Lapiz, Brush Relleno) {
			for (int Cont = 0; Cont < Poligonos.Count; Cont++)
				Poligonos[Cont].Dibuja(Lienzo, Lapiz, Relleno);
		}
	}

	internal class Poligono : IComparable {
		//Un polígono son cuatro(4) coordenadas espaciales
		public double X1, Y1, Z1, X2, Y2, Z2, X3, Y3, Z3, X4, Y4, Z4;

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

		//Normaliza puntos polígono entre -0.5 y 0.5
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

			//Usado para ordenar los polígonos del más lejano al más cercano
			Centro = (PosZ1g + PosZ2g + PosZ3g + PosZ4g) / 4;

			//Convierte de 3D a 2D (segunda dimensión)
			double X1sd = PosX1g * ZPersona / (ZPersona - PosZ1g);
			double Y1sd = PosY1g * ZPersona / (ZPersona - PosZ1g);

			double X2sd = PosX2g * ZPersona / (ZPersona - PosZ2g);
			double Y2sd = PosY2g * ZPersona / (ZPersona - PosZ2g);

			double X3sd = PosX3g * ZPersona / (ZPersona - PosZ3g);
			double Y3sd = PosY3g * ZPersona / (ZPersona - PosZ3g);

			double X4sd = PosX4g * ZPersona / (ZPersona - PosZ4g);
			double Y4sd = PosY4g * ZPersona / (ZPersona - PosZ4g);

			//Cuadra en pantalla física
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
			Point[] ListaPuntos = [Punto1, Punto2, Punto3, Punto4];

			//Dibuja el polígono relleno y su perímetro
			Lienzo.FillPolygon(Relleno, ListaPuntos);
			Lienzo.DrawPolygon(Lapiz, ListaPuntos);
		}

		//Usado para ordenar los polígonos del más lejano al más cercano
		public int CompareTo(object obj) {
			Poligono OrdenCompara = obj as Poligono;
			if (OrdenCompara.Centro < Centro) return 1;
			if (OrdenCompara.Centro > Centro) return -1;
			return 0;
			//https://stackoverflow.com/questions/3309188/how-to-sort-a-listt-by-a-property-in-the-object
		}
	}
}