namespace Graficos {
	public partial class Form1 : Form {
		public Form1() {
			InitializeComponent();
		}

		private void Form1_Paint(object sender, PaintEventArgs e) {
			Graphics grafico = e.Graphics;
			Pen lapiz = new Pen(Color.Blue, 2);
			Pen lapiz2 = new Pen(Color.Red, 2);
			int xval = 0;
			int yval = 300;

			do {
				grafico.DrawLine(lapiz, xval, 300 - yval, xval, 300 + yval);
				xval += 5;
				yval -= 5;
			}
			while (yval >= 0);

			xval = 300;
			yval = 600;
			do {
				grafico.DrawLine(lapiz2, 300 - xval, yval, 300 + xval, yval);
				xval -= 5;
				yval -= 5;
			}
			while (yval >= 300);
		}
	}
}
