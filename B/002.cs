namespace Ejemplo {
	internal class Program {
		static void Main() {
			//Rutas. Forma antigua
			string RutaA = "C:\\Users\\engin\\OneDrive\\Proyecto\\Libro\\16. C# Estructuras";
			
			//Ruta. Forma moderna
			string RutaB = @"C:\Users\engin\OneDrive\Proyecto\Libro\16. C# Estructuras";

			//Imprimiendo por consola
			Console.WriteLine(RutaA);
			Console.WriteLine(RutaB);
		}
	}
}