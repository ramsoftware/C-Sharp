namespace Graficos {
	public partial class Form1 : Form {
		public Form1() {
			InitializeComponent();
		}

		private void Form1_Paint(object sender, PaintEventArgs e) {
			Graphics grafico = e.Graphics;
			Pen lapiz = new Pen(Color.Blue, 2);
			Pen lapiz2 = new Pen(Color.Red, 2);
			int limite = 500;
			int contador = limite;
			int incremento = 2;

			do {
				grafico.DrawLine(lapiz, contador, 10, contador, 200);
				grafico.DrawLine(lapiz, limite - (contador - limite), 10, limite - (contador - limite), 200);
				grafico.DrawLine(lapiz2, contador, 200, contador, 380);
				grafico.DrawLine(lapiz2, limite - (contador - limite), 200, limite - (contador - limite), 380);
				incremento++;
				contador += incremento;
			}
			while (contador <= 2 * limite);
		}
	}
}

