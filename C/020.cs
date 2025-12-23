namespace Ejemplo;

internal class Program {
    static void Main() {
        //Una cadena
        string Cadena = "Esta es una frase";

        //Se divide en un arreglo de palabras
        string[] Palabras = Cadena.Split(' ');

        foreach (string elemento in Palabras) {
            Console.WriteLine("[" + elemento + "]");
        }
    }
}