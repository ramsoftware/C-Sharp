namespace Graficos {
	public partial class Form1 : Form {
		public Form1() {
			InitializeComponent();
		}

		private void Form1_Paint(object sender, PaintEventArgs e) {
			//Lienzo donde va a hacer el gráfico
			Graphics lienzo = e.Graphics;

			//Relleno
			SolidBrush Relleno = new SolidBrush(Color.Chocolate);

			//===============================
			//Elipse: Xpos, Ypos, ancho, alto
			//===============================
			lienzo.FillEllipse(Relleno, 200, 30, 250, 90);
		}
	}
}
