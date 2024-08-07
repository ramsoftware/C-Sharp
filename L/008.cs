namespace Graficos {
	public partial class Form1 : Form {
		public Form1() {
			InitializeComponent();
		}

		private void Form1_Paint(object sender, PaintEventArgs e) {
			//Lienzo donde va a hacer el gráfico
			Graphics lienzo = e.Graphics;

			//Con qué color se rellenan las figuras
			SolidBrush Relleno = new SolidBrush(Color.Red);

			//Conjunto de puntos
			PointF p1 = new PointF(150.0F, 150.0F);
			PointF p2 = new PointF(200.0F, 50.0F);
			PointF p3 = new PointF(300.0F, 140.0F);
			PointF p4 = new PointF(400.0F, 200.0F);
			PointF p5 = new PointF(450.0F, 300.0F);
			PointF p6 = new PointF(350.0F, 350.0F);
			PointF p7 = new PointF(300.0F, 150.0F);
			PointF[] Puntos = { p1, p2, p3, p4, p5, p6, p7 };

			//Dibuja el polígono
			lienzo.FillPolygon(Relleno, Puntos);
		}
	}
}