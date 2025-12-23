namespace Ejemplo;

internal class Program {
	static void Main() {
		//Es mejor usar reales que el cast
		double valA = 9.0 / 2.0 - 1.0 + 2.0 * Math.Pow(2.0, 5.0) / 4.0;
		double valB = (double)9 / 2 - 1 + 2 * Math.Pow(2, 5) / 4;

		/*Falla porque se interpreta completamente 
		  como enteros 9 / 2 es 4 en división entera */
		double valC = 9 / 2 - 1 + 2 * Math.Pow(2, 5) / 4;

		/* Falla el cast porque primero se interpreta la expresión
		como entera y luego se pasa a double */
		double valD = (double)(9 / 2 - 1 + 2 * Math.Pow(2, 5) / 4);

		Console.WriteLine("Valor A es: " + valA);
		Console.WriteLine("Valor B es: " + valB);
		Console.WriteLine("Valor C es: " + valC);
		Console.WriteLine("Valor D es: " + valD);
	}
}