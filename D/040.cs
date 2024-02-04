//Patrón: Factory Method
namespace Ejemplo {
	//Interface que obliga a definir el método dibujar
	interface IFigura {
		void Dibujar();
	}
	
	class Circulo : IFigura {
		public void Dibujar() {
			Console.WriteLine("Se hace el dibujo de un círculo");
		}
	}
	
	class Rectangulo : IFigura {
		public void Dibujar() {
			Console.WriteLine("Estoy dibujando un rectángulo");
		}
	}
	
	class Triangulo : IFigura {
		public void Dibujar() {
			Console.WriteLine("Ahora se dibuja un triángulo");
		}
	}
	
	class FabricaFiguras {
		//Dependiendo del parámetro retorna uno u otro objeto 
		public IFigura GetFigura(string TipoFigura) {
			if (TipoFigura.Equals("CIRCULO")) return new Circulo();
			if (TipoFigura.Equals("RECTANGULO")) return new Rectangulo();
			if (TipoFigura.Equals("TRIANGULO")) return new Triangulo();
			return null;
		}
	}
	
	class Program {
		static void Main() {
			FabricaFiguras objeto = new FabricaFiguras();

			//Obtiene un objeto círculo 
			IFigura Figura1 = objeto.GetFigura("CIRCULO");

			//Llama el método de dibujar del objeto círculo
			Figura1.Dibujar();

			//Obtiene un objeto rectángulo
			IFigura Figura2 = objeto.GetFigura("RECTANGULO");

			//Llama el método de dibujar del objeto rectángulo
			Figura2.Dibujar();

			//Obtiene un objeto triángulo
			IFigura Figura3 = objeto.GetFigura("TRIANGULO");

			//Llama el método de dibujar del objeto triángulo
			Figura3.Dibujar();
		}
	}
}
