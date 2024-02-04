//Giro de figuras en un plano calculando el centroide
namespace Graficos {
	public partial class Form1 : Form {

		public Form1() {
			InitializeComponent();
		}

		private void Form1_Paint(object sender, PaintEventArgs e) {
			//Datos del rectángulo
			int posXa, posYa, Largo, Alto;
			posXa = 80;
			posYa = 80;
			Largo = 400;
			Alto = 180;

			//Deduce las otras tres coordenadas del rectángulo
			int posXb, posYb, posXc, posYc, posXd, posYd;
			posXb = posXa + Largo;
			posYb = posYa;
			posXc = posXa + Largo;
			posYc = posYa + Alto;
			posXd = posXa;
			posYd = posYa + Alto;

			//Dibuja un rectángulo con cuatro líneas
			e.Graphics.DrawLine(Pens.Black, posXa, posYa, posXb, posYb);
			e.Graphics.DrawLine(Pens.Black, posXb, posYb, posXc, posYc);
			e.Graphics.DrawLine(Pens.Black, posXc, posYc, posXd, posYd);
			e.Graphics.DrawLine(Pens.Black, posXd, posYd, posXa, posYa);

			//Ángulo de giro
			int AnguloGiro = 15;
			double AnguloRadianes = AnguloGiro * Math.PI / 180;

			//Centroide
			int posXcentro = posXa + Largo / 2;
			int posYcentro = posYa + Alto / 2;

			//Cálcula el giro
			int posXga = Convert.ToInt32(posXa * Math.Cos(AnguloRadianes) - posYa * Math.Sin(AnguloRadianes));
			int posYga = Convert.ToInt32(posXa * Math.Sin(AnguloRadianes) + posYa * Math.Cos(AnguloRadianes));

			int posXgb = Convert.ToInt32(posXb * Math.Cos(AnguloRadianes) - posYb * Math.Sin(AnguloRadianes));
			int posYgb = Convert.ToInt32(posXb * Math.Sin(AnguloRadianes) + posYb * Math.Cos(AnguloRadianes));

			int posXgc = Convert.ToInt32(posXc * Math.Cos(AnguloRadianes) - posYc * Math.Sin(AnguloRadianes));
			int posYgc = Convert.ToInt32(posXc * Math.Sin(AnguloRadianes) + posYc * Math.Cos(AnguloRadianes));

			int posXgd = Convert.ToInt32(posXd * Math.Cos(AnguloRadianes) - posYd * Math.Sin(AnguloRadianes));
			int posYgd = Convert.ToInt32(posXd * Math.Sin(AnguloRadianes) + posYd * Math.Cos(AnguloRadianes));

			//Giro del centroide
			int posXgcentro = Convert.ToInt32(posXcentro * Math.Cos(AnguloRadianes) - posYcentro * Math.Sin(AnguloRadianes));
			int posYgcentro = Convert.ToInt32(posXcentro * Math.Sin(AnguloRadianes) + posYcentro * Math.Cos(AnguloRadianes));

			//¿Cuánto se desplazo el centroide?
			int desplazaX = posXgcentro - posXcentro;
			int desplazaY = posYgcentro - posYcentro;

			//Dibuja el triángulo con el giro
			e.Graphics.DrawLine(Pens.Red, posXga - desplazaX, posYga - desplazaY, posXgb - desplazaX, posYgb - desplazaY);
			e.Graphics.DrawLine(Pens.Red, posXgb - desplazaX, posYgb - desplazaY, posXgc - desplazaX, posYgc - desplazaY);
			e.Graphics.DrawLine(Pens.Red, posXgc - desplazaX, posYgc - desplazaY, posXgd - desplazaX, posYgd - desplazaY);
			e.Graphics.DrawLine(Pens.Red, posXga - desplazaX, posYga - desplazaY, posXgd - desplazaX, posYgd - desplazaY);
		}
	}
}