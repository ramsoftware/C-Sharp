namespace Ejemplo;

//Una clase con varios atributos
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
        //Se define una pila de tipo objeto personalizado
        Stack<MiClase> Pila = new();

        //Se agregan elementos a la pila
        Pila.Push(new MiClase(1, 0.2, 'r', "Leafar"));
        Pila.Push(new MiClase(8, -7.1, 'a', "Otrebla"));
        Pila.Push(new MiClase(23, -13.6, 'm', "Onerom"));
        Pila.Push(new MiClase(49, 16.83, 'p', "Arrap"));

        //Número de elmentos en la pila
        Console.WriteLine("Número de elementos: " + Pila.Count);

        //Imprimir la pila
        Console.WriteLine("\r\nElementos: ");
        foreach (MiClase elemento in Pila)
            Console.Write(elemento.Cad + ", ");

        //Quitar elemento de la pila
        Pila.Pop(); //Último en llegar, primero en salir
        Console.WriteLine("\r\nAl quitar un elemento de la pila: ");
        foreach (MiClase elemento in Pila)
            Console.Write(elemento.Cad + ", ");

        //Obtener el primer elemento de la pila
        //sin borrar ese elemento
        MiClase Primer = Pila.Peek();
        Console.WriteLine("\r\n\r\nElemento más arriba: " + Primer.Cad);

        //Leer y borrar la pila
        Console.WriteLine("\r\nLee y borra la pila: ");
        while (Pila.Count > 0)
            Console.Write(Pila.Pop().Cad + "; ");
        Console.WriteLine("\r\nNúmero de elementos: " + Pila.Count);

        //Agrega elementos a la pila y luego la borra
        Pila.Push(new MiClase(7, 6.5, 'z', "qwerty"));
        Pila.Push(new MiClase(4, -3.2, 'y', "asdfg"));
        Console.WriteLine("\r\nWlementos: " + Pila.Count);
        Pila.Clear();
        Console.WriteLine("Después de borrar: " + Pila.Count);
    }
}
