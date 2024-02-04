namespace Ejemplo {
    internal class Program {
        static void Main() {
            //Buscar el mayor valor de una ecuación modificando números de tipo double
            Poblacion pobl = new Poblacion();

            int TotalPoblacion = 100;
            int TotalCiclos = 90000;
            double ValorMinimo = -10;
            double ValorMaximo = 10;
            pobl.Proceso(TotalPoblacion, TotalCiclos, ValorMinimo, ValorMaximo);
        }
    }

    //Cómo es el individuo
    internal class Individuo {
        public double valA, valB, valC, valD, valE;

        //Al nacer, tendrá un valor double entre 0 y 1
        public Individuo(Random Azar, double ValorMinimo, double ValorMaximo) {
            valA = Azar.NextDouble() * (ValorMaximo - ValorMinimo) + ValorMinimo;
            valB = Azar.NextDouble() * (ValorMaximo - ValorMinimo) + ValorMinimo;
            valC = Azar.NextDouble() * (ValorMaximo - ValorMinimo) + ValorMinimo;
            valD = Azar.NextDouble() * (ValorMaximo - ValorMinimo) + ValorMinimo;
            valE = Azar.NextDouble() * (ValorMaximo - ValorMinimo) + ValorMinimo;
        }

        //Cambia el valor de una variable
        public void Muta(Random Azar, double ValorMinimo, double ValorMaximo) {
            switch (Azar.Next(5)) {
                case 0: valA = Azar.NextDouble() * (ValorMaximo - ValorMinimo) + ValorMinimo; break;
                case 1: valB = Azar.NextDouble() * (ValorMaximo - ValorMinimo) + ValorMinimo; break;
                case 2: valC = Azar.NextDouble() * (ValorMaximo - ValorMinimo) + ValorMinimo; break;
                case 3: valD = Azar.NextDouble() * (ValorMaximo - ValorMinimo) + ValorMinimo; break;
                case 4: valE = Azar.NextDouble() * (ValorMaximo - ValorMinimo) + ValorMinimo; break;
            }
        }
    }

    //La población
    internal class Poblacion {
        public List<Individuo> Individuos = new List<Individuo>();
        private Random Azar = new Random();

        public void Proceso(int TotalIndividuos, int TotalCiclos, double Minimo, double Maximo) {
            //Genera la población
            Individuos.Clear();
            for (int Contador = 1; Contador <= TotalIndividuos; Contador++)
                Individuos.Add(new Individuo(Azar, Minimo, Maximo));

            //El proceso evolutivo
            for (int Contador = 1; Contador <= TotalCiclos; Contador++) {
                //Seleccionar al azar dos individuos de esa población: A y B
                int PosA = Azar.Next(Individuos.Count);
                int PosB;
                do {
                    PosB = Azar.Next(Individuos.Count);
                } while (PosB == PosA);

                double PuntajeA = Ecuacion(Individuos[PosA].valA, Individuos[PosA].valB, Individuos[PosA].valC, Individuos[PosA].valD, Individuos[PosA].valE); //Evaluar adaptación de A
                double PuntajeB = Ecuacion(Individuos[PosB].valA, Individuos[PosB].valB, Individuos[PosB].valC, Individuos[PosB].valD, Individuos[PosB].valE); //Evaluar adaptación de B

                //Si adaptación de A es mejor que adaptación de B entonces
                if (PuntajeA > PuntajeB) {
                    //Eliminar individuo B y duplicar individuo A
                    Individuos[PosB].valA = Individuos[PosA].valA;
                    Individuos[PosB].valB = Individuos[PosA].valB;
                    Individuos[PosB].valC = Individuos[PosA].valC;
                    Individuos[PosB].valD = Individuos[PosA].valD;
                    Individuos[PosB].valE = Individuos[PosA].valE;

                    //Modificar levemente al azar el nuevo duplicado
                    Individuos[PosB].Muta(Azar, Minimo, Maximo);
                }
                else {
                    //Eliminar individuo A y duplicar individuo B
                    Individuos[PosA].valA = Individuos[PosB].valA;
                    Individuos[PosA].valB = Individuos[PosB].valB;
                    Individuos[PosA].valC = Individuos[PosB].valC;
                    Individuos[PosA].valD = Individuos[PosB].valD;
                    Individuos[PosA].valE = Individuos[PosB].valE;

                    //Modificar levemente al azar el nuevo duplicado
                    Individuos[PosA].Muta(Azar, Minimo, Maximo);
                }
            }

            //Buscar individuo con mejor adaptación de la población
            double MejorPuntaje = double.MinValue;
            int MejorIndivid = 0;
            for (int indiv = 0; indiv < Individuos.Count; indiv++) {
                double Puntaje = Ecuacion(Individuos[indiv].valA, Individuos[indiv].valB, Individuos[indiv].valC, Individuos[indiv].valD, Individuos[indiv].valE); ;
                if (Puntaje > MejorPuntaje) {
                    MejorPuntaje = Puntaje;
                    MejorIndivid = indiv;
                }
            }

            //Imprime el mejor individuo
            Console.WriteLine("Búsqueda del mayor valor Y de una ecuación de múltiples variables");
            Console.WriteLine("Entre Mínimo = " + Minimo + " y Máximo = " + Maximo);
            Console.WriteLine("Variable A: " + Individuos[MejorIndivid].valA);
            Console.WriteLine("Variable B: " + Individuos[MejorIndivid].valB);
            Console.WriteLine("Variable C: " + Individuos[MejorIndivid].valC);
            Console.WriteLine("Variable D: " + Individuos[MejorIndivid].valD);
            Console.WriteLine("Variable E: " + Individuos[MejorIndivid].valE);
            Console.WriteLine("Valor Y: " + MejorPuntaje);
        }

        public double Ecuacion(double a, double b, double c, double d, double e) {
            return 0.3 * Math.Sin(a * c - d) +
                    1.7 * Math.Sin(e * b + c) +
                    2.8 * Math.Cos(3.1 * b - 4.4 * a) -
                    3.1 * Math.Sin(a * d - e * c) +
                    0.7 * Math.Cos(a + b * c - d);
        }
    }
}