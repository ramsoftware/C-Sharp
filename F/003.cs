namespace Ejemplo {
	internal class Program {
		static void Main() {
			//Fuente de datos
			List<int> Lista = [1, 9, 7, 2, 0, 6, 2, 6, 1, 6, 8, 3];

			//Consulta: Extrayendo solo los números pares
			//en orden ascendente
			List<int> Resultados = (from numero in Lista 
									where (numero % 2) == 0
									orderby numero select numero).ToList();

			for (int Cont = 0; Cont < Resultados.Count; Cont++)
				Console.Write(Resultados[Cont] + ", ");
		}
	}
}