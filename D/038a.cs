namespace Ejemplo {
	partial class MiClase {
		public MiClase(int valA, double valB, char valC, string valD) {
			ValorA = valA;
			ValorB = valB;
			ValorC = valC;
			ValorD = valD;
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
