namespace Ejemplo;

	//Esta clase solo puede heredar, no se puede instanciar
	abstract class Mascota {
		public string SerialChip { get; set; }
		
		public string Nombre { get; set; }
		
		public DateTime FechaNacimiento { get; set; }
		
		//Macho, Hembra
		public char Sexo { get; set; }
		
		//Nombre del propietario
		public string Propietario { get; set; }
		
		//Teléfono del propietario
		public string Telefono { get; set; }
		
		//Correo electrónico del propietario
		public string Correo { get; set; }
		
		public double Peso { get; set; }
		
		//0. Azul, 1. Verde, 2. Dorado, 3. Dispar
		public int ColorOjos { get; set; }
		
		public int EsperanzaVidaMinimo { get; set; }
		
		public int EsperanzaVidaMaximo { get; set; }
		
		//0. Baja, 1. Media, 2. Alta
		public int NecesidadAtencion { get; set; }
		
		public string Raza { get; set; }
	}
	
	class Perro : Mascota {
		//Real Sociedad Canina de España
		public string ReconocimientoRSCE { get; set; }

		//United Kennel Club
		public string ReconocimientoUKC { get; set; }

		//Crianza
		public string CriadoPara { get; set; }

		public double AlturaALaCruz { get; set; }
		
		//0. Ninguna, 1. Baja, 2. Moderada
		public int TendenciaBabear { get; set; }
		
		public int TendenciaRoncar { get; set; }
		public int TendenciaLadrar { get; set; }
		public int TendenciaExcavar { get; set; }
	}
	
	class Gato : Mascota {
		public string PatronPelo { get; set; }
		public int TendenciaPerderPelo { get; set; }

		//Asociación de Criadores de Gatos
		public string ReconocimientoCFA { get; set; }
		
		//Asociación Americana de Criadores de Gatos
		public string ReconocimientoACFA { get; set; }
		
		//Fédération Internationale Féline 
		public string ReconocimientoFIFe { get; set; }
		
		//Asociación Internacional de Gatos
		public string ReconocimientoTICA { get; set; }
	}

	//Inicia la aplicación aquí
	internal class Program {
		static void Main() {
			Mascota objMascota = new();
			Gato objGato = new();
			Perro objPerro = new();

			//Da valores a la instancia de mascota
			objMascota.Correo = "enginelife@hotmail.com";
			objMascota.ColorOjos = 1;

			//Da valores a la instancia de gato
			objGato.Correo = "ramsoftware@gmail.com";
			objGato.Propietario = "Rafael Alberto Moreno Parra";
			objGato.Nombre = "Sally";
			objGato.Sexo = 'H';
			objGato.PatronPelo = "Tricolor";

			//Da valores a la instancia de perro
			objPerro.Raza = "Pastor Alemán";
			objPerro.Sexo = 'M';
			objPerro.Nombre = "Firuláis";
			objPerro.TendenciaLadrar = 1;
		}
	}