namespace Ejemplo;

internal class Program {
    static void Main() {
        //Inmutabilidad
        string cadenaA = "abcdefghijk";

        //Se copian los datos de cadenaA en cadenaB
        string cadenaB = cadenaA;

        //Se agregan datos a cadenaA
        //¿Qué sucederá con cadenaB? 
        cadenaA += "pqrstuvwxyz";

        //Imprimiendo por consola
        Console.WriteLine(cadenaA);
        Console.WriteLine(cadenaB);
    }
}