namespace Ejemplo {
	internal class Program {
		static void Main() {
			//Fuente de datos, un arreglo unidimensional
			int[] Lista = [9, 2, 9, 2, 3, 8, 6, 1];

			//Consulta: Contando los números pares
			//¡OJO! Aquí si se ejecuta la consulta de una vez
			int TotalRegistros =
				(from numero in Lista
				 where (numero % 2) == 0
				 select numero).Count();

			//Ejecuta la consulta y la imprime
			Console.WriteLine(TotalRegistros);
		}
	}
}