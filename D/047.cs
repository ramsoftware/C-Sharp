//Patrón de diseño: Modelo Vista Controlador
namespace Ejemplo {
	class Estudiante {
		public string Codigo { get; set; }
		public string Nombre { get; set; }
	}
	
	class ControladorEstudiante {
		private Estudiante modelo;
		private VisorEstudiante vista;

		public ControladorEstudiante(Estudiante modelo, VisorEstudiante vista) {
			this.modelo = modelo;
			this.vista = vista;
		}

		public void setNombreEstudiante(string nombre) {
			modelo.Nombre = nombre;
		}

		public string getNombreEstudiante() {
			return modelo.Nombre;
		}

		public void setCodigoEstudiante(string codigo) {
			modelo.Codigo = codigo;
		}

		public string getCodigoEstudiante() {
			return modelo.Codigo;
		}

		public void ActualizarVista() {
			vista.ImprimeDetallesEstudiante(modelo.Nombre, modelo.Codigo);
		}
	}
	
	class VisorEstudiante {
		public void ImprimeDetallesEstudiante(string NombreEstudiante, string CodigoEstudiante) {
			Console.WriteLine("Estudiante: ");
			Console.WriteLine("Nombre: " + NombreEstudiante);
			Console.WriteLine("Código: " + CodigoEstudiante);
		}
	}
	
	class Program {
		static void Main() {
			Estudiante modelo = TraeEstudianteBaseDatos();
			VisorEstudiante vista = new VisorEstudiante();
			ControladorEstudiante controlador = new ControladorEstudiante(modelo, vista);

			controlador.ActualizarVista();
			controlador.setNombreEstudiante("Laura");
			controlador.ActualizarVista();
		}

		private static Estudiante TraeEstudianteBaseDatos() {
			Estudiante estudiante = new Estudiante();
			estudiante.Nombre = "Johanna";
			estudiante.Codigo = "17123456";
			return estudiante;
		}
	}
}
