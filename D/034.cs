namespace Ejemplo {

	//Inicia la aplicación aquí
	internal class Program {

		//Una estructura
		struct Valores {
			public int valorA;
			public char valorB;
			public double valorC;
			public string valorD;
		}
		
		static void Main() {
			//Crea una variable de tipo struct
			Valores unosValores;
			unosValores.valorA = 13;
			unosValores.valorB = 'R';
			unosValores.valorC = 16.832;
			unosValores.valorD = "Milú";

			//Puede imprimir esos valores
			Console.WriteLine(unosValores.valorA);
			Console.WriteLine(unosValores.valorB);
			Console.WriteLine(unosValores.valorC);
			Console.WriteLine(unosValores.valorD);
		}
	}
}
