namespace Ejemplo {
	internal class Program {
		static void Main() {
			//Instancia el evaluador
			Evaluador4 evaluador = new Evaluador4();

			//Una expresión simple con números reales 
			string Ecuacion = "7.318+5.0045-9.071^2*8.04961";
			evaluador.Analizar(Ecuacion);
			double valorY = evaluador.Evaluar();
			Console.WriteLine(valorY);
		}
	}
}