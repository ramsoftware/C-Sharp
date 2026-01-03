namespace Ejemplo;

class Program {
    public static void Main() {
        //Declara la lista que almacenará cadenas
        List<string> ListaAnimales = new();

        //Adiciona elementos a la lista
        ListaAnimales.Add("Ballena");
        ListaAnimales.Add("Tortuga marina");
        ListaAnimales.Add("Tiburón");
        ListaAnimales.Add("Estrella de mar");
        ListaAnimales.Add("Hipocampo");
        ListaAnimales.Add("Serpiente marina");
        ListaAnimales.Add("Delfín");
        ListaAnimales.Add("Pulpo");
        ListaAnimales.Add("Caballito de mar");
        ListaAnimales.Add("Coral");
        ListaAnimales.Add("Pingüinos");

        //Un arreglo estático
        string[] Cadenas = { "Gato", "Conejo", "Liebre" };

        //Inserta el arreglo estático en una determinada
        //posición del ArrayList
        int posicionInserta = 4;
        ListaAnimales.InsertRange(posicionInserta, Cadenas);

        //Imprime el ArrayList
        for (int cont = 0; cont < ListaAnimales.Count; cont++)
            Console.Write(ListaAnimales[cont] + "; ");
    }
}