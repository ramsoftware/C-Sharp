using System.Text.Json;

namespace Ejemplo;

[Serializable]
public class Persona {
	public string Nombre { get; set; }
	public int Telefono { get; set; }
}

internal class Program {
	static void Main(string[] args) {
		var persona = new Persona { Nombre = "Rafael", Telefono = 312456789 };

		// Guardar
		var json = JsonSerializer.Serialize(persona);
		File.WriteAllText("persona.json", json);

		// Leer
		var jsonLeido = File.ReadAllText("persona.json");
		var personaLeida = JsonSerializer.Deserialize<Persona>(jsonLeido);

		//Imprime
		Console.WriteLine("Nombre: " + personaLeida.Nombre);
		Console.WriteLine("Teléfono: " + personaLeida.Telefono);
	}
}