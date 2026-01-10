namespace Ejemplo;

internal class Program {
    public static char[] Letras;

    static void Main() {
        /* Único generador de números aleatorios para todo el programa */
        Random Azar = new();

        /* Alfabeto de letras */
        Letras = "abcdefghijklmnopqrstuvwxyz ".ToCharArray();

        /* Cadena original a "adivinar" */
        string Original = "esta es una prueba para dar con una cadena";

        /* Iniciar el proceso */
        Proceso(Azar, Original);
    }

    /* Método que realiza el proceso de "adivinar" la cadena original */
    static void Proceso(Random Azar, string Original) {
        /* Trabaja con arreglos de caracteres */
        char[] OriginalArray = Original.ToCharArray();

        /* Genera población inicial con individuos que tengan la 
			   misma longitud de la cadena original */
        int TotalIndividuos = 1000;
        char[][] Individuos = new char[TotalIndividuos][];

        int Tamano = OriginalArray.Length;
        for (int indiv = 0; indiv < TotalIndividuos; indiv++) {
            Individuos[indiv] = new char[Tamano];
            for (int pos = 0; pos < Tamano; pos++)
                Individuos[indiv][pos] = Letras[Azar.Next(Letras.Length)];
        }

        int Contador = 0;
        int MejorPuntaje = -1;
        int MejorIndividuo = -1;

        while (true) {

            /* Seleccionar dos inviduos aleatoriamente */
            int Indice1 = Azar.Next(TotalIndividuos);
            int Indice2;
            do {
                Indice2 = Azar.Next(TotalIndividuos);
            } while (Indice2 == Indice1);

            /* Genera los hijos */
            char[] HijoA = new char[Tamano];
            int Pos = Azar.Next(Tamano);

            // Copiar desde Padre [0..Pos]
            Array.Copy(Individuos[Indice1], 0, HijoA, 0, Pos + 1);

            // Copiar desde Madre [Pos+1..fin]
            Array.Copy(Individuos[Indice2], Pos + 1, HijoA, Pos + 1, Individuos[Indice2].Length - (Pos + 1));

            char[] HijoB = new char[Tamano];

            // Copiar desde Padre [0..Pos]
            Array.Copy(Individuos[Indice2], 0, HijoB, 0, Pos + 1);

            // Copiar desde Madre [Pos+1..fin]
            Array.Copy(Individuos[Indice1], Pos + 1, HijoB, Pos + 1, Individuos[Indice1].Length - (Pos + 1));

            /* Evalúa cada individuo */
            int Puntaje1 = Puntuar(Individuos[Indice1], OriginalArray);
            int Puntaje2 = Puntuar(Individuos[Indice2], OriginalArray);
            int PuntajeHijoA = Puntuar(HijoA, OriginalArray);
            int PuntajeHijoB = Puntuar(HijoB, OriginalArray);

            /* Si el hijo es mejor que algún progenitor, entonces se sobre-escribe el progenitor */
            if (PuntajeHijoA > Puntaje1)
                Array.Copy(HijoA, Individuos[Indice1], Individuos[Indice1].Length);
            if (PuntajeHijoA > Puntaje2)
                Array.Copy(HijoA, Individuos[Indice2], Individuos[Indice2].Length);

            if (PuntajeHijoB > Puntaje1)
                Array.Copy(HijoB, Individuos[Indice1], Individuos[Indice1].Length);
            if (PuntajeHijoB > Puntaje2)
                Array.Copy(HijoB, Individuos[Indice2], Individuos[Indice2].Length);

            if (Puntaje1 > MejorPuntaje) { MejorPuntaje = Puntaje1; MejorIndividuo = Indice1; }
            if (Puntaje2 > MejorPuntaje) { MejorPuntaje = Puntaje2; MejorIndividuo = Indice2; }

            /* Evalúa si un individuo ha acertado a la cadena original */
            if (Puntaje1 == OriginalArray.Length || Puntaje2 == OriginalArray.Length) {
                break;
            }

            /* Incrementar el contador e informar cada 1000 intentos */
            Contador++;
            if (Contador % 1000 == 0) {
                Console.WriteLine($"Intento: {Contador:N0} Mejor individuo: [{new string(Individuos[MejorIndividuo])}]");
            }
        }

        Console.WriteLine($"Intento: {Contador:N0} Mejor individuo: [{new string(Individuos[MejorIndividuo])}]");
    }

    /* Evalúa la similitud entre dos arreglos de caracteres */
    static int Puntuar(char[] charArreglo1, char[] charArreglo2) {
        int Similitud = 0;
        for (int i = 0; i < charArreglo1.Length; i++) {
            if (charArreglo1[i] == charArreglo2[i]) {
                Similitud++;
            }
        }
        return Similitud;
    }
}