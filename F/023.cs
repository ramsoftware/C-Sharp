namespace Ejemplo;

internal class Program {
	static void Main() {
		//Una cadena
		string Cadena = "El-ñandú-es-un-ave-de-Sudamérica.";
		Cadena += "-La-cigüeña-blanca-es-una-especie-de-ave";
		Cadena += "-Ciconiiforme-de-gran-tamaño.";
		Console.WriteLine("Cadena: " + Cadena);

		/* Se ordena usando Linq
			 * Si desea ordenar los elementos dentro de una secuencia,
			 * deberá pasar un método keySelector de identidad que
			 * indique que cada elemento de
			 * la secuencia es, en sí mismo, una clave. */
		List<char> Resultado = Cadena.OrderBy(str => str).ToList();

		Console.WriteLine("Arreglo con las letras ordenadas");
		for (int Cont = 0; Cont < Resultado.Count; Cont++)
			Console.Write("[" + Resultado[Cont] + "] ");

		// Y convierte ese arreglo en cadena 
		string Ordenado = String.Concat(Resultado);

		//Imprime
		Console.WriteLine("\r\nOrdenado por letra: " + Ordenado);
	}
}