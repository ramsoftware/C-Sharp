namespace Ejemplo {
	internal class Program {
		static void Main() {
			Console.WriteLine("Compleja expresión booleana");
			Console.WriteLine(!true && true | !false & true ^ true & !false);
			Console.WriteLine(!true | false & true ^ false && !true & true);
			Console.WriteLine(!false | !true ^ !true & false & !false);

			/* Precedencia de los operadores. Tomado de:
			https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/boolean-logical-operators 
				Logical negation operator !
				Logical AND operator &
				Logical exclusive OR operator ^
				Logical OR operator |
				Conditional logical AND operator &&
				Conditional logical OR operator ||
			*/
		}
	}
}
