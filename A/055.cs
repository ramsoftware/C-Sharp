namespace Ejemplo {
	internal class Program {
		static void Main() {
			//Función con doble salida. Nuevo en C# 7.0
			double radio = 1;
			double perimetro, area;
			DatosCirculo(radio, out perimetro, out area);
			Console.WriteLine("Area del círculo es: " + area.ToString());
			Console.WriteLine("Perímetro del círculo es: " + perimetro.ToString());
		}

		//Retorna dos valores: el área y el perímetro del círculo
		static void DatosCirculo(double Radio, out double Perimetro, out double Area) {
			Area = Math.PI * Radio * Radio;
			Perimetro = 2 * Math.PI * Radio;
		}
	}
}
