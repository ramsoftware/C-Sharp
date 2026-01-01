namespace Ejemplo;
//Patrón: Singleton

class ObjetoUnico {
	//Genera un objeto de ObjetoUnico
	private static ObjetoUnico instancia = new ObjetoUnico();

	//Hace el constructor privado por lo que
	//no puede ser instanciado
	private ObjetoUnico() { }

	//Retorna la única instancia de esta clase
	public static ObjetoUnico GetInstancia() {
		return instancia;
	}

	public void Mensaje() {
		Console.WriteLine("Esta es una prueba");
	}
}

class Program {
	static void Main() {
		//Quite el comentario de esta instrucción
		//y generará un error al compilar
		//ObjetoUnico pruebaObjeto = new ObjetoUnico();

		//Obtiene el único objeto instanciable
		ObjetoUnico miObjeto = ObjetoUnico.GetInstancia();

		//Muestra un mensaje
		miObjeto.Mensaje();
	}
}