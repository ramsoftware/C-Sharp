namespace Ejemplo {
	internal class Program {
		static void Main() {
			//Único generador de números pseudo-aleatorios
			Random Azar = new();

			//La cadena original
			string cadenaOriginal = "esta es una prueba de texto";

			//Genera cadenas al azar y ver si en algún
			//momento hay coincidencia
			int longitud = cadenaOriginal.Length;

			//Ciclo para generar cadenas al azar 
			for (int Contador = 1; Contador <= 10000; Contador++) {
				string nuevaCadena = CadenaAzar(Azar, longitud);
				if (nuevaCadena == cadenaOriginal)
					Console.WriteLine("Acertó");
			}

			Console.WriteLine("Finaliza");
		}

		//Retorna una cadena al azar
		static string CadenaAzar(Random Azar, int Longitud) {
			string Letras = "abcdefghijklmnopqrstuvwxyz ";

			string Cadena = "";
			for (int Contador = 1; Contador <= Longitud; Contador++)
				Cadena += Letras[Azar.Next(Letras.Length)];
			return Cadena;
		}
	}
}