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

            //Recorrido con foreach
            Console.WriteLine("Recorrido con foreach");
            foreach (Object objeto in ListaAnimales)
                Console.Write(objeto + ";");
            Console.WriteLine("\r\n");

            //Recorrido con for
            Console.WriteLine("Recorrido con for");
            for (int cont = 0; cont < ListaAnimales.Count; cont++)
                Console.Write(ListaAnimales[cont] + ";");
            Console.WriteLine("\r\n");

            //Recorrido con un IEnumerator
            Console.WriteLine("Recorrido con un IEnumerator");
            IEnumerator elemento = ListaAnimales.GetEnumerator();
            while (elemento.MoveNext())
                Console.Write(elemento.Current + ";");
        }
    }
}