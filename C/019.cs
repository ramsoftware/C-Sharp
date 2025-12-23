namespace Ejemplo;

internal class Program {
    static void Main() {
        //Tipo implícito en arreglo de arreglos
        var arregloA = new[] {
                new[] { 16, 83, 29, 29 },
                new[] { 72, 6, 26 }
            };

        var arregloB = new[] {
                new[] { 'a', 'e', 'i', 'o' },
                new[] { 'q', 'w', 'e' },
                new[] { 'r', 't', 'y', 'u', 'o', 'p' }
            };

        //Imprime los tipos
        Console.WriteLine("Tipo ArregloA: " + arregloA.GetType());
        Console.WriteLine("Tipo ArregloB: " + arregloB.GetType());
    }
}