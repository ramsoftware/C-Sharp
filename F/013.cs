namespace Ejemplo {
	internal class Mascota {
		public string Especie { get; set; }
		public string Nombre { get; set; }
		public Mascota(string Especie, string Nombre) {
			this.Especie = Especie;
			this.Nombre = Nombre;
		}

		public void Imprime() {
			Console.WriteLine("Especie: " + Especie + " Nombre: " + Nombre);
		}
	}

	internal class Program {
		static void Main() {
			//Fuente de datos, una lista
			List<Mascota> listaMascotas = new List<Mascota>();
			listaMascotas.Add(new Mascota("gato", "Suini"));
			listaMascotas.Add(new Mascota("gato", "Gris"));
			listaMascotas.Add(new Mascota("gato", "Sally"));
			listaMascotas.Add(new Mascota("gato", "Tinita"));
			listaMascotas.Add(new Mascota("conejo", "Krousky"));
			listaMascotas.Add(new Mascota("gato", "Capuchina"));
			listaMascotas.Add(new Mascota("gato", "Tammy"));
			listaMascotas.Add(new Mascota("gato", "Grisú"));
			listaMascotas.Add(new Mascota("ave", "Lua"));
			listaMascotas.Add(new Mascota("conejo", "Copo"));
			listaMascotas.Add(new Mascota("gato", "Vikingo"));
			listaMascotas.Add(new Mascota("gato", "Arian"));
			listaMascotas.Add(new Mascota("gato", "Milú"));
			listaMascotas.Add(new Mascota("ave", "Azulin"));
			listaMascotas.Add(new Mascota("gato", "Frac"));
			listaMascotas.Add(new Mascota("ave", "Negro"));
			listaMascotas.Add(new Mascota("conejo", "Clopa"));

			//Ordene primero por especie y luego por nombre
			List<Mascota> Resultados = (from animal in listaMascotas orderby animal.Especie, animal.Nombre select animal).ToList();

			//Ejecuta la consulta y la imprime
			for (int contador = 0; contador < Resultados.Count; contador++) {
				Resultados[contador].Imprime();
			}
		}
	}
}