namespace Ejemplo;

internal class Program {
    static void Main() {
        //Mayúsculas y minúsculas
        string cadena = "abcde ABCDE áéíóúñ ÁÉÍÓÚÑ äëïöü ÄËÏÖÜ";
        Console.WriteLine(cadena);

        //Convierte a mayúscula
        string mayuscula = cadena.ToUpper();
        Console.WriteLine(mayuscula);

        //Convierte a minúscula
        string minuscula = cadena.ToLower();
        Console.WriteLine(minuscula);
    }
}