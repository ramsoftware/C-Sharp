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

        //Limpia el List
        Console.WriteLine("(Antes) Elementos: " + ListaAnimales.Count);
        ListaAnimales.Clear();
        Console.WriteLine("(Después) Elementos: " + ListaAnimales.Count);

        Console.WriteLine("\r\n");
    }
}