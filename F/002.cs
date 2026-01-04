namespace Ejemplo;

internal class Program {
	static void Main() {
		//Fuente de datos
		List<int> Lista = [1, 9, 7, 2, 0, 6, 2, 6, 1, 6, 8, 3];

		//LINQ, extrae los mayores o iguales a 5
		List<int> ListaNumeros = (from numero in Lista
								  where numero >= 5
								  select numero).ToList();

		for (int Cont = 0; Cont < ListaNumeros.Count; Cont++)
			Console.Write(ListaNumeros[Cont] + ", ");
	}
}