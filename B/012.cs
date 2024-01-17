using System.Text; //Requiere para StringBuilder

namespace Ejemplo {
	internal class Program {
		static void Main() {
			//StringBuilder, mayor velocidad y se puede modificar
			StringBuilder cadenaRapida = new StringBuilder("Esta es una prueba");
			Console.WriteLine(cadenaRapida.ToString());

			//Cambia el primer caracter
			cadenaRapida[0] = 'e';
			Console.WriteLine(cadenaRapida.ToString());

			//Agrega caracteres
			for (int numero=0; numero <= 9; numero++) {
				cadenaRapida.Append(numero.ToString());
			}
			Console.WriteLine(cadenaRapida.ToString());
		}
	}
}