namespace Ejemplo {
	internal class Program {
		static void Main() {
			//Declarar variable de tipo cadena (string). Dos formas.
			System.String cadenaA;
			string cadenaB;

			//Asignando valores de cadena
			cadenaA = "Esto es una prueba de texto";
			cadenaB = "Asignando valores alfanuméricos";

			//Imprimiendo por consola
			Console.WriteLine(cadenaA);
			Console.WriteLine(cadenaB);
			
			//Uniendo dos cadenas o concatenar
			string cadenaC = cadenaA + " <=0=> " + cadenaB;
			Console.WriteLine(cadenaC);
		}
	}
}