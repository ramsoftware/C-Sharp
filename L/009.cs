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

			//Conjunto de Puntos
			PointF punto1 = new PointF(150.0F, 150.0F);
			PointF punto2 = new PointF(200.0F, 50.0F);
			PointF punto3 = new PointF(300.0F, 140.0F);
			PointF punto4 = new PointF(400.0F, 200.0F);
			PointF punto5 = new PointF(450.0F, 300.0F);
			PointF punto6 = new PointF(350.0F, 350.0F);
			PointF punto7 = new PointF(300.0F, 150.0F);
			PointF[] Puntos = { punto1, punto2, punto3, punto4, punto5, punto6, punto7 };

			//Dibuja una curva cerrada que une esos puntos
			lienzo.DrawClosedCurve(lapiz, Puntos);
		}
	}
}
