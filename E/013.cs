using System.Collections;

namespace Ejemplo {
    class Program {
        public static void Main() {
            //Declara la lista que almacenará cadenas
            ArrayList Listado = new();

            //Adiciona elementos a la lista
            Listado.Add("AB");
            Listado.Add("CD");
            Listado.Add("EF");
            Listado.Add("GH");
            Listado.Add("IJ");
            Listado.Add("KL");
            Listado.Add("MN");
            Listado.Add("OP");

            //Imprime el ArrayList
            for (int cont = 0; cont < Listado.Count; cont++)
                Console.Write(Listado[cont] + "; ");
            Console.WriteLine("\r\n");

            //Aplica Reverse()
            Listado.Reverse();

            //Imprime de nuevo el ArrayList
            for (int cont = 0; cont < Listado.Count; cont++)
                Console.Write(Listado[cont] + "; ");
        }
    }
}