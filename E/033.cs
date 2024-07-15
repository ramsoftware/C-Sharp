using System.Collections;

namespace Ejemplo {
	class MiClase {
		public int Numero { get; set; }
		public double Valor { get; set; }
		public char Car { get; set; }
		public string Cad { get; set; }

		public MiClase(int Numero, double Valor, char Car, string Cad) {
			this.Numero = Numero;
			this.Valor = Valor;
			this.Car = Car;
			this.Cad = Cad;
		}
	}

	class Program {
		static void Main() {
			//Se define un Hashtable
			Hashtable Obj = new Hashtable();

			Obj.Add("uno", new MiClase(1, 0.2, 'r', "Leafar"));
			Obj.Add("dos", new MiClase(8, -7.1, 'a', "Otrebla"));
			Obj.Add("tres", new MiClase(23, -13.6, 'm', "Onerom"));
			Obj.Add("cuatro", new MiClase(49, 16.83, 'p', "Arrap"));

			//Trae los datos del objeto guardado en el diccionario
			string Llave = "tres";
			Console.Write("Llave: " + Llave);
			Console.WriteLine(" atributo: " + (Obj[Llave] as MiClase).Cad);


			Console.Write("Llave: " + Llave);
			Console.WriteLine(" atributo: " + (Obj[Llave] as MiClase).Numero);


			Console.Write("Llave: " + Llave);
			Console.WriteLine(" atributo: " + (Obj[Llave] as MiClase).Valor);

			//Guarda las llaves en una variable de colección
			Console.WriteLine("\r\nLista de Llaves:");
			var ListaLlaves = Obj.Keys;
			foreach (string Llaves in ListaLlaves) {
				Console.WriteLine("Llave: " + Llaves);
			}

			//Verifica si existe una llave
			Console.WriteLine("\r\nVerifica si existe una llave:");
			if (Obj.ContainsKey("cuatro")) {
				Console.WriteLine((Obj["cuatro"] as MiClase).Cad);
			}
			else {
				Console.WriteLine("No existe esa llave");
			}
		}
	}
}