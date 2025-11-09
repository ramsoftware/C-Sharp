using System.Xml.Serialization;

namespace Ejemplo
{
	[Serializable]
	public class Persona {
		public string Nombre { get; set; }
		public int Telefono { get; set; }
	}

	internal class Program
	{
		static void Main(string[] args)
		{
			var persona = new Persona { Nombre = "Rafael", Telefono = 312456789 };

			var serializer = new XmlSerializer(typeof(Persona));
			using (var writer = new StreamWriter("persona.xml")) {
				serializer.Serialize(writer, persona);
			}

			// Leer
			using (var reader = new StreamReader("persona.xml")) {
				var personaLeida = (Persona)serializer.Deserialize(reader);

				//Imprime
				Console.WriteLine("Nombre: " + personaLeida.Nombre);
				Console.WriteLine("Teléfono: " + personaLeida.Telefono);
			}
		}
	}
}
