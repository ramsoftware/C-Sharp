namespace Ejemplo {
	internal class Program {
		static void Main() {
			//Instancia el evaluador
			Evaluador4 evaluador = new();

			//Una expresión con paréntesis 
			string Ecuacion = "5*(3+2.5)";
			Ecuacion += "-7/(8.03*2-5^3)";
			Ecuacion += "+4.1*(3-(5.8*2.3))";
			evaluador.Analizar(Ecuacion);
			double valorY = evaluador.Evaluar();
			Console.WriteLine(valorY);
		}
	}
}