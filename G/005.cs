namespace Ejemplo;

class Nodo {
	//Atributos propios
	public string Cad { get; set; }
	public char Car { get; set; }
	public int Entero { get; set; }
	public double Num { get; set; }

	//Apuntador para lista simplemente enlazada
	public Nodo Apuntador;

	//Constructor
	public Nodo(string Cad, char Car, int Entero,
				double Num, Nodo Apuntador) {
		this.Cad = Cad;
		this.Car = Car;
		this.Entero = Entero;
		this.Num = Num;
		this.Apuntador = Apuntador;
	}

	//Imprime Contenido
	public void Imprime() {
		Console.Write("Cad: " + Cad + " Car: " + Car);
		Console.WriteLine(" Entero: " + Entero + " Real: " + Num);
	}
}

class Program {
	static void Main() {
		//Crea la lista
		Nodo lista = new("aaaa", 'A', 1, 0.1, null);
		lista = new("bbbb", 'B', 2, 0.2, lista);
		lista = new("cccc", 'C', 3, 0.3, lista);
		lista = new("dddd", 'D', 4, 0.4, lista);
		lista = new("eeee", 'E', 5, 0.5, lista);
		lista = new("ffff", 'F', 6, 0.6, lista);
		lista = new("gggg", 'G', 7, 0.7, lista);
		lista = new("hhhh", 'H', 8, 0.8, lista);
		lista = new("iiii", 'I', 9, 0.9, lista);

		//Imprime el tamaño de la lista
		Console.WriteLine("Tamaño de la lista es: " + TamanoLista(lista));
	}

	//Imprime la lista
	static public void ImprimeLista(Nodo pasear) {
		while (pasear != null) {
			pasear.Imprime();
			pasear = pasear.Apuntador;
		}
	}

	//Retorna el tamaño de la lista
	static public int TamanoLista(Nodo pasear) {
		int tamano = 0;
		while (pasear != null) {
			tamano++;
			pasear = pasear.Apuntador;
		}
		return tamano;
	}
}
