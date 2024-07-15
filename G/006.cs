namespace Ejemplo {
	internal class Program {
		static void Main() {
			Random Azar = new();

			//Instancia el evaluador
			Evaluador4 evaluador = new();

			//Una expresión con uso de variables
			//(deben estar en minúsculas)
			string Ecuacion = "3*cos(2*x+4)-5*sen(4*y-7)";
			
			//Se analiza primero la ecuación
			evaluador.Analizar(Ecuacion);

			//Después de ser analizada, se le dan los 
			//valores a las variables, esto hace que
			//el evaluador sea muy rápido
			for (int cont = 1; cont <= 20; cont++) {
				evaluador.DarValorVariable('x', Azar.NextDouble());
				evaluador.DarValorVariable('y', Azar.NextDouble());
				double valorY = evaluador.Evaluar();
				Console.WriteLine(valorY);
			}
		}
	}
}