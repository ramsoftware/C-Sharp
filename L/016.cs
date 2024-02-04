namespace Graficos {
	public partial class Form1 : Form {
		public Form1() {
			InitializeComponent();
		}

		private void Form1_Paint(object sender, PaintEventArgs e) {
			//Lienzo donde va a hacer el gráfico
			Graphics lienzo = e.Graphics;

			//Rellenos
			SolidBrush Relleno1 = new SolidBrush(Color.Chocolate);
			SolidBrush Relleno2 = new SolidBrush(Color.Red);
			SolidBrush Relleno3 = new SolidBrush(Color.Blue);

			//================
			//Dibuja un pastel
			//================

			//Crea un rectángulo para la elipse que dibujará el pastel
			Rectangle rectangulo = new Rectangle(10, 10, 400, 400);

			//Pastel: rectángulo que contiene, ángulo inicial, ángulo de apertura
			lienzo.FillPie(Relleno1, rectangulo, 0F, 45F);
			lienzo.FillPie(Relleno2, rectangulo, 90F, 45F);
			lienzo.FillPie(Relleno3, rectangulo, 150F, 45F);
		}
	}
}
