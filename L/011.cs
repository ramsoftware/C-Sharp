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

			//Conjunto de Puntos
			PointF p1 = new(150.0F, 150.0F);
			PointF p2 = new(200.0F, 50.0F);
			PointF p3 = new(300.0F, 140.0F);
			PointF p4 = new(400.0F, 200.0F);
			PointF p5 = new(450.0F, 300.0F);
			PointF p6 = new(350.0F, 350.0F);
			PointF p7 = new(300.0F, 150.0F);
			PointF[] Puntos = { p1, p2, p3, p4, p5, p6, p7 };

			//Dibuja la curva que une esos puntos
			lienzo.DrawCurve(lapiz, Puntos);
		}
	}
}