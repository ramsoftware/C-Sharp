using System.Text.Json;

namespace Ejemplo; 

class MiClase {
    public int Entero { get; set; }
    public double Real { get; set; }
    public char Caracter { get; set; }
    public bool Booleano { get; set; }
    public string Cadena { get; set; }
}

class Program {
    static void Main() {
        // Crear lista de objetos
        List<MiClase> lista =
        [
        new MiClase { Entero = -1, Real = 3.1416, Caracter = 'A', Booleano = true, Cadena = "Kakapu" },
        new MiClase { Entero = 38, Real = -2.7164, Caracter = 'K', Booleano = false, Cadena = "Ballena" },
        new MiClase { Entero = -16, Real = 1.67, Caracter = 'M', Booleano = false, Cadena = "Ciervo" },
        new MiClase { Entero = 49, Real = -6.112, Caracter = 'R', Booleano = false, Cadena = "Cóndor" },
        new MiClase { Entero = -83, Real = 9.4676, Caracter = 'T', Booleano = true, Cadena = "Águila" },
        new MiClase { Entero = 6, Real = -2.6774, Caracter = 'D', Booleano = false, Cadena = "Gato" },
        new MiClase { Entero = -29, Real = 7.255, Caracter = 'X', Booleano = true, Cadena = "Perro" },
        new MiClase { Entero = 72, Real = -5.23765, Caracter = 'L', Booleano = false, Cadena = "Leopardo" },
        ];

        // Serializar a JSON
        string json = JsonSerializer.Serialize(lista, new JsonSerializerOptions { WriteIndented = true });

        // Guardar en archivo
        File.WriteAllText("datos.json", json);
        Console.WriteLine("Archivo JSON guardado correctamente.");


        // Leer el archivo JSON
        string jsonLeido = File.ReadAllText("datos.json");

        // Deserializar a lista de objetos
        List<MiClase> listaRecuperada = JsonSerializer.Deserialize<List<MiClase>>(jsonLeido);

        // Mostrar los datos
        foreach (var obj in listaRecuperada) {
            Console.WriteLine($"Entero: {obj.Entero}, Real: {obj.Real}, Caracter: {obj.Caracter}, Booleano: {obj.Booleano}, Cadena: {obj.Cadena}");
        }
    }
}