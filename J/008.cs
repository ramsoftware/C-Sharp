namespace Ejemplo {
    internal class Program {
        static void Main() {
            //Buscar el mayor valor de una ecuación.
            //Operador cruce y mutación
            Evolutivo objEvl = new();

            int TamanoPoblacion = 1000;
            int Ciclos = 90000;
            int Bits = 20;
            double Xmin = -4;
            double Xmax = 1;
            objEvl.Proceso(TamanoPoblacion, Bits, Ciclos, Xmin, Xmax);
        }
    }

    //Cómo es el individuo
    internal class Individuo {
        public int Genotipo;

        //Al nacer, tendrá un valor dependiendo del número de bits
        public Individuo(Random Azar, int NumeroBits) {
            Genotipo = Azar.Next((int)Math.Pow(2, NumeroBits));
        }

        //Operador cruce.
        public Individuo(Random Azar, int GeneticoA, int GeneticoB) {
            //En que posicion corta el genotipo de cada padre
            int Posicion = Azar.Next(sizeof(int) * 8);

            //Extrae las partes de cada progenitor
            int Mascara = (1 << Posicion) - 1;
            int ParteA = GeneticoA >> Posicion;
            int ParteB = GeneticoB & Mascara;

            //Une las partes las inicial de A y la final de B
            Genotipo = (ParteA << Posicion) | ParteB;
        }

        //Mutación: Cambia el valor en algun bit
        public void Muta(Random Azar, int NumeroBits) {
            int Mascara = 1 << Azar.Next(NumeroBits);
            Genotipo ^= Mascara;
        }
    }

    //La población
    internal class Evolutivo {
        public List<Individuo> Poblacion = [];
        private Random Azar = new();

        public void Proceso(int TamanoPoblacion, int Bits, int Ciclos,
                            double Xmin, double Xmax) {
            //Genera la población
            Poblacion.Clear();
            for (int Cont = 1; Cont <= TamanoPoblacion; Cont++)
                Poblacion.Add(new Individuo(Azar, Bits));

            //El factor de conversión
            double Divide = Math.Pow(2, Bits) - 1;
            double Factor = (Xmax - Xmin) / Divide;

            //El proceso evolutivo
            for (int Cont = 1; Cont <= Ciclos; Cont++) {

                //Seleccionar al azar dos individuos de esa población: A y B
                int PosA = Azar.Next(Poblacion.Count);
                int PosB;
                do {
                    PosB = Azar.Next(Poblacion.Count);
                } while (PosB == PosA);

                //Generan un hijo que nace del cruce
                Individuo Hijo = new(Azar, Poblacion[PosA].Genotipo,
                                           Poblacion[PosB].Genotipo);

                //Además muta al Hijo
                Hijo.Muta(Azar, Bits);

                double Xa = Xmin + Poblacion[PosA].Genotipo * Factor;
                double Pa = Ecuacion(Xa); //Evaluar adaptación de A

                double Xb = Xmin + Poblacion[PosB].Genotipo * Factor;
                double Pb = Ecuacion(Xb); //Evaluar adaptación de B

                double Xh = Xmin + Hijo.Genotipo * Factor;
                double Ph = Ecuacion(Xh); //Evaluar adaptación de Hijo

                if (Ph > Pa)
                    Poblacion[PosA].Genotipo = Hijo.Genotipo;

                if (Ph > Pb)
                    Poblacion[PosB].Genotipo = Hijo.Genotipo;
            }

            //Buscar individuo con mejor adaptación de la población
            double MejorPuntaje = double.MinValue;
            int MejorIndivid = 0;
            for (int indiv = 0; indiv < Poblacion.Count; indiv++) {
                double ValorX = Xmin + Poblacion[indiv].Genotipo * Factor;
                double Puntaje = Ecuacion(ValorX);
                if (Puntaje > MejorPuntaje) {
                    MejorPuntaje = Puntaje;
                    MejorIndivid = indiv;
                }
            }

            //Imprime el mejor individuo
            double MejorValorX = Xmin + Poblacion[MejorIndivid].Genotipo * Factor;

            Console.Write("Búsqueda del mayor valor Y");
            Console.WriteLine(". Operador cruce y mutación.");
            Console.WriteLine("Entre Xmin = " + Xmin + " y Xmax = " + Xmax);
            Console.WriteLine("Número de bits: " + Bits);
            Console.WriteLine("Valor X: " + MejorValorX);
            Console.WriteLine("Valor Y: " + Ecuacion(MejorValorX));
        }

        public double Ecuacion(double x) {
            return 0.1 * Math.Pow(x, 6) + 0.6 * Math.Pow(x, 5) + (-0.9 * Math.Pow(x, 4)) - 6.2 * Math.Pow(x, 3) + 2 * x * x + 5 * x - 1;
        }
    }
}