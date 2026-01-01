namespace Ejemplo;

//Clase madre con atributos privados
class Mascota {
	public string Nombre { get; set; }

	//Macho, Hembra
	public char Sexo { get; set; }

	//Nombre del propietario
	public string Dueno { get; set; }
}

class Gato : Mascota {
	public string PatronPelo { get; set; }
	public int TendenciaPerderPelo { get; set; }
	public void DatosGato(string Nombre, char Sexo, string Dueno) {
		this.Nombre = Nombre;
		this.Sexo = Sexo;
		this.Dueno = Dueno;
	}
}

class Perro : Mascota {
	//Crianza
	public string CriadoPara { get; set; }
	public double AlturaALaCruz { get; set; }

	public void DatosPerro(string Nombre, char Sexo, string Dueno) {
		this.Nombre = Nombre;
		this.Sexo = Sexo;
		this.Dueno = Dueno;
	}
}

//Inicia la aplicación aquí
internal class Program {
	static void Main() {
		Mascota objMascota = new();
		Gato objGato = new();
		Perro objPerro = new();

		//Da valores a la instancia de gato
		objGato.DatosGato("Sally", 'H', "Rafael Moreno");

		//Da valores a la instancia de perro
		objPerro.DatosPerro("Kitty", 'H', "Chloe Perry");

		//Intenta acceder a los métodos protegidos de Mascota
		objMascota.Nombre = "Milú";
	}
}