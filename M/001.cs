namespace Graficos {

	public partial class Form1 : Form {
		public Form1() {
			InitializeComponent();
		}

		private void Form1_Paint(object sender, PaintEventArgs e) {
			Graphics Lienzo = e.Graphics;
			Pen Lapiz = new(Color.Blue, 3);

			//Distancia de la persona (observador) al plano donde se proyecta la "sombra" del cubo
			int ZPersona = 180;

			Cubo Figura3D = new();
			Figura3D.Convierte3Da2D(ZPersona);
			Figura3D.Dibuja(Lienzo, Lapiz);
		}
	}

	internal class Cubo {
		//Un cubo tiene 8 coordenadas espaciales X, Y, Z
		private List<int> Coordenadas;

		//Luego tiene 8 coordenadas planas
		private List<int> PlanoX;
		private List<int> PlanoY;

		//Constructor
		public Cubo() {
			//Ejemplo de coordenadas espaciales X,Y,Z
			Coordenadas = [
			50, 50, 50,
			100, 50, 50,
			100, 100, 50,
			50, 100, 50,
			50, 50, 100,
			100, 50, 100,
			100, 100, 100,
			50, 100, 100 ];

			PlanoX = [];
			PlanoY = [];
		}

		//Convierte de 3D a 2D
		public void Convierte3Da2D(int ZPersona) {
			for (int cont = 0; cont < Coordenadas.Count; cont += 3) {
				//Extrae las coordenadas espaciales
				int X = Coordenadas[cont];
				int Y = Coordenadas[cont + 1];
				int Z = Coordenadas[cont + 2];

				//Convierte a coordenadas planas
				int Xp = (ZPersona * X) / (ZPersona - Z);
				int Yp = (ZPersona * Y) / (ZPersona - Z);

				//Agrega las coordenadas planas a la lista
				PlanoX.Add(Xp);
				PlanoY.Add(Yp);
			}
		}

		//Dibuja el cubo
		public void Dibuja(Graphics lienzo, Pen lapiz) {
			lienzo.DrawLine(lapiz, PlanoX[0], PlanoY[0], PlanoX[1], PlanoY[1]);
			lienzo.DrawLine(lapiz, PlanoX[1], PlanoY[1], PlanoX[2], PlanoY[2]);
			lienzo.DrawLine(lapiz, PlanoX[2], PlanoY[2], PlanoX[3], PlanoY[3]);
			lienzo.DrawLine(lapiz, PlanoX[3], PlanoY[3], PlanoX[0], PlanoY[0]);

			lienzo.DrawLine(lapiz, PlanoX[4], PlanoY[4], PlanoX[5], PlanoY[5]);
			lienzo.DrawLine(lapiz, PlanoX[5], PlanoY[5], PlanoX[6], PlanoY[6]);
			lienzo.DrawLine(lapiz, PlanoX[6], PlanoY[6], PlanoX[7], PlanoY[7]);
			lienzo.DrawLine(lapiz, PlanoX[7], PlanoY[7], PlanoX[4], PlanoY[4]);

			lienzo.DrawLine(lapiz, PlanoX[0], PlanoY[0], PlanoX[4], PlanoY[4]);
			lienzo.DrawLine(lapiz, PlanoX[1], PlanoY[1], PlanoX[5], PlanoY[5]);
			lienzo.DrawLine(lapiz, PlanoX[2], PlanoY[2], PlanoX[6], PlanoY[6]);
			lienzo.DrawLine(lapiz, PlanoX[3], PlanoY[3], PlanoX[7], PlanoY[7]);
		}
	}
}