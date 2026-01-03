namespace Ejemplo; 

class Program {
    public static void Main() {
        //Declara la lista que almacenará cadenas
        List<string> Listado = [];

        //Adiciona elementos a la lista
        Listado.Add("AB");
        Listado.Add("CD");
        Listado.Add("EF");
        Listado.Add("GH");
        Listado.Add("IJ");
        Listado.Add("KL");
        Listado.Add("MN");
        Listado.Add("OP");

        //Imprime el List
        for (int cont = 0; cont < Listado.Count; cont++)
            Console.Write(Listado[cont] + "; ");
        Console.WriteLine("\r\n");

        //Aplica Reverse()
        Listado.Reverse();

        //Imprime de nuevo el List
        for (int cont = 0; cont < Listado.Count; cont++)
            Console.Write(Listado[cont] + "; ");
    }
}