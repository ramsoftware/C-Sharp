namespace Ejemplo {
	internal class Program {
		static void Main() {
			//Operadores booleanos
			bool valA = true;
			bool valB = false;

			bool Resultado1 = valA & valB; //Operador Y
			bool Resultado2 = valA | valB; //Operador O
			bool Resultado3 = valA ^ valB; //Operador XOR
			bool Resultado4 = !valA; //Operador negación

			Console.WriteLine(Resultado1);
			Console.WriteLine(Resultado2);
			Console.WriteLine(Resultado3);
			Console.WriteLine(Resultado4);
		}
	}
}