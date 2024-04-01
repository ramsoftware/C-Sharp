namespace Ejemplo {
	internal class Program {
		static void Main() {
			//Generador congruencial lineal
			long X0, A, B, N;

			//Valores de inicio. Se los da el usuario.
			X0 = 302;
			A = 278;
			B = 435;
			N = 871;

			for (int contador = 1; contador <= 100; contador++) {
				X0 = (A * X0 + B) % N;
				double r = (double) X0 / N;
				Console.WriteLine("Número pseudo-aleatorio: " + X0 + "  r: " + r);
			} 
		}
	}
}
