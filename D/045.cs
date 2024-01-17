//Patrón de diseño: Composite
namespace Ejemplo {
	public class Empleado {
		private string nombre;
		private string departamento;
		private int salario;
		private List<Empleado> subordinados;

		//Constructor
		public Empleado(string nombre, string departamento, int salario) {
			this.nombre = nombre;
			this.departamento = departamento;
			this.salario = salario;
			subordinados = new List<Empleado>();
		}

		public void Adicionar(Empleado objEmpleado) {
			subordinados.Add(objEmpleado);
		}

		public void Quitar(Empleado objEmpleado) {
			subordinados.Remove(objEmpleado);
		}

		public List<Empleado> GetSubordinados() {
			return subordinados;
		}

		public new string ToString() {
			return "Empleado => Nombre: " + nombre + ", departamento: " + departamento + ", salario: " + salario.ToString();
		}
	}
	
	internal class Program {
		static void Main() {
			Empleado Gerente = new Empleado("Laura", "Gerente", 5000000);
			Empleado jefeVentas = new Empleado("Patricia", "Jefa de Ventas", 3000000);
			Empleado jefeMercadeo = new Empleado("Adriana", "Jefa de Mercadeo", 3000000);
			Empleado disenador1 = new Empleado("Sandra", "Marketing", 2000000);
			Empleado disenador2 = new Empleado("Alejandra", "Marketing", 2000000);
			Empleado vendedor1 = new Empleado("Francisca", "Ventas", 200000);
			Empleado vendedor2 = new Empleado("Flor", "Ventas", 2000000);

			Gerente.Adicionar(jefeVentas);
			Gerente.Adicionar(jefeMercadeo);

			jefeVentas.Adicionar(vendedor1);
			jefeVentas.Adicionar(vendedor2);

			jefeMercadeo.Adicionar(disenador1);
			jefeMercadeo.Adicionar(disenador2);

			//Imprime todos los empleados de la organización
			Console.WriteLine(Gerente.ToString());

			foreach (Empleado jefe in Gerente.GetSubordinados()) {
				Console.WriteLine(jefe.ToString());

				foreach (Empleado empleado in jefe.GetSubordinados()) {
					Console.WriteLine(empleado.ToString());
				}
			}
		}
	}
}
