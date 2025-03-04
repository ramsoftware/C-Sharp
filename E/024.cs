namespace Ejemplo {
    class Program {
        static void Main() {
            //Se define un diccionario: llave, cadena
            //En este caso la llave es una cadena
            Dictionary<string, string> Extension = new() {
                {"exe", "Ejecutable"},
                {"com", "Ejecutable DOS"},
                {"vb", "Visual Basic .NET"},
                {"cs", "C#"},
                {"js", "JavaScript"},
                {"xlsx", "Excel"},
                {"docx", "Word"},
                {"html", "HTML 5"}
            };

            //Otra forma de adicionar
            Extension.Add("pptx", "PowerPoint");

            //Trae un elemento dada una llave
            string Llave = "cs";
            Console.Write("Llave: " + Llave);
            Console.WriteLine(" valor es: " + Extension[Llave]);

            //Tamaño del diccionario
            Console.WriteLine("Tamaño: " + Extension.Count);

            //Elimina un elemento
            Extension.Remove("docx");

            //Tamaño del diccionario
            Console.WriteLine("Después de eliminar: " + Extension.Count);
        }
    }
}