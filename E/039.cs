using System.Collections;
using System.Text.Json;

namespace Ejemplo {
	class Elemento {
		public string Tipo { get; set; }
		public JsonElement Valor { get; set; }
	}

	class Program {
		static void Main() {
			ArrayList lista = new ArrayList { "Hola", true, 3.14, 'A' };
			var serializable = new List<Elemento>();

			foreach (var item in lista) {
				serializable.Add(new Elemento {
					Tipo = item.GetType().FullName,
					Valor = JsonSerializer.SerializeToElement(item)
				});
			}

			// Guardar como JSON
			var json = JsonSerializer.Serialize(serializable);
			File.WriteAllText("datos.json", json);

			// Leer desde JSON
			var jsonLeido = File.ReadAllText("datos.json");
			var elementos = JsonSerializer.Deserialize<List<Elemento>>(jsonLeido);

			var listaLeida = new ArrayList();
			foreach (var e in elementos) {
				object valorConvertido = e.Tipo switch {
					"System.String" => e.Valor.GetString(),
					"System.Boolean" => e.Valor.GetBoolean(),
					"System.Double" => e.Valor.GetDouble(),
					"System.Char" => e.Valor.GetString()[0],
					_ => throw new NotSupportedException($"Tipo no soportado: {e.Tipo}")
				};

				listaLeida.Add(valorConvertido);
			}

			foreach (var item in listaLeida) {
				Console.WriteLine($"{item} ({item.GetType()})");
			}
		}
	}
}
