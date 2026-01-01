namespace Ejemplo;

class Program {
	// 1. Se declara el delegado
	public delegate double Operacion(double valor);

	// 2. Métodos compatibles con el delegado
	public static double Doble(double x) => x * 2;
	public static double Cuadrado(double x) => x * x;
	public static double Raiz(double x) => Math.Sqrt(x);

	// 3. Método que recibe el delegado y aplica la operación
	public static void EjecutarOperacion(double numero, Operacion op) {
		double resultado = op(numero);
		Console.WriteLine($"Resultado: {resultado}");
	}

	static void Main() {
		Console.WriteLine("Ingrese un número:");
		double numero = Convert.ToDouble(Console.ReadLine());

		Console.WriteLine("Elija operación: 1 = Doble, 2 = Cuadrado, 3 = Raíz");
		string opcion = Console.ReadLine();

		Operacion operacionElegida;

		// 4. Se asigna el método al delegado según la opción
		switch (opcion) {
			case "1":
				operacionElegida = Doble;
				break;
			case "2":
				operacionElegida = Cuadrado;
				break;
			case "3":
				operacionElegida = Raiz;
				break;
			default:
				Console.WriteLine("Opción inválida.");
				return;
		}

		// 5. Ejecuta la operación
		EjecutarOperacion(numero, operacionElegida);
	}
}