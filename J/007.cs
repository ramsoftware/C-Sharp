namespace Ejemplo {
    internal class Program {
        static void Main() {
            //Buscar el mayor valor de una ecuación. Operador cruce y mutación
            Poblacion pobl = new();

            int TotalIndividuos = 1000;
            int TotalCiclos = 90000;
            int NumeroBits = 20;
            double ValorXminimo = -4;
            double ValorXmaximo = 1;
            pobl.Proceso(TotalIndividuos, NumeroBits, TotalCiclos, ValorXminimo, ValorXmaximo);
        }
    }

    //Cómo es el individuo
    internal class Individuo {
        public int Genotipo;

        //Al nacer, tendrá un valor dependiendo del número de bits
        public Individuo(Random Azar, int NumeroBits) {
            Genotipo = Azar.Next((int) Math.Pow(2, NumeroBits));
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
    internal class Poblacion {
        public List<Individuo> Individuos = new List<Individuo>();
        private Random Azar = new Random();

        public void Proceso(int TotalIndividuos, int NumeroBits, int TotalCiclos, double Xmin, double Xmax) {
            //Genera la población
            Individuos.Clear();
            for (int Contador = 1; Contador <= TotalIndividuos; Contador++)
                Individuos.Add(new Individuo(Azar, NumeroBits));

            //El divisor 
            double Divide = Math.Pow(2, NumeroBits) - 1;

            //El proceso evolutivo
            for (int Contador = 1; Contador <= TotalCiclos; Contador++) {
                //Seleccionar al azar dos individuos de esa población: A y B
                int PosA = Azar.Next(Individuos.Count);
                int PosB;
                do {
                    PosB = Azar.Next(Individuos.Count);
                } while (PosB == PosA);

                //Generan un hijo que nace del cruce
                Individuo Hijo = new Individuo(Azar, Individuos[PosA].Genotipo, Individuos[PosB].Genotipo);

                //Además muta al Hijo
                Hijo.Muta(Azar, NumeroBits);

                double ValorXa = Xmin + Individuos[PosA].Genotipo * (Xmax - Xmin) / Divide;
                double PuntajeA = Ecuacion(ValorXa); //Evaluar adaptación de A

                double ValorXb = Xmin + Individuos[PosB].Genotipo * (Xmax - Xmin) / Divide;
                double PuntajeB = Ecuacion(ValorXb); //Evaluar adaptación de B

                double ValorXHijo = Xmin + Hijo.Genotipo * (Xmax - Xmin) / Divide;
                double PuntajeHijo = Ecuacion(ValorXHijo); //Evaluar adaptación de Hijo

                if (PuntajeHijo > PuntajeA) Individuos[PosA].Genotipo = Hijo.Genotipo;
                if (PuntajeHijo > PuntajeB) Individuos[PosB].Genotipo = Hijo.Genotipo;
            }

            //Buscar individuo con mejor adaptación de la población
            double MejorPuntaje = double.MinValue;
            int MejorIndivid = 0;
            for (int indiv = 0; indiv < Individuos.Count; indiv++) {
                double ValorX = Xmin + Individuos[indiv].Genotipo * (Xmax - Xmin) / Divide;
                double Puntaje = Ecuacion(ValorX);
                if (Puntaje > MejorPuntaje) {
                    MejorPuntaje = Puntaje;
                    MejorIndivid = indiv;
                }
            }

            //Imprime el mejor individuo
            double MejorValorX = Xmin + Individuos[MejorIndivid].Genotipo * (Xmax - Xmin) / Divide;

            Console.WriteLine("Búsqueda del mayor valor Y de una ecuación. Operador cruce y mutación.");
            Console.WriteLine("Y = 0.1 * Math.Pow(x, 6) + 0.6 * Math.Pow(x, 5) - 0.9 * Math.Pow(x, 4) - 6.2 * Math.Pow(x, 3) + 2 * x * x + 5 * x - 1");
            Console.WriteLine("Entre Xmin = " + Xmin + " y Xmax = " + Xmax);
            Console.WriteLine("Número de bits: " + NumeroBits);
            Console.WriteLine("Valor X: " + MejorValorX);
            Console.WriteLine("Valor Y: " + Ecuacion(MejorValorX));
        }

        public double Ecuacion(double x) {
            return 0.1 * Math.Pow(x, 6) + 0.6 * Math.Pow(x, 5) - 0.9 * Math.Pow(x, 4) - 6.2 * Math.Pow(x, 3) + 2 * x * x + 5 * x - 1;
        }
    }
}

