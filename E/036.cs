namespace Ejemplo {

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
            //Se define una lista enlazada
            LinkedList<MiClase> Lenguajes = new();

            //Agrega al final
            Console.WriteLine("Agregando con AddLast");
            Lenguajes.AddLast(new MiClase(16, 83.29, 'R', "Lenguaje R"));
            Lenguajes.AddLast(new MiClase(29, 89.7, 'A', "ADA"));
            Lenguajes.AddLast(new MiClase(2, 80.19, 'M', "Máquina"));
            Lenguajes.AddLast(new MiClase(95, 7.21, 'P', "PHP"));

            //Imprime esa lista
            foreach (MiClase elemento in Lenguajes)
                Console.Write(elemento.Cad + "; ");

            //Agrega al inicio
            Lenguajes.AddFirst(new MiClase(78, 12.32, 'S', "C#"));
            Lenguajes.AddFirst(new MiClase(5, -3.1, 'V', "J#"));

            //Imprime esa lista
            Console.WriteLine("\r\n\r\nAgregando con AddFirst");
            foreach (MiClase elemento in Lenguajes)
                Console.Write(elemento.Cad + "; ");

            //Agrega al final
            Lenguajes.AddLast(new MiClase(16, 83.29, 'C', "C++"));
            Console.WriteLine("\r\n\r\nAgregando con AddLast");
            foreach (MiClase elemento in Lenguajes)
                Console.Write(elemento.Cad + "; ");

            //Cantidad
            Console.WriteLine("\r\n\r\nCantidad es: " + Lenguajes.Count);

            //Elimina primer elemento
            Lenguajes.RemoveFirst();
            Console.WriteLine("\r\nEliminado el primer elemento");
            foreach (MiClase elemento in Lenguajes)
                Console.Write(elemento.Cad + "; ");

            //Elimina último elemento
            Lenguajes.RemoveLast();
            Console.WriteLine("\r\n\r\nEliminado el último elemento");
            foreach (MiClase elemento in Lenguajes)
                Console.Write(elemento.Cad + "; ");
        }
    }
}
