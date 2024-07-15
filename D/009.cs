namespace Ejemplo {
	class MiClase {
		private int valor;
		private string cadena;
		private double costo;

		public void UnMetodo(int valor, string cadena) {
			this.valor = valor;
			this.cadena = cadena;
			Console.WriteLine("Un método B");
		}

		public void UnMetodo(string cadena, int valor) {
			this.cadena = cadena;
			this.valor = valor;
			Console.WriteLine("Segundo método");
		}

		public void UnMetodo(double costo, int valor) {
			this.costo = costo;
			this.valor = valor;
			Console.WriteLine("Tercer método");
		}

		public void UnMetodo(string cadena, double costo) {
			this.cadena = cadena;
			this.costo = costo;
			Console.WriteLine("Cuarto método");
		}
	}
	
	//Inicia la aplicación aquí
	class Program {
		static void Main() {
			//Instancia o crea un objeto
			MiClase objetoA = new();
			objetoA.UnMetodo(48, "Rafael");
			objetoA.UnMetodo("Alberto", 26);
			objetoA.UnMetodo(1994.06, 48);
			objetoA.UnMetodo("Moreno Parra", 1683.29);
		}
	}
}
