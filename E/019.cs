namespace Ejemplo;

class MiClase {
    //Atributos variados
    public int Entero { get; set; }
    public double Num { get; set; }
    public char Car { get; set; }
    public string Cad { get; set; }

    //Constructor
    public MiClase(int Entero, double Num, char Car, string Cad) {
        this.Entero = Entero;
        this.Num = Num;
        this.Car = Car;
        this.Cad = Cad;
    }

    //Imprime los valores
    public void Imprime() {
        Console.WriteLine("\r\nEntero: " + Entero);
        Console.WriteLine("Real: " + Num);
        Console.WriteLine("Caracter: " + Car);
        Console.WriteLine("Cadena: [" + Cad + "]");
    }
}

class Program {
    static void Main() {
        List<MiClase> Listado = [];

        //Adiciona objetos a la lista
        Listado.Add(new MiClase(16, 83.29, 'R', "Ruiseñor"));
        Listado.Add(new MiClase(29, 89.7, 'A', "Águila"));
        Listado.Add(new MiClase(2, 80.19, 'M', "Manatí"));
        Listado.Add(new MiClase(95, 7.21, 'P', "Puma"));

        //Llama al método de imprimir del objeto
        for (int cont = 0; cont < Listado.Count; cont++)
            Listado[cont].Imprime();

        //Inserta un objeto
        Listado.Insert(1, new MiClase(88, 3.33, 'Z', "QQQQQ"));

        //Elimina un objeto
        Listado.RemoveAt(3);

        //Llama al método de imprimir del objeto
        Console.WriteLine("\r\nDespués de modificar");
        for (int cont = 0; cont < Listado.Count; cont++)
            Listado[cont].Imprime();

        Console.WriteLine("\r\nFinal");
    }
}
