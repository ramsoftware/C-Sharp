//Algoritmo de Bresenham, para dibujar líneas rectas rápidamente
namespace Graficos {
	public partial class Form1 : Form {

		public Form1() {
			InitializeComponent();
		}

		public void DibujarLineaRecta(Graphics lienzo, int iniX, int iniY, int finX, int finY) {
			int Contador, Distancia;
			int Xerror=0, Yerror=0, CambioX, CambioY, incrementoX, incrementoY;

			CambioX = finX - iniX;
			CambioY = finY - iniY;

			if (CambioX > 0) incrementoX = 1;
			else if (CambioX == 0) incrementoX = 0;
			else incrementoX = -1;

			if (CambioY > 0) incrementoY = 1;
			else if (CambioY == 0) incrementoY = 0;
			else incrementoY = -1;

			if (CambioX < 0) CambioX *= -1;
			if (CambioY < 0) CambioY *= -1;

			if (CambioX > CambioY)
				Distancia = CambioX;
			else
				Distancia = CambioY;

			for (Contador = 0; Contador <= Distancia + 1; Contador++) {
				lienzo.FillRectangle(Brushes.Black, iniX, iniY, 1, 1);
				Xerror += CambioX;
				Yerror += CambioY;
				if (Xerror > Distancia) {
					Xerror -= Distancia;
					iniX += incrementoX;
				}

				if (Yerror > Distancia) {
					Yerror -= Distancia;
					iniY += incrementoY;
				}
			}
		}

		private void Form1_Paint(object sender, PaintEventArgs e) {
			//Ejemplo
			DibujarLineaRecta(e.Graphics, 16, 83, 197, 206);
		}
	}
}