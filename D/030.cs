namespace Ejemplo {

	interface IMetodos {
		void MetodoA();
		void MetodoB();
	}
	
	interface IProcedimientos {
		void ProcedimientoA();
		void ProcedimientoB();
	}
	
	class Madre {
		public void Aviso() {
			Console.WriteLine("Método de clase madre");
		}
	}
	
	//Hereda de Madre e implementa de IMetodos e IProcedimientos
	class Hija : Madre, IMetodos, IProcedimientos {
		public void Mensaje() {
			Console.WriteLine("En clase hija");
		}

		public void MetodoA() {
			Console.WriteLine("En MetodoA");
		}

		public void MetodoB() {
			Console.WriteLine("En MetodoB");
		}

		public void ProcedimientoA() {
			Console.WriteLine("En ProcedimientoA");
		}

		public void ProcedimientoB() {
			Console.WriteLine("En ProcedimientoB");
		}
	}

	//Inicia la aplicación aquí
	class Program {
		static void Main() {
			Hija objHija = new Hija();
			objHija.Aviso();
			objHija.Mensaje();
			objHija.MetodoA();
			objHija.ProcedimientoA();
		}
	}
}
