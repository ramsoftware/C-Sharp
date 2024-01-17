namespace Graficos {
	public partial class Form1 : Form {
		public Form1() {
			InitializeComponent();
		}

		private void Form1_Paint(object sender, PaintEventArgs e) {
			//Lienzo donde va a hacer el gráfico
			Graphics lienzo = e.Graphics;

			//Lápiz con que dibuja. Color, grosor
			Pen lapiz = new Pen(Color.Blue, 2);

			//===================================
			//Rectángulo: Xpos, Ypos, Ancho, Alto
			//===================================
			lienzo.DrawRectangle(lapiz, 100, 100, 200, 150);
		}
	}
}
