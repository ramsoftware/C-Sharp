namespace Graficos {
	public partial class Form1 : Form {
		public Form1() {
			InitializeComponent();
		}

		private void Form1_Paint(object sender, PaintEventArgs e) {
			Graphics grafico = e.Graphics;
			Pen lapiz = new Pen(Color.Blue, 2);
			Pen lapiz2 = new Pen(Color.Red, 2);
			int xval = 10;
			int yval = 5;

			do {
				grafico.DrawLine(lapiz, xval, 300 - yval, xval, 300 + yval);
				xval += 5;
				yval += 5;
			}
			while (yval < 300);

			do {
				grafico.DrawLine(lapiz2, xval, 300 - yval, xval, 300 + yval);
				xval += 5;
				yval -= 5;
			}
			while (yval > 0);
		}
	}
}
