namespace Ejemplo;

internal class Program {
	static void Main() {
		Console.WriteLine("\r\nCompleja expresión booleana");
		Console.WriteLine(true && true || false && true || true || false);
		Console.WriteLine(true || false && true || false && true && true);
		Console.WriteLine(!false && !true || !true && false && !false);

		/* No se recomienda en una expresión lógica poner dos o más
		 * operadores lógicos. Llega a confundir.
		 * Hacer uso de paréntesis. */
	}
}