using System.Text.Json;

namespace Ejemplo; 

class Program {
    static void Main() {
        List<double> datos = [3.14, -2.71, 1.618, -4.31, 7.89];

        // Guardar como JSON
        string json = JsonSerializer.Serialize(datos);
        File.WriteAllText("datos.json", json);

        // Leer desde JSON
        string jsonLeido = File.ReadAllText("datos.json");
        List<double> datosLeidos = JsonSerializer.Deserialize<List<double>>(jsonLeido);

        //Imprime los datos leídos
        for (int Cont = 0; Cont < datosLeidos.Count; Cont++) {
            Console.WriteLine(datosLeidos[Cont]);
        }
    }
}
