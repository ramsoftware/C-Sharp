using System.Diagnostics;

/* Algoritmo evolutivo para simplificar ecuaciones
 * Autor: Rafael Alberto Moreno Parra
 * 
 * Problema:
 * Dada una ecuación compleja del tipo
 * Y = a*seno(b*X+c) + ... + p*seno(q*X+r) + ...
 * Con múltiples sumandos
 * 
 * donde X es la variable independiente y
 * Y la variable dependiente, hallar una función
 * que simplifique la ecuación anterior.
 * 
 * Solución:
 * Usar un algoritmo evolutivo para dar con esa
 * función que se acerque al comportamiento de la 
 * función compleja. 
 * ¿Cómo?
 * La ecuación compleja genera una serie de datos, luego
 * se busca la ecuación simple que se acerque a esa serie
 * de datos.
 * */


namespace Ejemplo; 

/* Cada individuo es una solución posible */
public class Individuo {
    const double Grado_A_Radian = Math.PI / 180.0;
    public double Distancia;
    public double[] Coef;

    public Individuo(int TotalBloques, Random Azar, double CoefMinimo, double CoefMaximo) {
        Distancia = -1;
        Coef = new double[TotalBloques * 3];

        double Multiplica = CoefMaximo - CoefMinimo;
        for (int cont = 0; cont < Coef.Length; cont += 3) {
            Coef[cont] = Azar.NextDouble() * Multiplica + CoefMinimo;
            Coef[cont + 1] = (Azar.NextDouble() * Multiplica + CoefMinimo) * Grado_A_Radian;
            Coef[cont + 2] = (Azar.NextDouble() * Multiplica + CoefMinimo) * Grado_A_Radian;
        }
    }
}

/* Aquí se hace el proceso evolutivo */
internal class Program {

    //Valores X de entrada
    public static double[] Xentrada;

    //Valores Y generados por la ecuación
    public static double[] Yesperado;

    static void Main() {
        //Toma el tiempo
        Stopwatch temporizador = new();
        temporizador.Reset();
        temporizador.Start();

        /* Único generador de números aleatorios para todo el programa */
        Random Azar = new();

        /* Genera el dataset de la ecuación compleja */
        int BloquesDataset = 30;
        double CoefMinimo = -3;
        double CoefMaximo = 3;
        double Xmin = -720;
        double Xmax = 720;
        int TotalDatos = 100;
        GeneraDataset(Azar, BloquesDataset, CoefMinimo, CoefMaximo, Xmin, Xmax, TotalDatos);

        /* Buscar la ecuación más simple */
        int TotalIndividuos = 400;
        int NumeroCiclos = 4000000;
        int BloquesMinimo = 7;
        BuscaEcuacion(Azar, BloquesMinimo, CoefMinimo, CoefMaximo, TotalIndividuos, NumeroCiclos);

        temporizador.Stop();
        Console.WriteLine("Tiempo tomado: " + temporizador.ElapsedMilliseconds);

        /* Datos */
        Console.WriteLine("\r\nConfiguración dataset original");
        Console.WriteLine("Número de bloques originales: " + BloquesDataset);
        Console.WriteLine("Valor mínimo de los coeficientes: " + CoefMinimo);
        Console.WriteLine("Valor máximo de los coeficientes: " + CoefMaximo);
        Console.WriteLine("X mínimo: " + Xmin);
        Console.WriteLine("X máximo: " + Xmax);
        Console.WriteLine("Total datos generados: " + TotalDatos);

        Console.WriteLine("\r\nConfiguración población");
        Console.WriteLine("Total individuos: " + TotalIndividuos);
        Console.WriteLine("Número de ciclos: " + NumeroCiclos);
        Console.WriteLine("Número de bloques de cada individuo: " + BloquesMinimo);
    }

    /* Genera los datos de la ecuación compleja */
    static void GeneraDataset(Random Azar, int Bloques, double CoefMinimo, double CoefMaximo, double Xmin, double Xmax, int TotalDatos) {
        /* Genera coeficientes aleatorios */
        Individuo Ambiente = new(Bloques, Azar, CoefMinimo, CoefMaximo);

        /* Genera valores X e Y */
        Xentrada = new double[TotalDatos];
        for (int Cont = 0; Cont < TotalDatos; Cont++)
            Xentrada[Cont] = Azar.NextDouble() * (Xmax - Xmin) + Xmin;
        Xentrada.Sort();

        Yesperado = new double[TotalDatos];
        for (int Cont = 0; Cont < TotalDatos; Cont++) {
            Yesperado[Cont] = Ecuacion(Ambiente, Xentrada[Cont]);
        }
    }

