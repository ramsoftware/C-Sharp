﻿using System.Collections;

namespace Ejemplo {
    class Program {
        public static void Main() {
            //Declara la lista que almacenará cadenas
            ArrayList Listado = new();

            //Adiciona elementos a la lista
            Listado.Add("GH");
            Listado.Add("MN");
            Listado.Add("AB");
            Listado.Add("OP");
            Listado.Add("IJ");
            Listado.Add("KL");
            Listado.Add("CD");
            Listado.Add("EF");

            //Imprime el ArrayList
            for (int cont = 0; cont < Listado.Count; cont++)
                Console.Write(Listado[cont] + "; ");
            Console.WriteLine("\r\n");

            //Ordena el ArrayList
            Listado.Sort();

            //Imprime de nuevo el ArrayList
            for (int cont = 0; cont < Listado.Count; cont++)
                Console.Write(Listado[cont] + "; ");
        }
    }
}