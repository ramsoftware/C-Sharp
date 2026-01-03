namespace Ejemplo;

internal class Program {
    static void Main(string[] args) {
        //Declara la lista que almacenará cadenas
        List<string> ListaAnimales =
        [
            //Inicia con elementos
            "Ballena",
            "Tortuga marina",
            "Tiburón",
            "Estrella de mar",
            "Hipocampo",
            "Serpiente marina",
            "Delfín",
            "Pulpo",
            "Pingüinos",
            "Calamar",
        ];

        //Recorrido con foreach
        Console.WriteLine("Recorrido con foreach");
        foreach (Object objeto in ListaAnimales)
            Console.Write(objeto + ";");

        //Recorrido con for
        Console.WriteLine("\r\n\r\nRecorrido con for");
        for (int cont = 0; cont < ListaAnimales.Count; cont++)
            Console.Write(ListaAnimales[cont] + ";");

        //Recorrido con un IEnumerator
        Console.WriteLine("\r\n\r\nRecorrido con un IEnumerator");
        List<string>.Enumerator elemento = ListaAnimales.GetEnumerator();
        while (elemento.MoveNext())
            Console.Write(elemento.Current + ";");

        Console.WriteLine("\r\n");
    }
}