    /* Método que realiza el proceso de encontrar el valor máximo */
    static void BuscaEcuacion(Random Azar, int Bloques, double CoefMinimo, double CoefMaximo, int TotalIndividuos, int NumeroCiclos) {

        /* Genera población inicial con coeficientes aleatorios */
        Individuo[] Individuos = new Individuo[TotalIndividuos];
        Individuo Hijo = new(Bloques, Azar, CoefMinimo, CoefMaximo);

        for (int indiv = 0; indiv < TotalIndividuos; indiv++) {
            Individuos[indiv] = new Individuo(Bloques, Azar, CoefMinimo, CoefMaximo);
        }

        double MejorDistancia = double.MaxValue;
        int MejorIndividuo = -1;
        int numCoef = Bloques * 3;

        for (int ciclos = 1; ciclos <= NumeroCiclos; ciclos++) {

            /* Seleccionar dos inviduos aleatoriamente */
            int Indice1 = Azar.Next(TotalIndividuos);
            int Indice2;
            do {
                Indice2 = Azar.Next(TotalIndividuos);
            } while (Indice2 == Indice1);

            var Indiv1 = Individuos[Indice1];
            var Indiv2 = Individuos[Indice2];

            /* Evalúa cada individuo */
            Distancia(Indiv1);
            Distancia(Indiv2);

            if (Indiv1.Distancia < MejorDistancia) {
                MejorDistancia = Indiv1.Distancia;
                MejorIndividuo = Indice1;
            }

            if (Indiv2.Distancia < MejorDistancia) {
                MejorDistancia = Indiv2.Distancia;
                MejorIndividuo = Indice2;
            }

            /* Genera un hijo con operador cruce (se cruzan los coeficientes) */
            var coef1 = Indiv1.Coef;
            var coef2 = Indiv2.Coef;
            var coefHijo = Hijo.Coef;

            int puntoCruce = Azar.Next(numCoef);
            Array.Copy(coef1, 0, coefHijo, 0, puntoCruce + 1);
            Array.Copy(coef2, puntoCruce + 1, coefHijo, puntoCruce + 1, numCoef - (puntoCruce + 1));

            /* Muta el hijo */
            int PuntoMutacion = Azar.Next(numCoef);
            coefHijo[PuntoMutacion] += Azar.NextDouble() * 2 - 1;

            /* Evalúa el hijo */
            Hijo.Distancia = -1;
            Distancia(Hijo);

            /* Si el hijo es mejor que algún progenitor, entonces se sobre-escribe el progenitor */
            if (Hijo.Distancia < Indiv1.Distancia) {
                Array.Copy(coefHijo, coef1, coefHijo.Length);
                Indiv1.Distancia = Hijo.Distancia;
            }

            if (Hijo.Distancia < Indiv2.Distancia) {
                Array.Copy(coefHijo, coef2, coefHijo.Length);
                Indiv2.Distancia = Hijo.Distancia;
            }

            /* Informar cada 100000 intentos */
            if (ciclos % 100000 == 0) {
                Console.WriteLine($"Intento: {ciclos:N0} Mejor individuo: [{MejorIndividuo}] con Valor: [{Individuos[MejorIndividuo].Distancia}]");
            }
        }

        Console.WriteLine($"Mejor individuo: [{MejorIndividuo}] con Valor: [{Individuos[MejorIndividuo].Distancia}]");
        for (int varInterna = 0; varInterna < Individuos[MejorIndividuo].Coef.Length; varInterna++) {
            Console.WriteLine($" Variable {varInterna + 1}: {Individuos[MejorIndividuo].Coef[varInterna]}");
        }

        Console.WriteLine("Registros");
        for (int cont = 0; cont < Xentrada.Length; cont++) {
            Console.Write(Xentrada[cont] + ";" + Yesperado[cont] + ";");
            Console.WriteLine(Ecuacion(Individuos[MejorIndividuo], Xentrada[cont]));
        }
    }

    static void Distancia(Individuo Indiv) {
        if (Indiv.Distancia != -1) return;
        Indiv.Distancia = 0;
        for (int Cont = 0; Cont < Xentrada.Length; Cont++) {
            double ValorEcuacion = Ecuacion(Indiv, Xentrada[Cont]);
            Indiv.Distancia += Math.Abs(ValorEcuacion - Yesperado[Cont]);
        }
    }

    static double Ecuacion(Individuo Indiv, double X) {
        double Acumula = 0;
        for (int bloque = 0; bloque < Indiv.Coef.Length; bloque += 3) {
            Acumula += Indiv.Coef[bloque] * Math.Sin(Indiv.Coef[bloque + 1] * X + Indiv.Coef[bloque + 2]);
        }
        return Acumula;
    }
}
