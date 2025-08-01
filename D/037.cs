namespace Ejemplo {

	//Inicia la aplicación aquí
	internal class Program {

		//Una estructura
		struct Valores {
			private int valorA;
			private char valorB;
			private double valorC;
			private string valorD;

			public Valores(int valA, char valB, double valC, string valD) {
				this.valorA = valA;
				this.valorB = valB;
				this.valorC = valC;
				this.valorD = valD;
			}

			public void ImprimeValores() {
				Console.WriteLine(valorA);
				Console.WriteLine(valorB);
				Console.WriteLine(valorC);
				Console.WriteLine(valorD);
			}
		}

		static void Main() {
			//Crea una variable de tipo struct y
			//la inicializa con un constructor
			Valores unosValores = new Valores(13, 'R', 16.832, "Milú");
			unosValores.ImprimeValores();
		}
	}
}
