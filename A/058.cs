namespace Ejemplo;

internal class Program {
	static void Main() {
		//Ámbito de las variables. Variable local
		int valor = 17;
		Console.WriteLine("Valor inicial: " + valor);
		SubrutinaA();
		Console.WriteLine("Después de SubrutinaA(): " + valor);
		SubrutinaB();
		Console.WriteLine("Después de SubrutinaB(): " + valor);
	}

	//Un procedimiento.
	//La variable “valor” es otra distinta a la del “Main”
	static void SubrutinaA() {
		int valor = 590;
	}

	//Otro procedimiento. La variable
	//“valor” es otra distinta a la del “Main”
	static void SubrutinaB() {
		int valor = 3246;
	}
}