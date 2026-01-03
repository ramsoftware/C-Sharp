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

        //Tamaño la lista
        int tamano = ListaAnimales.Count;
        Console.WriteLine("Tamaño de la lista: " + tamano);

        //Traer un determinado elemento de la lista
        int posicion = 5;
        string texto = ListaAnimales[posicion].ToString();
        Console.WriteLine("\r\nEn posición: " + posicion + " es: " + texto);

        //Nos dice si existe un determinado elemento en la lista
        string buscar = "Pulpo";
        bool Existe = ListaAnimales.Contains(buscar);
        Console.WriteLine("\r\nBusca: " + buscar + " Resultado: " + Existe);

        //Nos dice la posición donde encontró el elemento en la lista
        int posBusca = ListaAnimales.IndexOf(buscar);
        Console.WriteLine("\r\nBusca: " + buscar + " Posición: " + posBusca);

        //Agrega elementos a la lista
        ListaAnimales.Add("León Marino");
        ListaAnimales.Add("Foca");
        ListaAnimales.Add("Langostino");

        //Imprime la lista
        Console.WriteLine("\r\nLista completa es:");
        for (int Cont = 0; Cont < ListaAnimales.Count; Cont++)
            Console.Write(ListaAnimales[Cont] + ";");

        Console.WriteLine("\r\n");
    }
}
