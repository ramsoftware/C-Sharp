//Giro de figuras en un plano calculando el centroide
namespace Graficos {
	public partial class Form1 : Form {

		public Form1() {
			InitializeComponent();
		}

		private void Form1_Paint(object sender, PaintEventArgs e) {
			Graphics lienzo = e.Graphics;
			Pen lapizA = new(Color.Black, 1);
			pen lapizB = new(Color.Red, 2);
			
			//Datos del rectángulo
			int Xa, Ya, Largo, Alto;
			Xa = 80;
			Ya = 80;
			Largo = 400;
			Alto = 180;

			//Deduce las otras tres coordenadas del rectángulo
			int Xb, Yb, Xc, Yc, Xd, Yd;
			Xb = Xa + Largo;
			Yb = Ya;
			Xc = Xa + Largo;
			Yc = Ya + Alto;
			Xd = Xa;
			Yd = Ya + Alto;

			//Dibuja un rectángulo con cuatro líneas
			lienzo.DrawLine(lapizA, Xa, Ya, Xb, Yb);
			lienzo.DrawLine(lapizA, Xb, Yb, Xc, Yc);
			lienzo.DrawLine(lapizA, Xc, Yc, Xd, Yd);
			lienzo.DrawLine(lapizA, Xd, Yd, Xa, Ya);

			//Ángulo de giro
			int AnguloGiro = 15;
			double AnguloRadianes = AnguloGiro * Math.PI / 180;
			double CosA = Math.Cos(AnguloRadianes);
			double SinA = Math.Sin(AnguloRadianes);

			//Centroide
			int Xcentro = Xa + Largo / 2;
			int Ycentro = Ya + Alto / 2;

			//Cálcula el giro
			int Xga = Convert.ToInt32(Xa * CosA - Ya * SinA);
			int Yga = Convert.ToInt32(Xa * SinA + Ya * CosA);

			int Xgb = Convert.ToInt32(Xb * CosA - Yb * SinA);
			int Ygb = Convert.ToInt32(Xb * SinA + Yb * CosA);

			int Xgc = Convert.ToInt32(Xc * CosA - Yc * SinA);
			int Ygc = Convert.ToInt32(Xc * SinA + Yc * CosA);

			int Xgd = Convert.ToInt32(Xd * CosA - Yd * SinA);
			int Ygd = Convert.ToInt32(Xd * SinA + Yd * CosA);

			//Giro del centroide
			int Xgcentro = Convert.ToInt32(Xcentro * CosA - Ycentro * SinA);
			int Ygcentro = Convert.ToInt32(Xcentro * SinA + Ycentro * CosA);

			//¿Cuánto se desplazo el centroide?
			int dX = Xgcentro - Xcentro;
			int dY = Ygcentro - Ycentro;

			//Dibuja el triángulo con el giro
			lienzo.DrawLine(lapizB, Xga - dX, Yga - dY, Xgb - dX, Ygb - dY);
			lienzo.DrawLine(lapizB, Xgb - dX, Ygb - dY, Xgc - dX, Ygc - dY);
			lienzo.DrawLine(lapizB, Xgc - dX, Ygc - dY, Xgd - dX, Ygd - dY);
			lienzo.DrawLine(lapizB, Xga - dX, Yga - dY, Xgd - dX, Ygd - dY);
		}
	}
}