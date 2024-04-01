namespace Ejemplo {
	internal class Program {
		static void Main() {
			//Uso del try...catch
			int valA = 17;
			int valB = 0;
			int resultado;
			try {
				resultado = valA / valB; //Intenta dividir entre cero
				Console.WriteLine("Resultado es: " + resultado.ToString());
			}
			catch { //Captura el error
				Console.WriteLine("División entre cero");
			}
		}
	}
}