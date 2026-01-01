namespace Ejemplo;

//Compara dos valores si son iguales
public static class Utilidades {
	public static bool SonIguales<T>(T a, T b) {
		return EqualityComparer<T>.Default.Equals(a, b);
	}
}

internal class Program {
	static void Main(string[] args) {
		bool resultado1 = Utilidades.SonIguales(5, 5);			   // true
		bool resultado2 = Utilidades.SonIguales("hola", "adiós");	// false
		bool resultado3 = Utilidades.SonIguales(3.14, 3.14);		 // true

		Console.WriteLine(resultado1);
		Console.WriteLine(resultado2);
		Console.WriteLine(resultado3);
	}
}