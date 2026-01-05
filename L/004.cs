namespace Graficos {
	public partial class Form1 : Form {
		public Form1() {
			InitializeComponent();
		}

		private void Form1_Paint(object sender, PaintEventArgs e) {
			//Lienzo donde va a hacer el gráfico
			Graphics lienzo = e.Graphics;

			//Con qué color se rellenan las figuras
			SolidBrush Relleno = new(Color.Red);

			//===================================
			//Rectángulo: Xpos, Ypos, Ancho, Alto
			//===================================
			lienzo.FillRectangle(Relleno, 100, 100, 200, 150);
		}
	}
}
