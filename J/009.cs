namespace Ejemplo {
    internal class Program {
        static void Main() {
            //Buscar el mayor valor de una ecuación
            //modificando números de tipo double
            Evolutivo objEvl = new();

            int TamanoPoblacion = 200;
            int Ciclos = 200000;
            double ValorMinimo = -10;
            double ValorMaximo = 10;
            objEvl.Proceso(TamanoPoblacion, Ciclos, ValorMinimo, ValorMaximo);
        }
    }

    //Cómo es el individuo
    internal class Individuo {
        public double valA, valB, valC, valD, valE;

        //Al nacer, tendrá un valor double entre ValMin y ValMax
        public Individuo(Random Azar, double ValMin, double ValMax) {
            valA = Azar.NextDouble() * (ValMax - ValMin) + ValMin;
            valB = Azar.NextDouble() * (ValMax - ValMin) + ValMin;
            valC = Azar.NextDouble() * (ValMax - ValMin) + ValMin;
            valD = Azar.NextDouble() * (ValMax - ValMin) + ValMin;
            valE = Azar.NextDouble() * (ValMax - ValMin) + ValMin;
        }

        //Cambia el valor de una variable
        public void Muta(Random Azar, double ValMin, double ValMax) {
            switch (Azar.Next(5)) {
                case 0:
                    valA = Azar.NextDouble() * (ValMax - ValMin) + ValMin;
                    break;

                case 1:
                    valB = Azar.NextDouble() * (ValMax - ValMin) + ValMin;
                    break;

                case 2:
                    valC = Azar.NextDouble() * (ValMax - ValMin) + ValMin;
                    break;

                case 3:
                    valD = Azar.NextDouble() * (ValMax - ValMin) + ValMin;
                    break;

                case 4:
                    valE = Azar.NextDouble() * (ValMax - ValMin) + ValMin;
                    break;
            }
        }
    }

    //La población
    internal class Evolutivo {
        public List<Individuo> Poblacion = [];
        private Random Azar = new();

        public void Proceso(int TamanoPoblacion, int Ciclos,
                            double Minimo, double Maximo) {
            //Genera la población
            Poblacion.Clear();
            for (int Cont = 1; Cont <= TamanoPoblacion; Cont++)
                Poblacion.Add(new Individuo(Azar, Minimo, Maximo));

            //El proceso evolutivo
            for (int Cont = 1; Cont <= Ciclos; Cont++) {
                //Seleccionar al azar dos individuos de esa población: A y B
                int PosA = Azar.Next(Poblacion.Count);
                int PosB;
                do {
                    PosB = Azar.Next(Poblacion.Count);
                } while (PosB == PosA);

                //Evaluar adaptación de A
                double PuntajeA = Ecuacion(Poblacion[PosA].valA, Poblacion[PosA].valB,
                                            Poblacion[PosA].valC, Poblacion[PosA].valD,
                                            Poblacion[PosA].valE);

                //Evaluar adaptación de B
                double PuntajeB = Ecuacion(Poblacion[PosB].valA, Poblacion[PosB].valB,
                                            Poblacion[PosB].valC, Poblacion[PosB].valD,
                                            Poblacion[PosB].valE);

                //Si adaptación de A es mejor que adaptación de B entonces
                if (PuntajeA > PuntajeB) {
                    //Eliminar individuo B y duplicar individuo A
                    Poblacion[PosB].valA = Poblacion[PosA].valA;
                    Poblacion[PosB].valB = Poblacion[PosA].valB;
                    Poblacion[PosB].valC = Poblacion[PosA].valC;
                    Poblacion[PosB].valD = Poblacion[PosA].valD;
                    Poblacion[PosB].valE = Poblacion[PosA].valE;

                    //Modificar levemente al azar el nuevo duplicado
                    Poblacion[PosB].Muta(Azar, Minimo, Maximo);
                }
                else {
                    //Eliminar individuo A y duplicar individuo B
                    Poblacion[PosA].valA = Poblacion[PosB].valA;
                    Poblacion[PosA].valB = Poblacion[PosB].valB;
                    Poblacion[PosA].valC = Poblacion[PosB].valC;
                    Poblacion[PosA].valD = Poblacion[PosB].valD;
                    Poblacion[PosA].valE = Poblacion[PosB].valE;

                    //Modificar levemente al azar el nuevo duplicado
                    Poblacion[PosA].Muta(Azar, Minimo, Maximo);
                }
            }

            //Buscar individuo con mejor adaptación de la población
            double MejorPuntaje = double.MinValue;
            int Mejor = 0;
            for (int indiv = 0; indiv < Poblacion.Count; indiv++) {
                double Puntaje = Ecuacion(Poblacion[indiv].valA, Poblacion[indiv].valB,
                                            Poblacion[indiv].valC, Poblacion[indiv].valD,
                                            Poblacion[indiv].valE); ;
                if (Puntaje > MejorPuntaje) {
                    MejorPuntaje = Puntaje;
                    Mejor = indiv;
                }
            }

            //Imprime el mejor individuo
            Console.Write("Búsqueda del mayor valor Y");
            Console.WriteLine(" de una ecuación de múltiples variables");
            Console.Write("Entre Mínimo = " + Minimo);
            Console.WriteLine(" y Máximo = " + Maximo);
            Console.WriteLine("Variable A: " + Poblacion[Mejor].valA);
            Console.WriteLine("Variable B: " + Poblacion[Mejor].valB);
            Console.WriteLine("Variable C: " + Poblacion[Mejor].valC);
            Console.WriteLine("Variable D: " + Poblacion[Mejor].valD);
            Console.WriteLine("Variable E: " + Poblacion[Mejor].valE);
            Console.WriteLine("Valor Y: " + MejorPuntaje);
        }

        public double Ecuacion(double a, double b, double c,
                                double d, double e) {
            return 0.3 * Math.Sin(a * c - d) +
                    1.7 * Math.Sin(e * b + c) +
                    2.8 * Math.Cos(3.1 * b - 4.4 * a) -
                    3.1 * Math.Sin(a * d - e * c) +
                    0.7 * Math.Cos(a + b * c - d);
        }
    }
}