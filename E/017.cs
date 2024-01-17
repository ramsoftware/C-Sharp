using System.Collections;

namespace Ejemplo {
	class Program {
		public static void Main() {
			//Declara la lista que almacenará cadenas
			ArrayList Ejemplo = new ArrayList();

			//Para agregar elementos al azar
			Random azar = new Random();

			//Va agregando elementos al azar, imprime el tamaño y la capacidad
			for (int veces = 1; veces <= 50; veces++) {
				Console.WriteLine("Iteración: " + veces.ToString());
				Console.WriteLine("Tamaño del ArrayList: " + Ejemplo.Count);
				Console.WriteLine("Capacidad del ArrayList: " + Ejemplo.Capacity + "\r\n");
				for (int cont = 1; cont <= 30; cont++) {
					Ejemplo.Add(azar.NextDouble());
				}
			}
		}
	}
}
