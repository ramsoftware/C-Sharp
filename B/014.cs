namespace Ejemplo {
	internal class Program {
		static void Main() {
			//Cortando espacios
			string cadenaA = "	 espacios al inicio y al final	 ";
			Console.WriteLine("[" + cadenaA + "]");

			//Quita los espacios de inicio y fin
			string cadenaB = cadenaA.Trim(' ');
			Console.WriteLine("[" + cadenaB + "]\r\n");

			//¿Y si son tabuladores? Los retira: \t
			string cadenaC = "\t\tUsando tabuladores al inicio y final\t\t";
			Console.WriteLine("[" + cadenaC + "]");
			string cadenaD = cadenaC.Trim('\t');
			Console.WriteLine("[" + cadenaD + "]");

			//Retirar los tabuladores de la izquierda
			string cadenaE = cadenaC.TrimStart('\t');
			Console.WriteLine("[" + cadenaE + "]");

			//Retirar los tabuladores de la derecha
			string cadenaF = cadenaC.TrimEnd('\t');
			Console.WriteLine("[" + cadenaF + "]\r\n");

			//Retirar otro caracter
			cadenaA = "aaaaaaaaaaUN CARACTER AL INICIO Y FINALaaaaaaaaaaaa";
			Console.WriteLine("[" + cadenaA + "]");
			string cadenaG = cadenaA.Trim('a');
			Console.WriteLine("[" + cadenaG + "]");
		}
	}
}
