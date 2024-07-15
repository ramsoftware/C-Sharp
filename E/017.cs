using System.Collections;

namespace Ejemplo {
	class Program {
		public static void Main() {
			//Declara la lista que almacenará cadenas
			ArrayList Ejemplo = new();

			//Para agregar elementos al azar
			Random azar = new();

			//Va agregando elementos al azar,
			//imprime el tamaño y la capacidad
			for (int veces = 1; veces <= 50; veces++) {
				Console.WriteLine("\r\nIteración: " + veces);
				Console.WriteLine("Tamaño: " + Ejemplo.Count);
				Console.WriteLine("Capacidad: " + Ejemplo.Capacity);
				for (int cont = 1; cont <= 30; cont++) {
					Ejemplo.Add(azar.NextDouble());
				}
			}
		}
	}
}
