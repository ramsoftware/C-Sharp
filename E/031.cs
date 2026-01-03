namespace Ejemplo; 

class Program {
    static void Main() {

        //Ordena y elimina duplicados (enteros)
        SortedSet<int> numeros = [1, 6, 8, 3, 2, 9, 2, 9];

        foreach (var n in numeros)
            Console.Write(n + ", ");

        Console.WriteLine(" ");

        //Ordena y elimina duplicados (char)
        SortedSet<char> letras = ['e', 's', 't', 'a', 'e', 's', 'u', 'n', 'a', 'p', 'r', 'u', 'e', 'b', 'a'];

        foreach (var l in letras)
            Console.Write(l + ", ");
    }
}