namespace Ejemplo {
	internal class Program {
		static void Main() {
			//Fuente de datos, un arreglo unidimensional
			int[] Lista = [1, 9, 7, 2, 0, 6, 2, 6, 1, 6];

			//Consulta: Extrayendo solo los números pares en 
			//orden descendente
			//¡OJO! Aquí si se ejecuta la consulta de una vez
			List<string> Resultados =
				(from numero in Lista
				 where (numero % 2) == 0
				 orderby numero descending
				 select $"Valor es: {numero}, ").ToList();

			//Ejecuta la consulta y la imprime
			for (int cont = 0; cont < Resultados.Count; cont++) {
				Console.WriteLine(Resultados[cont]);
			}
		}
	}
}