namespace Ejemplo {
	internal class Program {
		static void Main() {
			//Otras funciones matemáticas
			double valorReal = 5.0713;
			double valAbsoluto = Math.Abs(valorReal); //valor absoluto
			double valTecho = Math.Ceiling(valorReal); //entero superior
			double valExponencial = Math.Exp(valorReal);
			double valPiso = Math.Floor(valorReal);
			double valLogaritmoNatural = Math.Log(valorReal);
			double valLogaritmoBase10 = Math.Log10(valorReal);
			double valMaximoEntero = Math.Max(7, 19);
			double valMinimoEntero = Math.Min(7, 19);
			double valRedondea = Math.Round(valorReal);
			double valSigno = Math.Sign(valorReal);
			double valRaizC = Math.Sqrt(valorReal); //raiz cuadrada
			double valTrunca = Math.Truncate(valorReal);
			
			Console.WriteLine("Valor: " + valorReal.ToString());
			Console.WriteLine("Valor absoluto es: " + valAbsoluto.ToString());
			Console.WriteLine("Valor techo es: " + valTecho.ToString());
			Console.WriteLine("Exponencial es: " + valExponencial.ToString());
			Console.WriteLine("Valor piso es: " + valPiso.ToString());
			Console.WriteLine("Logaritmo Natural es: " + valLogaritmoNatural.ToString());
			Console.WriteLine("Logaritmo Base 10 es: " + valLogaritmoBase10.ToString());
			Console.WriteLine("Máximo entero es: " + valMaximoEntero.ToString());
			Console.WriteLine("Mínimo entero es: " + valMinimoEntero.ToString());
			Console.WriteLine("Redondea: " + valRedondea.ToString());
			Console.WriteLine("Signo es: " + valSigno.ToString());
			Console.WriteLine("Raiz cuadrada es: " + valRaizC.ToString());
			Console.WriteLine("Trunca: " + valTrunca.ToString());

			//Funciones con dos salidas
			int residuo;
			int cociente = Math.DivRem(29, 4, out residuo);
			Console.WriteLine("29/4 cociente: " + cociente.ToString() + " residuo: " + residuo.ToString());

			//Multiplicación enorme
			long valMultiplica = Math.BigMul(123456789, 987654321);
			Console.WriteLine("Multiplicación enorme: " + valMultiplica.ToString());

			//División modular, operación y funciones
			decimal dividendo = 100, divisor = 34;
			decimal residuoA = dividendo % divisor;
			decimal residuoB = (Math.Abs(dividendo) - (Math.Abs(divisor) * (Math.Floor(Math.Abs(dividendo) / Math.Abs(divisor))))) * Math.Sign(dividendo);
			Console.WriteLine("ResiduoA: " + residuoA.ToString() + " ResiduoB: " + residuoB.ToString());
		}
	}
}