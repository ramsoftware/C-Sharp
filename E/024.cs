namespace Ejemplo;

class Program {
    static void Main() {
        //Se define una cola de tipo string: Queue
        Queue<string> Cola = new();

        //Se agregan elementos a la cola
        Cola.Enqueue("aaa");
        Cola.Enqueue("bbb");
        Cola.Enqueue("ccc");
        Cola.Enqueue("ddd");
        Cola.Enqueue("eee");
        Cola.Enqueue("fff");

        //Número de elmentos en la cola
        Console.WriteLine("Número de elementos: " + Cola.Count);

        //Imprimir la cola
        Console.WriteLine("\r\nElementos: ");
        foreach (object elemento in Cola)
            Console.Write(elemento + ", ");

        //Quitar elemento de la cola.
        //Primero en llegar, primero en salir, luego quitaría a "aaa"
        Cola.Dequeue();
        Console.WriteLine("\r\nQuitar un elemento de la cola: ");
        foreach (object elemento in Cola)
            Console.Write(elemento + ", ");

        //Verificar si hay un elemento en la cola
        string Buscar = "ddd";
        if (Cola.Contains(Buscar) == true) {
            Console.WriteLine("\r\n\r\nLa cola contiene: " + Buscar);
        }
        else
            Console.WriteLine("\r\n\r\nLa cola NO contiene: " + Buscar);

        //Obtener el primer elemento de la cola
        //sin borrar ese elemento
        string PrimerElemento = Convert.ToString(Cola.Peek());
        Console.WriteLine("\r\nPrimer elemento: " + PrimerElemento);

        //Leer y borrar la cola
        Console.WriteLine("\r\nLee y borra la cola: ");
        while (Cola.Count > 0)
            Console.Write(Cola.Dequeue() + "; ");
        Console.WriteLine("\r\nNúmero de elementos: " + Cola.Count);
    }
}
