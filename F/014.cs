namespace Ejemplo {
	internal class Mascota {
		public string Especie { get; set; }
		public string Nombre { get; set; }
		public Mascota(string Especie, string Nombre) {
			this.Especie = Especie;
			this.Nombre = Nombre;
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

			var ConjuntoGrupos = from animal in listaMascotas group animal by animal.Especie;

			//Itera por grupo		
			foreach (var grupo in ConjuntoGrupos) {
				Console.WriteLine("\r\nGrupo: {0}", grupo.Key); //Cada grupo tiene una llave 

				foreach (Mascota individuo in grupo) // Cada grupo tiene una colección interna
					Console.WriteLine("Nombre: {0}", individuo.Nombre);
			}
		}
	}
}