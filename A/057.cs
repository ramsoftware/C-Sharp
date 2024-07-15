namespace Ejemplo {
	internal class Program {
		//Una variable que es conocida por todas las funciones
		static int valor;

		static void Main() {
			//Ámbito de las variables
			valor = 17;
			Console.WriteLine("Valor al iniciar: " + valor);
			SubrutinaA();
			Console.WriteLine("Después de SubrutinaA(): " + valor);
			SubrutinaB();
			Console.WriteLine("Después de SubrutinaB(): " + valor);
		}

		//Un procedimiento
		static void SubrutinaA() {
			valor = 590;
		}

		//Otro procedimiento
		static void SubrutinaB() {
			valor = 3246;
		}
	}
}
