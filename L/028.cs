namespace Graficos {
	public partial class Form1 : Form {
		public Form1() {
			InitializeComponent();
		}

		private void Form1_Paint(object sender, PaintEventArgs e) {
			Graphics lienzo = e.Graphics;
			Pen lapiz = new(Color.Blue, 2);
			Pen lapiz2 = new(Color.Red, 2);
			int variar = 0;

			for (var cont = 1; cont <= 18; cont += 1) {
				int valA = 380 - variar;
				int valB = 380 + variar;
				lienzo.DrawLine(lapiz, valA, valA, valB, valA);
				lienzo.DrawLine(lapiz, valA, valA, valA, valB);
				lienzo.DrawLine(lapiz, valB, valA, valB, valB);
				variar += 10;

				lienzo.DrawLine(lapiz2, valA, valB, valB, valB);
				lienzo.DrawLine(lapiz2, valA, valA, valA, valB);
				lienzo.DrawLine(lapiz2, valB, valA, valB, valB);
				variar += 10;
			}
		}
	}
}
