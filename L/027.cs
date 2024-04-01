namespace Graficos {
	public partial class Form1 : Form {
		public Form1() {
			InitializeComponent();
		}

		private void Form1_Paint(object sender, PaintEventArgs e) {
			Graphics grafico = e.Graphics;
			Pen lapizA = new Pen(Color.Blue, 2);
			Pen lapizB = new Pen(Color.Red, 2);
			Pen lapizC = new Pen(Color.Chocolate, 2);
			Pen lapizD = new Pen(Color.DarkGreen, 2);

			int variar, centro;
			variar = 0;
			centro = 380;

			for (var cont = 1; cont <= 30; cont += 1) {
				grafico.DrawLine(lapizA, centro - variar, centro - variar, centro - variar + variar * 2, centro - variar);
				grafico.DrawLine(lapizB, centro - variar, centro - variar, centro - variar, centro - variar + variar * 2);
				grafico.DrawLine(lapizC, centro - variar + variar * 2, centro - variar, centro - variar + variar * 2, centro - variar + variar * 2);
				grafico.DrawLine(lapizD, centro - variar, centro - variar + variar * 2, centro - variar + variar * 2, centro - variar + variar * 2);
				variar = variar + 10;
			}
		}
	}
}
