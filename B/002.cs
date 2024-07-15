namespace Ejemplo {
    internal class Program {
        static void Main() {
            //Rutas. Forma antigua
            string RutaA = "C:\\Users\\engin\\OneDrive\\";

            //Ruta. Forma moderna
            string RutaB = @"C:\Users\engin\OneDrive\";

            //Imprimiendo por consola
            Console.WriteLine(RutaA);
            Console.WriteLine(RutaB);
        }
    }
}