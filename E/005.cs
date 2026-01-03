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

        //Imprime de nuevo la lista original
        Console.WriteLine("\r\n\r\nLista original");
        for (int Cont = 0; Cont < ListaAnimales.Count; Cont++)
            Console.Write(ListaAnimales[Cont] + ";");

        //Genera nueva lista
        int posIni = 5;
        int cantidad = 3;
        List<string> nuevaLista = ListaAnimales.GetRange(posIni, cantidad);

        //Imprime valores de esa nueva lista
        Console.WriteLine("\r\n\r\nNueva lista");
        for (int Cont = 0; Cont < nuevaLista.Count; Cont++)
            Console.Write(nuevaLista[Cont] + ";");

        //Modifica un valor de la nueva lista
        nuevaLista[0] = "CACATÚA";

        //Imprime la lista nueva con el valor alterado
        Console.WriteLine("\r\n\r\nNueva lista, primer valor editado:");
        for (int Cont = 0; Cont < nuevaLista.Count; Cont++)
            Console.Write(nuevaLista[Cont] + ";");

        //Imprime de nuevo la lista original
        Console.WriteLine("\r\n\r\nLista original");
        for (int Cont = 0; Cont < ListaAnimales.Count; Cont++)
            Console.Write(ListaAnimales[Cont] + ";");

        Console.WriteLine("\r\n");
    }
}