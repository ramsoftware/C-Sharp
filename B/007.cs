namespace Ejemplo {
	internal class Program {
		static void Main() {
			//Tamaño de cadena y recorrerla
			string cadena = "QWERTYUIOPabcdefghijklmnñopqrstuvwxyz";
			int tamano = cadena.Length;
			Console.WriteLine(cadena);
			Console.WriteLine("Tamaño es: " + tamano.ToString());
			
			//Recorre la cadena
			for (int posicion=0; posicion < tamano; posicion++) {
				char letra = cadena[posicion]; //va de letra en letra
				Console.Write(letra.ToString() + " ; ");
			}
		}
	}
}
