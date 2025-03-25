namespace Ejemplo {
	internal class Program {
		static void Main() {
			//Fuente de datos
			List<int> Lista = [1, 9, 7, 2, 0, 6, 2, 6, 1, 6, 8, 3];

			//Consulta: Extrayendo solo los números pares en 
			//orden descendente
			List<string> Resultados =
				(from numero in Lista
				 where (numero % 2) == 0
				 orderby numero descending
				 select $"Valor es: {numero}, ").ToList();

			for (int Cont = 0; Cont < Resultados.Count; Cont++)
				Console.WriteLine(Resultados[Cont]);
		}
	}
}