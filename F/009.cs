namespace Ejemplo {
	internal class Program {
		static void Main() {
			//Fuente de datos, un arreglo unidimensional
			string[] Lista = [ "búho", "loro", "gaviota",
					"azulejo", "bichofue", "canario" ];

			//Consulta, especies de aves que tengan
			//la letra 'a'
			//¡OJO! Aquí si se ejecuta la consulta de una vez
			int Cuenta = (from aves in Lista
						  where aves.Contains("a")
						  select aves).Count();

			//Ejecuta la consulta y la imprime
			Console.WriteLine("Aves con letra a: " + Cuenta);
		}
	}
}