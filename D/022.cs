namespace Ejemplo;

internal class Abuela {
	//Constructor
	public Abuela() {
		Console.WriteLine("Constructor de la clase abuela");
	}

	//Método
	public void Mostrar() {
		Console.WriteLine("Mostrar en Abuela");
	}
}

internal class Madre : Abuela {
	//Constructor
	public Madre() {
		Console.WriteLine("Constructor de la clase madre");
	}

	public new void Mostrar() {
		base.Mostrar(); //Llama al método de la clase abuela
		Console.WriteLine("Mostrar en Madre");
	}
}

internal class Hija : Madre {
	//Constructor
	public Hija() {
		Console.WriteLine("Constructor de la clase hija");
	}

	public new void Mostrar() {
		base.Mostrar(); //Llama al método de la clase madre
		Console.WriteLine("Mostrar en Hija");
	}
}

//Inicia la aplicación aquí
internal class Program {
	static void Main() {
		//Instancia a la hija
		Hija objHija = new();

		//Ejecuta método
		objHija.Mostrar();
	}
}