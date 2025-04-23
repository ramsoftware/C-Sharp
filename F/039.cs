using System.Text.Json.Nodes;

//JSON y LINQ
namespace Ejemplo {
	class Program {
		static void Main() {
			string EjemploJSON = @"
			{
				""Linea"": {
					""titulo"": ""Ejemplo de LINQ to JSON"",
					""items"": [
						{ ""titulo"": ""Teclado Mc"", ""descripcion"": ""Teclado mecánico"" },
						{ ""titulo"": ""Teclado Mb"", ""descripcion"": ""Teclado de membrana"" },
						{ ""titulo"": ""Mouse Ina"", ""descripcion"": ""Mouse inalámbrico"" }
					]
				}
			}";

			// Parsear el JSON
			JsonNode rss = JsonNode.Parse(EjemploJSON);

			// Consultar las descripciones de los artículos usando LINQ
			var titulos = rss["Linea"]["items"]
				.AsArray()
				.Select(item => item["descripcion"].ToString());

			// Mostrar los títulos
			foreach (var titulo in titulos) {
				Console.WriteLine(titulo);
			}
		}
	}
}
