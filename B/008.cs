namespace Ejemplo {
	internal class Program {
		static void Main() {
			//Subcadenas
			string cadena = "abcdefghijklmnñopqrstuvwxyz";

			string subCadA = cadena.Substring(3); //Del caracter 3 en adelante
			Console.WriteLine(subCadA);

			string subCadB = cadena.Substring(7, 4); //Del caracter 7 traiga 4 caracteres
			Console.WriteLine(subCadB);
		}
	}
}