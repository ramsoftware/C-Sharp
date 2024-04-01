namespace Ejemplo {
	internal class Program {
		static void Main() {
			//Fuente de datos, un arreglo unidimensional
			int[] Lista = new int[] { 8, -3, 2, 10, -7, 3, 0, 4, 13, -17, 9 };

			//Consulta: Máximo, mínimo y suma
			//¡OJO! Aquí si se ejecuta la consulta de una vez
			int Maximo = (from numero in Lista select numero).Max();
			int Minimo = (from numero in Lista select numero).Min();
			int Suma = (from numero in Lista select numero).Sum();

			//Ejecuta la consulta y la imprime
			Console.WriteLine("Máximo es: " + Maximo.ToString());
			Console.WriteLine("Mínimo es: " + Minimo.ToString());
			Console.WriteLine("Suma es: " + Suma.ToString());
			
			//Otra forma de hacerlo
			int maximo = Lista.Max();
			int minimo = Lista.Min();
			int suma = Lista.Sum();

			//Imprime
			Console.WriteLine("Máximo: " + maximo.ToString());
			Console.WriteLine("Mínimo: " + minimo.ToString());
			Console.WriteLine("Suma: " + suma.ToString());
		}
	}
}