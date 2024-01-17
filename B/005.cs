namespace Ejemplo {
	internal class Program {
		static void Main() {
			//Caracteres especiales. Salto de línea
			string cadenaA = "Este es un salto \r\n de línea";
			Console.WriteLine(cadenaA);

			//Caracteres especiales. Tabuladores
			string cadenaB = "123\t456\t789\t012";
			Console.WriteLine(cadenaB);

			//Caracteres especiales. Imprimir las comillas dobles
			string cadenaC = "Esto \"acelera\" la ejecución del programa";
			Console.WriteLine(cadenaC);

			//Usando el verbatim (toma los caracteres internos)
			string cadenaD = @"Uno puede seleccionar
								C# o Visual Basic .NET
							para programar en .NET
							ambos generan el mismo código precompilado";
			Console.WriteLine(cadenaD);
		}
	}
}
