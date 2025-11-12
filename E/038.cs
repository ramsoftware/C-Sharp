using System.Collections;

namespace Ejemplo {
	class Program {
		static void Main() {
			//Declara la lista
			ArrayList Listado = new();

			//Adiciona elementos a la lista
			Listado.Add("Ballena");
			Listado.Add(1234);
			Listado.Add(true);
			Listado.Add(-3.1415);
			Listado.Add('K');
			Listado.Add(false);
			Listado.Add("Caballito de mar");
			Listado.Add(89.12);
			Listado.Add(7890);

			//Imprime la lista
			Console.WriteLine("LISTA ORIGINAL");

			//Muestra el contenido y el tipo de cada elemento
			for (int cont = 0; cont < Listado.Count; cont++) {
				Console.Write(Listado[cont]);
				Console.WriteLine(" tipo: " + Listado[cont].GetType());
			}
			Console.WriteLine("\r\n\r\n");

			//Guarda en medio persistente
			using (StreamWriter Escritor = new("MisDatos.txt")) {
				foreach (object item in Listado) {
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
			//Muestra el contenido y el tipo de cada elemento
			for (int cont = 0; cont < NuevaLista.Count; cont++) {
				Console.Write(NuevaLista[cont]);
				Console.WriteLine(" tipo: " + NuevaLista[cont].GetType());
			}
			Console.WriteLine("\r\n\r\n");
		}
	}
}
