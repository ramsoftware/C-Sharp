namespace Ejemplo; 

class Program {
    static void Main() {
        List<double> datos = [3.14, -2.71, 1.618, -4.31, 7.89];

        // Guardar como archivo texto plano
        File.WriteAllText("datos.txt", string.Join(";", datos));

        // Leer desde archivo texto plano
        string contenido = File.ReadAllText("datos.txt");
        List<double> datosLeidos = [];
        foreach (var s in contenido.Split(';')) {
            datosLeidos.Add(double.Parse(s));
        }

        //Imprime los datos leídos
        for (int Cont = 0; Cont < datosLeidos.Count; Cont++) {
            Console.WriteLine(datosLeidos[Cont]);
        }
    }
}