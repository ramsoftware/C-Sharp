namespace Ejemplo {
	internal class Program {
		static void Main() {
			//Fuente de datos
			List<int> Lista = [1, 9, 7, 2, 0, 6, 2, 6, 1, 6, 8, 3];

			//Consulta: Contando los números pares
			int TotalRegistros =
				(from numero in Lista
				 where (numero % 2) == 0
				 select numero).Count();

			//Ejecuta la consulta y la imprime
			Console.WriteLine(TotalRegistros);
		}
	}
}