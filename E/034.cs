namespace Ejemplo {
    class Program {
        static void Main() {
            //Se define una lista ordenada: llave, cadena
            //En este caso la llave es una cadena
            SortedList<string, string> Extensiones = new() {
                { "exe", "Ejecutable" },
                { "com", "Ejecutable DOS" },
                { "vb", "Visual Basic .NET" },
                { "cs", "C#" },
                { "js", "JavaScript" },
                { "xlsx", "Excel" },
                { "docx", "Word" },
                { "pptx", "PowerPoint" }
            };

            //Imprime la lista ordenada
            foreach (object elemento in Extensiones)
                Console.WriteLine(elemento);

            //Otra forma de adicionar
            Extensiones.Add("html", "HTML 5");

            //Imprime llave y valor
            var ListaLlaves = Extensiones.Keys;
            Console.WriteLine("\r\nImprime llave y valor en separado");
            foreach (string Llave in ListaLlaves) {
                Console.Write("Llave: " + Llave);
                Console.WriteLine(" Valor: " + Extensiones[Llave]);
            }
        }
    }
}
