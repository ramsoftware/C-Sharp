namespace Ejemplo;

internal class Program {
	static void Main() {
		//Función con doble salida. Nuevo en C# 7.0
		double radio = 1;
		double perimetro, area;
		area = DatosCirculo(radio, out perimetro);
		Console.WriteLine("Area del círculo es: " + area);
		Console.WriteLine("Perímetro del círculo es: " + perimetro);
	}

	//Retorna dos valores: el área y el perímetro del círculo
	static double DatosCirculo(double Radio, out double Perimetro) {
		double area = Math.PI * Radio * Radio;
		Perimetro = 2 * Math.PI * Radio;
		return area;
	}
}