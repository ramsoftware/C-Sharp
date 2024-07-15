namespace Ejemplo {
	internal class Program {
		static void Main(string[] args) {
			/* Variable aleatoria
			   Distribución Normal. 
			   Generar una variable aleatoria con media M y desviación D
			   variable = M + D * c
			   donde c = cos(2*PI*r2)*raizcuadrada(-2*LogarimoNatural(r1))
			   r1 y r2 son números aleatorios   */
			Random Azar = new();
			double M = 100;
			double D = 7;
			for (int cont = 1; cont <= 100; cont++) {
				double r1 = Azar.NextDouble();
				double r2 = Azar.NextDouble();
				double valA = Math.Cos(2 * Math.PI * r2);
				double valB = Math.Sqrt(-2 * Math.Log(r1));
				double c = valA * valB;
				double variable = M + D * c;
				Console.Write(variable + "; ");
			}
		}
	}
}