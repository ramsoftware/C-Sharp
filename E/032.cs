using System.Collections;

namespace Ejemplo {
    class Program {
        static void Main() {
            Random Azar = new();

            //Se define un Hashtable
            //En este caso la llave es un número entero
            Hashtable Animales = new();
            Animales.Add(11, "Ballena");
            Animales.Add(12, "Tortuga marina");
            Animales.Add(13, "Tiburón");
            Animales.Add(14, "Estrella de mar");
            Animales.Add(15, "Hipocampo");
            Animales.Add(16, "Serpiente marina");
            Animales.Add(17, "Delfín");
            Animales.Add(18, "Pulpo");
            Animales.Add(19, "Caballito de mar");
            Animales.Add(20, "Coral");
            Animales.Add(21, "Pingüinos");
            Animales.Add(22, "Calamar");
            Animales.Add(23, "Gaviota");
            Animales.Add(24, "Foca");
            Animales.Add(25, "Manaties");
            Animales.Add(26, "Ballena con barba");
            Animales.Add(27, "Peces Guppy");
            Animales.Add(28, "Orca");
            Animales.Add(29, "Medusas");
            Animales.Add(30, "Mejillones");
            Animales.Add(31, "Caracoles");

            for (int cont = 1; cont <= 10; cont++) {
                //Busque al azar un número entre mínimo y máximo
                //valor de llave.
                //Hay que sumarle +1 al máximo valor de llave para
                //que quede dentro del rango de los números aleatorios
                int Llave = Azar.Next(11, 31 + 1);

                //Muestre el registro según la llave
                Console.Write("Llave: " + Llave);
                Console.WriteLine(" cadena: " + Animales[Llave]);
            }
        }
    }
}
