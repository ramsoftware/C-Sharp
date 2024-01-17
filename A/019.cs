namespace Ejemplo {
	internal class Program {
		static void Main() {
			//Pasar correctamente ecuaciones a formato en C#
			double X = 5.7;
			double Y;

			//Ejemplos
			Y = 3 / (X - 1);
			Console.WriteLine("Valor Y es: " + Y.ToString());

			Y = 3 / (X - 1) + 2;
			Console.WriteLine("Valor Y es: " + Y.ToString());

			Y = 3 / X + X / 7;
			Console.WriteLine("Valor Y es: " + Y.ToString());

			Y = 3 / (X * X);
			Console.WriteLine("Valor Y es: " + Y.ToString());

			Y = 3 / (2 - (X * X + 5));
			Console.WriteLine("Valor Y es: " + Y.ToString());

			Y = (5 + X) / (6 - X * X * X);
			Console.WriteLine("Valor Y es: " + Y.ToString());

			Y = 2 + ((4 / X) / 3);
			Console.WriteLine("Valor Y es: " + Y.ToString());

			Y = 5 * ((X * X / 4) / (3 / (X + 5)));
			Console.WriteLine("Valor Y es: " + Y.ToString());

			Y = ((X * X) + ((2 * X - 5) / (X + 1))) / (1 - X * X);
			Console.WriteLine("Valor Y es: " + Y.ToString());
		}
	}
}
