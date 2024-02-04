namespace Ejemplo {
	partial class MiClase {
		public int ValorA { get; set; }
		public double ValorB { get; set; }
		public char ValorC { get; set; }
		public string ValorD { get; set; }

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

		//Destructor
		~MiClase() {
			Console.WriteLine("Ejecuta el destructor");
		}
	}
}
