namespace Ejemplo {
	internal class Program {
		static void Main(string[] args) {
			//============================================
			//Listas y variables externas 
			//============================================

			//Una lista de operaciones Lambda
			var Operaciones = new List<Func<int, int>>();

			//Agrega items a la lista, declara internamente a Suma
			for (int Cont = 5; Cont <= 10; Cont++) {
				int Suma = Cont;
				Operaciones.Add((int Valor) => Valor + Suma);
			}

			//En este caso SI funciona
			foreach (var operacion in Operaciones) {
				int Resultados = operacion(300);
				Console.WriteLine(Resultados);
			}
		}
	}
}