namespace Ejemplo {
	internal class Program {
		static void Main() {
			//Tabla del AND
			Console.WriteLine("\r\nTabla del operador AND");
			Console.WriteLine(true && true);
			Console.WriteLine(true && false);
			Console.WriteLine(false && true);
			Console.WriteLine(false && false);

			//Tabla del OR
			Console.WriteLine("\r\nTabla del operador OR");
			Console.WriteLine(true || true);
			Console.WriteLine(true || false);
			Console.WriteLine(false || true);
			Console.WriteLine(false || false);

			/* La diferencia entre & y &&, | y || es que cuando se
			 * usa & se evalúan ambos operandos a la izquierda y derecha del &, 
			 * en cambio cuando se usa && se evalúa primero el operando de la izquierda 
			 * y si da falso, ya se sabe que toda la expresión es falsa. Luego en 
			 * un si condicional, se ejecuta más rápido si se usa && en vez de &. 
			 * Similar se aplica para || o | , si se usa en un si condicional
			 * evalúa el primer operando, si es verdadero, toda la expresión es verdadera. */
		}
	}
}