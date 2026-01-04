namespace Ejemplo;

internal class Mascota {
	public int Codigo;
	public string Nombre;
	public int FechaNace; //Formato: aaaammdd

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
		listaMascotas.Add(new Mascota(6, "Milú", 20160706));

		//Extraiga los registros donde el nombre tenga la letra 'a'
		List<Mascota> Resultados = (from animal in listaMascotas
									where animal.Nombre.Contains("a")
									select animal).ToList();

		//Ejecuta la consulta y la imprime
		for (int cont = 0; cont < Resultados.Count; cont++) {
			Resultados[cont].Imprime();
		}
	}
}