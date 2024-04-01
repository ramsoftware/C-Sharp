namespace Ejemplo {
	
	internal class MiClase {
		//Constructor
		public MiClase() {
			//Llama a otros métodos
			MetodoA();
			MetodoB();
		}

		public void MetodoA() {
			Console.WriteLine("Ha llamado el método A");
		}

		private void MetodoB() {
			Console.WriteLine("Ha llamado el método B");
		}
	}
	
	//Inicia la aplicación aquí
	internal class Program {
		static void Main() {
			MiClase objeto = new MiClase();
		}
	}
}
