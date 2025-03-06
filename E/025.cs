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
            //Se define un diccionario: llave, objeto
            //En este caso la llave es una cadena
            var Objetos = new Dictionary<string, MiClase> {
                {"uno", new MiClase(1, 0.2, 'r', "Leafar") },
                {"dos", new MiClase(8, -7.1, 'a', "Otrebla")},
                {"tres", new MiClase(23, -13.6, 'm', "Onerom")},
                {"cuatro", new MiClase(49, 16.83, 'p', "Arrap")}
            };

            //Trae los datos del objeto guardado en el diccionario
            string Llave = "tres";
            Console.Write("Llave: " + Llave);
            Console.WriteLine(" atributo es: " + Objetos[Llave].Cad);

            Console.Write("Llave: " + Llave);
            Console.WriteLine(" atributo es: " + Objetos[Llave].Numero);

            Console.Write("Llave: " + Llave);
            Console.WriteLine(" atributo es: " + Objetos[Llave].Valor);

            //Guarda las llaves en una lista
            Console.WriteLine("\r\nLista de Llaves:");
            var ListaLlaves = new List<string>(Objetos.Keys);
            foreach (string Llaves in ListaLlaves) {
                Console.WriteLine("Llave: " + Llaves);
            }

            //Verifica si existe una llave
            Console.WriteLine("\r\nVerifica si existe una llave:");
            if (Objetos.ContainsKey("cuatro")) {
                Console.WriteLine(Objetos["cuatro"].Cad);
            }
            else {
                Console.WriteLine("No existe esa llave");
            }
        }
    }
}
