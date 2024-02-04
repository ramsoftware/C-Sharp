namespace Ejemplo {
	internal class Program {
		static void Main() {
			List<string> ColoresA = new List<string>(){ "Azul", "Rojo", "Verde", "Marrón", "Violeta" };
			List<string> ColoresB = new List<string>(){ "Violeta", "Azul", "Marrón", "Naranja" };

			/* Une los valores de ambas listas evitando repetir */ 
			var Resultado = ColoresA.Union(ColoresB);

			foreach(string Cadena in Resultado)
				Console.WriteLine(Cadena);
		}
	}
}
