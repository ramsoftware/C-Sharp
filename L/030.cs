namespace Graficos {
	public partial class Form1 : Form {
		public Form1() {
			InitializeComponent();
		}

		private void Form1_Paint(object sender, PaintEventArgs e) {
			Graphics grafico = e.Graphics;
			Pen lapiz = new(Color.Blue, 2);
			Pen lapiz2 = new(Color.Red, 2);
			Pen lapiz3 = new(Color.Green, 2);
			Pen lapiz4 = new(Color.Violet, 2);
			int cont = 0;

			do {
				grafico.DrawLine(lapiz, cont, 600, 600, cont);
				grafico.DrawLine(lapiz2, 1200 - cont, 600, 600, cont);
				grafico.DrawLine(lapiz3, 1200 - cont, 0, 600, 600 - cont);
				grafico.DrawLine(lapiz4, cont, 0, 600, 600 - cont);
				cont += 20;
			}
			while (cont <= 600);
		}
	}
}