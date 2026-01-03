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

        //Imprime la lista
        Console.WriteLine("\r\nLista completa es:");
        for (int Cont = 0; Cont < ListaAnimales.Count; Cont++)
            Console.Write(ListaAnimales[Cont] + ";");

        //Retira elemento de la lista
        ListaAnimales.Remove("Hipocampo");

        //Imprime la lista
        Console.WriteLine("\r\n\r\nLista con uno menos:");
        for (int Cont = 0; Cont < ListaAnimales.Count; Cont++)
            Console.Write(ListaAnimales[Cont] + ";");

        //Elimina el objeto de determinada posición.
        ListaAnimales.RemoveAt(5);

        //Imprime la lista
        Console.WriteLine("\r\n\r\nLista con otro menos:");
        for (int Cont = 0; Cont < ListaAnimales.Count; Cont++)
            Console.Write(ListaAnimales[Cont] + ";");

        Console.WriteLine("\r\n");
    }
}
