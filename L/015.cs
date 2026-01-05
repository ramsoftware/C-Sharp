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

			//================
			//Dibuja un pastel
			//================

			//Crea un rectángulo para la elipse que dibujará el pastel
			Rectangle rectangulo = new(10, 10, 400, 400);

			//Pastel: rectángulo que contiene:
			//ángulo inicial, ángulo de apertura
			lienzo.DrawPie(lapiz, rectangulo, 0F, 45F);
			lienzo.DrawPie(lapiz, rectangulo, 90F, 45F);
			lienzo.DrawPie(lapiz, rectangulo, 150F, 45F);
		}
	}
}