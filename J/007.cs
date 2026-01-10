namespace Ejemplo;

internal class Program {

    static void Main() {
        /* Único generador de números aleatorios para todo el programa */
        Random Azar = new();

        /* Iniciar el proceso */
        double MinValor = -10;
        double MaxValor = 10;
        int TotalIndividuos = 100;
        int NumeroCiclos = 50000;
        int TotalBits = 10; //Número de bits para representar cada individuo
        int NumeroVariables = 5; //Número de variables en la ecuación
        MaximoValor(Azar, MinValor, MaxValor, TotalIndividuos, NumeroCiclos, TotalBits, NumeroVariables);
    }

    /* Método que realiza el proceso de encontrar el valor máximo */
    static void MaximoValor(Random Azar, double MinValor, double MaxValor, int TotalIndividuos, int NumeroCiclos, int TotalBits, int NumeroVariables) {

        /* Genera población inicial con individuos con valores aleatorios */
        int[][] Individuos = new int[TotalIndividuos][];

        for (int indiv = 0; indiv < TotalIndividuos; indiv++) {
            Individuos[indiv] = new int[NumeroVariables];
            for (int varInterna = 0; varInterna < NumeroVariables; varInterna++) {
                Individuos[indiv][varInterna] = Azar.Next((int)Math.Pow(2, TotalBits));
            }
        }

        int Contador = 0;
        double MejorPuntaje = double.MinValue;
        int MejorIndividuo = -1;
        double MayorValorY;

        //El factor de conversión
        double Divide = Math.Pow(2, TotalBits) - 1;
        double Factor = (MaxValor - MinValor) / Divide;

        for (int ciclos = 1; ciclos <= NumeroCiclos; ciclos++) {

            /* Seleccionar dos inviduos aleatoriamente */
            int Indice1 = Azar.Next(TotalIndividuos);
            int Indice2;
            do {
                Indice2 = Azar.Next(TotalIndividuos);
            } while (Indice2 == Indice1);

            /* Evalúa cada individuo */
            double Puntaje1 = Ecuacion(Individuos[Indice1], MinValor, Factor);
            double Puntaje2 = Ecuacion(Individuos[Indice2], MinValor, Factor);

            if (Puntaje1 > MejorPuntaje) { MejorPuntaje = Puntaje1; MejorIndividuo = Indice1; }
            if (Puntaje2 > MejorPuntaje) { MejorPuntaje = Puntaje2; MejorIndividuo = Indice2; }

            /* Genera un hijo con operador cruce */
            int[] Hijo = new int[NumeroVariables];

            int PuntoCruce = Azar.Next(NumeroVariables);
            for (int varInterna = 0; varInterna < NumeroVariables; varInterna++) {
                if (varInterna <= PuntoCruce)
                    Hijo[varInterna] = Individuos[Indice1][varInterna];
                else
                    Hijo[varInterna] = Individuos[Indice2][varInterna];
            }

            /* Muta el hijo */
            int PuntoMutacion = Azar.Next(NumeroVariables);
            Hijo[PuntoMutacion] = Azar.Next((int)Math.Pow(2, TotalBits));

            /* Evalúa el hijo */
            double PuntajeHijo = Ecuacion(Hijo, MinValor, Factor);

            /* Si el hijo es mejor que algún progenitor, entonces se sobre-escribe el progenitor */
            if (PuntajeHijo > Puntaje1)
                Individuos[Indice1] = Hijo;

            if (PuntajeHijo > Puntaje2)
                Individuos[Indice2] = Hijo;

            /* Incrementar el contador e informar cada 1000 intentos */
            Contador++;
            if (Contador % 1000 == 0) {
                MayorValorY = Ecuacion(Individuos[MejorIndividuo], MinValor, Factor);
                Console.WriteLine($"Intento: {Contador:N0} Mejor individuo: [{MejorIndividuo}] con Valor: [{MayorValorY}]");
            }
        }

        MayorValorY = Ecuacion(Individuos[MejorIndividuo], MinValor, Factor);
        Console.WriteLine($"Intento: {Contador:N0} Mejor individuo: [{MejorIndividuo}] con Valor: [{MayorValorY}]");
    }

    static double Ecuacion(int[] Variables, double MinValor, double Factor) {
        double a = MinValor + Variables[0] * Factor;
        double b = MinValor + Variables[1] * Factor;
        double c = MinValor + Variables[2] * Factor;
        double d = MinValor + Variables[3] * Factor;
        double e = MinValor + Variables[4] * Factor;

        return 0.3 * Math.Sin(a * c - d) +
                1.7 * Math.Sin(e * b + c) +
                2.8 * Math.Cos(3.1 * b - 4.4 * a) -
                3.1 * Math.Sin(a * d - e * c) +
                0.7 * Math.Cos(a + b * c - d);
    }
}