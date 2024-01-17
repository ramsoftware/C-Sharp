namespace Ejemplo {
	partial class MiClase {
		public MiClase(int valorA, double valorB, char valorC, string valorD) {
			ValorA = valorA;
			ValorB = valorB;
			ValorC = valorC;
			ValorD = valorD;
		}

		public void Imprime() {
			Console.WriteLine("Valores");
			Console.WriteLine(ValorA);
			Console.WriteLine(ValorB);
			Console.WriteLine(ValorC);
			Console.WriteLine(ValorD);
		}
	}

	//Inicia la aplicación aquí
	class Program {
		public static void Main() {
			MiClase objClase = new MiClase(2010, 7.15, 'S', "Sally");
			objClase.Imprime();
		}
	}
}
