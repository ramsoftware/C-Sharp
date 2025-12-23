namespace Ejemplo;

internal class Program {
	static void Main() {
		//Uso del try...catch
		int valA = 17;
		int valB = 0;
		int resultado;
		try {
			//Intenta dividir entre cero
			resultado = valA / valB;
			Console.WriteLine("Resultado: " + resultado);
		}
		catch { //Captura el error
			Console.WriteLine("División entre cero");
		}
	}
}