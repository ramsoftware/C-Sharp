namespace Ejemplo;

internal class Program {
    static void Main() {
        //Arreglo unidimensional. Tamaños.
        string[] cadenas = ["naranja", "manzana", "pera", "coco"];
        int[] numeros = new int[8];

        //Tamaños de los arreglos
        int TCadenas = cadenas.Length;
        int TNumeros = numeros.Length;

        //Imprime
        Console.WriteLine("Tamaño arreglo cadenas: " + TCadenas);
        Console.WriteLine("Tamaño arreglo numeros: " + TNumeros);
    }
}