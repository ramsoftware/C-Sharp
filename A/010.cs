namespace Ejemplo {
	internal class Program {
		static void Main() {
			//Declara variables de tipo double
			double valA = 17902.8421;
			double valB = -871901372.420821098765;
			double valC = 89341759342.1678;

			//Imprime con un formato de miles
			Console.WriteLine("Valor A con formato de miles es: {0:0,0.0}", valA);
			Console.WriteLine("Valor A con formato de miles y tres decimales es: {0:0,0.000}", valA);

			Console.WriteLine("\r\nValor B con formato de miles es: {0:0,0.0}", valB);
			Console.WriteLine("Valor B con formato de miles y tres decimales es: {0:0,0.000}", valB);

			Console.WriteLine("\r\nValor C con formato de miles es: {0:0,0.0}", valC);
			Console.WriteLine("Valor C con formato de miles y tres decimales es: {0:0,0.000}", valC);
		}
	}
}
