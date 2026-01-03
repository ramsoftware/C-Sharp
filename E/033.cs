namespace Ejemplo; 

class Program {
    static void Main() {

        SortedDictionary<int, string> DiccionarioOrdenado = [];

        //Agrega elementos al SortedDictionary
        DiccionarioOrdenado.Add(3, "Koala");
        DiccionarioOrdenado.Add(1, "Tiburón");
        DiccionarioOrdenado.Add(7, "Calamar");
        DiccionarioOrdenado.Add(2, "Arenque");
        DiccionarioOrdenado.Add(5, "Cangrejo");
        DiccionarioOrdenado.Add(4, "Estrella de mar");

        foreach (var Dato in DiccionarioOrdenado) {
            Console.WriteLine($"Key: {Dato.Key}, Value: {Dato.Value}");
        }
    }
}