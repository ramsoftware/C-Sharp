//Patrón: Builder
namespace Ejemplo {
	public interface IEmpacado {
		string Empaque(); //Obligar a hacer el método Empaque()
	}

	class Envoltura : IEmpacado {
		public string Empaque() {
			return "Empaque Ecológico";
		}
	}
	
	public class Botella : IEmpacado {
		public string Empaque() {
			return "Botella biodegradable";
		}
	}
	
	//Todo producto en la comida tendrá estos ítems: Nombre, como se empaca, precio
	public interface Item {
		string Nombre();
		IEmpacado EmpacandoProducto();
		float Precio();
	}
	
	public abstract class Hamburguesa : Item {
		public IEmpacado EmpacandoProducto() {
			return new Envoltura();
		}
		public abstract float Precio();
		public abstract string Nombre();
	}
	
	public class HamburguesaPollo : Hamburguesa {
		public override float Precio() {
			return 7000;
		}

		public override string Nombre() {
			return "Hamburguesa de pollo";
		}
	}
	
	class HamburguesaVegetariana : Hamburguesa {
		public override float Precio() {
			return 5000;
		}

		public override string Nombre() {
			return "Hamburguesa vegetariana";
		}
	}
	
	public abstract class BebidaFria : Item {
		public IEmpacado EmpacandoProducto() {
			return new Botella();
		}
		public abstract float Precio();
		public abstract string Nombre();
	}
	
	class Malteada : BebidaFria {
		public override float Precio() {
			return 4700;
		}

		public override string Nombre() {
			return "Malteada";
		}
	}
	
	class CaFeFrio : BebidaFria {
		public override float Precio() {
			return 4000;
		}

		public override string Nombre() {
			return "Café frío";
		}
	}
	
	class Comida {
		private List<Item> items = new List<Item>();

		public void AddItem(Item item) {
			items.Add(item);
		}

		public float GetCosto() {
			float costo = 0.0f;
			foreach (Item item in items) {
				costo += item.Precio();
			}
			return costo;
		}

		public void MostrarItems() {
			foreach (Item item in items) {
				Console.WriteLine("Item: " + item.Nombre());
				Console.WriteLine(", Empaque: " + item.EmpacandoProducto().Empaque());
				Console.WriteLine(", Precio: " + item.Precio());
			}
		}
	}
	
	//Prepara la comida dependiendo si es vegetariana o no
	class FabricaComida {
		public Comida PrepararComidaVegetariana() {
			Comida miComida = new Comida();
			miComida.AddItem(new HamburguesaVegetariana());
			miComida.AddItem(new CaFeFrio());
			return miComida;
		}

		public Comida PrepararComidaNoVegetariana() {
			Comida miComida = new Comida();
			miComida.AddItem(new HamburguesaPollo());
			miComida.AddItem(new Malteada());
			return miComida;
		}
	}
	
	class Program {
		static void Main() {
			FabricaComida miComida = new FabricaComida();

			Comida vegetariano = miComida.PrepararComidaVegetariana();
			Console.WriteLine("Comida vegetariana");
			vegetariano.MostrarItems();
			Console.WriteLine("Costo total: " + vegetariano.GetCosto());

			Comida noVegetariano = miComida.PrepararComidaNoVegetariana();
			Console.WriteLine("\n\nComida No vegetariana");
			noVegetariano.MostrarItems();
			Console.WriteLine("Costo total: " + noVegetariano.GetCosto());
		}
	}
}
