namespace Ejemplo {
	internal class Program {
		static void Main() {
			//Instancia el evaluador
			Evaluador4 evaluador = new();

			//Una expresión con uso de variables
			//(deben estar en minúsculas)
			string Ecuacion = "3*x+2*y";
			evaluador.Analizar(Ecuacion);

			//Le da valor a las variables
			//(deben estar en minúsculas)
			evaluador.DarValorVariable('x', 1.8);
			evaluador.DarValorVariable('y', 3.5);
			double valorY = evaluador.Evaluar();
			Console.WriteLine(valorY);
		}
	}
}