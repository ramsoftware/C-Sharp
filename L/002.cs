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

			//===========================================================
			//Arco: Xpos, Ypos, Ancho, Alto, Ángulo Inicial, Ángulo Final
			//===========================================================
			lienzo.DrawArc(lapiz, 10, 90, 160, 170, 0, 270);
		}
	}
}
