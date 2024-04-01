namespace Ejemplo {
	internal class Program {
		static void Main() {
			//Fuente de datos, un arreglo unidimensional
			int[] Lista = new int[] { 1, 9, 7, 2, 0, 6, 2, 6, 1, 6, 8, 3, 2, 9, 2, 9 };

			//Consulta: Extrayendo solo los números pares
			//¡OJO! Aquí si se ejecuta la consulta de una vez
			List<int> Resultados = (from numero in Lista where (numero % 2) == 0 select numero).ToList();

			//Ejecuta la consulta y la imprime
			for (int contador = 0; contador < Resultados.Count; contador++) {
				Console.Write(Resultados[contador].ToString() + ", ");
			}
		}
	}
}