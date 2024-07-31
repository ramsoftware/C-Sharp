namespace Ejemplo {
	internal class Program {
		static void Main() {
			//Instancia el evaluador
			Evaluador4 evaluador = new();

			//Una expresión simple 
			string Ecuacion = "8*5+1-7/4+2^3";
			evaluador.Analizar(Ecuacion);
			double valorY = evaluador.Evaluar();
			Console.WriteLine(valorY);
		}
	}
}