namespace Ejemplo {
	sealed class Madre {
		public void Aviso() {
			Console.WriteLine("Método en clase madre");
		}
	}
	
	class Hija : Madre {
		public void Mensaje() {
			Console.WriteLine("Método en clase hija");
		}
	}

	//Inicia la aplicación aquí
	class Program {
		static void Main() {
			Hija objHija = new Hija();
			objHija.Mensaje();
		}
	}
}
