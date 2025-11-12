using System.Collections;

namespace Ejemplo {
	class Program {
		static void Main() {
			//Declara la lista
			ArrayList ListaAnimales = new();

			//Adiciona elementos a la lista
			ListaAnimales.Add("Ballena");
			ListaAnimales.Add("Tortuga marina");
			ListaAnimales.Add("Tiburón");
			ListaAnimales.Add("Hipocampo");
			ListaAnimales.Add("Delfín");
			ListaAnimales.Add("Pulpo");
			ListaAnimales.Add("Caballito de mar");
			ListaAnimales.Add("Coral");
			ListaAnimales.Add("Pingüinos");

			//Imprime la lista
			Console.WriteLine("LISTA ORIGINAL");
			for (int Cont = 0; Cont < ListaAnimales.Count; Cont++)
				Console.Write(ListaAnimales[Cont] + ";");
			Console.WriteLine("\r\n\r\n");

			//Guarda en medio persistente
			using (StreamWriter Escritor = new("MisDatos.txt")) {
				foreach (object item in ListaAnimales) {
					Escritor.WriteLine(item.ToString());
				}
			}

			//Lee de ese medio persistente y lo guarda
			//en un nuevo arraylist
			ArrayList NuevaLista = new();
			using (StreamReader Lector = new("MisDatos.txt")) {
				string Linea;
				while ((Linea = Lector.ReadLine()) != null) {
					NuevaLista.Add(Linea);
				}
			}

			//Imprime la lista leída
			Console.WriteLine("LISTA LEIDA");
			for (int Cont = 0; Cont < NuevaLista.Count; Cont++)
				Console.Write(NuevaLista[Cont] + ";");
			Console.WriteLine("\r\n\r\n");
		}
	}
}
