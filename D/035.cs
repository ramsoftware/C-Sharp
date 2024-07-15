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

			//Crea una segunda variable y le asigna la primera
			//creando una copia
			Valores otro;
			otro = unosValores;

			//Puede imprimir esos valores
			Console.WriteLine("Valores copiados");
			Console.WriteLine(otro.valorA);
			Console.WriteLine(otro.valorB);
			Console.WriteLine(otro.valorC);
			Console.WriteLine(otro.valorD);

			//Modifica la original
			unosValores.valorA = -9876;

			//Imprime la copia
			Console.WriteLine("\nDespués de modificar el original");
			Console.WriteLine(otro.valorA);
		}
	}
}
