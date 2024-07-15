//Giro de figuras en un plano
namespace Graficos {
	public partial class Form1 : Form {

		public Form1() {
			InitializeComponent();
		}

		private void Form1_Paint(object sender, PaintEventArgs e) {
			//Coordenadas de la figura
			int posXa, posYa, posXb, posYb, posXc, posYc;

			posXa = 80;
			posYa = 80;
			posXb = 400;
			posYb = 300;
			posXc = 500;
			posYc = 200;

			//Dibuja un triángulo con tres líneas
			e.Graphics.DrawLine(Pens.Black, posXa, posYa, posXb, posYb);
			e.Graphics.DrawLine(Pens.Black, posXb, posYb, posXc, posYc);
			e.Graphics.DrawLine(Pens.Black, posXc, posYc, posXa, posYa);

			//Ángulo de giro
			int AnguloGiro = 15;
			double AnguloRadianes = AnguloGiro * Math.PI / 180;
			double CosA = Math.Cos(AnguloRadianes);
			double SinA = Math.Sin(AnguloRadianes);

			//Cálcula el giro
			int posXga = Convert.ToInt32(posXa * CosA - posYa * SinA);
			int posYga = Convert.ToInt32(posXa * SinA + posYa * CosA);

			int posXgb = Convert.ToInt32(posXb * CosA - posYb * SinA);
			int posYgb = Convert.ToInt32(posXb * SinA + posYb * CosA);

			int posXgc = Convert.ToInt32(posXc * CosA - posYc * SinA);
			int posYgc = Convert.ToInt32(posXc * SinA + posYc * CosA);

			//Dibuja el triángulo con el giro
			e.Graphics.DrawLine(Pens.Red, posXga, posYga, posXgb, posYgb);
			e.Graphics.DrawLine(Pens.Red, posXgb, posYgb, posXgc, posYgc);
			e.Graphics.DrawLine(Pens.Red, posXgc, posYgc, posXga, posYga);
		}
	}
}