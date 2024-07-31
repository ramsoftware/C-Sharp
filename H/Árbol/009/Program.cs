namespace ArbolBinarioEvaluador {
	//Forma el árbol binario dada una expresión matemática
	//de números, variables, paréntesis, funciones y los operadores:
	//Suma, resta, multiplicación, división y potencia
	//Luego evalúa la expresión
	internal class Program {

		static void Main(string[] args) {
			//Ecuación operadores, variables, funciones, paréntesis
			string Ecuacion = "sen(cos(x)+sen(y*z))/cos(q^3-z)";

			EvalArbolBin obj = new();
			int Sintaxis = obj.Analizar(Ecuacion);

			if (Sintaxis == 0) {

				//En un ciclo se cambian los valores de las
				//variables
				Random Azar = new();
				for (int Cont = 1; Cont <= 30; Cont++) {
					obj.DarValorVariable('x', Azar.NextDouble());
					obj.DarValorVariable('y', Azar.NextDouble());
					obj.DarValorVariable('z', Azar.NextDouble());
					obj.DarValorVariable('q', Azar.NextDouble());

					//Evalúa la expresión 
					double Resultado = obj.Evaluar();
					Console.WriteLine("Resultado es: " + Resultado);
				}
			}
			else {
				//Hay un error de sintaxis
				Console.WriteLine(obj.MensajeError(Sintaxis));
			}
		}
	}
}
