namespace Graficos {
	public partial class Form1 : Form {
		public Form1() {
			InitializeComponent();
		}

		private void Form1_Paint(object sender, PaintEventArgs e) {
			Graphics lienzo = e.Graphics;
			Pen lapiz = new Pen(Color.Blue, 2);
			Pen lapiz2 = new Pen(Color.Red, 2);
			int lim = 500;
			int cont = lim;
			int incremento = 2;

			do {
				int comun = lim - (cont - lim);
				lienzo.DrawLine(lapiz, cont, 10, cont, 200);
				lienzo.DrawLine(lapiz, comun, 10, comun, 200);
				lienzo.DrawLine(lapiz2, cont, 200, cont, 380);
				lienzo.DrawLine(lapiz2, comun, 200, comun, 380);
				incremento++;
				cont += incremento;
			}
			while (cont <= 2 * lim);
		}
	}
}