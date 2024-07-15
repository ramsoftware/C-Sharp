namespace Ejemplo {
	class MiClase {
		private int valor;
		private string cadena;
		private double costo;
		public MiClase() {
			Console.WriteLine("Constructor por defecto");
		}

		public MiClase(int valor) {
			this.valor = valor;
			this.cadena = "por defecto";
			this.costo = 0;
			Console.WriteLine("Constructor B");
		}

		public MiClase(string cadena, int valor) {
			this.cadena = cadena;
			this.valor = valor;
			this.costo = 0;
			Console.WriteLine("Tercer Constructor");
		}

		public MiClase(double costo, int valor) {
			this.cadena = "por defecto";
			this.costo = costo;
			this.valor = valor;
			Console.WriteLine("El cuarto constructor");
		}

		public MiClase(string cadena, double costo, int valor) {
			this.cadena = cadena;
			this.costo = costo;
			this.valor = valor;
			Console.WriteLine("Quinto constructor");
		}
	}
	
	//Inicia la aplicación aquí
	class Program {
		static void Main() {
			//Instancia o crea un objeto
			MiClase objetoA = new();
			MiClase objetoB = new(48);
			MiClase objetoC = new(1972.06, 26);
			MiClase objetoD = new("Ramp", 48);
			MiClase objetoE = new("Moreno Parra", 1683.29, 29);
		}
	}
}
