namespace Ejemplo {
	//Declara una interface (el estándar dice que debe empezar con la letra "I")
	interface IMetodosRequeridos {
		//Métodos requeridos en las clases que implementen esta interface
		double AreaFigura();
		double PerimetroFigura();

	}
	
	//Esta clase debe implementar lo que dice la interface
	class Circulo : IMetodosRequeridos {
		public double Radio { get; set; }

		public Circulo(double Radio) {
			this.Radio = Radio;
		}

		//Implementa los métodos señalados por la interface
		public double AreaFigura() {
			return Math.PI * Radio * Radio;
		}

		public double PerimetroFigura() {
			return 2 * Math.PI * Radio;
		}
	}
	
	//Esta clase debe implementar lo que dice la interface
	class Cuadrado : IMetodosRequeridos {
		public double Lado { get; set; }
		
		public Cuadrado(double Lado) {
			this.Lado = Lado;
		}

		//Implementa los métodos señalados por la interface
		public double AreaFigura() {
			return Lado * Lado;
		}

		public double PerimetroFigura() {
			return 4 * Lado;
		}
	}

	//Inicia la aplicación aquí
	class Program {
		static void Main() {
			//Instancia las clases
			Cuadrado objCuadrado = new Cuadrado(5);
			Circulo objCirculo = new Circulo(5);

			//Imprime los valores
			Console.WriteLine("Área del círculo: " + objCirculo.AreaFigura().ToString());
			Console.WriteLine("Área del cuadrado: " + objCuadrado.AreaFigura().ToString());
			Console.WriteLine("Perímetro del círculo: " + objCirculo.PerimetroFigura().ToString());
			Console.WriteLine("Perímetro del cuadrado: " + objCuadrado.PerimetroFigura().ToString());
		}
	}
}
