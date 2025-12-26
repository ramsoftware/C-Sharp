namespace Ejemplo;

internal class Program {
    static void Main() {
        Random Azar = new(); //con semilla 700 usaría 1429497 ciclos

        /* SUDOKU original, los ceros son los números
            que se deben hallar */
        int[][] Original = [
            [1, 0, 0, 0, 0, 7, 0, 9, 0],
            [0, 3, 0, 0, 2, 0, 0, 0, 8],
            [0, 0, 9, 6, 0, 0, 5, 0, 0],
            [0, 0, 5, 3, 0, 0, 9, 0, 0],
            [0, 1, 0, 0, 8, 0, 0, 0, 2],
            [6, 0, 0, 0, 0, 4, 0, 0, 0],
            [3, 0, 0, 0, 0, 0, 0, 1, 0],
            [0, 4, 0, 0, 0, 0, 0, 0, 7],
            [0, 0, 7, 0, 0, 0, 3, 0, 0]
        ];

        /* Mantiene el ciclo hasta que resuelva el Sudoku */
        bool Finalizar;

        /* Lleva el número de iteraciones */
        int Ciclos = 0;

        /* Copia el SUDOKU original para trabajar en esta copia */
        int[][] Copia = new int[9][];
        for (int i = 0; i < 9; i++)
            Copia[i] = new int[9];

        /* Cada cuantos ciclos borra números para destrabar */
        int DESTRUYE = 700;

        /* Ciclo que llenará el sudoku completamente */
        do {
            /* Copia el sudoku original */
            for (int Fil = 0; Fil < 9; Fil++) {
                for (int Col = 0; Col < 9; Col++)
                    if (Original[Fil][Col] != 0)
                        Copia[Fil][Col] = Original[Fil][Col];
            }

            bool numValido;
            int Fila, Columna, Numero;
            do {
                /* Busca un número al azar para colocar en alguna celda */
                Fila = Azar.Next(9); /* Una posición X de 0 a 8 */
                Columna = Azar.Next(9); /* Una columna de 0 a 8 */
                Numero = Azar.Next(1, 10);  /* Un número al azar de 1 a 9 */
                numValido = true;

                /*  Chequea si el número no se repite ni vertical
                    ni horizontalmente */
                for (int Cont = 0; Cont < 9; Cont++)
                    if (Copia[Cont][Columna] == Numero ||
                        Copia[Fila][Cont] == Numero)
                        numValido = false;

            } while (!numValido);

            /*  Si el número no se repite entonces valida que 
                no se repita dentro del cuadro interno */
            int cuadroFila = Fila - Fila % 3;
            int cuadroColumna = Columna - Columna % 3;
            for (int i = cuadroFila; i < cuadroFila + 3; i++) {
                for (int j = cuadroColumna; j < cuadroColumna + 3; j++) {
                    if (Copia[i][j] == Numero) {
                        numValido = false;
                    }
                }
            }

            /* Si todo está bien, entonces se pone el número */
            if (numValido)
                Copia[Fila][Columna] = Numero;

            /* Chequea si se completó el sudoku completamente */
            Finalizar = true;
            for (Fila = 0; Fila < 9; Fila++)
                for (Columna = 0; Columna < 9; Columna++)
                    if (Copia[Fila][Columna] == 0)
                        Finalizar = false;

            /*  Cada cierto número de ciclos, para destrabar,
                borra la tercera parte de lo completado */
            Ciclos++;
            if (Ciclos % DESTRUYE == 0) { 
                Console.WriteLine("Ciclos: " + Ciclos);
                for (Fila = 0; Fila < 9; Fila++)
                    for (Columna = 0; Columna < 9; Columna++)
                        if (Azar.NextDouble() < 0.34)
                            Copia[Fila][Columna] = 0;
                }
        } while (!Finalizar);

        //Imprime el sudoku original
        Console.WriteLine("Sudoku Original");
        for (int Fila = 0; Fila < 9; Fila++) {
            for (int Columna = 0; Columna < 9; Columna++)
                if (Original[Fila][Columna] == 0)
                    Console.Write("_ ");
                else
                    Console.Write(Original[Fila][Columna] + " ");
            Console.WriteLine(" ");
        }

        //Imprime el sudoku resuelto
        Console.WriteLine("\r\nCiclos totales usados: " + Ciclos);
        Console.WriteLine("Sudoku Resuelto");
        for (int Fila = 0; Fila < 9; Fila++) {
            for (int Columna = 0; Columna < 9; Columna++)
                Console.Write(Copia[Fila][Columna] + " ");
            Console.WriteLine(" ");
        }
    }
}
