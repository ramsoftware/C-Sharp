namespace Ejemplo {
	internal class Program {
		static void Main() {
			//Lee dos números por consola
			Console.Write("Escriba un primer número: ");
			double valorA = Convert.ToDouble(Console.ReadLine());

			Console.Write("Escriba un segundo número: ");
			double valorB = Convert.ToDouble(Console.ReadLine());

			//Si condicional
			if (valorA > valorB) {
				Console.WriteLine(valorA.ToString() + " es mayor que " + valorB.ToString());
			}
			else { //de lo contrario
				Console.WriteLine(valorA.ToString() + " es menor o igual que " + valorB.ToString());
			}
		}
	}
}