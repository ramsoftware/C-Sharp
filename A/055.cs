namespace Ejemplo {
	internal class Program {
		static void Main() {
			//Función con doble salida. Nuevo en C# 7.0
			double radio = 1;
			double perimetro, area;
			Circulo(radio, out perimetro, out area);
			Console.WriteLine("Area del círculo: " + area);
			Console.WriteLine("Perímetro del círculo: " + perimetro);
		}

		//Retorna dos valores: el área y el perímetro del círculo
		static void Circulo(double R, out double Perimetro, out double Area) {
			Area = Math.PI * R * R;
			Perimetro = 2 * Math.PI * R;
		}
	}
}
