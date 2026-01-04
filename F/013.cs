namespace Ejemplo;

internal class Mascota {
	public string Especie { get; set; }
	public string Nombre { get; set; }
	public Mascota(string Especie, string Nombre) {
		this.Especie = Especie;
		this.Nombre = Nombre;
	}

	public void Imprime() {
		Console.Write("Especie: " + Especie);
		Console.WriteLine(" Nombre: " + Nombre);
	}
}

internal class Program {
	static void Main() {
		//Fuente de datos, una lista
		List<Mascota> listaMascotas =
		[
			new Mascota("gato", "Suini"),
			new Mascota("gato", "Gris"),
			new Mascota("gato", "Sally"),
			new Mascota("gato", "Tinita"),
			new Mascota("conejo", "Krousky"),
			new Mascota("gato", "Capuchina"),
			new Mascota("gato", "Tammy"),
			new Mascota("gato", "Grisú"),
			new Mascota("ave", "Lua"),
			new Mascota("conejo", "Copo"),
			new Mascota("gato", "Vikingo"),
			new Mascota("gato", "Arian"),
			new Mascota("gato", "Milú"),
			new Mascota("ave", "Azulin"),
			new Mascota("gato", "Frac"),
			new Mascota("ave", "Negro"),
			new Mascota("conejo", "Clopa"),
		];

		//Ordene primero por especie y luego por nombre
		List<Mascota> Resultados = (from animal in listaMascotas
									orderby animal.Especie,
									animal.Nombre
									select animal).ToList();

		//Ejecuta la consulta y la imprime
		for (int Cont = 0; Cont < Resultados.Count; Cont++) {
			Resultados[Cont].Imprime();
		}
	}
}