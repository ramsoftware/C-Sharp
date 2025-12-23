namespace Ejemplo;

internal class Program {
    static void Main() {
        //Comparar cadenas
        string cadenaA = "abcdefghij";
        string cadenaB = "Abcdefghij";
        string cadenaC = "abcdefghij ";
        string cadenaD = "abcdefg hij";

        //Forma 2 de comparar. Recomendada.
        if (cadenaA.Equals(cadenaB))
            Console.WriteLine("1. Iguales");
        else
            Console.WriteLine("1. Diferentes");

        if (cadenaA.Equals(cadenaC))
            Console.WriteLine("2. Iguales");
        else
            Console.WriteLine("2. Diferentes");

        if (cadenaA.Equals(cadenaD))
            Console.WriteLine("3. Iguales");
        else
            Console.WriteLine("3. Diferentes");
    }
}