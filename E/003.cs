using System.Collections;

namespace Ejemplo {
    class Program {
        public static void Main() {
            //Declara la lista que almacenará cadenas
            ArrayList ListaAnimales = new();

            //Adiciona elementos a la lista
            ListaAnimales.Add("Ballena");
            ListaAnimales.Add("Tortuga marina");
            ListaAnimales.Add("Tiburón");
            ListaAnimales.Add("Estrella de mar");
            ListaAnimales.Add("Hipocampo");
            ListaAnimales.Add("Serpiente marina");
            ListaAnimales.Add("Delfín");
            ListaAnimales.Add("Pulpo");
            ListaAnimales.Add("Pingüinos");
            ListaAnimales.Add("Foca");
            ListaAnimales.Add("Manaties");

            //Imprime valores
            for (int Cont = 0; Cont < ListaAnimales.Count; Cont++)
                Console.Write(ListaAnimales[Cont] + ";");
            Console.WriteLine(" ");

            //Cambia una cadena en la lista
            ListaAnimales[3] = "CACATÚA";

            //Imprime valores
            for (int Cont = 0; Cont < ListaAnimales.Count; Cont++)
                Console.Write(ListaAnimales[Cont] + ";");
            Console.WriteLine(" ");
        }
    }
}