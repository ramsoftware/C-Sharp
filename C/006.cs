namespace Ejemplo;

internal class Program {
    static void Main() {
        //Arreglo unidimensional
        string[] cadenas = ["naranja", "manzana", "pera", "coco"];

        //Recorre el arreglo y lo imprime
        foreach (string texto in cadenas) {
            Console.WriteLine(texto);
        }
    }
}