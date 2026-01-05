//Traslado de figuras en un plano
namespace Graficos {
	public partial class Form1 : Form {

		public Form1() {
			InitializeComponent();
		}

		private void Form1_Paint(object sender, PaintEventArgs e) {
			Graphics lienzo = e.Graphics;

			//Traslado horizontal
			int mueveX = 0;

			//Traslado vertical
			int mueveY = 0;

			//Nuevas coordenadas
			int posX1 = 10 + mueveX;
			int posX2 = 400 + mueveX;
			int posY1 = 10 + mueveY;
			int posY2 = 250 + mueveY;

			//Dibuja un rectángulo con cuatro líneas
			lienzo.DrawLine(Pens.Black, posX1, posY1, posX2, posY1);
			lienzo.DrawLine(Pens.Black, posX1, posY2, posX2, posY2);
			lienzo.DrawLine(Pens.Black, posX2, posY1, posX2, posY2);
			lienzo.DrawLine(Pens.Black, posX1, posY1, posX1, posY2);
		}
	}
}
