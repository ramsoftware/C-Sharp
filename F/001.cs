namespace Ejemplo {
	internal class Program {
		static void Main() {
			//Fuente de datos, un arreglo unidimensional
			int[] Lista = new int[] { 1, 9, 7, 2, 0, 6, 2, 6, 1, 6, 8, 3, 2, 9, 2, 9 };

			//Consulta: Extrayendo solo los números impares
			//¡OJO! Sólo crea la instrucción de consulta pero todavía no la hace
			IEnumerable<int> Consulta =
				from numero in Lista where (numero % 2) == 1 select numero;

			//Ejecuta la consulta y la imprime
			foreach (int Valor in Consulta)
				Console.Write(Valor.ToString() + ", ");
		}
	}
}