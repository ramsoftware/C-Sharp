//Patrón: Abstract Factory
namespace Ejemplo {
	//Interface que obliga a definir el método dibujar
	public interface IFigura {
		void Dibujar();
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
	
	class Circulo : IFigura {
		public void Dibujar() {
			Console.WriteLine("Se hace el dibujo de un círculo");
		}
	}
	
	public interface IColor {
		void Rellenar();
	}
	
	class Rojo : IColor {
		public void Rellenar() {
			Console.WriteLine("Pinta de rojo");
		}
	}
	
	class Verde : IColor {
		public void Rellenar() {
			Console.WriteLine("Un verde es pintado");
		}
	}
	
	class Azul : IColor {
		public void Rellenar() {
			Console.WriteLine("Ahora de azul es rellenado");
		}
	}
	
	public abstract class FabricaAbstracta {
		public abstract IFigura GetFigura(string TipoFigura);
		public abstract IColor GetColor(string color);
	}
	
	public class FabricaFiguras : FabricaAbstracta {
		//Dependiendo del parámetro retorna uno u otro objeto 
		public override IFigura GetFigura(string TipoFigura) {
			if (TipoFigura.Equals("CIRCULO")) return new Circulo();
			if (TipoFigura.Equals("RECTANGULO")) return new Rectangulo();
			if (TipoFigura.Equals("TRIANGULO")) return new Triangulo();
			return null;
		}

		public override IColor GetColor(string color) {
			return null;
		}
	}
	
	class FabricaColores : FabricaAbstracta {
		//Dependiendo del parámetro retorna uno u otro objeto 
		public override IFigura GetFigura(string TipoFigura) {
			return null;
		}

		public override IColor GetColor(string color) {
			if (color.Equals("ROJO")) return new Rojo();
			if (color.Equals("VERDE")) return new Verde();
			if (color.Equals("AZUL")) return new Azul();
			return null;
		}
	}
	
	class ProductorDeFabricas {
		public static FabricaAbstracta GetFabrica(string seleccion) {
			if (seleccion.Equals("FIGURA")) return new FabricaFiguras();
			if (seleccion.Equals("COLOR")) return new FabricaColores();
			return null;
		}
	}

	class Program {
		static void Main() {
			//Trae una determinada fábrica en este caso de FIGURA 
			FabricaAbstracta fabricaFiguras = ProductorDeFabricas.GetFabrica("FIGURA");

			//Obtenida la fábrica, se solicita un tipo de objeto de esa fábrica
			IFigura figura1 = fabricaFiguras.GetFigura("CIRCULO");

			//Llama un método de ese objeto dado por la fábrica en particular
			figura1.Dibujar();

			//Obtenida la fábrica, se solicita un tipo de objeto de esa fábrica
			IFigura figura2 = fabricaFiguras.GetFigura("RECTANGULO");

			//Llama un método de ese objeto dado por la fábrica en particular
			figura2.Dibujar();

			//Obtenida la fábrica, se solicita un tipo de objeto de esa fábrica 
			IFigura figura3 = fabricaFiguras.GetFigura("TRIANGULO");

			//Llama un método de ese objeto dado por la fábrica en particular
			figura3.Dibujar();

			//Trae una determinada fábrica en este caso de COLOR
			FabricaAbstracta FabricaColores = ProductorDeFabricas.GetFabrica("COLOR");

			//Obtenida la fábrica, se solicita un tipo de objeto de esa fábrica
			IColor color1 = FabricaColores.GetColor("ROJO");

			//Llama un método de ese objeto dado por la fábrica en particular
			color1.Rellenar();

			//Obtenida la fábrica, se solicita un tipo de objeto de esa fábrica
			IColor color2 = FabricaColores.GetColor("VERDE");

			//Llama un método de ese objeto dado por la fábrica en particular
			color2.Rellenar();

			//Obtenida la fábrica, se solicita un tipo de objeto de esa fábrica
			IColor color3 = FabricaColores.GetColor("AZUL");

			//Llama un método de ese objeto dado por la fábrica en particular
			color3.Rellenar();
		}
	}
}
