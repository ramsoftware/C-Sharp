namespace Ejemplo;

class Program {
    static void Main() {
        Random Azar = new();

        //Se define un diccionario: llave, cadena
        //En este caso la llave es un número entero
        Dictionary<int, string> Animales = new() {
            {11, "Ballena"},
            {12, "Tortuga marina"},
            {13, "Tiburón"},
            {14, "Estrella de mar"},
            {15, "Hipocampo"},
            {16, "Serpiente marina"},
            {17, "Delfín"},
            {18, "Pulpo"},
            {19, "Caballito de mar"},
            {20, "Coral"},
            {21, "Pingüinos"},
            {22, "Calamar"},
            {23, "Gaviota"},
            {24, "Foca"},
            {25, "Manaties"},
            {26, "Ballena con barba"},
            {27, "Peces Guppy"},
            {28, "Orca"},
            {29, "Medusas"},
            {30, "Mejillones"},
            {31, "Caracoles"}
        };

        for (int cont = 1; cont <= 10; cont++) {
            int Llave = Azar.Next(11, Animales.Count + 11);
            Console.Write("Llave: " + Llave);
            Console.WriteLine(" cadena: " + Animales[Llave]);
        }
    }
}
