namespace Ejemplo {
	//Declara una interface (el estándar dice que debe empezar con la letra "I")
	interface ICalculos {
		//Métodos requeridos en las clases que implementen esta interface
		double AreaFigura();
		double PerimetroFigura();

	}
	
	//Otra interface para obligar a mostrar los resultados
	interface IMuestra {
		void ImprimeArea();
		void ImprimePerimetro();
	}
	
	//Implementa de varios Interface
	class Circulo : ICalculos, IMuestra {
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

		public void ImprimeArea() {
			Console.WriteLine("Área del círculo: " + AreaFigura().ToString());
		}

		public void ImprimePerimetro() {
			Console.WriteLine("Perímetro del círculo: " + PerimetroFigura().ToString());
		}
	}
	
	class Cuadrado : ICalculos, IMuestra {
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

		public void ImprimeArea() {
			Console.WriteLine("Área del cuadrado: " + AreaFigura().ToString());
		}

		public void ImprimePerimetro() {
			Console.WriteLine("Perímetro del cuadrado: " + PerimetroFigura().ToString());
		}
	}

	//Inicia la aplicación aquí
	class Program {
		static void Main() {
			//Instancia las clases
			Cuadrado objCuadrado = new Cuadrado(5);
			Circulo objCirculo = new Circulo(5);

			//Imprime los valores
			objCuadrado.ImprimeArea();
			objCuadrado.ImprimePerimetro();

			objCirculo.ImprimeArea();
			objCirculo.ImprimePerimetro();
		}
	}
}
