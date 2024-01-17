namespace Graficos {
	public partial class Form1 : Form {
		public Form1() {
			InitializeComponent();
		}

		private void Form1_Paint(object sender, PaintEventArgs e) {
			Graphics grafico = e.Graphics;
			Pen lapiz;
			Pen lapizRojo = new Pen(Color.Red, 2);
			Pen lapizAzul = new Pen(Color.Blue, 2);

			int pX1, pY1, pX2, pY2, pX3, pY3, constante, cambia;
			pX1 = 220;
			pY1 = 360;
			pX2 = 160;
			pY2 = 400;
			pX3 = 220;
			pY3 = 440;
			constante = 30;
			cambia = 1;
			do {
				if (cambia == 1) {
					cambia = 2;
					lapiz = lapizAzul;
				}
				else {
					cambia = 1;
					lapiz = lapizRojo;
				}

				grafico.DrawLine(lapiz, pX1, pY1, pX2, pY2);
				grafico.DrawLine(lapiz, pX2, pY2, pX3, pY3);
				grafico.DrawLine(lapiz, pX1, pY1, pX3, pY3);
				pX1 += constante;
				pY1 -= constante;
				pX2 += constante;
				pX3 += constante;
				pY3 += constante;
			}
			while (pY1 >= 0);
		}
	}
}
