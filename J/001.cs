namespace Ejemplo
{
	internal class Program
	{
		static void Main(string[] args)
		{
			/* Único generador de números aleatorios para todo el programa */
			Random Azar = new();

			/* Cadena original a "adivinar" */
			string Original = "naturaleza";

			/* Iniciar el proceso */
			Proceso(Azar, Original);
		}

		/* Método que realiza el proceso de "adivinar" la cadena original */
		static void Proceso(Random Azar, string Original) {
			int Contador = 0;
			for (; ;) {

				/* Generar una cadena aleatoria */
				string Cadena = GenerarCadenaAzar(Azar, Original.Length);

				/* Comparar con la original */
				if (string.Compare(Original, Cadena) == 0) {
					break;
				}

				/* Incrementar el contador e informar cada 1000 intentos */
				Contador++;
				if (Contador % 1000 == 0) {
					Console.WriteLine($"Intentos: {Contador:N0}");
				}
			}
		}

		/* Método que genera una cadena aleatoria de una longitud dada */
		static string GenerarCadenaAzar(Random Azar, int longitud) {
			char[] caracteres = new char[longitud];
			for (int i = 0; i < longitud; i++) {
				caracteres[i] = LetraAzar(Azar);
			}
			return new string(caracteres);
		}

		/* Método que genera una letra minúscula aleatoria */
		static char LetraAzar(Random Azar) { 
			return (char)Azar.Next('a', 'z' + 1);
		}
	}
}