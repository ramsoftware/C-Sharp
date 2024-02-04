namespace Ejemplo {
	
	//Clase madre con atributos privados
	class Mascota {
		public string Nombre { get; set; }
		public char Sexo { get; set; } //Macho, Hembra
		public string Propietario { get; set; } //Nombre del propietario
	}
	
	class Gato : Mascota {
		public string PatronPelo { get; set; }
		public int TendenciaPerderPelo { get; set; }
		public void DatosGato(string Nombre, char Sexo, string Propietario) {
			this.Nombre = Nombre;
			this.Sexo = Sexo;
			this.Propietario = Propietario;
		}
	}
	
	class Perro : Mascota {
		//Crianza
		public string CriadoPara { get; set; }
		public double AlturaALaCruz { get; set; }

		public void DatosPerro(string Nombre, char Sexo, string Propietario) {
			this.Nombre = Nombre;
			this.Sexo = Sexo;
			this.Propietario = Propietario;
		}
	}

	//Inicia la aplicación aquí
	internal class Program {
		static void Main() {
			Mascota objMascota = new Mascota();
			Gato objGato = new Gato();
			Perro objPerro = new Perro();

			//Da valores a la instancia de gato
			objGato.DatosGato("Sally", 'H', "Rafael Moreno");

			//Da valores a la instancia de perro
			objPerro.DatosPerro("Kitty", 'H', "Chloe Perry");

			//Intenta acceder a los métodos protegidos de Mascota
			objMascota.Nombre = "Milú";
		}
	}
}
