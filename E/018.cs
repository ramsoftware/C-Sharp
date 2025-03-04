using System.Collections;

namespace Ejemplo {
    class Program {
        public static void Main() {
            //Declara la lista que almacenará cadenas
            ArrayList Listado = new();

            //Agrega diferentes tipos de datos
            Listado.Add("Rafael Alberto Moreno Parra");
            Listado.Add(720626);
            Listado.Add(1.6832929);
            Listado.Add('J');
            Listado.Add(true);

            //Muestra el contenido y el tipo de cada elemento
            for (int cont = 0; cont < Listado.Count; cont++) {
                Console.Write(Listado[cont]);
                Console.WriteLine(" tipo: " + Listado[cont].GetType());
            }
            Console.WriteLine("\r\n");

            //Y compara
            for (int cont = 0; cont < Listado.Count; cont++) {
                Console.Write(Listado[cont]);
                if (Listado[cont].GetType() == typeof(int))
                    Console.WriteLine(" es un entero");

                if (Listado[cont].GetType() == typeof(char))
                    Console.WriteLine(" es un caracter");

                if (Listado[cont].GetType() == typeof(double))
                    Console.WriteLine(" es un real");

                if (Listado[cont].GetType() == typeof(string))
                    Console.WriteLine(" es una cadena");

                if (Listado[cont].GetType() == typeof(bool))
                    Console.WriteLine(" es un booleano");
            }
        }
    }
}
