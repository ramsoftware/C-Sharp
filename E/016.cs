namespace Ejemplo; 

class Program {
    public static void Main() {
        //Declara la lista que almacenará cadenas
        List<string> Listado = [];

        //Adiciona elementos a la lista
        Listado.Add("GH");
        Listado.Add("MN");
        Listado.Add("AB");
        Listado.Add("KL");
        Listado.Add("OP");
        Listado.Add("IJ");
        Listado.Add("CD");
        Listado.Add("EF");

        //Imprime el List
        Console.WriteLine("List Original");
        for (int cont = 0; cont < Listado.Count; cont++)
            Console.Write(Listado[cont] + "; ");
        Console.WriteLine("\r\n");

        //Ordena el List
        Listado.Sort();

        //Imprime de nuevo el List
        Console.WriteLine("List Ordenado");
        for (int cont = 0; cont < Listado.Count; cont++)
            Console.Write(Listado[cont] + "; ");
        Console.WriteLine("\r\n");

        //Busca en forma binaria en el List
        string Buscar = "KL";
        int pos = Listado.BinarySearch(Buscar);
        Console.WriteLine("Buscando: " + Buscar);
        Console.WriteLine("Encontrado en: " + pos);
    }
}