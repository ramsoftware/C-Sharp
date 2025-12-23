namespace Ejemplo;

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
		double valRedondea = Math.Round(valorReal);
		double valSigno = Math.Sign(valorReal);
		double valRaizC = Math.Sqrt(valorReal); //raiz cuadrada
		double valTrunca = Math.Truncate(valorReal);

		Console.WriteLine("Valor: " + valorReal);
		Console.WriteLine("Valor absoluto es: " + valAbsoluto);
		Console.WriteLine("Valor techo es: " + valTecho);
		Console.WriteLine("Exponencial es: " + valExponencial);
		Console.WriteLine("Valor piso es: " + valPiso);
		Console.WriteLine("Logaritmo Natural es: " + valLogaritmoNatural);
		Console.WriteLine("Logaritmo Base 10 es: " + valLogaritmoBase10);
		Console.WriteLine("Redondea: " + valRedondea);
		Console.WriteLine("Signo es: " + valSigno);
		Console.WriteLine("Raiz cuadrada es: " + valRaizC);
		Console.WriteLine("Trunca: " + valTrunca);

		//Funciones con salidas
		var (cociente, residuo) = Math.DivRem(29, 4);
		Console.WriteLine("29/4 cociente: " + cociente);
		Console.WriteLine("29/4 residuo: " + residuo);

		//Multiplicación enorme
		long valMultiplica = Math.BigMul(123456789, 987654321);
		Console.WriteLine("123456789*987654321= " + valMultiplica);

		//División modular
		decimal dividendo = 100, divisor = 34;
		decimal Otroresiduo = dividendo % divisor;
		Console.WriteLine("100/4 => Residuo: " + Otroresiduo);
	}
}