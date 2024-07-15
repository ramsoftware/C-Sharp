namespace Ejemplo {
	internal class Program {
		static void Main() {
			//Declara variables de tipo double
			double valA = 5.718987654321;
			double valB = -3.420821098765;
			double valC = 1.234567890123456789;
			double valD = 7.8;

			//Imprime con un formato de al menos dos decimales
			Console.WriteLine("Valor A es: {0:0.00}", valA);

			//Imprime con un formato de al menos tres decimales
			Console.WriteLine("Valor B es: {0:0.000}", valB);

			//Imprime con un formato de al menos cuatro decimales
			Console.WriteLine("Valor C es: {0:0.0000}", valC);

			//Imprime con un formato de al menos cinco decimales
			Console.WriteLine("Valor D es: {0:0.00000}", valD);

			/* Imprime dos variables. 
			 * Ver el inicio {N: donde N es la posición de la variable
			 * en la instrucción de impresión iniciando en cero. */
			Console.WriteLine("A: {0:0.00}; B: {1:0.00}", valA, valB);

			/* Máximo tres decimales */
			Console.WriteLine("Valor C con 3 decimales: {0:0.###}", valC);
			Console.WriteLine("Valor D con 3 decimales: {0:0.###}", valD);

			/* Mínimo tres cifras antes del punto decimal */
			Console.WriteLine("Valor A. 3 cifras enteras: {0:000.###}", valA);
			Console.WriteLine("Valor B. 3 cifras enteras: {0:000.###}", valB);
		}
	}
}