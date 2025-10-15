using System.Text;

namespace Ejemplo {

    // El individuo es una posible solución al problema
    internal class Individuo {
        public int Puntos;
        public StringBuilder Cadena;
        public static StringBuilder Letras = new("abcdefghijklmnopqrstuvwxyz ");

        public Individuo() {
            Puntos = -1;
            Cadena = new();
        }

        public Individuo(Random Azar, int Tamano) {
            Puntos = -1;
            Cadena = new();
            for (int Cont = 0; Cont < Tamano; Cont++) {
                int Pos = Azar.Next(Letras.Length);
                Cadena.Append(Letras[Pos]);
            }
        }

        //Puntaje del individuo
        public void Evalua(StringBuilder CadenaBusca) {
            Puntos = 0;
            for (int Cont = 0; Cont < CadenaBusca.Length; Cont++)
                if (CadenaBusca[Cont] == Cadena[Cont])
                    Puntos++;
        }
    }

    internal class Program {
        //Población: conjunto de individuos
        static List<Individuo> Poblacion = [];

        static void Main() {
            Random Azar = new();
            StringBuilder CadenaBusca = new("esta es una prueba de algoritmos evolutivos");
            OperadorMutacion(Azar, CadenaBusca);
        }

        // Operador cruce
        static void OperadorMutacion(Random Azar, StringBuilder CadenaBusca) {
            int TamanoPoblacion = 900;
            int TotalCiclos = 90000;

            //Crea la población de individuos
            Poblacion.Clear();
            for (int Cont = 0; Cont < TamanoPoblacion; Cont++) {
                Poblacion.Add(new Individuo(Azar, CadenaBusca.Length));
            }

            //Proceso evolutivo
            for (int Cont = 1; Cont <= TotalCiclos; Cont++) {

                //Selecciona dos individuos distintos al azar
                int IndivA = Azar.Next(Poblacion.Count);
                int IndivB;
                do {
                    IndivB = Azar.Next(Poblacion.Count);
                } while (IndivA == IndivB);

                //Evalúa cada individuo seleccionado
                Poblacion[IndivA].Evalua(CadenaBusca);
                Poblacion[IndivB].Evalua(CadenaBusca);

                //Genera el hijo
                Individuo Hijo = new();
                int Pos = Azar.Next(CadenaBusca.Length);
                Hijo.Cadena.Append(Poblacion[IndivA].Cadena.ToString(0, Pos));
                Hijo.Cadena.Append(Poblacion[IndivB].Cadena.ToString(Pos, CadenaBusca.Length - Pos));

                //Si el hijo es mejor que los progenitores, los reemplaza
                Hijo.Evalua(CadenaBusca);
                if (Hijo.Puntos > Poblacion[IndivA].Puntos) Poblacion[IndivA].Cadena = new(Hijo.Cadena.ToString());
                if (Hijo.Puntos > Poblacion[IndivB].Puntos) Poblacion[IndivB].Cadena = new(Hijo.Cadena.ToString());

                // Muestra resultados parciales
                if (Cont % 2000 == 0) {
                    List<Individuo> Temp;
                    Temp = Poblacion.OrderByDescending(obj => obj.Puntos).ToList();
                    Console.Write("Individuo: " + Temp[0].Cadena);
                    Console.WriteLine(" Puntos: " + Temp[0].Puntos);
                }
            }

            //Muestra el mejor individuo con el mejor puntaje
            Console.WriteLine("\r\n\r\nFinaliza");
            Poblacion = Poblacion.OrderByDescending(obj => obj.Puntos).ToList();
            Console.Write("Individuo: " + Poblacion[0].Cadena);
            Console.WriteLine(" Puntos: " + Poblacion[0].Puntos);
        }
    }
}