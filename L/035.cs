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

			//Cálcula el giro
			int posXga = Convert.ToInt32(posXa * Math.Cos(AnguloRadianes) - posYa * Math.Sin(AnguloRadianes));
			int posYga = Convert.ToInt32(posXa * Math.Sin(AnguloRadianes) + posYa * Math.Cos(AnguloRadianes));

			int posXgb = Convert.ToInt32(posXb * Math.Cos(AnguloRadianes) - posYb * Math.Sin(AnguloRadianes));
			int posYgb = Convert.ToInt32(posXb * Math.Sin(AnguloRadianes) + posYb * Math.Cos(AnguloRadianes));

			int posXgc = Convert.ToInt32(posXc * Math.Cos(AnguloRadianes) - posYc * Math.Sin(AnguloRadianes));
			int posYgc = Convert.ToInt32(posXc * Math.Sin(AnguloRadianes) + posYc * Math.Cos(AnguloRadianes));

			//Dibuja el triángulo con el giro
			e.Graphics.DrawLine(Pens.Red, posXga, posYga, posXgb, posYgb);
			e.Graphics.DrawLine(Pens.Red, posXgb, posYgb, posXgc, posYgc);
			e.Graphics.DrawLine(Pens.Red, posXgc, posYgc, posXga, posYga);
		}
	}
}