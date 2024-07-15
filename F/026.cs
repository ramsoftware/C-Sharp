using System.Diagnostics;
/* Comparativa entre LINQ e implementación tradicional */

namespace Ejemplo {

	class Program {
		static void Main() {
			Console.WriteLine("Comparativa LINQ vs Clásico\r\n");

			//Generador de números aleatorios único
			Random Azar = new();
			for (int Probar = 1; Probar <= 20; Probar++)
				Pruebas(Azar);
		}

		static public void Pruebas(Random Azar) {
			//Llenar un List<int> con valores al azar
			List<int> Enteros = [];
			for (int Cont = 1; Cont <= 1000000; Cont++) {
				Enteros.Add(Azar.Next(-50, 50));
			}
			List<int> ResultadosLINQ = [];

			//===============
			//Prueba con LINQ
			//===============

			//Medidor de tiempos
			Stopwatch cronometro = new();
			cronometro.Reset();
			cronometro.Start();

			IEnumerable<int> Consulta =
				from numero in Enteros
				where (numero % 2) == 1
				select numero;

			//Ejecuta la consulta y guarda el rersultado en una lista 
			foreach (int Valor in Consulta)
				ResultadosLINQ.Add(Valor);

			long TiempoLINQ = cronometro.ElapsedMilliseconds;

			//Imprime el tiempo transcurrido y un valor de la lista
			Console.Write("Tiempo LINQ: " + TiempoLINQ);

			//===============
			//Prueba sin LINQ
			//===============
			List<int> ResultadosNOLINQ = [];
			cronometro.Reset();
			cronometro.Start();

			//Ejecuta la consulta y guarda el rersultado en una lista 
			foreach (int Valor in Enteros)
				if (Valor % 2 == 1) {
					ResultadosNOLINQ.Add(Valor);
				}

			long TiempoNOLINQ = cronometro.ElapsedMilliseconds;

			//Imprime el tiempo transcurrido y un valor de la lista
			Console.Write("  Tiempo NO LINQ: " + TiempoNOLINQ);

			if (ResultadosNOLINQ.Sum() == ResultadosLINQ.Sum())
				Console.WriteLine(" Coinciden");
			else
				Console.WriteLine(" ¡OJO! No hay coincidencia");
		}
	}
}