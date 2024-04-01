namespace Ejemplo {
	internal class Program {
		static void Main() {
			//Tipo implícito de arreglo
			var arregloA = new[] { 16, 83, 29, 29 };
			var arregloB = new[] { 'R', 'a', 'f', 'a', 'e', 'l' };
			var arregloC = new[] { "Esta", "es", "una", "prueba" };
			var arregloD = new[] { true, false, false, true };
			var arregloE = new[] { 3.1, 8.9, 2.3 };

			//Imprime los tipos
			Console.WriteLine("Tipo ArregloA: " + arregloA.GetType().ToString());
			Console.WriteLine("Tipo ArregloB: " + arregloB.GetType().ToString());
			Console.WriteLine("Tipo ArregloC: " + arregloC.GetType().ToString());
			Console.WriteLine("Tipo ArregloD: " + arregloD.GetType().ToString());
			Console.WriteLine("Tipo ArregloE: " + arregloE.GetType().ToString());
		}
	}
}
