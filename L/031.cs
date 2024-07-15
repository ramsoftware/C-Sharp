namespace Graficos {
	public partial class Form1 : Form {
		public Form1() {
			InitializeComponent();
		}

		private void Form1_Paint(object sender, PaintEventArgs e) {
			// Necesario para los gráficos GDI+
			Graphics grafico = e.Graphics;

			// Lápiz para el color de la línea y con un ancho de 1
			Pen lapiz = new Pen(Color.Blue, 1);

			for (int Fila = 0; Fil <= 10; Fil++) {
				for (int Col = 0; Col <= 10; Col++){
					int valA = Fil * 35 + 80;
					int valB = Col * 35 + 40;
					grafico.DrawRectangle(lapiz, valA, valB, 30, 30);
				}
			}
		}
	}
}
