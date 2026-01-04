namespace Ejemplo;

internal class Mascota {
	public int Codigo { get; set; }
	public string Nombre { get; set; }
	public int FechaNace { get; set; } //Formato: aaaammdd

	public Mascota(int Codigo, string Nombre, int FechaNace) {
		this.Codigo = Codigo;
		this.Nombre = Nombre;
		this.FechaNace = FechaNace;
	}

	public void Imprime() {
		Console.Write("Código: " + Codigo);
		Console.Write(" Nombre: " + Nombre);
		Console.WriteLine(" Fecha Nacimiento: " + FechaNace);
	}
}

internal class Program {
	static void Main() {
		//Fuente de datos, una lista
		List<Mascota> listaMascotas = new List<Mascota>();
		listaMascotas.Add(new Mascota(1, "Suini", 20121012));
		listaMascotas.Add(new Mascota(2, "Sally", 20100701));
		listaMascotas.Add(new Mascota(3, "Capuchina", 20161210));
		listaMascotas.Add(new Mascota(4, "Grisú", 20161120));
		listaMascotas.Add(new Mascota(5, "Arian", 20200102));
		listaMascotas.Add(new Mascota(6, "Milú", 20100706));

		//Extraiga los registros donde la fecha de nacimiento
		//esté en un rango
		List<Mascota> Resultados = (from animal in listaMascotas
									where animal.FechaNace > 20150101
									&& animal.FechaNace <= 20161231
									select animal).ToList();

		//Ejecuta la consulta y la imprime
		for (int cont = 0; cont < Resultados.Count; cont++) {
			Resultados[cont].Imprime();
		}
	}
}