using System.Text.Json;

namespace Ejemplo;

class Nodo {
	//Atributos propios
	public string Cad { get; set; }
	public char Car { get; set; }
	public int Entero { get; set; }
	public double Num { get; set; }

	//Uso de una Lista para sostener los hijos del nodo
	public List<Nodo> Hijos { get; set; } = new List<Nodo>();

	public Nodo(string Cad, char Car, int Entero, double Num) {
		this.Cad = Cad;
		this.Car = Car;
		this.Entero = Entero;
		this.Num = Num;
		Hijos = []; //Crea la lista vacía
	}

	public void AgregaHijo(Nodo hijo) {
		Hijos.Add(hijo); //Agrega hijo a la lista
	}

	//Imprime Contenido
	public void Imprime() {
		Console.Write("Cad: " + Cad + " Car: " + Car);
		Console.Write(" Entero: " + Entero + " Real: " + Num);
		Console.WriteLine(" Número de hijos: " + Hijos.Count + "\r\n");
	}
}


class Program {
	static void Main() {
		//Crea la raíz del árbol N-ario
		Nodo arbolN = new("AAAA", 'a', 1, 0.1);

		//Agrega varios hijos a esa raíz
		arbolN.AgregaHijo(new("BBBB", 'b', 2, 0.2));
		arbolN.AgregaHijo(new("CCCC", 'c', 3, 0.3));
		arbolN.AgregaHijo(new("DDDD", 'd', 4, 0.4));
		arbolN.AgregaHijo(new("EEEE", 'e', 5, 0.5));
		arbolN.AgregaHijo(new("FFFF", 'f', 6, 0.6));

		//Agrega varios hijos al nodo "BBBB"
		arbolN.Hijos[0].AgregaHijo(new("Bhhh", 'h', 7, 0.7));
		arbolN.Hijos[0].AgregaHijo(new("Biii", 'i', 8, 0.8));
		arbolN.Hijos[0].AgregaHijo(new("Bjjj", 'j', 9, 0.9));

		//Agrega varios hijos al nodo "EEEE"
		arbolN.Hijos[3].AgregaHijo(new("Ekkk", 'k', 10, 1.1));
		arbolN.Hijos[3].AgregaHijo(new("Elll", 'l', 11, 1.2));

		//Imprime el árbol
		RecorrerPreorden(arbolN);

		//Guarda el árbol N-ario
		Console.WriteLine("Guarda árbol N-ario");
		GuardarArbolNarioComoJSON(arbolN, "arbol.json");

		//Restaura el árbol N-ario
		Console.WriteLine("Restaura árbol N-ario");
		Nodo Restaura = CargarArbolNarioDesdeJSON("arbol.json");

		//Imprime el árbol N-ario restaurado
		RecorrerPreorden(Restaura);
	}

	static void RecorrerPreorden(Nodo nodo) {
		if (nodo == null) return;
		nodo.Imprime();
		foreach (var hijo in nodo.Hijos) {
			RecorrerPreorden(hijo);
		}
	}

	static void GuardarArbolNarioComoJSON(Nodo raiz, string rutaArchivo) {
		var opciones = new JsonSerializerOptions { WriteIndented = true };
		string json = JsonSerializer.Serialize(raiz, opciones);
		File.WriteAllText(rutaArchivo, json);
	}

	static Nodo CargarArbolNarioDesdeJSON(string rutaArchivo) {
		string json = File.ReadAllText(rutaArchivo);
		return JsonSerializer.Deserialize<Nodo>(json);
	}
}
