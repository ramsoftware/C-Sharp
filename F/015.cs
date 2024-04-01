namespace Ejemplo {
	internal class Especie {
		public int Codigo { get; set; }
		public string Nombre { get; set; }

		public Especie(int Codigo,  string Nombre) {
			this.Codigo = Codigo;
			this.Nombre = Nombre;   
		}
	}

	internal class Mascota {
		public int Especie { get; set; }
		public string Nombre { get; set; }
		public Mascota(int Especie, string Nombre) {
			this.Especie = Especie;
			this.Nombre = Nombre;
		}
	}

	internal class Program {
		static void Main() {
			List<Especie> listaEspecies = new List<Especie>();
			listaEspecies.Add(new Especie(1, "Gato"));
			listaEspecies.Add(new Especie(2, "Conejo"));
			listaEspecies.Add(new Especie(3, "Ave"));

			List<Mascota> listaMascotas = new List<Mascota>();
			listaMascotas.Add(new Mascota(1, "Suini"));
			listaMascotas.Add(new Mascota(1, "Gris"));
			listaMascotas.Add(new Mascota(1, "Sally"));
			listaMascotas.Add(new Mascota(1, "Tinita"));
			listaMascotas.Add(new Mascota(2, "Krousky"));
			listaMascotas.Add(new Mascota(1, "Capuchina"));
			listaMascotas.Add(new Mascota(1, "Tammy"));
			listaMascotas.Add(new Mascota(1, "Grisú"));
			listaMascotas.Add(new Mascota(3, "Lua"));
			listaMascotas.Add(new Mascota(2, "Copo"));
			listaMascotas.Add(new Mascota(1, "Vikingo"));
			listaMascotas.Add(new Mascota(1, "Arian"));
			listaMascotas.Add(new Mascota(1, "Milú"));
			listaMascotas.Add(new Mascota(3, "Azulin"));
			listaMascotas.Add(new Mascota(1, "Frac"));
			listaMascotas.Add(new Mascota(3, "Negro"));
			listaMascotas.Add(new Mascota(2, "Clopa"));

			var Consulta = from mascota in listaMascotas
						join especie in listaEspecies
						on mascota.Especie equals especie.Codigo
						select new {
							Especie = especie.Nombre,
							Mascota = mascota.Nombre
						};

			foreach (var item in Consulta) {
				Console.WriteLine($"La mascota {item.Mascota} es de la especie {item.Especie}");
			}
		}
	}
}