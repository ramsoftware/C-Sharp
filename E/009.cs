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

            //Guarda el ArrayList en un arreglo estático
            //de tipo objeto
            Console.WriteLine("Arreglo estático de tipo objeto");
            object[] arregloEstatico = ListaAnimales.ToArray();
            for (int Cont = 0; Cont < ListaAnimales.Count; Cont++)
                Console.Write(ListaAnimales[Cont] + ";");
            Console.WriteLine(" ");

            //Guarda el ArrayList en un arreglo estático de tipo string
            Console.WriteLine("Arreglo estático de tipo cadena");
            string[] Cadenas = ListaAnimales.ToArray(typeof(string)) as string[];
            for (int cont = 0; cont < Cadenas.Length; cont++)
                Console.Write(Cadenas[cont] + ";");
        }
    }
}