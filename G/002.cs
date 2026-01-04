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

		//Imprime la lista
		lista.Imprime(); //Primer nodo
		lista.Apuntador.Imprime(); //Segundo nodo
		lista.Apuntador.Apuntador.Imprime(); //Tercer nodo
	}
}