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
            ListaAnimales.Add("Caballito de mar");
            ListaAnimales.Add("Coral");
            ListaAnimales.Add("Pingüinos");

            //Elimina un rango de elementos del ArrayList
            Console.WriteLine("Antes");
            for (int Cont = 0; Cont < ListaAnimales.Count; Cont++)
                Console.Write(ListaAnimales[Cont] + ";");
            Console.WriteLine(" ");

            int posicion = 1;
            int cantidad = 4;
            ListaAnimales.RemoveRange(posicion, cantidad);

            Console.WriteLine("Después");
            //Imprime valores
            for (int Cont = 0; Cont < ListaAnimales.Count; Cont++)
                Console.Write(ListaAnimales[Cont] + ";");
            Console.WriteLine(" ");
        }
    }
}