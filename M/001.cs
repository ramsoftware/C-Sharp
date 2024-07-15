namespace Graficos {

	public partial class Form1 : Form {
		public Form1() {
			InitializeComponent();
		}

		private void Form1_Paint(object sender, PaintEventArgs e) {
			Graphics Lienzo = e.Graphics;
			Pen Lapiz = new(Color.Blue, 3);

			//Distancia de la persona (observador)
			//al plano donde se proyecta la "sombra" del cubo
			int ZPersona = 180;

			Cubo Figura3D = new();
			Figura3D.Convierte3Da2D(ZPersona);
			Figura3D.Dibuja(Lienzo, Lapiz);
		}
	}

	internal class Cubo {
		//Un cubo tiene 8 puntos con
		//coordenadas espaciales X, Y, Z
		private List<int> Punto;

		//Luego tiene 8 coordenadas planas
		private List<int> pX;
		private List<int> pY;

		//Constructor
		public Cubo() {
			//Ejemplo de coordenadas
			//espaciales X,Y,Z
			Punto = [
			50, 50, 50,
			100, 50, 50,
			100, 100, 50,
			50, 100, 50,
			50, 50, 100,
			100, 50, 100,
			100, 100, 100,
			50, 100, 100 ];

			pX = [];
			pY = [];
		}

		//Convierte de 3D a 2D
		public void Convierte3Da2D(int ZPersona) {
			for (int cont = 0; cont < Punto.Count; cont += 3) {
				//Extrae las coordenadas espaciales
				int X = Punto[cont];
				int Y = Punto[cont + 1];
				int Z = Punto[cont + 2];

				//Convierte a coordenadas planas
				int Xp = (ZPersona * X) / (ZPersona - Z);
				int Yp = (ZPersona * Y) / (ZPersona - Z);

				//Agrega las coordenadas planas a la lista
				pX.Add(Xp);
				pY.Add(Yp);
			}
		}

		//Dibuja el cubo
		public void Dibuja(Graphics lienzo, Pen lapiz) {
			lienzo.DrawLine(lapiz, pX[0], pY[0], pX[1], pY[1]);
			lienzo.DrawLine(lapiz, pX[1], pY[1], pX[2], pY[2]);
			lienzo.DrawLine(lapiz, pX[2], pY[2], pX[3], pY[3]);
			lienzo.DrawLine(lapiz, pX[3], pY[3], pX[0], pY[0]);

			lienzo.DrawLine(lapiz, pX[4], pY[4], pX[5], pY[5]);
			lienzo.DrawLine(lapiz, pX[5], pY[5], pX[6], pY[6]);
			lienzo.DrawLine(lapiz, pX[6], pY[6], pX[7], pY[7]);
			lienzo.DrawLine(lapiz, pX[7], pY[7], pX[4], pY[4]);

			lienzo.DrawLine(lapiz, pX[0], pY[0], pX[4], pY[4]);
			lienzo.DrawLine(lapiz, pX[1], pY[1], pX[5], pY[5]);
			lienzo.DrawLine(lapiz, pX[2], pY[2], pX[6], pY[6]);
			lienzo.DrawLine(lapiz, pX[3], pY[3], pX[7], pY[7]);
		}
	}
}