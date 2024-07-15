namespace Ejemplo {
	internal class Program {
		static void Main() {
			int Contador;

			//Ciclo while ascendente
			Console.WriteLine("Ciclo ascendente:");
			Contador = 1;
			while (Contador <= 20) {
				Console.Write(Contador + ", ");
				Contador++;
			}

			//Ciclo while descendente
			Console.WriteLine("\r\nCiclo descendente:");
			Contador = 20;
			while (Contador >= 1) {
				Console.Write(Contador + ", ");
				Contador--;
			}

			//Ciclo while ascendente, avance de 2 en 2
			Console.WriteLine("\r\nCiclo avance de 2 en 2:");
			Contador = 1;
			while (Contador <= 20) {
				Console.Write(Contador + ", ");
				Contador += 2;
			}

			//Ciclo while descendente, retrocede de 2 en 2
			Console.WriteLine("\r\nCiclo retrocede de 2 en 2:");
			Contador = 20;
			while (Contador >= 1) {
				Console.Write(Contador + ", ");
				Contador -= 2;
			}

			//Ciclo while ascendente, avance doble
			Console.WriteLine("\r\nCiclo avance doble:");
			Contador = 1;
			while (Contador <= 20) {
				Console.Write(Contador + ", ");
				Contador *= 2;
			}

			//Ciclo while descendente, retrocede la mitad
			Console.WriteLine("\r\nCiclo retrocede la mitad:");
			Contador = 20;
			while (Contador >= 1) {
				Console.Write(Contador + ", ");
				Contador /= 2;
			}
		}
	}
}