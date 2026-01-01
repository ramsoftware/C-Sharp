namespace Ejemplo;

//Inicia la aplicación aquí
internal class Program {

	//Una "clase especial" para almacenar constantes
	enum Valores {
		valorA = 89,
		valorB = 12,
		valorC = 47,
		valorD = 63
	}

	static void Main() {
		Valores unosValores = Valores.valorC;
		Console.WriteLine(unosValores);
		Console.WriteLine((int)unosValores);
	}
}