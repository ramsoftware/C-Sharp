﻿namespace Ejemplo {
    //Una clase con varios atributos
    class MiClase {
        public int Numero { get; set; }
        public double Valor { get; set; }
        public char Car { get; set; }
        public string Cad { get; set; }

        public MiClase(int Numero, double Valor, char Car, string Cad) {
            this.Numero = Numero;
            this.Valor = Valor;
            this.Car = Car;
            this.Cad = Cad;
        }
    }

    class Program {
        static void Main() {
            //Se define una cola de tipo objeto personalizado
            Queue<MiClase> Cola = new();

            //Se agregan elementos a la cola
            Cola.Enqueue(new MiClase(1, 0.2, 'r', "Leafar"));
            Cola.Enqueue(new MiClase(8, -7.1, 'a', "Otrebla"));
            Cola.Enqueue(new MiClase(23, -13.6, 'm', "Onerom"));
            Cola.Enqueue(new MiClase(49, 16.83, 'p', "Arrap"));

            //Número de elmentos en la cola
            Console.WriteLine("Número de elementos: " + Cola.Count);

            //Imprimir la cola
            Console.WriteLine("\r\nElementos: ");
            foreach (MiClase elemento in Cola)
                Console.Write(elemento.Cad + ", ");

            //Quitar elemento de la cola
            //Primero en llegar, primero en salir,
            //luego quitaría a "aaa"
            Cola.Dequeue();
            Console.WriteLine("\r\nAl quitar un elemento de la cola: ");
            foreach (MiClase elemento in Cola)
                Console.Write(elemento.Cad + ", ");

            //Obtener el primer elemento de la cola
            //sin borrar ese elemento
            MiClase PrimerElemento = Cola.Peek();
            Console.WriteLine("\r\n\r\nPrimer: " + PrimerElemento.Cad);

            //Leer y borrar la cola
            Console.WriteLine("\r\nLee y borra la cola: ");
            while (Cola.Count > 0)
                Console.Write(Cola.Dequeue().Cad + "; ");
            Console.WriteLine("\r\nNúmero de elementos: " + Cola.Count);

            //Agrega elementos a la cola y luego la borra
            Cola.Enqueue(new MiClase(7, 6.5, 'z', "qwerty"));
            Cola.Enqueue(new MiClase(4, -3.2, 'y', "asdfg"));
            Console.WriteLine("\r\nElementos: " + Cola.Count);
            Cola.Clear();
            Console.WriteLine("Después de borrar: " + Cola.Count);
        }
    }
}
