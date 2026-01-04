namespace Ejemplo;

internal class Especie(int Codigo, string Nombre) {
	public int Codigo { get; set; } = Codigo;
	public string Nombre { get; set; } = Nombre;
}

internal class Mascota(int Especie, string Nombre) {
	public int Especie { get; set; } = Especie;
	public string Nombre { get; set; } = Nombre;
}

internal class Program {
	static void Main() {
		List<Especie> listaEspecies =
		[
			new Especie(1, "Gato"),
			new Especie(2, "Conejo"),
			new Especie(3, "Ave"),
		];

		List<Mascota> listaMascotas =
		[
			new Mascota(1, "Suini"),
			new Mascota(1, "Gris"),
			new Mascota(1, "Sally"),
			new Mascota(1, "Tinita"),
			new Mascota(2, "Krousky"),
			new Mascota(1, "Capuchina"),
			new Mascota(1, "Tammy"),
			new Mascota(1, "Grisú"),
			new Mascota(3, "Lua"),
			new Mascota(2, "Copo"),
			new Mascota(1, "Vikingo"),
			new Mascota(1, "Arian"),
			new Mascota(1, "Milú"),
			new Mascota(3, "Azulin"),
			new Mascota(1, "Frac"),
			new Mascota(3, "Negro"),
			new Mascota(2, "Clopa"),
		];

		var Consulta = from mascota in listaMascotas
					   join especie in listaEspecies
					   on mascota.Especie equals especie.Codigo
					   select new {
						   Mascota = "Nombre Mascota: " + mascota.Nombre,
						   Especie = "Especie: " + especie.Nombre
					   };

		foreach (var item in Consulta) {
			Console.WriteLine(item.Mascota + " : " + item.Especie);
		}
	}
}
