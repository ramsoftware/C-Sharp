namespace Ejemplo {
	internal class Program {
		static void Main() {
			//Ciclo for ascendente
			Console.WriteLine("Ciclo ascendente:");
			for (int Contador = 1; Contador <= 20; Contador++) {
				Console.Write(Contador.ToString() + ", ");
			}

			//Ciclo for descendente
			Console.WriteLine("\r\nCiclo descendente:");
			for (int Contador = 20; Contador >= 1; Contador--) {
				Console.Write(Contador.ToString() + ", ");
			}

			//Ciclo for ascendente, avance de 2 en 2
			Console.WriteLine("\r\nCiclo ascendente (avance de 2 en 2):");
			for (int Contador = 1; Contador <= 20; Contador += 2) {
				Console.Write(Contador.ToString() + ", ");
			}

			//Ciclo for descendente, retrocede de 2 en 2
			Console.WriteLine("\r\nCiclo descendente (retrocede de 2 en 2):");
			for (int Contador = 20; Contador >= 1; Contador -= 2) {
				Console.Write(Contador.ToString() + ", ");
			}

			//Ciclo for ascendente, avance doble
			Console.WriteLine("\r\nCiclo ascendente (avance doble):");
			for (int Contador = 1; Contador <= 20; Contador *= 2) {
				Console.Write(Contador.ToString() + ", ");
			}

			//Ciclo for descendente, retrocede la mitad
			Console.WriteLine("\r\nCiclo descendente (retrocede la mitad):");
			for (int Contador = 20; Contador >= 1; Contador /= 2) {
				Console.Write(Contador.ToString() + ", ");
			}
		}
	}
}