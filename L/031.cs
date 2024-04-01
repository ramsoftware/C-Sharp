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

			for (int Fila = 0; Fila <= 10; Fila++) {
				for (int Columna = 0; Columna <= 10; Columna++)
					grafico.DrawRectangle(lapiz, Fila * 35 + 80, Columna * 35 + 40, 30, 30);
			}
		}
	}
}
