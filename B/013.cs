using System.Diagnostics; //Requiere para medir tiempos
using System.Text; //Requiere para StringBuilder

namespace Ejemplo {
	internal class Program {
		static void Main() {
			//StringBuilder, comparando la velocidad
			StringBuilder cadenaRapida = new StringBuilder();
			string cadenaClasica = "";

			//Medidor de tiempos
			Stopwatch cronometro = new Stopwatch();

			//Agrega caracteres a un StringBuilder
			cronometro.Reset();
			cronometro.Start();
			for (int numero=0; numero <= 20000; numero++) {
				cadenaRapida.Append(numero.ToString());
			}
			long TBuilder = cronometro.ElapsedMilliseconds;

			//Agrega caracteres a un string
			cronometro.Reset();
			cronometro.Start();
			for (int numero = 0; numero <= 20000; numero++) {
				cadenaClasica += numero.ToString();
			}
			long TClasica = cronometro.ElapsedMilliseconds;

			Console.WriteLine("Tiempo en milisegundos StringBuilder: " + TBuilder.ToString());
			Console.WriteLine("Tiempo en milisegundos cadena clásica: " + TClasica.ToString());
			Console.WriteLine("Tamaño StringBuilder: " + cadenaRapida.Length);
			Console.WriteLine("Tamaño cadena clásica: " + cadenaClasica.Length);
		}
	}
}
