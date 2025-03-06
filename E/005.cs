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

            //Imprime valores
            Console.WriteLine("Lista original");
            for (int Cont = 0; Cont < ListaAnimales.Count; Cont++)
                Console.Write(ListaAnimales[Cont] + ";");
            Console.WriteLine(" ");

            //Genera nueva lista
            int posIni = 5;
            int cantidad = 3;
            ArrayList nuevaL = ListaAnimales.GetRange(posIni, cantidad);

            //Imprime valores de esa nueva lista
            Console.WriteLine("\r\nNueva lista");
            for (int Cont = 0; Cont < nuevaL.Count; Cont++)
                Console.Write(nuevaL[Cont] + ";");
            Console.WriteLine(" ");

            //Modifica un valor de la nueva lista
            nuevaL[0] = "CACATÚA";

            //Imprime la lista nueva con el valor alterado
            Console.WriteLine("\r\nNueva lista, primer valor:");
            for (int Cont = 0; Cont < nuevaL.Count; Cont++)
                Console.Write(nuevaL[Cont] + ";");
            Console.WriteLine(" ");

            //Imprime de nuevo la lista original
            Console.WriteLine("\r\nLista original");
            for (int Cont = 0; Cont < ListaAnimales.Count; Cont++)
                Console.Write(ListaAnimales[Cont] + ";");
            Console.WriteLine(" ");
        }
    }
}
