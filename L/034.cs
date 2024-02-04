//Traslado de figuras en un plano
namespace Graficos {
	public partial class Form1 : Form {

		public Form1() {
			InitializeComponent();
		}

		private void Form1_Paint(object sender, PaintEventArgs e) {
			//Traslado horizontal
			int mueveX = 0;

			//Traslado vertical
			int mueveY = 0;

			//Dibuja un rectángulo con cuatro líneas
			e.Graphics.DrawLine(Pens.Black, 10 + mueveX, 10 + mueveY, 400 + mueveX, 10 + mueveY);
			e.Graphics.DrawLine(Pens.Black, 10 + mueveX, 250 + mueveY, 400 + mueveX, 250 + mueveY);
			e.Graphics.DrawLine(Pens.Black, 400 + mueveX, 10 + mueveY, 400 + mueveX, 250 + mueveY);
			e.Graphics.DrawLine(Pens.Black, 10 + mueveX, 10 + mueveY, 10 + mueveX, 250 + mueveY);
		}
	}
}
