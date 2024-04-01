namespace Graficos {
	public partial class Form1 : Form {
		public Form1() {
			InitializeComponent();
		}

		private void Form1_Paint(object sender, PaintEventArgs e) {
			Graphics grafico = e.Graphics;
			Pen lapiz = new Pen(Color.Blue, 2);
			Pen lapiz2 = new Pen(Color.Red, 2);
			int variar = 0;

			for (var cont = 1; cont <= 18; cont += 1) {
				grafico.DrawLine(lapiz, 380 - variar, 380 - variar, 380 + variar, 380 - variar);
				grafico.DrawLine(lapiz, 380 - variar, 380 - variar, 380 - variar, 380 + variar);
				grafico.DrawLine(lapiz, 380 + variar, 380 - variar, 380 + variar, 380 + variar);
				variar += 10;

				grafico.DrawLine(lapiz2, 380 - variar, 380 + variar, 380 + variar, 380 + variar);
				grafico.DrawLine(lapiz2, 380 - variar, 380 - variar, 380 - variar, 380 + variar);
				grafico.DrawLine(lapiz2, 380 + variar, 380 - variar, 380 + variar, 380 + variar);
				variar += 10;
			}
		}
	}
}
