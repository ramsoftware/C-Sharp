using System;

namespace Ejemplo {
	internal class Program {
		static void Main() {
			//Encontrar subcadenas
			string cadena = "manzana y naranja";
			Console.WriteLine(cadena);

			//Busca la primera posición de la letra "a"
			int posA = cadena.IndexOf('a');
			Console.WriteLine("Posición de la primera 'a' es: " + posA.ToString());

			//Busca una letra que no existe
			int posB = cadena.IndexOf('K');
			Console.WriteLine("Posición de la primera 'K' es: " + posB.ToString());

			//Busca la primera posición de la subcadena "na"
			int posC = cadena.IndexOf("na");
			Console.WriteLine("Posición de la primera 'na' es: " + posC.ToString());

			//Busca la segunda posición de la letra "a"
			int posD = cadena.IndexOf('a', posA+1);
			Console.WriteLine("Posición de la segunda 'a' es: " + posD.ToString());

			//Busca la tercera posición de la letra "a"
			int posE = cadena.IndexOf('a', posD + 1);
			Console.WriteLine("Posición de la tercera 'a' es: " + posE.ToString());
		}
	}
}
