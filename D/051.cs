namespace Ejemplo
{
	class Valores {
		public int Entero;
		public double ValorReal;

		public Valores(int entero, double valorReal) {
			Entero = entero;
			ValorReal = valorReal;
		}

		public void Imprime() {
			Console.WriteLine(Entero + ";" + ValorReal);
		}
	}

	internal class Program
	{
		static void Main()
		{
			//Arreglo unidimensional de objetos
			Valores[] objetos = new Valores[20];

			Random Azar = new();

			//Se crean los objetos
			for (int Cont=0; Cont < objetos.Length; Cont++)
				objetos[Cont] = new Valores(Azar.Next(100), Azar.NextDouble());

			//Imprime los objetos
			Console.WriteLine("Arreglo de objetos original");
			for (int Cont = 0; Cont < objetos.Length; Cont++)
				objetos[Cont].Imprime();

			//Se procede a ordenar usando ShellSort
			Shell(objetos);

			//Imprime los objetos
			Console.WriteLine("\r\nArreglo de objetos ordenado por atributo entero");
			for (int Cont = 0; Cont < objetos.Length; Cont++)
				objetos[Cont].Imprime();
		}

		//Ordenamiento por Shell
		static void Shell(Valores[] arr) {
			int incr = arr.Length;
			do {
				incr /= 2;
				for (int k = 0; k < incr; k++) {
					for (int i = incr + k; i < arr.Length; i += incr) {
						int j = i;
						while (j - incr >= 0 && arr[j].Entero < arr[j - incr].Entero) {
							int tmp = arr[j].Entero;
							arr[j].Entero = arr[j - incr].Entero;
							arr[j - incr].Entero = tmp;

							double tmp2 = arr[j].ValorReal;
							arr[j].ValorReal = arr[j - incr].ValorReal;
							arr[j - incr].ValorReal = tmp2;

							j -= incr;
						}
					}
				}
			} while (incr > 1);
		}

	}
}
