using System.Text;

namespace Ejemplo {

    // El individuo es una posible solución al problema
    internal class Individuo {
        public int Puntos;
        public StringBuilder Cadena;
        public static StringBuilder Letras = new("abcdefghijklmnopqrstuvwxyz ");

        public Individuo(Random Azar, int Tamano) {
            Puntos = -1;
            Cadena = new();
            for (int Cont = 0; Cont < Tamano; Cont++) {
                int Pos = Azar.Next(Letras.Length);
                Cadena.Append(Letras[Pos]);
            }
        }

        //Operador mutación: Cambia una letra al azar de la Cadena
        public void Muta(Random Azar) {
            int PosA = Azar.Next(Cadena.Length);
            int PosB = Azar.Next(Letras.Length);
            Cadena[PosA] = Letras[PosB];
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

        // Operador mutación
        static void OperadorMutacion(Random Azar, StringBuilder CadenaBusca) {
            int TamanoPoblacion = 350;
            int TotalCiclos = 70000;

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

                // El individuo ganador reemplaza al perdedor, muta esa copia
                if (Poblacion[IndivA].Puntos > Poblacion[IndivB].Puntos) {
                    Poblacion[IndivB].Cadena = new(Poblacion[IndivA].Cadena.ToString());
                    Poblacion[IndivB].Muta(Azar);
                }
                else if (Poblacion[IndivB].Puntos > Poblacion[IndivA].Puntos) {
                    Poblacion[IndivA].Cadena = new(Poblacion[IndivB].Cadena.ToString());
                    Poblacion[IndivA].Muta(Azar);
                }

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