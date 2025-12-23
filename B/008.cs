namespace Ejemplo;

internal class Program {
    static void Main() {
        //Subcadenas
        string cadena = "abcdefghijklmnñopqrstuvwxyz";

        //Del caracter 3 en adelante
        string subCadA = cadena.Substring(3);
        Console.WriteLine(subCadA);

        //Del caracter 7 traiga 4 caracteres
        string subCadB = cadena.Substring(7, 4);
        Console.WriteLine(subCadB);
    }
}