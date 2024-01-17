namespace Ejemplo {
	internal class Program {
		static void Main() {
			//Fuente de datos, un arreglo unidimensional
			int[] Lista = new int[] { 8, -3, 2, 10, -7, 3, 0, 4, 13, -17, 9 };

			//Consulta: Máximo y mínimo
			//¡OJO! Aquí si se ejecuta la consulta de una vez
			int Maximo = (from numero in Lista where numero % 2 == 0 select numero).Max();
			int Minimo = (from numero in Lista where numero % 2 == 0 select numero).Min();
			int Suma = (from numero in Lista where numero % 2 == 0  select numero).Sum();

			//Ejecuta la consulta y la imprime
			Console.WriteLine("Máximo es: " + Maximo.ToString());
			Console.WriteLine("Mínimo es: " + Minimo.ToString());
			Console.WriteLine("Suma es: " + Suma.ToString());
		}
	}
}