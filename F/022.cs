namespace Ejemplo {
	internal class Program {
		static void Main() {
			//Una cadena
			string Cadena = "El-ñandú-es-un-ave-de-Sudamérica.-La-cigüeña-blanca-es-una-especie-de-ave-Ciconiiforme-de-gran-tamaño.";
			Console.WriteLine("Cadena: " + Cadena);

			/* Se ordena usando Linq
			 * Si desea ordenar los elementos dentro de una secuencia, deberá pasar
			 * un método keySelector de identidad que indique que cada elemento de
			 * la secuencia es, en sí mismo, una clave. */
			IEnumerable<char> resultado = Cadena.OrderBy(str => str);
			Console.WriteLine("Arreglo con las letras ordenadas");
			foreach (int valor in resultado) {
				Console.Write("[" + (char)valor + "] ");
			}

			// Y convierte ese arreglo en cadena 
			string Ordenado = String.Concat(resultado);

			//Imprime
			Console.WriteLine("\r\nOrdenado por letra: " + Ordenado);
		}
	}
}
