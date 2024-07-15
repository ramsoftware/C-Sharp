namespace Ejemplo {
	//Patrón de diseño: Composite

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
			string Cad = "Empleado => Nombre: " + nombre;
			Cad += ", departamento: " + departamento;
			Cad += ", salario: " + salario;
			return Cad;
		}
	}

	internal class Program {
		static void Main() {
			Empleado Gerente = new("Laura", "Gerente", 5000);
			Empleado jefeVentas = new("Patricia", "Ventas", 3000);
			Empleado jefeMercadeo = new("Adriana", "Mercadeo", 3000);
			Empleado disenador1 = new("Sandra", "Marketing", 2000);
			Empleado disenador2 = new("Alejandra", "Marketing", 2000);
			Empleado vendedor1 = new("Francisca", "Ventas", 2000);
			Empleado vendedor2 = new("Flor", "Ventas", 2000);

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
