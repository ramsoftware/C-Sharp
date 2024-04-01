namespace Ejemplo {
	internal class Program {
		static void Main() {
			//Ámbito de las variables. Variable local
			int valor = 17;
			Console.WriteLine("Valor es: " + valor.ToString());
			UnProcedimiento();
			Console.WriteLine("Valor es: " + valor.ToString());
			OtroProcedimiento();
			Console.WriteLine("Valor es: " + valor.ToString());
		}

		//Un procedimiento. La variable “valor” es otra distinta a la del “Main”
		static void UnProcedimiento() {
			int valor = 590;
		}

		//Otro procedimiento. La variable “valor” es otra distinta a la del “Main”
		static void OtroProcedimiento() {
			int valor = 3246;
		}
	}
}
