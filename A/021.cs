using System.Globalization;

namespace Ejemplo {
	internal class Program {
		static void Main() {
			//Conversión de reales
			string valA = "4.78";

			//Da a problemas porque se ignora el punto decimal
			double valB = Convert.ToDouble(valA);
			Console.WriteLine("Valor B: " + valB);

			//Aquí si funciona la conversión
			string valC = "9,21";
			double valD = Convert.ToDouble(valC);
			Console.WriteLine("Valor D: " + valD);

			//Para usar la conversión con punto decimal,
			//se debe hacer uso de CultureInfo
			string valE = "6.8315";
			double valF = double.Parse(valE, CultureInfo.InvariantCulture);
			Console.WriteLine("Valor F: " + valF);
		}
	}
}
