namespace Ejemplo {
	internal class Program {
		static void Main(string[] args) {
			//============================================
			//Listas y variables externas 
			//============================================

			//Una lista de operaciones Lambda
			var Operaciones = new List<Func<int, int>>();

			//Agrega items a la lista, declara externamente Suma
			int Suma;
			for (int Cont = 5; Cont <= 10; Cont++) {
				Suma = Cont;
				Operaciones.Add((int Valor) => Valor + Suma);
			}

			//En este caso NO va a funcionar
			foreach (var operacion in Operaciones) {
				int Resultados = operacion(300);
				Console.WriteLine(Resultados);
			}
		}
	}
}

https://www.csharptutorial.net/csharp-tutorial/csharp-lambda-expression/