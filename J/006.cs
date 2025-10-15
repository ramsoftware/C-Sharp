namespace Ejemplo {
    internal class Program {
        static void Main() {
            //Buscar el mayor valor de una ecuación
            //modificando números binarios
            Evolutivo objEvl = new();

            int TamanoPoblacion = 100;
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

        //Al nacer, tendrá un valor double entre 0 y 1
        public Individuo(Random Azar, int NumeroBits) {
            Genotipo = Azar.Next((int)Math.Pow(2, NumeroBits));
        }

        //Cambia el valor en algun bit
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

                //Seleccionar al azar dos individuos
                //de esa población: A y B
                int PosA = Azar.Next(Poblacion.Count);
                int PosB;
                do {
                    PosB = Azar.Next(Poblacion.Count);
                } while (PosB == PosA);

                double Xa = Xmin + Poblacion[PosA].Genotipo * Factor;
                double Pa = Ecuacion(Xa); //Evaluar adaptación de A

                double Xb = Xmin + Poblacion[PosB].Genotipo * Factor;
                double Pb = Ecuacion(Xb); //Evaluar adaptación de B

                //Si adaptación de A es mejor que adaptación de B entonces
                if (Pa > Pb) {
                    //Eliminar individuo B y duplicar individuo A
                    Poblacion[PosB].Genotipo = Poblacion[PosA].Genotipo;
                    //Modificar levemente al azar el nuevo duplicado
                    Poblacion[PosB].Muta(Azar, Bits);
                }
                else if (Pb > Pa) {
                    //Eliminar individuo A y duplicar individuo B
                    Poblacion[PosA].Genotipo = Poblacion[PosB].Genotipo;
                    //Modificar levemente al azar el nuevo duplicado
                    Poblacion[PosA].Muta(Azar, Bits);
                }
            }

            //Buscar individuo con mejor adaptación de la población
            double MejorPuntaje = double.MinValue;
            int Mejor = 0;
            for (int indiv = 0; indiv < Poblacion.Count; indiv++) {
                double ValorX = Xmin + Poblacion[indiv].Genotipo * Factor;
                double Puntaje = Ecuacion(ValorX);
                if (Puntaje > MejorPuntaje) {
                    MejorPuntaje = Puntaje;
                    Mejor = indiv;
                }
            }

            //Imprime el mejor individuo
            double MejorValorX = Xmin + Poblacion[Mejor].Genotipo * Factor;

            Console.WriteLine("Búsqueda del mayor valor Y de una ecuación");
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
