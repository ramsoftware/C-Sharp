namespace Ejemplo {
	//Esta es una clase propia con sus atributos
	//y métodos (encapsulación)
	internal class MiClase {
		//Atributos privados
		private int Numero;
		private char Letra;
		private string Cadena;
		private double Valor;

		//Atributos públicos (no recomendado)
		public int Acumula;
		public char Caracter;

		//Métodos privados
		private double Maximo(double numA, double numB, double numC) {
			double max = numA;
			if (max < numB) max = numB;
			if (max < numC) max = numC;
			return max;
		}

		//Métodos públicos
		public double Promedio(double numA, double numB, double numC) {
			return (numA + numB + numC) / 3;
		}
	}

	//Inicia la aplicación aquí
	internal class Program {
		static void Main() {
			//Instancia o crea un objeto de MiClase
			MiClase Objeto = new();

			//Solo puede llamar al método público de MiClase
			double resultado = Objeto.Promedio(1, 7, 8);
			Console.WriteLine(resultado);
		}
	}
}