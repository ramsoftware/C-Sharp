namespace Ejemplo {
	internal class Program {
		static void Main(string[] args) {
			//============================================
			//Expresion lambda retornando el tipo de valor
			//============================================
			Func<int, long> Factorial = (int numero) => {
				long acumula = 1;
				for (int cont = 1; cont <= numero; cont++) {
					acumula *= cont;
				}
				return acumula;
			};
			long Probar = Factorial(5);
			Console.WriteLine("Factorial es: " + Probar);
		}
	}
}
