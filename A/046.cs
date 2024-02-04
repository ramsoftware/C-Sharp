namespace Ejemplo {
	internal class Program {
		static void Main() {
			int Contador;

			//Rompe el ciclo con break
			Console.WriteLine("Ciclo ascendente:");
			Contador = 1;
			do {
				//Si Contador es múltiplo de 13 se rompe el ciclo con break
				if (Contador % 13 == 0) break;
				Console.Write(Contador.ToString() + ", ");
				Contador++;
			} while (Contador <= 20);
		}
	}
}
