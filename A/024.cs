namespace Ejemplo;

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

		Console.WriteLine("Ángulo en grados es: " + anguloGrados);
		Console.WriteLine("Ángulo en radianes: " + anguloRadian);
		Console.WriteLine("Seno es: " + valSeno);
		Console.WriteLine("Coseno es: " + valCoseno);
		Console.WriteLine("Tangente es: " + valTangente);
		Console.WriteLine("arcoSeno es: " + arcoSeno);
		Console.WriteLine("arcoCoseno es: " + arcoCoseno);
		Console.WriteLine("arcoTangente es: " + arcoTangente);
	}
}