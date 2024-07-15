using System.Diagnostics;
using System.Text;

namespace Ejemplo {
	internal class Program {
		static void Main() {
			//StringBuilder, comparando la velocidad
			StringBuilder cadenaRapida = new();
			string cadenaClasica = "";
			int NumLetras = 70000;

			//Medidor de tiempos
			Stopwatch cronometro = new();

			//Agrega caracteres a un StringBuilder
			cronometro.Reset();
			cronometro.Start();

			for (int numero = 1; numero <= NumLetras; numero++)
				cadenaRapida.Append(numero);

			long TBuilder = cronometro.ElapsedMilliseconds;

			//Agrega caracteres a un string
			cronometro.Reset();
			cronometro.Start();

			for (int numero = 1; numero <= NumLetras; numero++)
				cadenaClasica += numero;

			long TClasica = cronometro.ElapsedMilliseconds;

			if (cadenaClasica == cadenaRapida.ToString()) {
				Console.WriteLine("Tiempo StringBuilder: " + TBuilder);
				Console.WriteLine("Tiempo cadena clásica: " + TClasica);
			}
			else
				Console.WriteLine("Prueba errónea");
		}
	}
}