namespace Ejemplo {
	internal class Program {
		static void Main() {
			int Contador;

			//Ciclo do-while ascendente
			Console.WriteLine("Ciclo ascendente:");
			Contador = 1;
			do {
				Console.Write(Contador + ", ");
				Contador++;
			} while (Contador <= 20);

			//Ciclo do-while descendente
			Console.WriteLine("\r\nCiclo descendente:");
			Contador = 20;
			do {
				Console.Write(Contador + ", ");
				Contador--;
			} while (Contador >= 1);

			//Ciclo do-while ascendente, avance de 2 en 2
			Console.WriteLine("\r\nCiclo avance de 2 en 2:");
			Contador = 1;
			do {
				Console.Write(Contador + ", ");
				Contador += 2;
			} while (Contador <= 20);

			//Ciclo do-while descendente, retrocede de 2 en 2
			Console.WriteLine("\r\nCiclo retrocede de 2 en 2:");
			Contador = 20;
			do {
				Console.Write(Contador + ", ");
				Contador -= 2;
			} while (Contador >= 1);

			//Ciclo do-while ascendente, avance doble
			Console.WriteLine("\r\nCiclo avance doble:");
			Contador = 1;
			do {
				Console.Write(Contador + ", ");
				Contador *= 2;
			} while (Contador <= 20);

			//Ciclo do-while descendente, retrocede la mitad
			Console.WriteLine("\r\nCiclo retrocede la mitad:");
			Contador = 20;
			do {
				Console.Write(Contador + ", ");
				Contador /= 2;
			} while (Contador >= 1);

		}
	}
}
