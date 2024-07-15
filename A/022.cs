using System.Globalization;

namespace Ejemplo {
	internal class Program {
		static void Main() {
			//Fallos de conversión
			string valA = ""; //Una cadena nula o vacía daña la conversión

			//El programa se cae
			double valB = Convert.ToDouble(valA);
			Console.WriteLine("Valor B es: " + valB);

			//El programa se cae
			double valF = double.Parse(valA, CultureInfo.InvariantCulture);
			Console.WriteLine("Valor F es: " + valF);
		}
	}
}