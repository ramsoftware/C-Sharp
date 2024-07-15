namespace Ejemplo {
	internal class Program {
		static void Main() {
			int Contador;

			Console.WriteLine("Ciclo ascendente:");
			Contador = 0;
			do {
				Contador++;

				//Si Contador es par entonces va
				//a la siguiente iteración, no 
				//ejecuta lo que está después.
				if (Contador % 2 == 0) continue;

				Console.Write(Contador + ", ");
			} while (Contador <= 20);
		}
	}
}