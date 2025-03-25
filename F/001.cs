namespace Ejemplo {
	internal class Program {
		static void Main() {
			//Fuente de datos
			List<int> Lista = [1, 9, 7, 2, 0, 6, 2, 6, 1, 6, 8, 3];

			//LINQ, extrae los impares
			List<int> ListaImpares = (from numero in Lista
									  where (numero % 2) == 1
									  select numero).ToList();

			for (int Cont = 0; Cont < ListaImpares.Count; Cont++)
				Console.Write(ListaImpares[Cont] + ", ");
		}
	}
}