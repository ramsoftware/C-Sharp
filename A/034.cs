namespace Ejemplo {
	internal class Program {
		static void Main() {
			//Lee un valor entero
			Console.Write("Escriba un valor entero: ");
			int valor = Convert.ToInt32(Console.ReadLine());

			switch (valor) {
				case 1: Console.WriteLine("Escribió uno"); break;
				case 2: Console.WriteLine("Escribió dos, ");
					Console.WriteLine("que es un número par");
					break; //Hay que terminar con break
				case 3: //Esto sería el equivalente a un OR
				case 4:
				case 5: Console.WriteLine("Escribió 3 o 4 o 5");
					break;
				default: Console.WriteLine("Fuera del rango de 1 a 5");
					break; //Inclusive el default requiere break
			}
		}
	}
}