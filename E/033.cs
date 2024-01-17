using System.Collections;

namespace Ejemplo {
	class MiClase {
		public int Numero { get; set; }
		public double Valor { get; set; }
		public char Caracter { get; set; }
		public string Cadena { get; set; }

		public MiClase(int Numero, double Valor, char Caracter, string Cadena) {
			this.Numero = Numero;
			this.Valor = Valor;
			this.Caracter = Caracter;
			this.Cadena = Cadena;
		}
	}

	class Program {
		static void Main() {
			//Se define un Hashtable
			Hashtable Objetos = new Hashtable();

			Objetos.Add("uno", new MiClase(1, 0.2, 'r', "Leafar"));
			Objetos.Add("dos", new MiClase(8, -7.1, 'a', "Otrebla"));
			Objetos.Add("tres", new MiClase(23, -13.6, 'm', "Onerom"));
			Objetos.Add("cuatro", new MiClase(49, 16.83, 'p', "Arrap"));

			//Trae los datos del objeto guardado en el diccionario
			string Llave = "tres";
			Console.WriteLine("Llave: " + Llave + " atributo es: " + (Objetos[Llave] as MiClase).Cadena);
			Console.WriteLine("Llave: " + Llave + " atributo es: " + (Objetos[Llave] as MiClase).Numero);
			Console.WriteLine("Llave: " + Llave + " atributo es: " + (Objetos[Llave] as MiClase).Valor);

			//Guarda las llaves en una variable de colección
			Console.WriteLine("\r\nLista de Llaves:");
			var ListaLlaves = Objetos.Keys;
			foreach (string Llaves in ListaLlaves) {
				Console.WriteLine("Llave: " + Llaves);
			}

			//Verifica si existe una llave
			Console.WriteLine("\r\nVerifica si existe una llave:");
			if (Objetos.ContainsKey("cuatro")) {
				Console.WriteLine((Objetos["cuatro"] as MiClase).Cadena);
			}
			else {
				Console.WriteLine("No existe esa llave");
			}
		}
	}
}