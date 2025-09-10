namespace Graficos {
	public partial class Form1 : Form {
		public Form1() {
			InitializeComponent();
		}

		private void Form1_Paint(object sender, PaintEventArgs e) {
			//Lienzo donde va a hacer el gráfico
			Graphics lienzo = e.Graphics;

			//Lápiz con que dibuja. Color, grosor
			Pen lapiz = new(Color.Blue, 2);

			//============================================
			//Dibujar una Curva de Bézier
			//============================================
			Point P0 = new(100, 180);
			Point P1 = new(200, 10);
			Point P2 = new(350, 50);
			Point P3 = new(500, 180);
			lienzo.DrawBezier(lapiz, P0, P1, P2, P3);
		}
	}
}
