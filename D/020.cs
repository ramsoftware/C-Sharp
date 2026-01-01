namespace Ejemplo;

internal class Madre {
	public void Procedimiento() {
		Console.WriteLine("En la clase madre");
	}
}

internal class Hija : Madre {
	public new void Procedimiento() {
		Console.WriteLine("En la clase hija");
	}
}

//Inicia la aplicación aquí
internal class Program {
	static void Main() {
		Hija objHija = new();
		objHija.Procedimiento();
	}
}