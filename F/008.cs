namespace Ejemplo {
	internal class Program {
		static void Main() {
			//Fuente de datos
			List<int> Lista = [1, 9, 7, 2, 0, 6, 2, 6, 1, 6, 8, 3];

			//Consulta: Máximo y mínimo
			int Maximo = (from numero in Lista
						  where numero % 2 == 0
						  select numero).Max();

			int Minimo = (from numero in Lista
						  where numero % 2 == 0
						  select numero).Min();

			int Suma = (from numero in Lista
						where numero % 2 == 0
						select numero).Sum();

			//Ejecuta la consulta y la imprime
			Console.WriteLine("Máximo es: " + Maximo);
			Console.WriteLine("Mínimo es: " + Minimo);
			Console.WriteLine("Suma es: " + Suma);
		}
	}
}