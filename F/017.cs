namespace Ejemplo {
	internal class Program {
		static void Main() {
			List<string> Animales = new List<string>(){ "Gato", "Condor", "Perro", "Conejo", "Guacamaya" };
			List<string> Mamiferos = new List<string>(){ "Perro", "Conejo", "Gato" };

			/* Extrae los animales que no están en mamíferos */ 
			var Resultado = Animales.Except(Mamiferos);

			foreach(string Cadena in Resultado)
				Console.WriteLine(Cadena);
		}
	}
}
