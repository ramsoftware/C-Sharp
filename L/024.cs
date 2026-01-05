namespace Graficos {
	public partial class Form1 : Form {
		public Form1() {
			InitializeComponent();
		}

		private void Form1_Paint(object sender, PaintEventArgs e) {
			Graphics grafico = e.Graphics;
			Pen lapiz = new(Color.Blue, 2);

			int pX1, pY1, pX2, pY2, pX3, pY3, constante;
			pX1 = 420;
			pY1 = 360;
			pX2 = 480;
			pY2 = 400;
			pX3 = 420;
			pY3 = 440;
			constante = 20;
			do {
				grafico.DrawLine(lapiz, pX1, pY1, pX2, pY2);
				grafico.DrawLine(lapiz, pX2, pY2, pX3, pY3);
				grafico.DrawLine(lapiz, pX1, pY1, pX3, pY3);
				pX1 -= constante;
				pY1 -= constante;
				pX2 += constante;
				pX3 -= constante;
				pY3 += constante;
			}
			while (pY1 >= 0);
		}
	}
}
