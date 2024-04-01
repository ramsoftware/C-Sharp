namespace Ejemplo {
	internal class Program {
		static int valor; //Una variable que es conocida por todas las funciones

		static void Main() {
			//Ámbito de las variables
			valor = 17;
			Console.WriteLine("Valor al iniciar es: " + valor.ToString());
			UnProcedimiento();
			Console.WriteLine("Valor después de primer procedimiento es: " + valor.ToString());
			OtroProcedimiento();
			Console.WriteLine("Valor después de segundo procedimiento es: " + valor.ToString());
		}

		//Un procedimiento
		static void UnProcedimiento() {
			valor = 590;
		}

		//Otro procedimiento
		static void OtroProcedimiento() {
			valor = 3246;
		}
	}
}
