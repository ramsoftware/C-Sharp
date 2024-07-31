namespace ArbolBinarioEvaluador {
//Forma el árbol binario dada una expresión matemática
//de números, variables, paréntesis, funciones y los operadores:
//Suma, resta, multiplicación, división y potencia
//Luego evalúa la expresión
	internal class Program {

		static void Main(string[] args) {
			//Ecuación operadores, variables, funciones, paréntesis
			string Ecuacion = "sen(cos(x)+sen(y+z))/cos(78-q)";

			EvalArbolBin obj = new();
			obj.Analizar(Ecuacion);
			obj.DarValorVariable('x', 120);
			obj.DarValorVariable('y', 150);
			obj.DarValorVariable('z', 45);
			obj.DarValorVariable('q', -10);

			//Evalúa la expresión 
			double Resultado = obj.Evaluar();
			Console.WriteLine("Resultado es: " + Resultado);

			//Probarlo en: http://viz-js.com
			obj.Dibujar();
		}
	}
}