namespace Ejemplo {
	internal class Program {
		static void Main() {
			//Funciones trigonométricas
			double anguloGrados = 60;
			double anguloRadian = anguloGrados * Math.PI / 180;

			double valSeno = Math.Sin(anguloRadian);
			double valCoseno = Math.Cos(anguloRadian);
			double valTangente = Math.Tan(anguloRadian);

			double arcoSeno = Math.Asin(valSeno);
			double arcoCoseno = Math.Acos(valCoseno);
			double arcoTangente = Math.Atan(valTangente);

			Console.WriteLine("Ángulo en grados es: " + anguloGrados.ToString());
			Console.WriteLine("Ángulo en radianes: " + anguloRadian.ToString());
			Console.WriteLine("Seno es: " + valSeno.ToString());
			Console.WriteLine("Coseno es: " + valCoseno.ToString());
			Console.WriteLine("Tangente es: " + valTangente.ToString());
			Console.WriteLine("arcoSeno es: " + arcoSeno.ToString());
			Console.WriteLine("arcoCoseno es: " + arcoCoseno.ToString());
			Console.WriteLine("arcoTangente es: " + arcoTangente.ToString());
		}
	}
}