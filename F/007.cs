namespace Ejemplo;

internal class Program {
	static void Main() {
		//Fuente de datos
		List<int> Lista = [1, 9, 7, 2, 0, 6, 2, 6, 1, 6, 8, 3];

		//Consulta: Máximo, mínimo y suma
		int Maximo = (from numero in Lista
					  select numero).Max();

		int Minimo = (from numero in Lista
					  select numero).Min();

		int Suma = (from numero in Lista
					select numero).Sum();

		//Ejecuta la consulta y la imprime
		Console.WriteLine("Máximo es: " + Maximo);
		Console.WriteLine("Mínimo es: " + Minimo);
		Console.WriteLine("Suma es: " + Suma);

		//Otra forma de hacerlo
		int maximo = Lista.Max();
		int minimo = Lista.Min();
		int suma = Lista.Sum();

		//Imprime
		Console.WriteLine("Máximo: " + maximo);
		Console.WriteLine("Mínimo: " + minimo);
		Console.WriteLine("Suma: " + suma);
	}
}
