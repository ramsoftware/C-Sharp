namespace Ejemplo;

//Inicia la aplicación aquí
internal class Program {

	//Una estructura
	struct Valores {
		private int valorA;
		private char valorB;
		private double valorC;
		private string valorD;

		public void Asigna(int A, char B, double C, string D) {
			this.valorA = A;
			this.valorB = B;
			this.valorC = C;
			this.valorD = D;
		}

		public void ImprimeValores() {
			Console.WriteLine(valorA);
			Console.WriteLine(valorB);
			Console.WriteLine(valorC);
			Console.WriteLine(valorD);
		}

		public double RetornaValor(double numero) {
			return valorA * valorC + numero;
		}
	}

	static void Main() {
		//Crea una variable de tipo struct y
		//la inicializa por defecto
		Valores unosValores = default;

		//Llama a los métodos del struct
		unosValores.Asigna(13, 'R', 16.832, "Milú");
		unosValores.ImprimeValores();

		//Y a la función del struct
		Console.WriteLine(unosValores.RetornaValor(5));
	}
}