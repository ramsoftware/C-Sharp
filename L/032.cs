namespace Graficos {
	public partial class Form1 : Form {
		public Form1() {
			InitializeComponent();
		}

		private void Form1_Paint(object sender, PaintEventArgs e) {
			Graphics grafico = e.Graphics;

			// Lápiz para el color de la línea y con un ancho de 1
			Pen lapiz = new Pen(Color.Blue, 1);

			// Parte superior
			for (int Posicion = 0; Posicion <= 200; Posicion += 20) {
				// Línea requiere:  Lapiz, X1, Y1, X2, Y2
				grafico.DrawLine(lapiz, 200, Posicion, Posicion + 200, 200);
				grafico.DrawLine(lapiz, 200, Posicion, 200 - Posicion, 200);
			}

			//Parte inferior
			for (int Posicion = 400; Posicion >= 200; Posicion += -20) {
				// Línea requiere:  Lapiz, X1, Y1, X2, Y2
				grafico.DrawLine(lapiz, 200, Posicion, 600 - Posicion, 200);
				grafico.DrawLine(lapiz, 200, Posicion, Posicion - 200, 200);
			}
		}
	}
}
