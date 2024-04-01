namespace Ejemplo {
	internal class Program {
		static void Main() {
			double X = 1; //valor inicial
			double Yini = Ecuacion(X);
			double Variacion = 1;

			while (Math.Abs(Variacion) > 0.00001) {
				double Ysigue = Ecuacion(X + Variacion);

				//Si en vez de disminuir Y, lo que hace es aumentar, cambia de dirección a un paso menor
				if (Ysigue > Yini) {
					Variacion *= -1;
					Variacion /= 10;
				}
				else { //Está disminuyendo Y
					Yini = Ysigue;
					X += Variacion;
					Console.WriteLine("X: " + X.ToString() + " Y:" + Yini.ToString());
				}
			}
			Console.WriteLine("Respuesta: " + X.ToString());
		}

		//Ecuación a analizar
		static double Ecuacion(double X) {
			return 2 * Math.Sin(3 * X - 4) + 5 * Math.Sin(-4 * X + 5) - 4 * Math.Sin(5 * X - 7);
		}
	}
}