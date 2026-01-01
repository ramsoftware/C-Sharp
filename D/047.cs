namespace Ejemplo;
//Patrón de diseño: Modelo Vista Controlador
class Gente {
	public string Codigo { get; set; }
	public string Nombre { get; set; }
}

class ControladorGente {
	private Gente modelo;
	private VisorGente vista;

	public ControladorGente(Gente modelo, VisorGente vista) {
		this.modelo = modelo;
		this.vista = vista;
	}

	public void setNombreGente(string nombre) {
		modelo.Nombre = nombre;
	}

	public string getNombreGente() {
		return modelo.Nombre;
	}

	public void setCodigoGente(string codigo) {
		modelo.Codigo = codigo;
	}

	public string getCodigoGente() {
		return modelo.Codigo;
	}

	public void ActualizarVista() {
		vista.ImprimeGente(modelo.Nombre, modelo.Codigo);
	}
}

class VisorGente {
	public void ImprimeGente(string Nombre, string Codigo) {
		Console.WriteLine("Gente: ");
		Console.WriteLine("Nombre: " + Nombre);
		Console.WriteLine("Código: " + Codigo);
	}
}

class Program {
	static void Main() {
		Gente modelo = TraeGenteBaseDatos();
		VisorGente vista = new();
		ControladorGente control = new(modelo, vista);

		control.ActualizarVista();
		control.setNombreGente("Laura");
		control.ActualizarVista();
	}

	private static Gente TraeGenteBaseDatos() {
		Gente Gente = new();
		Gente.Nombre = "Johanna";
		Gente.Codigo = "17123456";
		return Gente;
	}
}