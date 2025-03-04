using System.Collections;

namespace Ejemplo {
    class Program {
        static void Main() {
            //Se define una pila: Queue
            Stack Pila = new();

            //Se agregan elementos a la pila
            Pila.Push("aaa");
            Pila.Push("bbb");
            Pila.Push("ccc");
            Pila.Push("ddd");
            Pila.Push("eee");
            Pila.Push("fff");

            //Número de elmentos en la pila
            Console.WriteLine("Número de elementos: " + Pila.Count);

            //Imprimir la pila
            Console.WriteLine("\r\nElementos: ");
            foreach (object elemento in Pila)
                Console.Write(elemento + ", ");

            //Quitar elemento de la pila
            //Último en llegar, primero en salir,
            //luego quitaría a "fff"
            Pila.Pop();
            Console.WriteLine("\r\nAl quitar un elemento de la pila: ");
            foreach (object elemento in Pila)
                Console.Write(elemento + ", ");

            //Verificar si hay un elemento en la pila
            string Buscar = "ddd";
            if (Pila.Contains(Buscar) == true) {
                Console.WriteLine("\r\n\r\nLa pila contiene: " + Buscar);
            }
            else
                Console.WriteLine("\r\n\r\nLa pila NO contiene: " + Buscar);

            //Obtener el primer elemento de la pila sin borrar ese elemento
            string PrimerElemento = Convert.ToString(Pila.Peek());
            Console.WriteLine("\r\nPrimer elemento: " + PrimerElemento);

            //Leer y borrar la pila
            Console.WriteLine("\r\nLee y borra la pila: ");
            while (Pila.Count > 0)
                Console.Write(Pila.Pop() + "; ");
            Console.WriteLine("\r\nElementos: " + Pila.Count);
        }
    }
}
