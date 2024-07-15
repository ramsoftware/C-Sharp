namespace Ejemplo {
	internal class Program {
		static void Main() {
			Random Azar = new();

			//Imprime 10 cadenas al azar de 50 caracteres cada una
			for (int cont = 0; cont < 10; cont++)
				Console.WriteLine(CadenaAzar(Azar, 50));
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