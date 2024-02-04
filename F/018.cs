namespace Ejemplo {
	internal class Program {
		static void Main() {
			List<string> ColoresA = new List<string>(){ "Azul", "Rojo", "Verde", "Violeta" };
			List<string> ColoresB = new List<string>(){ "Violeta", "Azul", "Marrón" };

			/* Muestra los colores comunes a ambas listas */ 
			var Resultado = ColoresA.Intersect(ColoresB);

			foreach(string Cadena in Resultado)
				Console.WriteLine(Cadena);
		}
	}
}
