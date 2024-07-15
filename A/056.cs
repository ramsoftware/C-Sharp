namespace Ejemplo {
	internal class Program {
		static void Main() {
			//Función iterativa y recursiva
			long valor = 10;
			long factorialA, factorialB;

			factorialA = CalculaFactorialIterativa(valor);
			factorialB = CalculaFactorialRecursivo(valor);

			Console.WriteLine("factorialA es: " + factorialA);
			Console.WriteLine("factorialB es: " + factorialB);
		}

		//Retorna el factorial de un número, de forma iterativa
		static long CalculaFactorialIterativa(long numero) {
			long resultado = 1;
			for (long num=2; num <= numero; num++) {
				resultado *= num;
			}
			return resultado;
		}

		//Retorna el factorial de un número, de forma recursiva 
		static long CalculaFactorialRecursivo(long numero) {
			if (numero == 1) return 1;
			return numero*CalculaFactorialRecursivo(numero-1);
		}
	}
}