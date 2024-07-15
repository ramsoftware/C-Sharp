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

			int variar = 0;
			int centro = 380;

			for (var cont = 1; cont <= 30; cont += 1) {
				int valA = centro - variar;
				int valB = centro + variar;
				grafico.DrawLine(lapizA, valA, valA, valB, valA);
				grafico.DrawLine(lapizB, valA, valA, valA, valB);
				grafico.DrawLine(lapizC, valB, valA, valB, valB);
				grafico.DrawLine(lapizD, valA, valB, valB, valB);
				variar += 10;
			}
		}
	}
}
