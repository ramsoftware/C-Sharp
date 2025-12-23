namespace Ejemplo;

internal class Program {
    static void Main() {
        //Arreglo unidimensional
        string[] cadenas = ["mil", "ufr", "ac", "ari", "an"];

        //Ordena el arreglo
        Array.Sort(cadenas);

        //Recorre el arreglo y lo imprime
        foreach (string texto in cadenas) {
            Console.WriteLine(texto);
        }
    }
}